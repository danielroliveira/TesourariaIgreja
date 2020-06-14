namespace CamadaUI.Entradas
{
	partial class frmContribuicao
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
			this.lblCongregacao = new System.Windows.Forms.Label();
			this.txtOrigemDescricao = new System.Windows.Forms.TextBox();
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnNovo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalvar = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.line1 = new AwesomeShapeControl.Line();
			this.btnSetContribuinte = new VIBlend.WinForms.Controls.vButton();
			this.txtContribuinte = new System.Windows.Forms.TextBox();
			this.lblContribuinte = new System.Windows.Forms.Label();
			this.txtValorBruto = new CamadaUC.ucOnlyNumbers();
			this.label2 = new System.Windows.Forms.Label();
			this.txtContribuicaoTipo = new System.Windows.Forms.TextBox();
			this.btnSetEntradaTipo = new VIBlend.WinForms.Controls.vButton();
			this.label3 = new System.Windows.Forms.Label();
			this.txtSetor = new System.Windows.Forms.TextBox();
			this.btnSetSetor = new VIBlend.WinForms.Controls.vButton();
			this.label4 = new System.Windows.Forms.Label();
			this.txtConta = new System.Windows.Forms.TextBox();
			this.btnSetConta = new VIBlend.WinForms.Controls.vButton();
			this.lblReuniao = new System.Windows.Forms.Label();
			this.txtReuniao = new System.Windows.Forms.TextBox();
			this.btnSetReuniao = new VIBlend.WinForms.Controls.vButton();
			this.lblCampanha = new System.Windows.Forms.Label();
			this.txtCampanha = new System.Windows.Forms.TextBox();
			this.btnSetCampanha = new VIBlend.WinForms.Controls.vButton();
			this.label8 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtEntradaForma = new System.Windows.Forms.TextBox();
			this.btnSetEntradaForma = new VIBlend.WinForms.Controls.vButton();
			this.cmbEntradaMes = new CamadaUC.ucComboLimitedValues();
			this.numEntradaAno = new System.Windows.Forms.NumericUpDown();
			this.numEntradaDia = new System.Windows.Forms.NumericUpDown();
			this.line2 = new AwesomeShapeControl.Line();
			this.lblSitBlock = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numEntradaAno)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numEntradaDia)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(286, 0);
			this.lblTitulo.Size = new System.Drawing.Size(279, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "Cadastro de Contribuição";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(565, 0);
			this.btnClose.TabIndex = 3;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblID);
			this.panel1.Controls.Add(this.lbl_IdTexto);
			this.panel1.Size = new System.Drawing.Size(605, 50);
			this.panel1.Controls.SetChildIndex(this.btnClose, 0);
			this.panel1.Controls.SetChildIndex(this.lblTitulo, 0);
			this.panel1.Controls.SetChildIndex(this.lbl_IdTexto, 0);
			this.panel1.Controls.SetChildIndex(this.lblID, 0);
			// 
			// lblCongregacao
			// 
			this.lblCongregacao.AutoSize = true;
			this.lblCongregacao.BackColor = System.Drawing.Color.Transparent;
			this.lblCongregacao.ForeColor = System.Drawing.Color.Black;
			this.lblCongregacao.Location = new System.Drawing.Point(47, 505);
			this.lblCongregacao.Name = "lblCongregacao";
			this.lblCongregacao.Size = new System.Drawing.Size(73, 19);
			this.lblCongregacao.TabIndex = 30;
			this.lblCongregacao.Text = "Descrição";
			// 
			// txtOrigemDescricao
			// 
			this.txtOrigemDescricao.BackColor = System.Drawing.Color.White;
			this.txtOrigemDescricao.Location = new System.Drawing.Point(126, 502);
			this.txtOrigemDescricao.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtOrigemDescricao.MaxLength = 200;
			this.txtOrigemDescricao.Multiline = true;
			this.txtOrigemDescricao.Name = "txtOrigemDescricao";
			this.txtOrigemDescricao.Size = new System.Drawing.Size(433, 50);
			this.txtOrigemDescricao.TabIndex = 31;
			this.txtOrigemDescricao.Tag = "Pressione a tecla (+) para preencher automaticamente";
			this.txtOrigemDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// lblID
			// 
			this.lblID.BackColor = System.Drawing.Color.Transparent;
			this.lblID.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblID.ForeColor = System.Drawing.Color.AliceBlue;
			this.lblID.Location = new System.Drawing.Point(4, 16);
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
			this.lbl_IdTexto.Location = new System.Drawing.Point(31, 3);
			this.lbl_IdTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbl_IdTexto.Name = "lbl_IdTexto";
			this.lbl_IdTexto.Size = new System.Drawing.Size(35, 13);
			this.lbl_IdTexto.TabIndex = 1;
			this.lbl_IdTexto.Text = "Reg.";
			this.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.btnFechar,
            this.toolStripSeparator2});
			this.tspMenu.Location = new System.Drawing.Point(2, 585);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(600, 44);
			this.tspMenu.TabIndex = 32;
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
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 44);
			// 
			// line1
			// 
			this.line1.EndPoint = new System.Drawing.Point(540, 5);
			this.line1.LineColor = System.Drawing.Color.SlateGray;
			this.line1.LineWidth = 3F;
			this.line1.Location = new System.Drawing.Point(25, 161);
			this.line1.Name = "line1";
			this.line1.Size = new System.Drawing.Size(551, 10);
			this.line1.StartPoint = new System.Drawing.Point(5, 5);
			this.line1.TabIndex = 7;
			this.line1.TabStop = false;
			// 
			// btnSetContribuinte
			// 
			this.btnSetContribuinte.AllowAnimations = true;
			this.btnSetContribuinte.BackColor = System.Drawing.Color.Transparent;
			this.btnSetContribuinte.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetContribuinte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetContribuinte.Location = new System.Drawing.Point(525, 424);
			this.btnSetContribuinte.Name = "btnSetContribuinte";
			this.btnSetContribuinte.RoundedCornersMask = ((byte)(15));
			this.btnSetContribuinte.RoundedCornersRadius = 0;
			this.btnSetContribuinte.Size = new System.Drawing.Size(34, 27);
			this.btnSetContribuinte.TabIndex = 26;
			this.btnSetContribuinte.TabStop = false;
			this.btnSetContribuinte.Text = "...";
			this.btnSetContribuinte.UseCompatibleTextRendering = true;
			this.btnSetContribuinte.UseVisualStyleBackColor = false;
			this.btnSetContribuinte.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetContribuinte.Click += new System.EventHandler(this.btnSetContribuinte_Click);
			// 
			// txtContribuinte
			// 
			this.txtContribuinte.Location = new System.Drawing.Point(126, 424);
			this.txtContribuinte.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtContribuinte.MaxLength = 30;
			this.txtContribuinte.Name = "txtContribuinte";
			this.txtContribuinte.Size = new System.Drawing.Size(393, 27);
			this.txtContribuinte.TabIndex = 25;
			this.txtContribuinte.Tag = "Pressione a tecla (+) para procurar";
			this.txtContribuinte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// lblContribuinte
			// 
			this.lblContribuinte.AutoSize = true;
			this.lblContribuinte.BackColor = System.Drawing.Color.Transparent;
			this.lblContribuinte.ForeColor = System.Drawing.Color.Black;
			this.lblContribuinte.Location = new System.Drawing.Point(31, 427);
			this.lblContribuinte.Name = "lblContribuinte";
			this.lblContribuinte.Size = new System.Drawing.Size(89, 19);
			this.lblContribuinte.TabIndex = 24;
			this.lblContribuinte.Text = "Contribuinte";
			// 
			// txtValorBruto
			// 
			this.txtValorBruto.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtValorBruto.Inteiro = false;
			this.txtValorBruto.Location = new System.Drawing.Point(111, 269);
			this.txtValorBruto.Moeda = false;
			this.txtValorBruto.Name = "txtValorBruto";
			this.txtValorBruto.Positivo = true;
			this.txtValorBruto.Size = new System.Drawing.Size(120, 31);
			this.txtValorBruto.TabIndex = 14;
			this.txtValorBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtValorBruto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown_Block);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(47, 349);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(143, 19);
			this.label2.TabIndex = 18;
			this.label2.Text = "Tipo de Contribuição";
			// 
			// txtContribuicaoTipo
			// 
			this.txtContribuicaoTipo.BackColor = System.Drawing.Color.White;
			this.txtContribuicaoTipo.Location = new System.Drawing.Point(196, 346);
			this.txtContribuicaoTipo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtContribuicaoTipo.MaxLength = 30;
			this.txtContribuicaoTipo.Name = "txtContribuicaoTipo";
			this.txtContribuicaoTipo.Size = new System.Drawing.Size(228, 27);
			this.txtContribuicaoTipo.TabIndex = 19;
			this.txtContribuicaoTipo.Tag = "Pressione a tecla (+) para procurar ou atalho numérico";
			this.txtContribuicaoTipo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			this.txtContribuicaoTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
			// 
			// btnSetEntradaTipo
			// 
			this.btnSetEntradaTipo.AllowAnimations = true;
			this.btnSetEntradaTipo.BackColor = System.Drawing.Color.Transparent;
			this.btnSetEntradaTipo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetEntradaTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetEntradaTipo.Location = new System.Drawing.Point(430, 346);
			this.btnSetEntradaTipo.Name = "btnSetEntradaTipo";
			this.btnSetEntradaTipo.RoundedCornersMask = ((byte)(15));
			this.btnSetEntradaTipo.RoundedCornersRadius = 0;
			this.btnSetEntradaTipo.Size = new System.Drawing.Size(34, 27);
			this.btnSetEntradaTipo.TabIndex = 20;
			this.btnSetEntradaTipo.TabStop = false;
			this.btnSetEntradaTipo.Text = "n";
			this.btnSetEntradaTipo.UseCompatibleTextRendering = true;
			this.btnSetEntradaTipo.UseVisualStyleBackColor = false;
			this.btnSetEntradaTipo.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetEntradaTipo.Click += new System.EventHandler(this.btnSetContribuicaoTipo_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(66, 116);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(109, 19);
			this.label3.TabIndex = 4;
			this.label3.Text = "Setor Creditado";
			// 
			// txtSetor
			// 
			this.txtSetor.Location = new System.Drawing.Point(181, 113);
			this.txtSetor.MaxLength = 30;
			this.txtSetor.Name = "txtSetor";
			this.txtSetor.Size = new System.Drawing.Size(228, 27);
			this.txtSetor.TabIndex = 5;
			this.txtSetor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// btnSetSetor
			// 
			this.btnSetSetor.AllowAnimations = true;
			this.btnSetSetor.BackColor = System.Drawing.Color.Transparent;
			this.btnSetSetor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetSetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetSetor.Location = new System.Drawing.Point(415, 113);
			this.btnSetSetor.Name = "btnSetSetor";
			this.btnSetSetor.RoundedCornersMask = ((byte)(15));
			this.btnSetSetor.RoundedCornersRadius = 0;
			this.btnSetSetor.Size = new System.Drawing.Size(34, 27);
			this.btnSetSetor.TabIndex = 6;
			this.btnSetSetor.TabStop = false;
			this.btnSetSetor.Text = "...";
			this.btnSetSetor.UseCompatibleTextRendering = true;
			this.btnSetSetor.UseVisualStyleBackColor = false;
			this.btnSetSetor.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetSetor.Click += new System.EventHandler(this.btnSetSetor_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(61, 78);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(114, 19);
			this.label4.TabIndex = 1;
			this.label4.Text = "Conta Creditada";
			// 
			// txtConta
			// 
			this.txtConta.Location = new System.Drawing.Point(181, 75);
			this.txtConta.MaxLength = 30;
			this.txtConta.Name = "txtConta";
			this.txtConta.Size = new System.Drawing.Size(228, 27);
			this.txtConta.TabIndex = 2;
			this.txtConta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// btnSetConta
			// 
			this.btnSetConta.AllowAnimations = true;
			this.btnSetConta.BackColor = System.Drawing.Color.Transparent;
			this.btnSetConta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetConta.Location = new System.Drawing.Point(415, 75);
			this.btnSetConta.Name = "btnSetConta";
			this.btnSetConta.RoundedCornersMask = ((byte)(15));
			this.btnSetConta.RoundedCornersRadius = 0;
			this.btnSetConta.Size = new System.Drawing.Size(34, 27);
			this.btnSetConta.TabIndex = 3;
			this.btnSetConta.TabStop = false;
			this.btnSetConta.Text = "...";
			this.btnSetConta.UseCompatibleTextRendering = true;
			this.btnSetConta.UseVisualStyleBackColor = false;
			this.btnSetConta.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetConta.Click += new System.EventHandler(this.btnSetConta_Click);
			// 
			// lblReuniao
			// 
			this.lblReuniao.AutoSize = true;
			this.lblReuniao.BackColor = System.Drawing.Color.Transparent;
			this.lblReuniao.ForeColor = System.Drawing.Color.Black;
			this.lblReuniao.Location = new System.Drawing.Point(79, 388);
			this.lblReuniao.Name = "lblReuniao";
			this.lblReuniao.Size = new System.Drawing.Size(111, 19);
			this.lblReuniao.TabIndex = 21;
			this.lblReuniao.Text = "Reunião | Culto";
			// 
			// txtReuniao
			// 
			this.txtReuniao.Location = new System.Drawing.Point(196, 385);
			this.txtReuniao.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtReuniao.MaxLength = 30;
			this.txtReuniao.Name = "txtReuniao";
			this.txtReuniao.Size = new System.Drawing.Size(228, 27);
			this.txtReuniao.TabIndex = 22;
			this.txtReuniao.Tag = "Pressione a tecla (+) para procurar";
			this.txtReuniao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// btnSetReuniao
			// 
			this.btnSetReuniao.AllowAnimations = true;
			this.btnSetReuniao.BackColor = System.Drawing.Color.Transparent;
			this.btnSetReuniao.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetReuniao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetReuniao.Location = new System.Drawing.Point(430, 385);
			this.btnSetReuniao.Name = "btnSetReuniao";
			this.btnSetReuniao.RoundedCornersMask = ((byte)(15));
			this.btnSetReuniao.RoundedCornersRadius = 0;
			this.btnSetReuniao.Size = new System.Drawing.Size(34, 27);
			this.btnSetReuniao.TabIndex = 23;
			this.btnSetReuniao.TabStop = false;
			this.btnSetReuniao.Text = "...";
			this.btnSetReuniao.UseCompatibleTextRendering = true;
			this.btnSetReuniao.UseVisualStyleBackColor = false;
			this.btnSetReuniao.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetReuniao.Click += new System.EventHandler(this.btnSetReuniao_Click);
			// 
			// lblCampanha
			// 
			this.lblCampanha.AutoSize = true;
			this.lblCampanha.BackColor = System.Drawing.Color.Transparent;
			this.lblCampanha.ForeColor = System.Drawing.Color.Black;
			this.lblCampanha.Location = new System.Drawing.Point(42, 466);
			this.lblCampanha.Name = "lblCampanha";
			this.lblCampanha.Size = new System.Drawing.Size(78, 19);
			this.lblCampanha.TabIndex = 27;
			this.lblCampanha.Text = "Campanha";
			// 
			// txtCampanha
			// 
			this.txtCampanha.Location = new System.Drawing.Point(126, 463);
			this.txtCampanha.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCampanha.MaxLength = 30;
			this.txtCampanha.Name = "txtCampanha";
			this.txtCampanha.Size = new System.Drawing.Size(393, 27);
			this.txtCampanha.TabIndex = 28;
			this.txtCampanha.Tag = "Pressione a tecla (+) para procurar";
			this.txtCampanha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// btnSetCampanha
			// 
			this.btnSetCampanha.AllowAnimations = true;
			this.btnSetCampanha.BackColor = System.Drawing.Color.Transparent;
			this.btnSetCampanha.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetCampanha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetCampanha.Location = new System.Drawing.Point(525, 463);
			this.btnSetCampanha.Name = "btnSetCampanha";
			this.btnSetCampanha.RoundedCornersMask = ((byte)(15));
			this.btnSetCampanha.RoundedCornersRadius = 0;
			this.btnSetCampanha.Size = new System.Drawing.Size(34, 27);
			this.btnSetCampanha.TabIndex = 29;
			this.btnSetCampanha.TabStop = false;
			this.btnSetCampanha.Text = "...";
			this.btnSetCampanha.UseCompatibleTextRendering = true;
			this.btnSetCampanha.UseVisualStyleBackColor = false;
			this.btnSetCampanha.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetCampanha.Click += new System.EventHandler(this.btnSetCampanha_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.ForeColor = System.Drawing.Color.Black;
			this.label8.Location = new System.Drawing.Point(118, 247);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(116, 19);
			this.label8.TabIndex = 12;
			this.label8.Text = "Valor da Entrada";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(136, 179);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 19);
			this.label1.TabIndex = 8;
			this.label1.Text = "Data da Entrada";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.ForeColor = System.Drawing.Color.Black;
			this.label9.Location = new System.Drawing.Point(233, 247);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(116, 19);
			this.label9.TabIndex = 13;
			this.label9.Text = "Meio de Entrada";
			// 
			// txtEntradaForma
			// 
			this.txtEntradaForma.BackColor = System.Drawing.Color.White;
			this.txtEntradaForma.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEntradaForma.Location = new System.Drawing.Point(237, 269);
			this.txtEntradaForma.MaxLength = 30;
			this.txtEntradaForma.Name = "txtEntradaForma";
			this.txtEntradaForma.Size = new System.Drawing.Size(193, 31);
			this.txtEntradaForma.TabIndex = 15;
			this.txtEntradaForma.Tag = "Pressione a tecla (+) para procurar  ou atalho numérico";
			this.txtEntradaForma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			this.txtEntradaForma.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
			// 
			// btnSetEntradaForma
			// 
			this.btnSetEntradaForma.AllowAnimations = true;
			this.btnSetEntradaForma.BackColor = System.Drawing.Color.Transparent;
			this.btnSetEntradaForma.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetEntradaForma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetEntradaForma.ImageAbsolutePosition = new System.Drawing.Point(7, 4);
			this.btnSetEntradaForma.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnSetEntradaForma.Location = new System.Drawing.Point(436, 269);
			this.btnSetEntradaForma.Name = "btnSetEntradaForma";
			this.btnSetEntradaForma.RoundedCornersMask = ((byte)(15));
			this.btnSetEntradaForma.RoundedCornersRadius = 0;
			this.btnSetEntradaForma.Size = new System.Drawing.Size(34, 31);
			this.btnSetEntradaForma.TabIndex = 16;
			this.btnSetEntradaForma.TabStop = false;
			this.btnSetEntradaForma.Text = "n";
			this.btnSetEntradaForma.UseAbsoluteImagePositioning = true;
			this.btnSetEntradaForma.UseCompatibleTextRendering = true;
			this.btnSetEntradaForma.UseVisualStyleBackColor = false;
			this.btnSetEntradaForma.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetEntradaForma.Click += new System.EventHandler(this.btnSetEntradaForma_Click);
			// 
			// cmbEntradaMes
			// 
			this.cmbEntradaMes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbEntradaMes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbEntradaMes.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbEntradaMes.FormattingEnabled = true;
			this.cmbEntradaMes.Location = new System.Drawing.Point(198, 201);
			this.cmbEntradaMes.Name = "cmbEntradaMes";
			this.cmbEntradaMes.Size = new System.Drawing.Size(150, 31);
			this.cmbEntradaMes.TabIndex = 10;
			this.cmbEntradaMes.SelectionChangeCommitted += new System.EventHandler(this.cmbEntradaMes_SelectionChangeCommitted);
			this.cmbEntradaMes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown_Block);
			// 
			// numEntradaAno
			// 
			this.numEntradaAno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numEntradaAno.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numEntradaAno.Location = new System.Drawing.Point(354, 201);
			this.numEntradaAno.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numEntradaAno.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numEntradaAno.Name = "numEntradaAno";
			this.numEntradaAno.Size = new System.Drawing.Size(76, 31);
			this.numEntradaAno.TabIndex = 11;
			this.numEntradaAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numEntradaAno.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.numEntradaAno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown_Block);
			// 
			// numEntradaDia
			// 
			this.numEntradaDia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numEntradaDia.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numEntradaDia.Location = new System.Drawing.Point(140, 201);
			this.numEntradaDia.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
			this.numEntradaDia.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numEntradaDia.Name = "numEntradaDia";
			this.numEntradaDia.Size = new System.Drawing.Size(52, 31);
			this.numEntradaDia.TabIndex = 9;
			this.numEntradaDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numEntradaDia.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numEntradaDia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown_Block);
			// 
			// line2
			// 
			this.line2.EndPoint = new System.Drawing.Point(546, 5);
			this.line2.LineColor = System.Drawing.Color.SlateGray;
			this.line2.LineWidth = 3F;
			this.line2.Location = new System.Drawing.Point(25, 315);
			this.line2.Name = "line2";
			this.line2.Size = new System.Drawing.Size(551, 10);
			this.line2.StartPoint = new System.Drawing.Point(5, 5);
			this.line2.TabIndex = 17;
			this.line2.TabStop = false;
			// 
			// lblSitBlock
			// 
			this.lblSitBlock.AutoSize = true;
			this.lblSitBlock.BackColor = System.Drawing.Color.AntiqueWhite;
			this.lblSitBlock.Font = new System.Drawing.Font("Pathway Gothic One", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSitBlock.ForeColor = System.Drawing.Color.Maroon;
			this.lblSitBlock.Location = new System.Drawing.Point(334, 594);
			this.lblSitBlock.Name = "lblSitBlock";
			this.lblSitBlock.Size = new System.Drawing.Size(157, 24);
			this.lblSitBlock.TabIndex = 33;
			this.lblSitBlock.Text = "- Apenas Visualização -";
			// 
			// frmContribuicao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(605, 631);
			this.Controls.Add(this.lblSitBlock);
			this.Controls.Add(this.numEntradaDia);
			this.Controls.Add(this.numEntradaAno);
			this.Controls.Add(this.cmbEntradaMes);
			this.Controls.Add(this.txtValorBruto);
			this.Controls.Add(this.btnSetConta);
			this.Controls.Add(this.btnSetSetor);
			this.Controls.Add(this.btnSetEntradaForma);
			this.Controls.Add(this.btnSetEntradaTipo);
			this.Controls.Add(this.btnSetCampanha);
			this.Controls.Add(this.btnSetReuniao);
			this.Controls.Add(this.btnSetContribuinte);
			this.Controls.Add(this.txtConta);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtSetor);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtEntradaForma);
			this.Controls.Add(this.txtContribuicaoTipo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtCampanha);
			this.Controls.Add(this.lblCampanha);
			this.Controls.Add(this.txtReuniao);
			this.Controls.Add(this.lblReuniao);
			this.Controls.Add(this.txtContribuinte);
			this.Controls.Add(this.lblContribuinte);
			this.Controls.Add(this.line2);
			this.Controls.Add(this.line1);
			this.Controls.Add(this.tspMenu);
			this.Controls.Add(this.txtOrigemDescricao);
			this.Controls.Add(this.lblCongregacao);
			this.KeyPreview = true;
			this.Name = "frmContribuicao";
			this.Shown += new System.EventHandler(this.frmContribuicao_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEntrada_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.lblCongregacao, 0);
			this.Controls.SetChildIndex(this.txtOrigemDescricao, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.line1, 0);
			this.Controls.SetChildIndex(this.line2, 0);
			this.Controls.SetChildIndex(this.lblContribuinte, 0);
			this.Controls.SetChildIndex(this.txtContribuinte, 0);
			this.Controls.SetChildIndex(this.lblReuniao, 0);
			this.Controls.SetChildIndex(this.txtReuniao, 0);
			this.Controls.SetChildIndex(this.lblCampanha, 0);
			this.Controls.SetChildIndex(this.txtCampanha, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.label8, 0);
			this.Controls.SetChildIndex(this.label9, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.txtContribuicaoTipo, 0);
			this.Controls.SetChildIndex(this.txtEntradaForma, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.txtSetor, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.txtConta, 0);
			this.Controls.SetChildIndex(this.btnSetContribuinte, 0);
			this.Controls.SetChildIndex(this.btnSetReuniao, 0);
			this.Controls.SetChildIndex(this.btnSetCampanha, 0);
			this.Controls.SetChildIndex(this.btnSetEntradaTipo, 0);
			this.Controls.SetChildIndex(this.btnSetEntradaForma, 0);
			this.Controls.SetChildIndex(this.btnSetSetor, 0);
			this.Controls.SetChildIndex(this.btnSetConta, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.txtValorBruto, 0);
			this.Controls.SetChildIndex(this.cmbEntradaMes, 0);
			this.Controls.SetChildIndex(this.numEntradaAno, 0);
			this.Controls.SetChildIndex(this.numEntradaDia, 0);
			this.Controls.SetChildIndex(this.lblSitBlock, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numEntradaAno)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numEntradaDia)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal System.Windows.Forms.Label lblCongregacao;
		internal System.Windows.Forms.TextBox txtOrigemDescricao;
		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label lbl_IdTexto;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnNovo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnSalvar;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		private System.Windows.Forms.ToolStripButton btnFechar;
		private AwesomeShapeControl.Line line1;
		internal VIBlend.WinForms.Controls.vButton btnSetContribuinte;
		internal System.Windows.Forms.TextBox txtContribuinte;
		internal System.Windows.Forms.Label lblContribuinte;
		private CamadaUC.ucOnlyNumbers txtValorBruto;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox txtContribuicaoTipo;
		internal VIBlend.WinForms.Controls.vButton btnSetEntradaTipo;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.TextBox txtSetor;
		internal VIBlend.WinForms.Controls.vButton btnSetSetor;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TextBox txtConta;
		internal VIBlend.WinForms.Controls.vButton btnSetConta;
		internal System.Windows.Forms.Label lblReuniao;
		internal System.Windows.Forms.TextBox txtReuniao;
		internal VIBlend.WinForms.Controls.vButton btnSetReuniao;
		internal System.Windows.Forms.Label lblCampanha;
		internal System.Windows.Forms.TextBox txtCampanha;
		internal VIBlend.WinForms.Controls.vButton btnSetCampanha;
		internal System.Windows.Forms.Label label8;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Label label9;
		internal System.Windows.Forms.TextBox txtEntradaForma;
		internal VIBlend.WinForms.Controls.vButton btnSetEntradaForma;
		private CamadaUC.ucComboLimitedValues cmbEntradaMes;
		private System.Windows.Forms.NumericUpDown numEntradaAno;
		private System.Windows.Forms.NumericUpDown numEntradaDia;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private AwesomeShapeControl.Line line2;
		private System.Windows.Forms.Label lblSitBlock;
	}
}
