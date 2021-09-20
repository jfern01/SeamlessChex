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
        /// Fail <see cref="Risk">risk</see> status.
        /// </summary>
        public const string RiskStatusFail = "Fail";

        /// <summary>
        /// Pass <see cref="Risk">risk</see> status.
        /// </summary>
        public const string RiskStatusPass = "Pass";

        /// <summary>
        /// Gets or sets details about the retrieved status of verification.
        /// </summary>
        [JsonPropertyName("description_bv")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets basic verification response code. https://developers.seamlesschex.com/seamlesschex/docs/#basic-verification.
        /// </summary>
        [JsonPropertyName("code_bv")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating risk status.
        /// </summary>
        [JsonPropertyName("risk_bv")]
        public string Risk { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether basic verification was passed.
        /// </summary>
        [JsonPropertyName("pass_bv")]
        [JsonConverter(typeof(BooleanNumericConverter))]
        public bool Pass { get; set; }

        /// <summary>
        /// Gets or sets the status of a basic verification.
        /// See: https://developers.seamlesschex.com/seamlesschex/docs/#basic-verification.
        /// </summary>
        [JsonPropertyName("verification_bv")]
        public string Verification { get; set; }

        /// <summary>
        /// Gets a value indicating whether basic verification is risky.
        /// </summary>
        public bool IsRisky => this.Risk != RiskStatusPass;
    }
}
