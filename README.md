<div align="center">
 <h1 style="font-size: 5em;">Argus | Cardano Blockchain Indexer for .NET</h1>
</div>  

<div align="center"> 
  <img src="/assets/asset.png" alt="Argus Logo"> 
</div> 

<div align="center"> 

![Forks](https://img.shields.io/github/forks/SAIB-Inc/Argus.svg?style=social)  
![Stars](https://img.shields.io/github/stars/SAIB-Inc/Argus.svg?style=social)  
![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg) 
![Contributors](https://img.shields.io/github/contributors/SAIB-Inc/Argus.svg?label=Contributors) 
![Issues](https://img.shields.io/github/issues/SAIB-Inc/Argus.svg?label=Open%20Issues) 
![Issues Closed](https://img.shields.io/github/issues-closed/SAIB-Inc/Argus.svg?label=Closed%20Issues) 

<a href="https://www.nuget.org/packages/SAIB.Cardano.Sync"> 
    <img src="https://img.shields.io/nuget/v/SAIB.Cardano.Sync.svg" alt="NuGet"> 
</a> 

![C#](https://img.shields.io/badge/C%23-purple.svg) 

</div> 

Argus is a .NET library that simplifies interactions with the Cardano blockchain by providing an efficient indexing framework. Initially supporting PostgreSQL as the database backend, it processes block data into structured, queryable formats. This tool is designed for robust enterprise integration, with plans to introduce additional database backends in the future to broaden its applicability and flexibility. 

## Features :sparkles: 

  

## Roadmap :rocket: 

  

## Getting Started :package: 

  

To use Argus in your .NET project: 

1. You can install Argus via NuGet: 
    `dotnet add package SAIB.Cardano.Sync` 

2. Dependency Installation: 
    Chrysalis, Nsec.Cryptography, Microsoft.EntityFramework.Design, Pallas.NET 

3. # Review - is creating a postgresDB necessary or will it make it automatically? 

4. Configure your appsettings.json file: 

5. Create your models and DbContext or use our general reducers: 

6. Migrate and update your database changes: 

7. Run your reducer! 

  

## Example :pencil2:  


Program.cs 

```cs 
    builder.Services.AddCardanoIndexer<CardanoTestDbContext>(builder.Configuration); 
    builder.Services.AddReducers<CardanoTestDbContext, IReducerModel>([typeof(OutputBySlotReducer<>)]); 
``` 

```cs 

using Argus.Sync.Example.Data; 
using Argus.Sync.Reducers; 
using PallasDotnet.Models; 

namespace Argus.Sync.Example.Reducers; 

public class MyReducer : IReducer 

{ 
    private readonly ILogger<MyReducer> _logger; 

    public MyReducer(ILogger<MyReducer> logger) 
    { 
        _logger = logger; 
    } 

    public async Task RollForwardAsync(NextResponse response) 
    { 
        _logger.LogInformation("Processing new block at slot {slot}", response.Block.Slot); 
        // Implement your logic here 
    } 

    public async Task RollBackwardAsync(NextResponse response) 
    { 
        _logger.LogInformation("Rollback at slot {slot}", response.Block.Slot); 
        // Implement rollback logic here 
    } 
} 
``` 

 