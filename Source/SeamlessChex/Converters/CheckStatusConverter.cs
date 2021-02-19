namespace SeamlessChex.Converters
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using SeamlessChex.Models;

    /// <summary>
    /// Responsible for JSON (un)serializing CheckStatus.
    /// </summary>
    public class CheckStatusConverter : JsonConverter<CheckStatus>
    {
        /// <inheritdoc/>
        public override CheckStatus Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) => reader.GetString() switch
            {
                "in_process" => CheckStatus.InProcess,
                "printed" => CheckStatus.Printed,
                "deposited" => CheckStatus.Deposited,
                "failed" => CheckStatus.Failed,
                "void" => CheckStatus.Void,
                _ => throw new InvalidOperationException($"Invalid check status '{reader.GetString()}'"),
            };

        /// <inheritdoc/>
        public override void Write(
            Utf8JsonWriter writer,
            CheckStatus value,
            JsonSerializerOptions options)
        {
            switch (value)
            {
                case CheckStatus.InProcess:
                    writer.WriteStringValue("in_process");
                    break;
                case CheckStatus.Printed:
                    writer.WriteStringValue("printed");
                    break;
                case CheckStatus.Deposited:
                    writer.WriteStringValue("deposited");
                    break;
                case CheckStatus.Failed:
                    writer.WriteStringValue("failed");
                    break;
                case CheckStatus.Void:
                    writer.WriteStringValue("void");
                    break;
                default:
                    break;
            }
        }
    }
}
