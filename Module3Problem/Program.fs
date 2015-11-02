open System
 
let rec inputNumber() =
    Console.WriteLine("Enter a number:")
    let parsed, number = Int32.TryParse(Console.ReadLine())
    if parsed then number
    else
        Console.WriteLine("The input was not a valid number")
        inputNumber()
 
let goldenRation = (1.0 + Math.Sqrt(5.0)) / 2.0
let calculateRatio value = value * goldenRation
   
 
[<EntryPoint>]
let main argv =
   
    let goldenRationSequence = [
        let mutable run = true
        while run do
            let number = inputNumber()
            yield (number, calculateRatio (float number))
 
            Console.WriteLine("Would you like to inform another value? (y/n)")
            if Console.ReadLine().ToLower() <> "y" then
                run <- false
    ]
 
    for item in goldenRationSequence do
        printfn "%A" item
 
    Console.Read() |> ignore
    0 // return an integer exit code