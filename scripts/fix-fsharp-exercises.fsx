#!/usr/bin/env -S dotnet fsi

#load "functions.fsx"

let projectsToClean = fsi.CommandLineArgs |> Array.tail

if projectsToClean.Length <> 1 then
    failwith "Please provide a single project name."
else
    let projectToClean = projectsToClean.[0]

    // Remove old fantomas and install new one.
    Functions.runShellCommand
        $"""
        cd tracks/fsharp/{projectToClean} \
        && dotnet tool uninstall fantomas-tool \
        && dotnet tool install fantomas --version 5.2.4
    """
