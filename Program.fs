open System
open System.IO
open System.Collections.Generic
open System.Net

let getRequests() =
    let requests =
        [|
            "http://www.google.com"
            "http://www.pluralsight.com"
            "http://99.99.99.99/doesntexist"
            "http://www.bbc.co.uk"
            "http://www.amazon.com"
            "http://www.bing.com"
        |]
    use wc = new WebClient()
    requests
    |> Array.choose(fun url ->
        try
            (url, wc.DownloadString(url).Length) |> Some
        with
        | _ -> None)

    |> Array.sortBy(fun(url, length) -> -length)
getRequests()
|> printfn "%A"

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code

