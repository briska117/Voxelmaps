using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IISI.Request
{
     public interface IRequestService
    {
        Task<TResult> GetAsync<TResult>(string uri, AuthenticationScheme authScheme = AuthenticationScheme.None, string token = "", ContentType contentType = ContentType.Json);

        Task<TResult> PostAsync<TResult>(
          string uri,
          TResult data,
          AuthenticationScheme authScheme = AuthenticationScheme.None,
          string token = "", ContentType contentType = ContentType.Json);

        Task<TResult> PostAsync<TRequest, TResult>(
          string uri,
          TRequest data,
          AuthenticationScheme authScheme = AuthenticationScheme.None,
          string token = "", ContentType contentType = ContentType.Json);

        Task<TResult> PutAsync<TResult>(
          string uri,
          TResult data,
          AuthenticationScheme authScheme = AuthenticationScheme.None,
          string token = "", ContentType contentType = ContentType.Json);

        Task<TResult> PutAsync<TRequest, TResult>(
          string uri,
          TRequest data,
          AuthenticationScheme authScheme = AuthenticationScheme.None,
          string token = "", ContentType contentType = ContentType.Json);

        Task<TResult> PatchAsync<TResult>(
          string uri,
          TResult data,
          AuthenticationScheme authScheme = AuthenticationScheme.None,
          string token = "", ContentType contentType = ContentType.Json);

        Task<TResult> PatchAsync<TRequest, TResult>(
          string uri,
          TRequest data,
          AuthenticationScheme authScheme = AuthenticationScheme.None,
          string token = "", ContentType contentType = ContentType.Json);

        Task<TResult> DeleteAsync<TResult>(string uri, AuthenticationScheme authScheme = AuthenticationScheme.None, string token = "", ContentType contentType = ContentType.Json);

    }
}
