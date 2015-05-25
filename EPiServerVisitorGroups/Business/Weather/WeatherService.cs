using System;
using System.Linq;
using EPiServer;
using EPiServerVisitorGroups.Business.Utils;
using Newtonsoft.Json.Linq;

namespace EPiServerVisitorGroups.Business.Weather
{
    /// <summary>
    /// Weather service
    /// </summary>
    public class WeatherService : IWeatherService
    {
        private const double _kelvin = 273.15;
        private const string _weatherApiUrl = "http://api.openweathermap.org/data/2.5/weather";

        private readonly IHttpRequestUtils _httpRequestUtils = new HttpRequestUtils();

        /// <summary>
        /// Get current tempature
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public int GetCurrentTempature(double latitude, double longitude)
        {
            var url = new UrlBuilder(_weatherApiUrl);
            url.QueryCollection.Add("lat", latitude.ToString());
            url.QueryCollection.Add("lon", longitude.ToString());

            var json = _httpRequestUtils.DoHttpRequest(url.ToString());
            if (!string.IsNullOrEmpty(json))
            {
                var jsonObject = JObject.Parse(json);

                var tempature = 0.0;
                var result = jsonObject["main"].Children<JProperty>().FirstOrDefault(x => x.Name == "temp").Value.Value<string>();

                if (double.TryParse(result, out tempature))
                {
                    return Convert.ToInt32(tempature - _kelvin);
                }
            }
            return 0;
        }
    } 
}