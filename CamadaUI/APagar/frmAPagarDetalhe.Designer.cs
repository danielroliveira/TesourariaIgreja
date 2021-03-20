namespace CamadaUI.APagar
{
	partial class frmAPagarDetalhe
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAPagarDetalhe));
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.lblDespesaDescricao = new System.Windows.Forms.Label();
			this.txtIdentificador = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.numParcela = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSetForma = new VIBlend.WinForms.Controls.vButton();
			this.txtAPagarForma = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSetBanco = new VIBlend.WinForms.Controls.vButton();
			this.txtBanco = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtAPagarValor = new CamadaUC.ucOnlyNumbers();
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
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.lblIdentificador = new System.Windows.Forms.Label();
			this.lblParcela = new System.Windows.Forms.Label();
			this.lblAPagarForma = new System.Windows.Forms.Label();
			this.lblBanco = new System.Windows.Forms.Label();
			this.lblVencimento = new System.Windows.Forms.Label();
			this.lblAPagarValor = new System.Windows.Forms.Label();
			this.lblReferencia = new System.Windows.Forms.Label();
			this.pnlVisualizar = new System.Windows.Forms.Panel();
			this.pnlEditar = new System.Windows.Forms.Panel();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnOK = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.mnuImagem = new System.Windows.Forms.ToolStripDropDownButton();
			this.btnInserirImagem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnVerImagem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnRemoverImagem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numParcela)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numReferenciaAno)).BeginInit();
			this.panel2.SuspendLayout();
			this.pnlVisualizar.SuspendLayout();
			this.pnlEditar.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(757, 0);
			this.lblTitulo.Size = new System.Drawing.Size(266, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "A Pagar - Detalhamento";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(1023, 0);
			this.btnClose.TabIndex = 3;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblID);
			this.panel1.Controls.Add(this.lbl_IdTexto);
			this.panel1.Size = new System.Drawing.Size(1063, 50);
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
			this.txtIdentificador.TabIndex = 3;
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
			this.label2.TabIndex = 2;
			this.label2.Text = "No. Reg.";
			// 
			// numParcela
			// 
			this.numParcela.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numParcela.Location = new System.Drawing.Point(164, 54);
			this.numParcela.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.numParcela.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.numParcela.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numParcela.Name = "numParcela";
			this.numParcela.Size = new System.Drawing.Size(65, 31);
			this.numParcela.TabIndex = 5;
			this.numParcela.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(94, 59);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 19);
			this.label1.TabIndex = 4;
			this.label1.Text = "Parcela";
			// 
			// btnSetForma
			// 
			this.btnSetForma.AllowAnimations = true;
			this.btnSetForma.BackColor = System.Drawing.Color.Transparent;
			this.btnSetForma.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetForma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetForma.Location = new System.Drawing.Point(437, 97);
			this.btnSetForma.Name = "btnSetForma";
			this.btnSetForma.RoundedCornersMask = ((byte)(15));
			this.btnSetForma.RoundedCornersRadius = 0;
			this.btnSetForma.Size = new System.Drawing.Size(34, 27);
			this.btnSetForma.TabIndex = 8;
			this.btnSetForma.TabStop = false;
			this.btnSetForma.Text = "...";
			this.btnSetForma.UseCompatibleTextRendering = true;
			this.btnSetForma.UseVisualStyleBackColor = false;
			this.btnSetForma.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetForma.Click += new System.EventHandler(this.btnSetForma_Click);
			// 
			// txtAPagarForma
			// 
			this.txtAPagarForma.Location = new System.Drawing.Point(164, 97);
			this.txtAPagarForma.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtAPagarForma.MaxLength = 30;
			this.txtAPagarForma.Name = "txtAPagarForma";
			this.txtAPagarForma.Size = new System.Drawing.Size(267, 27);
			this.txtAPagarForma.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(24, 100);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(134, 19);
			this.label3.TabIndex = 6;
			this.label3.Text = "Forma de Cobrança";
			// 
			// btnSetBanco
			// 
			this.btnSetBanco.AllowAnimations = true;
			this.btnSetBanco.BackColor = System.Drawing.Color.Transparent;
			this.btnSetBanco.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetBanco.Location = new System.Drawing.Point(437, 136);
			this.btnSetBanco.Name = "btnSetBanco";
			this.btnSetBanco.RoundedCornersMask = ((byte)(15));
			this.btnSetBanco.RoundedCornersRadius = 0;
			this.btnSetBanco.Size = new System.Drawing.Size(34, 27);
			this.btnSetBanco.TabIndex = 11;
			this.btnSetBanco.TabStop = false;
			this.btnSetBanco.Text = "...";
			this.btnSetBanco.UseCompatibleTextRendering = true;
			this.btnSetBanco.UseVisualStyleBackColor = false;
			this.btnSetBanco.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetBanco.Click += new System.EventHandler(this.btnSetBanco_Click);
			// 
			// txtBanco
			// 
			this.txtBanco.Location = new System.Drawing.Point(164, 136);
			this.txtBanco.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtBanco.MaxLength = 30;
			this.txtBanco.Name = "txtBanco";
			this.txtBanco.Size = new System.Drawing.Size(267, 27);
			this.txtBanco.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(109, 139);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 19);
			this.label4.TabIndex = 9;
			this.label4.Text = "Banco";
			// 
			// txtAPagarValor
			// 
			this.txtAPagarValor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtAPagarValor.Inteiro = false;
			this.txtAPagarValor.Location = new System.Drawing.Point(164, 218);
			this.txtAPagarValor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtAPagarValor.Moeda = false;
			this.txtAPagarValor.Name = "txtAPagarValor";
			this.txtAPagarValor.Positivo = true;
			this.txtAPagarValor.Size = new System.Drawing.Size(145, 31);
			this.txtAPagarValor.TabIndex = 15;
			this.txtAPagarValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.ForeColor = System.Drawing.Color.Black;
			this.label8.Location = new System.Drawing.Point(116, 224);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(42, 19);
			this.label8.TabIndex = 14;
			this.label8.Text = "Valor";
			// 
			// dtpVencimento
			// 
			this.dtpVencimento.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpVencimento.Location = new System.Drawing.Point(164, 175);
			this.dtpVencimento.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.dtpVencimento.Name = "dtpVencimento";
			this.dtpVencimento.Size = new System.Drawing.Size(145, 31);
			this.dtpVencimento.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(73, 181);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(85, 19);
			this.label5.TabIndex = 12;
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
			this.label6.TabIndex = 17;
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
			this.label7.TabIndex = 16;
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
			this.cmbReferenciaMes.TabIndex = 19;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.ForeColor = System.Drawing.Color.Black;
			this.label9.Location = new System.Drawing.Point(79, 291);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(79, 19);
			this.label9.TabIndex = 18;
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
			this.numReferenciaAno.TabIndex = 20;
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
			this.panel2.TabIndex = 21;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.Transparent;
			this.label11.ForeColor = System.Drawing.Color.DarkGray;
			this.label11.Location = new System.Drawing.Point(9, 9);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(77, 19);
			this.label11.TabIndex = 2;
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
			this.lblCredor.TabIndex = 1;
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
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.BackColor = System.Drawing.Color.Transparent;
			this.label12.ForeColor = System.Drawing.Color.Black;
			this.label12.Location = new System.Drawing.Point(91, 19);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(68, 19);
			this.label12.TabIndex = 2;
			this.label12.Text = "No. Reg.:";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.BackColor = System.Drawing.Color.Transparent;
			this.label13.ForeColor = System.Drawing.Color.Black;
			this.label13.Location = new System.Drawing.Point(358, 181);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(61, 19);
			this.label13.TabIndex = 4;
			this.label13.Text = "Parcela:";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.BackColor = System.Drawing.Color.Transparent;
			this.label14.ForeColor = System.Drawing.Color.Black;
			this.label14.Location = new System.Drawing.Point(21, 73);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(138, 19);
			this.label14.TabIndex = 6;
			this.label14.Text = "Forma de Cobrança:";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.BackColor = System.Drawing.Color.Transparent;
			this.label15.ForeColor = System.Drawing.Color.Black;
			this.label15.Location = new System.Drawing.Point(106, 128);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(53, 19);
			this.label15.TabIndex = 9;
			this.label15.Text = "Banco:";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.BackColor = System.Drawing.Color.Transparent;
			this.label16.ForeColor = System.Drawing.Color.Black;
			this.label16.Location = new System.Drawing.Point(70, 181);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(89, 19);
			this.label16.TabIndex = 12;
			this.label16.Text = "Vencimento:";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.BackColor = System.Drawing.Color.Transparent;
			this.label17.ForeColor = System.Drawing.Color.Black;
			this.label17.Location = new System.Drawing.Point(76, 289);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(83, 19);
			this.label17.TabIndex = 18;
			this.label17.Text = "Referência:";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.BackColor = System.Drawing.Color.Transparent;
			this.label18.ForeColor = System.Drawing.Color.Black;
			this.label18.Location = new System.Drawing.Point(113, 236);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(46, 19);
			this.label18.TabIndex = 14;
			this.label18.Text = "Valor:";
			// 
			// lblIdentificador
			// 
			this.lblIdentificador.BackColor = System.Drawing.Color.White;
			this.lblIdentificador.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblIdentificador.Location = new System.Drawing.Point(161, 16);
			this.lblIdentificador.Name = "lblIdentificador";
			this.lblIdentificador.Size = new System.Drawing.Size(325, 27);
			this.lblIdentificador.TabIndex = 1;
			this.lblIdentificador.Text = "Identificador";
			this.lblIdentificador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblParcela
			// 
			this.lblParcela.BackColor = System.Drawing.Color.White;
			this.lblParcela.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblParcela.Location = new System.Drawing.Point(425, 178);
			this.lblParcela.Name = "lblParcela";
			this.lblParcela.Size = new System.Drawing.Size(61, 27);
			this.lblParcela.TabIndex = 1;
			this.lblParcela.Text = "00";
			this.lblParcela.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblAPagarForma
			// 
			this.lblAPagarForma.BackColor = System.Drawing.Color.White;
			this.lblAPagarForma.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAPagarForma.Location = new System.Drawing.Point(161, 70);
			this.lblAPagarForma.Name = "lblAPagarForma";
			this.lblAPagarForma.Size = new System.Drawing.Size(325, 27);
			this.lblAPagarForma.TabIndex = 1;
			this.lblAPagarForma.Text = "Forma de Cobrança";
			this.lblAPagarForma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblBanco
			// 
			this.lblBanco.BackColor = System.Drawing.Color.White;
			this.lblBanco.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBanco.Location = new System.Drawing.Point(161, 124);
			this.lblBanco.Name = "lblBanco";
			this.lblBanco.Size = new System.Drawing.Size(325, 27);
			this.lblBanco.TabIndex = 1;
			this.lblBanco.Text = "Banco de Cobrança";
			this.lblBanco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblVencimento
			// 
			this.lblVencimento.BackColor = System.Drawing.Color.White;
			this.lblVencimento.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblVencimento.Location = new System.Drawing.Point(161, 178);
			this.lblVencimento.Name = "lblVencimento";
			this.lblVencimento.Size = new System.Drawing.Size(182, 27);
			this.lblVencimento.TabIndex = 1;
			this.lblVencimento.Text = "Vencimento";
			this.lblVencimento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblAPagarValor
			// 
			this.lblAPagarValor.BackColor = System.Drawing.Color.White;
			this.lblAPagarValor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAPagarValor.Location = new System.Drawing.Point(161, 232);
			this.lblAPagarValor.Name = "lblAPagarValor";
			this.lblAPagarValor.Size = new System.Drawing.Size(182, 27);
			this.lblAPagarValor.TabIndex = 1;
			this.lblAPagarValor.Text = "R$ 0,00";
			this.lblAPagarValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblReferencia
			// 
			this.lblReferencia.BackColor = System.Drawing.Color.White;
			this.lblReferencia.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblReferencia.Location = new System.Drawing.Point(161, 286);
			this.lblReferencia.Name = "lblReferencia";
			this.lblReferencia.Size = new System.Drawing.Size(325, 27);
			this.lblReferencia.TabIndex = 1;
			this.lblReferencia.Text = "Mes/Ano";
			this.lblReferencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlVisualizar
			// 
			this.pnlVisualizar.BackColor = System.Drawing.Color.Transparent;
			this.pnlVisualizar.Controls.Add(this.lblIdentificador);
			this.pnlVisualizar.Controls.Add(this.label12);
			this.pnlVisualizar.Controls.Add(this.label13);
			this.pnlVisualizar.Controls.Add(this.label14);
			this.pnlVisualizar.Controls.Add(this.lblReferencia);
			this.pnlVisualizar.Controls.Add(this.label15);
			this.pnlVisualizar.Controls.Add(this.lblAPagarValor);
			this.pnlVisualizar.Controls.Add(this.label16);
			this.pnlVisualizar.Controls.Add(this.lblVencimento);
			this.pnlVisualizar.Controls.Add(this.label17);
			this.pnlVisualizar.Controls.Add(this.lblBanco);
			this.pnlVisualizar.Controls.Add(this.label18);
			this.pnlVisualizar.Controls.Add(this.lblAPagarForma);
			this.pnlVisualizar.Controls.Add(this.lblParcela);
			this.pnlVisualizar.Location = new System.Drawing.Point(544, 132);
			this.pnlVisualizar.Name = "pnlVisualizar";
			this.pnlVisualizar.Size = new System.Drawing.Size(505, 330);
			this.pnlVisualizar.TabIndex = 21;
			// 
			// pnlEditar
			// 
			this.pnlEditar.BackColor = System.Drawing.Color.Transparent;
			this.pnlEditar.Controls.Add(this.txtIdentificador);
			this.pnlEditar.Controls.Add(this.label2);
			this.pnlEditar.Controls.Add(this.label1);
			this.pnlEditar.Controls.Add(this.numParcela);
			this.pnlEditar.Controls.Add(this.numReferenciaAno);
			this.pnlEditar.Controls.Add(this.cmbReferenciaMes);
			this.pnlEditar.Controls.Add(this.label3);
			this.pnlEditar.Controls.Add(this.txtAPagarValor);
			this.pnlEditar.Controls.Add(this.txtAPagarForma);
			this.pnlEditar.Controls.Add(this.label8);
			this.pnlEditar.Controls.Add(this.btnSetForma);
			this.pnlEditar.Controls.Add(this.dtpVencimento);
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
			this.pnlEditar.TabIndex = 21;
			// 
			// tspMenu
			// 
			this.tspMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tspMenu.AutoSize = false;
			this.tspMenu.BackColor = System.Drawing.Color.AntiqueWhite;
			this.tspMenu.Dock = System.Windows.Forms.DockStyle.None;
			this.tspMenu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tspMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOK,
            this.btnFechar,
            this.mnuImagem});
			this.tspMenu.Location = new System.Drawing.Point(4, 489);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(524, 44);
			this.tspMenu.TabIndex = 22;
			this.tspMenu.TabStop = true;
			this.tspMenu.Text = "toolStrip1";
			// 
			// btnOK
			// 
			this.btnOK.AutoSize = false;
			this.btnOK.Image = global::CamadaUI.Properties.Resources.accept_24;
			this.btnOK.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnOK.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnOK.Name = "btnOK";
			this.btnOK.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnOK.Size = new System.Drawing.Size(110, 41);
			this.btnOK.Text = "&OK";
			this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnOK.Click += new System.EventHandler(this.btnClose_Click);
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
			// mnuImagem
			// 
			this.mnuImagem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInserirImagem,
            this.btnVerImagem,
            this.toolStripSeparator3,
            this.btnRemoverImagem});
			this.mnuImagem.Image = ((System.Drawing.Image)(resources.GetObject("mnuImagem.Image")));
			this.mnuImagem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuImagem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuImagem.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
			this.mnuImagem.Name = "mnuImagem";
			this.mnuImagem.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.mnuImagem.Size = new System.Drawing.Size(114, 41);
			this.mnuImagem.Text = "Imagem";
			this.mnuImagem.Click += new System.EventHandler(this.mnuImagem_Click);
			// 
			// btnInserirImagem
			// 
			this.btnInserirImagem.Image = global::CamadaUI.Properties.Resources.add_16;
			this.btnInserirImagem.Name = "btnInserirImagem";
			this.btnInserirImagem.Size = new System.Drawing.Size(191, 24);
			this.btnInserirImagem.Text = "Inserir Imagem";
			this.btnInserirImagem.Click += new System.EventHandler(this.btnInserirImagem_Click);
			// 
			// btnVerImagem
			// 
			this.btnVerImagem.Image = global::CamadaUI.Properties.Resources.search_page_24;
			this.btnVerImagem.Name = "btnVerImagem";
			this.btnVerImagem.Size = new System.Drawing.Size(191, 24);
			this.btnVerImagem.Text = "Ver Imagem";
			this.btnVerImagem.Click += new System.EventHandler(this.btnVerImagem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(188, 6);
			// 
			// btnRemoverImagem
			// 
			this.btnRemoverImagem.Image = global::CamadaUI.Properties.Resources.delete_16;
			this.btnRemoverImagem.Name = "btnRemoverImagem";
			this.btnRemoverImagem.Size = new System.Drawing.Size(191, 24);
			this.btnRemoverImagem.Text = "Remover Imagem";
			this.btnRemoverImagem.Click += new System.EventHandler(this.btnRemoverImagem_Click);
			// 
			// frmAPagarDetalhe
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(1063, 536);
			this.Controls.Add(this.tspMenu);
			this.Controls.Add(this.pnlVisualizar);
			this.Controls.Add(this.pnlEditar);
			this.Controls.Add(this.panel2);
			this.Name = "frmAPagarDetalhe";
			this.Activated += new System.EventHandler(this.form_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_FormClosed);
			this.Controls.SetChildIndex(this.panel2, 0);
			this.Controls.SetChildIndex(this.pnlEditar, 0);
			this.Controls.SetChildIndex(this.pnlVisualizar, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numParcela)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numReferenciaAno)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.pnlVisualizar.ResumeLayout(false);
			this.pnlVisualizar.PerformLayout();
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
		private System.Windows.Forms.NumericUpDown numParcela;
		internal System.Windows.Forms.Label label1;
		internal VIBlend.WinForms.Controls.vButton btnSetForma;
		internal System.Windows.Forms.TextBox txtAPagarForma;
		internal System.Windows.Forms.Label label3;
		internal VIBlend.WinForms.Controls.vButton btnSetBanco;
		internal System.Windows.Forms.TextBox txtBanco;
		internal System.Windows.Forms.Label label4;
		private CamadaUC.ucOnlyNumbers txtAPagarValor;
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
		internal System.Windows.Forms.Label label12;
		internal System.Windows.Forms.Label label13;
		internal System.Windows.Forms.Label label14;
		internal System.Windows.Forms.Label label15;
		internal System.Windows.Forms.Label label16;
		internal System.Windows.Forms.Label label17;
		internal System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label lblIdentificador;
		private System.Windows.Forms.Label lblParcela;
		private System.Windows.Forms.Label lblAPagarForma;
		private System.Windows.Forms.Label lblBanco;
		private System.Windows.Forms.Label lblVencimento;
		private System.Windows.Forms.Label lblAPagarValor;
		private System.Windows.Forms.Label lblReferencia;
		private System.Windows.Forms.Panel pnlVisualizar;
		private System.Windows.Forms.Panel pnlEditar;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnOK;
		private System.Windows.Forms.ToolStripButton btnFechar;
		private System.Windows.Forms.ToolStripDropDownButton mnuImagem;
		private System.Windows.Forms.ToolStripMenuItem btnInserirImagem;
		private System.Windows.Forms.ToolStripMenuItem btnVerImagem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem btnRemoverImagem;
	}
}
