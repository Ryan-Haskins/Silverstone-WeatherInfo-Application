using Microsoft.AspNetCore.Mvc;
using Silverstone_WeatherInfo_Application.Helpers;
using Silverstone_WeatherInfo_Application.Interfaces;
using Silverstone_WeatherInfo_Application.Models;
using System.Diagnostics;

namespace Silverstone_WeatherInfo_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherInfoRepository _weatherInfoRepository;

        public HomeController(IWeatherInfoRepository WeatherInfoRepository)
        {
            _weatherInfoRepository = WeatherInfoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetWeatherInfo(string location)
        {
            WeatherInfo weatherInfo = _weatherInfoRepository.GetWeatherInformation(location);

            if (String.IsNullOrEmpty(weatherInfo.ErrorMessage))
            {
                return RedirectToAction("WeatherData", "Home", weatherInfo);
            }

            weatherInfo.ErrorMessage = ErrorMessageHelpers.CheckErrorMessageFormatting(weatherInfo.ErrorMessage);

            return RedirectToAction("FailedWeatherAPICall", "Home", weatherInfo);
        }

        public IActionResult WeatherData(WeatherInfo weatherInfo)
        {
            return View(weatherInfo);
        }

        public IActionResult FailedWeatherAPICall(WeatherInfo weatherInfo)
        {
            
            return View(weatherInfo);
        }
    }
}