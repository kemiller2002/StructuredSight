using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuredSite.ApplicationBusinessLogic
{

    public interface IDataInteractionCode
    {
        //T Query<T>(string command, params string[] parameters);
        IEnumerable<T> Query<T>(string command, params string[] parameters);
    }

    public class DI {

    }

    public class BusinessLogic
    {
        internal IDataInteractionCode _iDataInteraction;
        public BusinessLogic(IDataInteractionCode dataInteraction)
        {
            _iDataInteraction = dataInteraction;
        }

        public BusinessLogic(DI dataInteraction)
        {

        }

    }
}
