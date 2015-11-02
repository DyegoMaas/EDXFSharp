open System

let hexarea t : float =
    (3.0 * Math.Sqrt(3.0) / 2.0) * Math.Pow(t, 2.0)



[<EntryPoint>]
let main argv = 
    
    Console.WriteLine("Tamanho dos lados do hexagono: ")
    let valor = Console.ReadLine()
    let f = float valor

    let calc = hexarea f
    printf "%f" calc //side-effect

    Console.ReadKey() |> ignore


    0 // return an integer exit code
