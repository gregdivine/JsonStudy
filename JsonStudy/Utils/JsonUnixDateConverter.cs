using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonStudy.Utils
{
    public class JsonUnixDateConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (long.TryParse(Convert.ToString(reader.Value), out long Value))
            {
                return DateTimeOffset.FromUnixTimeSeconds(Value).ToLocalTime().DateTime;
            }

            if (objectType == typeof(DateTime))
            {
                return default(DateTime);
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var val = new DateTimeOffset((DateTime)value).ToUniversalTime().ToUnixTimeSeconds();
            writer.WriteValue(val);
        }
    }
}
