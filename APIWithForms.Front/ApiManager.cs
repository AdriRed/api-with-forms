using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIWithForms.Front
{
    public class ApiManager : IDisposable
    {
        HttpClient client;

        public ApiManager(HttpClient client)
        {
            this.client = client;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            var response = await NoBody(uri, client.GetAsync);
            return await WithoutSuccess<T>(response);
        }

        public async Task GetAsync<T>(string uri, Action<T> onSuccess)
        {
            var response = await NoBody(uri, client.GetAsync);
            await WithSuccess(response, onSuccess);
        }

        public async Task GetAsync<TSuccess, TError>(string uri, Action<TSuccess> onSuccess, Action<TError> onError)
        {
            var response = await NoBody(uri, client.GetAsync);
            await WithSuccessAndError(response, onSuccess, onError);
        }

        public async Task<TResponse> PostAsync<TBody, TResponse>(string uri, TBody body)
        {
            var response = await WithBody(uri, body, client.PostAsync);
            return await WithoutSuccess<TResponse>(response);
        }

        public async Task PostAsync<TBody, TResponse>(string uri, TBody body, Action<TResponse> onSuccess)
        {
            var response = await WithBody(uri, body, client.PostAsync);
            await WithSuccess(response, onSuccess);
        }

        public async Task PostAsync<TBody, TSuccess, TError>(string uri, TBody body, Action<TSuccess> onSuccess, Action<TError> onError)
        {
            var response = await WithBody(uri, body, client.PostAsync);
            await WithSuccessAndError(response, onSuccess, onError);
        }

        public async Task<TResponse> PutAsync<TBody, TResponse>(string uri, TBody body)
        {
            var response = await WithBody(uri, body, client.PutAsync);
            return await WithoutSuccess<TResponse>(response);
        }

        public async Task PutAsync<TBody, TResponse>(string uri, TBody body, Action<TResponse> onSuccess)
        {
            var response = await WithBody(uri, body, client.PutAsync);
            await WithSuccess(response, onSuccess);
        }

        public async Task PutAsync<TBody, TSuccess, TError>(string uri, TBody body, Action<TSuccess> onSuccess, Action<TError> onError)
        {
            var response = await WithBody(uri, body, client.PutAsync);
            await WithSuccessAndError(response, onSuccess, onError);
        }

        public async Task<T> DeleteAsync<T>(string uri)
        {
            var response = await NoBody(uri, client.DeleteAsync);
            return await WithoutSuccess<T>(response);
        }

        public async Task DeleteAsync<T>(string uri, Action<T> onSuccess)
        {
            var response = await NoBody(uri, client.DeleteAsync);
            await WithSuccess(response, onSuccess);
        }

        public async Task DeleteAsync<TSuccess, TError>(string uri, Action<TSuccess> onSuccess, Action<TError> onError)
        {
            var response = await NoBody(uri, client.DeleteAsync);
            await WithSuccessAndError(response, onSuccess, onError);
        }



        #region Dirigible Methods

        private async Task<T> WithoutSuccess<T>(HttpResponseMessage response)
        {
            T result = default;
            if (response.IsSuccessStatusCode)
                result = await GetContent<T>(response.Content);
            return result;
        }

        private async Task WithSuccess<T>(HttpResponseMessage response, Action<T> onSuccess)
        {
            if (response.IsSuccessStatusCode)
                await ManageResponse(response.Content, onSuccess);
        }

        private async Task WithSuccessAndError<TSuccess, TError>(HttpResponseMessage response, Action<TSuccess> onSuccess, Action<TError> onError)
        {
            if (response.IsSuccessStatusCode)
                await ManageResponse(response.Content, onSuccess);
            else
                await ManageResponse(response.Content, onError);
        }

        #endregion

        #region Atomic Methods

        private async Task<T> GetContent<T>(HttpContent content) 
        {
            string body = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(body);
        }

        private async Task<HttpResponseMessage> NoBody(string uri, Func<string, Task<HttpResponseMessage>> request)
        {
            return await request.Invoke(uri);
        }

        private async Task<HttpResponseMessage> WithBody<T>(string uri, T body, Func<string, HttpContent, Task<HttpResponseMessage>> request)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            return await request.Invoke(uri, content);
        }

        private async Task ManageResponse<T>(HttpContent body, Action<T> onSerialization)
        {
            T content = await GetContent<T>(body);
            onSerialization?.Invoke(content);
        }

        #endregion

        public void Dispose()
        {
            ((IDisposable)client).Dispose();
        }
    }
}
