using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecDrill.Exceptions
{
    public class DynamicMemberInitializationException : ApplicationException
    {
        public DynamicMemberInitializationException(string message) : base(message) { }
    }
}
