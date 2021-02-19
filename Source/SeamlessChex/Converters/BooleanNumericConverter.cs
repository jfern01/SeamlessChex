namespace SeamlessChex.Converters
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Responsible for JSON (un)serializing boolean values (0 or 1).
    /// </summary>
    public class BooleanNumericConverter : JsonConverter<bool>
    {
        /// <inheritdoc/>
        public override bool Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) => reader.GetInt32() == 1;

        /// <inheritdoc/>
        public override void Write(
            Utf8JsonWriter writer,
            bool value,
            JsonSerializerOptions options) => writer.WriteNumberValue(value ? 1 : 0);
    }
}
