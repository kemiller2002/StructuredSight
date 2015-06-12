using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace AlteringCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\projects\HackingIISDotNET\CodeToAlter\bin\Debug\";

            String entryTarget = "CodeToAlter.exe";

            string newTarget = "HijackedCode.exe";

            var definition = AssemblyDefinition.ReadAssembly(path + entryTarget);

            foreach (var t in definition.MainModule.Types)
            {
                foreach (var m in t.Methods)
                {
                    Console.WriteLine(m.Name);
                    if (m.Name == "AddTwoNumbers")
                    {
                        var processor = m.Body.GetILProcessor();
                        var instructions = processor.Body.Instructions.Skip(1).ToList();

                        foreach (var i in instructions)
                        {
                            processor.Remove(i);
                        }

                        processor.Append(processor.Create(OpCodes.Ldarg_0));

                        processor.Append(processor.Create(OpCodes.Ret));
                    }
                }
            }

            Constants.Save(definition, path + newTarget);
        }
    }
}
