| master | develop |
| --- | --- |
| [![Build status](https://ci.appveyor.com/api/projects/status/utcs7j2r5xsli0in/branch/master?svg=true)](https://ci.appveyor.com/project/jacobduijzer/cleanarchitecturetemplate-wxbn3/branch/master) | [![Build status](https://ci.appveyor.com/api/projects/status/utcs7j2r5xsli0in/branch/develop?svg=true)](https://ci.appveyor.com/project/jacobduijzer/cleanarchitecturetemplate-wxbn3/branch/develop) |
| [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?branch=master&project=CleanArchitectureTemplate&metric=alert_status)](https://sonarcloud.io/dashboard?id=CleanArchitectureTemplate&branch=master) | [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?branch=develop&project=CleanArchitectureTemplate&metric=alert_status)](https://sonarcloud.io/dashboard?id=CleanArchitectureTemplate&branch=develop) |
| [![Coverage](https://sonarcloud.io/api/project_badges/measure?branch=master&project=CleanArchitectureTemplate&metric=coverage)](https://sonarcloud.io/dashboard?id=CleanArchitectureTemplate&branch=master) | [![Coverage](https://sonarcloud.io/api/project_badges/measure?branch=develop&project=CleanArchitectureTemplate&metric=coverage)](https://sonarcloud.io/dashboard?id=CleanArchitectureTemplate&branch=develop) |
|   [![Nuget status](https://buildstats.info/nuget/JacobsApps.CleanArchitectureProjectTemplate.CSharp?includePreReleases=false)](https://www.nuget.org/packages/JacobsApps.CleanArchitectureProjectTemplate.CSharp/) | |


# Clean Architecture Template

My interpretation of a clean architecture project setup for asp.net an MVC & API project. 

Please read the [Wiki](https://github.com/jacobduijzer/CleanArchitectureTemplate/wiki) to learn more about Clean Architecture and the project setup of this package.

## TODO: 

* Extend ToDo sample with full CRUD
* Change Mvc site to show ToDo samples only

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

> ## v.1.3.4 (?)
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

## Used packages

- [Mediatr - Simple mediator implementation in .NET](https://github.com/jbogard/MediatR)
  
- [LinqBuilder - LinqBuilder is based on the specification pattern](https://github.com/Baune8D/linqbuilder)

## Others

- [How to create dotnet new templates](https://blogs.msdn.microsoft.com/dotnet/2017/04/02/how-to-create-your-own-templates-for-dotnet-new/)

# Books

- [Clean Architecture: A Craftsman's Guide to Software Structure and Design (Robert C. Martin Series)](https://www.amazon.com/Clean-Architecture-Craftsmans-Software-Structure/dp/0134494164)
