using System.Threading.Tasks;

namespace BibliotecaCS.Domain
{
    public interface IUsuarioRepository
    {
        Task<Usuario> LoginAsync(string email, string senha);
        Task<bool> RegistrarAsync(Usuario usuario);
    }
}
