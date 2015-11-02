open System

// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 

    let arr = [| 1; 2; 3; 4; 5; 6; 7; 8; 9 |]
    let l = arr.Length
    let isEven x = x % 2 = 0

    let out =
        [ for i = 0 to l - 1 do
              if isEven arr.[i] then yield arr.[i] ]

    let newout = 0 :: out


    printfn "%A" newout

    Console.ReadLine() |> ignore
    0 // return an integer exit code
