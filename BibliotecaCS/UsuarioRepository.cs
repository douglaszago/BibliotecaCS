using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BibliotecaCS;

namespace BibliotecaCS
{
    public class UsuarioRepository
    {
        public UsuarioRepository()
        {
            // Usuário padrão só pra teste
            Usuarios.Add(new Usuario
            {
                Id = _seq++,
                Nome = "Douglas",
                Email = "douglas@teste.com",
                Senha = "123"
            });
        }

        private int _seq = 1;

        // Lista de usuários (usada pelo cadastro e pelo login)
        public BindingList<Usuario> Usuarios { get; } = new BindingList<Usuario>();

        // Adicionar um novo usuário
        public Usuario Add(Usuario u)
        {
            u.Id = _seq++;
            Usuarios.Add(u);
            return u;
        }

        // Atualizar um usuário existente
        public void Update(Usuario u)
        {
            var idx = Usuarios.ToList().FindIndex(x => x.Id == u.Id);
            if (idx >= 0)
                Usuarios[idx] = u;
        }

        // Excluir um usuário pelo ID
        public void Delete(int id)
        {
            var u = Usuarios.FirstOrDefault(x => x.Id == id);
            if (u != null)
                Usuarios.Remove(u);
        }

        // 🔍 Buscar usuário por e-mail e senha (para login)
        public Usuario BuscarPorLoginESenha(string email, string senha)
        {
            return Usuarios.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                u.Senha == senha);
        }
    }
}
