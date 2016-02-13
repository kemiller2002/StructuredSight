using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Web;
using AdventureWorks.Models.DataTransferObjects;
using StackExchange.Profiling;

namespace AdventureWorks.Models
{
    public class HumanResourcesModel : BaseModel
    {

        public HumanResourcesModel(Func<DbCommand> getCommand) : base(getCommand)
        {
            
        }

        public IEnumerable<Department> GetDepartments()
        {
            var command = GetCommand();

            command.CommandText = "SELECT * FROM HumanResources.Department";
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new Department(reader);
            }

        }

        
        public static IEnumerable<String> GetPropDepartments(Stream fileStream)
        {
            using (MiniProfiler.Current.Step("File Read Operation"))
            {
                using (var writer = new StreamReader(fileStream))
                {
                    yield return writer.ReadLine();
                }
            }
        } 




    }
}