using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AzurApi
{
    public class AzurApiClient
    {
        public AzurApiClient()
        {
            Http = new HttpClient();
        }
        public readonly HttpClient Http;
        




        internal async Task<AzurRequest> GetRequest(string url)
        {
            HttpResponseMessage Message = null;
            try
            {
                Message = await Http.GetAsync(url);
                return new AzurRequest
                {
                    success = true,
                    code = 200
                };
            }
            catch (HttpRequestException hex)
            {
                return new AzurRequest
                {
                    success = false,
                    code = (int)Message.StatusCode,
                    error = Message.ReasonPhrase ?? hex.Message
                };
            }
            catch (Exception ex)
            {
                return new AzurRequest
                {
                    success = false,
                    code = 0,
                    error = $"AzurApi-cs lib error, {ex.Message}"
                };
            }
        }

        internal async Task<JObject> GetCustomRequest(string url)
        {
            HttpResponseMessage Message = null;
            try
            {
                Message = await Http.GetAsync(url);
                string Content = await Message.Content.ReadAsStringAsync();
                return JObject.Parse(Content);
            }
            catch (HttpRequestException hex)
            {
                return JObject.FromObject(new AzurRequest
                {
                    success = false,
                    code = (int)Message.StatusCode,
                    error = Message.ReasonPhrase ?? hex.Message
                });
            }
            catch (Exception ex)
            {
                return JObject.FromObject(new AzurRequest
                {
                    success = false,
                    code = 0,
                    error = $"AzurApi-cs lib error, {ex.Message}"
                });
            }
        }

    }
}
