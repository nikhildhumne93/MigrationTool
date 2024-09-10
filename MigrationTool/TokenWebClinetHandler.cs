using MigrationTool.DTOs;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http.Headers;
using System.Text;
namespace MigrationTool
{
    public class DataObject
    {
        public string Name { get; set; }
    }
    public class TokenWebClinetHandler
    {

        private static string _clientId = ConfigurationManager.AppSettings["ClientId"].ToString().Trim();
        private static string _clientSecret = ConfigurationManager.AppSettings["ClientSecret"].ToString().Trim();
        private static string _accessTokenUrl = ConfigurationManager.AppSettings["AccessTokenUrl"].ToString().Trim();
        HttpResponseMessage _httpResponse;
        HttpRequestMessage _httpRequest;
        HttpClient _httpClient;
        public async Task<GetTokenResponseDataDTO> GetAccessToken()
        {
            _httpClient = new HttpClient();
            _httpRequest = new HttpRequestMessage(HttpMethod.Post, _accessTokenUrl);

            GetTokenResponseDataDTO getTokenResponseDataDTO = null;

            try
            {
                var jObjectbody = Newtonsoft.Json.JsonConvert.SerializeObject(new GetTokenRequetDataDTO()
                {
                    ClientId = _clientId,
                    ClientSecret = _clientSecret
                });

                var stringContent = new StringContent(jObjectbody, Encoding.UTF8, "application/json");
                _httpRequest.Content = stringContent;

                List<NameValueHeaderValue> headerValues = new List<NameValueHeaderValue>();
                headerValues.Add(new NameValueHeaderValue("Encoding", "utf-8"));
                headerValues.Add(new NameValueHeaderValue("user-agent", "x-machine"));

                foreach (var headerValue in headerValues)
                {
                    _httpRequest.Headers.Add(headerValue.Name, headerValue.Value);
                }

                _httpResponse = await _httpClient.SendAsync(_httpRequest);
                if (_httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseBody = await _httpResponse.Content.ReadAsStringAsync();
                    getTokenResponseDataDTO = JsonConvert.DeserializeObject<GetTokenResponseDataDTO>(responseBody);
                }
                else
                {
                    Logger.WriteException("Get access token Exception StatusCode: " +  _httpResponse.StatusCode + " ReasonPhrase: " + _httpResponse.ReasonPhrase);

                }
            }
            catch (Exception ex)
            {
                Logger.WriteException("Get access token Exception " + ex.Message);
            }

            return getTokenResponseDataDTO;
        }
    }
}
