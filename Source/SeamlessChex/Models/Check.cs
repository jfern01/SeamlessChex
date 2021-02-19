namespace SeamlessChex.Models
{
    using System;
    using System.Text.Json.Serialization;
    using SeamlessChex.Converters;

    /// <summary>
    /// Represents a check request.
    /// </summary>
    public class Check
    {
        /// <summary>
        /// Gets or sets unique identifier for the eCheck object.
        /// </summary>
        [JsonPropertyName("check_id")]
        public string CheckId { get; set; }

        /// <summary>
        /// Gets or sets when eCheck was created.
        /// </summary>
        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// Gets or sets the custom number of a check. If this field has not been sent,
        /// the check number will be filled in automatically.
        /// </summary>
        [JsonPropertyName("number")]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the amount of the check. The check amount has to be positive.
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets a brief description of the purpose of the check.
        /// </summary>
        [JsonPropertyName("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// Gets or sets the sender’s name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the sender’s email address.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the specified date will be displayed on the check.
        /// By default, the date of eCheck creation will be presented.
        /// The authorization date can not be older than 30 days.
        /// The authorization date can not be future dated.
        /// </summary>
        [JsonPropertyName("authorization_date")]
        [JsonConverter(typeof(DateTimeOffsetDateOnlyConverter))]
        public DateTimeOffset AuthorizationDate { get; set; }

        /// <summary>
        /// Gets or sets the label is useful to find similar eChecks.
        /// </summary>
        [JsonPropertyName("label")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the sender’s phone number.
        /// </summary>
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the sender’s address.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the sender’s city.
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the sender’s state.
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the sender’s postal code.
        /// </summary>
        [JsonPropertyName("zip")]
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets the sender’s bank account.
        /// The ‘bank_routing’ and ‘bank_account’ fields must be both entered.
        /// In this case, both fields ‘token’ and ‘store’ must not be entered.
        /// </summary>
        [JsonPropertyName("bank_account")]
        public string BankAccount { get; set; }

        /// <summary>
        /// Gets or sets the sender’s bank routing number.
        /// The ‘bank_routing’ and ‘bank_account’ fields must be both entered.
        /// In this case, both fields ‘token’ and ‘store’ must not be entered.
        /// </summary>
        [JsonPropertyName("bank_routing")]
        public string BankRouting { get; set; }

        /// <summary>
        /// Gets or sets the sender’s bank name.
        /// </summary>
        [JsonPropertyName("bank_name")]
        public string BankName { get; set; }

        /// <summary>
        /// Gets or sets the sender’s bank address.
        /// </summary>
        [JsonPropertyName("bank_address")]
        public string BankAddress { get; set; }

        /// <summary>
        /// Gets or sets the sender’s bank city.
        /// </summary>
        [JsonPropertyName("bank_city")]
        public string BankCity { get; set; }

        /// <summary>
        /// Gets or sets the sender’s bank state.
        /// </summary>
        [JsonPropertyName("bank_state")]
        public string BankState { get; set; }

        /// <summary>
        /// Gets or sets the sender’s bank postal code.
        /// </summary>
        [JsonPropertyName("bank_zip")]
        public string BankZip { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable recurring payments.
        /// </summary>
        [JsonPropertyName("recurring")]
        [JsonConverter(typeof(BooleanNumericConverter))]
        public bool Recurring { get; set; }

        /// <summary>
        /// Gets or sets the recurring payment will occur with a selected frequency.
        /// The options available for recurring payments are daily, weekly, bi-weekly or monthly.
        /// </summary>
        [JsonPropertyName("recurring_cycle")]
        public RecurringCycle? RecurringCycle { get; set; }

        /// <summary>
        /// Gets or sets the recurring payments will start on the day of its creation, if NULL.
        /// If a start date is entered, the recurring payment will start on the start date selected.
        /// </summary>
        [JsonPropertyName("recurring_start_date")]
        [JsonConverter(typeof(DateTimeOffsetDateOnlyConverter))]
        public DateTimeOffset? RecurringStartDate { get; set; }

        /// <summary>
        /// Gets or sets the recurring payments to occur a specific number of times or to be indefinite.
        /// </summary>
        [JsonPropertyName("recurring_installments")]
        public int? RecurringInstallments { get; set; }

        /// <summary>
        /// Gets or sets link to a check generated for mobile devices.
        /// </summary>
        [JsonPropertyName("mobile")]
        public Uri Mobile { get; set; }

        /// <summary>
        /// Gets or sets link to a check for printing on paper.
        /// </summary>
        [JsonPropertyName("paper")]
        public Uri Paper { get; set; }

        /// <summary>
        /// Gets or sets basic verification object.
        /// </summary>
        [JsonPropertyName("basic_verification")]
        public BasicVerification BasicVerification { get; set; }

        /// <summary>
        /// Gets or sets funds confirmation object.
        /// </summary>
        [JsonPropertyName("funds_confirmation")]
        public FundsConfirmation FundsConfirmation { get; set; }
    }
}
