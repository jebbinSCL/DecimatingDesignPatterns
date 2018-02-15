open System
open System.Drawing

module AsteroidModule = 

    [<StructuredFormatDisplay("{AsString}")>]
    type Asteroid = {
        CenterLocation: Point
        BoundaryTranslations: Point seq
    } with
        override a.ToString() = 
            let transations = a.BoundaryTranslations |> Seq.map (fun x -> x.ToString()) |> String.concat ";"
            sprintf "Center: %A, Boundaries: %s" a.CenterLocation transations

        member a.AsString = a.ToString()

    [<RequireQualifiedAccess>]
    module Asteroid = 
        //type annotation isn't necessary, but could save us issues if the implementation changed
        let drawAll (asteroids: Asteroid seq) =
            asteroids
            |> Seq.iter (printfn "%A")

        let large location = { CenterLocation = location; BoundaryTranslations = [ new Point(3, 3); new Point(3, -3); new Point(-3, -3); new Point(-3, 3) ] }
        let medium location = { CenterLocation = location; BoundaryTranslations = [ new Point(2, 2); new Point(2, -2); new Point(-2, -2); new Point(-2, 2) ] }
        let small location = { CenterLocation = location; BoundaryTranslations = [ new Point(1, 1); new Point(1, -1); new Point(-1, -1); new Point(-1, 1) ] }
        let random (random : Random) gameWidth gameHeight = 
            let location = new Point(random.Next(0,gameWidth), random.Next(0,gameHeight))
            let size = random.Next(0,3)
            match size with
            | 0 -> small location 
            | 1 -> medium location 
            | 2 -> large location
            | _ -> raise <| new InvalidOperationException(sprintf "Whoops: %i" size)

open AsteroidModule

[<EntryPoint>]
let main _ =
    let asteroids = [                
        Asteroid.large(new Point(23, 10));
        Asteroid.medium(new Point(16, 21));
        Asteroid.small(new Point(4, 5))
    ]
    Asteroid.drawAll asteroids
    Console.ReadKey() |> ignore

    let random = new Random (DateTime.Now.Millisecond)
    let randomAsteriods = Seq.init 100 (fun _ -> Asteroid.random random 50 50)

    Asteroid.drawAll randomAsteriods
    Console.ReadKey() |> ignore
    0 
