namespace CoffeeCat.RiotCommon.Utils
{
    using System;
    using System.Collections.Generic;

    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> NotNull<TSource>(this IEnumerable<TSource> source)
        {
            foreach (var item in source)
            {
                if (item != null)
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TSource> NotNull<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            foreach (var item in source)
            {
                if (selector(item) != null)
                {
                    yield return item;
                }
            }
        }
    }
}
