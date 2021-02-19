namespace SeamlessChex.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using SeamlessChex.Converters;

    /// <summary>
    /// Represends a collection of checks.
    /// </summary>
#pragma warning disable CA1711 // Identifiers should not have incorrect suffix
    public class CheckCollection
#pragma warning restore CA1711 // Identifiers should not have incorrect suffix
    {
        /// <summary>
        /// Gets or sets the number of the current page.
        /// </summary>
        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the number of the previous page before the current one that defines your place in the list.
        /// </summary>
        [JsonPropertyName("from")]
        public int From { get; set; }

        /// <summary>
        /// Gets or sets the number of the next page after the current one that defines your place in the list.
        /// </summary>
        [JsonPropertyName("to")]
        public int To { get; set; }

        /// <summary>
        /// Gets or sets the total number of eChecks objects in the array list.
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the number of the last page.
        /// </summary>
        [JsonPropertyName("last_page")]
        public int LastPage { get; set; }

        /// <summary>
        /// Gets or sets the total number of eChecks objects in the array list per one page.
        /// </summary>
        [JsonPropertyName("per_page")]
        [JsonConverter(typeof(NumericStringConverter))]
        public int PerPage { get; set; }

        /// <summary>
        /// Gets or sets the collection of checks.
        /// </summary>
        [JsonPropertyName("data")]
        public IEnumerable<Check> Data { get; set; }
    }
}
