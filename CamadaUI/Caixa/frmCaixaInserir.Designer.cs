namespace CamadaUI.Caixa
{
	partial class frmCaixaInserir
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
			this.btnSetConta = new VIBlend.WinForms.Controls.vButton();
			this.txtConta = new System.Windows.Forms.TextBox();
			this.lblContaDetalhe = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
			this.lblDataFinalLabel = new System.Windows.Forms.Label();
			this.lblDataInicial = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.Panel2 = new System.Windows.Forms.Panel();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.rbtPeriodo = new System.Windows.Forms.RadioButton();
			this.btnEfetuar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.lblMaxDate = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblDataFinalText = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.Panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(181, 0);
			this.lblTitulo.Text = "Finalização de Caixa";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(440, 0);
			this.btnClose.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(480, 50);
			// 
			// btnSetConta
			// 
			this.btnSetConta.AllowAnimations = true;
			this.btnSetConta.BackColor = System.Drawing.Color.Transparent;
			this.btnSetConta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetConta.Location = new System.Drawing.Point(417, 104);
			this.btnSetConta.Name = "btnSetConta";
			this.btnSetConta.RoundedCornersMask = ((byte)(15));
			this.btnSetConta.RoundedCornersRadius = 0;
			this.btnSetConta.Size = new System.Drawing.Size(34, 31);
			this.btnSetConta.TabIndex = 8;
			this.btnSetConta.TabStop = false;
			this.btnSetConta.Text = "...";
			this.btnSetConta.UseCompatibleTextRendering = true;
			this.btnSetConta.UseVisualStyleBackColor = false;
			this.btnSetConta.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetConta.Click += new System.EventHandler(this.btnSetConta_Click);
			// 
			// txtConta
			// 
			this.txtConta.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtConta.Location = new System.Drawing.Point(137, 104);
			this.txtConta.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtConta.MaxLength = 30;
			this.txtConta.Name = "txtConta";
			this.txtConta.Size = new System.Drawing.Size(274, 31);
			this.txtConta.TabIndex = 7;
			this.txtConta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// lblContaDetalhe
			// 
			this.lblContaDetalhe.BackColor = System.Drawing.Color.Transparent;
			this.lblContaDetalhe.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblContaDetalhe.ForeColor = System.Drawing.Color.Black;
			this.lblContaDetalhe.Location = new System.Drawing.Point(137, 138);
			this.lblContaDetalhe.Name = "lblContaDetalhe";
			this.lblContaDetalhe.Size = new System.Drawing.Size(228, 35);
			this.lblContaDetalhe.TabIndex = 9;
			this.lblContaDetalhe.Text = "Saldo da Conta: R$ 0,00\r\nData de Bloqueio até: 01/01/2000";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.BackColor = System.Drawing.Color.Transparent;
			this.label19.ForeColor = System.Drawing.Color.Black;
			this.label19.Location = new System.Drawing.Point(21, 107);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(107, 19);
			this.label19.TabIndex = 6;
			this.label19.Text = "Conta do Caixa";
			// 
			// dtpDataFinal
			// 
			this.dtpDataFinal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDataFinal.Location = new System.Drawing.Point(134, 282);
			this.dtpDataFinal.Name = "dtpDataFinal";
			this.dtpDataFinal.Size = new System.Drawing.Size(157, 31);
			this.dtpDataFinal.TabIndex = 10;
			// 
			// lblDataFinalLabel
			// 
			this.lblDataFinalLabel.AutoSize = true;
			this.lblDataFinalLabel.BackColor = System.Drawing.Color.Transparent;
			this.lblDataFinalLabel.ForeColor = System.Drawing.Color.Black;
			this.lblDataFinalLabel.Location = new System.Drawing.Point(50, 289);
			this.lblDataFinalLabel.Name = "lblDataFinalLabel";
			this.lblDataFinalLabel.Size = new System.Drawing.Size(79, 19);
			this.lblDataFinalLabel.TabIndex = 6;
			this.lblDataFinalLabel.Text = "Data Final:";
			// 
			// lblDataInicial
			// 
			this.lblDataInicial.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDataInicial.Location = new System.Drawing.Point(133, 242);
			this.lblDataInicial.Name = "lblDataInicial";
			this.lblDataInicial.Size = new System.Drawing.Size(151, 29);
			this.lblDataInicial.TabIndex = 11;
			this.lblDataInicial.Text = "00/00/0000";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(42, 245);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 19);
			this.label3.TabIndex = 6;
			this.label3.Text = "Data Inicial:";
			// 
			// Panel2
			// 
			this.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
			this.Panel2.Controls.Add(this.radioButton2);
			this.Panel2.Controls.Add(this.rbtPeriodo);
			this.Panel2.Location = new System.Drawing.Point(3, 193);
			this.Panel2.Margin = new System.Windows.Forms.Padding(1);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(474, 35);
			this.Panel2.TabIndex = 12;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(279, 6);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(66, 23);
			this.radioButton2.TabIndex = 0;
			this.radioButton2.Text = "Diário";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// rbtPeriodo
			// 
			this.rbtPeriodo.AutoSize = true;
			this.rbtPeriodo.Checked = true;
			this.rbtPeriodo.Location = new System.Drawing.Point(106, 6);
			this.rbtPeriodo.Name = "rbtPeriodo";
			this.rbtPeriodo.Size = new System.Drawing.Size(143, 23);
			this.rbtPeriodo.TabIndex = 0;
			this.rbtPeriodo.TabStop = true;
			this.rbtPeriodo.Text = "Período de Tempo";
			this.rbtPeriodo.UseVisualStyleBackColor = true;
			this.rbtPeriodo.CheckedChanged += new System.EventHandler(this.rbtPeriodo_CheckedChanged);
			// 
			// btnEfetuar
			// 
			this.btnEfetuar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnEfetuar.Enabled = false;
			this.btnEfetuar.Image = global::CamadaUI.Properties.Resources.accept_24;
			this.btnEfetuar.Location = new System.Drawing.Point(115, 362);
			this.btnEfetuar.Name = "btnEfetuar";
			this.btnEfetuar.Size = new System.Drawing.Size(120, 48);
			this.btnEfetuar.TabIndex = 17;
			this.btnEfetuar.Text = "&Efetuar";
			this.btnEfetuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnEfetuar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnEfetuar.UseVisualStyleBackColor = true;
			this.btnEfetuar.Click += new System.EventHandler(this.btnEfetuar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancelar.Image = global::CamadaUI.Properties.Resources.fechar_24;
			this.btnCancelar.Location = new System.Drawing.Point(245, 362);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(120, 48);
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
			this.lblMaxDate.Location = new System.Drawing.Point(134, 316);
			this.lblMaxDate.Name = "lblMaxDate";
			this.lblMaxDate.Size = new System.Drawing.Size(138, 19);
			this.lblMaxDate.TabIndex = 19;
			this.lblMaxDate.Text = "máx.: 00/00/0000";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(57, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(378, 25);
			this.label4.TabIndex = 20;
			this.label4.Text = "Escolha a CONTA e a DATA para efetuar o fechamento:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblDataFinalText
			// 
			this.lblDataFinalText.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDataFinalText.Location = new System.Drawing.Point(317, 286);
			this.lblDataFinalText.Name = "lblDataFinalText";
			this.lblDataFinalText.Size = new System.Drawing.Size(151, 29);
			this.lblDataFinalText.TabIndex = 11;
			this.lblDataFinalText.Text = "00/00/0000";
			this.lblDataFinalText.Visible = false;
			// 
			// frmCaixaInserir
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(480, 433);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblMaxDate);
			this.Controls.Add(this.btnEfetuar);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.Panel2);
			this.Controls.Add(this.lblDataFinalText);
			this.Controls.Add(this.lblDataInicial);
			this.Controls.Add(this.dtpDataFinal);
			this.Controls.Add(this.btnSetConta);
			this.Controls.Add(this.txtConta);
			this.Controls.Add(this.lblContaDetalhe);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblDataFinalLabel);
			this.Controls.Add(this.label19);
			this.KeyPreview = true;
			this.Name = "frmCaixaInserir";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.label19, 0);
			this.Controls.SetChildIndex(this.lblDataFinalLabel, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.lblContaDetalhe, 0);
			this.Controls.SetChildIndex(this.txtConta, 0);
			this.Controls.SetChildIndex(this.btnSetConta, 0);
			this.Controls.SetChildIndex(this.dtpDataFinal, 0);
			this.Controls.SetChildIndex(this.lblDataInicial, 0);
			this.Controls.SetChildIndex(this.lblDataFinalText, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.Panel2, 0);
			this.Controls.SetChildIndex(this.btnCancelar, 0);
			this.Controls.SetChildIndex(this.btnEfetuar, 0);
			this.Controls.SetChildIndex(this.lblMaxDate, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.panel1.ResumeLayout(false);
			this.Panel2.ResumeLayout(false);
			this.Panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal VIBlend.WinForms.Controls.vButton btnSetConta;
		internal System.Windows.Forms.TextBox txtConta;
		internal System.Windows.Forms.Label lblContaDetalhe;
		internal System.Windows.Forms.Label label19;
		private System.Windows.Forms.DateTimePicker dtpDataFinal;
		internal System.Windows.Forms.Label lblDataFinalLabel;
		private System.Windows.Forms.Label lblDataInicial;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.Panel Panel2;
		internal System.Windows.Forms.Button btnEfetuar;
		internal System.Windows.Forms.Button btnCancelar;
		internal System.Windows.Forms.Label lblMaxDate;
		internal System.Windows.Forms.Label label4;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton rbtPeriodo;
		private System.Windows.Forms.Label lblDataFinalText;
	}
}
