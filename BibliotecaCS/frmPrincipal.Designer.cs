namespace WindowsFormsApp1
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.principalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeLivroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeAutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.emprestimosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoEmpréstimoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devoluçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeUsuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.principalToolStripMenuItem,
            this.emprestimosToolStripMenuItem,
            this.relatóriosToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(908, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // principalToolStripMenuItem
            // 
            this.principalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroDeLivroToolStripMenuItem,
            this.cadastroDeAutorToolStripMenuItem,
            this.toolStripMenuItem2,
            this.sairToolStripMenuItem,
            this.toolStripMenuItem3,
            this.cadastroDeUsuárioToolStripMenuItem});
            this.principalToolStripMenuItem.Name = "principalToolStripMenuItem";
            this.principalToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.principalToolStripMenuItem.Text = "Principal";
            this.principalToolStripMenuItem.Click += new System.EventHandler(this.principalToolStripMenuItem_Click);
            // 
            // cadastroDeLivroToolStripMenuItem
            // 
            this.cadastroDeLivroToolStripMenuItem.Name = "cadastroDeLivroToolStripMenuItem";
            this.cadastroDeLivroToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cadastroDeLivroToolStripMenuItem.Text = "Cadastro de Livro";
            this.cadastroDeLivroToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeLivroToolStripMenuItem_Click);
            // 
            // cadastroDeAutorToolStripMenuItem
            // 
            this.cadastroDeAutorToolStripMenuItem.Name = "cadastroDeAutorToolStripMenuItem";
            this.cadastroDeAutorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cadastroDeAutorToolStripMenuItem.Text = "Cadastro de Autor";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // emprestimosToolStripMenuItem
            // 
            this.emprestimosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoEmpréstimoToolStripMenuItem,
            this.devoluçãoToolStripMenuItem});
            this.emprestimosToolStripMenuItem.Name = "emprestimosToolStripMenuItem";
            this.emprestimosToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.emprestimosToolStripMenuItem.Text = "Empréstimos";
            // 
            // novoEmpréstimoToolStripMenuItem
            // 
            this.novoEmpréstimoToolStripMenuItem.Name = "novoEmpréstimoToolStripMenuItem";
            this.novoEmpréstimoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.novoEmpréstimoToolStripMenuItem.Text = "Novo Empréstimo";
            // 
            // devoluçãoToolStripMenuItem
            // 
            this.devoluçãoToolStripMenuItem.Name = "devoluçãoToolStripMenuItem";
            this.devoluçãoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.devoluçãoToolStripMenuItem.Text = "Devolução";
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // cadastroDeUsuárioToolStripMenuItem
            // 
            this.cadastroDeUsuárioToolStripMenuItem.Name = "cadastroDeUsuárioToolStripMenuItem";
            this.cadastroDeUsuárioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cadastroDeUsuárioToolStripMenuItem.Text = "Cadastro de usuário";
            this.cadastroDeUsuárioToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeUsuárioToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(908, 537);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.ShowIcon = false;
            this.Text = "Minha primeira solução";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem principalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeLivroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeAutorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem emprestimosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoEmpréstimoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devoluçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeUsuárioToolStripMenuItem;
    }
}

