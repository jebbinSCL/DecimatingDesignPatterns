open System

[<RequireQualifiedAccess>]
module GlobalRandom = 

    type GlobalRandom(seed: int) = 
        inherit Random(seed)

    let instance = new GlobalRandom(11123123)

let DoSomethingRandom (instance: GlobalRandom.GlobalRandom) =
    Console.WriteLine(instance.Next())

let writeRandomNumbers () = 

    let random = GlobalRandom.instance
    DoSomethingRandom random

    let sameRandom = GlobalRandom.instance
    DoSomethingRandom sameRandom
    
    let randomsAreTheSame = random = sameRandom
    Console.WriteLine(sprintf "Randoms are the same: %b" randomsAreTheSame)

[<EntryPoint>]
let main _ =
    writeRandomNumbers ()
    Console.ReadLine() |> ignore
    0 
