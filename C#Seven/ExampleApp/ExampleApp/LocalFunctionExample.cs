using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp
{
    public class LocalFunctionExample
    {
        public int AddFactorialNumbers (int number)
        {
            int Multiply (int innerNumber) => 
                 (innerNumber == 1) ? 1 : innerNumber * Multiply(innerNumber - 1);
   
            return Multiply(number);
        }


        public string MakeUpperCaseWithLamda  (string lowerName)
        {
            Func<string,string> makeUpperCase = (name) => name[0].ToString().ToUpper() + String.Join("", name.Take(1));

            return makeUpperCase(lowerName);
        }


        public string MakeFirstCharacterUpperCase(string lowerName)
        {
            string MakeUpperCase(string name) => name[0].ToString().ToUpper() + String.Join("", name.Take(1));

            return MakeUpperCase(lowerName);
        }


        private static String MakeUpperCase (Func<string> getString)
        {
            return getString().ToUpper();
        }

        public static String MakeUpperCaseWithLambda (string name)
        {
            return MakeUpperCase(() => name.Substring(4));
        }

        public static String MakeUpperCaseWithLocalFunction(string name)
        {
            string getName() => name.Substring(4);

            return MakeUpperCase(getName);
        }

        public static IEnumerable<string> GetNames ()
        {
            throw new Exception("I'm an exception");
        }

        /// <summary>
        /// This has lazy evaluation, so you won't find out if the argument is the cause of an exception 
        /// until you start the enumeration. 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static IEnumerable<char> MakeUpperCaseAndReturnParts (string word)
        {
            if (String.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentException("input is null");
            }

            var uppercase = word.ToUpper();

            foreach(var c in uppercase)
            {
                yield return c;
            }

        }

        /// <summary>
        /// Since the enumeration is encapsulated, the evaluation of the paratmer is 
        /// immediate, allowing you to notice the exception when the method is called
        /// and not evaulated at some later time. 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static IEnumerable<char> MakeUpperCaseAndReturnPartsLocalFunction (string word)
        {
            if (String.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentException("input is null");
            }

            IEnumerable<char> EnumerateChars ()
            {
                var uppercase = word.ToUpper();

                foreach (var c in uppercase)
                {
                    yield return c;
                }
            }

            return EnumerateChars();
        }


    }
}
