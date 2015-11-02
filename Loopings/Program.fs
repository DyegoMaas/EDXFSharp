open System

let checarValor v =
    if v = 5 then
        "Sou CINCO!"
    elif v < 5 then
        "Sou menor que CINCO"
    else
        "Sou qualquer outro número por aí"

[<EntryPoint>]
let main argv = 
    let valor = Console.ReadLine()
    let valor = int valor

    let mutable continuar = true
    let mutable n = 0
    while continuar do
        n <- n + 1
        printfn "%A" (checarValor n)
        if n = valor then continuar <- false

    for i = 100 downto valor do
        printfn "2: %A" (checarValor n)

    printfn "%A" argv
    Console.Read() |> ignore
    0 // return an integer exit code
