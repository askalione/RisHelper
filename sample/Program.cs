using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RisHelper.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var samplePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\..\..\data\sample.ris";
            var records = RisReader.Read(samplePath);

            var types = records.Select(x => x.Type).Distinct().ToList();
        }
    }
}
