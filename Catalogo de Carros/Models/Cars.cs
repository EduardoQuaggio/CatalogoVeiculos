using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace Catalogo_de_Carros.Models
{
    public class Car
    {
        [JsonProperty("city_mpg")]
        public long CityMpg { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("combination_mpg")]
        public long CombinationMpg { get; set; }

        [JsonProperty("cylinders")]
        public long Cylinders { get; set; }

        [JsonProperty("displacement")]
        public double Displacement { get; set; }

        [JsonProperty("drive")]
        public string Drive { get; set; }

        [JsonProperty("fuel_type")]
        public string FuelType { get; set; }

        [JsonProperty("highway_mpg")]
        public long HighwayMpg { get; set; }

        [JsonProperty("make")]
        public string Make { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("transmission")]
        public string Transmission { get; set; }

        [JsonProperty("year")]
        public long Year { get; set; }

        [JsonIgnore]
        public string Image { get; set; }

        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public bool Favorite { get; set; }
    }
}
