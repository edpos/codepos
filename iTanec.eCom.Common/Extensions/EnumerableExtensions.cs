using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace UIG.Accounting.Common.Extensions
{
    /// <summary>
    /// Static class containing Enumerable extension methods
    /// </summary>
    /// <history>
    ///  Author				:	Edwin J
    ///  Creation Date		:	16/1/2014
    ///  Last revised		:
    ///  Revision history	:
    /// </history>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Converts all items of a list and returns them as enumerable.
        /// </summary>
        /// <typeparam name="TSource">The source data type</typeparam>
        /// <typeparam name="TTarget">The target data type</typeparam>
        /// <param name="source">The source data.</param>
        /// <returns>The converted data</returns>
        /// <example>
        ///
        /// var values = new[] { "1", "2", "3" };
        /// values.ConvertList&lt;string, int&gt;().ForEach(Console.WriteLine);
        ///
        /// </example>
        public static IEnumerable<TTarget> ConvertList<TSource, TTarget>(this IEnumerable<TSource> source)
        {
            foreach (var value in source)
            {
                yield return value.ConvertTo<TTarget>();
            }
        }

        /// <summary>
        /// Performs an action for each item in the enumerable
        /// </summary>
        /// <typeparam name="T">The enumerable data type</typeparam>
        /// <param name="values">The data values.</param>
        /// <param name="action">The action to be performed.</param>
        /// <example>
        ///
        /// var values = new[] { "1", "2", "3" };
        /// values.ConvertList&lt;string, int&gt;().ForEach(Console.WriteLine);
        ///
        /// </example>
        /// <remarks>This method was intended to return the passed values to provide method chaining. Howver due to defered execution the compiler would actually never run the entire code at all.</remarks>
        public static void ForEach<T>(this IEnumerable<T> values, Action<T> action)
        {
            foreach (var value in values)
            {
                action(value);
            }
        }

        public static IEnumerable<IEnumerable<T>> Transpose<T>(this IEnumerable<IEnumerable<T>> values)
        {
            if (values.Count() == 0)
                return values;
            if (values.First().Count() == 0)
                return Transpose(values.Skip(1));

            var x = values.First().First();
            var xs = values.First().Skip(1);
            var xss = values.Skip(1);
            return
             new[] {new[] {x}
           .Concat(xss.Select(ht => ht.First()))}
               .Concat(new[] { xs }
               .Concat(xss.Select(ht => ht.Skip(1)))
               .Transpose());
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}