using NUnit.Framework;
using Silverstone_WeatherInfo_Application.DataParsers;
using Silverstone_WeatherInfo_Application.Models;
using UnitTests.TestObjects;

namespace UnitTests
{
    public class DataParserTests
    {
        JsonTestObjects jsonTestObjects;

        [SetUp]
        public void Setup()
        {
            jsonTestObjects = new JsonTestObjects();
        }

        [Test]
        public void DeserializeToWeatherInfoObject_ConvertsValidJSONToWeatherInfoObject_ValidWeatherInfoNameCheck()
        {
            // Arrange
            var json = jsonTestObjects.getJsonForDeserialiseToWeatherInfoObjectTest();

            // Act
            WeatherInfo weatherInfo = DataParser.DeserializeToWeatherInfoObject(json);

            // Assert
            Assert.That(weatherInfo.Name, Is.EqualTo("Northampton"));
        }

        [Test]
        public void DeserializeToWeatherInfoObject_ConvertsValidJSONToWeatherInfoObject_ValidWeatherInfoCurrentTempCheck()
        {
            // Arrange
            var json = jsonTestObjects.getJsonForDeserialiseToWeatherInfoObjectTest();

            // Act
            WeatherInfo weatherInfo = DataParser.DeserializeToWeatherInfoObject(json);

            // Assert
            Assert.That(weatherInfo.CurrentTemp, Is.EqualTo(10));
        }

        [Test]
        public void DeserializeToWeatherInfoObject_ConvertsValidJSONToWeatherInfoObject_ValidWeatherInfoHumidityCheck()
        {
            // Arrange
            var json = jsonTestObjects.getJsonForDeserialiseToWeatherInfoObjectTest();

            // Act
            WeatherInfo weatherInfo = DataParser.DeserializeToWeatherInfoObject(json);

            // Assert
            Assert.That(weatherInfo.Humidity, Is.EqualTo(66));
        }

        [Test]
        public void DeserializeToWeatherInfoObject_ConvertsValidJSONToWeatherInfoObject_ValidWeatherInfoMaxTempCheck()
        {
            // Arrange
            var json = jsonTestObjects.getJsonForDeserialiseToWeatherInfoObjectTest();

            // Act
            WeatherInfo weatherInfo = DataParser.DeserializeToWeatherInfoObject(json);

            // Assert
            Assert.That(weatherInfo.MaxTemp, Is.EqualTo(11.9));
        }

        [Test]
        public void DeserializeToWeatherInfoObject_ConvertsValidJSONToWeatherInfoObject_ValidWeatherInfoMinTempCheck()
        {
            // Arrange
            var json = jsonTestObjects.getJsonForDeserialiseToWeatherInfoObjectTest();

            // Act
            WeatherInfo weatherInfo = DataParser.DeserializeToWeatherInfoObject(json);

            // Assert
            Assert.That(weatherInfo.MinTemp, Is.EqualTo(5.8));
        }

        [Test]
        public void DeserializeToWeatherInfoObject_ConvertsValidJSONToWeatherInfoObject_ValidWeatherInfoSunriseCheck()
        {
            // Arrange
            var json = jsonTestObjects.getJsonForDeserialiseToWeatherInfoObjectTest();

            // Act
            WeatherInfo weatherInfo = DataParser.DeserializeToWeatherInfoObject(json);

            // Assert
            Assert.That(weatherInfo.Sunrise, Is.EqualTo("08:00 AM"));
        }

        [Test]
        public void DeserializeToWeatherInfoObject_ConvertsValidJSONToWeatherInfoObject_ValidWeatherInfoSunsetCheck()
        {
            // Arrange
            var json = jsonTestObjects.getJsonForDeserialiseToWeatherInfoObjectTest();

            // Act
            WeatherInfo weatherInfo = DataParser.DeserializeToWeatherInfoObject(json);

            // Assert
            Assert.That(weatherInfo.Sunset, Is.EqualTo("03:51 PM"));
        }

        [Test]
        public void DeserializeToWeatherInfoObject_ConvertsValidJSONToWeatherInfoObject_ValidWeatherInfoErrorMessageCheck()
        {
            // Arrange
            var json = jsonTestObjects.getJsonForDeserialiseToWeatherInfoObjectTest();

            // Act
            WeatherInfo weatherInfo = DataParser.DeserializeToWeatherInfoObject(json);

            // Assert
            Assert.That(weatherInfo.ErrorMessage, Is.Null);
        }

        [Test]
        public void DeserializeToErrorMessage_ConvertsValidJSONToErrorMessageString_ValidErrorMessageCheck()
        {
            // Arrange
            var json = jsonTestObjects.getJsonForDeserialiseErrorMessageTest();

            // Act
            string errorMessage = DataParser.DeserializeForErrorMessage(json);

            // Assert
            Assert.That(errorMessage, Is.EqualTo("Parameter q is missing."));
        }
    }
}