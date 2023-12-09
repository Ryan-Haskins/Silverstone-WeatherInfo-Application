using Silverstone_WeatherInfo_Application.Models;

namespace Silverstone_WeatherInfo_Application.Interfaces
{
    public interface IWeatherInfoRepository
    {
        WeatherInfo GetWeatherInformation(string location);
    }
}