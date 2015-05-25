using EPiServer;
using EPiServerVisitorGroups.Business.Utils;
using Newtonsoft.Json.Linq;

namespace EPiServerVisitorGroups.Business.Geo
{
    /// <summary>
    /// Geo service
    /// </summary>
    public class GeoService : IGeoService
    {
        private const string _geoApiUrl = "http://freegeoip.net/json/{0}";
        private readonly IHttpRequestUtils _httpRequestUtils = new HttpRequestUtils();

        /// <summary>
        /// Get Geo coordinates by ip address
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public GeoCoordinates GetGeoByIp(string ip)
        {
            var geo = new GeoCoordinates();
            var url = new UrlBuilder(string.Format(_geoApiUrl, ip));

            var json = _httpRequestUtils.DoHttpRequest(url.ToString());

            if (!string.IsNullOrEmpty(json))
            {
                var jsonObject = JObject.Parse(json);

                var latitude = 0.0;
                var longitude = 0.0;
                if (double.TryParse(jsonObject["latitude"].Value<string>(), out latitude) &&
                    double.TryParse(jsonObject["longitude"].Value<string>(), out longitude))
                {
                    geo.Latitude = latitude;
                    geo.Longitude = longitude;
                }
            }
            return geo;
        }
    }
}