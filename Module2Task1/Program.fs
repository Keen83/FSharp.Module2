// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open System

let checkNumber str = 
    let isCorrect, no = Int32.TryParse(str)
    if isCorrect && no >= 0 && no < 120 then no
    else -1

let (|IsNameEmpty|) name = 
    String.IsNullOrWhiteSpace name

let readName() = 
    printfn "%s" "Enter the name: "
    let name = Console.ReadLine()
    name

let readAge() = 
    printfn "%s" "Enter correct age: "
    let str = Console.ReadLine()
    let no = checkNumber str
    no

let getAge(name) = 
    match readAge() with 
    | -1 -> None
    | age -> Some age
    
let rec getName() = 
    match readName() with 
    | IsNameEmpty true -> None
    | name -> Some name

let getData1 name age = 
    match name() with 
    | None -> None
    | Some name -> Some(name, age())
    
let rec getData() =
    let data = getData1 <| getName <| getAge
    match data with 
    | None -> []
    | Some (_, None) -> []
    | Some (a, b) -> (a, b.Value) :: getData()
    

let print3 tuple =
    match tuple with 
    | (a, b, c) -> printfn "%A - %A - %s" a b c

let print tuple1 =
   match tuple1 with
    | (a, b) when b < 13 -> print3 (a, b, a + " is a child")
    | (a, b) when b >= 13 && b < 18 -> print3 (a, b, a + " is a teenager")
    | (a, b) -> print3 (a, b, a + " is not longer a teenager")

[<EntryPoint>]
let main argv = 
    let data = getData() |> List.iter(fun x -> print x)
        
    Console.ReadKey()
    0 // return an integer exit code