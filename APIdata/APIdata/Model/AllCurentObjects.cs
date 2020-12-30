using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace APIdata.Model
{
    public class AllCurentObjects
    {
        public ObservableCollection<Telesa> AllObjects { get; set; }
        public AllCurentObjects()
        {
            AllObjects = new ObservableCollection<Telesa>();
            GetFromAPI();
        }

        public async Task GetFromAPI()
        {
            HttpClient http = new HttpClient();
            DateTime dt = DateTime.Now;
            DateTime dt2 = dt.AddDays(-1);
            try
            {
                string url = "https://api.nasa.gov/neo/rest/v1/feed?start_date=" + dt2.ToString("yyyy-MM-dd") + "&end_date=" + dt.ToString("yyyy-MM-dd") + "&api_key=d5m1LesAjClwYjHv5pDC572UnkZOhKls0jOomejg";
                HttpResponseMessage response = await http.GetAsync(url, HttpCompletionOption.ResponseContentRead);
                string res = await response.Content.ReadAsStringAsync();
                var content = JsonConvert.DeserializeObject<dynamic>(res);
                JObject jo = JObject.Parse(res);
                Stream stream = new FileStream("lastObject.txt", FileMode.Create);
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    sw.WriteLine(res);
                }
                for (int i = 0; i < 13; i++)
                {
                    Telesa tl = new Telesa();
                    tl.Name = Convert.ToString(jo["near_earth_objects"][dt2.ToString("yyyy-MM-dd")][i]["name"]);
                    tl.IsDangerous = Convert.ToBoolean(jo["near_earth_objects"][dt2.ToString("yyyy-MM-dd")][i]["is_potentially_hazardous_asteroid"]);
                    tl.KMPerHour = Convert.ToDouble(jo["near_earth_objects"][dt2.ToString("yyyy-MM-dd")][i]["close_approach_data"][0]["relative_velocity"]["kilometers_per_hour"]);
                    tl.MissDistance = Convert.ToDouble(jo["near_earth_objects"][dt2.ToString("yyyy-MM-dd")][i]["close_approach_data"][0]["miss_distance"]["kilometers"]);
                    tl.CloseApproachDate = Convert.ToDateTime(jo["near_earth_objects"][dt2.ToString("yyyy-MM-dd")][i]["close_approach_data"][0]["close_approach_date"]);
                    AllObjects.Add(tl);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                JObject jo = JObject.Parse(File.ReadAllText("lastObject.txt"));
                for (int i = 0; i < 13; i++)
                {
                    Telesa tl = new Telesa();
                    tl.Name = Convert.ToString(jo["near_earth_objects"][dt2.ToString("yyyy-MM-dd")][i]["name"]);
                    tl.IsDangerous = Convert.ToBoolean(jo["near_earth_objects"][dt2.ToString("yyyy-MM-dd")][i]["is_potentially_hazardous_asteroid"]);
                    tl.KMPerHour = Convert.ToDouble(jo["near_earth_objects"][dt2.ToString("yyyy-MM-dd")][i]["close_approach_data"][0]["relative_velocity"]["kilometers_per_hour"]);
                    tl.MissDistance = Convert.ToDouble(jo["near_earth_objects"][dt2.ToString("yyyy-MM-dd")][i]["close_approach_data"][0]["miss_distance"]["kilometers"]);
                    tl.CloseApproachDate = Convert.ToDateTime(jo["near_earth_objects"][dt2.ToString("yyyy-MM-dd")][i]["close_approach_data"][0]["close_approach_date"]);
                    AllObjects.Add(tl);
                }
            }
        }
    }
}

