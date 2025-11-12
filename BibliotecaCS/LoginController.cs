using BibliotecaCS.Domain;
using System.Threading.Tasks;

namespace BibliotecaCS
{
    public class LoginController
    {
        private readonly ApiUsuarioRepository _apiUsuarioRepository;

        public LoginController(ApiUsuarioRepository apiUsuarioRepository)
        {
            _apiUsuarioRepository = apiUsuarioRepository;
        }

        // Adiciona o método AutenticarAsync para corrigir o erro CS1061
        public async Task<Usuario> AutenticarAsync(string email, string senha)
        {
            return await _apiUsuarioRepository.LoginAsync(email, senha);
        }

    }
}