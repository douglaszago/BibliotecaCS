using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;
using System.ComponentModel;

namespace BibliotecaCS
{
    public class UsuarioRepository
    {
        private int _seq = 1;
        public BindingList<Usuario> Usuarios { get; } = new BindingList<Usuario>();

        public Usuario Add(Usuario u)
        {
            u.Id = _seq++;
            Usuarios.Add(u);
            return u;
        }

        public void Update(Usuario u)
        {
            var idx = Usuarios.ToList().FindIndex(x => x.Id == u.Id);
            if (idx >= 0) Usuarios[idx] = u;
        }

        public void Delete(int id)
        {
            var u = Usuarios.FirstOrDefault(x => x.Id == id);
            if (u != null) Usuarios.Remove(u);
        }
    }
}
