module KindergartenGarden

let students =
    [ "Alice"
      "Bob"
      "Charlie"
      "David"
      "Eve"
      "Fred"
      "Ginny"
      "Harriet"
      "Ileana"
      "Joseph"
      "Kincaid"
      "Larry" ]

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

    let index = students |> List.findIndex (fun x -> x = student)

    studentCups.[index]


let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
let cups = diagram.Split [| '\n' |]
let skip = (Seq.skip (3 * 2) >> Seq.take 2) cups.[0]
let collect = Seq.collect (Seq.skip (3 * 2) >> Seq.take 2) cups
