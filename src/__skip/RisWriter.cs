using RisHelper.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RisHelper
{
    public static class RisWriter
    {
        public static byte[] Write(IEnumerable<RisRecord> records)
        {
            if (records == null)
            {
                throw new ArgumentNullException(nameof(records));
            }

            var stringBuilder = new StringBuilder(100);

            var properties = typeof(RisRecord).GetProperties();

            foreach (var record in records)
            {
                foreach (var property in properties)
                {
                    if (Mapping.TryGetPropertyContext(property, out PropertyContext propertyContext))
                    {
                        var fields = propertyContext.Converter.Write(propertyContext.Tag, property.GetValue(record, null));
                        if (fields != null)
                        {
                            foreach (var field in fields)
                            {
                                stringBuilder.AppendLine(field);
                            }
                        }
                    }
                }

                stringBuilder.AppendLine(Constants.EndTag + Constants.FieldValueSeparator);
            }

            var bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());

            return bytes;
        }

        public static void Write(IEnumerable<RisRecord> records, string path)
        {
            if (records == null)
            {
                throw new ArgumentNullException(nameof(records));
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            var bytes = Write(records);

            File.WriteAllBytes(path, bytes);
        }
    }
}
