﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileTimeStoredProcedures
{
    public interface IDbQuery
    {
        string Query {get;}

        IEnumerable<StoredProcedureParameterTypeAndValue> SqlParameters { get; }

    }
}
