open System
// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

let rec Fibonacci (n: int) : int =
    match n with
    | 0 -> 0
    | 1 -> 1
    | _ -> Fibonacci (n - 1) + Fibonacci (n - 2)

[<EntryPoint>]
let main argv = 
    let n = Fibonacci 4
    let sequence = seq { for i in 1 .. 4 do yield Fibonacci i }
    for v in sequence do
        printfn "%d" v

    let (|Even|Odd|) number = if number % 2 = 0 then Even else Odd
    let x = match 10 with
    | Even -> "even"
    | Odd -> "odd"
    Console.WriteLine(x)
    Console.Read() |> ignore
    0