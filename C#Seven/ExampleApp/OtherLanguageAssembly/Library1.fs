namespace OtherLanguageAssembly

module IntegrationAssembly =
    
   let CheckNameAndPhone (nameAndPhone:(string * string)) =
        let name,phone = nameAndPhone
         
        (name, phone, name.Equals("Jenny", System.StringComparison.OrdinalIgnoreCase) && phone.Equals("867-5309"))


    (*let CheckPhoneWithValueTuple (nameAndPhone:System.ValueTuple<string,string>) = 
        let name,phone = nameAndPhone

        new System.ValueTuple<string,string,bool>
            (name, phone, name.Equals("Jenny", System.StringComparison.OrdinalIgnoreCase) && phone.Equals("867-5309"))
    *)
    