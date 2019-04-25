using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
   public interface IHttpClient
    {
        Task<String> GetStringAsync(string uri, String authorizationToken = null, string authorizationMethod = "Bearer");

        Task<HttpResponseMessage> PostAsync<T>(string uri, T item, String authorizationToken = null, String authorizationMethod = "Bearer");

        Task<HttpResponseMessage> PutAsync<T>(string uri, T item, String authorizationToken = null, String authorizationMethod = "Bearer");

        Task<HttpResponseMessage> DeleteAsync<T>(string uri,  String authorizationToken = null, String authorizationMethod = "Bearer");


    }
}
