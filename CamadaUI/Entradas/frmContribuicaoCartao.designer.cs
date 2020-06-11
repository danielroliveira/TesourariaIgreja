namespace CamadaUI.Entradas
{
	partial class frmContribuicaoCartao
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
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnOK = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCartaoBandeira = new System.Windows.Forms.TextBox();
			this.btnSetBandeira = new VIBlend.WinForms.Controls.vButton();
			this.label4 = new System.Windows.Forms.Label();
			this.txtCartaoOperadora = new System.Windows.Forms.TextBox();
			this.lblParcelas = new System.Windows.Forms.Label();
			this.btnSetOperadora = new VIBlend.WinForms.Controls.vButton();
			this.numParcelas = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCartaoTipo = new System.Windows.Forms.TextBox();
			this.btnSetCartaoTipo = new VIBlend.WinForms.Controls.vButton();
			this.lblSitBlock = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numParcelas)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(216, 0);
			this.lblTitulo.Size = new System.Drawing.Size(225, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "Detalhes do Cartão";
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
			this.panel1.Controls.Add(this.lblID);
			this.panel1.Controls.Add(this.lbl_IdTexto);
			this.panel1.Size = new System.Drawing.Size(481, 50);
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
            this.btnOK,
            this.btnCancelar});
			this.tspMenu.Location = new System.Drawing.Point(2, 247);
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
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(25, 155);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(134, 19);
			this.label3.TabIndex = 7;
			this.label3.Text = "Bandeira do Cartão";
			// 
			// txtCartaoBandeira
			// 
			this.txtCartaoBandeira.Location = new System.Drawing.Point(165, 152);
			this.txtCartaoBandeira.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCartaoBandeira.MaxLength = 30;
			this.txtCartaoBandeira.Name = "txtCartaoBandeira";
			this.txtCartaoBandeira.Size = new System.Drawing.Size(228, 27);
			this.txtCartaoBandeira.TabIndex = 8;
			this.txtCartaoBandeira.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			this.txtCartaoBandeira.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
			// 
			// btnSetBandeira
			// 
			this.btnSetBandeira.AllowAnimations = true;
			this.btnSetBandeira.BackColor = System.Drawing.Color.Transparent;
			this.btnSetBandeira.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetBandeira.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetBandeira.Location = new System.Drawing.Point(399, 152);
			this.btnSetBandeira.Name = "btnSetBandeira";
			this.btnSetBandeira.RoundedCornersMask = ((byte)(15));
			this.btnSetBandeira.RoundedCornersRadius = 0;
			this.btnSetBandeira.Size = new System.Drawing.Size(34, 27);
			this.btnSetBandeira.TabIndex = 9;
			this.btnSetBandeira.TabStop = false;
			this.btnSetBandeira.Text = "n";
			this.btnSetBandeira.UseCompatibleTextRendering = true;
			this.btnSetBandeira.UseVisualStyleBackColor = false;
			this.btnSetBandeira.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetBandeira.Click += new System.EventHandler(this.btnSetBandeira_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(81, 116);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 19);
			this.label4.TabIndex = 4;
			this.label4.Text = "Operadora";
			// 
			// txtCartaoOperadora
			// 
			this.txtCartaoOperadora.Location = new System.Drawing.Point(165, 113);
			this.txtCartaoOperadora.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCartaoOperadora.MaxLength = 30;
			this.txtCartaoOperadora.Name = "txtCartaoOperadora";
			this.txtCartaoOperadora.Size = new System.Drawing.Size(228, 27);
			this.txtCartaoOperadora.TabIndex = 5;
			this.txtCartaoOperadora.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			this.txtCartaoOperadora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
			// 
			// lblParcelas
			// 
			this.lblParcelas.AutoSize = true;
			this.lblParcelas.BackColor = System.Drawing.Color.Transparent;
			this.lblParcelas.ForeColor = System.Drawing.Color.Silver;
			this.lblParcelas.Location = new System.Drawing.Point(95, 196);
			this.lblParcelas.Name = "lblParcelas";
			this.lblParcelas.Size = new System.Drawing.Size(64, 19);
			this.lblParcelas.TabIndex = 10;
			this.lblParcelas.Text = "Parcelas";
			// 
			// btnSetOperadora
			// 
			this.btnSetOperadora.AllowAnimations = true;
			this.btnSetOperadora.BackColor = System.Drawing.Color.Transparent;
			this.btnSetOperadora.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetOperadora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetOperadora.Location = new System.Drawing.Point(399, 113);
			this.btnSetOperadora.Name = "btnSetOperadora";
			this.btnSetOperadora.RoundedCornersMask = ((byte)(15));
			this.btnSetOperadora.RoundedCornersRadius = 0;
			this.btnSetOperadora.Size = new System.Drawing.Size(34, 27);
			this.btnSetOperadora.TabIndex = 6;
			this.btnSetOperadora.TabStop = false;
			this.btnSetOperadora.Text = "n";
			this.btnSetOperadora.UseCompatibleTextRendering = true;
			this.btnSetOperadora.UseVisualStyleBackColor = false;
			this.btnSetOperadora.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetOperadora.Click += new System.EventHandler(this.btnSetOperadora_Click);
			// 
			// numParcelas
			// 
			this.numParcelas.Enabled = false;
			this.numParcelas.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numParcelas.Location = new System.Drawing.Point(165, 191);
			this.numParcelas.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.numParcelas.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numParcelas.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.numParcelas.Name = "numParcelas";
			this.numParcelas.Size = new System.Drawing.Size(65, 31);
			this.numParcelas.TabIndex = 11;
			this.numParcelas.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.numParcelas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numParcelas_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(55, 77);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "Tipo de Cartão";
			// 
			// txtCartaoTipo
			// 
			this.txtCartaoTipo.Location = new System.Drawing.Point(165, 74);
			this.txtCartaoTipo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCartaoTipo.MaxLength = 30;
			this.txtCartaoTipo.Name = "txtCartaoTipo";
			this.txtCartaoTipo.Size = new System.Drawing.Size(228, 27);
			this.txtCartaoTipo.TabIndex = 2;
			this.txtCartaoTipo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			this.txtCartaoTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
			// 
			// btnSetCartaoTipo
			// 
			this.btnSetCartaoTipo.AllowAnimations = true;
			this.btnSetCartaoTipo.BackColor = System.Drawing.Color.Transparent;
			this.btnSetCartaoTipo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetCartaoTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetCartaoTipo.Location = new System.Drawing.Point(399, 74);
			this.btnSetCartaoTipo.Name = "btnSetCartaoTipo";
			this.btnSetCartaoTipo.RoundedCornersMask = ((byte)(15));
			this.btnSetCartaoTipo.RoundedCornersRadius = 0;
			this.btnSetCartaoTipo.Size = new System.Drawing.Size(34, 27);
			this.btnSetCartaoTipo.TabIndex = 3;
			this.btnSetCartaoTipo.TabStop = false;
			this.btnSetCartaoTipo.Text = "n";
			this.btnSetCartaoTipo.UseCompatibleTextRendering = true;
			this.btnSetCartaoTipo.UseVisualStyleBackColor = false;
			this.btnSetCartaoTipo.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetCartaoTipo.Click += new System.EventHandler(this.btnSetCartaoTipo_Click);
			// 
			// lblSitBlock
			// 
			this.lblSitBlock.AutoSize = true;
			this.lblSitBlock.BackColor = System.Drawing.Color.AntiqueWhite;
			this.lblSitBlock.Font = new System.Drawing.Font("Pathway Gothic One", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSitBlock.ForeColor = System.Drawing.Color.Maroon;
			this.lblSitBlock.Location = new System.Drawing.Point(161, 257);
			this.lblSitBlock.Name = "lblSitBlock";
			this.lblSitBlock.Size = new System.Drawing.Size(157, 24);
			this.lblSitBlock.TabIndex = 34;
			this.lblSitBlock.Text = "- Apenas Visualização -";
			// 
			// frmContribuicaoCartao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(481, 293);
			this.Controls.Add(this.lblSitBlock);
			this.Controls.Add(this.numParcelas);
			this.Controls.Add(this.btnSetBandeira);
			this.Controls.Add(this.btnSetCartaoTipo);
			this.Controls.Add(this.btnSetOperadora);
			this.Controls.Add(this.txtCartaoTipo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtCartaoOperadora);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtCartaoBandeira);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblParcelas);
			this.Controls.Add(this.tspMenu);
			this.KeyPreview = true;
			this.Name = "frmContribuicaoCartao";
			this.Activated += new System.EventHandler(this.form_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_FormClosed);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEntrada_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.lblParcelas, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.txtCartaoBandeira, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.txtCartaoOperadora, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.txtCartaoTipo, 0);
			this.Controls.SetChildIndex(this.btnSetOperadora, 0);
			this.Controls.SetChildIndex(this.btnSetCartaoTipo, 0);
			this.Controls.SetChildIndex(this.btnSetBandeira, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.numParcelas, 0);
			this.Controls.SetChildIndex(this.lblSitBlock, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numParcelas)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label lbl_IdTexto;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnOK;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.TextBox txtCartaoBandeira;
		internal VIBlend.WinForms.Controls.vButton btnSetBandeira;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TextBox txtCartaoOperadora;
		internal System.Windows.Forms.Label lblParcelas;
		internal VIBlend.WinForms.Controls.vButton btnSetOperadora;
		private System.Windows.Forms.NumericUpDown numParcelas;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox txtCartaoTipo;
		internal VIBlend.WinForms.Controls.vButton btnSetCartaoTipo;
		private System.Windows.Forms.Label lblSitBlock;
	}
}
