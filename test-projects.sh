#!/bin/bash

set -x

dotnet new -i /home/vsts/work/1/s/JacobsApps.CleanArchitectureProjectTemplate.CSharp.2.5.0.nupkg

mkdir FullWeb 
cd FullWeb 
dotnet new cleanarchitecture -uc fullweb
dotnet build
dotnet test