using System;
using System.Windows.Forms;
using BibliotecaCS.Application;
using BibliotecaCS.Domain;
using WindowsFormsApp1;
using BibliotecaCS.Application;
using BibliotecaCS.Domain;


namespace BibliotecaCS
{
    public partial class frmLogin : Form
    {
        private readonly LoginController _controller;

        public frmLogin()
        {
            InitializeComponent();

            // Injeta o repositório da API no controller
            _controller = new LoginController(new ApiUsuarioRepository());
        }

        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = txtUsuario.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha o e-mail e a senha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var usuario = await _controller.AutenticarAsync(email, senha);

                if (usuario == null)
                {
                    MessageBox.Show("E-mail ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Notifica os interessados (Observer)
                LoginNotifier.Notify(usuario);

                MessageBox.Show($"Bem-vindo, {usuario.Nome}!", "Login realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var principal = new frmPrincipal();
                principal.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar à API: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();

        }
    }
}
