using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp
{

    static class FirstAndLastNameNoDeconstructorExtensions
    {
        public static void Deconstruct (this FirstAndLastNameNoDeconstructor obj, out string first, out string last)
        {
            first = obj.First;
            last = obj.Last;
        }

    }


    class FirstAndLastNameNoDeconstructor
    {
        public string First;
        public string Last;
        public FirstAndLastNameNoDeconstructor (string first, string last)
        {
            First = first;
            Last = last;
        }

    }


    class FirstAndLastName
    {
        string _firstName;
        string _lastName;

        public FirstAndLastName(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public void Deconstruct(out string firstName, out string lastName)
        {
            firstName = _firstName;
            lastName = _lastName;
        }

        public void Deconstruct(out string firstName) {
            firstName = _firstName;
        }

        public void AssignByOut (out string firstName, out string lastName)
        {
            firstName = _firstName;
            lastName = _lastName;

        }
    }


    class Deconstructors
    {

        public static FirstAndLastName GetFirstAndLastname ()
        {
            return new FirstAndLastName("Jenny", "no last name");
        }

        public void Show()
        {
            //var (first, last) = GetFirstAndLastname();

            //var firstName = GetFirstAndLastname();

            var firstAndLastName = new FirstAndLastName("Jenny", "?");
            var (firstName, lastName) = firstAndLastName; //automatically calls method Deconstruct.

        }

        public void ShowNoDeconstrcutor()
        {
            var noDeconstructor = new FirstAndLastNameNoDeconstructor("jenny", "no last name given");

            var (first, last) = noDeconstructor;
        }


        public void ShowAssignByOut ()
        {
            string first;
            string last;

            var firstAndLastName = new FirstAndLastName("Jenny", "?");

            firstAndLastName.AssignByOut(out first, out last);
        }
    }
}
