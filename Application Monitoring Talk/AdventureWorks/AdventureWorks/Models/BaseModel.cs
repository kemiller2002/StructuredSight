using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace AdventureWorks.Models
{
    public class BaseModel
    {
        protected Func<DbCommand> GetCommand;

        public BaseModel(Func<DbCommand> getCommand)
        {
            GetCommand = getCommand;
        }



    }
}