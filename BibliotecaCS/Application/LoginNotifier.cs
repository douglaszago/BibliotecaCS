using System;

namespace BibliotecaCS.Application
{
    // Padrão: Observer para notificar login bem-sucedido
    public static class LoginNotifier
    {
        public static event Action<Usuario> OnLogin;

        public static void Notify(Usuario usuario)
        {
            OnLogin?.Invoke(usuario);
        }
    }
}
