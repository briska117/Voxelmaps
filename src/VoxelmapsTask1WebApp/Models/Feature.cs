using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoxelmapsTask1WebApp.Models
{
    public class Feature
    {
        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }
}
