open System
// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

let Fibonacci (n: int) : int =
    let mutable primeiro = 0
    let mutable segundo = 1
    let mutable temp = 0
    
    for indice = 1 to n do
        temp <- primeiro + segundo
        primeiro <- segundo
        segundo <- temp
    primeiro

type Pessoa = { Nome:string; Idade:int } 

[<EntryPoint>]
let main argv = 

    let sequence = seq { for i in 0 .. 20 do yield Fibonacci i }
    for v in sequence do
        printfn "%d" v

    let pessoas = [| ("joao", 26); ("guilherme", 24); ("nina", 20) |]
    for pessoa in pessoas do
        match pessoa with
        | (nome, idade) when idade > 20 -> printfn "%s tem mais de 20 anos" nome
        |_ -> ()

    let pessoas2 = [| {Nome = "joao"; Idade = 20}; {Nome = "guigui"; Idade = 26} |]
    for pessoa in pessoas2 do
        match pessoa with
        | p when p.Idade > 20 -> printfn "%s tem mais de 20 anos" p.Nome
        |_ -> ()

    Console.Read() |> ignore
    0 // return an integer exit code
