using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Windows.Forms;
using BibliotecaCS;
using QRCoder;

namespace WindowsFormsApp1
{
    public partial class frmCadUsuario : Form
    {
        private List<Usuario> usuarios = new List<Usuario>();
        private string caminhoImagem = "";

        public frmCadUsuario()
        {
            InitializeComponent();
            AtualizarGrid();
            this.StartPosition = FormStartPosition.CenterScreen; // abre centralizado
        }

        private void btnSelecionarImagem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Arquivos de imagem|*.jpg;*.png;*.jpeg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    caminhoImagem = ofd.FileName;
                    picUsuario.Image = Image.FromFile(caminhoImagem);
                }
            }
        }

        private async void btnAdicionar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = "http://localhost:3000/users";

                    var body = new
                    {
                        nome = nome,
                        email = email,
                        senha = senha
                    };

                    var json = JsonSerializer.Serialize(body);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNome.Clear();
                        txtEmail.Clear();
                        txtSenha.Clear();
                    }
                    else
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Erro ao cadastrar: {result}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao conectar à API: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
                return;

            int id = (int)dgvUsuarios.CurrentRow.Cells["Id"].Value;
            usuarios.RemoveAll(u => u.Id == id);

            AtualizarGrid();
            LimparCampos();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
                return;

            int id = (int)dgvUsuarios.CurrentRow.Cells["Id"].Value;
            var u = usuarios.FirstOrDefault(x => x.Id == id);

            if (u != null)
            {
                u.Nome = txtNome.Text;
                u.Email = txtEmail.Text;
                u.Senha = txtSenha.Text;
                u.CaminhoImagem = caminhoImagem;
            }

            AtualizarGrid();
            GerarQRCode(u);
        }

        private void AtualizarGrid()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = usuarios;
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            picUsuario.Image = null;
            picQRCode.Image = null;
            caminhoImagem = "";
        }

        private void GerarQRCode(Usuario u)
        {
            string dados = $"Nome: {u.Nome}\nEmail: {u.Email}\nCPF: {u.Senha}";

            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(dados, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);

            picQRCode.Image = code.GetGraphic(5); // exibe o QRCode no PictureBox
        }
    }
}
