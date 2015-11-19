open System

type MyRecord =
    { IP : string
      MAC : string
      FriendlyName : string
      ID : int }

let IsMatchByName record name =
    match record with
    | { IP = ip; MAC = _; FriendlyName = nameFound; ID = id } -> if nameFound = name then Some(id, ip) else None
    | _ -> None

let checkmatch input =
    match input with
    | Some(id, ip) -> printfn "%A" id
    | None -> printfn "%A" "Sorry no match" 

[<EntryPoint>]
let main argv = 

    let input = {IP = "10.1.1.1"; MAC = "FF:FF:FF:FF:FF:FF"; FriendlyName = "ServerFailure";ID = 0}
    let matchName = "ServerFailure"

    let isMatchResult = IsMatchByName input matchName
    let result = checkmatch isMatchResult
    printfn "%A" result
    Console.ReadLine() |> ignore
    0 // return an integer exit code
