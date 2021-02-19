namespace SeamlessChex.Converters
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using SeamlessChex.Models;

    /// <summary>
    /// Responsible for JSON (un)serializing CheckStatus.
    /// </summary>
    public class RecurringCycleConverter : JsonConverter<RecurringCycle>
    {
        /// <inheritdoc/>
        public override RecurringCycle Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) => reader.GetString() switch
            {
                "daily" => RecurringCycle.Daily,
                "weekly" => RecurringCycle.Weekly,
                "bi-weekly" => RecurringCycle.BiWeekly,
                "monthly" => RecurringCycle.Monthly,
                _ => throw new InvalidOperationException($"Invalid recurring cycle '{reader.GetString()}'"),
            };

        /// <inheritdoc/>
        public override void Write(
            Utf8JsonWriter writer,
            RecurringCycle value,
            JsonSerializerOptions options)
        {
            switch (value)
            {
                case RecurringCycle.Daily:
                    writer.WriteStringValue("daily");
                    break;
                case RecurringCycle.Weekly:
                    writer.WriteStringValue("weekly");
                    break;
                case RecurringCycle.BiWeekly:
                    writer.WriteStringValue("bi-weekly");
                    break;
                case RecurringCycle.Monthly:
                    writer.WriteStringValue("monthly");
                    break;
                default:
                    writer.WriteNullValue();
                    break;
            }
        }
    }
}
