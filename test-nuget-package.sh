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

CreateBuildAndTestProject $1 
#CreateBuildAndTestProject FullWeb
