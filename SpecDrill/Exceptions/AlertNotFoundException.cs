using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecDrill.Exceptions
{
    public class AlertNotFoundException : ApplicationException
    {
        public AlertNotFoundException(string message) : base(message) { }
    }
}
