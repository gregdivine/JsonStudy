using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonStudy.Models
{
    public class Category
    {

        [JsonProperty("category_id")]
        public int CategoryId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("meta_title")]
        public string MetaTitle { get; set; }

        [JsonProperty("meta_keywords")]
        public string MetaKeywords { get; set; }

        [JsonProperty("meta_description")]
        public string MetaDescription { get; set; }

        [JsonProperty("page_description")]
        public string PageDescription { get; set; }

        [JsonProperty("page_title")]
        public string PageTitle { get; set; }

        [JsonProperty("category_name")]
        public string CategoryName { get; set; }

        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("long_name")]
        public string LongName { get; set; }

        [JsonProperty("num_children")]
        public int NumChildren { get; set; }
    }

    
}
