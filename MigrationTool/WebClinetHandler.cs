using Microsoft.VisualBasic;
using MigrationTool.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MigrationTool
{
    public class WebClinetHandler
    {
        private static string _sqlSaveUrl = ConfigurationManager.AppSettings["SqlDataSaveUrl"].ToString().Trim();
        private static string _mongoDataSaveUrl = ConfigurationManager.AppSettings["MongoDataSaveUrl"].ToString().Trim();
        private static string _accessToen;
        HttpResponseMessage _httpResponse;
        HttpRequestMessage _httpRequest;
        HttpClient _httpClient;
        public WebClinetHandler(string AccessToken)
        {
            _accessToen = AccessToken;
        }

        public async Task<SqlDataSaveResponsetDTO> SaveSqlData(SqlDataSaveRequestDTO requestDTO, string fromFileName)
        {
            SqlDataSaveResponsetDTO _responsetDTO = null;
            try

            {
                _httpClient = new HttpClient();
                _httpRequest = new HttpRequestMessage(HttpMethod.Post, _sqlSaveUrl);


                var jObjectbody = Newtonsoft.Json.JsonConvert.SerializeObject(requestDTO);

                var stringContent = new StringContent(jObjectbody, Encoding.UTF8, "application/json");
                _httpRequest.Content = stringContent;

                List<NameValueHeaderValue> headerValues = new List<NameValueHeaderValue>();
                headerValues.Add(new NameValueHeaderValue("Encoding", "utf-8"));
                headerValues.Add(new NameValueHeaderValue("user-agent", "x-machine"));
                headerValues.Add(new NameValueHeaderValue("token_type", "Bearer"));
                headerValues.Add(new NameValueHeaderValue("access_token", _accessToen));
                headerValues.Add(new NameValueHeaderValue("X-Account-Id", "a781caf8-9369-43ec-80b2-08dc0c5a98eb"));
                headerValues.Add(new NameValueHeaderValue("X-Correlation-Id", "1512aee6-a558-4dfc-92a3-474007dc234e"));
                headerValues.Add(new NameValueHeaderValue("X-Tenant-Id", "9d8db373-3527-4f64-9c9a-08dc1f259ab8"));
                headerValues.Add(new NameValueHeaderValue("X-Workspace-Id", "41fecee1-8622-4745-77a4-08dc2d64ddca"));


                foreach (var headerValue in headerValues)
                {
                    _httpRequest.Headers.Add(headerValue.Name, headerValue.Value);
                }
                _httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToen);

                _httpResponse = await _httpClient.SendAsync(_httpRequest);
                if (_httpResponse.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    string responseBody = await _httpResponse.Content.ReadAsStringAsync();
                    _responsetDTO = JsonConvert.DeserializeObject<SqlDataSaveResponsetDTO>(responseBody);
                }
                else
                {
                    Logger.WriteException("Failed storing data in SQL for " + fromFileName + " StatusCode: " + _httpResponse.StatusCode + " ReasonPhrase: " + _httpResponse.ReasonPhrase);

                }
            }
            catch (Exception ex)
            {
                Logger.WriteException("Failed storing data in SQL for " + fromFileName + ex.Message);
            }

            return _responsetDTO;
        }


        public async Task<MongoDBDataSaveDataResponseDTO> SaveMongoDBData(MongoDBDataSaveRequestDTO requestDTO, string fromFileName)
        {
            MongoDBDataSaveDataResponseDTO _responsetDTO = null;
            try
            {
                _httpClient = new HttpClient();
                _httpRequest = new HttpRequestMessage(HttpMethod.Post, _mongoDataSaveUrl);



                var jObjectbody = Newtonsoft.Json.JsonConvert.SerializeObject(requestDTO);

                var stringContent = new StringContent(jObjectbody, Encoding.UTF8, "application/json");
                _httpRequest.Content = stringContent;

                List<NameValueHeaderValue> headerValues = new List<NameValueHeaderValue>();
                headerValues.Add(new NameValueHeaderValue("Encoding", "utf-8"));
                headerValues.Add(new NameValueHeaderValue("user-agent", "x-machine"));
                headerValues.Add(new NameValueHeaderValue("token_type", "Bearer"));
                headerValues.Add(new NameValueHeaderValue("access_token", _accessToen));


                foreach (var headerValue in headerValues)
                {
                    _httpRequest.Headers.Add(headerValue.Name, headerValue.Value);
                }

                _httpResponse = await _httpClient.SendAsync(_httpRequest);

                if (_httpResponse.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    string responseBody = await _httpResponse.Content.ReadAsStringAsync();
                    _responsetDTO = JsonConvert.DeserializeObject<MongoDBDataSaveDataResponseDTO>(responseBody);
                }
                else
                {
                    Logger.WriteException("Failed storing data in No SQL for " + fromFileName + " StatusCode: " + _httpResponse.StatusCode + " ReasonPhrase: " + _httpResponse.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException("Failed storing data in No SQL for " + fromFileName + ex.Message);
            }

            return _responsetDTO;
        }
    }
}
