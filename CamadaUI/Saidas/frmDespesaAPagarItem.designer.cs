﻿namespace CamadaUI.Saidas
{
	partial class frmDespesaAPagarItem
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
			this.lblVencimento = new System.Windows.Forms.Label();
			this.btnSetForma = new VIBlend.WinForms.Controls.vButton();
			this.label3 = new System.Windows.Forms.Label();
			this.txtAPagarForma = new System.Windows.Forms.TextBox();
			this.dtpVencimento = new System.Windows.Forms.DateTimePicker();
			this.txtAPagarValor = new CamadaUC.ucOnlyNumbers();
			this.label8 = new System.Windows.Forms.Label();
			this.txtIdentificador = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(313, 0);
			this.lblTitulo.Size = new System.Drawing.Size(182, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "APagar Parcela";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(495, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(535, 50);
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
			this.tspMenu.Location = new System.Drawing.Point(2, 310);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(530, 44);
			this.tspMenu.TabIndex = 13;
			this.tspMenu.TabStop = true;
			this.tspMenu.Text = "toolStrip1";
			this.tspMenu.Enter += new System.EventHandler(this.tspMenu_Enter);
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
			this.label2.Location = new System.Drawing.Point(127, 164);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 19);
			this.label2.TabIndex = 6;
			this.label2.Text = "Banco";
			// 
			// txtBanco
			// 
			this.txtBanco.Location = new System.Drawing.Point(184, 161);
			this.txtBanco.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtBanco.MaxLength = 30;
			this.txtBanco.Name = "txtBanco";
			this.txtBanco.Size = new System.Drawing.Size(267, 27);
			this.txtBanco.TabIndex = 7;
			this.txtBanco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// btnSetBanco
			// 
			this.btnSetBanco.AllowAnimations = true;
			this.btnSetBanco.BackColor = System.Drawing.Color.Transparent;
			this.btnSetBanco.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetBanco.Location = new System.Drawing.Point(457, 161);
			this.btnSetBanco.Name = "btnSetBanco";
			this.btnSetBanco.RoundedCornersMask = ((byte)(15));
			this.btnSetBanco.RoundedCornersRadius = 0;
			this.btnSetBanco.Size = new System.Drawing.Size(34, 27);
			this.btnSetBanco.TabIndex = 8;
			this.btnSetBanco.TabStop = false;
			this.btnSetBanco.Text = "...";
			this.btnSetBanco.UseCompatibleTextRendering = true;
			this.btnSetBanco.UseVisualStyleBackColor = false;
			this.btnSetBanco.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetBanco.Click += new System.EventHandler(this.btnSetBanco_Click);
			// 
			// lblVencimento
			// 
			this.lblVencimento.AutoSize = true;
			this.lblVencimento.BackColor = System.Drawing.Color.Transparent;
			this.lblVencimento.ForeColor = System.Drawing.Color.Black;
			this.lblVencimento.Location = new System.Drawing.Point(36, 206);
			this.lblVencimento.Name = "lblVencimento";
			this.lblVencimento.Size = new System.Drawing.Size(140, 19);
			this.lblVencimento.TabIndex = 9;
			this.lblVencimento.Text = "Data do Vencimento";
			// 
			// btnSetForma
			// 
			this.btnSetForma.AllowAnimations = true;
			this.btnSetForma.BackColor = System.Drawing.Color.Transparent;
			this.btnSetForma.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetForma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetForma.Location = new System.Drawing.Point(457, 122);
			this.btnSetForma.Name = "btnSetForma";
			this.btnSetForma.RoundedCornersMask = ((byte)(15));
			this.btnSetForma.RoundedCornersRadius = 0;
			this.btnSetForma.Size = new System.Drawing.Size(34, 27);
			this.btnSetForma.TabIndex = 5;
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
			this.label3.Location = new System.Drawing.Point(30, 125);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(146, 19);
			this.label3.TabIndex = 3;
			this.label3.Text = "Forma de Pagamento";
			// 
			// txtAPagarForma
			// 
			this.txtAPagarForma.Location = new System.Drawing.Point(184, 122);
			this.txtAPagarForma.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtAPagarForma.MaxLength = 30;
			this.txtAPagarForma.Name = "txtAPagarForma";
			this.txtAPagarForma.Size = new System.Drawing.Size(267, 27);
			this.txtAPagarForma.TabIndex = 4;
			this.txtAPagarForma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// dtpVencimento
			// 
			this.dtpVencimento.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpVencimento.Location = new System.Drawing.Point(184, 201);
			this.dtpVencimento.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.dtpVencimento.Name = "dtpVencimento";
			this.dtpVencimento.Size = new System.Drawing.Size(145, 31);
			this.dtpVencimento.TabIndex = 10;
			// 
			// txtAPagarValor
			// 
			this.txtAPagarValor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtAPagarValor.Inteiro = false;
			this.txtAPagarValor.Location = new System.Drawing.Point(184, 244);
			this.txtAPagarValor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtAPagarValor.Moeda = false;
			this.txtAPagarValor.Name = "txtAPagarValor";
			this.txtAPagarValor.Positivo = true;
			this.txtAPagarValor.Size = new System.Drawing.Size(145, 31);
			this.txtAPagarValor.TabIndex = 12;
			this.txtAPagarValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.ForeColor = System.Drawing.Color.Black;
			this.label8.Location = new System.Drawing.Point(62, 250);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(114, 19);
			this.label8.TabIndex = 11;
			this.label8.Text = "Valor da Parcela";
			// 
			// txtIdentificador
			// 
			this.txtIdentificador.BackColor = System.Drawing.Color.White;
			this.txtIdentificador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtIdentificador.Location = new System.Drawing.Point(184, 83);
			this.txtIdentificador.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtIdentificador.MaxLength = 100;
			this.txtIdentificador.Name = "txtIdentificador";
			this.txtIdentificador.Size = new System.Drawing.Size(157, 27);
			this.txtIdentificador.TabIndex = 2;
			this.txtIdentificador.Tag = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(114, 86);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "No. Reg.";
			// 
			// frmDespesaAPagarItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(535, 356);
			this.Controls.Add(this.txtIdentificador);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtAPagarValor);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.dtpVencimento);
			this.Controls.Add(this.btnSetForma);
			this.Controls.Add(this.btnSetBanco);
			this.Controls.Add(this.txtAPagarForma);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtBanco);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblVencimento);
			this.Controls.Add(this.tspMenu);
			this.KeyPreview = true;
			this.Name = "frmDespesaAPagarItem";
			this.Activated += new System.EventHandler(this.form_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_FormClosed);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.lblVencimento, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.txtBanco, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.txtAPagarForma, 0);
			this.Controls.SetChildIndex(this.btnSetBanco, 0);
			this.Controls.SetChildIndex(this.btnSetForma, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.dtpVencimento, 0);
			this.Controls.SetChildIndex(this.label8, 0);
			this.Controls.SetChildIndex(this.txtAPagarValor, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.txtIdentificador, 0);
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
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox txtBanco;
		internal VIBlend.WinForms.Controls.vButton btnSetBanco;
		internal System.Windows.Forms.Label lblVencimento;
		internal VIBlend.WinForms.Controls.vButton btnSetForma;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.TextBox txtAPagarForma;
		private System.Windows.Forms.DateTimePicker dtpVencimento;
		private CamadaUC.ucOnlyNumbers txtAPagarValor;
		internal System.Windows.Forms.Label label8;
		internal System.Windows.Forms.TextBox txtIdentificador;
		internal System.Windows.Forms.Label label1;
	}
}
