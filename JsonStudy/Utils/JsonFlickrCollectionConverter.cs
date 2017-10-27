using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonStudy.Utils
{
    public class JsonFlickrCollectionConverter<TModel> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TModel);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // A collection type containing only a collection of type
            // eg: "urls": { "url": [{...}, {...}, ...] }
            if (reader.TokenType == JsonToken.StartObject)
            {
                var jObj = JObject.Load(reader);
                if (jObj.HasValues)
                {
                    var items = new List<TModel>();
                    foreach (var value in jObj.Values())
                    {
                        try
                        {
                            items.AddRange(JsonHelper.ToClass<IList<TModel>>(value.ToString()));
                        }
                        catch (Exception)
                        {

                            // unexpected type

                            return null;
                        }
                    }
                    return items;
                }
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
