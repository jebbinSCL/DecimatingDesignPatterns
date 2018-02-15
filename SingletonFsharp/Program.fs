open System

type GlobalRandom(seed: int) = 
    inherit Random(seed)
    static let instance = new GlobalRandom(11123123)
    static member Instance = instance

module RandomUser = 
    let DoSomethingRandom (instance: GlobalRandom) =
        Console.WriteLine(instance.Next())

    let writeRandomNumbers () = 

        let random = GlobalRandom.Instance
        DoSomethingRandom random

        let sameRandom = GlobalRandom.Instance
        DoSomethingRandom sameRandom
    
        let randomsAreTheSame = random = sameRandom
        Console.WriteLine(sprintf "Randoms are the same: %b" randomsAreTheSame)

[<EntryPoint>]
let main _ =
    RandomUser.writeRandomNumbers ()
    Console.ReadLine() |> ignore
    0 
