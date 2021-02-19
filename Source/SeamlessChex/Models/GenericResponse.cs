namespace SeamlessChex.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a generic response.
    /// </summary>
    public class GenericResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether request was successful.
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether request was successful.
        /// </summary>
        [JsonPropertyName("error")]
        public bool Error { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether request was successful.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
