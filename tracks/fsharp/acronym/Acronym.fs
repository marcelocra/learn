module Acronym

open System
open System.Text.RegularExpressions

let abbreviate (phrase: string) =
    // Everything that is not a letter or space, in this case.
    let delimiters = "[^a-zA-Z ]"

    // '-' is considered whitespace, so remove it first.
    let initialsArray =
        Regex.Replace(phrase.Replace("-", " "), delimiters, "").Split(" ")
        |> Array.filter (fun x -> x <> "") // Ignore consecutive spaces.
        |> Array.map (fun x -> Char.ToUpper(x.[0]))
        |> String

    String.Join("", initialsArray)


(*

    abbreviate "Thank Got It's Friday"
    abbreviate "Thank got It's Friday"
    abbreviate "Thank got-Friday"
    abbreviate "Something - I made up from thin air"

*)
