namespace Silverstone_WeatherInfo_Application.Models
{
    public class WeatherInfo
    {
        public String? Name { get; set; }
        public decimal? CurrentTemp { get; set; }
        public decimal? MinTemp { get; set; }
        public decimal? MaxTemp { get; set; }
        public int? Humidity { get; set; }
        public string? Sunrise { get; set; }
        public string? Sunset { get; set; }
        public string? ErrorMessage { get; set; }
    }
}