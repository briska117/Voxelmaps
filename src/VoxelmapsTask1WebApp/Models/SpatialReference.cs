using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoxelmapsTask1WebApp.Models
{
    public class SpatialReference
    {
        [JsonProperty("wkid")]
        public int Wkid { get; set; }

        [JsonProperty("latestWkid")]
        public int LatestWkid { get; set; }
    }
}
