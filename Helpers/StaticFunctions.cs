using System;

namespace Piksel.Helpers
{
    /// <summary>
    /// This class is intended to be <c>use static</c>'d and includes generic utility and readability functions
    /// </summary>
    /// <example>
    /// using static Piksel.Helpers.StaticFunctions;
    /// </example>
    public static class StaticFunctions
    {
        /// <summary>
        /// Execute <paramref name="tryFunc"/> in a try-catch clause. 
        /// If it fails, throw new <see cref="Exception"/> with <see cref="Exception.Message"/> 
        /// set to <paramref name="failureMessage"/> and <see cref="Exception.InnerException"/>
        /// set to the exception that was thrown by <paramref name="tryFunc"/>.
        /// </summary>
        /// <param name="tryFunc">The function to execute inside the clause</param>
        /// <param name="failureMessage">The message that the resulting Exception will contain upon failure</param>
        /// <example>
        ///     TryOrThrow(() => foo.DoSomethingThatMayFail(), "Failed to do Something using foo");
        /// </example>
        public static void TryOrThrow(Action tryFunc, string failureMessage)
        {
            try
            {
                tryFunc();
            }
            catch (Exception x)
            {
                throw new Exception(failureMessage, x);
            }
        }

        /// <summary>
        /// Execute <paramref name="tryFunc"/> in a try-catch clause returning it's result. 
        /// If it fails, throw new <see cref="Exception"/> with <see cref="Exception.Message"/> 
        /// set to <paramref name="failureMessage"/> and <see cref="Exception.InnerException"/>
        /// set to the exception that was threwn by <paramref name="tryFunc"/>.
        /// </summary>
        /// <typeparam name="TResult">Type of return value, can usually be inferred from <paramref name="tryFunc"/></typeparam>
        /// <param name="tryFunc">The function to execute inside the clause</param>
        /// <param name="failureMessage">The message that the resulting Exception will contain upon failure</param>
        /// <returns>Instance of <typeparamref name="TResult"/> if no exception was thrown</returns>
        /// <example>
        ///     var something = Attempt(() => foo.GetSomethingThatMayFail(), "Failed to get Something from foo");
        /// </example>
        public static TResult Attempt<TResult>(Func<TResult> tryFunc, string failureMessage)
        {
            try
            {
                return tryFunc();
            }
            catch (Exception x)
            {
                throw new Exception(failureMessage, x);
            }
        }
    }
}
