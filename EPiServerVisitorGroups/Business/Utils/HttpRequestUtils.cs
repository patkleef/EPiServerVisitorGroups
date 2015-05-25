using System.IO;
using System.Net;

namespace EPiServerVisitorGroups.Business.Utils
{
    /// <summary>
    /// Http request utils
    /// </summary>
    public class HttpRequestUtils : IHttpRequestUtils
    {
        /// <summary>
        /// Do http request
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string DoHttpRequest(string url)
        {
            var request = WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;

            WebResponse response = request.GetResponse();

            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(response.GetResponseStream());

            var json = reader.ReadToEnd();

            return json;
        }
    }
}