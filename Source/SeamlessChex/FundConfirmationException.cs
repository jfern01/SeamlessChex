namespace SeamlessChex
{
    /// <summary>
    /// SeamlessChex "Fund Confirmation Limit Reached" exception.
    /// </summary>
    public class FundConfirmationException : RequestException
    {
        /// <inheritdoc/>
        public override string Message => "Fund Confirmation limit reached";
    }
}
