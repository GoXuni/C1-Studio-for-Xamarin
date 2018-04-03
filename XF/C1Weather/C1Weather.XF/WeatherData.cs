using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using C1.CollectionView;

namespace C1Weather
{
    class WeatherData
    {
        //changes langauge and units based on device settings
        private static String GetUrlStringForSupportedCountry(string location)
        {
            String url;
            //sign up for a key at http://openweathermap.org/appid
            //Example key
            String appId = "&APPID=a0a0e5e6d1ded0c79e853990c86f957b";

            if (System.Globalization.CultureInfo.CurrentCulture.ToString() == "en-US")
            {
                url = string.Format("http://api.openweathermap.org/data/2.5/forecast?zip={0}&units=imperial&lang=en" + appId, location);
            }
            else if (System.Globalization.CultureInfo.CurrentCulture.ToString() == "ja-JP")
            {
                if (location.Contains(","))
                {
                    url = string.Format("http://api.openweathermap.org/data/2.5/forecast?zip={0}&units=metric&lang=ja" + appId, location);
                }
                else
                {
                    url = string.Format("http://api.openweathermap.org/data/2.5/forecast?zip={0},jp&units=metric&lang=ja" + appId, location);
                }
            }
            else if (System.Globalization.CultureInfo.CurrentCulture.ToString() == "zh-CHS")
            {
                if (location.Contains(","))
                {
                    url = string.Format("http://api.openweathermap.org/data/2.5/forecast?zip={0}&units=metric&lang=zh_cn" + appId, location);
                }
                else
                {
                    url = string.Format("http://api.openweathermap.org/data/2.5/forecast?zip={0},zh&units=metric&lang=zh_cn" + appId, location);
                }
            }
            else if (System.Globalization.CultureInfo.CurrentCulture.ToString() == "ko-KR")
            {
                if (location.Contains(","))
                {
                    url = string.Format("http://api.openweathermap.org/data/2.5/forecast?zip={0}&units=metric&lang=kr" + appId, location);
                }
                else
                {
                    url = string.Format("http://api.openweathermap.org/data/2.5/forecast?zip={0},ko&units=metric&lang=kr" + appId, location);
                }
            }
            else
            {
                url = string.Format("http://api.openweathermap.org/data/2.5/forecast?zip={0}&units=metric" + appId, location);
            }
            return url;
        }
        public async Task<Tuple<ObservableCollection<WeatherModel>, String>> GetResult(string zip)
        {
            zip = zip.Replace(" ", String.Empty);
            if(zip == null)
            {
                zip = "15232";
            }
            String url = GetUrlStringForSupportedCountry(zip);
            return await GetWeather(url);
        }
        private static async Task<Tuple<ObservableCollection<WeatherModel>, String>> GetWeather(string url)
        {
            
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                ObservableCollection<WeatherModel> weatherList = new ObservableCollection<WeatherModel>();
                string content = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<WeatherResult>(content);
                WeatherModel model;
                foreach (var item in data.list)
                {
                    model = new WeatherModel();
                    model.date = Convert.ToDateTime(item.dt_txt);
                    model.humidity = item.main.humidity;
                    model.pressure = item.main.pressure;
                    model.description = item.weather[0].description;
                    model.lowtemp = item.main.temp_min;
                    model.hightemp = item.main.temp_max;
                    model.icon = ("http://openweathermap.org/img/w/" + item.weather[0].icon + ".png");
                    weatherList.Add(model);
                }
                return new Tuple<ObservableCollection<WeatherModel>, String>(new ObservableCollection<WeatherModel>(weatherList), data.city.name + " " + data.city.country);
                //return new C1CollectionView<WeatherModel>(weatherList);
            }
            else
            {
                string content = await response.Content.ReadAsStringAsync();
                WeatherError errorData = JsonConvert.DeserializeObject<WeatherError>(content);
                //throw new Exception(await response.Content.ReadAsStringAsync());
                throw new Exception(errorData.COD + " "  + errorData.Message);
            }
        }
    }
    public class WeatherError
    {
        public string COD { get; set; }
        public string Message { get; set; }
    }
    public class WeatherResult
    {
        public City city { get; set; }
        public int cod { get; set; }
        public double message { get; set; }
        public int cnt { get; set; }
        public List<WeatherList> list { get; set; }
    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }
    public class Sys
    {
        public int population { get; set; }
    }
    public class OtherSys
    {
        public string pod { get; set; }
    }
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
    }
    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
    public class Clouds
    {
        public int all { get; set; }
    }
    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }
    public class Rain
    {
        public double? amount { get; set; }
    }
    public class WeatherList
    {
        public int dt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Rain rain { get; set; }
        public Wind wind { get; set; }
        public OtherSys sys { get; set; }
        public string dt_txt { get; set; }
    }
    public class Main
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }
        public int humidity { get; set; }
        public double temp_kf { get; set; }
    }
}

