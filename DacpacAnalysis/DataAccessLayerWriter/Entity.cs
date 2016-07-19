using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerWriter
{
    public class Entity
    {
        public String Type { get; set; }
        public String Name { get; set; }
        public IEnumerable Fields { get; set; }
    }
}
