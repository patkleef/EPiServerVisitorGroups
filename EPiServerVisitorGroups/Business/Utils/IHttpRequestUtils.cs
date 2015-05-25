namespace EPiServerVisitorGroups.Business.Utils
{
    public interface IHttpRequestUtils
    {
        /// <summary>
        /// Do http request
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        string DoHttpRequest(string url);
    }
}