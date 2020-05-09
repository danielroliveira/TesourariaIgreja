namespace CamadaUI.Entradas
{
	partial class frmContribuicaoCheque
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
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnOK = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtBanco = new System.Windows.Forms.TextBox();
			this.vButton1 = new VIBlend.WinForms.Controls.vButton();
			this.txtChequeNumero = new CamadaUC.ucOnlyNumbers();
			this.dtpDepositoData = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(216, 0);
			this.lblTitulo.Size = new System.Drawing.Size(225, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "Detalhes do Cheque";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(441, 0);
			this.btnClose.TabIndex = 3;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(481, 50);
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
            this.btnOK,
            this.btnCancelar});
			this.tspMenu.Location = new System.Drawing.Point(2, 222);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(476, 44);
			this.tspMenu.TabIndex = 12;
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
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnCancelar.Image = global::CamadaUI.Properties.Resources.fechar_30;
			this.btnCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnCancelar.Size = new System.Drawing.Size(110, 41);
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(89, 123);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 19);
			this.label4.TabIndex = 4;
			this.label4.Text = "Número";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(100, 84);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "Banco";
			// 
			// txtBanco
			// 
			this.txtBanco.Location = new System.Drawing.Point(155, 81);
			this.txtBanco.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtBanco.MaxLength = 30;
			this.txtBanco.Name = "txtBanco";
			this.txtBanco.Size = new System.Drawing.Size(228, 27);
			this.txtBanco.TabIndex = 2;
			this.txtBanco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// vButton1
			// 
			this.vButton1.AllowAnimations = true;
			this.vButton1.BackColor = System.Drawing.Color.Transparent;
			this.vButton1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.vButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.vButton1.Location = new System.Drawing.Point(389, 81);
			this.vButton1.Name = "vButton1";
			this.vButton1.RoundedCornersMask = ((byte)(15));
			this.vButton1.RoundedCornersRadius = 0;
			this.vButton1.Size = new System.Drawing.Size(34, 27);
			this.vButton1.TabIndex = 3;
			this.vButton1.TabStop = false;
			this.vButton1.Text = "...";
			this.vButton1.UseCompatibleTextRendering = true;
			this.vButton1.UseVisualStyleBackColor = false;
			this.vButton1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.vButton1.Click += new System.EventHandler(this.btnSetBanco_Click);
			// 
			// txtChequeNumero
			// 
			this.txtChequeNumero.Inteiro = true;
			this.txtChequeNumero.Location = new System.Drawing.Point(155, 120);
			this.txtChequeNumero.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtChequeNumero.Name = "txtChequeNumero";
			this.txtChequeNumero.Positivo = true;
			this.txtChequeNumero.Size = new System.Drawing.Size(100, 27);
			this.txtChequeNumero.TabIndex = 13;
			this.txtChequeNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// dtpDepositoData
			// 
			this.dtpDepositoData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDepositoData.Location = new System.Drawing.Point(155, 159);
			this.dtpDepositoData.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.dtpDepositoData.Name = "dtpDepositoData";
			this.dtpDepositoData.Size = new System.Drawing.Size(138, 27);
			this.dtpDepositoData.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(27, 162);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(122, 19);
			this.label1.TabIndex = 4;
			this.label1.Text = "Data do Depósito";
			// 
			// frmContribuicaoCheque
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(481, 268);
			this.Controls.Add(this.dtpDepositoData);
			this.Controls.Add(this.txtChequeNumero);
			this.Controls.Add(this.vButton1);
			this.Controls.Add(this.txtBanco);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tspMenu);
			this.KeyPreview = true;
			this.Name = "frmContribuicaoCheque";
			this.Activated += new System.EventHandler(this.form_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_FormClosed);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.txtBanco, 0);
			this.Controls.SetChildIndex(this.vButton1, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.txtChequeNumero, 0);
			this.Controls.SetChildIndex(this.dtpDepositoData, 0);
			this.panel1.ResumeLayout(false);
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnOK;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox txtBanco;
		internal VIBlend.WinForms.Controls.vButton vButton1;
		private CamadaUC.ucOnlyNumbers txtChequeNumero;
		private System.Windows.Forms.DateTimePicker dtpDepositoData;
		internal System.Windows.Forms.Label label1;
	}
}
