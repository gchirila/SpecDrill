using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecDrill.Exceptions
{
    public class InvalidAttributeTargetException : ApplicationException
    {
        public InvalidAttributeTargetException(string message) : base(message) { }
    }
}
