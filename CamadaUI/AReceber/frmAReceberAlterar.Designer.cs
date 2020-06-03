namespace CamadaUI.AReceber
{
	partial class frmAReceberAlterar
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
			this.lblEntradaForma = new System.Windows.Forms.Label();
			this.txtValorLiquido = new CamadaUC.ucOnlyNumbers();
			this.label8 = new System.Windows.Forms.Label();
			this.dtpCompensacaoData = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label11 = new System.Windows.Forms.Label();
			this.lblContaProvisoria = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.pnlEditar = new System.Windows.Forms.Panel();
			this.txtValorBruto = new CamadaUC.ucTextBoxUnclicked();
			this.txtValorRecebido = new CamadaUC.ucTextBoxUnclicked();
			this.label1 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnAlterar = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pnlEditar.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(260, 0);
			this.lblTitulo.Size = new System.Drawing.Size(230, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "A Receber - Alterar";
			// 
			// btnClose
			// 
			this.btnClose.CausesValidation = false;
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
			// lblEntradaForma
			// 
			this.lblEntradaForma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEntradaForma.BackColor = System.Drawing.Color.Transparent;
			this.lblEntradaForma.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEntradaForma.Location = new System.Drawing.Point(143, 4);
			this.lblEntradaForma.Name = "lblEntradaForma";
			this.lblEntradaForma.Size = new System.Drawing.Size(350, 27);
			this.lblEntradaForma.TabIndex = 1;
			this.lblEntradaForma.Text = "Descrição da Despesa";
			this.lblEntradaForma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtValorLiquido
			// 
			this.txtValorLiquido.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtValorLiquido.Inteiro = false;
			this.txtValorLiquido.Location = new System.Drawing.Point(181, 106);
			this.txtValorLiquido.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtValorLiquido.Name = "txtValorLiquido";
			this.txtValorLiquido.Positivo = true;
			this.txtValorLiquido.Size = new System.Drawing.Size(145, 31);
			this.txtValorLiquido.TabIndex = 5;
			this.txtValorLiquido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtValorLiquido.Validating += new System.ComponentModel.CancelEventHandler(this.txtValorLiquido_Validating);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.ForeColor = System.Drawing.Color.Black;
			this.label8.Location = new System.Drawing.Point(82, 112);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(93, 19);
			this.label8.TabIndex = 4;
			this.label8.Text = "Valor Líquido";
			// 
			// dtpCompensacaoData
			// 
			this.dtpCompensacaoData.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpCompensacaoData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpCompensacaoData.Location = new System.Drawing.Point(181, 149);
			this.dtpCompensacaoData.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.dtpCompensacaoData.Name = "dtpCompensacaoData";
			this.dtpCompensacaoData.Size = new System.Drawing.Size(145, 31);
			this.dtpCompensacaoData.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(20, 156);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(155, 19);
			this.label5.TabIndex = 6;
			this.label5.Text = "Data de Compensação";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
			this.panel2.Controls.Add(this.label11);
			this.panel2.Controls.Add(this.lblContaProvisoria);
			this.panel2.Controls.Add(this.label10);
			this.panel2.Controls.Add(this.lblEntradaForma);
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
			this.label11.Location = new System.Drawing.Point(10, 7);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(127, 19);
			this.label11.TabIndex = 0;
			this.label11.Text = "Forma de Entrada:";
			// 
			// lblContaProvisoria
			// 
			this.lblContaProvisoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblContaProvisoria.BackColor = System.Drawing.Color.Transparent;
			this.lblContaProvisoria.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblContaProvisoria.Location = new System.Drawing.Point(143, 33);
			this.lblContaProvisoria.Name = "lblContaProvisoria";
			this.lblContaProvisoria.Size = new System.Drawing.Size(350, 27);
			this.lblContaProvisoria.TabIndex = 3;
			this.lblContaProvisoria.Text = "Credor";
			this.lblContaProvisoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.ForeColor = System.Drawing.Color.DarkGray;
			this.label10.Location = new System.Drawing.Point(18, 36);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(119, 19);
			this.label10.TabIndex = 2;
			this.label10.Text = "Conta Provisória:";
			// 
			// pnlEditar
			// 
			this.pnlEditar.BackColor = System.Drawing.Color.Transparent;
			this.pnlEditar.Controls.Add(this.txtValorBruto);
			this.pnlEditar.Controls.Add(this.txtValorRecebido);
			this.pnlEditar.Controls.Add(this.txtValorLiquido);
			this.pnlEditar.Controls.Add(this.label8);
			this.pnlEditar.Controls.Add(this.label1);
			this.pnlEditar.Controls.Add(this.dtpCompensacaoData);
			this.pnlEditar.Controls.Add(this.label18);
			this.pnlEditar.Controls.Add(this.label5);
			this.pnlEditar.Location = new System.Drawing.Point(89, 137);
			this.pnlEditar.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
			this.pnlEditar.Name = "pnlEditar";
			this.pnlEditar.Size = new System.Drawing.Size(347, 212);
			this.pnlEditar.TabIndex = 2;
			// 
			// txtValorBruto
			// 
			this.txtValorBruto.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtValorBruto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtValorBruto.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtValorBruto.Location = new System.Drawing.Point(181, 20);
			this.txtValorBruto.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtValorBruto.Name = "txtValorBruto";
			this.txtValorBruto.ReadOnly = true;
			this.txtValorBruto.SelectionHighlightEnabled = false;
			this.txtValorBruto.Size = new System.Drawing.Size(145, 31);
			this.txtValorBruto.TabIndex = 1;
			this.txtValorBruto.TabStop = false;
			this.txtValorBruto.Text = "R$ 0,00";
			this.txtValorBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtValorRecebido
			// 
			this.txtValorRecebido.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtValorRecebido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtValorRecebido.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtValorRecebido.Location = new System.Drawing.Point(181, 63);
			this.txtValorRecebido.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtValorRecebido.Name = "txtValorRecebido";
			this.txtValorRecebido.ReadOnly = true;
			this.txtValorRecebido.SelectionHighlightEnabled = false;
			this.txtValorRecebido.Size = new System.Drawing.Size(145, 31);
			this.txtValorRecebido.TabIndex = 3;
			this.txtValorRecebido.TabStop = false;
			this.txtValorRecebido.Text = "R$ 0,00";
			this.txtValorRecebido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(94, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Valor Bruto";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.BackColor = System.Drawing.Color.Transparent;
			this.label18.ForeColor = System.Drawing.Color.Black;
			this.label18.Location = new System.Drawing.Point(69, 69);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(106, 19);
			this.label18.TabIndex = 2;
			this.label18.Text = "Valor Recebido";
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
			this.tspMenu.Location = new System.Drawing.Point(4, 369);
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
			// frmAReceberAlterar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(530, 416);
			this.Controls.Add(this.tspMenu);
			this.Controls.Add(this.pnlEditar);
			this.Controls.Add(this.panel2);
			this.Name = "frmAReceberAlterar";
			this.Activated += new System.EventHandler(this.form_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_FormClosed);
			this.Controls.SetChildIndex(this.panel2, 0);
			this.Controls.SetChildIndex(this.pnlEditar, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
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
		private System.Windows.Forms.Label lblEntradaForma;
		private CamadaUC.ucOnlyNumbers txtValorLiquido;
		internal System.Windows.Forms.Label label8;
		private System.Windows.Forms.DateTimePicker dtpCompensacaoData;
		internal System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblContaProvisoria;
		internal System.Windows.Forms.Label label11;
		internal System.Windows.Forms.Label label10;
		private System.Windows.Forms.Panel pnlEditar;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnAlterar;
		private System.Windows.Forms.ToolStripButton btnFechar;
		internal System.Windows.Forms.Label label18;
		private CamadaUC.ucTextBoxUnclicked txtValorRecebido;
		private CamadaUC.ucTextBoxUnclicked txtValorBruto;
		internal System.Windows.Forms.Label label1;
	}
}
