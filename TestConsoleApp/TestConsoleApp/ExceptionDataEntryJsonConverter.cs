using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TestConsoleApp
{
    public class ExceptionDataEntryJsonConverter : JsonConverter<ExceptionDataEntry>
    {
        public override ExceptionDataEntry Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            const string message =
                "Unnecessary because you don't convert the ExceptionDataEntry to JSON so don't use this converter for reading JSON";
            throw new NotSupportedException(message);
        }

        public override void Write(Utf8JsonWriter writer, ExceptionDataEntry entry, JsonSerializerOptions options)
        {
            //If there is another way to write an object 
            //or to write a JSON string as an object into the writer, Please let me know.
            JsonSerializer.Serialize(writer, entry.Value, options);
        }
    }
}