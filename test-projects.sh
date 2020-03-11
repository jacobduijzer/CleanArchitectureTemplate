#!/bin/bash

set -x

dotnet new dotnet new -i /home/vsts/work/1/s/JacobsApps.CleanArchitectureProjectTemplate.CSharp.2.5.0.nupkg

mkdir FullWeb 
cd FullWeb 
dotnet new cleanarchitectureproject -uc fullweb
dotnet build
dotnet test
