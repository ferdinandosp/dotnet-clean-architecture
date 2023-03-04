# Dotnet Clean Architecture

[![Build](https://github.com/ferdinandosp/dotnet-clean-architecture/actions/workflows/dotnet.yml/badge.svg)](https://github.com/ferdinandosp/dotnet-clean-architecture/actions/workflows/dotnet.yml/badge.svg)
[![CodeQL](https://github.com/ferdinandosp/dotnet-clean-architecture/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/ferdinandosp/dotnet-clean-architecture/actions/workflows/codeql-analysis.yml/badge.svg)
# Background
This is a template for a dotnet projects, meant to help people who wants to built a dotnet project, so they can write productive codes according to the product requirement as soon as possible.

# Technical
## Background
This template will use the latest dotnet version. The goal of this template is to make a dotnet project with the theories of Onion Architecture and DDD as easy as possible. Will also use libraries that helps towards that goal.
Simple things that is usually used in any projects such as authentication, authorization, user login, and API versioning, also GitHub Actions to run build is already built-in, or have a implementation example.

## Technologies
* [.NET](https://dotnet.microsoft.com/en-us/)
* [SQLite](https://www.sqlite.org/index.html)
* [Mediatr](https://github.com/jbogard/MediatR)
* [Autofac](https://github.com/autofac/Autofac)
* [Specification](https://github.com/ardalis/Specification)
* [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)

## Set Up
### Prerequisites
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) (or any other IDE that supports Windows App development)
* [.NET](https://dotnet.microsoft.com/en-us/download)
* [SQLite](https://www.sqlite.org/download.html)

### Restore Project
```PowerShell
cd %project_path%/
dotnet restore
```

### Build
```PowerShell
cd %project_path%/
dotnet build
```

### Database
To set up the database, just install SQLite on your machine. The app will run migration everytime it runs.

## Reference
* [Dotnet EF Migrations](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
* [Onion Architecture Template](https://github.com/NilavPatel/dotnet-onion-architecture)
