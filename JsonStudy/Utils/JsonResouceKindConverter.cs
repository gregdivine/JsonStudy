using JsonStudy.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonStudy.Utils
{
    public class JsonResouceKindConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IResourceKind);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            List<File> results = null;

            // Are there mulip[le results?
            if (reader.TokenType == JsonToken.StartArray)
            {
                // Retrieve a list of Json objects
                var jObjs = serializer.Deserialize<IList<JObject>>(reader);
                if (jObjs != null && jObjs.Count > 0)
                {
                    results = new List<File>();

                    for (int i = 0; i < jObjs.Count; i++)
                    {
                        ProcessFileType(results, jObjs, i);
                    }
                }
            }
            return results;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }


        // only some types are lists for briefity
        private readonly Dictionary<string, Func<JObject, File>> mimeTypes
            = new Dictionary<string, Func<JObject, File>>
            {
                { "application/vnd.google-apps.folder", Convert<Folder>() },
                { "image/jpeg", Convert<JpgImage>() },
                { "image/png", Convert<PngImage>() },
                { "application/zip", Convert<Zipped>() },
                { "application/x-zip-compressed", Convert<Zipped>() },
                { "video/mp4", Convert<Mp4Video>() },
                { "text/plain", Convert<TxtDocument>() },
                { "application/vnd.openxmlformats-officedocument.presentationml.presentation", Convert<PptDocument>() },
                { "application/vnd.openxmlformats-officedocument.wordprocessingml.document", Convert<WordDocument>() }
            };

        // Convert file of type.... mimeTypes
        private void ProcessFileType(List<File> results, IList<JObject> jObjs, int i)
        {
            var fileToken = jObjs[i].SelectToken("mimeType");
            if (fileToken != null)
            {
                var key = mimeTypes.Keys.FirstOrDefault(x => x.Equals(fileToken.ToString()));
                if (key != null)
                {
                    results.Add(mimeTypes[key](jObjs[i]));
                }
            }
        }

        // Convert Json Object data into a specified class type
        private static Func<JObject, File> Convert<TModel>() where TModel : File
        {
            return (jObj) => JsonHelper.ToClass<TModel>(jObj.ToString());
        }
    }
}
