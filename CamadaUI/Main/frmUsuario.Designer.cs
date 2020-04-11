namespace CamadaUI.Main
{
	partial class frmUsuario
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
			this.lblNome = new System.Windows.Forms.Label();
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtSenhaAntigaAlterar = new System.Windows.Forms.TextBox();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnSalvar = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.cmbAcessoAlterar = new CamadaUC.ucComboLimitedValues();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtSenhaConfirmarAlterar = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtSenhaNovaAlterar = new System.Windows.Forms.TextBox();
			this.pnlAlterarSenha = new System.Windows.Forms.Panel();
			this.lblUsuarioSenhaAlterar = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.pnlNovoUsuario = new System.Windows.Forms.Panel();
			this.txtEmailNovo = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtUsuarioNovo = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.cmbAcessoNovo = new CamadaUC.ucComboLimitedValues();
			this.txtSenhaConfirmarNovo = new System.Windows.Forms.TextBox();
			this.txtSenhaNovo = new System.Windows.Forms.TextBox();
			this.pnlAlterarAcesso = new System.Windows.Forms.Panel();
			this.lblUsuarioAcessoAlterar = new System.Windows.Forms.Label();
			this.pnlAlterarEmail = new System.Windows.Forms.Panel();
			this.txtEmailAlterar = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.lblUsuarioEmailAlterar = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.pnlAlterarSenha.SuspendLayout();
			this.pnlNovoUsuario.SuspendLayout();
			this.pnlAlterarAcesso.SuspendLayout();
			this.pnlAlterarEmail.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(182, 0);
			this.lblTitulo.Size = new System.Drawing.Size(327, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "Cadastro de Usuário";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(509, 0);
			this.btnClose.TabIndex = 3;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblID);
			this.panel1.Controls.Add(this.lbl_IdTexto);
			this.panel1.Size = new System.Drawing.Size(549, 50);
			this.panel1.Controls.SetChildIndex(this.btnClose, 0);
			this.panel1.Controls.SetChildIndex(this.lblTitulo, 0);
			this.panel1.Controls.SetChildIndex(this.lbl_IdTexto, 0);
			this.panel1.Controls.SetChildIndex(this.lblID, 0);
			// 
			// lblNome
			// 
			this.lblNome.AutoSize = true;
			this.lblNome.BackColor = System.Drawing.Color.Transparent;
			this.lblNome.ForeColor = System.Drawing.Color.Black;
			this.lblNome.Location = new System.Drawing.Point(51, 16);
			this.lblNome.Name = "lblNome";
			this.lblNome.Size = new System.Drawing.Size(59, 19);
			this.lblNome.TabIndex = 0;
			this.lblNome.Text = "Usuário";
			// 
			// lblID
			// 
			this.lblID.BackColor = System.Drawing.Color.Transparent;
			this.lblID.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblID.ForeColor = System.Drawing.Color.AliceBlue;
			this.lblID.Location = new System.Drawing.Point(4, 18);
			this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblID.Name = "lblID";
			this.lblID.Size = new System.Drawing.Size(94, 30);
			this.lblID.TabIndex = 0;
			this.lblID.Text = "0001";
			this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbl_IdTexto
			// 
			this.lbl_IdTexto.AutoSize = true;
			this.lbl_IdTexto.BackColor = System.Drawing.Color.Transparent;
			this.lbl_IdTexto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_IdTexto.ForeColor = System.Drawing.Color.LightGray;
			this.lbl_IdTexto.Location = new System.Drawing.Point(31, 5);
			this.lbl_IdTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbl_IdTexto.Name = "lbl_IdTexto";
			this.lbl_IdTexto.Size = new System.Drawing.Size(35, 13);
			this.lbl_IdTexto.TabIndex = 1;
			this.lbl_IdTexto.Text = "Reg.";
			this.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(18, 55);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 19);
			this.label3.TabIndex = 2;
			this.label3.Text = "Senha Antiga";
			// 
			// txtSenhaAntigaAlterar
			// 
			this.txtSenhaAntigaAlterar.BackColor = System.Drawing.Color.White;
			this.txtSenhaAntigaAlterar.Location = new System.Drawing.Point(121, 52);
			this.txtSenhaAntigaAlterar.Margin = new System.Windows.Forms.Padding(6);
			this.txtSenhaAntigaAlterar.MaxLength = 8;
			this.txtSenhaAntigaAlterar.Name = "txtSenhaAntigaAlterar";
			this.txtSenhaAntigaAlterar.Size = new System.Drawing.Size(120, 27);
			this.txtSenhaAntigaAlterar.TabIndex = 3;
			// 
			// tspMenu
			// 
			this.tspMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tspMenu.AutoSize = false;
			this.tspMenu.BackColor = System.Drawing.Color.AntiqueWhite;
			this.tspMenu.Dock = System.Windows.Forms.DockStyle.None;
			this.tspMenu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tspMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalvar,
            this.btnCancelar,
            this.btnFechar});
			this.tspMenu.Location = new System.Drawing.Point(2, 639);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(544, 44);
			this.tspMenu.TabIndex = 5;
			this.tspMenu.TabStop = true;
			this.tspMenu.Text = "toolStrip1";
			// 
			// btnSalvar
			// 
			this.btnSalvar.Image = global::CamadaUI.Properties.Resources.salvar_30;
			this.btnSalvar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSalvar.Name = "btnSalvar";
			this.btnSalvar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnSalvar.Size = new System.Drawing.Size(92, 41);
			this.btnSalvar.Text = "&Salvar";
			this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Image = global::CamadaUI.Properties.Resources.delete_page_30;
			this.btnCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnCancelar.Size = new System.Drawing.Size(110, 41);
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnFechar
			// 
			this.btnFechar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.fechar_30;
			this.btnFechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnFechar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnFechar.Size = new System.Drawing.Size(96, 41);
			this.btnFechar.Text = "&Fechar";
			this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// cmbAcessoAlterar
			// 
			this.cmbAcessoAlterar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbAcessoAlterar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbAcessoAlterar.FormattingEnabled = true;
			this.cmbAcessoAlterar.Location = new System.Drawing.Point(121, 54);
			this.cmbAcessoAlterar.Margin = new System.Windows.Forms.Padding(6);
			this.cmbAcessoAlterar.Name = "cmbAcessoAlterar";
			this.cmbAcessoAlterar.Size = new System.Drawing.Size(176, 27);
			this.cmbAcessoAlterar.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(57, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "Acesso";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(257, 94);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 19);
			this.label1.TabIndex = 6;
			this.label1.Text = "Confimar Senha";
			// 
			// txtSenhaConfirmarAlterar
			// 
			this.txtSenhaConfirmarAlterar.BackColor = System.Drawing.Color.White;
			this.txtSenhaConfirmarAlterar.Location = new System.Drawing.Point(372, 91);
			this.txtSenhaConfirmarAlterar.Margin = new System.Windows.Forms.Padding(6);
			this.txtSenhaConfirmarAlterar.MaxLength = 8;
			this.txtSenhaConfirmarAlterar.Name = "txtSenhaConfirmarAlterar";
			this.txtSenhaConfirmarAlterar.Size = new System.Drawing.Size(120, 27);
			this.txtSenhaConfirmarAlterar.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(27, 94);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(85, 19);
			this.label4.TabIndex = 4;
			this.label4.Text = "Nova Senha";
			// 
			// txtSenhaNovaAlterar
			// 
			this.txtSenhaNovaAlterar.BackColor = System.Drawing.Color.White;
			this.txtSenhaNovaAlterar.Location = new System.Drawing.Point(121, 91);
			this.txtSenhaNovaAlterar.Margin = new System.Windows.Forms.Padding(6);
			this.txtSenhaNovaAlterar.MaxLength = 8;
			this.txtSenhaNovaAlterar.Name = "txtSenhaNovaAlterar";
			this.txtSenhaNovaAlterar.Size = new System.Drawing.Size(120, 27);
			this.txtSenhaNovaAlterar.TabIndex = 5;
			// 
			// pnlAlterarSenha
			// 
			this.pnlAlterarSenha.Controls.Add(this.lblUsuarioSenhaAlterar);
			this.pnlAlterarSenha.Controls.Add(this.label12);
			this.pnlAlterarSenha.Controls.Add(this.txtSenhaAntigaAlterar);
			this.pnlAlterarSenha.Controls.Add(this.label3);
			this.pnlAlterarSenha.Controls.Add(this.label1);
			this.pnlAlterarSenha.Controls.Add(this.label4);
			this.pnlAlterarSenha.Controls.Add(this.txtSenhaConfirmarAlterar);
			this.pnlAlterarSenha.Controls.Add(this.txtSenhaNovaAlterar);
			this.pnlAlterarSenha.Location = new System.Drawing.Point(18, 261);
			this.pnlAlterarSenha.Name = "pnlAlterarSenha";
			this.pnlAlterarSenha.Size = new System.Drawing.Size(509, 139);
			this.pnlAlterarSenha.TabIndex = 2;
			// 
			// lblUsuarioSenhaAlterar
			// 
			this.lblUsuarioSenhaAlterar.BackColor = System.Drawing.Color.Transparent;
			this.lblUsuarioSenhaAlterar.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUsuarioSenhaAlterar.ForeColor = System.Drawing.Color.Black;
			this.lblUsuarioSenhaAlterar.Location = new System.Drawing.Point(116, 12);
			this.lblUsuarioSenhaAlterar.Name = "lblUsuarioSenhaAlterar";
			this.lblUsuarioSenhaAlterar.Size = new System.Drawing.Size(388, 25);
			this.lblUsuarioSenhaAlterar.TabIndex = 1;
			this.lblUsuarioSenhaAlterar.Text = "Nome do Usuário";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.BackColor = System.Drawing.Color.Transparent;
			this.label12.ForeColor = System.Drawing.Color.Black;
			this.label12.Location = new System.Drawing.Point(51, 16);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(59, 19);
			this.label12.TabIndex = 0;
			this.label12.Text = "Usuário";
			// 
			// pnlNovoUsuario
			// 
			this.pnlNovoUsuario.Controls.Add(this.txtEmailNovo);
			this.pnlNovoUsuario.Controls.Add(this.label10);
			this.pnlNovoUsuario.Controls.Add(this.txtUsuarioNovo);
			this.pnlNovoUsuario.Controls.Add(this.label5);
			this.pnlNovoUsuario.Controls.Add(this.label6);
			this.pnlNovoUsuario.Controls.Add(this.label8);
			this.pnlNovoUsuario.Controls.Add(this.label7);
			this.pnlNovoUsuario.Controls.Add(this.cmbAcessoNovo);
			this.pnlNovoUsuario.Controls.Add(this.txtSenhaConfirmarNovo);
			this.pnlNovoUsuario.Controls.Add(this.txtSenhaNovo);
			this.pnlNovoUsuario.Location = new System.Drawing.Point(18, 70);
			this.pnlNovoUsuario.Name = "pnlNovoUsuario";
			this.pnlNovoUsuario.Size = new System.Drawing.Size(509, 177);
			this.pnlNovoUsuario.TabIndex = 1;
			// 
			// txtEmailNovo
			// 
			this.txtEmailNovo.BackColor = System.Drawing.Color.White;
			this.txtEmailNovo.Location = new System.Drawing.Point(121, 94);
			this.txtEmailNovo.Margin = new System.Windows.Forms.Padding(6);
			this.txtEmailNovo.MaxLength = 30;
			this.txtEmailNovo.Name = "txtEmailNovo";
			this.txtEmailNovo.Size = new System.Drawing.Size(371, 27);
			this.txtEmailNovo.TabIndex = 5;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.ForeColor = System.Drawing.Color.Black;
			this.label10.Location = new System.Drawing.Point(67, 97);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(45, 19);
			this.label10.TabIndex = 4;
			this.label10.Text = "Email";
			// 
			// txtUsuarioNovo
			// 
			this.txtUsuarioNovo.BackColor = System.Drawing.Color.White;
			this.txtUsuarioNovo.Location = new System.Drawing.Point(121, 16);
			this.txtUsuarioNovo.Margin = new System.Windows.Forms.Padding(6);
			this.txtUsuarioNovo.MaxLength = 30;
			this.txtUsuarioNovo.Name = "txtUsuarioNovo";
			this.txtUsuarioNovo.Size = new System.Drawing.Size(371, 27);
			this.txtUsuarioNovo.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(56, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 19);
			this.label5.TabIndex = 0;
			this.label5.Text = "Usuário";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.ForeColor = System.Drawing.Color.Black;
			this.label6.Location = new System.Drawing.Point(258, 136);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(110, 19);
			this.label6.TabIndex = 8;
			this.label6.Text = "Confimar Senha";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.ForeColor = System.Drawing.Color.Black;
			this.label8.Location = new System.Drawing.Point(60, 58);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(55, 19);
			this.label8.TabIndex = 2;
			this.label8.Text = "Acesso";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.ForeColor = System.Drawing.Color.Black;
			this.label7.Location = new System.Drawing.Point(18, 136);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(93, 19);
			this.label7.TabIndex = 6;
			this.label7.Text = "Inserir Senha";
			// 
			// cmbAcessoNovo
			// 
			this.cmbAcessoNovo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbAcessoNovo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbAcessoNovo.FormattingEnabled = true;
			this.cmbAcessoNovo.Location = new System.Drawing.Point(121, 55);
			this.cmbAcessoNovo.Margin = new System.Windows.Forms.Padding(6);
			this.cmbAcessoNovo.Name = "cmbAcessoNovo";
			this.cmbAcessoNovo.Size = new System.Drawing.Size(176, 27);
			this.cmbAcessoNovo.TabIndex = 3;
			// 
			// txtSenhaConfirmarNovo
			// 
			this.txtSenhaConfirmarNovo.BackColor = System.Drawing.Color.White;
			this.txtSenhaConfirmarNovo.Location = new System.Drawing.Point(372, 133);
			this.txtSenhaConfirmarNovo.Margin = new System.Windows.Forms.Padding(6);
			this.txtSenhaConfirmarNovo.MaxLength = 8;
			this.txtSenhaConfirmarNovo.Name = "txtSenhaConfirmarNovo";
			this.txtSenhaConfirmarNovo.PasswordChar = '*';
			this.txtSenhaConfirmarNovo.Size = new System.Drawing.Size(120, 27);
			this.txtSenhaConfirmarNovo.TabIndex = 9;
			// 
			// txtSenhaNovo
			// 
			this.txtSenhaNovo.BackColor = System.Drawing.Color.White;
			this.txtSenhaNovo.Location = new System.Drawing.Point(121, 133);
			this.txtSenhaNovo.Margin = new System.Windows.Forms.Padding(6);
			this.txtSenhaNovo.MaxLength = 8;
			this.txtSenhaNovo.Name = "txtSenhaNovo";
			this.txtSenhaNovo.PasswordChar = '*';
			this.txtSenhaNovo.Size = new System.Drawing.Size(120, 27);
			this.txtSenhaNovo.TabIndex = 7;
			// 
			// pnlAlterarAcesso
			// 
			this.pnlAlterarAcesso.Controls.Add(this.lblUsuarioAcessoAlterar);
			this.pnlAlterarAcesso.Controls.Add(this.lblNome);
			this.pnlAlterarAcesso.Controls.Add(this.label2);
			this.pnlAlterarAcesso.Controls.Add(this.cmbAcessoAlterar);
			this.pnlAlterarAcesso.Location = new System.Drawing.Point(18, 412);
			this.pnlAlterarAcesso.Name = "pnlAlterarAcesso";
			this.pnlAlterarAcesso.Size = new System.Drawing.Size(509, 97);
			this.pnlAlterarAcesso.TabIndex = 3;
			// 
			// lblUsuarioAcessoAlterar
			// 
			this.lblUsuarioAcessoAlterar.BackColor = System.Drawing.Color.Transparent;
			this.lblUsuarioAcessoAlterar.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUsuarioAcessoAlterar.ForeColor = System.Drawing.Color.Black;
			this.lblUsuarioAcessoAlterar.Location = new System.Drawing.Point(116, 13);
			this.lblUsuarioAcessoAlterar.Name = "lblUsuarioAcessoAlterar";
			this.lblUsuarioAcessoAlterar.Size = new System.Drawing.Size(388, 25);
			this.lblUsuarioAcessoAlterar.TabIndex = 1;
			this.lblUsuarioAcessoAlterar.Text = "Nome do Usuário";
			// 
			// pnlAlterarEmail
			// 
			this.pnlAlterarEmail.Controls.Add(this.txtEmailAlterar);
			this.pnlAlterarEmail.Controls.Add(this.label13);
			this.pnlAlterarEmail.Controls.Add(this.lblUsuarioEmailAlterar);
			this.pnlAlterarEmail.Controls.Add(this.label11);
			this.pnlAlterarEmail.Location = new System.Drawing.Point(18, 525);
			this.pnlAlterarEmail.Name = "pnlAlterarEmail";
			this.pnlAlterarEmail.Size = new System.Drawing.Size(509, 97);
			this.pnlAlterarEmail.TabIndex = 4;
			// 
			// txtEmailAlterar
			// 
			this.txtEmailAlterar.BackColor = System.Drawing.Color.White;
			this.txtEmailAlterar.Location = new System.Drawing.Point(121, 54);
			this.txtEmailAlterar.Margin = new System.Windows.Forms.Padding(6);
			this.txtEmailAlterar.MaxLength = 30;
			this.txtEmailAlterar.Name = "txtEmailAlterar";
			this.txtEmailAlterar.Size = new System.Drawing.Size(371, 27);
			this.txtEmailAlterar.TabIndex = 3;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.BackColor = System.Drawing.Color.Transparent;
			this.label13.ForeColor = System.Drawing.Color.Black;
			this.label13.Location = new System.Drawing.Point(67, 57);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(45, 19);
			this.label13.TabIndex = 2;
			this.label13.Text = "Email";
			// 
			// lblUsuarioEmailAlterar
			// 
			this.lblUsuarioEmailAlterar.BackColor = System.Drawing.Color.Transparent;
			this.lblUsuarioEmailAlterar.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUsuarioEmailAlterar.ForeColor = System.Drawing.Color.Black;
			this.lblUsuarioEmailAlterar.Location = new System.Drawing.Point(116, 13);
			this.lblUsuarioEmailAlterar.Name = "lblUsuarioEmailAlterar";
			this.lblUsuarioEmailAlterar.Size = new System.Drawing.Size(388, 25);
			this.lblUsuarioEmailAlterar.TabIndex = 1;
			this.lblUsuarioEmailAlterar.Text = "Nome do Usuário";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.Transparent;
			this.label11.ForeColor = System.Drawing.Color.Black;
			this.label11.Location = new System.Drawing.Point(51, 16);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(59, 19);
			this.label11.TabIndex = 0;
			this.label11.Text = "Usuário";
			// 
			// frmUsuario
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(549, 685);
			this.Controls.Add(this.pnlAlterarEmail);
			this.Controls.Add(this.pnlAlterarAcesso);
			this.Controls.Add(this.pnlNovoUsuario);
			this.Controls.Add(this.pnlAlterarSenha);
			this.Controls.Add(this.tspMenu);
			this.KeyPreview = true;
			this.Name = "frmUsuario";
			this.Load += new System.EventHandler(this.frmUsuario_Load);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.pnlAlterarSenha, 0);
			this.Controls.SetChildIndex(this.pnlNovoUsuario, 0);
			this.Controls.SetChildIndex(this.pnlAlterarAcesso, 0);
			this.Controls.SetChildIndex(this.pnlAlterarEmail, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			this.pnlAlterarSenha.ResumeLayout(false);
			this.pnlAlterarSenha.PerformLayout();
			this.pnlNovoUsuario.ResumeLayout(false);
			this.pnlNovoUsuario.PerformLayout();
			this.pnlAlterarAcesso.ResumeLayout(false);
			this.pnlAlterarAcesso.PerformLayout();
			this.pnlAlterarEmail.ResumeLayout(false);
			this.pnlAlterarEmail.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		internal System.Windows.Forms.Label lblNome;
		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label lbl_IdTexto;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.TextBox txtSenhaAntigaAlterar;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnSalvar;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		private System.Windows.Forms.ToolStripButton btnFechar;
		private CamadaUC.ucComboLimitedValues cmbAcessoAlterar;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.TextBox txtSenhaConfirmarAlterar;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TextBox txtSenhaNovaAlterar;
		private System.Windows.Forms.Panel pnlAlterarSenha;
		private System.Windows.Forms.Panel pnlNovoUsuario;
		internal System.Windows.Forms.Label label6;
		internal System.Windows.Forms.Label label7;
		internal System.Windows.Forms.TextBox txtSenhaConfirmarNovo;
		internal System.Windows.Forms.TextBox txtSenhaNovo;
		internal System.Windows.Forms.TextBox txtUsuarioNovo;
		internal System.Windows.Forms.Label label5;
		internal System.Windows.Forms.Label label8;
		private CamadaUC.ucComboLimitedValues cmbAcessoNovo;
		private System.Windows.Forms.Panel pnlAlterarAcesso;
		internal System.Windows.Forms.Label lblUsuarioAcessoAlterar;
		internal System.Windows.Forms.TextBox txtEmailNovo;
		internal System.Windows.Forms.Label label10;
		private System.Windows.Forms.Panel pnlAlterarEmail;
		internal System.Windows.Forms.TextBox txtEmailAlterar;
		internal System.Windows.Forms.Label label13;
		internal System.Windows.Forms.Label lblUsuarioEmailAlterar;
		internal System.Windows.Forms.Label label11;
		internal System.Windows.Forms.Label lblUsuarioSenhaAlterar;
		internal System.Windows.Forms.Label label12;
	}
}
