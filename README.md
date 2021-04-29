# Structr
[![Build Status](https://ci.appveyor.com/api/projects/status/github/askalione/rishelper?branch=master&svg=true)](https://ci.appveyor.com/project/askalione/rishelper) 
[![GitHub license](https://img.shields.io/github/license/askalione/rishelper)](https://github.com/askalione/RisHelper/blob/master/LICENSE)  

RisHelper is a .NET reader/writer of [RIS](https://en.wikipedia.org/wiki/RIS_(file_format)) reference files.

## Nuget

| Component name | NuGet | Downloads |
| --- | --- | --- |
| RisHelper | [![NuGet RisHelper](https://img.shields.io/nuget/v/RisHelper)](https://www.nuget.org/packages/RisHelper/) | [![Downloads RisHelper](https://img.shields.io/nuget/dt/RisHelper)](https://www.nuget.org/stats/packages/RisHelper?groupby=Version) |

## Usage

```

var path = "./data/";

// Read records from file
var records = RisReader.Read(Path.Combine(path, "sample-read.ris"));

// Write records to file
RisWriter.Write(records, Path.Combine(path, "sample-write.ris"));

```

## License
RisHelper is open source, licensed under the [MIT License](https://github.com/askalione/RisHelper/blob/master/LICENSE).