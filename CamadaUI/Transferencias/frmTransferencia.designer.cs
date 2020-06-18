namespace CamadaUI.Transferencias
{
	partial class frmTransferencia
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
			this.txtDescricao = new System.Windows.Forms.TextBox();
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnSalvar = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.line1 = new AwesomeShapeControl.Line();
			this.txtTransferenciaValor = new CamadaUC.ucOnlyNumbers();
			this.label3 = new System.Windows.Forms.Label();
			this.txtContaEntrada = new System.Windows.Forms.TextBox();
			this.btnSetContaEntrada = new VIBlend.WinForms.Controls.vButton();
			this.label4 = new System.Windows.Forms.Label();
			this.txtContaSaida = new System.Windows.Forms.TextBox();
			this.btnSetContaSaida = new VIBlend.WinForms.Controls.vButton();
			this.label8 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbTransferenciaMes = new CamadaUC.ucComboLimitedValues();
			this.numTransferenciaAno = new System.Windows.Forms.NumericUpDown();
			this.numTransferenciaDia = new System.Windows.Forms.NumericUpDown();
			this.lblSitBlock = new System.Windows.Forms.Label();
			this.lblContaEntradaDetalhe = new System.Windows.Forms.Label();
			this.lblContaSaidaDetalhe = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numTransferenciaAno)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numTransferenciaDia)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(153, 0);
			this.lblTitulo.Size = new System.Drawing.Size(301, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "Transferência entre Contas";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(454, 0);
			this.btnClose.TabIndex = 3;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblID);
			this.panel1.Controls.Add(this.lbl_IdTexto);
			this.panel1.Size = new System.Drawing.Size(494, 50);
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
			this.lblCongregacao.Location = new System.Drawing.Point(45, 399);
			this.lblCongregacao.Name = "lblCongregacao";
			this.lblCongregacao.Size = new System.Drawing.Size(73, 19);
			this.lblCongregacao.TabIndex = 30;
			this.lblCongregacao.Text = "Descrição";
			// 
			// txtDescricao
			// 
			this.txtDescricao.BackColor = System.Drawing.Color.White;
			this.txtDescricao.Location = new System.Drawing.Point(48, 424);
			this.txtDescricao.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtDescricao.MaxLength = 200;
			this.txtDescricao.Multiline = true;
			this.txtDescricao.Name = "txtDescricao";
			this.txtDescricao.Size = new System.Drawing.Size(403, 55);
			this.txtDescricao.TabIndex = 31;
			this.txtDescricao.Tag = "Pressione a tecla (+) para preencher automaticamente";
			this.txtDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
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
			this.btnSalvar,
			this.btnCancelar,
			this.btnFechar,
			this.toolStripSeparator2});
			this.tspMenu.Location = new System.Drawing.Point(2, 503);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(489, 44);
			this.tspMenu.TabIndex = 32;
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
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 44);
			// 
			// line1
			// 
			this.line1.EndPoint = new System.Drawing.Point(434, 5);
			this.line1.LineColor = System.Drawing.Color.SlateGray;
			this.line1.LineWidth = 3F;
			this.line1.Location = new System.Drawing.Point(25, 248);
			this.line1.Name = "line1";
			this.line1.Size = new System.Drawing.Size(439, 10);
			this.line1.StartPoint = new System.Drawing.Point(5, 5);
			this.line1.TabIndex = 7;
			this.line1.TabStop = false;
			// 
			// txtTransferenciaValor
			// 
			this.txtTransferenciaValor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTransferenciaValor.Inteiro = false;
			this.txtTransferenciaValor.Location = new System.Drawing.Point(165, 359);
			this.txtTransferenciaValor.Moeda = false;
			this.txtTransferenciaValor.Name = "txtTransferenciaValor";
			this.txtTransferenciaValor.Positivo = true;
			this.txtTransferenciaValor.Size = new System.Drawing.Size(161, 31);
			this.txtTransferenciaValor.TabIndex = 14;
			this.txtTransferenciaValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtTransferenciaValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown_Block);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.DarkBlue;
			this.label3.Location = new System.Drawing.Point(31, 178);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(114, 19);
			this.label3.TabIndex = 4;
			this.label3.Text = "Conta Creditada";
			// 
			// txtContaEntrada
			// 
			this.txtContaEntrada.Location = new System.Drawing.Point(151, 175);
			this.txtContaEntrada.MaxLength = 30;
			this.txtContaEntrada.Name = "txtContaEntrada";
			this.txtContaEntrada.Size = new System.Drawing.Size(263, 27);
			this.txtContaEntrada.TabIndex = 5;
			this.txtContaEntrada.Tag = "Pressione a tecla (+) para escolher uma conta";
			this.txtContaEntrada.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// btnSetContaEntrada
			// 
			this.btnSetContaEntrada.AllowAnimations = true;
			this.btnSetContaEntrada.BackColor = System.Drawing.Color.Transparent;
			this.btnSetContaEntrada.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetContaEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetContaEntrada.Location = new System.Drawing.Point(420, 175);
			this.btnSetContaEntrada.Name = "btnSetContaEntrada";
			this.btnSetContaEntrada.RoundedCornersMask = ((byte)(15));
			this.btnSetContaEntrada.RoundedCornersRadius = 0;
			this.btnSetContaEntrada.Size = new System.Drawing.Size(34, 27);
			this.btnSetContaEntrada.TabIndex = 6;
			this.btnSetContaEntrada.TabStop = false;
			this.btnSetContaEntrada.Text = "...";
			this.btnSetContaEntrada.UseCompatibleTextRendering = true;
			this.btnSetContaEntrada.UseVisualStyleBackColor = false;
			this.btnSetContaEntrada.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetContaEntrada.Click += new System.EventHandler(this.btnSetContaEntrada_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.DarkRed;
			this.label4.Location = new System.Drawing.Point(35, 78);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(110, 19);
			this.label4.TabIndex = 1;
			this.label4.Text = "Conta Debitada";
			// 
			// txtContaSaida
			// 
			this.txtContaSaida.Location = new System.Drawing.Point(151, 75);
			this.txtContaSaida.MaxLength = 30;
			this.txtContaSaida.Name = "txtContaSaida";
			this.txtContaSaida.Size = new System.Drawing.Size(263, 27);
			this.txtContaSaida.TabIndex = 2;
			this.txtContaSaida.Tag = "Pressione a tecla (+) para escolher uma conta";
			this.txtContaSaida.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// btnSetContaSaida
			// 
			this.btnSetContaSaida.AllowAnimations = true;
			this.btnSetContaSaida.BackColor = System.Drawing.Color.Transparent;
			this.btnSetContaSaida.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetContaSaida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetContaSaida.Location = new System.Drawing.Point(420, 75);
			this.btnSetContaSaida.Name = "btnSetContaSaida";
			this.btnSetContaSaida.RoundedCornersMask = ((byte)(15));
			this.btnSetContaSaida.RoundedCornersRadius = 0;
			this.btnSetContaSaida.Size = new System.Drawing.Size(34, 27);
			this.btnSetContaSaida.TabIndex = 3;
			this.btnSetContaSaida.TabStop = false;
			this.btnSetContaSaida.Text = "...";
			this.btnSetContaSaida.UseCompatibleTextRendering = true;
			this.btnSetContaSaida.UseVisualStyleBackColor = false;
			this.btnSetContaSaida.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetContaSaida.Click += new System.EventHandler(this.btnSetContaSaida_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.ForeColor = System.Drawing.Color.Black;
			this.label8.Location = new System.Drawing.Point(168, 337);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(154, 19);
			this.label8.TabIndex = 12;
			this.label8.Text = "Valor da Transferência";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(89, 268);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 19);
			this.label1.TabIndex = 8;
			this.label1.Text = "Data da Transferência";
			// 
			// cmbTransferenciaMes
			// 
			this.cmbTransferenciaMes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbTransferenciaMes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbTransferenciaMes.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbTransferenciaMes.FormattingEnabled = true;
			this.cmbTransferenciaMes.Location = new System.Drawing.Point(151, 290);
			this.cmbTransferenciaMes.Name = "cmbTransferenciaMes";
			this.cmbTransferenciaMes.Size = new System.Drawing.Size(150, 31);
			this.cmbTransferenciaMes.TabIndex = 10;
			this.cmbTransferenciaMes.SelectionChangeCommitted += new System.EventHandler(this.cmbEntradaMes_SelectionChangeCommitted);
			this.cmbTransferenciaMes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown_Block);
			// 
			// numTransferenciaAno
			// 
			this.numTransferenciaAno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numTransferenciaAno.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numTransferenciaAno.Location = new System.Drawing.Point(307, 290);
			this.numTransferenciaAno.Maximum = new decimal(new int[] {
			5000,
			0,
			0,
			0});
			this.numTransferenciaAno.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.numTransferenciaAno.Name = "numTransferenciaAno";
			this.numTransferenciaAno.Size = new System.Drawing.Size(76, 31);
			this.numTransferenciaAno.TabIndex = 11;
			this.numTransferenciaAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numTransferenciaAno.Value = new decimal(new int[] {
			2000,
			0,
			0,
			0});
			this.numTransferenciaAno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown_Block);
			// 
			// numTransferenciaDia
			// 
			this.numTransferenciaDia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numTransferenciaDia.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numTransferenciaDia.Location = new System.Drawing.Point(93, 290);
			this.numTransferenciaDia.Maximum = new decimal(new int[] {
			31,
			0,
			0,
			0});
			this.numTransferenciaDia.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.numTransferenciaDia.Name = "numTransferenciaDia";
			this.numTransferenciaDia.Size = new System.Drawing.Size(52, 31);
			this.numTransferenciaDia.TabIndex = 9;
			this.numTransferenciaDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numTransferenciaDia.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.numTransferenciaDia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown_Block);
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
			// lblContaEntradaDetalhe
			// 
			this.lblContaEntradaDetalhe.BackColor = System.Drawing.Color.Transparent;
			this.lblContaEntradaDetalhe.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblContaEntradaDetalhe.ForeColor = System.Drawing.Color.Black;
			this.lblContaEntradaDetalhe.Location = new System.Drawing.Point(148, 205);
			this.lblContaEntradaDetalhe.Name = "lblContaEntradaDetalhe";
			this.lblContaEntradaDetalhe.Size = new System.Drawing.Size(228, 35);
			this.lblContaEntradaDetalhe.TabIndex = 34;
			this.lblContaEntradaDetalhe.Text = "Saldo da Conta: R$ 0,00\r\nData de Bloqueio até: ";
			// 
			// lblContaSaidaDetalhe
			// 
			this.lblContaSaidaDetalhe.BackColor = System.Drawing.Color.Transparent;
			this.lblContaSaidaDetalhe.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblContaSaidaDetalhe.ForeColor = System.Drawing.Color.Black;
			this.lblContaSaidaDetalhe.Location = new System.Drawing.Point(148, 105);
			this.lblContaSaidaDetalhe.Name = "lblContaSaidaDetalhe";
			this.lblContaSaidaDetalhe.Size = new System.Drawing.Size(228, 35);
			this.lblContaSaidaDetalhe.TabIndex = 34;
			this.lblContaSaidaDetalhe.Text = "Saldo da Conta: R$ 0,00\r\nData de Bloqueio até:";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::CamadaUI.Properties.Resources.DownArrow_64;
			this.pictureBox1.Location = new System.Drawing.Point(65, 109);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(45, 58);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 35;
			this.pictureBox1.TabStop = false;
			// 
			// frmTransferencia
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(494, 549);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lblContaSaidaDetalhe);
			this.Controls.Add(this.lblContaEntradaDetalhe);
			this.Controls.Add(this.lblSitBlock);
			this.Controls.Add(this.numTransferenciaDia);
			this.Controls.Add(this.numTransferenciaAno);
			this.Controls.Add(this.cmbTransferenciaMes);
			this.Controls.Add(this.txtTransferenciaValor);
			this.Controls.Add(this.btnSetContaSaida);
			this.Controls.Add(this.btnSetContaEntrada);
			this.Controls.Add(this.txtContaSaida);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtContaEntrada);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.line1);
			this.Controls.Add(this.tspMenu);
			this.Controls.Add(this.txtDescricao);
			this.Controls.Add(this.lblCongregacao);
			this.KeyPreview = true;
			this.Name = "frmTransferencia";
			this.Activated += new System.EventHandler(this.frmDateGet_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDateGet_FormClosed);
			this.Shown += new System.EventHandler(this.frmTransferencia_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEntrada_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.lblCongregacao, 0);
			this.Controls.SetChildIndex(this.txtDescricao, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.line1, 0);
			this.Controls.SetChildIndex(this.label8, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.txtContaEntrada, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.txtContaSaida, 0);
			this.Controls.SetChildIndex(this.btnSetContaEntrada, 0);
			this.Controls.SetChildIndex(this.btnSetContaSaida, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.txtTransferenciaValor, 0);
			this.Controls.SetChildIndex(this.cmbTransferenciaMes, 0);
			this.Controls.SetChildIndex(this.numTransferenciaAno, 0);
			this.Controls.SetChildIndex(this.numTransferenciaDia, 0);
			this.Controls.SetChildIndex(this.lblSitBlock, 0);
			this.Controls.SetChildIndex(this.lblContaEntradaDetalhe, 0);
			this.Controls.SetChildIndex(this.lblContaSaidaDetalhe, 0);
			this.Controls.SetChildIndex(this.pictureBox1, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numTransferenciaAno)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numTransferenciaDia)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal System.Windows.Forms.Label lblCongregacao;
		internal System.Windows.Forms.TextBox txtDescricao;
		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label lbl_IdTexto;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnSalvar;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		private System.Windows.Forms.ToolStripButton btnFechar;
		private AwesomeShapeControl.Line line1;
		private CamadaUC.ucOnlyNumbers txtTransferenciaValor;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.TextBox txtContaEntrada;
		internal VIBlend.WinForms.Controls.vButton btnSetContaEntrada;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TextBox txtContaSaida;
		internal VIBlend.WinForms.Controls.vButton btnSetContaSaida;
		internal System.Windows.Forms.Label label8;
		internal System.Windows.Forms.Label label1;
		private CamadaUC.ucComboLimitedValues cmbTransferenciaMes;
		private System.Windows.Forms.NumericUpDown numTransferenciaAno;
		private System.Windows.Forms.NumericUpDown numTransferenciaDia;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.Label lblSitBlock;
		internal System.Windows.Forms.Label lblContaEntradaDetalhe;
		internal System.Windows.Forms.Label lblContaSaidaDetalhe;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
