using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerWriter
{
    static class StringExtensions
    {
        public static string RemoveSquareBrackets(this string item)
            => (item == null) ? null : item.Replace("[", "").Replace("]", "");
    }
}
