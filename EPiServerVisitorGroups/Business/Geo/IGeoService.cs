namespace EPiServerVisitorGroups.Business.Geo
{
    public interface IGeoService
    {
        GeoCoordinates GetGeoByIp(string ip);
    }
}