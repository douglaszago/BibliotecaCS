using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QRCoder;

namespace WindowsFormsApp1
{
    public partial class frmCadUsuario : Form
    {
        private List<Usuario> usuarios = new List<Usuario>();
        private int proximoId = 1;
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

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // validação simples
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtCpf.Text))
            {
                MessageBox.Show("Preencha todos os campos antes de adicionar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario u = new Usuario
            {
                Id = proximoId++,
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Cpf = txtCpf.Text,
                Imagem = caminhoImagem
            };

            usuarios.Add(u);
            AtualizarGrid();
            GerarQRCode(u); // agora o QRCode aparece e não é limpo logo após
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
                u.Cpf = txtCpf.Text;
                u.Imagem = caminhoImagem;
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
            txtCpf.Clear();
            picUsuario.Image = null;
            picQRCode.Image = null;
            caminhoImagem = "";
        }

        private void GerarQRCode(Usuario u)
        {
            string dados = $"Nome: {u.Nome}\nEmail: {u.Email}\nCPF: {u.Cpf}";

            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(dados, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);

            picQRCode.Image = code.GetGraphic(5); // exibe o QRCode no PictureBox
        }
    }
}
