open System

[<RequireQualifiedAccess>]
[<AutoOpen>]
module GlobalRandom = 

    type GlobalRandom(seed: int) = 
        inherit Random(seed)

    let instance = new GlobalRandom(11123123)

let writeRandomNumbers () = 

    let random = GlobalRandom.instance
    Console.WriteLine(instance.Next())

    let sameRandom = GlobalRandom.instance
    Console.WriteLine(instance.Next())
    
    let randomsAreTheSame = random = sameRandom
    Console.WriteLine(sprintf "Randoms are the same: %b" randomsAreTheSame)

[<EntryPoint>]
let main _ =
    writeRandomNumbers ()
    Console.ReadLine() |> ignore
    0 
