namespace CamadaUI.Registres
{
	partial class frmCredor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCredor));
			this.txtCidade = new System.Windows.Forms.TextBox();
			this.txtUF = new System.Windows.Forms.TextBox();
			this.txtEnderecoLogradouro = new System.Windows.Forms.TextBox();
			this.Label16 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.txtCEP = new System.Windows.Forms.MaskedTextBox();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label15 = new System.Windows.Forms.Label();
			this.Label10 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.txtTelefoneFixo = new CamadaUC.ucTelefone();
			this.txtTelefoneCelular = new CamadaUC.ucTelefone();
			this.label1 = new System.Windows.Forms.Label();
			this.txtEnderecoNumero = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEnderecoComplemento = new System.Windows.Forms.TextBox();
			this.lblCongregacao = new System.Windows.Forms.Label();
			this.txtCredor = new System.Windows.Forms.TextBox();
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.lblCNP = new System.Windows.Forms.Label();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnNovo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalvar = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnAtivo = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.label11 = new System.Windows.Forms.Label();
			this.txtBairro = new System.Windows.Forms.TextBox();
			this.line1 = new AwesomeShapeControl.Line();
			this.line2 = new AwesomeShapeControl.Line();
			this.cmbCredorTipo = new CamadaUC.ucComboLimitedValues();
			this.label4 = new System.Windows.Forms.Label();
			this.pnlChk = new System.Windows.Forms.Panel();
			this.picWathsapp = new System.Windows.Forms.PictureBox();
			this.chkWhatsapp = new System.Windows.Forms.CheckBox();
			this.txtCNP = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.pnlChk.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picWathsapp)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(298, 0);
			this.lblTitulo.Size = new System.Drawing.Size(222, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "Cadastro de Credor";
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
			this.txtCidade.Location = new System.Drawing.Point(148, 299);
			this.txtCidade.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCidade.MaxLength = 50;
			this.txtCidade.Name = "txtCidade";
			this.txtCidade.Size = new System.Drawing.Size(268, 27);
			this.txtCidade.TabIndex = 16;
			// 
			// txtUF
			// 
			this.txtUF.BackColor = System.Drawing.Color.White;
			this.txtUF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtUF.Location = new System.Drawing.Point(473, 302);
			this.txtUF.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtUF.MaxLength = 2;
			this.txtUF.Name = "txtUF";
			this.txtUF.Size = new System.Drawing.Size(46, 27);
			this.txtUF.TabIndex = 18;
			// 
			// txtEnderecoLogradouro
			// 
			this.txtEnderecoLogradouro.BackColor = System.Drawing.Color.White;
			this.txtEnderecoLogradouro.Location = new System.Drawing.Point(148, 221);
			this.txtEnderecoLogradouro.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtEnderecoLogradouro.Name = "txtEnderecoLogradouro";
			this.txtEnderecoLogradouro.Size = new System.Drawing.Size(268, 27);
			this.txtEnderecoLogradouro.TabIndex = 8;
			// 
			// Label16
			// 
			this.Label16.AutoSize = true;
			this.Label16.BackColor = System.Drawing.Color.Transparent;
			this.Label16.ForeColor = System.Drawing.Color.Black;
			this.Label16.Location = new System.Drawing.Point(90, 419);
			this.Label16.Name = "Label16";
			this.Label16.Size = new System.Drawing.Size(51, 19);
			this.Label16.TabIndex = 26;
			this.Label16.Text = "e-Mail";
			// 
			// txtEmail
			// 
			this.txtEmail.BackColor = System.Drawing.Color.White;
			this.txtEmail.Location = new System.Drawing.Point(148, 416);
			this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtEmail.MaxLength = 200;
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(371, 27);
			this.txtEmail.TabIndex = 27;
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.BackColor = System.Drawing.Color.Transparent;
			this.Label5.ForeColor = System.Drawing.Color.Black;
			this.Label5.Location = new System.Drawing.Point(72, 224);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(69, 19);
			this.Label5.TabIndex = 7;
			this.Label5.Text = "Endereço";
			// 
			// txtCEP
			// 
			this.txtCEP.BackColor = System.Drawing.Color.White;
			this.txtCEP.Location = new System.Drawing.Point(148, 338);
			this.txtCEP.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCEP.Mask = "00000-000";
			this.txtCEP.Name = "txtCEP";
			this.txtCEP.Size = new System.Drawing.Size(94, 27);
			this.txtCEP.TabIndex = 20;
			this.txtCEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// Label9
			// 
			this.Label9.AutoSize = true;
			this.Label9.BackColor = System.Drawing.Color.Transparent;
			this.Label9.ForeColor = System.Drawing.Color.Black;
			this.Label9.Location = new System.Drawing.Point(76, 380);
			this.Label9.Name = "Label9";
			this.Label9.Size = new System.Drawing.Size(65, 19);
			this.Label9.TabIndex = 21;
			this.Label9.Text = "Telefone";
			// 
			// Label15
			// 
			this.Label15.AutoSize = true;
			this.Label15.BackColor = System.Drawing.Color.Transparent;
			this.Label15.ForeColor = System.Drawing.Color.Black;
			this.Label15.Location = new System.Drawing.Point(107, 342);
			this.Label15.Name = "Label15";
			this.Label15.Size = new System.Drawing.Size(34, 19);
			this.Label15.TabIndex = 19;
			this.Label15.Text = "CEP";
			// 
			// Label10
			// 
			this.Label10.AutoSize = true;
			this.Label10.BackColor = System.Drawing.Color.Transparent;
			this.Label10.ForeColor = System.Drawing.Color.Black;
			this.Label10.Location = new System.Drawing.Point(280, 380);
			this.Label10.Name = "Label10";
			this.Label10.Size = new System.Drawing.Size(55, 19);
			this.Label10.TabIndex = 23;
			this.Label10.Text = "Celular";
			// 
			// Label8
			// 
			this.Label8.AutoSize = true;
			this.Label8.BackColor = System.Drawing.Color.Transparent;
			this.Label8.ForeColor = System.Drawing.Color.Black;
			this.Label8.Location = new System.Drawing.Point(439, 305);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(26, 19);
			this.Label8.TabIndex = 17;
			this.Label8.Text = "UF";
			// 
			// Label7
			// 
			this.Label7.AutoSize = true;
			this.Label7.BackColor = System.Drawing.Color.Transparent;
			this.Label7.ForeColor = System.Drawing.Color.Black;
			this.Label7.Location = new System.Drawing.Point(87, 302);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(54, 19);
			this.Label7.TabIndex = 15;
			this.Label7.Text = "Cidade";
			// 
			// txtTelefoneFixo
			// 
			this.txtTelefoneFixo.BackColor = System.Drawing.Color.White;
			this.txtTelefoneFixo.Location = new System.Drawing.Point(148, 377);
			this.txtTelefoneFixo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtTelefoneFixo.Mask = "(99) 99000-0000";
			this.txtTelefoneFixo.Name = "txtTelefoneFixo";
			this.txtTelefoneFixo.Size = new System.Drawing.Size(125, 27);
			this.txtTelefoneFixo.TabIndex = 22;
			// 
			// txtTelefoneCelular
			// 
			this.txtTelefoneCelular.BackColor = System.Drawing.Color.White;
			this.txtTelefoneCelular.Location = new System.Drawing.Point(342, 377);
			this.txtTelefoneCelular.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtTelefoneCelular.Mask = "(99) 99000-0000";
			this.txtTelefoneCelular.Name = "txtTelefoneCelular";
			this.txtTelefoneCelular.Size = new System.Drawing.Size(125, 27);
			this.txtTelefoneCelular.TabIndex = 24;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(427, 224);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(24, 19);
			this.label1.TabIndex = 9;
			this.label1.Text = "nº";
			// 
			// txtEnderecoNumero
			// 
			this.txtEnderecoNumero.BackColor = System.Drawing.Color.White;
			this.txtEnderecoNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtEnderecoNumero.Location = new System.Drawing.Point(457, 221);
			this.txtEnderecoNumero.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtEnderecoNumero.MaxLength = 8;
			this.txtEnderecoNumero.Name = "txtEnderecoNumero";
			this.txtEnderecoNumero.Size = new System.Drawing.Size(62, 27);
			this.txtEnderecoNumero.TabIndex = 10;
			this.txtEnderecoNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoNumeros_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(42, 263);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(99, 19);
			this.label2.TabIndex = 11;
			this.label2.Text = "Complemento";
			// 
			// txtEnderecoComplemento
			// 
			this.txtEnderecoComplemento.BackColor = System.Drawing.Color.White;
			this.txtEnderecoComplemento.Location = new System.Drawing.Point(148, 260);
			this.txtEnderecoComplemento.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtEnderecoComplemento.MaxLength = 20;
			this.txtEnderecoComplemento.Name = "txtEnderecoComplemento";
			this.txtEnderecoComplemento.Size = new System.Drawing.Size(104, 27);
			this.txtEnderecoComplemento.TabIndex = 12;
			// 
			// lblCongregacao
			// 
			this.lblCongregacao.AutoSize = true;
			this.lblCongregacao.BackColor = System.Drawing.Color.Transparent;
			this.lblCongregacao.ForeColor = System.Drawing.Color.Black;
			this.lblCongregacao.Location = new System.Drawing.Point(90, 74);
			this.lblCongregacao.Name = "lblCongregacao";
			this.lblCongregacao.Size = new System.Drawing.Size(52, 19);
			this.lblCongregacao.TabIndex = 1;
			this.lblCongregacao.Text = "Credor";
			// 
			// txtCredor
			// 
			this.txtCredor.BackColor = System.Drawing.Color.White;
			this.txtCredor.Location = new System.Drawing.Point(149, 71);
			this.txtCredor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCredor.MaxLength = 100;
			this.txtCredor.Name = "txtCredor";
			this.txtCredor.Size = new System.Drawing.Size(371, 27);
			this.txtCredor.TabIndex = 2;
			// 
			// lblID
			// 
			this.lblID.BackColor = System.Drawing.Color.Transparent;
			this.lblID.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblID.ForeColor = System.Drawing.Color.AliceBlue;
			this.lblID.Location = new System.Drawing.Point(4, 17);
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
			this.lbl_IdTexto.Location = new System.Drawing.Point(31, 4);
			this.lbl_IdTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbl_IdTexto.Name = "lbl_IdTexto";
			this.lbl_IdTexto.Size = new System.Drawing.Size(35, 13);
			this.lbl_IdTexto.TabIndex = 1;
			this.lbl_IdTexto.Text = "Reg.";
			this.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblCNP
			// 
			this.lblCNP.AutoSize = true;
			this.lblCNP.BackColor = System.Drawing.Color.Transparent;
			this.lblCNP.ForeColor = System.Drawing.Color.Black;
			this.lblCNP.Location = new System.Drawing.Point(105, 168);
			this.lblCNP.Name = "lblCNP";
			this.lblCNP.Size = new System.Drawing.Size(36, 19);
			this.lblCNP.TabIndex = 5;
			this.lblCNP.Text = "CNP";
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
			this.tspMenu.Location = new System.Drawing.Point(2, 464);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(555, 44);
			this.tspMenu.TabIndex = 28;
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
			this.btnNovo.Text = "&Novo";
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
			this.btnAtivo.Text = "&Ativo";
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
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.Transparent;
			this.label11.ForeColor = System.Drawing.Color.Black;
			this.label11.Location = new System.Drawing.Point(258, 263);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 19);
			this.label11.TabIndex = 13;
			this.label11.Text = "Bairro";
			// 
			// txtBairro
			// 
			this.txtBairro.BackColor = System.Drawing.Color.White;
			this.txtBairro.Location = new System.Drawing.Point(312, 260);
			this.txtBairro.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtBairro.MaxLength = 30;
			this.txtBairro.Name = "txtBairro";
			this.txtBairro.Size = new System.Drawing.Size(207, 27);
			this.txtBairro.TabIndex = 14;
			// 
			// line1
			// 
			this.line1.EndPoint = new System.Drawing.Point(508, 5);
			this.line1.LineColor = System.Drawing.Color.SlateGray;
			this.line1.LineWidth = 3F;
			this.line1.Location = new System.Drawing.Point(30, 107);
			this.line1.Name = "line1";
			this.line1.Size = new System.Drawing.Size(513, 10);
			this.line1.StartPoint = new System.Drawing.Point(5, 5);
			this.line1.TabIndex = 29;
			this.line1.TabStop = false;
			// 
			// line2
			// 
			this.line2.EndPoint = new System.Drawing.Point(505, 5);
			this.line2.LineColor = System.Drawing.Color.SlateGray;
			this.line2.LineWidth = 3F;
			this.line2.Location = new System.Drawing.Point(30, 202);
			this.line2.Name = "line2";
			this.line2.Size = new System.Drawing.Size(510, 10);
			this.line2.StartPoint = new System.Drawing.Point(5, 5);
			this.line2.TabIndex = 30;
			this.line2.TabStop = false;
			// 
			// cmbCredorTipo
			// 
			this.cmbCredorTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbCredorTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbCredorTipo.FormattingEnabled = true;
			this.cmbCredorTipo.Location = new System.Drawing.Point(148, 126);
			this.cmbCredorTipo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.cmbCredorTipo.Name = "cmbCredorTipo";
			this.cmbCredorTipo.Size = new System.Drawing.Size(177, 27);
			this.cmbCredorTipo.TabIndex = 4;
			this.cmbCredorTipo.SelectionChangeCommitted += new System.EventHandler(this.cmbCredorTipo_SelectionChangeCommitted);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(37, 129);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 19);
			this.label4.TabIndex = 3;
			this.label4.Text = "Tipo de Credor";
			// 
			// pnlChk
			// 
			this.pnlChk.BackColor = System.Drawing.Color.Transparent;
			this.pnlChk.CausesValidation = false;
			this.pnlChk.Controls.Add(this.picWathsapp);
			this.pnlChk.Controls.Add(this.chkWhatsapp);
			this.pnlChk.Location = new System.Drawing.Point(472, 374);
			this.pnlChk.Name = "pnlChk";
			this.pnlChk.Size = new System.Drawing.Size(55, 32);
			this.pnlChk.TabIndex = 25;
			this.pnlChk.TabStop = true;
			// 
			// picWathsapp
			// 
			this.picWathsapp.Image = global::CamadaUI.Properties.Resources.whatsapp_32;
			this.picWathsapp.Location = new System.Drawing.Point(3, 3);
			this.picWathsapp.Name = "picWathsapp";
			this.picWathsapp.Size = new System.Drawing.Size(25, 25);
			this.picWathsapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picWathsapp.TabIndex = 46;
			this.picWathsapp.TabStop = false;
			this.picWathsapp.Click += new System.EventHandler(this.picWathsapp_Click);
			// 
			// chkWhatsapp
			// 
			this.chkWhatsapp.AutoSize = true;
			this.chkWhatsapp.Location = new System.Drawing.Point(33, 9);
			this.chkWhatsapp.Name = "chkWhatsapp";
			this.chkWhatsapp.Size = new System.Drawing.Size(15, 14);
			this.chkWhatsapp.TabIndex = 0;
			this.chkWhatsapp.UseVisualStyleBackColor = true;
			// 
			// txtCNP
			// 
			this.txtCNP.BackColor = System.Drawing.Color.White;
			this.txtCNP.Location = new System.Drawing.Point(148, 165);
			this.txtCNP.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCNP.MaxLength = 14;
			this.txtCNP.Name = "txtCNP";
			this.txtCNP.Size = new System.Drawing.Size(177, 27);
			this.txtCNP.TabIndex = 6;
			this.txtCNP.Leave += new System.EventHandler(this.txtCNP_Leave);
			// 
			// frmCredor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(560, 510);
			this.Controls.Add(this.txtCNP);
			this.Controls.Add(this.pnlChk);
			this.Controls.Add(this.cmbCredorTipo);
			this.Controls.Add(this.line2);
			this.Controls.Add(this.line1);
			this.Controls.Add(this.tspMenu);
			this.Controls.Add(this.txtTelefoneCelular);
			this.Controls.Add(this.txtTelefoneFixo);
			this.Controls.Add(this.txtCidade);
			this.Controls.Add(this.txtEnderecoNumero);
			this.Controls.Add(this.txtCredor);
			this.Controls.Add(this.txtEnderecoLogradouro);
			this.Controls.Add(this.txtEnderecoComplemento);
			this.Controls.Add(this.Label7);
			this.Controls.Add(this.txtUF);
			this.Controls.Add(this.Label8);
			this.Controls.Add(this.Label10);
			this.Controls.Add(this.Label16);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtBairro);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Label15);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this.lblCongregacao);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblCNP);
			this.Controls.Add(this.Label9);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.txtCEP);
			this.KeyPreview = true;
			this.Name = "frmCredor";
			this.Activated += new System.EventHandler(this.form_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_FormClosed);
			this.Controls.SetChildIndex(this.txtCEP, 0);
			this.Controls.SetChildIndex(this.Label5, 0);
			this.Controls.SetChildIndex(this.Label9, 0);
			this.Controls.SetChildIndex(this.lblCNP, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.lblCongregacao, 0);
			this.Controls.SetChildIndex(this.txtEmail, 0);
			this.Controls.SetChildIndex(this.Label15, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label11, 0);
			this.Controls.SetChildIndex(this.txtBairro, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.Label16, 0);
			this.Controls.SetChildIndex(this.Label10, 0);
			this.Controls.SetChildIndex(this.Label8, 0);
			this.Controls.SetChildIndex(this.txtUF, 0);
			this.Controls.SetChildIndex(this.Label7, 0);
			this.Controls.SetChildIndex(this.txtEnderecoComplemento, 0);
			this.Controls.SetChildIndex(this.txtEnderecoLogradouro, 0);
			this.Controls.SetChildIndex(this.txtCredor, 0);
			this.Controls.SetChildIndex(this.txtEnderecoNumero, 0);
			this.Controls.SetChildIndex(this.txtCidade, 0);
			this.Controls.SetChildIndex(this.txtTelefoneFixo, 0);
			this.Controls.SetChildIndex(this.txtTelefoneCelular, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.line1, 0);
			this.Controls.SetChildIndex(this.line2, 0);
			this.Controls.SetChildIndex(this.cmbCredorTipo, 0);
			this.Controls.SetChildIndex(this.pnlChk, 0);
			this.Controls.SetChildIndex(this.txtCNP, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			this.pnlChk.ResumeLayout(false);
			this.pnlChk.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picWathsapp)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private CamadaUC.ucTelefone txtTelefoneFixo;
		internal System.Windows.Forms.TextBox txtCidade;
		internal System.Windows.Forms.TextBox txtUF;
		internal System.Windows.Forms.TextBox txtEnderecoLogradouro;
		internal System.Windows.Forms.Label Label16;
		internal System.Windows.Forms.TextBox txtEmail;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.MaskedTextBox txtCEP;
		internal System.Windows.Forms.Label Label9;
		internal System.Windows.Forms.Label Label15;
		internal System.Windows.Forms.Label Label10;
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.Label Label7;
		private CamadaUC.ucTelefone txtTelefoneCelular;
		internal System.Windows.Forms.TextBox txtEnderecoNumero;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.TextBox txtEnderecoComplemento;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.Label lblCongregacao;
		internal System.Windows.Forms.TextBox txtCredor;
		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label lbl_IdTexto;
		internal System.Windows.Forms.Label lblCNP;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnNovo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnSalvar;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnAtivo;
		private System.Windows.Forms.ToolStripButton btnFechar;
		internal System.Windows.Forms.Label label11;
		internal System.Windows.Forms.TextBox txtBairro;
		private AwesomeShapeControl.Line line1;
		private AwesomeShapeControl.Line line2;
		private CamadaUC.ucComboLimitedValues cmbCredorTipo;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.Panel pnlChk;
		internal System.Windows.Forms.PictureBox picWathsapp;
		internal System.Windows.Forms.CheckBox chkWhatsapp;
		private System.Windows.Forms.TextBox txtCNP;
	}
}
