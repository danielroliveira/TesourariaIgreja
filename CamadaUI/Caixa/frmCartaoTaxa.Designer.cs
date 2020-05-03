namespace CamadaUI.Caixa
{
	partial class frmCartaoTaxa
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCartaoTaxa));
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnNovo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalvar = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnAtivo = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.line1 = new AwesomeShapeControl.Line();
			this.btnSetOperadora = new VIBlend.WinForms.Controls.vButton();
			this.txtCartaoOperadora = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtCartaoBandeira = new System.Windows.Forms.TextBox();
			this.btnSetBandeira = new VIBlend.WinForms.Controls.vButton();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPrazoDebito = new CamadaUC.ucOnlyNumbers();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPrazoCredito = new CamadaUC.ucOnlyNumbers();
			this.line2 = new AwesomeShapeControl.Line();
			this.txtTaxaDebito = new CamadaUC.ucOnlyNumbers();
			this.label5 = new System.Windows.Forms.Label();
			this.txtTaxaCredito = new CamadaUC.ucOnlyNumbers();
			this.label7 = new System.Windows.Forms.Label();
			this.txtTaxa3 = new CamadaUC.ucOnlyNumbers();
			this.txtTaxa2 = new CamadaUC.ucOnlyNumbers();
			this.label9 = new System.Windows.Forms.Label();
			this.txtTaxa5 = new CamadaUC.ucOnlyNumbers();
			this.txtTaxa4 = new CamadaUC.ucOnlyNumbers();
			this.txtTaxa7 = new CamadaUC.ucOnlyNumbers();
			this.txtTaxa6 = new CamadaUC.ucOnlyNumbers();
			this.txtTaxa8 = new CamadaUC.ucOnlyNumbers();
			this.txtTaxa9 = new CamadaUC.ucOnlyNumbers();
			this.txtTaxa10 = new CamadaUC.ucOnlyNumbers();
			this.txtTaxa11 = new CamadaUC.ucOnlyNumbers();
			this.label18 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.txtTaxa12 = new CamadaUC.ucOnlyNumbers();
			this.label20 = new System.Windows.Forms.Label();
			this.lblContaProvisoria = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(202, 0);
			this.lblTitulo.Size = new System.Drawing.Size(318, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "Taxas de Operadora de Cartão";
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
            this.toolStripSeparator2,
            this.btnAtivo,
            this.btnFechar});
			this.tspMenu.Location = new System.Drawing.Point(2, 621);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(555, 44);
			this.tspMenu.TabIndex = 43;
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
			// line1
			// 
			this.line1.EndPoint = new System.Drawing.Point(334, 5);
			this.line1.LineColor = System.Drawing.Color.SlateGray;
			this.line1.LineWidth = 3F;
			this.line1.Location = new System.Drawing.Point(172, 209);
			this.line1.Name = "line1";
			this.line1.Size = new System.Drawing.Size(339, 10);
			this.line1.StartPoint = new System.Drawing.Point(5, 5);
			this.line1.TabIndex = 10;
			this.line1.TabStop = false;
			// 
			// btnSetOperadora
			// 
			this.btnSetOperadora.AllowAnimations = true;
			this.btnSetOperadora.BackColor = System.Drawing.Color.Transparent;
			this.btnSetOperadora.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetOperadora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetOperadora.Location = new System.Drawing.Point(419, 73);
			this.btnSetOperadora.Name = "btnSetOperadora";
			this.btnSetOperadora.RoundedCornersMask = ((byte)(15));
			this.btnSetOperadora.RoundedCornersRadius = 0;
			this.btnSetOperadora.Size = new System.Drawing.Size(34, 27);
			this.btnSetOperadora.TabIndex = 3;
			this.btnSetOperadora.TabStop = false;
			this.btnSetOperadora.Text = "...";
			this.btnSetOperadora.UseCompatibleTextRendering = true;
			this.btnSetOperadora.UseVisualStyleBackColor = false;
			this.btnSetOperadora.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetOperadora.Click += new System.EventHandler(this.btnSetOperadora_Click);
			// 
			// txtCartaoOperadora
			// 
			this.txtCartaoOperadora.Location = new System.Drawing.Point(185, 73);
			this.txtCartaoOperadora.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCartaoOperadora.MaxLength = 30;
			this.txtCartaoOperadora.Name = "txtCartaoOperadora";
			this.txtCartaoOperadora.Size = new System.Drawing.Size(228, 27);
			this.txtCartaoOperadora.TabIndex = 2;
			this.txtCartaoOperadora.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.BackColor = System.Drawing.Color.Transparent;
			this.Label6.ForeColor = System.Drawing.Color.Black;
			this.Label6.Location = new System.Drawing.Point(101, 76);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(78, 19);
			this.Label6.TabIndex = 1;
			this.Label6.Text = "Operadora";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(112, 142);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 19);
			this.label1.TabIndex = 4;
			this.label1.Text = "Bandeira";
			// 
			// txtCartaoBandeira
			// 
			this.txtCartaoBandeira.Location = new System.Drawing.Point(185, 139);
			this.txtCartaoBandeira.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCartaoBandeira.MaxLength = 30;
			this.txtCartaoBandeira.Name = "txtCartaoBandeira";
			this.txtCartaoBandeira.Size = new System.Drawing.Size(228, 27);
			this.txtCartaoBandeira.TabIndex = 5;
			this.txtCartaoBandeira.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// btnSetBandeira
			// 
			this.btnSetBandeira.AllowAnimations = true;
			this.btnSetBandeira.BackColor = System.Drawing.Color.Transparent;
			this.btnSetBandeira.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetBandeira.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetBandeira.Location = new System.Drawing.Point(419, 139);
			this.btnSetBandeira.Name = "btnSetBandeira";
			this.btnSetBandeira.RoundedCornersMask = ((byte)(15));
			this.btnSetBandeira.RoundedCornersRadius = 0;
			this.btnSetBandeira.Size = new System.Drawing.Size(34, 27);
			this.btnSetBandeira.TabIndex = 6;
			this.btnSetBandeira.TabStop = false;
			this.btnSetBandeira.Text = "...";
			this.btnSetBandeira.UseCompatibleTextRendering = true;
			this.btnSetBandeira.UseVisualStyleBackColor = false;
			this.btnSetBandeira.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetBandeira.Click += new System.EventHandler(this.btnSetBandeira_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(88, 241);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 19);
			this.label2.TabIndex = 11;
			this.label2.Text = "Prazo Débito";
			// 
			// txtPrazoDebito
			// 
			this.txtPrazoDebito.Inteiro = true;
			this.txtPrazoDebito.Location = new System.Drawing.Point(185, 238);
			this.txtPrazoDebito.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtPrazoDebito.MaxLength = 2;
			this.txtPrazoDebito.Name = "txtPrazoDebito";
			this.txtPrazoDebito.Positivo = true;
			this.txtPrazoDebito.Size = new System.Drawing.Size(58, 27);
			this.txtPrazoDebito.TabIndex = 12;
			this.txtPrazoDebito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(254, 241);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(95, 19);
			this.label3.TabIndex = 13;
			this.label3.Text = "Prazo Crédito";
			// 
			// txtPrazoCredito
			// 
			this.txtPrazoCredito.Inteiro = true;
			this.txtPrazoCredito.Location = new System.Drawing.Point(355, 238);
			this.txtPrazoCredito.MaxLength = 2;
			this.txtPrazoCredito.Name = "txtPrazoCredito";
			this.txtPrazoCredito.Positivo = true;
			this.txtPrazoCredito.Size = new System.Drawing.Size(58, 27);
			this.txtPrazoCredito.TabIndex = 14;
			this.txtPrazoCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// line2
			// 
			this.line2.EndPoint = new System.Drawing.Point(229, 5);
			this.line2.LineColor = System.Drawing.Color.SlateGray;
			this.line2.LineWidth = 3F;
			this.line2.Location = new System.Drawing.Point(277, 294);
			this.line2.Name = "line2";
			this.line2.Size = new System.Drawing.Size(234, 10);
			this.line2.StartPoint = new System.Drawing.Point(5, 5);
			this.line2.TabIndex = 15;
			this.line2.TabStop = false;
			// 
			// txtTaxaDebito
			// 
			this.txtTaxaDebito.Inteiro = false;
			this.txtTaxaDebito.Location = new System.Drawing.Point(185, 333);
			this.txtTaxaDebito.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtTaxaDebito.MaxLength = 6;
			this.txtTaxaDebito.Name = "txtTaxaDebito";
			this.txtTaxaDebito.Positivo = true;
			this.txtTaxaDebito.Size = new System.Drawing.Size(58, 27);
			this.txtTaxaDebito.TabIndex = 18;
			this.txtTaxaDebito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(127, 336);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 19);
			this.label5.TabIndex = 17;
			this.label5.Text = "Débito";
			// 
			// txtTaxaCredito
			// 
			this.txtTaxaCredito.Inteiro = false;
			this.txtTaxaCredito.Location = new System.Drawing.Point(355, 333);
			this.txtTaxaCredito.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtTaxaCredito.MaxLength = 6;
			this.txtTaxaCredito.Name = "txtTaxaCredito";
			this.txtTaxaCredito.Positivo = true;
			this.txtTaxaCredito.Size = new System.Drawing.Size(58, 27);
			this.txtTaxaCredito.TabIndex = 20;
			this.txtTaxaCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.ForeColor = System.Drawing.Color.Black;
			this.label7.Location = new System.Drawing.Point(293, 336);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 19);
			this.label7.TabIndex = 19;
			this.label7.Text = "Crédito";
			// 
			// txtTaxa3
			// 
			this.txtTaxa3.Inteiro = false;
			this.txtTaxa3.Location = new System.Drawing.Point(355, 372);
			this.txtTaxa3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtTaxa3.MaxLength = 6;
			this.txtTaxa3.Name = "txtTaxa3";
			this.txtTaxa3.Positivo = true;
			this.txtTaxa3.Size = new System.Drawing.Size(58, 27);
			this.txtTaxa3.TabIndex = 24;
			this.txtTaxa3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtTaxa2
			// 
			this.txtTaxa2.Inteiro = false;
			this.txtTaxa2.Location = new System.Drawing.Point(185, 372);
			this.txtTaxa2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtTaxa2.MaxLength = 6;
			this.txtTaxa2.Name = "txtTaxa2";
			this.txtTaxa2.Positivo = true;
			this.txtTaxa2.Size = new System.Drawing.Size(58, 27);
			this.txtTaxa2.TabIndex = 22;
			this.txtTaxa2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.ForeColor = System.Drawing.Color.Black;
			this.label9.Location = new System.Drawing.Point(103, 375);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(76, 19);
			this.label9.TabIndex = 21;
			this.label9.Text = "2 Parcelas";
			// 
			// txtTaxa5
			// 
			this.txtTaxa5.Inteiro = false;
			this.txtTaxa5.Location = new System.Drawing.Point(355, 411);
			this.txtTaxa5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtTaxa5.MaxLength = 6;
			this.txtTaxa5.Name = "txtTaxa5";
			this.txtTaxa5.Positivo = true;
			this.txtTaxa5.Size = new System.Drawing.Size(58, 27);
			this.txtTaxa5.TabIndex = 28;
			this.txtTaxa5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtTaxa4
			// 
			this.txtTaxa4.Inteiro = false;
			this.txtTaxa4.Location = new System.Drawing.Point(185, 411);
			this.txtTaxa4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtTaxa4.MaxLength = 6;
			this.txtTaxa4.Name = "txtTaxa4";
			this.txtTaxa4.Positivo = true;
			this.txtTaxa4.Size = new System.Drawing.Size(58, 27);
			this.txtTaxa4.TabIndex = 26;
			this.txtTaxa4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtTaxa7
			// 
			this.txtTaxa7.Inteiro = false;
			this.txtTaxa7.Location = new System.Drawing.Point(355, 450);
			this.txtTaxa7.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtTaxa7.MaxLength = 6;
			this.txtTaxa7.Name = "txtTaxa7";
			this.txtTaxa7.Positivo = true;
			this.txtTaxa7.Size = new System.Drawing.Size(58, 27);
			this.txtTaxa7.TabIndex = 32;
			this.txtTaxa7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtTaxa6
			// 
			this.txtTaxa6.Inteiro = false;
			this.txtTaxa6.Location = new System.Drawing.Point(185, 450);
			this.txtTaxa6.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtTaxa6.MaxLength = 6;
			this.txtTaxa6.Name = "txtTaxa6";
			this.txtTaxa6.Positivo = true;
			this.txtTaxa6.Size = new System.Drawing.Size(58, 27);
			this.txtTaxa6.TabIndex = 30;
			this.txtTaxa6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtTaxa8
			// 
			this.txtTaxa8.Inteiro = false;
			this.txtTaxa8.Location = new System.Drawing.Point(185, 489);
			this.txtTaxa8.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtTaxa8.MaxLength = 6;
			this.txtTaxa8.Name = "txtTaxa8";
			this.txtTaxa8.Positivo = true;
			this.txtTaxa8.Size = new System.Drawing.Size(58, 27);
			this.txtTaxa8.TabIndex = 34;
			this.txtTaxa8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtTaxa9
			// 
			this.txtTaxa9.Inteiro = false;
			this.txtTaxa9.Location = new System.Drawing.Point(355, 489);
			this.txtTaxa9.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtTaxa9.MaxLength = 6;
			this.txtTaxa9.Name = "txtTaxa9";
			this.txtTaxa9.Positivo = true;
			this.txtTaxa9.Size = new System.Drawing.Size(58, 27);
			this.txtTaxa9.TabIndex = 36;
			this.txtTaxa9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtTaxa10
			// 
			this.txtTaxa10.Inteiro = false;
			this.txtTaxa10.Location = new System.Drawing.Point(185, 528);
			this.txtTaxa10.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtTaxa10.MaxLength = 6;
			this.txtTaxa10.Name = "txtTaxa10";
			this.txtTaxa10.Positivo = true;
			this.txtTaxa10.Size = new System.Drawing.Size(58, 27);
			this.txtTaxa10.TabIndex = 38;
			this.txtTaxa10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtTaxa11
			// 
			this.txtTaxa11.Inteiro = false;
			this.txtTaxa11.Location = new System.Drawing.Point(355, 528);
			this.txtTaxa11.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtTaxa11.MaxLength = 6;
			this.txtTaxa11.Name = "txtTaxa11";
			this.txtTaxa11.Positivo = true;
			this.txtTaxa11.Size = new System.Drawing.Size(58, 27);
			this.txtTaxa11.TabIndex = 40;
			this.txtTaxa11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.BackColor = System.Drawing.Color.Transparent;
			this.label18.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.Black;
			this.label18.Location = new System.Drawing.Point(40, 287);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(237, 23);
			this.label18.TabIndex = 16;
			this.label18.Text = "Taxas de Comissão (%)";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.ForeColor = System.Drawing.Color.Black;
			this.label8.Location = new System.Drawing.Point(273, 375);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(76, 19);
			this.label8.TabIndex = 23;
			this.label8.Text = "3 Parcelas";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.ForeColor = System.Drawing.Color.Black;
			this.label10.Location = new System.Drawing.Point(103, 414);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(76, 19);
			this.label10.TabIndex = 25;
			this.label10.Text = "4 Parcelas";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.Transparent;
			this.label11.ForeColor = System.Drawing.Color.Black;
			this.label11.Location = new System.Drawing.Point(103, 453);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(76, 19);
			this.label11.TabIndex = 29;
			this.label11.Text = "6 Parcelas";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.BackColor = System.Drawing.Color.Transparent;
			this.label12.ForeColor = System.Drawing.Color.Black;
			this.label12.Location = new System.Drawing.Point(103, 492);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(76, 19);
			this.label12.TabIndex = 33;
			this.label12.Text = "8 Parcelas";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.BackColor = System.Drawing.Color.Transparent;
			this.label13.ForeColor = System.Drawing.Color.Black;
			this.label13.Location = new System.Drawing.Point(95, 531);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(84, 19);
			this.label13.TabIndex = 37;
			this.label13.Text = "10 Parcelas";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.BackColor = System.Drawing.Color.Transparent;
			this.label14.ForeColor = System.Drawing.Color.Black;
			this.label14.Location = new System.Drawing.Point(265, 531);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(84, 19);
			this.label14.TabIndex = 39;
			this.label14.Text = "11 Parcelas";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.BackColor = System.Drawing.Color.Transparent;
			this.label15.ForeColor = System.Drawing.Color.Black;
			this.label15.Location = new System.Drawing.Point(273, 492);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(76, 19);
			this.label15.TabIndex = 35;
			this.label15.Text = "9 Parcelas";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.BackColor = System.Drawing.Color.Transparent;
			this.label16.ForeColor = System.Drawing.Color.Black;
			this.label16.Location = new System.Drawing.Point(273, 453);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(76, 19);
			this.label16.TabIndex = 31;
			this.label16.Text = "7 Parcelas";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.BackColor = System.Drawing.Color.Transparent;
			this.label17.ForeColor = System.Drawing.Color.Black;
			this.label17.Location = new System.Drawing.Point(273, 414);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(76, 19);
			this.label17.TabIndex = 27;
			this.label17.Text = "5 Parcelas";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.BackColor = System.Drawing.Color.Transparent;
			this.label19.ForeColor = System.Drawing.Color.Black;
			this.label19.Location = new System.Drawing.Point(95, 570);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(84, 19);
			this.label19.TabIndex = 41;
			this.label19.Text = "12 Parcelas";
			// 
			// txtTaxa12
			// 
			this.txtTaxa12.Inteiro = false;
			this.txtTaxa12.Location = new System.Drawing.Point(185, 567);
			this.txtTaxa12.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtTaxa12.MaxLength = 6;
			this.txtTaxa12.Name = "txtTaxa12";
			this.txtTaxa12.Positivo = true;
			this.txtTaxa12.Size = new System.Drawing.Size(58, 27);
			this.txtTaxa12.TabIndex = 42;
			this.txtTaxa12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.BackColor = System.Drawing.Color.Transparent;
			this.label20.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label20.ForeColor = System.Drawing.Color.Black;
			this.label20.Location = new System.Drawing.Point(40, 201);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(136, 23);
			this.label20.TabIndex = 16;
			this.label20.Text = "Prazos (dias)";
			// 
			// lblContaProvisoria
			// 
			this.lblContaProvisoria.BackColor = System.Drawing.Color.Transparent;
			this.lblContaProvisoria.ForeColor = System.Drawing.Color.Black;
			this.lblContaProvisoria.Location = new System.Drawing.Point(185, 104);
			this.lblContaProvisoria.Name = "lblContaProvisoria";
			this.lblContaProvisoria.Size = new System.Drawing.Size(228, 24);
			this.lblContaProvisoria.TabIndex = 7;
			this.lblContaProvisoria.Text = "Conta Creditada";
			// 
			// frmCartaoTaxa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(560, 667);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtTaxa11);
			this.Controls.Add(this.txtTaxa9);
			this.Controls.Add(this.txtTaxa12);
			this.Controls.Add(this.txtTaxa10);
			this.Controls.Add(this.txtTaxa7);
			this.Controls.Add(this.txtTaxa8);
			this.Controls.Add(this.txtTaxa6);
			this.Controls.Add(this.txtTaxa5);
			this.Controls.Add(this.txtTaxa4);
			this.Controls.Add(this.txtTaxa3);
			this.Controls.Add(this.txtTaxa2);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.txtTaxaCredito);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtTaxaDebito);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtPrazoCredito);
			this.Controls.Add(this.txtPrazoDebito);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblContaProvisoria);
			this.Controls.Add(this.btnSetBandeira);
			this.Controls.Add(this.btnSetOperadora);
			this.Controls.Add(this.txtCartaoBandeira);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtCartaoOperadora);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.line2);
			this.Controls.Add(this.line1);
			this.Controls.Add(this.tspMenu);
			this.KeyPreview = true;
			this.Name = "frmCartaoTaxa";
			this.Shown += new System.EventHandler(this.frmCartaoTaxa_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCartaoTaxa_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmCartaoTaxa_KeyPress);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.line1, 0);
			this.Controls.SetChildIndex(this.line2, 0);
			this.Controls.SetChildIndex(this.Label6, 0);
			this.Controls.SetChildIndex(this.txtCartaoOperadora, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.txtCartaoBandeira, 0);
			this.Controls.SetChildIndex(this.btnSetOperadora, 0);
			this.Controls.SetChildIndex(this.btnSetBandeira, 0);
			this.Controls.SetChildIndex(this.lblContaProvisoria, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.txtPrazoDebito, 0);
			this.Controls.SetChildIndex(this.txtPrazoCredito, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.label18, 0);
			this.Controls.SetChildIndex(this.label20, 0);
			this.Controls.SetChildIndex(this.txtTaxaDebito, 0);
			this.Controls.SetChildIndex(this.label7, 0);
			this.Controls.SetChildIndex(this.txtTaxaCredito, 0);
			this.Controls.SetChildIndex(this.label9, 0);
			this.Controls.SetChildIndex(this.label10, 0);
			this.Controls.SetChildIndex(this.label11, 0);
			this.Controls.SetChildIndex(this.label12, 0);
			this.Controls.SetChildIndex(this.label13, 0);
			this.Controls.SetChildIndex(this.label14, 0);
			this.Controls.SetChildIndex(this.label19, 0);
			this.Controls.SetChildIndex(this.label15, 0);
			this.Controls.SetChildIndex(this.label16, 0);
			this.Controls.SetChildIndex(this.label17, 0);
			this.Controls.SetChildIndex(this.txtTaxa2, 0);
			this.Controls.SetChildIndex(this.txtTaxa3, 0);
			this.Controls.SetChildIndex(this.txtTaxa4, 0);
			this.Controls.SetChildIndex(this.txtTaxa5, 0);
			this.Controls.SetChildIndex(this.txtTaxa6, 0);
			this.Controls.SetChildIndex(this.txtTaxa8, 0);
			this.Controls.SetChildIndex(this.txtTaxa7, 0);
			this.Controls.SetChildIndex(this.txtTaxa10, 0);
			this.Controls.SetChildIndex(this.txtTaxa12, 0);
			this.Controls.SetChildIndex(this.txtTaxa9, 0);
			this.Controls.SetChildIndex(this.txtTaxa11, 0);
			this.Controls.SetChildIndex(this.label8, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label lbl_IdTexto;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnNovo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnSalvar;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnAtivo;
		private System.Windows.Forms.ToolStripButton btnFechar;
		private AwesomeShapeControl.Line line1;
		internal VIBlend.WinForms.Controls.vButton btnSetOperadora;
		internal System.Windows.Forms.TextBox txtCartaoOperadora;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.TextBox txtCartaoBandeira;
		internal VIBlend.WinForms.Controls.vButton btnSetBandeira;
		internal System.Windows.Forms.Label label2;
		private CamadaUC.ucOnlyNumbers txtPrazoDebito;
		internal System.Windows.Forms.Label label3;
		private CamadaUC.ucOnlyNumbers txtPrazoCredito;
		private AwesomeShapeControl.Line line2;
		private CamadaUC.ucOnlyNumbers txtTaxaDebito;
		internal System.Windows.Forms.Label label5;
		private CamadaUC.ucOnlyNumbers txtTaxaCredito;
		internal System.Windows.Forms.Label label7;
		private CamadaUC.ucOnlyNumbers txtTaxa3;
		private CamadaUC.ucOnlyNumbers txtTaxa2;
		internal System.Windows.Forms.Label label9;
		private CamadaUC.ucOnlyNumbers txtTaxa5;
		private CamadaUC.ucOnlyNumbers txtTaxa4;
		private CamadaUC.ucOnlyNumbers txtTaxa7;
		private CamadaUC.ucOnlyNumbers txtTaxa6;
		private CamadaUC.ucOnlyNumbers txtTaxa8;
		private CamadaUC.ucOnlyNumbers txtTaxa9;
		private CamadaUC.ucOnlyNumbers txtTaxa10;
		private CamadaUC.ucOnlyNumbers txtTaxa11;
		internal System.Windows.Forms.Label label18;
		internal System.Windows.Forms.Label label8;
		internal System.Windows.Forms.Label label10;
		internal System.Windows.Forms.Label label11;
		internal System.Windows.Forms.Label label12;
		internal System.Windows.Forms.Label label13;
		internal System.Windows.Forms.Label label14;
		internal System.Windows.Forms.Label label15;
		internal System.Windows.Forms.Label label16;
		internal System.Windows.Forms.Label label17;
		internal System.Windows.Forms.Label label19;
		private CamadaUC.ucOnlyNumbers txtTaxa12;
		internal System.Windows.Forms.Label label20;
		internal System.Windows.Forms.Label lblContaProvisoria;
	}
}
