namespace SeamlessChex
{
    using System;

    /// <summary>
    /// SeamlessChex request excpetion.
    /// </summary>
    public class RequestException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestException"/> class.
        /// </summary>
        public RequestException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public RequestException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public RequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
