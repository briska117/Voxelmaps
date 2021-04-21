using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoxelmapsTask1WebApp.Models
{
    public class UniqueIdField
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isSystemMaintained")]
        public bool IsSystemMaintained { get; set; }
    }
}
