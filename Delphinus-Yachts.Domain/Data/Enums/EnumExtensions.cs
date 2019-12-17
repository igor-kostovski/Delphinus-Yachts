using System;
using System.Runtime.InteropServices.ComTypes;

namespace Delphinus_Yachts.Domain.Data.Enums
{
    public static class EnumExtensions
    {
        public static T? ToEnum<T>(this string value) where T : struct
        {
            if (Enum.TryParse<T>(value, true, out var result))
                return result;
            return null;
        }


        public static string ToString<T> (this T value)
        {
            return Enum.GetName(typeof(T), value);
        }
    }
}
