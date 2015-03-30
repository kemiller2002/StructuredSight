using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverloading
{
    public class Parent
    {
        public string FormatMessage(string message)
        {
            return "This is the parent: " + message;
        }

        public string AppendAndFormat(string message, string append)
        {
            return FormatMessage(message + append);
        }
        
    }

    public class Child : Parent
    {
        public string FormatMessage(object message)
        {
            return "This is the child: " + message;
        }
    }


    public class EqualOverloads
    {

        public string FormatMessage(string message)
        {
            return "This is the string: " + message;
        }

        public string FormatMessage(object message)
        {
            return "This is the object: " + message;
        }
    }




}
