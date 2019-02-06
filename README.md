[![Build status](https://ci.appveyor.com/api/projects/status/utcs7j2r5xsli0in/branch/master?svg=true)](https://ci.appveyor.com/project/jacobduijzer/cleanarchitecturetemplate-wxbn3/branch/master) [![Nuget status](https://buildstats.info/nuget/JacobsApps.CleanArchitectureProjectTemplate.CSharp?includePreReleases=false)](https://www.nuget.org/packages/JacobsApps.CleanArchitectureProjectTemplate.CSharp/) 

# Clean Architecture Template

My interpretation of a clean architecture project setup for asp.net an MVC & API project. 

## TODO: 

* Add documentation
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

> ## v1.2.0 (02/06/2019)
> - Added repository + mediator to Web project
> - Added ToDo page to Web project
> - Added Due date to fake data



# The cool stuff

### Mediator pattern

### Specification pattern

### Integration tests, test fixtures & collections

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
