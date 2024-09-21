module Program

open FSharp.UMX
open FsToolkit.ErrorHandling

type [<Measure>] m
type [<Measure>] r

type P = | P
type S = | S

let doThing (a: float<m>) (b:float<m>) =
    ()

let x (mr : (float<m>*float<r>) option) : unit =
    option {
        // Needs annotation
        //let! (m:float<m>,r:float<r>) = mr
        let! (m, r) = mr

        let r = UMX.cast<r, m>r
        doThing r m
    }
    |> ignore

let y (s : S option ) (p : P option)=
    option {
        // Needs annotation
        //let! (_s : S) = s
        let! _s = s

        // Needs annotation
        //let! (_p : P) = p
        let! _p = p

        ()
    } |> ignore

[<EntryPoint>]
let main argv =
    0