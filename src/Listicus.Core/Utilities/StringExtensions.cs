using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Listicus.Core.Utilities
{
    public static class StringExtensions
    {
        public static string ToNullOrValue(this string s)
        {
            if (s.IsNullOrWhitespace())
                return null;
            else
                return s;
        }

        public static bool IsNullOrWhitespace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        public static bool IsNotNullOrWhitespace(this string s)
        {
            return !s.IsNullOrWhitespace();
        }

        public static long? ToNullableLong(this string s)
        {
            long parsed;

            if (s.IsNotNullOrWhitespace() && long.TryParse(s, out parsed))
                return parsed;
            else
                return null;
        }

        public static long ToLongOrDefault(this string s)
        {
            long parsed;

            if (s.IsNotNullOrWhitespace() && long.TryParse(s, out parsed))
                return parsed;
            else
                return 0;
        }

        public static bool IsValidUrl(this string s)
        {
            return s.IsNotNullOrWhitespace();
        }
    }
}