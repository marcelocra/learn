module Frontend

open Browser
open Elmish

let str = "Hello, world! hello people"

printfn "%s" str

let div = document.createElement "div"
div.innerHTML <- str
document.body.appendChild div |> ignore

type Model = { Value: int }

type Msg =
    | Increment
    | Decrement

let init () = { Value = 0 }, Cmd.ofMsg Increment

let update (msg: Msg) (model: Model) =
    match msg with
    | Increment when model.Value < 2 -> { model with Value = model.Value + 1 }, Cmd.ofMsg Increment
    | Increment -> { model with Value = model.Value + 1 }, Cmd.ofMsg Decrement
    | Decrement when model.Value > 1 -> { model with Value = model.Value - 1 }, Cmd.ofMsg Decrement
    | Decrement -> { model with Value = model.Value - 1 }, Cmd.ofMsg Increment

Program.mkProgram init update (fun model _ -> printf "%A\n" model)
|> Program.run
