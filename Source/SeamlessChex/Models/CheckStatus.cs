namespace SeamlessChex.Models
{
    /// <summary>
    /// The current status of the eCheck.
    /// </summary>
    public enum CheckStatus
    {
        /// <summary>
        /// eCheck has been successfully created and it is waiting for the batch to be closed.
        /// </summary>
        InProcess,

        /// <summary>
        /// The batch is closed and the eCheck is printed.
        /// </summary>
        Printed,

        /// <summary>
        /// The batch is closed and funds are deposited.
        /// </summary>
        Deposited,

        /// <summary>
        /// The eCheck was automatically canceled for some reason. This could be scam or incorrect account details.
        /// </summary>
        Failed,

        /// <summary>
        /// eCheck was manually canceled.
        /// </summary>
        Void,
    }
}
