open System
// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

type Person =
    { Name : string
      Age : int
      Id : int }

let GetUser userName userAge =
    { Name = userName;
      Age = userAge;
      Id = userName.Length * userAge }

[<EntryPoint>]
let main argv = 
    Console.WriteLine("Digite o nome do usuário principal:")
    let nomeUsuario = Console.ReadLine()
    
    Console.WriteLine("Digite a idade do usuário principal:")
    let idadeUsuario = Console.ReadLine()

    let usuarioPrincipal = GetUser nomeUsuario (int idadeUsuario)

    let pessoas = [
        let mutable run = true
        while run do
            Console.WriteLine("Você deseja adicionar mais usuários? (s/n)")
            if Console.ReadLine().ToLower() = "s" then
                Console.WriteLine("Digite o nome do usuário:")
                let nomeUsuario = Console.ReadLine()
    
                Console.WriteLine("Digite a idade do usuário:")
                let idadeUsuario = Console.ReadLine()
                
                yield GetUser nomeUsuario (int idadeUsuario)
            else
                run <- false ]
    
    let pessoasComMesmoId = 
        seq { 
            for pessoa in pessoas do 
                if pessoa.Id = usuarioPrincipal.Id then yield pessoa 
        }

    for pessoa in pessoasComMesmoId do
        printfn "O usuário %s tem o mesmo Id que o usuário principal" pessoa.Name

    Console.Read() |> ignore
    0 // return an integer exit code
