namespace SeamlessChex.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a update check request.
    /// </summary>
    public class UpdateCheckRequest : CreateCheckRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier for the eCheck object.
        /// </summary>
        [JsonPropertyName("check_id")]
        public string CheckId { get; set; }
    }
}
