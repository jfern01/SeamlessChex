namespace SeamlessChex.Converters
{
    using System;
    using System.Globalization;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Responsible for JSON (un)serializing boolean values (0 or 1).
    /// </summary>
    public class NumericStringConverter : JsonConverter<int>
    {
        /// <inheritdoc/>
        public override int Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) => int.Parse(reader.GetString(), CultureInfo.InvariantCulture);

        /// <inheritdoc/>
        public override void Write(
            Utf8JsonWriter writer,
            int value,
            JsonSerializerOptions options) => writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
    }
}
