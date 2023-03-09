module KindergartenGarden

type Plant =
    | Clover
    | Grass
    | Radishes
    | Violets

let plantType (plant: char) =
    match plant with
    | 'C' -> Plant.Clover
    | 'G' -> Plant.Grass
    | 'R' -> Plant.Radishes
    | 'V' -> Plant.Violets
    | _ -> failwith "Invalid plant type"

let plants (diagram: string) (student: string) =
    let cups =
        diagram.Split('\n')
        |> Array.map (fun line -> Array.chunkBySize 2 (line.ToCharArray()))

    let studentCups =
        Array.zip cups.[0] cups.[1]
        |> Array.map (fun (c1, c2) -> Array.concat [ c1; c2 ])
        |> Array.map (fun full -> Array.map (fun c -> plantType c) full |> Array.toList)
        |> Array.toList

    match student with
    | "Alice" -> studentCups.[0]
    | "Bob" -> studentCups.[1]
    | "Charlie" -> studentCups.[2]
    | "David" -> studentCups.[3]
    | "Eve" -> studentCups.[4]
    | "Fred" -> studentCups.[5]
    | "Ginny" -> studentCups.[6]
    | "Harriet" -> studentCups.[7]
    | "Ileana" -> studentCups.[8]
    | "Joseph" -> studentCups.[9]
    | "Kincaid" -> studentCups.[10]
    | "Larry" -> studentCups.[11]
    | _ -> failwith "Invalid student name"
