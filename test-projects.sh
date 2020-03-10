#!/bin/bash

set -x

dotnet new dotnet new -i /home/jacob/projects/github/CleanArchitectureTemplate/JacobsApps.CleanArchitectureProjectTemplate.CSharp.2.5.0.nupkg

mkdir FullWeb 
cd FullWeb 
dotnet new cleanarchitectureproject -uc fullweb
dotnet build
dotnet test
