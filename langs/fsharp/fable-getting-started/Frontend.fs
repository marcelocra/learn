module Frontend

open Browser

let str = "Hello, world!"

printfn "%s" str

let div = document.createElement "div"
div.innerHTML <- str
document.body.appendChild div |> ignore
