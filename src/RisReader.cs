using RisHelper.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace RisHelper
{
    public static class RisReader
    {
        public static async IAsyncEnumerable<RisRecord> ReadAsync(Stream stream,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            stream.Position = 0;
            using StreamReader reader = new StreamReader(stream, Encoding.UTF8, true, 1024, true);

            string? line;
            List<Field> fields = [];
            while ((line = await reader.ReadLineAsync()) != null)
            {
                if (IsEndingField(line))
                {
                    RisRecord record = BuildRecord(fields);
                    fields.Clear();
                    yield return record;
                }
                else if (TryParseField(line, out Field field))
                {
                    fields.Add(field);
                }
                else
                {
                    throw new InvalidOperationException(
                        "Invalid RIS format.");
                }
            }

            yield break;
        }

        public static IAsyncEnumerable<RisRecord> ReadAsync(string filePath,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            if (File.Exists(filePath) == false)
            {
                throw new FileNotFoundException(
                    $"Invalid file path \"{filePath}\".");
            }

            FileStream stream = File.Open(filePath, FileMode.Open);
            return ReadAsync(stream, cancellationToken);
        }

        private static RisRecord BuildRecord(IEnumerable<Field> fields)
        {
            RisRecord record = new RisRecord();
            foreach (Field field in fields)
            {
                if (Mapping.TryGetPropertyContext(field.Tag, out PropertyContext propertyContext))
                {
                    object destValue = propertyContext.Property.GetValue(record);
                    propertyContext.Property.SetValue(
                        record,
                        propertyContext.Converter.Read(field.Tag, field.Value, destValue),
                        null);
                }
            }

            return record;
        }

        private static bool IsEndingField(string line)
            => string.Equals(line.Split(Constants.FieldValueSeparator)[0], Constants.EndingTag);

        private static bool TryParseField(string line, out Field field)
        {
            field = null!;
            string[] fieldData = line.Split(Constants.FieldValueSeparator);
            if (fieldData.Length != 2)
            {
                return false;
            }
            string tag = fieldData[0].Trim();
            string value = fieldData[1].Trim();
            if (string.IsNullOrWhiteSpace(tag) || string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            field = new Field(tag, value);
            return true;
        }
    }
}
