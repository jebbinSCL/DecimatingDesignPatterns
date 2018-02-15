open System

module GlobalRandom = 

    type GlobalRandom(seed: int) = 
        inherit Random(seed)

    let instance = new GlobalRandom(11123123)

module RandomUser = 
    open GlobalRandom

    let DoSomethingRandom (instance: GlobalRandom) =
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
    RandomUser.writeRandomNumbers ()
    Console.ReadLine() |> ignore
    0 
