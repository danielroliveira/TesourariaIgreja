namespace CamadaUI.AReceber
{
	partial class frmAReceberQuitar
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.lblEntradaForma = new System.Windows.Forms.Label();
			this.lblContaProvisoria = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.btnSetConta = new VIBlend.WinForms.Controls.vButton();
			this.txtConta = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.btnQuitar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.line1 = new AwesomeShapeControl.Line();
			this.numEntradaAno = new System.Windows.Forms.NumericUpDown();
			this.lblContaDetalhe = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.lblValorEmAberto = new System.Windows.Forms.Label();
			this.lblValorBruto = new System.Windows.Forms.Label();
			this.lblValorLiquido = new System.Windows.Forms.Label();
			this.lblValorRecebido = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDoValor = new CamadaUC.ucOnlyNumbers();
			this.txtEntradaDia = new CamadaUC.ucOnlyNumbers();
			this.cmbEntradaMes = new CamadaUC.ucComboLimitedValues();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numEntradaAno)).BeginInit();
			this.panel6.SuspendLayout();
			this.panel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(78, 0);
			this.lblTitulo.Size = new System.Drawing.Size(408, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Gerar Entradas - A Receber";
			// 
			// btnClose
			// 
			this.btnClose.CausesValidation = false;
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(486, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(526, 50);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(217)))), ((int)(((byte)(195)))));
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.lblEntradaForma);
			this.panel2.Controls.Add(this.lblContaProvisoria);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Location = new System.Drawing.Point(2, 50);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(522, 64);
			this.panel2.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.DarkGray;
			this.label1.Location = new System.Drawing.Point(18, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(127, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Forma de Entrada:";
			// 
			// lblEntradaForma
			// 
			this.lblEntradaForma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEntradaForma.BackColor = System.Drawing.Color.Transparent;
			this.lblEntradaForma.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEntradaForma.Location = new System.Drawing.Point(151, 4);
			this.lblEntradaForma.Name = "lblEntradaForma";
			this.lblEntradaForma.Size = new System.Drawing.Size(350, 27);
			this.lblEntradaForma.TabIndex = 1;
			this.lblEntradaForma.Text = "Forma da Entrada ";
			this.lblEntradaForma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblContaProvisoria
			// 
			this.lblContaProvisoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblContaProvisoria.BackColor = System.Drawing.Color.Transparent;
			this.lblContaProvisoria.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblContaProvisoria.Location = new System.Drawing.Point(151, 33);
			this.lblContaProvisoria.Name = "lblContaProvisoria";
			this.lblContaProvisoria.Size = new System.Drawing.Size(350, 27);
			this.lblContaProvisoria.TabIndex = 3;
			this.lblContaProvisoria.Text = "Conta Provisória";
			this.lblContaProvisoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.DarkGray;
			this.label2.Location = new System.Drawing.Point(40, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "Conta Origem:";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(175, 360);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(146, 19);
			this.label23.TabIndex = 12;
			this.label23.Text = "Valor a ser Recebido:";
			// 
			// btnSetConta
			// 
			this.btnSetConta.AllowAnimations = true;
			this.btnSetConta.BackColor = System.Drawing.Color.Transparent;
			this.btnSetConta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetConta.Location = new System.Drawing.Point(384, 135);
			this.btnSetConta.Name = "btnSetConta";
			this.btnSetConta.RoundedCornersMask = ((byte)(15));
			this.btnSetConta.RoundedCornersRadius = 0;
			this.btnSetConta.Size = new System.Drawing.Size(34, 27);
			this.btnSetConta.TabIndex = 4;
			this.btnSetConta.TabStop = false;
			this.btnSetConta.Text = "...";
			this.btnSetConta.UseCompatibleTextRendering = true;
			this.btnSetConta.UseVisualStyleBackColor = false;
			this.btnSetConta.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetConta.Click += new System.EventHandler(this.btnSetConta_Click);
			// 
			// txtConta
			// 
			this.txtConta.Location = new System.Drawing.Point(150, 135);
			this.txtConta.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtConta.MaxLength = 30;
			this.txtConta.Name = "txtConta";
			this.txtConta.Size = new System.Drawing.Size(228, 27);
			this.txtConta.TabIndex = 3;
			this.txtConta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.BackColor = System.Drawing.Color.Transparent;
			this.label19.ForeColor = System.Drawing.Color.Black;
			this.label19.Location = new System.Drawing.Point(30, 138);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(114, 19);
			this.label19.TabIndex = 2;
			this.label19.Text = "Conta Creditada";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.BackColor = System.Drawing.Color.Transparent;
			this.label26.ForeColor = System.Drawing.Color.Black;
			this.label26.Location = new System.Drawing.Point(110, 208);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(114, 19);
			this.label26.TabIndex = 6;
			this.label26.Text = "Data da Entrada";
			// 
			// btnQuitar
			// 
			this.btnQuitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnQuitar.Image = global::CamadaUI.Properties.Resources.money_green_32;
			this.btnQuitar.Location = new System.Drawing.Point(97, 450);
			this.btnQuitar.Name = "btnQuitar";
			this.btnQuitar.Size = new System.Drawing.Size(176, 49);
			this.btnQuitar.TabIndex = 15;
			this.btnQuitar.Text = "&Receber Parcial";
			this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnQuitar.UseVisualStyleBackColor = true;
			this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancelar.CausesValidation = false;
			this.btnCancelar.Image = global::CamadaUI.Properties.Resources.fechar_24;
			this.btnCancelar.Location = new System.Drawing.Point(283, 450);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(120, 49);
			this.btnCancelar.TabIndex = 16;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// line1
			// 
			this.line1.EndPoint = new System.Drawing.Point(485, 5);
			this.line1.LineColor = System.Drawing.Color.SlateGray;
			this.line1.LineWidth = 3F;
			this.line1.Location = new System.Drawing.Point(16, 428);
			this.line1.Name = "line1";
			this.line1.Size = new System.Drawing.Size(490, 10);
			this.line1.StartPoint = new System.Drawing.Point(5, 5);
			this.line1.TabIndex = 14;
			this.line1.TabStop = false;
			// 
			// numEntradaAno
			// 
			this.numEntradaAno.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numEntradaAno.Location = new System.Drawing.Point(328, 231);
			this.numEntradaAno.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
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
			this.numEntradaAno.Size = new System.Drawing.Size(86, 31);
			this.numEntradaAno.TabIndex = 9;
			this.numEntradaAno.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.numEntradaAno.Validating += new System.ComponentModel.CancelEventHandler(this.txtData_Validating);
			// 
			// lblContaDetalhe
			// 
			this.lblContaDetalhe.BackColor = System.Drawing.Color.Transparent;
			this.lblContaDetalhe.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblContaDetalhe.ForeColor = System.Drawing.Color.Black;
			this.lblContaDetalhe.Location = new System.Drawing.Point(150, 165);
			this.lblContaDetalhe.Name = "lblContaDetalhe";
			this.lblContaDetalhe.Size = new System.Drawing.Size(228, 35);
			this.lblContaDetalhe.TabIndex = 5;
			this.lblContaDetalhe.Text = "Saldo da Conta: R$ 0,00\r\nData de Bloqueio até: 01/01/2000";
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(217)))), ((int)(((byte)(195)))));
			this.panel6.Controls.Add(this.lblValorEmAberto);
			this.panel6.Controls.Add(this.lblValorBruto);
			this.panel6.Controls.Add(this.lblValorLiquido);
			this.panel6.Controls.Add(this.lblValorRecebido);
			this.panel6.Location = new System.Drawing.Point(2, 308);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(522, 37);
			this.panel6.TabIndex = 11;
			// 
			// lblValorEmAberto
			// 
			this.lblValorEmAberto.BackColor = System.Drawing.Color.Transparent;
			this.lblValorEmAberto.Font = new System.Drawing.Font("Pathway Gothic One", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorEmAberto.ForeColor = System.Drawing.Color.DarkRed;
			this.lblValorEmAberto.Location = new System.Drawing.Point(394, 5);
			this.lblValorEmAberto.Name = "lblValorEmAberto";
			this.lblValorEmAberto.Size = new System.Drawing.Size(110, 27);
			this.lblValorEmAberto.TabIndex = 3;
			this.lblValorEmAberto.Text = "R$ 0,00";
			this.lblValorEmAberto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblValorBruto
			// 
			this.lblValorBruto.BackColor = System.Drawing.Color.Transparent;
			this.lblValorBruto.Font = new System.Drawing.Font("Pathway Gothic One", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorBruto.Location = new System.Drawing.Point(20, 5);
			this.lblValorBruto.Name = "lblValorBruto";
			this.lblValorBruto.Size = new System.Drawing.Size(110, 27);
			this.lblValorBruto.TabIndex = 0;
			this.lblValorBruto.Text = "R$ 0,00";
			this.lblValorBruto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblValorLiquido
			// 
			this.lblValorLiquido.BackColor = System.Drawing.Color.Transparent;
			this.lblValorLiquido.Font = new System.Drawing.Font("Pathway Gothic One", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorLiquido.ForeColor = System.Drawing.Color.Black;
			this.lblValorLiquido.Location = new System.Drawing.Point(137, 5);
			this.lblValorLiquido.Name = "lblValorLiquido";
			this.lblValorLiquido.Size = new System.Drawing.Size(110, 27);
			this.lblValorLiquido.TabIndex = 2;
			this.lblValorLiquido.Text = "R$ 0,00";
			this.lblValorLiquido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblValorRecebido
			// 
			this.lblValorRecebido.BackColor = System.Drawing.Color.Transparent;
			this.lblValorRecebido.Font = new System.Drawing.Font("Pathway Gothic One", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorRecebido.ForeColor = System.Drawing.Color.DarkBlue;
			this.lblValorRecebido.Location = new System.Drawing.Point(268, 5);
			this.lblValorRecebido.Name = "lblValorRecebido";
			this.lblValorRecebido.Size = new System.Drawing.Size(110, 27);
			this.lblValorRecebido.TabIndex = 2;
			this.lblValorRecebido.Text = "R$ 0,00";
			this.lblValorRecebido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.White;
			this.panel5.Controls.Add(this.label3);
			this.panel5.Controls.Add(this.label18);
			this.panel5.Controls.Add(this.label4);
			this.panel5.Controls.Add(this.label5);
			this.panel5.Location = new System.Drawing.Point(2, 284);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(522, 24);
			this.panel5.TabIndex = 10;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(403, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(101, 19);
			this.label3.TabIndex = 3;
			this.label3.Text = "Vl. Em Aberto:";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.BackColor = System.Drawing.Color.Transparent;
			this.label18.ForeColor = System.Drawing.Color.Black;
			this.label18.Location = new System.Drawing.Point(21, 2);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(85, 19);
			this.label18.TabIndex = 0;
			this.label18.Text = "Valor Bruto:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(270, 2);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(110, 19);
			this.label4.TabIndex = 2;
			this.label4.Text = "Valor Recebido:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(152, 2);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(81, 19);
			this.label5.TabIndex = 1;
			this.label5.Text = "Vl. Liquido:";
			// 
			// txtDoValor
			// 
			this.txtDoValor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDoValor.Inteiro = false;
			this.txtDoValor.Location = new System.Drawing.Point(172, 385);
			this.txtDoValor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtDoValor.Name = "txtDoValor";
			this.txtDoValor.Positivo = true;
			this.txtDoValor.Size = new System.Drawing.Size(150, 31);
			this.txtDoValor.TabIndex = 13;
			this.txtDoValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDoValor.Validating += new System.ComponentModel.CancelEventHandler(this.txtDoValor_Validating);
			// 
			// txtEntradaDia
			// 
			this.txtEntradaDia.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEntradaDia.Inteiro = true;
			this.txtEntradaDia.Location = new System.Drawing.Point(114, 231);
			this.txtEntradaDia.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtEntradaDia.Name = "txtEntradaDia";
			this.txtEntradaDia.Positivo = true;
			this.txtEntradaDia.Size = new System.Drawing.Size(52, 31);
			this.txtEntradaDia.TabIndex = 7;
			this.txtEntradaDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtEntradaDia.Validating += new System.ComponentModel.CancelEventHandler(this.txtData_Validating);
			// 
			// cmbEntradaMes
			// 
			this.cmbEntradaMes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbEntradaMes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbEntradaMes.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbEntradaMes.FormattingEnabled = true;
			this.cmbEntradaMes.Location = new System.Drawing.Point(172, 231);
			this.cmbEntradaMes.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.cmbEntradaMes.Name = "cmbEntradaMes";
			this.cmbEntradaMes.Size = new System.Drawing.Size(150, 31);
			this.cmbEntradaMes.TabIndex = 8;
			this.cmbEntradaMes.Validating += new System.ComponentModel.CancelEventHandler(this.txtData_Validating);
			// 
			// frmAReceberQuitar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(526, 514);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.numEntradaAno);
			this.Controls.Add(this.line1);
			this.Controls.Add(this.txtDoValor);
			this.Controls.Add(this.btnQuitar);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.txtEntradaDia);
			this.Controls.Add(this.cmbEntradaMes);
			this.Controls.Add(this.btnSetConta);
			this.Controls.Add(this.txtConta);
			this.Controls.Add(this.lblContaDetalhe);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.label26);
			this.Controls.Add(this.label23);
			this.Controls.Add(this.panel2);
			this.KeyPreview = true;
			this.Name = "frmAReceberQuitar";
			this.Activated += new System.EventHandler(this.form_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_FormClosed);
			this.Shown += new System.EventHandler(this.frmAReceberQuitar_Shown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.panel2, 0);
			this.Controls.SetChildIndex(this.label23, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.label26, 0);
			this.Controls.SetChildIndex(this.label19, 0);
			this.Controls.SetChildIndex(this.lblContaDetalhe, 0);
			this.Controls.SetChildIndex(this.txtConta, 0);
			this.Controls.SetChildIndex(this.btnSetConta, 0);
			this.Controls.SetChildIndex(this.cmbEntradaMes, 0);
			this.Controls.SetChildIndex(this.txtEntradaDia, 0);
			this.Controls.SetChildIndex(this.btnCancelar, 0);
			this.Controls.SetChildIndex(this.btnQuitar, 0);
			this.Controls.SetChildIndex(this.txtDoValor, 0);
			this.Controls.SetChildIndex(this.line1, 0);
			this.Controls.SetChildIndex(this.numEntradaAno, 0);
			this.Controls.SetChildIndex(this.panel5, 0);
			this.Controls.SetChildIndex(this.panel6, 0);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numEntradaAno)).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Panel panel2;
		internal System.Windows.Forms.Label label23;
		private CamadaUC.ucOnlyNumbers txtEntradaDia;
		private CamadaUC.ucComboLimitedValues cmbEntradaMes;
		internal VIBlend.WinForms.Controls.vButton btnSetConta;
		internal System.Windows.Forms.TextBox txtConta;
		internal System.Windows.Forms.Label label19;
		internal System.Windows.Forms.Label label26;
		internal System.Windows.Forms.Button btnQuitar;
		internal System.Windows.Forms.Button btnCancelar;
		private CamadaUC.ucOnlyNumbers txtDoValor;
		private AwesomeShapeControl.Line line1;
		private System.Windows.Forms.NumericUpDown numEntradaAno;
		internal System.Windows.Forms.Label lblContaDetalhe;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label lblValorEmAberto;
		private System.Windows.Forms.Label lblValorBruto;
		private System.Windows.Forms.Label lblValorRecebido;
		private System.Windows.Forms.Panel panel5;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.Label label18;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblValorLiquido;
		internal System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblEntradaForma;
		private System.Windows.Forms.Label lblContaProvisoria;
		internal System.Windows.Forms.Label label2;
	}
}
