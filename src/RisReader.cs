using RisHelper.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace RisHelper
{
    public static class RisReader
    {
        public static IEnumerable<RisRecord> Read(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (File.Exists(path) == false)
            {
                throw new FileNotFoundException($"Invalid path {path}");
            }

            return Read(File.ReadAllBytes(path));
        }

        public static IEnumerable<RisRecord> Read(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            using (var memoryStream = new MemoryStream(bytes))
            {
                using (var streamReader = new StreamReader(memoryStream))
                {
                    var content = streamReader.ReadToEnd();
                    var entries = Regex.Split(content, Constants.EntrySeparator);
                    var records = ReadRecords(entries);
                    return records;
                }
            }
        }

        private static IEnumerable<RisRecord> ReadRecords(string[] entries)
        {
            List<RisRecord> records = new List<RisRecord>();

            if (entries == null)
            {
                return records;
            }

            foreach (var entry in entries)
            {
                var record = ReadRecord(entry);
                if (record != null)
                {
                    records.Add(record);
                }
            }

            return records;
        }

        private static RisRecord ReadRecord(string entry)
        {
            if (string.IsNullOrEmpty(entry))
            {
                return null;
            }

            var record = new RisRecord();
            var fields = Regex.Split(entry, Constants.FieldSeparator);
            foreach (var field in fields)
            {
                var fieldArray = Regex.Split(field, Constants.FieldValueSeparator);
                if (fieldArray.Length == 2)
                {
                    if (Mapping.TryGetPropertyContext(fieldArray[0], out PropertyContext propertyContext))
                    {
                        var tag = fieldArray[0];
                        var srcValue = fieldArray[1];
                        var destValue = propertyContext.Property.GetValue(record);
                        propertyContext.Property.SetValue(record, propertyContext.Converter.Read(tag, srcValue, destValue), null);
                    }
                }
            }

            return record;
        }
    }
}
