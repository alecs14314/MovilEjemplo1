// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using MovilEjemplo1.Models;
//
//    var land = Land.FromJson(jsonString);

namespace MovilEjemplo1.Models
{
    using System;
    using Newtonsoft.Json;
    public partial class Language
    {
        [JsonProperty("iso639_1")]
        public string Iso6391 { get; set; }

        [JsonProperty("iso639_2")]
        public string Iso6392 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nativeName")]
        public string NativeName { get; set; }
    }
}
