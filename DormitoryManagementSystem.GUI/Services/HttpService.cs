using DormitoryManagementSystem.GUI.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace DormitoryManagementSystem.GUI.Services
{
    internal static class HttpService
    {
        private static readonly Lazy<HttpClient> _client = new(() =>
        {
            var baseUrl = Environment.GetEnvironmentVariable("DMS_API_BASE_URL")
                ?? "localhost:5041";

            // Bỏ qua SSL certificate validation cho localhost (chỉ dùng trong development)
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                {
                    // Cho phép localhost bỏ qua SSL validation
                    if (message.RequestUri?.Host == "localhost" || message.RequestUri?.Host == "127.0.0.1")
                        return true;
                    return errors == SslPolicyErrors.None;
                }
            };

            // Đảm bảo base URL kết thúc bằng "/"
            if (!baseUrl.EndsWith("/"))
            {
                baseUrl = baseUrl + "/";
            }

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl),
                Timeout = TimeSpan.FromSeconds(30) // Set timeout 30 giây
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrWhiteSpace(GlobalState.AuthToken))
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", GlobalState.AuthToken);
            }

            return client;
        });

        public static HttpClient Client => _client.Value;

        public static void SetAuthorization(string? token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                Client.DefaultRequestHeaders.Authorization = null;
            }
            else
            {
                Client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}

