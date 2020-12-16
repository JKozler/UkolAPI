using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace APIdata.Model
{
    public class AllCurentObjects
    {
        public ObservableCollection<Telesa> AllObjects { get; set; }
        public AllCurentObjects()
        {
        }

        public async Task GetFromAPI()
        {
            HttpClient http = new HttpClient();
            try
            {
                DateTime dt = DateTime.Now;
                DateTime dt2 = dt.AddDays(-1);
                string url = "https://api.nasa.gov/neo/rest/v1/feed?start_date=" + dt2.ToString("yyyy-MM-dd") + "&end_date=" + dt.ToString("yyyy-MM-dd") + "&api_key=d5m1LesAjClwYjHv5pDC572UnkZOhKls0jOomejg";
                HttpResponseMessage response = await http.GetAsync(url, HttpCompletionOption.ResponseContentRead);
                string res = await response.Content.ReadAsStringAsync();
                var content = JsonConvert.DeserializeObject<dynamic>(res);

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
