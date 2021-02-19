namespace SeamlessChex.Converters
{
    using System;
    using System.Globalization;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Responsible for JSON (un)serializing DateTimeOffset but only the date part (YYYY-MM-DD).
    /// </summary>
    public class DateTimeOffsetDateOnlyConverter : JsonConverter<DateTimeOffset>
    {
        /// <inheritdoc/>
        public override DateTimeOffset Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
                DateTimeOffset.ParseExact(reader.GetString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);

        /// <inheritdoc/>
        public override void Write(
            Utf8JsonWriter writer,
            DateTimeOffset value,
            JsonSerializerOptions options) =>
                writer.WriteStringValue(value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
    }
}
