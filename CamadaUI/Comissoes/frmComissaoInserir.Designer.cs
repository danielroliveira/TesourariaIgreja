namespace CamadaUI.Comissoes
{
	partial class frmComissaoInserir
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
			this.btnSetColaborador = new VIBlend.WinForms.Controls.vButton();
			this.txtColaborador = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
			this.lblDataFinalLabel = new System.Windows.Forms.Label();
			this.lblDataInicial = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnEfetuar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.lblMaxDate = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblSetor = new System.Windows.Forms.Label();
			this.lblTaxa = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblQuantidade = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lblSomaTotal = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(257, 0);
			this.lblTitulo.Size = new System.Drawing.Size(307, 50);
			this.lblTitulo.Text = "Verificar | Inserir Comissão";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(564, 0);
			this.btnClose.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(604, 50);
			// 
			// btnSetColaborador
			// 
			this.btnSetColaborador.AllowAnimations = true;
			this.btnSetColaborador.BackColor = System.Drawing.Color.Transparent;
			this.btnSetColaborador.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetColaborador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetColaborador.Location = new System.Drawing.Point(516, 110);
			this.btnSetColaborador.Name = "btnSetColaborador";
			this.btnSetColaborador.RoundedCornersMask = ((byte)(15));
			this.btnSetColaborador.RoundedCornersRadius = 0;
			this.btnSetColaborador.Size = new System.Drawing.Size(34, 31);
			this.btnSetColaborador.TabIndex = 8;
			this.btnSetColaborador.TabStop = false;
			this.btnSetColaborador.Text = "...";
			this.btnSetColaborador.UseCompatibleTextRendering = true;
			this.btnSetColaborador.UseVisualStyleBackColor = false;
			this.btnSetColaborador.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetColaborador.Click += new System.EventHandler(this.btnSetColaborador_Click);
			// 
			// txtColaborador
			// 
			this.txtColaborador.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtColaborador.Location = new System.Drawing.Point(152, 110);
			this.txtColaborador.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtColaborador.MaxLength = 30;
			this.txtColaborador.Name = "txtColaborador";
			this.txtColaborador.Size = new System.Drawing.Size(358, 31);
			this.txtColaborador.TabIndex = 7;
			this.txtColaborador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.BackColor = System.Drawing.Color.Transparent;
			this.label19.ForeColor = System.Drawing.Color.Black;
			this.label19.Location = new System.Drawing.Point(58, 116);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(92, 19);
			this.label19.TabIndex = 6;
			this.label19.Text = "Colaborador:";
			// 
			// dtpDataFinal
			// 
			this.dtpDataFinal.Enabled = false;
			this.dtpDataFinal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDataFinal.Location = new System.Drawing.Point(209, 266);
			this.dtpDataFinal.Name = "dtpDataFinal";
			this.dtpDataFinal.Size = new System.Drawing.Size(151, 31);
			this.dtpDataFinal.TabIndex = 10;
			// 
			// lblDataFinalLabel
			// 
			this.lblDataFinalLabel.AutoSize = true;
			this.lblDataFinalLabel.BackColor = System.Drawing.Color.Transparent;
			this.lblDataFinalLabel.ForeColor = System.Drawing.Color.Black;
			this.lblDataFinalLabel.Location = new System.Drawing.Point(122, 271);
			this.lblDataFinalLabel.Name = "lblDataFinalLabel";
			this.lblDataFinalLabel.Size = new System.Drawing.Size(79, 19);
			this.lblDataFinalLabel.TabIndex = 6;
			this.lblDataFinalLabel.Text = "Data Final:";
			// 
			// lblDataInicial
			// 
			this.lblDataInicial.BackColor = System.Drawing.Color.Gainsboro;
			this.lblDataInicial.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDataInicial.Location = new System.Drawing.Point(209, 225);
			this.lblDataInicial.Name = "lblDataInicial";
			this.lblDataInicial.Size = new System.Drawing.Size(151, 29);
			this.lblDataInicial.TabIndex = 11;
			this.lblDataInicial.Text = "00/00/0000";
			this.lblDataInicial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(114, 229);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 19);
			this.label3.TabIndex = 6;
			this.label3.Text = "Data Inicial:";
			// 
			// btnEfetuar
			// 
			this.btnEfetuar.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnEfetuar.Enabled = false;
			this.btnEfetuar.Image = global::CamadaUI.Properties.Resources.accept_24;
			this.btnEfetuar.Location = new System.Drawing.Point(156, 7);
			this.btnEfetuar.Name = "btnEfetuar";
			this.btnEfetuar.Size = new System.Drawing.Size(132, 48);
			this.btnEfetuar.TabIndex = 17;
			this.btnEfetuar.Text = "&Inicializar";
			this.btnEfetuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnEfetuar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnEfetuar.UseVisualStyleBackColor = true;
			this.btnEfetuar.Click += new System.EventHandler(this.btnEfetuar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnCancelar.Image = global::CamadaUI.Properties.Resources.fechar_24;
			this.btnCancelar.Location = new System.Drawing.Point(295, 7);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(132, 48);
			this.btnCancelar.TabIndex = 18;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// lblMaxDate
			// 
			this.lblMaxDate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMaxDate.Location = new System.Drawing.Point(209, 300);
			this.lblMaxDate.Name = "lblMaxDate";
			this.lblMaxDate.Size = new System.Drawing.Size(138, 19);
			this.lblMaxDate.TabIndex = 19;
			this.lblMaxDate.Text = "Data máx.: 00/00/0000";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(51, 74);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(494, 25);
			this.label4.TabIndex = 20;
			this.label4.Text = "Escolha o COLABORADOR e a DATA FINAL:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(155, 157);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 19);
			this.label1.TabIndex = 6;
			this.label1.Text = "Setor:";
			// 
			// lblSetor
			// 
			this.lblSetor.BackColor = System.Drawing.Color.Gainsboro;
			this.lblSetor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSetor.Location = new System.Drawing.Point(209, 152);
			this.lblSetor.Name = "lblSetor";
			this.lblSetor.Size = new System.Drawing.Size(341, 29);
			this.lblSetor.TabIndex = 11;
			this.lblSetor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTaxa
			// 
			this.lblTaxa.BackColor = System.Drawing.Color.Gainsboro;
			this.lblTaxa.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTaxa.Location = new System.Drawing.Point(209, 188);
			this.lblTaxa.Name = "lblTaxa";
			this.lblTaxa.Size = new System.Drawing.Size(151, 29);
			this.lblTaxa.TabIndex = 22;
			this.lblTaxa.Text = "0,00%";
			this.lblTaxa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(158, 193);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(43, 19);
			this.label5.TabIndex = 21;
			this.label5.Text = "Taxa:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(64, 331);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(137, 19);
			this.label2.TabIndex = 6;
			this.label2.Text = "Qde. Contribuições:";
			// 
			// lblQuantidade
			// 
			this.lblQuantidade.BackColor = System.Drawing.Color.Gainsboro;
			this.lblQuantidade.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblQuantidade.Location = new System.Drawing.Point(209, 327);
			this.lblQuantidade.Name = "lblQuantidade";
			this.lblQuantidade.Size = new System.Drawing.Size(151, 29);
			this.lblQuantidade.TabIndex = 11;
			this.lblQuantidade.Text = "nenhum registro";
			this.lblQuantidade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.ForeColor = System.Drawing.Color.Black;
			this.label7.Location = new System.Drawing.Point(35, 369);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(166, 19);
			this.label7.TabIndex = 6;
			this.label7.Text = "Valor das Contribuições:";
			// 
			// lblSomaTotal
			// 
			this.lblSomaTotal.BackColor = System.Drawing.Color.Gainsboro;
			this.lblSomaTotal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSomaTotal.Location = new System.Drawing.Point(209, 364);
			this.lblSomaTotal.Name = "lblSomaTotal";
			this.lblSomaTotal.Size = new System.Drawing.Size(151, 29);
			this.lblSomaTotal.TabIndex = 11;
			this.lblSomaTotal.Text = "R$ 0,00";
			this.lblSomaTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
			this.panel2.Controls.Add(this.btnCancelar);
			this.panel2.Controls.Add(this.btnEfetuar);
			this.panel2.Location = new System.Drawing.Point(2, 430);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(600, 62);
			this.panel2.TabIndex = 23;
			// 
			// frmComissaoInserir
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(604, 494);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lblTaxa);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblMaxDate);
			this.Controls.Add(this.lblSetor);
			this.Controls.Add(this.lblSomaTotal);
			this.Controls.Add(this.lblQuantidade);
			this.Controls.Add(this.lblDataInicial);
			this.Controls.Add(this.dtpDataFinal);
			this.Controls.Add(this.btnSetColaborador);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtColaborador);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblDataFinalLabel);
			this.Controls.Add(this.label19);
			this.KeyPreview = true;
			this.Name = "frmComissaoInserir";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.label19, 0);
			this.Controls.SetChildIndex(this.lblDataFinalLabel, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.txtColaborador, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label7, 0);
			this.Controls.SetChildIndex(this.btnSetColaborador, 0);
			this.Controls.SetChildIndex(this.dtpDataFinal, 0);
			this.Controls.SetChildIndex(this.lblDataInicial, 0);
			this.Controls.SetChildIndex(this.lblQuantidade, 0);
			this.Controls.SetChildIndex(this.lblSomaTotal, 0);
			this.Controls.SetChildIndex(this.lblSetor, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.lblMaxDate, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.lblTaxa, 0);
			this.Controls.SetChildIndex(this.panel2, 0);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal VIBlend.WinForms.Controls.vButton btnSetColaborador;
		internal System.Windows.Forms.TextBox txtColaborador;
		internal System.Windows.Forms.Label label19;
		private System.Windows.Forms.DateTimePicker dtpDataFinal;
		internal System.Windows.Forms.Label lblDataFinalLabel;
		private System.Windows.Forms.Label lblDataInicial;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.Button btnEfetuar;
		internal System.Windows.Forms.Button btnCancelar;
		internal System.Windows.Forms.Label lblMaxDate;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblSetor;
		private System.Windows.Forms.Label lblTaxa;
		internal System.Windows.Forms.Label label5;
		internal System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblQuantidade;
		internal System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblSomaTotal;
		private System.Windows.Forms.Panel panel2;
	}
}
