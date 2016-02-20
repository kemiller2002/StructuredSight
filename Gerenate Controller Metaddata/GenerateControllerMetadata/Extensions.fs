namespace StructuredSight

[<System.Runtime.CompilerServices.Extension>]
module Extensions = 
   
   [<System.Runtime.CompilerServices.Extension>] 
   let ReturnOption (this:string) = 
        if System.String.IsNullOrWhiteSpace this then None
        else Some this

       