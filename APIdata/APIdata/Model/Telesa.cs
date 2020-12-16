using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace APIdata.Model
{
    public class Telesa
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("estimated_diameter_min")]
        public double Width { get; set; }

        [JsonProperty("estimated_diameter_max")]
        public double Height { get; set; }
        public double KMPerHour { get; set; }
        public double MissDistance { get; set; }
    }
}
