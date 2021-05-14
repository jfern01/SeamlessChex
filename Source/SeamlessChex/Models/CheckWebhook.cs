namespace SeamlessChex.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a check webhook request.
    /// </summary>
    public class CheckWebhook
    {
        /// <summary>
        /// Occurs whenever a check has created.
        /// </summary>
        public const string EventTypeCreated = "check.created";

        /// <summary>
        /// Occurs whenever a check or check’s status has updated.
        /// </summary>
        public const string EventTypeChanged = "check.changed";

        /// <summary>
        /// Occurs whenever a check has voided.
        /// </summary>
        public const string EventTypeDeleted = "check.deleted";

        /// <summary>
        /// Occurs when funds confirmation response is available.
        /// </summary>
        public const string EventTypeFundConfirmation = "check.fund_confirmation";

        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        [JsonPropertyName("event")]
        public string Event { get; set; }

        /// <summary>
        /// Gets or sets the check object.
        /// </summary>
        [JsonPropertyName("data")]
        public Check Data { get; set; }
    }
}
