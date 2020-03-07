| Project status | 
| --- | 
| [![Build Status](https://dev.azure.com/JacobsApps/CleanArchitectureTemplate/_apis/build/status/jacobduijzer.CleanArchitectureTemplate?branchName=master)](https://dev.azure.com/JacobsApps/CleanArchitectureTemplate/_build/latest?definitionId=1&branchName=master) | 
| [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?branch=master&project=CleanArchitectureTemplate&metric=alert_status)](https://sonarcloud.io/dashboard?id=CleanArchitectureTemplate&branch=master) |
| [![Coverage](https://sonarcloud.io/api/project_badges/measure?branch=master&project=CleanArchitectureTemplate&metric=coverage)](https://sonarcloud.io/dashboard?id=CleanArchitectureTemplate&branch=master) |
| [![Nuget status](https://buildstats.info/nuget/JacobsApps.CleanArchitectureProjectTemplate.CSharp?includePreReleases=false)](https://www.nuget.org/packages/JacobsApps.CleanArchitectureProjectTemplate.CSharp/) |


# Clean Architecture Template

My interpretation of a clean architecture project setup for asp.net an MVC & API project. 

Please read the [Wiki](https://github.com/jacobduijzer/CleanArchitectureTemplate/wiki) to learn more about Clean Architecture and the project setup of this package.

## DISCLAIMER

I am switching back to .NET Core 2.2 due to the belated final release of .NET Core 3.0. I am using this package in production and have to keep adding some new projects based on this template.

## TODO: 

* Extend ToDo sample with full CRUD
* Change Mvc site to show ToDo samples only
* Better templating
  * full
  * empty
  * api
  * razor
  * web
  * docker
  * docker-compose
  * postgresql

# Usage

To install the template so you can use it with `dotnet new`:

```
dotnet new --install JacobsApps.CleanArchitectureProjectTemplate.CSharp 
```

To create a new project:
```
dotnet new  cleanarchitectureproject -n SomeFancyNamespace
```

# Release Notes


> ## v2.5.0 (?)
> - Included a default .editorconfig
> - Better templating (exluding sample code by default)
> - Latest package versions
> - 

> ## v2.4.1 (02/12/2020)
> - fixed some minor SonarQube issues

> ## v2.4.0 (02/12/2020)
> - Updated to .NET Core 3.1
> - Added Blazor UI

> ## v2.3.0 (09/27/2019)
> - More changes and improvements for .NET Core 3.0
> - Removed pagination, never using it
> - Restructured project locations

> ## v2.2.3 (09/25/2019)
> - Disabled nullable (new C# 8 feature)

> ## v2.2.2 (09/25/2019)
> - Fixing issues with razor + core 3.0
> - Fixing issues with integration tests (added custom web factory)
> - Added test data for Integration tests

> ## v2.2.1 (09/24/2019)
> - Updgrade to .NET Core 3.0
> - Upgraded all packages

> ## v2.1.0 (03/18/2019)
> - Switched back to .NET Core 2.2
> - Downgraded coverlet due to build issues with latest version

> ## v2.0.0 (03/13/2019)
> - Upgrade to .NET Core 3.0 (Which is still in preview!)
> - Renamed handlers, queries and commands
> - Added event / event handler

> ## v.1.3.4 (02/26/2019)
> - Added logging (ILoggingFactory)
> - Added application settings + builder

> ## v1.3.3 (02/11/2019)
> - Added reusable paged data handler for pagination with sample
> - Added a generic CachedRepositoryDecorator to create cached repositories.

> ## v1.3.2 (02/08/2019)
> - Added more unit tests 
> - Added sonar cloud code analysis

> ## v1.3.1 (02/07/2019)
> - Added link to the wiki
> - Added a unit test for a view model
> - code cleanup

> ## v1.3.0 (02/06/2019)
> - Updated README with links
> - Removed ValuesController
> - Added integration tests and unit tests
> - Updated test fixtures to use fake data with integration tests
> - Added Refit for Api integration tests

> ## v1.2.0 (02/06/2019)
> - Added repository + mediator to Web project
> - Added ToDo page to Web project
> - Added Due date to fake data

# Links

## Clean Architecture

- [Clean Architecture explained by Uncle Bob](http://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

- [Clean Architecture Cheat Sheet (PDF)](https://www.planetgeek.ch/wp-content/uploads/2016/03/Clean-Architecture-V1.0.pdf)

- [A starting point for Clean Architecture with ASP.NET Core (Steve Smith/Ardalis)](https://github.com/ardalis/CleanArchitecture)

- [Clean Architecture: Patterns, Practices, and Principles (Pluralsight)](https://www.pluralsight.com/courses/clean-architecture-patterns-practices-principles)

## DDD

- [CQRS with DDD (Kamil Grzybek)](http://www.kamilgrzybek.com/design/simple-cqrs-implementation-with-raw-sql-and-ddd/)

## Used packages

- [Mediatr - Simple mediator implementation in .NET](https://github.com/jbogard/MediatR)
  
- [LinqBuilder - LinqBuilder is based on the specification pattern](https://github.com/Baune8D/linqbuilder)

## Others

- [How to create dotnet new templates](https://blogs.msdn.microsoft.com/dotnet/2017/04/02/how-to-create-your-own-templates-for-dotnet-new/)

# Books

- [Clean Architecture: A Craftsman's Guide to Software Structure and Design (Robert C. Martin Series)](https://www.amazon.com/Clean-Architecture-Craftsmans-Software-Structure/dp/0134494164)
