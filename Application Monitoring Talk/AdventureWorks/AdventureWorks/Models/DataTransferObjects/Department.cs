using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace AdventureWorks.Models.DataTransferObjects
{
    public class Department
    {

        public Department(DbDataReader reader)
        {
            DepartmentId = (Int16) reader["DepartmentID"];
            Name = (string) reader["Name"];
            GroupName = (string) reader["GroupName"];
            ModifiedDate = (DateTime) reader["ModifiedDate"];
        }

        public Int16 DepartmentId {get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}