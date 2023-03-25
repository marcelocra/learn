module RunLengthEncoding

let calculate (acc: string * char * int) (nextChar: char) =
    let (finalString, currChar, currCharCount) = acc

    if currChar <> nextChar then
        let countToShow = if currCharCount = 1 then "" else $"{currCharCount}"
        ($"{finalString}{countToShow}{currChar}", nextChar, 1)
    else
        ($"{finalString}", currChar, currCharCount + 1)

let encode (input: string) : string =
    if input.Trim() = "" then
        ""
    else
        let first = input.[0]
        let rest = input.Substring(1)

        let (withoutLastElement, lastChar, lastCharCount) =
            Seq.fold calculate ("", first, 1) (rest)

        let countToShow = if lastCharCount = 1 then "" else $"{lastCharCount}"
        $"{withoutLastElement}{countToShow}{lastChar}"

(*

    encode "test"
    encode ""
    encode "heeeeeelo"

*)

open System.Text.RegularExpressions

let decode (input: string) =
    if input.Trim() = "" then
        ""
    else if not (Regex.IsMatch(input, "[0-9]+")) then
        input
    else
        let countArr = Regex.Split(input, "[a-zA-Z ]+") |> Array.filter (fun x -> x <> "")
        let letterArr = Regex.Split(input, "[0-9]+") |> Array.filter (fun x -> x <> "")
        let countAndLetterArr = Array.zip countArr letterArr

        Seq.fold
            (fun acc elem ->
                let (count: string, letter: string) = elem
                let countInt = int count
                let firstLetter = letter.Substring(0, 1)
                let rest = letter.Substring(1)

                let multiple = String.replicate countInt firstLetter

                $"{acc}{multiple}{rest}")
            ""
            countAndLetterArr

(*

    decode "2AB3B4CX"
    decode "2 hs2q q2w2 "

*)
