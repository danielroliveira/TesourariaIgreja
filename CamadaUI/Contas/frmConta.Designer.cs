namespace CamadaUI.Contas
{
	partial class frmConta
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConta));
			this.lblCongregacao = new System.Windows.Forms.Label();
			this.txtConta = new System.Windows.Forms.TextBox();
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnNovo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalvar = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnAtivo = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.line1 = new AwesomeShapeControl.Line();
			this.pnlChk1 = new System.Windows.Forms.Panel();
			this.chkBancaria = new System.Windows.Forms.CheckBox();
			this.btnCongEscolher = new VIBlend.WinForms.Controls.vButton();
			this.txtCongregacao = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label34 = new System.Windows.Forms.Label();
			this.pnlChk2 = new System.Windows.Forms.Panel();
			this.chkOperadoraCartao = new System.Windows.Forms.CheckBox();
			this.lblContaSaldo = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblBloqueioData = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.pnlChk1.SuspendLayout();
			this.pnlChk2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(251, 0);
			this.lblTitulo.Size = new System.Drawing.Size(269, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "Conta de Movimentação";
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
			// lblCongregacao
			// 
			this.lblCongregacao.AutoSize = true;
			this.lblCongregacao.BackColor = System.Drawing.Color.Transparent;
			this.lblCongregacao.ForeColor = System.Drawing.Color.Black;
			this.lblCongregacao.Location = new System.Drawing.Point(45, 94);
			this.lblCongregacao.Name = "lblCongregacao";
			this.lblCongregacao.Size = new System.Drawing.Size(135, 19);
			this.lblCongregacao.TabIndex = 1;
			this.lblCongregacao.Text = "Descrição da Conta";
			// 
			// txtConta
			// 
			this.txtConta.BackColor = System.Drawing.Color.White;
			this.txtConta.Location = new System.Drawing.Point(186, 91);
			this.txtConta.Name = "txtConta";
			this.txtConta.Size = new System.Drawing.Size(319, 27);
			this.txtConta.TabIndex = 2;
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
            this.btnNovo,
            this.toolStripSeparator1,
            this.btnSalvar,
            this.btnCancelar,
            this.toolStripSeparator2,
            this.btnAtivo,
            this.btnFechar});
			this.tspMenu.Location = new System.Drawing.Point(2, 337);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(555, 44);
			this.tspMenu.TabIndex = 13;
			this.tspMenu.TabStop = true;
			this.tspMenu.Text = "toolStrip1";
			// 
			// btnNovo
			// 
			this.btnNovo.Image = global::CamadaUI.Properties.Resources.adicionar_30;
			this.btnNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNovo.Name = "btnNovo";
			this.btnNovo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnNovo.Size = new System.Drawing.Size(86, 41);
			this.btnNovo.Text = "&Nova";
			this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 44);
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
			// btnCancelar
			// 
			this.btnCancelar.Image = global::CamadaUI.Properties.Resources.delete_page_30;
			this.btnCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnCancelar.Size = new System.Drawing.Size(110, 41);
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 44);
			// 
			// btnAtivo
			// 
			this.btnAtivo.Image = ((System.Drawing.Image)(resources.GetObject("btnAtivo.Image")));
			this.btnAtivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnAtivo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAtivo.Name = "btnAtivo";
			this.btnAtivo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnAtivo.Size = new System.Drawing.Size(96, 41);
			this.btnAtivo.Text = "&Ativa";
			this.btnAtivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAtivo.Click += new System.EventHandler(this.btnAtivo_Click);
			// 
			// btnFechar
			// 
			this.btnFechar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.fechar_30;
			this.btnFechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnFechar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnFechar.Size = new System.Drawing.Size(96, 41);
			this.btnFechar.Text = "&Fechar";
			this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// line1
			// 
			this.line1.EndPoint = new System.Drawing.Point(495, 5);
			this.line1.LineColor = System.Drawing.Color.SlateGray;
			this.line1.LineWidth = 3F;
			this.line1.Location = new System.Drawing.Point(27, 256);
			this.line1.Name = "line1";
			this.line1.Size = new System.Drawing.Size(500, 10);
			this.line1.StartPoint = new System.Drawing.Point(5, 5);
			this.line1.TabIndex = 8;
			this.line1.TabStop = false;
			// 
			// pnlChk1
			// 
			this.pnlChk1.BackColor = System.Drawing.Color.Transparent;
			this.pnlChk1.CausesValidation = false;
			this.pnlChk1.Controls.Add(this.chkBancaria);
			this.pnlChk1.Location = new System.Drawing.Point(76, 181);
			this.pnlChk1.Name = "pnlChk1";
			this.pnlChk1.Size = new System.Drawing.Size(161, 32);
			this.pnlChk1.TabIndex = 6;
			this.pnlChk1.TabStop = true;
			// 
			// chkBancaria
			// 
			this.chkBancaria.AutoSize = true;
			this.chkBancaria.Location = new System.Drawing.Point(13, 5);
			this.chkBancaria.Name = "chkBancaria";
			this.chkBancaria.Size = new System.Drawing.Size(134, 23);
			this.chkBancaria.TabIndex = 0;
			this.chkBancaria.Text = "Conta Bancária?";
			this.chkBancaria.UseVisualStyleBackColor = true;
			// 
			// btnCongEscolher
			// 
			this.btnCongEscolher.AllowAnimations = true;
			this.btnCongEscolher.BackColor = System.Drawing.Color.Transparent;
			this.btnCongEscolher.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnCongEscolher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCongEscolher.Location = new System.Drawing.Point(420, 133);
			this.btnCongEscolher.Name = "btnCongEscolher";
			this.btnCongEscolher.RoundedCornersMask = ((byte)(15));
			this.btnCongEscolher.RoundedCornersRadius = 0;
			this.btnCongEscolher.Size = new System.Drawing.Size(34, 27);
			this.btnCongEscolher.TabIndex = 5;
			this.btnCongEscolher.TabStop = false;
			this.btnCongEscolher.Text = "...";
			this.btnCongEscolher.UseCompatibleTextRendering = true;
			this.btnCongEscolher.UseVisualStyleBackColor = false;
			this.btnCongEscolher.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnCongEscolher.Click += new System.EventHandler(this.btnCongregacaoEscolher_Click);
			// 
			// txtCongregacao
			// 
			this.txtCongregacao.Location = new System.Drawing.Point(186, 133);
			this.txtCongregacao.MaxLength = 30;
			this.txtCongregacao.Name = "txtCongregacao";
			this.txtCongregacao.Size = new System.Drawing.Size(228, 27);
			this.txtCongregacao.TabIndex = 4;
			this.txtCongregacao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.BackColor = System.Drawing.Color.Transparent;
			this.Label6.ForeColor = System.Drawing.Color.Black;
			this.Label6.Location = new System.Drawing.Point(85, 136);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(94, 19);
			this.Label6.TabIndex = 3;
			this.Label6.Text = "Congregação";
			// 
			// Label34
			// 
			this.Label34.AutoSize = true;
			this.Label34.BackColor = System.Drawing.Color.Transparent;
			this.Label34.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label34.Location = new System.Drawing.Point(266, 282);
			this.Label34.Name = "Label34";
			this.Label34.Size = new System.Drawing.Size(125, 19);
			this.Label34.TabIndex = 11;
			this.Label34.Text = "Data do Bloqueio:";
			this.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pnlChk2
			// 
			this.pnlChk2.BackColor = System.Drawing.Color.Transparent;
			this.pnlChk2.CausesValidation = false;
			this.pnlChk2.Controls.Add(this.chkOperadoraCartao);
			this.pnlChk2.Location = new System.Drawing.Point(256, 181);
			this.pnlChk2.Name = "pnlChk2";
			this.pnlChk2.Size = new System.Drawing.Size(197, 32);
			this.pnlChk2.TabIndex = 7;
			this.pnlChk2.TabStop = true;
			// 
			// chkOperadoraCartao
			// 
			this.chkOperadoraCartao.AutoSize = true;
			this.chkOperadoraCartao.Location = new System.Drawing.Point(13, 5);
			this.chkOperadoraCartao.Name = "chkOperadoraCartao";
			this.chkOperadoraCartao.Size = new System.Drawing.Size(171, 23);
			this.chkOperadoraCartao.TabIndex = 0;
			this.chkOperadoraCartao.Text = "Operadora de Cartão?";
			this.chkOperadoraCartao.UseVisualStyleBackColor = true;
			// 
			// lblContaSaldo
			// 
			this.lblContaSaldo.AutoSize = true;
			this.lblContaSaldo.BackColor = System.Drawing.Color.Transparent;
			this.lblContaSaldo.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblContaSaldo.Location = new System.Drawing.Point(144, 277);
			this.lblContaSaldo.Name = "lblContaSaldo";
			this.lblContaSaldo.Size = new System.Drawing.Size(85, 29);
			this.lblContaSaldo.TabIndex = 10;
			this.lblContaSaldo.Text = "R$ 0,00";
			this.lblContaSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(28, 282);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 19);
			this.label1.TabIndex = 9;
			this.label1.Text = "Saldo da Conta:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblBloqueioData
			// 
			this.lblBloqueioData.AutoSize = true;
			this.lblBloqueioData.BackColor = System.Drawing.Color.Transparent;
			this.lblBloqueioData.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBloqueioData.Location = new System.Drawing.Point(397, 277);
			this.lblBloqueioData.Name = "lblBloqueioData";
			this.lblBloqueioData.Size = new System.Drawing.Size(127, 29);
			this.lblBloqueioData.TabIndex = 12;
			this.lblBloqueioData.Text = "00/00/0000";
			this.lblBloqueioData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmConta
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(560, 383);
			this.Controls.Add(this.lblBloqueioData);
			this.Controls.Add(this.lblContaSaldo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Label34);
			this.Controls.Add(this.btnCongEscolher);
			this.Controls.Add(this.txtCongregacao);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.pnlChk2);
			this.Controls.Add(this.pnlChk1);
			this.Controls.Add(this.line1);
			this.Controls.Add(this.tspMenu);
			this.Controls.Add(this.txtConta);
			this.Controls.Add(this.lblCongregacao);
			this.KeyPreview = true;
			this.Name = "frmConta";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConta_KeyDown);
			this.Controls.SetChildIndex(this.lblCongregacao, 0);
			this.Controls.SetChildIndex(this.txtConta, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.line1, 0);
			this.Controls.SetChildIndex(this.pnlChk1, 0);
			this.Controls.SetChildIndex(this.pnlChk2, 0);
			this.Controls.SetChildIndex(this.Label6, 0);
			this.Controls.SetChildIndex(this.txtCongregacao, 0);
			this.Controls.SetChildIndex(this.btnCongEscolher, 0);
			this.Controls.SetChildIndex(this.Label34, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.lblContaSaldo, 0);
			this.Controls.SetChildIndex(this.lblBloqueioData, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			this.pnlChk1.ResumeLayout(false);
			this.pnlChk1.PerformLayout();
			this.pnlChk2.ResumeLayout(false);
			this.pnlChk2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal System.Windows.Forms.Label lblCongregacao;
		internal System.Windows.Forms.TextBox txtConta;
		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label lbl_IdTexto;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnNovo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnSalvar;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnAtivo;
		private System.Windows.Forms.ToolStripButton btnFechar;
		private AwesomeShapeControl.Line line1;
		internal System.Windows.Forms.Panel pnlChk1;
		internal System.Windows.Forms.CheckBox chkBancaria;
		internal VIBlend.WinForms.Controls.vButton btnCongEscolher;
		internal System.Windows.Forms.TextBox txtCongregacao;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label Label34;
		internal System.Windows.Forms.Panel pnlChk2;
		internal System.Windows.Forms.CheckBox chkOperadoraCartao;
		internal System.Windows.Forms.Label lblContaSaldo;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Label lblBloqueioData;
	}
}
