using System.Security.Principal;
using System.Web;
using EPiServer.Personalization.VisitorGroups;
using EPiServerVisitorGroups.Business.Geo;
using EPiServerVisitorGroups.Business.Weather;

namespace EPiServerVisitorGroups.Business.Personalization
{
    [VisitorGroupCriterion(
        Category = "Weather",
        DisplayName = "Current weather",
        Description = "Check the user current weather location")]
    public class WeatherVisitorCriterion : CriterionBase<Weather1CriterionSettings>
    {
        private readonly IWeatherService _weatherService = new WeatherService();
        private readonly IGeoService _geoService = new GeoService();

        /// <summary>
        /// Is match method
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public override bool IsMatch(IPrincipal principal, HttpContextBase httpContext)
        {
            var ipAddress = GetUserIPAddress(httpContext);

            var geo = _geoService.GetGeoByIp(ipAddress);
            if (geo.Latitude > 0 && geo.Longitude > 0)
            {
                var tempature = _weatherService.GetCurrentTempature(geo.Latitude, geo.Longitude);
                return tempature >= Model.MinTempature && tempature <= Model.MaxTempature;
            }
            return false;
        }

        /// <summary>
        /// Get user IP address
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetUserIPAddress(HttpContextBase context)
        {
            if (context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                return context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (context.Request.UserHostAddress.Length != 0)
            {
                return context.Request.UserHostAddress;
            }
            return string.Empty;
        }
    }
}