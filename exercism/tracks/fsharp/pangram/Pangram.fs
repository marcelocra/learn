module Pangram

open System.Text.RegularExpressions


let uniqLetters (input: string) : Set<char> =
    input.ToLower().Trim().ToCharArray()
    |> Set.ofArray
    |> Set.filter (fun letter -> Regex.IsMatch(letter.ToString(), "[a-z]"))


let isPangram (input: string) : bool =
    let uniq = uniqLetters (input)

    if uniq.Count <> 26 then
        false

    else
        true
