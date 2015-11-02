//open System
//
//let cylinderVolume r h : float =
//    2.0 * 3.14 * Math.Pow(r, 2.0) * h
//
//[<EntryPoint>]
//let main argv = 
//    Console.WriteLine("What is the cylinder radius?")
//    let radius = Console.ReadLine();
//    let radius = float radius
//
//    Console.WriteLine("What is the cylinder height?")
//    let height = Console.ReadLine();
//    let height = float height
//
//    let volume = cylinderVolume radius height
//    
//    printfn "Volume = %f" volume
//    Console.ReadKey() |> ignore
//
//    0 // return an integer exit code


// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System

let vol r h =
    Math.PI * (r * r) * h

[<EntryPoint>]
let main argv = 
    Console.WriteLine("Please enter radius of cylinder: ")
    let rawRadius = Console.ReadLine();
    let radius = float rawRadius

    Console.WriteLine("Please enter height of cylinder: ")
    let rawHeight = Console.ReadLine();
    let height = float rawHeight

    let volume = vol radius height
    printfn "volume of cylinder for give radius %f and height %f is - %f" radius height volume
    Console.ReadKey() |> ignore
    0 // return an integer exit code
