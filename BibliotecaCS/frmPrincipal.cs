using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmPrincipal : Form
    {
        private Panel minimizedFormsPanel;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void principalToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void cadastroDeLivroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadLivros cadLivros = new frmCadLivros();
            cadLivros.MdiParent = this;
            cadLivros.Show();
        }

        private void cadastroDeUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadUsuario cadUsuario = new frmCadUsuario();
            cadUsuario.MdiParent = this;
            cadUsuario.Show();
        }
    }
}
