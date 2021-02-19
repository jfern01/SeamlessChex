namespace SeamlessChex.Models
{
    using System.Text.Json.Serialization;
    using SeamlessChex.Converters;

    /// <summary>
    /// The result of checking the bank account information.
    /// </summary>
    public class BasicVerification
    {
        /// <summary>
        /// Gets or sets details about the retrieved status of verification.
        /// </summary>
        [JsonPropertyName("description_bv")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether basic verification was passed.
        /// </summary>
        [JsonPropertyName("pass_bv")]
        [JsonConverter(typeof(BooleanNumericConverter))]
        public bool Pass { get; set; }

        /// <summary>
        /// Gets or sets the status of a basic verification.
        /// See: https://developers.seamlesschex.com/seamlesschex/docs/#basicVerification.
        /// </summary>
        [JsonPropertyName("verification_bv")]
        public string Verification { get; set; }
    }
}
