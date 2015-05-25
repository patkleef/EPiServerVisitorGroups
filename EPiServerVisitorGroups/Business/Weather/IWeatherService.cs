namespace EPiServerVisitorGroups.Business.Weather
{
    public interface IWeatherService
    {
        int GetCurrentTempature(double latitude, double longitude);
    }
}