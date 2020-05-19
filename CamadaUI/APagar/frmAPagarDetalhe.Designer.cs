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
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.lblDespesaDescricao = new System.Windows.Forms.Label();
			this.txtIdentificador = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.numParcela = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSetForma = new VIBlend.WinForms.Controls.vButton();
			this.txtCobrancaForma = new System.Windows.Forms.TextBox();
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
			this.lblCredor = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numParcela)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numReferenciaAno)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(223, 0);
			this.lblTitulo.Size = new System.Drawing.Size(266, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "A Pagar - Detalhamento";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(489, 0);
			this.btnClose.TabIndex = 3;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblID);
			this.panel1.Controls.Add(this.lbl_IdTexto);
			this.panel1.Size = new System.Drawing.Size(529, 50);
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
			this.lblDespesaDescricao.BackColor = System.Drawing.Color.Transparent;
			this.lblDespesaDescricao.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDespesaDescricao.Location = new System.Drawing.Point(9, 3);
			this.lblDespesaDescricao.Name = "lblDespesaDescricao";
			this.lblDespesaDescricao.Size = new System.Drawing.Size(464, 27);
			this.lblDespesaDescricao.TabIndex = 1;
			this.lblDespesaDescricao.Text = "Descrição da Despesa";
			this.lblDespesaDescricao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtIdentificador
			// 
			this.txtIdentificador.BackColor = System.Drawing.Color.White;
			this.txtIdentificador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtIdentificador.Location = new System.Drawing.Point(180, 138);
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
			this.label2.Location = new System.Drawing.Point(110, 141);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "No. Reg.";
			// 
			// numParcela
			// 
			this.numParcela.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numParcela.Location = new System.Drawing.Point(180, 177);
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
			this.label1.Location = new System.Drawing.Point(110, 182);
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
			this.btnSetForma.Location = new System.Drawing.Point(453, 220);
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
			// txtCobrancaForma
			// 
			this.txtCobrancaForma.Location = new System.Drawing.Point(180, 220);
			this.txtCobrancaForma.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCobrancaForma.MaxLength = 30;
			this.txtCobrancaForma.Name = "txtCobrancaForma";
			this.txtCobrancaForma.Size = new System.Drawing.Size(267, 27);
			this.txtCobrancaForma.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(40, 223);
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
			this.btnSetBanco.Location = new System.Drawing.Point(453, 259);
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
			this.txtBanco.Location = new System.Drawing.Point(180, 259);
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
			this.label4.Location = new System.Drawing.Point(125, 262);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 19);
			this.label4.TabIndex = 9;
			this.label4.Text = "Banco";
			// 
			// txtAPagarValor
			// 
			this.txtAPagarValor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtAPagarValor.Inteiro = false;
			this.txtAPagarValor.Location = new System.Drawing.Point(180, 341);
			this.txtAPagarValor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
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
			this.label8.Location = new System.Drawing.Point(132, 347);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(42, 19);
			this.label8.TabIndex = 14;
			this.label8.Text = "Valor";
			// 
			// dtpVencimento
			// 
			this.dtpVencimento.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpVencimento.Location = new System.Drawing.Point(180, 298);
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
			this.label5.Location = new System.Drawing.Point(89, 304);
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
			this.label6.Location = new System.Drawing.Point(343, 388);
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
			this.label7.Location = new System.Drawing.Point(176, 389);
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
			this.cmbReferenciaMes.Location = new System.Drawing.Point(180, 411);
			this.cmbReferenciaMes.Name = "cmbReferenciaMes";
			this.cmbReferenciaMes.Size = new System.Drawing.Size(150, 27);
			this.cmbReferenciaMes.TabIndex = 19;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.ForeColor = System.Drawing.Color.Black;
			this.label9.Location = new System.Drawing.Point(95, 414);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(79, 19);
			this.label9.TabIndex = 18;
			this.label9.Text = "Referência";
			// 
			// numReferenciaAno
			// 
			this.numReferenciaAno.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numReferenciaAno.Location = new System.Drawing.Point(347, 411);
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
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(205)))), ((int)(((byte)(224)))));
			this.panel2.Controls.Add(this.lblCredor);
			this.panel2.Controls.Add(this.lblDespesaDescricao);
			this.panel2.Location = new System.Drawing.Point(23, 60);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(481, 64);
			this.panel2.TabIndex = 21;
			// 
			// lblCredor
			// 
			this.lblCredor.BackColor = System.Drawing.Color.Transparent;
			this.lblCredor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCredor.Location = new System.Drawing.Point(9, 33);
			this.lblCredor.Name = "lblCredor";
			this.lblCredor.Size = new System.Drawing.Size(464, 27);
			this.lblCredor.TabIndex = 1;
			this.lblCredor.Text = "Credor";
			this.lblCredor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmAPagarDetalhe
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(529, 478);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.cmbReferenciaMes);
			this.Controls.Add(this.txtAPagarValor);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.dtpVencimento);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnSetBanco);
			this.Controls.Add(this.txtBanco);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnSetForma);
			this.Controls.Add(this.txtCobrancaForma);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.numReferenciaAno);
			this.Controls.Add(this.numParcela);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtIdentificador);
			this.Controls.Add(this.label2);
			this.Name = "frmAPagarDetalhe";
			this.Activated += new System.EventHandler(this.form_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_FormClosed);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.txtIdentificador, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.numParcela, 0);
			this.Controls.SetChildIndex(this.numReferenciaAno, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.txtCobrancaForma, 0);
			this.Controls.SetChildIndex(this.btnSetForma, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.txtBanco, 0);
			this.Controls.SetChildIndex(this.btnSetBanco, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.label6, 0);
			this.Controls.SetChildIndex(this.label7, 0);
			this.Controls.SetChildIndex(this.label9, 0);
			this.Controls.SetChildIndex(this.dtpVencimento, 0);
			this.Controls.SetChildIndex(this.label8, 0);
			this.Controls.SetChildIndex(this.txtAPagarValor, 0);
			this.Controls.SetChildIndex(this.cmbReferenciaMes, 0);
			this.Controls.SetChildIndex(this.panel2, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numParcela)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numReferenciaAno)).EndInit();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

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
		internal System.Windows.Forms.TextBox txtCobrancaForma;
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
	}
}
