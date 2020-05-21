namespace CamadaUI.APagar
{
	partial class frmAPagarAlterar
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
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.lblDespesaDescricao = new System.Windows.Forms.Label();
			this.txtIdentificador = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnSetForma = new VIBlend.WinForms.Controls.vButton();
			this.txtCobrancaForma = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSetBanco = new VIBlend.WinForms.Controls.vButton();
			this.txtBanco = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtValorDesconto = new CamadaUC.ucOnlyNumbers();
			this.label8 = new System.Windows.Forms.Label();
			this.dtpVencimento = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.cmbReferenciaMes = new CamadaUC.ucComboLimitedValues();
			this.label9 = new System.Windows.Forms.Label();
			this.numReferenciaAno = new System.Windows.Forms.NumericUpDown();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label11 = new System.Windows.Forms.Label();
			this.lblCredor = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.pnlEditar = new System.Windows.Forms.Panel();
			this.lblAPagarValor = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnAlterar = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numReferenciaAno)).BeginInit();
			this.panel2.SuspendLayout();
			this.pnlEditar.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(246, 0);
			this.lblTitulo.Size = new System.Drawing.Size(244, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "A Pagar - Alteração";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(490, 0);
			this.btnClose.TabIndex = 3;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblID);
			this.panel1.Controls.Add(this.lbl_IdTexto);
			this.panel1.Size = new System.Drawing.Size(530, 50);
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
			this.lblID.Location = new System.Drawing.Point(6, 16);
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
			this.lbl_IdTexto.Location = new System.Drawing.Point(33, 3);
			this.lbl_IdTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbl_IdTexto.Name = "lbl_IdTexto";
			this.lbl_IdTexto.Size = new System.Drawing.Size(35, 13);
			this.lbl_IdTexto.TabIndex = 1;
			this.lbl_IdTexto.Text = "Reg.";
			this.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblDespesaDescricao
			// 
			this.lblDespesaDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDespesaDescricao.BackColor = System.Drawing.Color.Transparent;
			this.lblDespesaDescricao.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDespesaDescricao.Location = new System.Drawing.Point(92, 6);
			this.lblDespesaDescricao.Name = "lblDespesaDescricao";
			this.lblDespesaDescricao.Size = new System.Drawing.Size(405, 27);
			this.lblDespesaDescricao.TabIndex = 1;
			this.lblDespesaDescricao.Text = "Descrição da Despesa";
			this.lblDespesaDescricao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtIdentificador
			// 
			this.txtIdentificador.BackColor = System.Drawing.Color.White;
			this.txtIdentificador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtIdentificador.Location = new System.Drawing.Point(164, 15);
			this.txtIdentificador.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtIdentificador.MaxLength = 100;
			this.txtIdentificador.Name = "txtIdentificador";
			this.txtIdentificador.Size = new System.Drawing.Size(157, 27);
			this.txtIdentificador.TabIndex = 1;
			this.txtIdentificador.Tag = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(94, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 19);
			this.label2.TabIndex = 0;
			this.label2.Text = "No. Reg.";
			// 
			// btnSetForma
			// 
			this.btnSetForma.AllowAnimations = true;
			this.btnSetForma.BackColor = System.Drawing.Color.Transparent;
			this.btnSetForma.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetForma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetForma.Location = new System.Drawing.Point(437, 54);
			this.btnSetForma.Name = "btnSetForma";
			this.btnSetForma.RoundedCornersMask = ((byte)(15));
			this.btnSetForma.RoundedCornersRadius = 0;
			this.btnSetForma.Size = new System.Drawing.Size(34, 27);
			this.btnSetForma.TabIndex = 4;
			this.btnSetForma.TabStop = false;
			this.btnSetForma.Text = "...";
			this.btnSetForma.UseCompatibleTextRendering = true;
			this.btnSetForma.UseVisualStyleBackColor = false;
			this.btnSetForma.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetForma.Click += new System.EventHandler(this.btnSetForma_Click);
			// 
			// txtCobrancaForma
			// 
			this.txtCobrancaForma.Location = new System.Drawing.Point(164, 54);
			this.txtCobrancaForma.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCobrancaForma.MaxLength = 30;
			this.txtCobrancaForma.Name = "txtCobrancaForma";
			this.txtCobrancaForma.Size = new System.Drawing.Size(267, 27);
			this.txtCobrancaForma.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(24, 57);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(134, 19);
			this.label3.TabIndex = 2;
			this.label3.Text = "Forma de Cobrança";
			// 
			// btnSetBanco
			// 
			this.btnSetBanco.AllowAnimations = true;
			this.btnSetBanco.BackColor = System.Drawing.Color.Transparent;
			this.btnSetBanco.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetBanco.Location = new System.Drawing.Point(437, 93);
			this.btnSetBanco.Name = "btnSetBanco";
			this.btnSetBanco.RoundedCornersMask = ((byte)(15));
			this.btnSetBanco.RoundedCornersRadius = 0;
			this.btnSetBanco.Size = new System.Drawing.Size(34, 27);
			this.btnSetBanco.TabIndex = 7;
			this.btnSetBanco.TabStop = false;
			this.btnSetBanco.Text = "...";
			this.btnSetBanco.UseCompatibleTextRendering = true;
			this.btnSetBanco.UseVisualStyleBackColor = false;
			this.btnSetBanco.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetBanco.Click += new System.EventHandler(this.btnSetBanco_Click);
			// 
			// txtBanco
			// 
			this.txtBanco.Location = new System.Drawing.Point(164, 93);
			this.txtBanco.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtBanco.MaxLength = 30;
			this.txtBanco.Name = "txtBanco";
			this.txtBanco.Size = new System.Drawing.Size(267, 27);
			this.txtBanco.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(109, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 19);
			this.label4.TabIndex = 5;
			this.label4.Text = "Banco";
			// 
			// txtValorDesconto
			// 
			this.txtValorDesconto.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtValorDesconto.Inteiro = false;
			this.txtValorDesconto.Location = new System.Drawing.Point(164, 218);
			this.txtValorDesconto.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtValorDesconto.Name = "txtValorDesconto";
			this.txtValorDesconto.Positivo = true;
			this.txtValorDesconto.Size = new System.Drawing.Size(145, 31);
			this.txtValorDesconto.TabIndex = 13;
			this.txtValorDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.ForeColor = System.Drawing.Color.Black;
			this.label8.Location = new System.Drawing.Point(88, 224);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(70, 19);
			this.label8.TabIndex = 12;
			this.label8.Text = "Desconto";
			// 
			// dtpVencimento
			// 
			this.dtpVencimento.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpVencimento.Location = new System.Drawing.Point(164, 132);
			this.dtpVencimento.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.dtpVencimento.Name = "dtpVencimento";
			this.dtpVencimento.Size = new System.Drawing.Size(145, 31);
			this.dtpVencimento.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(73, 138);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(85, 19);
			this.label5.TabIndex = 8;
			this.label5.Text = "Vencimento";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.ForeColor = System.Drawing.Color.Black;
			this.label6.Location = new System.Drawing.Point(327, 265);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 19);
			this.label6.TabIndex = 15;
			this.label6.Text = "Ano";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.ForeColor = System.Drawing.Color.Black;
			this.label7.Location = new System.Drawing.Point(160, 266);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(37, 19);
			this.label7.TabIndex = 14;
			this.label7.Text = "Mês";
			// 
			// cmbReferenciaMes
			// 
			this.cmbReferenciaMes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbReferenciaMes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbReferenciaMes.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbReferenciaMes.FormattingEnabled = true;
			this.cmbReferenciaMes.Location = new System.Drawing.Point(164, 288);
			this.cmbReferenciaMes.Name = "cmbReferenciaMes";
			this.cmbReferenciaMes.Size = new System.Drawing.Size(150, 27);
			this.cmbReferenciaMes.TabIndex = 17;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.ForeColor = System.Drawing.Color.Black;
			this.label9.Location = new System.Drawing.Point(79, 291);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(79, 19);
			this.label9.TabIndex = 16;
			this.label9.Text = "Referência";
			// 
			// numReferenciaAno
			// 
			this.numReferenciaAno.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numReferenciaAno.Location = new System.Drawing.Point(331, 288);
			this.numReferenciaAno.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.numReferenciaAno.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numReferenciaAno.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numReferenciaAno.Name = "numReferenciaAno";
			this.numReferenciaAno.Size = new System.Drawing.Size(86, 27);
			this.numReferenciaAno.TabIndex = 18;
			this.numReferenciaAno.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
			this.panel2.Controls.Add(this.label11);
			this.panel2.Controls.Add(this.lblCredor);
			this.panel2.Controls.Add(this.label10);
			this.panel2.Controls.Add(this.lblDespesaDescricao);
			this.panel2.Location = new System.Drawing.Point(12, 60);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(505, 64);
			this.panel2.TabIndex = 1;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.Transparent;
			this.label11.ForeColor = System.Drawing.Color.DarkGray;
			this.label11.Location = new System.Drawing.Point(9, 9);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(77, 19);
			this.label11.TabIndex = 0;
			this.label11.Text = "Descrição:";
			// 
			// lblCredor
			// 
			this.lblCredor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCredor.BackColor = System.Drawing.Color.Transparent;
			this.lblCredor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCredor.Location = new System.Drawing.Point(91, 33);
			this.lblCredor.Name = "lblCredor";
			this.lblCredor.Size = new System.Drawing.Size(406, 27);
			this.lblCredor.TabIndex = 3;
			this.lblCredor.Text = "Credor";
			this.lblCredor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.ForeColor = System.Drawing.Color.DarkGray;
			this.label10.Location = new System.Drawing.Point(30, 36);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 19);
			this.label10.TabIndex = 2;
			this.label10.Text = "Credor:";
			// 
			// pnlEditar
			// 
			this.pnlEditar.BackColor = System.Drawing.Color.Transparent;
			this.pnlEditar.Controls.Add(this.txtIdentificador);
			this.pnlEditar.Controls.Add(this.label2);
			this.pnlEditar.Controls.Add(this.numReferenciaAno);
			this.pnlEditar.Controls.Add(this.cmbReferenciaMes);
			this.pnlEditar.Controls.Add(this.label3);
			this.pnlEditar.Controls.Add(this.txtValorDesconto);
			this.pnlEditar.Controls.Add(this.lblAPagarValor);
			this.pnlEditar.Controls.Add(this.txtCobrancaForma);
			this.pnlEditar.Controls.Add(this.label8);
			this.pnlEditar.Controls.Add(this.btnSetForma);
			this.pnlEditar.Controls.Add(this.dtpVencimento);
			this.pnlEditar.Controls.Add(this.label18);
			this.pnlEditar.Controls.Add(this.label4);
			this.pnlEditar.Controls.Add(this.label9);
			this.pnlEditar.Controls.Add(this.txtBanco);
			this.pnlEditar.Controls.Add(this.label7);
			this.pnlEditar.Controls.Add(this.btnSetBanco);
			this.pnlEditar.Controls.Add(this.label6);
			this.pnlEditar.Controls.Add(this.label5);
			this.pnlEditar.Location = new System.Drawing.Point(12, 132);
			this.pnlEditar.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
			this.pnlEditar.Name = "pnlEditar";
			this.pnlEditar.Size = new System.Drawing.Size(505, 330);
			this.pnlEditar.TabIndex = 2;
			// 
			// lblAPagarValor
			// 
			this.lblAPagarValor.BackColor = System.Drawing.Color.Transparent;
			this.lblAPagarValor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAPagarValor.Location = new System.Drawing.Point(162, 177);
			this.lblAPagarValor.Name = "lblAPagarValor";
			this.lblAPagarValor.Size = new System.Drawing.Size(147, 27);
			this.lblAPagarValor.TabIndex = 11;
			this.lblAPagarValor.Text = "R$ 0,00";
			this.lblAPagarValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.BackColor = System.Drawing.Color.Transparent;
			this.label18.ForeColor = System.Drawing.Color.Black;
			this.label18.Location = new System.Drawing.Point(60, 181);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(98, 19);
			this.label18.TabIndex = 10;
			this.label18.Text = "Valor Original";
			// 
			// tspMenu
			// 
			this.tspMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tspMenu.AutoSize = false;
			this.tspMenu.BackColor = System.Drawing.Color.AntiqueWhite;
			this.tspMenu.Dock = System.Windows.Forms.DockStyle.None;
			this.tspMenu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tspMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAlterar,
            this.btnFechar});
			this.tspMenu.Location = new System.Drawing.Point(4, 474);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(524, 44);
			this.tspMenu.TabIndex = 3;
			this.tspMenu.TabStop = true;
			this.tspMenu.Text = "toolStrip1";
			// 
			// btnAlterar
			// 
			this.btnAlterar.AutoSize = false;
			this.btnAlterar.Enabled = false;
			this.btnAlterar.Image = global::CamadaUI.Properties.Resources.accept_24;
			this.btnAlterar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnAlterar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAlterar.Name = "btnAlterar";
			this.btnAlterar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnAlterar.Size = new System.Drawing.Size(110, 41);
			this.btnAlterar.Text = "&Alterar";
			this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
			// 
			// btnFechar
			// 
			this.btnFechar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.fechar_30;
			this.btnFechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnFechar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnFechar.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnFechar.Size = new System.Drawing.Size(110, 41);
			this.btnFechar.Text = "&Cancelar";
			this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFechar.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// frmAPagarAlterar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(530, 521);
			this.Controls.Add(this.tspMenu);
			this.Controls.Add(this.pnlEditar);
			this.Controls.Add(this.panel2);
			this.Name = "frmAPagarAlterar";
			this.Activated += new System.EventHandler(this.form_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_FormClosed);
			this.Controls.SetChildIndex(this.panel2, 0);
			this.Controls.SetChildIndex(this.pnlEditar, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numReferenciaAno)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.pnlEditar.ResumeLayout(false);
			this.pnlEditar.PerformLayout();
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label lbl_IdTexto;
		private System.Windows.Forms.Label lblDespesaDescricao;
		internal System.Windows.Forms.TextBox txtIdentificador;
		internal System.Windows.Forms.Label label2;
		internal VIBlend.WinForms.Controls.vButton btnSetForma;
		internal System.Windows.Forms.TextBox txtCobrancaForma;
		internal System.Windows.Forms.Label label3;
		internal VIBlend.WinForms.Controls.vButton btnSetBanco;
		internal System.Windows.Forms.TextBox txtBanco;
		internal System.Windows.Forms.Label label4;
		private CamadaUC.ucOnlyNumbers txtValorDesconto;
		internal System.Windows.Forms.Label label8;
		private System.Windows.Forms.DateTimePicker dtpVencimento;
		internal System.Windows.Forms.Label label5;
		internal System.Windows.Forms.Label label6;
		internal System.Windows.Forms.Label label7;
		private CamadaUC.ucComboLimitedValues cmbReferenciaMes;
		internal System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown numReferenciaAno;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblCredor;
		internal System.Windows.Forms.Label label11;
		internal System.Windows.Forms.Label label10;
		private System.Windows.Forms.Panel pnlEditar;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnAlterar;
		private System.Windows.Forms.ToolStripButton btnFechar;
		private System.Windows.Forms.Label lblAPagarValor;
		internal System.Windows.Forms.Label label18;
	}
}
