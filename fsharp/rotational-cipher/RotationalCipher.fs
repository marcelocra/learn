module RotationalCipher

open System


(*
    Algorithm ideas:

    1. Define bounds for each character type (lowercase, uppercase, numbers, etc.)
    2. 
*)

let shift (key: char) (shift: int) =
    let lower = Char.IsLower key
    let keyInt = int key
    let lowerBound = if lower then int 'a' else int 'A'
    let upperBound = if lower then int 'z' else int 'Z'
    let shifted = keyInt + shift

    if shifted > upperBound then
        char (lowerBound + (shifted - upperBound) - 1)
    else
        char shifted

let rotate (shiftKey: int) (text: string) =
    text |> String.map (fun c -> if Char.IsLetter c then shift c shiftKey else c)

(*

// Testing grounds! Comment out before submitting.

open System

"test".ToCharArray()
char ((int 'a') + 10)

let rot = 10
(int 'A')
(int 'Z')
100 % 90
(char ((int 'A') - 1 + ((int 'Z') + 10) % 90))
shift 'a' 10 = 'k'
shift 'z' 10 = 'j'
shift 'Z' 10 = 'J'
rotate 5 "omg"
rotate 0 "c"
rotate 26 "Cool"
rotate 13 "The quick brown fox jumps over the lazy dog."
rotate 13 "Gur dhvpx oebja sbk whzcf bire gur ynml qbt."

*)
