using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecDrill.Infrastructure
{
    public static class Converters
    {
        public static T ToEnum<T>(this string enumValue)
            where T: struct
        {
            return (T) Enum.Parse(typeof (T), enumValue);
        }
    }
}
