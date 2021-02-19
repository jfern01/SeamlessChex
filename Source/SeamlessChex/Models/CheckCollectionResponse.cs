namespace SeamlessChex.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a check list response.
    /// </summary>
    public class CheckCollectionResponse : GenericResponse
    {
        /// <summary>
        /// Gets or sets a list with a data property that contains an array of up to limit eChecks.
        /// </summary>
        [JsonPropertyName("list")]
        public CheckCollection List { get; set; }
    }
}
