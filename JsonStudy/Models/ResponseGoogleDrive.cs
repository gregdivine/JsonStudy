using JsonStudy.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonStudy.Models
{
    public class ResponseGoogleDrive
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("incompleteSearch")]
        public bool IncompleteSearch { get; set; }

        [JsonProperty("files"), JsonConverter(typeof(JsonResouceKindConverter))]
        public IList<File> Files { get; set; }
    }

    public class File : IResourceKind
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("mimeType")]
        public string MimeType { get; set; }
    }

    public class Folder : File
    {
    }

    public class TxtDocument : File
    {
    }

    public class WordDocument : File
    {
    }

    public class PngImage : File
    {
    }

    public class JpgImage : File
    {
    }

    public class Zipped : File
    {
    }

    public class Mp4Video : File
    {
    }

    public class PptDocument : File
    {
    }

}
