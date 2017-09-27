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
            where T: struct, IConvertible
        {
            var result = enumValue.AsEnum<T>();

            if (!result.HasValue)
                throw new Exception($" {enumValue} is not a member of {typeof(T).Name} enum");

            return result.Value;
        }

        public static object AsEnum(this string enumValue, Type enumType)
        {
            if (!enumType.IsEnum)
                return null;

            object parsedEnumValue = null;

            try { parsedEnumValue = Enum.Parse(enumType, enumValue); } catch { }

            return parsedEnumValue;
        }

        public static bool OfEnum(this string enumValue, Type enumType)
        {
            if (! enumType.IsEnum)
                return false;

            object parsedOrientation = null;

            try { parsedOrientation = Enum.Parse(enumType, enumValue); } catch { }

            return (parsedOrientation != null);
        }

        public static bool OfEnum<T>(this string enumValue)
            where T : struct, IConvertible
            => enumValue.OfEnum(typeof(T));
        public static T? AsEnum<T>(this string enumValue)
            where T : struct, IConvertible
            => (T)enumValue.AsEnum(typeof(T));
    }
}
