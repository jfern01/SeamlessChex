namespace SeamlessChex
{
    /// <summary>
    /// SeamlessChex "Basic Verification Limit Reached" exception.
    /// </summary>
    public class BasicVerificationException : RequestException
    {
        /// <inheritdoc/>
        public override string Message => "Basic Verification limit reached";
    }
}
