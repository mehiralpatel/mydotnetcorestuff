using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Extension
{
    public static class LinqExtensions
    {
        public static IEnumerable<TResult> TakeIfNotNull<TResult>(this IEnumerable<TResult> source, int? count)
        {
            return !count.HasValue ? source : source.Take(count.Value);
        }
    }
}
