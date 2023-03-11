module RotationalCipher

open System


let rotate shiftKey text =
    let shift r = r - 26 |> char

    let rotateletter shiftKey c =
        match int c + shiftKey with
        | r when Char.IsUpper c && r > int 'Z' -> shift r
        | r when Char.IsLower c && r > int 'z' -> shift r
        | r -> r |> char

    let mapper (c: char) =
        if Char.IsLetter c then rotateletter shiftKey c else c

    text |> String.map mapper
