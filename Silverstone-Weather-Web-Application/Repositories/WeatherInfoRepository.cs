using Silverstone_WeatherInfo_Application.DataParsers;
using Silverstone_WeatherInfo_Application.Interfaces;
using Silverstone_WeatherInfo_Application.Models;

namespace Silverstone_WeatherInfo_Application.Repository
{
    public class WeatherInfoRepository : IWeatherInfoRepository
    {
        private readonly IConfiguration _configuration;
        private static HttpClient client = new HttpClient();

        public WeatherInfoRepository(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }
        public WeatherInfo GetWeatherInformation(string location)
        {
            var apiKey = GetWeatherAPIKey();
            var weatherInfo = CallWeatherAPIForecastCall(location, apiKey);
            
            return weatherInfo;
        }

        private WeatherInfo CallWeatherAPIForecastCall(string location, string apiKey)
        {
            WeatherInfo weatherInfo = new WeatherInfo();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "http://api.weatherapi.com/v1/forecast.json?key=" + apiKey + "&q=" + location + "&days=1&aqi=no&alerts=no");
                var response = client.SendAsync(request).Result;
                string jsonResult = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    weatherInfo = DataParser.DeserializeToWeatherInfoObject(jsonResult);
                }
                else 
                {
                    weatherInfo.ErrorMessage = DataParser.DeserializeForErrorMessage(jsonResult);
                }
            }
            catch (Exception ex)
            {
                weatherInfo.ErrorMessage = ex.Message;

                return weatherInfo;
            }

            return weatherInfo;
        }

        private string GetWeatherAPIKey()
        {
            var authKey = _configuration.GetValue<string>("AuthKey");

            return authKey;
        }
    }
}