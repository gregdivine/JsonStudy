using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonStudy.Models
{
    public class Params
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }
    }

    public class Pagination
    {
        [JsonProperty("effective_limit")]
        public int? EffectiveLimit { get; set; }

        [JsonProperty("effective_offset")]
        public int? EffectiveOffset { get; set; }

        [JsonProperty("effective_page")]
        public int? EffectivePage { get; set; }

        [JsonProperty("next_offset")]
        public int? NextOffset { get; set; }

        [JsonProperty("next_page")]
        public int? NextPage { get; set; }
    }

    public class Response<TModel> where TModel : class
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("results")]
        public IList<TModel> Results { get; set; }

        [JsonProperty("params")]
        public Params Params { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }


}
