﻿open System
open System.IO

let GetFile() =
    Console.WriteLine("Enter the path to the input file")
    Console.ReadLine()

type Point = { X: float; Y: float }

type GunTest = {
    Target: Point
    Speed: float
    ExpectedDistance: float
    Name: string
}

let gravity = 9.81 //m/s
let CalculateAngleOfReach distance speed = 0.5 * Math.Pow(Math.Sin(gravity * distance / (speed * speed)), -1.0)
let DistanceTravelledOverFlatSurface speed angle = speed * speed * Math.Sin(2.0 * angle) / gravity
let CalculateAngle x y  = Math.Pow(Math.Tan(y / x), -1.0)

let (|Hit|Miss|) (gunTest: GunTest) = 
    let angle = CalculateAngle gunTest.Target.X gunTest.Target.Y
    let distanceTravelled = DistanceTravelledOverFlatSurface gunTest.Speed angle
    match distanceTravelled >= gunTest.ExpectedDistance with
    | true -> Hit
    | false -> Miss

[<EntryPoint>]
let main argv =

    try
        use input = new StreamReader(match argv.Length with
                                       | 0 -> GetFile()
                                       | _ -> argv.[0])
        
        let testList = [ while not input.EndOfStream do
                            let raw = input.ReadLine()
                            let values = raw.Split(',')
                                    
                            yield { 
                                Target = { X = float values.[0]; Y = float values.[1] }
                                Speed = float values.[2]
                                ExpectedDistance = float values.[3]
                                Name = values.[4]
                            } ]

        for test in testList do
            match test with
            | Hit -> printfn "Gun %s hit the target as expected" test.Name
            | Miss -> 
                let angleOfReach = CalculateAngleOfReach test.ExpectedDistance test.Speed
                printfn "Gun %s should shoot at angle %f in order to hit the target" test.Name angleOfReach

        Console.ReadLine() |> ignore
        0
    with
    | :? FileNotFoundException ->
        printfn "The input file was not found"
        Console.ReadLine() |> ignore
        -1
    | _ -> 
        printfn "An error occured while reading the input file. Press any key to exit"
        Console.ReadLine() |> ignore
        -1