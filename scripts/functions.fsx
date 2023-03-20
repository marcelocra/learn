module Functions

open System
open System.Diagnostics


let isUnix = Environment.OSVersion.Platform = PlatformID.Unix


/// <summary>Runs the given command in a shell and returns the output.</summary>
let runShellCommand (command: string) : string =
    // Perhaps use /usr/bin/env bash -S instead of /bin/bash?
    let osExecutor = if isUnix then "/bin/bash" else "cmd.exe"
    let osExecutorArgs = sprintf (if isUnix then "-c \"%s\"" else "/C %s") command

    let proc = new Process()
    proc.StartInfo.FileName <- osExecutor
    proc.StartInfo.Arguments <- osExecutorArgs
    proc.StartInfo.UseShellExecute <- false
    proc.StartInfo.RedirectStandardOutput <- true

    proc.Start() |> ignore

    let output = proc.StandardOutput.ReadToEnd()
    proc.WaitForExit()

    output


// -- Playground below --


// // Add a new tool manifest to the current directory and install fantomas.
// runShellCommand "dotnet new tool-manifest"
// runShellCommand "dotnet tool install fantomas --version 5.2.4"

// // Play with environment.
// printfn "%A" Environment.CurrentDirectory
// printfn "%A" Environment.OSVersion
// printfn "%A" Environment.OSVersion.Platform
