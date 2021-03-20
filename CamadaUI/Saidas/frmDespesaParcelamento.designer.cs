namespace CamadaUI.Saidas
{
	partial class frmDespesaParcelamento
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
			this.label2 = new System.Windows.Forms.Label();
			this.txtBanco = new System.Windows.Forms.TextBox();
			this.btnSetBanco = new VIBlend.WinForms.Controls.vButton();
			this.label1 = new System.Windows.Forms.Label();
			this.numVencimentoDia = new System.Windows.Forms.NumericUpDown();
			this.lblParcelas = new System.Windows.Forms.Label();
			this.btnSetForma = new VIBlend.WinForms.Controls.vButton();
			this.label3 = new System.Windows.Forms.Label();
			this.txtAPagarForma = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numVencimentoDia)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(179, 0);
			this.lblTitulo.Size = new System.Drawing.Size(293, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Detalhes do Parcelamento";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(472, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(512, 50);
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
			this.tspMenu.Size = new System.Drawing.Size(507, 44);
			this.tspMenu.TabIndex = 9;
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
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(114, 127);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 19);
			this.label2.TabIndex = 4;
			this.label2.Text = "Banco";
			// 
			// txtBanco
			// 
			this.txtBanco.Location = new System.Drawing.Point(169, 124);
			this.txtBanco.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtBanco.MaxLength = 30;
			this.txtBanco.Name = "txtBanco";
			this.txtBanco.Size = new System.Drawing.Size(267, 27);
			this.txtBanco.TabIndex = 5;
			this.txtBanco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// btnSetBanco
			// 
			this.btnSetBanco.AllowAnimations = true;
			this.btnSetBanco.BackColor = System.Drawing.Color.Transparent;
			this.btnSetBanco.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetBanco.Location = new System.Drawing.Point(442, 124);
			this.btnSetBanco.Name = "btnSetBanco";
			this.btnSetBanco.RoundedCornersMask = ((byte)(15));
			this.btnSetBanco.RoundedCornersRadius = 0;
			this.btnSetBanco.Size = new System.Drawing.Size(34, 27);
			this.btnSetBanco.TabIndex = 6;
			this.btnSetBanco.TabStop = false;
			this.btnSetBanco.Text = "...";
			this.btnSetBanco.UseCompatibleTextRendering = true;
			this.btnSetBanco.UseVisualStyleBackColor = false;
			this.btnSetBanco.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetBanco.Click += new System.EventHandler(this.btnSetBanco_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(32, 167);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(131, 19);
			this.label1.TabIndex = 7;
			this.label1.Text = "Dia do Vencimento";
			// 
			// numVencimentoDia
			// 
			this.numVencimentoDia.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numVencimentoDia.Location = new System.Drawing.Point(169, 163);
			this.numVencimentoDia.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.numVencimentoDia.Maximum = new decimal(new int[] {
			31,
			0,
			0,
			0});
			this.numVencimentoDia.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.numVencimentoDia.Name = "numVencimentoDia";
			this.numVencimentoDia.Size = new System.Drawing.Size(65, 31);
			this.numVencimentoDia.TabIndex = 8;
			this.numVencimentoDia.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.numVencimentoDia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_KeyDown);
			// 
			// lblParcelas
			// 
			this.lblParcelas.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblParcelas.Location = new System.Drawing.Point(351, 168);
			this.lblParcelas.Name = "lblParcelas";
			this.lblParcelas.Size = new System.Drawing.Size(125, 26);
			this.lblParcelas.TabIndex = 10;
			this.lblParcelas.Text = "Parcelas";
			this.lblParcelas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnSetForma
			// 
			this.btnSetForma.AllowAnimations = true;
			this.btnSetForma.BackColor = System.Drawing.Color.Transparent;
			this.btnSetForma.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetForma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetForma.Location = new System.Drawing.Point(442, 85);
			this.btnSetForma.Name = "btnSetForma";
			this.btnSetForma.RoundedCornersMask = ((byte)(15));
			this.btnSetForma.RoundedCornersRadius = 0;
			this.btnSetForma.Size = new System.Drawing.Size(34, 27);
			this.btnSetForma.TabIndex = 3;
			this.btnSetForma.TabStop = false;
			this.btnSetForma.Text = "...";
			this.btnSetForma.UseCompatibleTextRendering = true;
			this.btnSetForma.UseVisualStyleBackColor = false;
			this.btnSetForma.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetForma.Click += new System.EventHandler(this.btnSetForma_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(29, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(134, 19);
			this.label3.TabIndex = 1;
			this.label3.Text = "Forma de Cobrança";
			// 
			// txtAPagarForma
			// 
			this.txtAPagarForma.Location = new System.Drawing.Point(169, 85);
			this.txtAPagarForma.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtAPagarForma.MaxLength = 30;
			this.txtAPagarForma.Name = "txtAPagarForma";
			this.txtAPagarForma.Size = new System.Drawing.Size(267, 27);
			this.txtAPagarForma.TabIndex = 2;
			this.txtAPagarForma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// frmDespesaParcelamento
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(512, 268);
			this.Controls.Add(this.lblParcelas);
			this.Controls.Add(this.numVencimentoDia);
			this.Controls.Add(this.btnSetForma);
			this.Controls.Add(this.btnSetBanco);
			this.Controls.Add(this.txtAPagarForma);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtBanco);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tspMenu);
			this.KeyPreview = true;
			this.Name = "frmDespesaParcelamento";
			this.Activated += new System.EventHandler(this.form_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_FormClosed);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.txtBanco, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.txtAPagarForma, 0);
			this.Controls.SetChildIndex(this.btnSetBanco, 0);
			this.Controls.SetChildIndex(this.btnSetForma, 0);
			this.Controls.SetChildIndex(this.numVencimentoDia, 0);
			this.Controls.SetChildIndex(this.lblParcelas, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.panel1.ResumeLayout(false);
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numVencimentoDia)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnOK;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox txtBanco;
		internal VIBlend.WinForms.Controls.vButton btnSetBanco;
		internal System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numVencimentoDia;
		private System.Windows.Forms.Label lblParcelas;
		internal VIBlend.WinForms.Controls.vButton btnSetForma;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.TextBox txtAPagarForma;
	}
}
