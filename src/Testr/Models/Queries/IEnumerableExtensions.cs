using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testr.Models.Queries
{
    public static class IEnumerableExtensions
    {
        public static void Each<T>(this IEnumerable<T> values, Action<T> action)
        {
            foreach (var value in values)
            {
                action(value);
            }
        }
    }
}