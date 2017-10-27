using JsonStudy.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonStudy.Models
{
    public class Class_Time
    {
        [JsonProperty("time"), JsonConverter(typeof(JsonUnixDateConverter))]
        public DateTime? Time { get; set; }

        [JsonProperty("__class__")]
        public string Class { get; set; }
    }

    public class ServerResponse_UpdateTime
    {
        [JsonProperty("responseData")]
        public Class_Time ResponseData { get; set; }

        [JsonProperty("requestClass")]
        public string RequestClass { get; set; }

        [JsonProperty("requestMethod")]
        public string RequestMethod { get; set; }

        [JsonProperty("requestId")]
        public int RequestId { get; set; }

        [JsonProperty("__class__")]
        public string Class { get; set; }
    }
}
