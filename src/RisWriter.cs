using RisHelper.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RisHelper
{
    public static class RisWriter
    {
        public static async Task<Stream> WriteAsync(IEnumerable<RisRecord> records)
        {
            if (records == null)
            {
                throw new ArgumentNullException(nameof(records));
            }

            PropertyInfo[] properties = typeof(RisRecord).GetProperties();

            MemoryStream stream = new MemoryStream();
            using StreamWriter streamWriter = new StreamWriter(stream, Encoding.UTF8, 1024, true);

            foreach (RisRecord record in records)
            {
                foreach (PropertyInfo property in properties)
                {
                    if (Mapping.TryGetPropertyContext(property, out PropertyContext propertyContext))
                    {
                        Field[] fields = propertyContext.Converter.Write(propertyContext.Tag, property.GetValue(record, null));
                        foreach (Field field in fields)
                        {
                            await streamWriter.WriteLineAsync(field.ToString());
                        }
                    }
                }

                await streamWriter.WriteLineAsync(Constants.EndingTag + Constants.FieldValueSeparator);
            }

            await streamWriter.FlushAsync();
            stream.Position = 0;

            return stream;
        }

        public static async Task<Stream> WriteAsync(IAsyncEnumerable<RisRecord> records)
        {
            if (records == null)
            {
                throw new ArgumentNullException(nameof(records));
            }

            PropertyInfo[] properties = typeof(RisRecord).GetProperties();

            MemoryStream stream = new MemoryStream();
            using StreamWriter streamWriter = new StreamWriter(stream, Encoding.UTF8, 1024, true);

            await foreach (RisRecord record in records)
            {
                foreach (PropertyInfo property in properties)
                {
                    if (Mapping.TryGetPropertyContext(property, out PropertyContext propertyContext))
                    {
                        Field[] fields = propertyContext.Converter.Write(propertyContext.Tag, property.GetValue(record, null));
                        foreach (Field field in fields)
                        {
                            await streamWriter.WriteLineAsync(field.ToString());
                        }
                    }
                }

                await streamWriter.WriteLineAsync(Constants.EndingTag + Constants.FieldValueSeparator);
            }

            await streamWriter.FlushAsync();
            stream.Position = 0;

            return stream;
        }

        public static async Task WriteAsync(IEnumerable<RisRecord> records, string filePath)
        {
            if (records == null)
            {
                throw new ArgumentNullException(nameof(records));
            }
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            Stream stream = await WriteAsync(records);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }

        public static async Task WriteAsync(IAsyncEnumerable<RisRecord> records, string filePath)
        {
            if (records == null)
            {
                throw new ArgumentNullException(nameof(records));
            }
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            Stream stream = await WriteAsync(records);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
    }
}
