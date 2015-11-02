open System
// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

let classifyPersonByAge name age =
    if age >= 20 then
        sprintf "%s is an adult" name
    elif age < 13 then
        sprintf "%s is a kid or child" name
    else
        sprintf "%s is a teenage" name

let rec collectAge() =
    printfn "Enter an age:"

    let parsed, age = Int32.TryParse(Console.ReadLine())
    if parsed then age 
    else 
        printfn "The input was not a valid age"
        collectAge()

[<EntryPoint>]
let main argv = 

    let mutable inputMorePeople = true
    while inputMorePeople do
        printfn "Enter the person's Name: (empty to quit)"

        let name = Console.ReadLine()
        if name = "" then 
            inputMorePeople <- false
        else
            let age = collectAge()
            printfn "%s" (classifyPersonByAge name age)
            printfn ""
    
    printf "Done"
    Console.Read() |> ignore
    0 // return an integer exit code
