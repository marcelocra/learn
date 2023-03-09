module ReverseString

let reverseCheating (input: string) =
    input.ToCharArray() |> Array.rev |> System.String

let reverse (input: string) =
    let rec reverse' s out =
        match s with
        | x :: r -> reverse' r (x :: out)
        | [] -> out

    reverse' (input |> List.ofSeq) [] |> System.String.Concat
