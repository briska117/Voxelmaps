using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IISI.Request
{
    public class RequestService : IRequestService
    {
        private readonly ILogger<RequestService> _logger;
        private readonly JsonSerializerSettings _serializerSettings;
        private Dictionary<string, string> headers = new Dictionary<string, string>();

        public RequestService(ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger<RequestService>();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = (IContractResolver)new CamelCasePropertyNamesContractResolver();
            serializerSettings.DateTimeZoneHandling = ((DateTimeZoneHandling)1);
            serializerSettings.NullValueHandling = ((NullValueHandling)1);
            this._serializerSettings = serializerSettings;
            ((ICollection<JsonConverter>)this._serializerSettings.Converters).Add((JsonConverter)new StringEnumConverter());
        }

        public async Task<TResult> GetAsync<TResult>(
          string uri,
          AuthenticationScheme authScheme = AuthenticationScheme.None,
          string token = "", ContentType contentType = ContentType.Json)
        {
            if (string.IsNullOrEmpty(uri))
                throw new ArgumentNullException(nameof(uri));
            this._logger.LogDebug("GET '{0}'", (object)uri);
            HttpClient httpClient = this.CreateHttpClient(authScheme, token);
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            await this.HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();
            this._logger.LogDebug("Response Data: {0}", (object)serialized);
            TResult result = await Task.Run<TResult>((Func<TResult>)(() => (TResult)JsonConvert.DeserializeObject<TResult>(serialized, this._serializerSettings)));
            return result;
        }

        public Task<TResult> PostAsync<TResult>(
          string uri,
          TResult data,
          AuthenticationScheme authScheme = AuthenticationScheme.None,
          string token = "", ContentType contentType = ContentType.Json)
        {
            return this.PostAsync<TResult, TResult>(uri, data, authScheme, token, contentType);
        }

        public async Task<TResult> PostAsync<TRequest, TResult>(
          string uri,
          TRequest data,
          AuthenticationScheme authScheme = AuthenticationScheme.None,
          string token = "", ContentType contentType = ContentType.Json)
        {
            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentNullException(nameof(uri));
            }
            this._logger.LogDebug("POST '{0}'", (object)uri);
            string serialized = "";

            if (contentType == ContentType.Json)
            {
                serialized = await Task.Run<string>((Func<string>)(() => JsonConvert.SerializeObject((object)(TRequest)data, this._serializerSettings)));
            }
            else
            {
                serialized = data.ToString();
            }
            this._logger.LogDebug("Request Data: {0}", (object)serialized);

            HttpClient httpClient = this.CreateHttpClient(authScheme, token, contentType);

            HttpResponseMessage response = await httpClient.PostAsync(uri, (HttpContent)new StringContent(serialized, Encoding.UTF8, "application/json"));
            await this.HandleResponse(response);
            string responseData = await response.Content.ReadAsStringAsync();
            this._logger.LogDebug("Response Data: {0}", (object)responseData);
            TResult result = await Task.Run<TResult>((Func<TResult>)(() => (TResult)JsonConvert.DeserializeObject<TResult>(responseData, this._serializerSettings)));
            return result;
        }

        public Task<TResult> PutAsync<TResult>(
          string uri,
          TResult data,
          AuthenticationScheme authScheme = AuthenticationScheme.None,
          string token = "", ContentType contentType = ContentType.Json)
        {
            return this.PutAsync<TResult, TResult>(uri, data, authScheme, token, contentType);
        }

        public async Task<TResult> PutAsync<TRequest, TResult>(
          string uri,
          TRequest data,
          AuthenticationScheme authScheme = AuthenticationScheme.None,
          string token = "", ContentType contentType = ContentType.Json)
        {
            if (string.IsNullOrEmpty(uri))
                throw new ArgumentNullException(nameof(uri));
            this._logger.LogDebug("PUT '{0}'", (object)uri);
            string serialized = await Task.Run<string>((Func<string>)(() => JsonConvert.SerializeObject((object)(TRequest)data, this._serializerSettings)));
            this._logger.LogDebug("Request Data: {0}", (object)serialized);
            HttpClient httpClient = this.CreateHttpClient(authScheme, token);
            HttpResponseMessage response = await httpClient.PutAsync(uri, (HttpContent)new StringContent(serialized, Encoding.UTF8, "application/json"));
            await this.HandleResponse(response);
            string responseData = await response.Content.ReadAsStringAsync();
            this._logger.LogDebug("Response Data: {0}", (object)responseData);
            TResult result = await Task.Run<TResult>((Func<TResult>)(() => (TResult)JsonConvert.DeserializeObject<TResult>(responseData, this._serializerSettings)));
            return result;
        }

        public Task<TResult> PatchAsync<TResult>(
          string uri,
          TResult data,
          AuthenticationScheme authScheme = AuthenticationScheme.None,
          string token = "", ContentType contentType = ContentType.Json)
        {
            return this.PatchAsync<TResult, TResult>(uri, data, authScheme, token, contentType);
        }

        public async Task<TResult> PatchAsync<TRequest, TResult>(
          string uri,
          TRequest data,
          AuthenticationScheme authScheme = AuthenticationScheme.None,
          string token = "", ContentType contentType = ContentType.Json)
        {
            if (string.IsNullOrEmpty(uri))
                throw new ArgumentNullException(nameof(uri));
            this._logger.LogDebug("PATCH '{0}'", (object)uri);
            string serialized = await Task.Run<string>((Func<string>)(() => JsonConvert.SerializeObject((object)(TRequest)data, this._serializerSettings)));
            this._logger.LogDebug("Request Data: {0}", (object)serialized);
            HttpClient httpClient = this.CreateHttpClient(authScheme, token);
            HttpMethod method = new HttpMethod("PATCH");
            HttpRequestMessage request = new HttpRequestMessage(method, uri)
            {
                Content = (HttpContent)new StringContent(serialized, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = await httpClient.SendAsync(request);
            await this.HandleResponse(response);
            string responseData = await response.Content.ReadAsStringAsync();
            this._logger.LogDebug("Response Data: {0}", (object)responseData);
            TResult result = await Task.Run<TResult>((Func<TResult>)(() => (TResult)JsonConvert.DeserializeObject<TResult>(responseData, this._serializerSettings)));
            return result;
        }

        private static bool IsEmail(string value)
        {
            return new EmailAddressAttribute().IsValid((object)value);
        }

        public async Task<TResult> DeleteAsync<TResult>(string uri, AuthenticationScheme authScheme = AuthenticationScheme.None, string token = "", ContentType contentType = ContentType.Json)
        {
            if (string.IsNullOrEmpty(uri))
                throw new ArgumentNullException(nameof(uri));
            this._logger.LogDebug("DELETE '{0}'", (object)uri);
            HttpClient httpClient = this.CreateHttpClient(authScheme, token);
            HttpMethod method = new HttpMethod("DELETE");
            HttpRequestMessage request = new HttpRequestMessage(method, uri)
            {

            };
            HttpResponseMessage response = await httpClient.SendAsync(request);
            await this.HandleResponse(response);
            string responseData = await response.Content.ReadAsStringAsync();
            this._logger.LogDebug("Response Data: {0}", (object)responseData);
            TResult result = await Task.Run<TResult>((Func<TResult>)(() => (TResult)JsonConvert.DeserializeObject<TResult>(responseData, this._serializerSettings)));
            return result;
        }

        private HttpClient CreateHttpClient(AuthenticationScheme authScheme = AuthenticationScheme.None, string token = "", ContentType contentType = ContentType.Json)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(GetEnumDescription(contentType)));
            if (this.headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }

            }



            if (!string.IsNullOrEmpty(token) && (uint)authScheme > 0U)
                this._logger.LogDebug("Authorization: {0}", (object)(httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authScheme.ToString("G"), token)));
            return httpClient;
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public void AddHeader(string key, string value)
        {
            this.headers.Add(key, value);
        }

        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (HttpStatusCode.Forbidden == response.StatusCode || HttpStatusCode.Unauthorized == response.StatusCode)
                    throw new Exception(content);
                if (HttpStatusCode.InternalServerError == response.StatusCode)
                {
                    MicroserviceError microserviceError = (MicroserviceError)JsonConvert.DeserializeObject<MicroserviceError>(content, this._serializerSettings);
                    throw new MicroserviceException(microserviceError.StatusCode, microserviceError.Message);
                }
                throw new HttpRequestException(content);
            }
        }


    }
}
