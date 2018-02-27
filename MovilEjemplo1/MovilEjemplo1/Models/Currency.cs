// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using MovilEjemplo1.Models;
//
//    var land = Land.FromJson(jsonString);

namespace MovilEjemplo1.Models
{
    using System;
    using Newtonsoft.Json;
    public partial class Currency
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}
