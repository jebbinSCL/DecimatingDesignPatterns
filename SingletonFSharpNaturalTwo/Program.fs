open System

//This idea is from https://gist.github.com/swlaschin/54cfff886669ccab895a

module GRandom = 
    type GlobalRandom = private GlobalRandom of Random

    (*
        Kind of a work around (A little bit of a compilier bug I might report)
        This is only necessary if you want to pass around the type. 
        Alternatively, you could have all the functions be in the module below
        Which is probably what we would do if we weren't working with an object
    *)
    let (|GlobalRandom|) random = 
        match random with
        | GlobalRandom r -> r

    module GlobalRandom = 
        let private inst = new Random(11123123)
        let instance = GlobalRandom (inst)
        // Usually the functions would be here:
        let next () = inst.Next()

open GRandom

module RandomUser = 
    let DoSomethingRandom (GlobalRandom instance) =
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
