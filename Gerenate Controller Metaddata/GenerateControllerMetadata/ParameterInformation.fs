namespace StructuredSight.Web.Api
open System
open System.Reflection
open StructuredSight
open System.Web


module ParameterInformation = 
    let HasFromBody (pi:ParameterInfo) = 
        pi.GetCustomAttributes() |> 
            Seq.exists
                (
                    fun x-> 
                            x.GetType().Name
                                .Equals("FromBodyAttribute", StringComparison.OrdinalIgnoreCase)
                )

    let Create (pi:ParameterInfo) = 
        {
            Variable = VariableInformation.Create (pi.Name , pi.ParameterType);
            FromBody = HasFromBody pi
            HasDefaultValue = pi.HasDefaultValue
        }