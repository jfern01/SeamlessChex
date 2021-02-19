namespace SeamlessChex.Models
{
    /// <summary>
    /// The recurring payment will occur with a selected frequency.
    /// The options available for recurring payments are daily, weekly, bi-weekly or monthly.
    /// </summary>
    public enum RecurringCycle
    {
        /// <summary>
        /// Daily.
        /// </summary>
        Daily,

        /// <summary>
        /// Weekly.
        /// </summary>
        Weekly,

        /// <summary>
        /// Bi-weekly.
        /// </summary>
        BiWeekly,

        /// <summary>
        /// Monthly.
        /// </summary>
        Monthly,
    }
}
