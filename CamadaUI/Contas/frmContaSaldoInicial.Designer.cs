namespace CamadaUI.Contas
{
	partial class frmContaSaldoInicial
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
			this.lblConta = new System.Windows.Forms.Label();
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnSalvar = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.line1 = new AwesomeShapeControl.Line();
			this.lblCongregacao = new System.Windows.Forms.Label();
			this.txtSaldoInicial = new CamadaUC.ucOnlyNumbers();
			this.lblSaldoInicialLabel = new System.Windows.Forms.Label();
			this.dtpDataInicial = new System.Windows.Forms.DateTimePicker();
			this.lblDataInicialLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(186, 0);
			this.lblTitulo.Size = new System.Drawing.Size(334, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "Conta Saldo Inicial e Data Inicial";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(520, 0);
			this.btnClose.TabIndex = 3;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblID);
			this.panel1.Controls.Add(this.lbl_IdTexto);
			this.panel1.Size = new System.Drawing.Size(560, 50);
			this.panel1.Controls.SetChildIndex(this.btnClose, 0);
			this.panel1.Controls.SetChildIndex(this.lblTitulo, 0);
			this.panel1.Controls.SetChildIndex(this.lbl_IdTexto, 0);
			this.panel1.Controls.SetChildIndex(this.lblID, 0);
			// 
			// lblConta
			// 
			this.lblConta.BackColor = System.Drawing.Color.Transparent;
			this.lblConta.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblConta.ForeColor = System.Drawing.Color.Black;
			this.lblConta.Location = new System.Drawing.Point(133, 85);
			this.lblConta.Name = "lblConta";
			this.lblConta.Size = new System.Drawing.Size(355, 28);
			this.lblConta.TabIndex = 1;
			this.lblConta.Text = "Descrição da Conta";
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
            this.btnSalvar,
            this.btnFechar});
			this.tspMenu.Location = new System.Drawing.Point(2, 274);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(555, 44);
			this.tspMenu.TabIndex = 17;
			this.tspMenu.TabStop = true;
			this.tspMenu.Text = "toolStrip1";
			// 
			// btnSalvar
			// 
			this.btnSalvar.Image = global::CamadaUI.Properties.Resources.salvar_30;
			this.btnSalvar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSalvar.Name = "btnSalvar";
			this.btnSalvar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnSalvar.Size = new System.Drawing.Size(92, 41);
			this.btnSalvar.Text = "&Salvar";
			this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
			// 
			// btnFechar
			// 
			this.btnFechar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.delete_24;
			this.btnFechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnFechar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnFechar.Size = new System.Drawing.Size(104, 41);
			this.btnFechar.Text = "&Cancelar";
			this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// line1
			// 
			this.line1.EndPoint = new System.Drawing.Point(495, 5);
			this.line1.LineColor = System.Drawing.Color.SlateGray;
			this.line1.LineWidth = 3F;
			this.line1.Location = new System.Drawing.Point(27, 170);
			this.line1.Name = "line1";
			this.line1.Size = new System.Drawing.Size(500, 10);
			this.line1.StartPoint = new System.Drawing.Point(5, 5);
			this.line1.TabIndex = 8;
			this.line1.TabStop = false;
			// 
			// lblCongregacao
			// 
			this.lblCongregacao.BackColor = System.Drawing.Color.Transparent;
			this.lblCongregacao.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCongregacao.ForeColor = System.Drawing.Color.Black;
			this.lblCongregacao.Location = new System.Drawing.Point(133, 133);
			this.lblCongregacao.Name = "lblCongregacao";
			this.lblCongregacao.Size = new System.Drawing.Size(355, 28);
			this.lblCongregacao.TabIndex = 3;
			this.lblCongregacao.Text = "Congregação";
			// 
			// txtSaldoInicial
			// 
			this.txtSaldoInicial.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSaldoInicial.Inteiro = false;
			this.txtSaldoInicial.Location = new System.Drawing.Point(133, 200);
			this.txtSaldoInicial.Moeda = true;
			this.txtSaldoInicial.Name = "txtSaldoInicial";
			this.txtSaldoInicial.Positivo = true;
			this.txtSaldoInicial.Size = new System.Drawing.Size(126, 31);
			this.txtSaldoInicial.TabIndex = 10;
			this.txtSaldoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblSaldoInicialLabel
			// 
			this.lblSaldoInicialLabel.AutoSize = true;
			this.lblSaldoInicialLabel.BackColor = System.Drawing.Color.Transparent;
			this.lblSaldoInicialLabel.ForeColor = System.Drawing.Color.Black;
			this.lblSaldoInicialLabel.Location = new System.Drawing.Point(30, 206);
			this.lblSaldoInicialLabel.Name = "lblSaldoInicialLabel";
			this.lblSaldoInicialLabel.Size = new System.Drawing.Size(91, 19);
			this.lblSaldoInicialLabel.TabIndex = 9;
			this.lblSaldoInicialLabel.Text = "Saldo Inicial:";
			// 
			// dtpDataInicial
			// 
			this.dtpDataInicial.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDataInicial.Location = new System.Drawing.Point(374, 200);
			this.dtpDataInicial.Name = "dtpDataInicial";
			this.dtpDataInicial.Size = new System.Drawing.Size(131, 31);
			this.dtpDataInicial.TabIndex = 12;
			// 
			// lblDataInicialLabel
			// 
			this.lblDataInicialLabel.AutoSize = true;
			this.lblDataInicialLabel.BackColor = System.Drawing.Color.Transparent;
			this.lblDataInicialLabel.ForeColor = System.Drawing.Color.Black;
			this.lblDataInicialLabel.Location = new System.Drawing.Point(282, 206);
			this.lblDataInicialLabel.Name = "lblDataInicialLabel";
			this.lblDataInicialLabel.Size = new System.Drawing.Size(87, 19);
			this.lblDataInicialLabel.TabIndex = 11;
			this.lblDataInicialLabel.Text = "Data Inicial:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(70, 89);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 19);
			this.label1.TabIndex = 9;
			this.label1.Text = "Conta:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(23, 136);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 19);
			this.label2.TabIndex = 9;
			this.label2.Text = "Congregação:";
			// 
			// frmContaSaldoInicial
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(560, 320);
			this.Controls.Add(this.dtpDataInicial);
			this.Controls.Add(this.txtSaldoInicial);
			this.Controls.Add(this.lblDataInicialLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblSaldoInicialLabel);
			this.Controls.Add(this.lblCongregacao);
			this.Controls.Add(this.line1);
			this.Controls.Add(this.tspMenu);
			this.Controls.Add(this.lblConta);
			this.KeyPreview = true;
			this.Name = "frmContaSaldoInicial";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmContaSaldoInicial_KeyDown);
			this.Controls.SetChildIndex(this.lblConta, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.line1, 0);
			this.Controls.SetChildIndex(this.lblCongregacao, 0);
			this.Controls.SetChildIndex(this.lblSaldoInicialLabel, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.lblDataInicialLabel, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.txtSaldoInicial, 0);
			this.Controls.SetChildIndex(this.dtpDataInicial, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal System.Windows.Forms.Label lblConta;
		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label lbl_IdTexto;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnSalvar;
		private System.Windows.Forms.ToolStripButton btnFechar;
		private AwesomeShapeControl.Line line1;
		internal System.Windows.Forms.Label lblCongregacao;
		private CamadaUC.ucOnlyNumbers txtSaldoInicial;
		internal System.Windows.Forms.Label lblSaldoInicialLabel;
		private System.Windows.Forms.DateTimePicker dtpDataInicial;
		internal System.Windows.Forms.Label lblDataInicialLabel;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Label label2;
	}
}
