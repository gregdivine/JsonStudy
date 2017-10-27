using JsonStudy.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonStudy.Models
{
    public class Note
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("authorname")]
        public string Authorname { get; set; }

        [JsonProperty("authorrealname")]
        public string Authorrealname { get; set; }

        [JsonProperty("authorispro")]
        public int Authorispro { get; set; }

        [JsonProperty("x")]
        public string X { get; set; }

        [JsonProperty("y")]
        public string Y { get; set; }

        [JsonProperty("w")]
        public string W { get; set; }

        [JsonProperty("h")]
        public string H { get; set; }

        [JsonProperty("_content")]
        public string Content { get; set; }
    }

    public class Photo
    {
        [JsonProperty("notes"), JsonConverter(typeof(JsonFlickrCollectionConverter<Note>))]
        public IList<Note> Notes { get; set; }
    }


}
