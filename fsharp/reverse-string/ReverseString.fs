module ReverseString

let reverse (input: string) =
    input.ToCharArray() |> Array.rev |> System.String
