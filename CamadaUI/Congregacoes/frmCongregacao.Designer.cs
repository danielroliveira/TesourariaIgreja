namespace CamadaUI.Congregacoes
{
	partial class frmCongregacao
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCongregacao));
			this.txtCidade = new System.Windows.Forms.TextBox();
			this.txtUF = new System.Windows.Forms.TextBox();
			this.txtEnderecoLogradouro = new System.Windows.Forms.TextBox();
			this.Label16 = new System.Windows.Forms.Label();
			this.txtSetor = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.txtCEP = new System.Windows.Forms.MaskedTextBox();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label15 = new System.Windows.Forms.Label();
			this.Label10 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.txtTelefoneFixo = new CamadaUC.ucTelefone();
			this.txtTelefoneDirigente = new CamadaUC.ucTelefone();
			this.label1 = new System.Windows.Forms.Label();
			this.txtEnderecoNumero = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEnderecoComplemento = new System.Windows.Forms.TextBox();
			this.lblCongregacao = new System.Windows.Forms.Label();
			this.txtCongregacao = new System.Windows.Forms.TextBox();
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDirigente = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtTesoureiro = new System.Windows.Forms.TextBox();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnNovo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalvar = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnAtivo = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.btnSetorEscolher = new VIBlend.WinForms.Controls.vButton();
			this.label11 = new System.Windows.Forms.Label();
			this.txtBairro = new System.Windows.Forms.TextBox();
			this.line1 = new AwesomeShapeControl.Line();
			this.line2 = new AwesomeShapeControl.Line();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(261, 0);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "Congregação | Filiais";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(520, 0);
			this.btnClose.TabIndex = 3;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblID);
			this.panel1.Controls.Add(this.lbl_IdTexto);
			this.panel1.Size = new System.Drawing.Size(560, 50);
			this.panel1.Controls.SetChildIndex(this.btnClose, 0);
			this.panel1.Controls.SetChildIndex(this.lblTitulo, 0);
			this.panel1.Controls.SetChildIndex(this.lbl_IdTexto, 0);
			this.panel1.Controls.SetChildIndex(this.lblID, 0);
			// 
			// txtCidade
			// 
			this.txtCidade.BackColor = System.Drawing.Color.White;
			this.txtCidade.Location = new System.Drawing.Point(134, 306);
			this.txtCidade.MaxLength = 50;
			this.txtCidade.Name = "txtCidade";
			this.txtCidade.Size = new System.Drawing.Size(268, 27);
			this.txtCidade.TabIndex = 19;
			// 
			// txtUF
			// 
			this.txtUF.BackColor = System.Drawing.Color.White;
			this.txtUF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtUF.Location = new System.Drawing.Point(459, 309);
			this.txtUF.MaxLength = 2;
			this.txtUF.Name = "txtUF";
			this.txtUF.Size = new System.Drawing.Size(46, 27);
			this.txtUF.TabIndex = 21;
			// 
			// txtEnderecoLogradouro
			// 
			this.txtEnderecoLogradouro.BackColor = System.Drawing.Color.White;
			this.txtEnderecoLogradouro.Location = new System.Drawing.Point(134, 240);
			this.txtEnderecoLogradouro.Name = "txtEnderecoLogradouro";
			this.txtEnderecoLogradouro.Size = new System.Drawing.Size(268, 27);
			this.txtEnderecoLogradouro.TabIndex = 11;
			// 
			// Label16
			// 
			this.Label16.AutoSize = true;
			this.Label16.BackColor = System.Drawing.Color.Transparent;
			this.Label16.ForeColor = System.Drawing.Color.Black;
			this.Label16.Location = new System.Drawing.Point(76, 408);
			this.Label16.Name = "Label16";
			this.Label16.Size = new System.Drawing.Size(51, 19);
			this.Label16.TabIndex = 28;
			this.Label16.Text = "e-Mail";
			// 
			// txtSetor
			// 
			this.txtSetor.Location = new System.Drawing.Point(134, 191);
			this.txtSetor.MaxLength = 30;
			this.txtSetor.Name = "txtSetor";
			this.txtSetor.Size = new System.Drawing.Size(228, 27);
			this.txtSetor.TabIndex = 8;
			this.txtSetor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.BackColor = System.Drawing.Color.Transparent;
			this.Label6.ForeColor = System.Drawing.Color.Black;
			this.Label6.Location = new System.Drawing.Point(86, 194);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(42, 19);
			this.Label6.TabIndex = 7;
			this.Label6.Text = "Setor";
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(134, 405);
			this.txtEmail.MaxLength = 200;
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(371, 27);
			this.txtEmail.TabIndex = 29;
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.BackColor = System.Drawing.Color.Transparent;
			this.Label5.ForeColor = System.Drawing.Color.Black;
			this.Label5.Location = new System.Drawing.Point(58, 243);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(69, 19);
			this.Label5.TabIndex = 10;
			this.Label5.Text = "Endereço";
			// 
			// txtCEP
			// 
			this.txtCEP.Location = new System.Drawing.Point(134, 339);
			this.txtCEP.Mask = "00000-000";
			this.txtCEP.Name = "txtCEP";
			this.txtCEP.Size = new System.Drawing.Size(94, 27);
			this.txtCEP.TabIndex = 23;
			this.txtCEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// Label9
			// 
			this.Label9.AutoSize = true;
			this.Label9.BackColor = System.Drawing.Color.Transparent;
			this.Label9.ForeColor = System.Drawing.Color.Black;
			this.Label9.Location = new System.Drawing.Point(62, 375);
			this.Label9.Name = "Label9";
			this.Label9.Size = new System.Drawing.Size(65, 19);
			this.Label9.TabIndex = 24;
			this.Label9.Text = "Telefone";
			// 
			// Label15
			// 
			this.Label15.AutoSize = true;
			this.Label15.BackColor = System.Drawing.Color.Transparent;
			this.Label15.ForeColor = System.Drawing.Color.Black;
			this.Label15.Location = new System.Drawing.Point(93, 343);
			this.Label15.Name = "Label15";
			this.Label15.Size = new System.Drawing.Size(34, 19);
			this.Label15.TabIndex = 22;
			this.Label15.Text = "CEP";
			// 
			// Label10
			// 
			this.Label10.AutoSize = true;
			this.Label10.BackColor = System.Drawing.Color.Transparent;
			this.Label10.ForeColor = System.Drawing.Color.Black;
			this.Label10.Location = new System.Drawing.Point(299, 375);
			this.Label10.Name = "Label10";
			this.Label10.Size = new System.Drawing.Size(55, 19);
			this.Label10.TabIndex = 26;
			this.Label10.Text = "Celular";
			// 
			// Label8
			// 
			this.Label8.AutoSize = true;
			this.Label8.BackColor = System.Drawing.Color.Transparent;
			this.Label8.ForeColor = System.Drawing.Color.Black;
			this.Label8.Location = new System.Drawing.Point(425, 312);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(26, 19);
			this.Label8.TabIndex = 20;
			this.Label8.Text = "UF";
			// 
			// Label7
			// 
			this.Label7.AutoSize = true;
			this.Label7.BackColor = System.Drawing.Color.Transparent;
			this.Label7.ForeColor = System.Drawing.Color.Black;
			this.Label7.Location = new System.Drawing.Point(73, 309);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(54, 19);
			this.Label7.TabIndex = 18;
			this.Label7.Text = "Cidade";
			// 
			// txtTelefoneFixo
			// 
			this.txtTelefoneFixo.Location = new System.Drawing.Point(134, 372);
			this.txtTelefoneFixo.Mask = "(99) 99000-0000";
			this.txtTelefoneFixo.Name = "txtTelefoneFixo";
			this.txtTelefoneFixo.Size = new System.Drawing.Size(144, 27);
			this.txtTelefoneFixo.TabIndex = 25;
			// 
			// txtTelefoneDirigente
			// 
			this.txtTelefoneDirigente.Location = new System.Drawing.Point(361, 372);
			this.txtTelefoneDirigente.Mask = "(99) 99000-0000";
			this.txtTelefoneDirigente.Name = "txtTelefoneDirigente";
			this.txtTelefoneDirigente.Size = new System.Drawing.Size(144, 27);
			this.txtTelefoneDirigente.TabIndex = 27;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(413, 243);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(24, 19);
			this.label1.TabIndex = 12;
			this.label1.Text = "nº";
			// 
			// txtEnderecoNumero
			// 
			this.txtEnderecoNumero.BackColor = System.Drawing.Color.White;
			this.txtEnderecoNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtEnderecoNumero.Location = new System.Drawing.Point(443, 240);
			this.txtEnderecoNumero.MaxLength = 8;
			this.txtEnderecoNumero.Name = "txtEnderecoNumero";
			this.txtEnderecoNumero.Size = new System.Drawing.Size(62, 27);
			this.txtEnderecoNumero.TabIndex = 13;
			this.txtEnderecoNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEnderecoNumero_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(28, 276);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(99, 19);
			this.label2.TabIndex = 14;
			this.label2.Text = "Complemento";
			// 
			// txtEnderecoComplemento
			// 
			this.txtEnderecoComplemento.BackColor = System.Drawing.Color.White;
			this.txtEnderecoComplemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtEnderecoComplemento.Location = new System.Drawing.Point(134, 273);
			this.txtEnderecoComplemento.MaxLength = 20;
			this.txtEnderecoComplemento.Name = "txtEnderecoComplemento";
			this.txtEnderecoComplemento.Size = new System.Drawing.Size(104, 27);
			this.txtEnderecoComplemento.TabIndex = 15;
			// 
			// lblCongregacao
			// 
			this.lblCongregacao.AutoSize = true;
			this.lblCongregacao.BackColor = System.Drawing.Color.Transparent;
			this.lblCongregacao.ForeColor = System.Drawing.Color.Black;
			this.lblCongregacao.Location = new System.Drawing.Point(33, 77);
			this.lblCongregacao.Name = "lblCongregacao";
			this.lblCongregacao.Size = new System.Drawing.Size(94, 19);
			this.lblCongregacao.TabIndex = 1;
			this.lblCongregacao.Text = "Congregação";
			// 
			// txtCongregacao
			// 
			this.txtCongregacao.BackColor = System.Drawing.Color.White;
			this.txtCongregacao.Location = new System.Drawing.Point(134, 74);
			this.txtCongregacao.MaxLength = 100;
			this.txtCongregacao.Name = "txtCongregacao";
			this.txtCongregacao.Size = new System.Drawing.Size(371, 27);
			this.txtCongregacao.TabIndex = 2;
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
			this.label3.Location = new System.Drawing.Point(58, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 19);
			this.label3.TabIndex = 3;
			this.label3.Text = "Dirigente";
			// 
			// txtDirigente
			// 
			this.txtDirigente.BackColor = System.Drawing.Color.White;
			this.txtDirigente.Location = new System.Drawing.Point(134, 125);
			this.txtDirigente.MaxLength = 50;
			this.txtDirigente.Name = "txtDirigente";
			this.txtDirigente.Size = new System.Drawing.Size(268, 27);
			this.txtDirigente.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(50, 161);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 19);
			this.label4.TabIndex = 5;
			this.label4.Text = "Tesoureiro";
			// 
			// txtTesoureiro
			// 
			this.txtTesoureiro.BackColor = System.Drawing.Color.White;
			this.txtTesoureiro.Location = new System.Drawing.Point(134, 158);
			this.txtTesoureiro.MaxLength = 50;
			this.txtTesoureiro.Name = "txtTesoureiro";
			this.txtTesoureiro.Size = new System.Drawing.Size(268, 27);
			this.txtTesoureiro.TabIndex = 6;
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
            this.btnNovo,
            this.toolStripSeparator1,
            this.btnSalvar,
            this.btnCancelar,
            this.toolStripSeparator2,
            this.btnAtivo,
            this.btnFechar});
			this.tspMenu.Location = new System.Drawing.Point(2, 457);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(555, 44);
			this.tspMenu.TabIndex = 30;
			this.tspMenu.TabStop = true;
			this.tspMenu.Text = "toolStrip1";
			// 
			// btnNovo
			// 
			this.btnNovo.Image = global::CamadaUI.Properties.Resources.adicionar_30;
			this.btnNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNovo.Name = "btnNovo";
			this.btnNovo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnNovo.Size = new System.Drawing.Size(86, 41);
			this.btnNovo.Text = "&Nova";
			this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 44);
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
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 44);
			// 
			// btnAtivo
			// 
			this.btnAtivo.Image = ((System.Drawing.Image)(resources.GetObject("btnAtivo.Image")));
			this.btnAtivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnAtivo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAtivo.Name = "btnAtivo";
			this.btnAtivo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnAtivo.Size = new System.Drawing.Size(96, 41);
			this.btnAtivo.Text = "&Ativa";
			this.btnAtivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAtivo.Click += new System.EventHandler(this.btnAtivo_Click);
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
			// btnSetorEscolher
			// 
			this.btnSetorEscolher.AllowAnimations = true;
			this.btnSetorEscolher.BackColor = System.Drawing.Color.Transparent;
			this.btnSetorEscolher.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetorEscolher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetorEscolher.Location = new System.Drawing.Point(368, 191);
			this.btnSetorEscolher.Name = "btnSetorEscolher";
			this.btnSetorEscolher.RoundedCornersMask = ((byte)(15));
			this.btnSetorEscolher.RoundedCornersRadius = 0;
			this.btnSetorEscolher.Size = new System.Drawing.Size(34, 27);
			this.btnSetorEscolher.TabIndex = 9;
			this.btnSetorEscolher.TabStop = false;
			this.btnSetorEscolher.Text = "...";
			this.btnSetorEscolher.UseCompatibleTextRendering = true;
			this.btnSetorEscolher.UseVisualStyleBackColor = false;
			this.btnSetorEscolher.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetorEscolher.Click += new System.EventHandler(this.btnSetorEscolher_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.Transparent;
			this.label11.ForeColor = System.Drawing.Color.Black;
			this.label11.Location = new System.Drawing.Point(244, 276);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 19);
			this.label11.TabIndex = 16;
			this.label11.Text = "Bairro";
			// 
			// txtBairro
			// 
			this.txtBairro.Location = new System.Drawing.Point(298, 273);
			this.txtBairro.MaxLength = 30;
			this.txtBairro.Name = "txtBairro";
			this.txtBairro.Size = new System.Drawing.Size(207, 27);
			this.txtBairro.TabIndex = 17;
			// 
			// line1
			// 
			this.line1.EndPoint = new System.Drawing.Point(495, 5);
			this.line1.LineColor = System.Drawing.Color.SlateGray;
			this.line1.LineWidth = 3F;
			this.line1.Location = new System.Drawing.Point(25, 107);
			this.line1.Name = "line1";
			this.line1.Size = new System.Drawing.Size(500, 10);
			this.line1.StartPoint = new System.Drawing.Point(5, 5);
			this.line1.TabIndex = 31;
			this.line1.TabStop = false;
			// 
			// line2
			// 
			this.line2.EndPoint = new System.Drawing.Point(495, 5);
			this.line2.LineColor = System.Drawing.Color.SlateGray;
			this.line2.LineWidth = 3F;
			this.line2.Location = new System.Drawing.Point(25, 224);
			this.line2.Name = "line2";
			this.line2.Size = new System.Drawing.Size(500, 10);
			this.line2.StartPoint = new System.Drawing.Point(5, 5);
			this.line2.TabIndex = 31;
			this.line2.TabStop = false;
			// 
			// frmCongregacao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(560, 503);
			this.Controls.Add(this.line2);
			this.Controls.Add(this.line1);
			this.Controls.Add(this.btnSetorEscolher);
			this.Controls.Add(this.tspMenu);
			this.Controls.Add(this.txtTelefoneDirigente);
			this.Controls.Add(this.txtTelefoneFixo);
			this.Controls.Add(this.txtCidade);
			this.Controls.Add(this.txtEnderecoNumero);
			this.Controls.Add(this.txtCongregacao);
			this.Controls.Add(this.txtTesoureiro);
			this.Controls.Add(this.txtDirigente);
			this.Controls.Add(this.txtEnderecoLogradouro);
			this.Controls.Add(this.txtEnderecoComplemento);
			this.Controls.Add(this.Label7);
			this.Controls.Add(this.txtUF);
			this.Controls.Add(this.Label8);
			this.Controls.Add(this.Label10);
			this.Controls.Add(this.Label16);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtBairro);
			this.Controls.Add(this.txtSetor);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.Label15);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblCongregacao);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.Label9);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.txtCEP);
			this.KeyPreview = true;
			this.Name = "frmCongregacao";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmCongregacao_KeyPress);
			this.Controls.SetChildIndex(this.txtCEP, 0);
			this.Controls.SetChildIndex(this.Label5, 0);
			this.Controls.SetChildIndex(this.Label9, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.lblCongregacao, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.txtEmail, 0);
			this.Controls.SetChildIndex(this.Label15, 0);
			this.Controls.SetChildIndex(this.Label6, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label11, 0);
			this.Controls.SetChildIndex(this.txtSetor, 0);
			this.Controls.SetChildIndex(this.txtBairro, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.Label16, 0);
			this.Controls.SetChildIndex(this.Label10, 0);
			this.Controls.SetChildIndex(this.Label8, 0);
			this.Controls.SetChildIndex(this.txtUF, 0);
			this.Controls.SetChildIndex(this.Label7, 0);
			this.Controls.SetChildIndex(this.txtEnderecoComplemento, 0);
			this.Controls.SetChildIndex(this.txtEnderecoLogradouro, 0);
			this.Controls.SetChildIndex(this.txtDirigente, 0);
			this.Controls.SetChildIndex(this.txtTesoureiro, 0);
			this.Controls.SetChildIndex(this.txtCongregacao, 0);
			this.Controls.SetChildIndex(this.txtEnderecoNumero, 0);
			this.Controls.SetChildIndex(this.txtCidade, 0);
			this.Controls.SetChildIndex(this.txtTelefoneFixo, 0);
			this.Controls.SetChildIndex(this.txtTelefoneDirigente, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.btnSetorEscolher, 0);
			this.Controls.SetChildIndex(this.line1, 0);
			this.Controls.SetChildIndex(this.line2, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private CamadaUC.ucTelefone txtTelefoneFixo;
		internal System.Windows.Forms.TextBox txtCidade;
		internal System.Windows.Forms.TextBox txtUF;
		internal System.Windows.Forms.TextBox txtEnderecoLogradouro;
		internal System.Windows.Forms.Label Label16;
		internal System.Windows.Forms.TextBox txtSetor;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.TextBox txtEmail;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.MaskedTextBox txtCEP;
		internal System.Windows.Forms.Label Label9;
		internal System.Windows.Forms.Label Label15;
		internal System.Windows.Forms.Label Label10;
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.Label Label7;
		private CamadaUC.ucTelefone txtTelefoneDirigente;
		internal System.Windows.Forms.TextBox txtEnderecoNumero;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.TextBox txtEnderecoComplemento;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.Label lblCongregacao;
		internal System.Windows.Forms.TextBox txtCongregacao;
		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label lbl_IdTexto;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.TextBox txtDirigente;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TextBox txtTesoureiro;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnNovo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnSalvar;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnAtivo;
		private System.Windows.Forms.ToolStripButton btnFechar;
		internal VIBlend.WinForms.Controls.vButton btnSetorEscolher;
		internal System.Windows.Forms.Label label11;
		internal System.Windows.Forms.TextBox txtBairro;
		private AwesomeShapeControl.Line line1;
		private AwesomeShapeControl.Line line2;
	}
}
