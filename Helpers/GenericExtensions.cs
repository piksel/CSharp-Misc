using System;

namespace Piksel.Helpers
{
    public static class GenericExtensions
    {
        /// <summary>
        /// Attempt to convert <paramref name="source"/> into <paramref name="result"/> using <paramref name="conversionFunction"/>
        /// </summary>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <remarks>Types can usually be inferred by the body of <paramref name="conversionFunction"/></remarks>
        /// <param name="source"></param>
        /// <param name="conversionFunction"></param>
        /// <param name="result"></param>
        /// <returns>Returns whether <paramref name="conversionFunction"/> executed without throwing any exceptions</returns>
        /// <example>
        ///     if (foo.TryConvert(b => b.ToString(), out string result))
        ///     {
        ///         // use result
        ///     }
        /// </example>
        public static bool TryConvert<TSource, TResult>(this TSource source, Func<TSource, TResult> conversionFunction, out TResult result)
        {
            try
            {
                result = conversionFunction(source);
                return true;
            }
            catch
            {
                result = default(TResult);
                return false;
            }
        }
    }
}
