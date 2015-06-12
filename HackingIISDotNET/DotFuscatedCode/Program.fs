// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.


let GetNumber () = System.Console.ReadLine() |> System.Int32.Parse

let AddNumbers (f)(s) = f + s
 
let DisplayAddTwoNumberes = "Add Two Numbers: "


[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    printfn "%s" DisplayAddTwoNumberes

    printf "First Number "
    let fNumber = GetNumber ()

    printf "Second Number "
    let sNumber = GetNumber ()

    let total = AddNumbers fNumber sNumber 


    printfn "Your total is: %i" total

    System.Console.ReadLine () |> ignore

    0 // return an integer exit code
