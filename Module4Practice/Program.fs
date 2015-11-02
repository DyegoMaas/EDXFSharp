open System
open System.IO

let GetFile() =
    Console.WriteLine("Insira o caminho do arquivo com as coordenadas")
    Console.ReadLine()

type Entity = 
      { X: int;
        Y: int;
        Name: string }

let (|Quadrant1|Quadrant2|Quadrant3|Quadrant4|Origin|Undefined|) input =
    match input with
    | {Entity.X = x; Entity.Y = y; Entity.Name = name } when x > 0 && y > 0 -> Quadrant1
    | {Entity.X = x; Entity.Y = y; Entity.Name = name } when x < 0 && y > 0 -> Quadrant2
    | {Entity.X = x; Entity.Y = y; Entity.Name = name } when x < 0 && y < 0 -> Quadrant3
    | {Entity.X = x; Entity.Y = y; Entity.Name = name } when x > 0 && y < 0 -> Quadrant4
    | {Entity.X = x; Entity.Y = y; Entity.Name = name } when x = 0 && y = 0 -> Origin
    | _ -> Undefined

[<EntryPoint>]
let main argv = 
    
    try
        use input = new StreamReader(match argv.Length with
                                     | 0 -> GetFile()
                                     | _ -> argv.[0])

        let entities = [ while not input.EndOfStream do
                            let raw = input.ReadLine()
                            let values = raw.Split(',')
                            yield { X = int values.[0]
                                    Y = int values.[1]
                                    Name = values.[2]} ]

        let errorNames = 
            seq {
                for p in entities ->
                    match p with
                    | Undefined -> Some(p.Name)
                    | _ -> None
            }

        Console.WriteLine("As seguintes entidades não foram reconhecidas")
        for error in errorNames do
            match error with
            | Some name -> Console.WriteLine(name)
            | None -> ()
        0

    with
    | :? System.IO.FileNotFoundException ->
        Console.WriteLine("Arquivo não encontrado. Pressione uma tecla para sair")
        -1
    | _ ->
        Console.WriteLine("Ocorreu um erro ao ler o arquivo de coordenadas. Pressione uma tecla para sair")
        -1