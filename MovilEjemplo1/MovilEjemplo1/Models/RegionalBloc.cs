
namespace MovilEjemplo1.Models
{
    using System;
    using Newtonsoft.Json;
    public partial class RegionalBloc
    {
        [JsonProperty("acronym")]
        public string Acronym { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("otherAcronyms")]
        public object[] OtherAcronyms { get; set; }

        [JsonProperty("otherNames")]
        public object[] OtherNames { get; set; }
    }
}
