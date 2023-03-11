module LogLevels

let message (logLine: string): string =
    let arr = logLine.Split(":")
    arr.[1].Trim()

let logLevel(logLine: string): string =
    let startIdx = logLine.IndexOf("[")
    let endIdx = logLine.IndexOf("]")
    let str = logLine.[startIdx+1..endIdx-1]
    printfn "%s" (str.ToLower())
    str.ToLower()

let reformat(logLine: string): string =
    let msg = message(logLine)
    let lvl = logLevel(logLine)
    $"{msg} ({lvl})"
