using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecDrill.Exceptions
{
    public class MissingHomepageConfigEntryException : ApplicationException
    {
        public MissingHomepageConfigEntryException(string message) : base(message) { }
    }
}
