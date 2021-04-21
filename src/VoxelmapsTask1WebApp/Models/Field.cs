using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoxelmapsTask1WebApp.Models
{
    public class Field
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("sqlType")]
        public string SqlType { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("domain")]
        public object Domain { get; set; }

        [JsonProperty("defaultValue")]
        public object DefaultValue { get; set; }
    }

}
