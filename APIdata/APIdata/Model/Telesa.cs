using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace APIdata.Model
{
    public class Telesa
    {
        public string Name { get; set; }
        public DateTime CloseApproachDate { get; set; }
        public double KMPerHour { get; set; }
        public double MissDistance { get; set; }
        public bool IsDangerous { get; set; }
    }
}
