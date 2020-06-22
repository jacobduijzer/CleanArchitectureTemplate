#!/usr/bin/env bash

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
    dotnet new cleanarchitecture --use-case $useCase 
    dotnet build $1.$2.sln
    dotnet test $1.$2.sln
}

GetNugetPackage

InstallNugetPackage

CreateBuildAndTestProject $1 $2
