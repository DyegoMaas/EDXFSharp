open System
open System.Text

let obterEntrada (args: string list) : int =
    let obterValorConsole() =
        let podeConverter, valorInformado = Int32.TryParse(Console.ReadLine())
        if podeConverter then valorInformado
        else 0
    
    if args.Length > 0 then
        let converteu, valorEntrada = Int32.TryParse(args.[0])
        if converteu then valorEntrada
        else obterValorConsole()
    else obterValorConsole()
          
let Fibonacci (n: int) : int =
    let mutable primeiro = 0
    let mutable segundo = 1
    let mutable temp = 0
    
    for indice = primeiro to n do
        temp <- primeiro + segundo
        primeiro <- segundo
        segundo <- temp
    primeiro

let rec Fibonacci2 (n: int) : int =
    if n = 0 then 0
    elif n < 2 then 1
    else Fibonacci2 (n - 1) + Fibonacci2 (n - 2)

[<EntryPoint>]
let main args = 
    printfn "%A" args

    let valor = obterEntrada args

//    for n = 0 to valor do
    let f = Fibonacci2 valor
    Console.Write(f.ToString() + " ") |> ignore

    Console.Read() |> ignore 
            

    0 // return an integer exit code
