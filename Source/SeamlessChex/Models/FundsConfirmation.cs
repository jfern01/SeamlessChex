namespace SeamlessChex.Models
{
    using System.Text.Json.Serialization;
    using SeamlessChex.Converters;

    /// <summary>
    /// The result of checking the availability of funds.
    /// </summary>
    public class FundsConfirmation
    {
        /// <summary>
        /// Gets or sets details about the retrieved status of funds verification.
        /// </summary>
        [JsonPropertyName("description_fc")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether funds are confirmed.
        /// </summary>
        [JsonPropertyName("pass_fc")]
        [JsonConverter(typeof(BooleanNumericConverter))]
        public bool Pass { get; set; }

        /// <summary>
        /// Gets or sets the status of a funds confirmation.
        /// See: https://developers.seamlesschex.com/seamlesschex/docs/#foundConfirmation.
        /// </summary>
        [JsonPropertyName("verification_fc")]
        public string Verification { get; set; }
    }
}
