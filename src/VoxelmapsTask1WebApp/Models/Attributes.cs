using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoxelmapsTask1WebApp.Models
{
    public class Attributes
    {
        [JsonProperty("Country_Region")]
        public string CountryRegion { get; set; }

        [JsonProperty("Lat")]
        public double? Lat { get; set; }

        [JsonProperty("Long_")]
        public double? Long { get; set; }

        [JsonProperty("Confirmed")]
        public int Confirmed { get; set; }

        [JsonProperty("Deaths")]
        public int Deaths { get; set; }

        [JsonProperty("Recovered")]
        public int? Recovered { get; set; }

        [JsonProperty("UID")]
        public int UID { get; set; }

        [JsonProperty("ISO3")]
        public string ISO3 { get; set; }
    }
}
