using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json.Linq;
using Silverstone_WeatherInfo_Application.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Silverstone_WeatherInfo_Application.DataParsers
{
    public class DataParser
    {
        public static WeatherInfo DeserializeToWeatherInfoObject(string json)
        {
            WeatherInfo weatherInfo = new WeatherInfo();
            
            var result = JObject.Parse(json);
            weatherInfo.Name = (string)result.SelectToken("location.name");
            weatherInfo.CurrentTemp = (decimal)result.SelectToken("current.temp_c");
            weatherInfo.MaxTemp = (decimal)result.SelectToken("forecast.forecastday[0].day.maxtemp_c");
            weatherInfo.MinTemp = (decimal)result.SelectToken("forecast.forecastday[0].day.mintemp_c");
            weatherInfo.Humidity = (int)result.SelectToken("current.humidity");
            weatherInfo.Sunrise = (string)result.SelectToken("forecast.forecastday[0].astro.sunrise");
            weatherInfo.Sunset = (string)result.SelectToken("forecast.forecastday[0].astro.sunset");

            return weatherInfo;
        }

        public static string DeserializeForErrorMessage(string json)
        {
            var result = JObject.Parse(json);

            return (string)result.SelectToken("error.message");
        }
    }
}