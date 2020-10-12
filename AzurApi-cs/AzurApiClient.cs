using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public AzurShip[] Ships { get; internal set; } = null;

        internal async Task<JObject> GetRequest(string url)
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

        public async Task<AzurRequest> DownloadShips()
        {
            JObject Json = await GetRequest("https://raw.githubusercontent.com/AzurAPI/azurapi-js-setup/master/ships.json");
            if (Json.ContainsKey("success"))
                return Json.ToObject<AzurRequest>();
            Ships = Json.ToObject<AzurShip[]>();
            return new AzurRequest
            {
                success = true
            };
        }

        public AzurShip GetShipById(string id)
        {
            return Ships.FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<AzurShip> GetShipsByName(string name)
        {
            return Ships.Where(x => x.names.en.ToLower().Contains(name.ToLower()));
        }
    }
}
