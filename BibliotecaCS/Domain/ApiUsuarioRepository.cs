using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BibliotecaCS.Infrastructure;

namespace BibliotecaCS.Domain
{
    public class ApiUsuarioRepository : IUsuarioRepository
    {
        public async Task<Usuario> LoginAsync(string email, string senha)
        {
            var client = ApiClient.Instance;

            var payload = new { email, senha };
            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("users/login", content);
            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            JsonDocument doc = JsonDocument.Parse(json);
            try
            {
                if (!doc.RootElement.TryGetProperty("user", out var userElement))
                    return null;

                var usuario = new Usuario
                {
                    Nome = userElement.GetProperty("nome").GetString(),
                    Email = userElement.GetProperty("email").GetString()
                };

                return usuario;
            }
            finally
            {
                doc.Dispose();
            }
        }

        public async Task<bool> RegistrarAsync(Usuario usuario)
        {
            var client = ApiClient.Instance;

            var payload = new
            {
                nome = usuario.Nome,
                email = usuario.Email,
                senha = usuario.Senha
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("users", content);

            return response.IsSuccessStatusCode;
        }
    }
}
