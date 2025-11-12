using System;
using System.Net.Http;

namespace BibliotecaCS.Infrastructure
{
    // Padrão: Singleton para cliente HTTP
    public sealed class ApiClient
    {
        private static readonly Lazy<HttpClient> _client = new Lazy<HttpClient>(() =>
        {
            var c = new HttpClient();
            c.BaseAddress = new Uri("http://localhost:3000/");
            return c;
        });

        public static HttpClient Instance => _client.Value;
    }
}
