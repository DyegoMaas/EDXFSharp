open System
open System.IO
// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 
    
    let criarArquivo caminhoArquivo = 
        use arquivo = File.CreateText(caminhoArquivo)
        for i in 1 .. 1000 do
            arquivo.WriteLine(sprintf "Linha %i" i)

    let lerArquivo caminhoArquivo = 
        try
            File.ReadAllText(caminhoArquivo)
        with
        | :? IOException -> "não foi possível ler o arquivo"

    let caminho = Path.Combine([|AppDomain.CurrentDomain.BaseDirectory; "arquivo.txt" |])
    
    criarArquivo caminho
    printfn "%A" (lerArquivo caminho)
    printfn "%A" (lerArquivo @"c:\teste.txtt")
    Console.Read() |> ignore
    0 // return an integer exit code
