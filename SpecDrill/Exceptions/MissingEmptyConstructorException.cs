using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecDrill.Exceptions
{
    public class MissingEmptyConstructorException : ApplicationException
    {
        public MissingEmptyConstructorException(string message) : base(message) { }
        public MissingEmptyConstructorException(string message, Exception innerException) : base(message, innerException) { }
    }
}
