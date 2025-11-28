using System.Reflection;

namespace RisHelper.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var samplePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\..\..\data\";

            IAsyncEnumerable<RisRecord> records = RisReader.ReadAsync(Path.Combine(samplePath, "sample-read.ris"));

            List<RisRecord> data = [];
            await foreach (RisRecord record in records)
            {
                record.Type = RisRecordType.ART;
                data.Add(record);
            }

            await RisWriter.WriteAsync(data, Path.Combine(samplePath, "sample-write.ris"));
        }
    }
}
