using System.IO;
using System.Reflection;

namespace RisHelper.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var samplePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\..\..\data\";

            var records = RisReader.Read(Path.Combine(samplePath, "sample-read.ris"));

            RisWriter.Write(records, Path.Combine(samplePath, "sample-write.ris"));
        }
    }
}
