using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoxelmapsTask1WebApp.Models
{
    public class CovidResponse
    {
        [JsonProperty("objectIdFieldName")]
        public string ObjectIdFieldName { get; set; }

        [JsonProperty("uniqueIdField")]
        public UniqueIdField UniqueIdField { get; set; }

        [JsonProperty("globalIdFieldName")]
        public string GlobalIdFieldName { get; set; }

        [JsonProperty("geometryType")]
        public string GeometryType { get; set; }

        [JsonProperty("spatialReference")]
        public SpatialReference SpatialReference { get; set; }

        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }

        [JsonProperty("features")]
        public List<Feature> Features { get; set; }
    }
}
