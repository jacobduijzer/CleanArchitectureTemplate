#!/bin/bash

function GetNugetPackage
{
    echo "GetNugetPackage"
    pattern="JacobsApps.CleanArchitectureProjectTemplate.CSharp.*.nupkg"
    files=( $pattern )
    nugetFile="${files[0]}"
    echo "Package found: " $nugetFile 
}

function InstallNugetPackage
{
    echo "InstallNugetPackage"
    dotnet new -i $nugetFile
}

function CreateBuildAndTestProject
{
    echo "Creating test project: " $1

    useCase=${1,,}

    mkdir $1
    cd $1
    dotnet new cleanarchitecture -uc $useCase
    dotnet build
    dotnet test
}

GetNugetPackage

InstallNugetPackage

CreateBuildAndTestProject EmptyApi 
#CreateBuildAndTestProject FullWeb

# echo $nugetFile
# dotnet new -i /home/vsts/work/1/s/JacobsApps.CleanArchitectureProjectTemplate.CSharp.2.5.0.nupkg

# mkdir FullWeb 
# cd FullWeb 
# dotnet new cleanarchitecture -uc fullweb
# dotnet build
# dotnet test
