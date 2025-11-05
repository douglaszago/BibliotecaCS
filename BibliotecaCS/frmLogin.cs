using System;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1;


namespace BibliotecaCS
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
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

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = "http://localhost:3000/users/login";

                    var body = new
                    {
                        email = email,
                        senha = senha
                    };

                    var json = JsonSerializer.Serialize(body);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();

                        // Converte a resposta em um objeto anônimo
                        var jsonResponse = JsonSerializer.Deserialize<JsonElement>(result);
                        var user = jsonResponse.GetProperty("user");

                        string nome = user.GetProperty("nome").GetString();

                        MessageBox.Show($"Bem-vindo, {nome}!", "Login realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        frmPrincipal principal = new frmPrincipal();
                        principal.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("E-mail ou senha inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao conectar à API: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            // se fechar o login, fecha tudo
            Application.Exit();
        }
    }
}
