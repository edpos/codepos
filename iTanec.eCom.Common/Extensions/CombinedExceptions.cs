using System;

namespace UIG.Accounting.Common.Extensions
{
    /// <summary>
    /// Helper class for combined exceptions
    /// </summary>
    /// <history>
    ///  Author				:	Edwin J
    ///  Creation Date		:	16/1/2014
    ///  Last revised		:
    ///  Revision history	:
    /// </history>
    public class CombinedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CombinedException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerExceptions">The inner exceptions.</param>
        public CombinedException(string message, Exception[] innerExceptions)
            : base(message)
        {
            this.InnerExceptions = innerExceptions;
        }

        /// <summary>
        /// Gets the inner exceptions.
        /// </summary>
        /// <value>The inner exceptions.</value>
        public Exception[] InnerExceptions { get; protected set; }
    }
}