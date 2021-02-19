namespace SeamlessChex.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a check response.
    /// </summary>
    public class CheckResponse : GenericResponse
    {
        /// <summary>
        /// Gets or sets the check object.
        /// </summary>
        [JsonPropertyName("check")]
        public Check Check { get; set; }
    }
}
