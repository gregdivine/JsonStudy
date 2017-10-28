using JsonStudy.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonStudy.Utils
{
    public class JsonDataTypeConverter : JsonConverter
    {
        // destination data type
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IDataType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            List<IDataType> results = null;

            // Are there mulip[le results?
            if (reader.TokenType == JsonToken.StartArray)
            {
                // Retrieve a list of Json objects
                var jObjs = serializer.Deserialize<IList<JObject>>(reader);
                if (jObjs != null && jObjs.Count > 0)
                {
                    results = new List<IDataType>();

                    for (int i = 0; i < jObjs.Count; i++)
                    {
                        var token = jObjs[i].SelectToken("media_type");
                        if (token != null)
                        {
                            switch (token.ToString())
                            {
                                // "media_type": "tv"
                                case "tv":
                                    results.Add(Convert<TV>(jObjs[i]));
                                    break;
                                // "media_type": "movie"
                                case "movie":
                                    results.Add(Convert<Movie>(jObjs[i]));
                                    break;
                                // "media_type": "person"
                                case "person":
                                    results.Add(Convert<Person>(jObjs[i]));
                                    break;
                            }
                        }
                    }
                }
            }
            return results;
        }

        // Convert Json Object data into a specified class type
        private TModel Convert<TModel>(JObject jObj) where TModel : IDataType
        {
            return JsonHelper.ToClass<TModel>(jObj.ToString());
        }

        // one way conversion, so back to Json is not required
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
