using System;
using System.Collections.Generic;

namespace CoffeeCat.RiotCommon.Utils
{
    public class Validation
    {
        public static void ValidateNotNull(object obj, string name)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void ValidateNotNullOrWhitespace(string s, string name)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void ValidateNotNullOrEmpty<T>(ICollection<T> list, string name)
        {
            if (list == null || list.Count == 0)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
