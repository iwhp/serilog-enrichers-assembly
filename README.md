# Collector.Serilog.Enrichers.Assembly
[![Build status](https://ci.appveyor.com/api/projects/status/c5ojwsjhle19nd8u/branch/master?svg=true)](https://ci.appveyor.com/project/CollectorHeimdal/serilog-enrichers-assembly/branch/master)

Enriches Serilog events with information from the process environment using assembly information.
 
To use the enricher, first install the NuGet package:

```powershell
Install-Package Collector.Serilog.Enrichers.Assembly
```

Then, apply the enricher to your `LoggerConfiguration`:

```csharp
Log.Logger = new LoggerConfiguration()
    .Enrich.With<SourceSystemEnricher<ClassInAssemblyOfSourceSystem>>()
    // ...other configuration...
    .CreateLogger();
```

### Included enrichers

The package includes:

 * `SourceSystemEnricher<T>` - adds `SourceSystemEnricher` based on the name of the assembly that `T` resides in.
 * `SourceSystemInformationalVersionEnricher<T>` - adds `SourceSystemInformationalVersionEnricher` based on the assembly's informational version.
