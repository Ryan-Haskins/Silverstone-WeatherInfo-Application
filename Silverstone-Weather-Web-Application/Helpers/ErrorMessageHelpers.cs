using Newtonsoft.Json.Linq;
using Silverstone_WeatherInfo_Application.Models;

namespace Silverstone_WeatherInfo_Application.Helpers
{
    public static class ErrorMessageHelpers
    {
        public static string CheckErrorMessageFormatting(string message)
        {
            if(message.Contains("q"))
            {
                return ConvertEmptyParameterError();
            }

            return message;
        }

        public static string ConvertEmptyParameterError()
        {
            return "A location is required. Please try again.";
        }
    }
}