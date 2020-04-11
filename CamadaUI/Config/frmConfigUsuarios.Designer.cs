namespace CamadaUI.Config
{
	partial class frmConfigUsuarios
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCancelar = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.pnlPastas = new System.Windows.Forms.Panel();
			this.btnAdicionar = new System.Windows.Forms.Button();
			this.btnAlterarAtivo = new System.Windows.Forms.Button();
			this.btnAlterarAcesso = new System.Windows.Forms.Button();
			this.btnAlterarEmail = new System.Windows.Forms.Button();
			this.btnAlterarSenha = new System.Windows.Forms.Button();
			this.lstUsuarios = new ComponentOwl.BetterListView.BetterListView();
			this.clnIDUsuario = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
			this.clnUsuarioApelido = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
			this.clnUsuarioAcessoDesc = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
			this.clnUsuarioAtivo = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
			this.panel1.SuspendLayout();
			this.pnlPastas.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lstUsuarios)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.BackColor = System.Drawing.Color.DarkOliveGreen;
			this.lblTitulo.Padding = new System.Windows.Forms.Padding(20, 0, 0, 4);
			this.lblTitulo.Size = new System.Drawing.Size(704, 30);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Controle de Usuários";
			// 
			// btnClose
			// 
			this.btnClose.BackColor = System.Drawing.Color.DarkOliveGreen;
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(704, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(744, 30);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightYellow;
			this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancelar.Image = global::CamadaUI.Properties.Resources.delete_24;
			this.btnCancelar.Location = new System.Drawing.Point(611, 531);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(121, 36);
			this.btnCancelar.TabIndex = 7;
			this.btnCancelar.Text = "&Fechar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(10, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(181, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "Controle de Usuários:";
			// 
			// pnlPastas
			// 
			this.pnlPastas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(221)))), ((int)(((byte)(207)))));
			this.pnlPastas.Controls.Add(this.btnAdicionar);
			this.pnlPastas.Controls.Add(this.btnAlterarAtivo);
			this.pnlPastas.Controls.Add(this.btnAlterarAcesso);
			this.pnlPastas.Controls.Add(this.btnAlterarEmail);
			this.pnlPastas.Controls.Add(this.btnAlterarSenha);
			this.pnlPastas.Controls.Add(this.lstUsuarios);
			this.pnlPastas.Controls.Add(this.label3);
			this.pnlPastas.Location = new System.Drawing.Point(12, 42);
			this.pnlPastas.Name = "pnlPastas";
			this.pnlPastas.Size = new System.Drawing.Size(720, 387);
			this.pnlPastas.TabIndex = 2;
			// 
			// btnAdicionar
			// 
			this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdicionar.BackColor = System.Drawing.Color.MintCream;
			this.btnAdicionar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.btnAdicionar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightYellow;
			this.btnAdicionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdicionar.Image = global::CamadaUI.Properties.Resources.add_24;
			this.btnAdicionar.Location = new System.Drawing.Point(498, 42);
			this.btnAdicionar.Name = "btnAdicionar";
			this.btnAdicionar.Size = new System.Drawing.Size(178, 40);
			this.btnAdicionar.TabIndex = 9;
			this.btnAdicionar.Text = "&Adicionar Usuário";
			this.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAdicionar.UseVisualStyleBackColor = false;
			this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
			// 
			// btnAlterarAtivo
			// 
			this.btnAlterarAtivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAlterarAtivo.BackColor = System.Drawing.Color.MintCream;
			this.btnAlterarAtivo.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.btnAlterarAtivo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightYellow;
			this.btnAlterarAtivo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			this.btnAlterarAtivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAlterarAtivo.Image = global::CamadaUI.Properties.Resources.block_24;
			this.btnAlterarAtivo.Location = new System.Drawing.Point(498, 258);
			this.btnAlterarAtivo.Name = "btnAlterarAtivo";
			this.btnAlterarAtivo.Size = new System.Drawing.Size(178, 40);
			this.btnAlterarAtivo.TabIndex = 9;
			this.btnAlterarAtivo.Text = "&Desativar Usuário";
			this.btnAlterarAtivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAlterarAtivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAlterarAtivo.UseVisualStyleBackColor = false;
			this.btnAlterarAtivo.Click += new System.EventHandler(this.btnAlterarAtivo_Click);
			// 
			// btnAlterarAcesso
			// 
			this.btnAlterarAcesso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAlterarAcesso.BackColor = System.Drawing.Color.MintCream;
			this.btnAlterarAcesso.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.btnAlterarAcesso.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightYellow;
			this.btnAlterarAcesso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			this.btnAlterarAcesso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAlterarAcesso.Image = global::CamadaUI.Properties.Resources.editar_24;
			this.btnAlterarAcesso.Location = new System.Drawing.Point(498, 196);
			this.btnAlterarAcesso.Name = "btnAlterarAcesso";
			this.btnAlterarAcesso.Size = new System.Drawing.Size(178, 40);
			this.btnAlterarAcesso.TabIndex = 9;
			this.btnAlterarAcesso.Text = "&Alterar Acesso";
			this.btnAlterarAcesso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAlterarAcesso.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAlterarAcesso.UseVisualStyleBackColor = false;
			this.btnAlterarAcesso.Click += new System.EventHandler(this.btnAlterarAcesso_Click);
			// 
			// btnAlterarEmail
			// 
			this.btnAlterarEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAlterarEmail.BackColor = System.Drawing.Color.MintCream;
			this.btnAlterarEmail.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.btnAlterarEmail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightYellow;
			this.btnAlterarEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			this.btnAlterarEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAlterarEmail.Image = global::CamadaUI.Properties.Resources.editar_24;
			this.btnAlterarEmail.Location = new System.Drawing.Point(498, 150);
			this.btnAlterarEmail.Name = "btnAlterarEmail";
			this.btnAlterarEmail.Size = new System.Drawing.Size(178, 40);
			this.btnAlterarEmail.TabIndex = 9;
			this.btnAlterarEmail.Text = "&Alterar Email";
			this.btnAlterarEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAlterarEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAlterarEmail.UseVisualStyleBackColor = false;
			this.btnAlterarEmail.Click += new System.EventHandler(this.btnAlterarEmail_Click);
			// 
			// btnAlterarSenha
			// 
			this.btnAlterarSenha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAlterarSenha.BackColor = System.Drawing.Color.MintCream;
			this.btnAlterarSenha.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.btnAlterarSenha.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightYellow;
			this.btnAlterarSenha.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			this.btnAlterarSenha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAlterarSenha.Image = global::CamadaUI.Properties.Resources.editar_24;
			this.btnAlterarSenha.Location = new System.Drawing.Point(498, 104);
			this.btnAlterarSenha.Name = "btnAlterarSenha";
			this.btnAlterarSenha.Size = new System.Drawing.Size(178, 40);
			this.btnAlterarSenha.TabIndex = 9;
			this.btnAlterarSenha.Text = "&Alterar Senha";
			this.btnAlterarSenha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAlterarSenha.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAlterarSenha.UseVisualStyleBackColor = false;
			this.btnAlterarSenha.Click += new System.EventHandler(this.btnAlterarSenha_Click);
			// 
			// lstUsuarios
			// 
			this.lstUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstUsuarios.ColorSortedColumn = System.Drawing.Color.LightBlue;
			this.lstUsuarios.Columns.Add(this.clnIDUsuario);
			this.lstUsuarios.Columns.Add(this.clnUsuarioApelido);
			this.lstUsuarios.Columns.Add(this.clnUsuarioAcessoDesc);
			this.lstUsuarios.Columns.Add(this.clnUsuarioAtivo);
			this.lstUsuarios.DisplayMember = "IDUsuario";
			this.lstUsuarios.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstUsuarios.FontColumns = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstUsuarios.ForeColor = System.Drawing.Color.Black;
			this.lstUsuarios.ForeColorColumns = System.Drawing.Color.Black;
			this.lstUsuarios.ForeColorGroups = System.Drawing.SystemColors.MenuHighlight;
			this.lstUsuarios.GridLines = ComponentOwl.BetterListView.BetterListViewGridLines.Grid;
			this.lstUsuarios.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Nonclickable;
			this.lstUsuarios.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection;
			this.lstUsuarios.Location = new System.Drawing.Point(14, 42);
			this.lstUsuarios.MultiSelect = false;
			this.lstUsuarios.Name = "lstUsuarios";
			this.lstUsuarios.Size = new System.Drawing.Size(452, 330);
			this.lstUsuarios.TabIndex = 8;
			this.lstUsuarios.ItemActivate += new ComponentOwl.BetterListView.BetterListViewItemActivateEventHandler(this.lstUsuarios_ItemActivate);
			this.lstUsuarios.DrawColumnHeader += new ComponentOwl.BetterListView.BetterListViewDrawColumnHeaderEventHandler(this.lstUsuarios_DrawColumnHeader);
			this.lstUsuarios.DrawItem += new ComponentOwl.BetterListView.BetterListViewDrawItemEventHandler(this.lstUsuarios_DrawItem);
			// 
			// clnIDUsuario
			// 
			this.clnIDUsuario.AllowResize = false;
			this.clnIDUsuario.Name = "clnIDUsuario";
			this.clnIDUsuario.Text = "Reg";
			this.clnIDUsuario.Width = 50;
			// 
			// clnUsuarioApelido
			// 
			this.clnUsuarioApelido.AllowResize = false;
			this.clnUsuarioApelido.Name = "clnUsuarioApelido";
			this.clnUsuarioApelido.Text = "Apelido";
			this.clnUsuarioApelido.Width = 160;
			// 
			// clnUsuarioAcessoDesc
			// 
			this.clnUsuarioAcessoDesc.AllowResize = false;
			this.clnUsuarioAcessoDesc.Name = "clnUsuarioAcessoDesc";
			this.clnUsuarioAcessoDesc.Text = "Acesso";
			this.clnUsuarioAcessoDesc.Width = 130;
			// 
			// clnUsuarioAtivo
			// 
			this.clnUsuarioAtivo.Name = "clnUsuarioAtivo";
			this.clnUsuarioAtivo.Text = "Ativo";
			this.clnUsuarioAtivo.Width = 60;
			// 
			// frmConfigUsuarios
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(744, 579);
			this.Controls.Add(this.pnlPastas);
			this.Controls.Add(this.btnCancelar);
			this.Name = "frmConfigUsuarios";
			this.Controls.SetChildIndex(this.btnCancelar, 0);
			this.Controls.SetChildIndex(this.pnlPastas, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.panel1.ResumeLayout(false);
			this.pnlPastas.ResumeLayout(false);
			this.pnlPastas.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.lstUsuarios)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel pnlPastas;
		internal ComponentOwl.BetterListView.BetterListView lstUsuarios;
		internal ComponentOwl.BetterListView.BetterListViewColumnHeader clnIDUsuario;
		internal ComponentOwl.BetterListView.BetterListViewColumnHeader clnUsuarioApelido;
		internal ComponentOwl.BetterListView.BetterListViewColumnHeader clnUsuarioAcessoDesc;
		private System.Windows.Forms.Button btnAlterarSenha;
		private System.Windows.Forms.Button btnAdicionar;
		private ComponentOwl.BetterListView.BetterListViewColumnHeader clnUsuarioAtivo;
		private System.Windows.Forms.Button btnAlterarEmail;
		private System.Windows.Forms.Button btnAlterarAcesso;
		private System.Windows.Forms.Button btnAlterarAtivo;
	}
}
