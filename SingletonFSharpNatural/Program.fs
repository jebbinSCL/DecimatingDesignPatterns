open System

[<RequireQualifiedAccess>]
module GlobalRandom = 
    let instance = new Random(11123123)

module RandomUser = 

    let DoSomethingRandom () =
        let random = GlobalRandom.instance
        Console.WriteLine(random.Next())

    let writeRandomNumbers () = 

        DoSomethingRandom ()

        DoSomethingRandom ()
    
        let randomsAreTheSame = GlobalRandom.instance = GlobalRandom.instance
        Console.WriteLine(sprintf "Randoms are the same: %b" randomsAreTheSame)

[<EntryPoint>]
let main _ =
    RandomUser.writeRandomNumbers ()
    Console.ReadLine() |> ignore
    0 
