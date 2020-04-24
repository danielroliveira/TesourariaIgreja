namespace CamadaUI.Registres
{
	partial class frmContribuinte
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContribuinte));
			this.txtCongregacao = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label15 = new System.Windows.Forms.Label();
			this.Label10 = new System.Windows.Forms.Label();
			this.txtTelefoneCelular = new CamadaUC.ucTelefone();
			this.lblCongregacao = new System.Windows.Forms.Label();
			this.txtContribuinte = new System.Windows.Forms.TextBox();
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtIDMembro = new System.Windows.Forms.TextBox();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnNovo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalvar = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnAtivo = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.btnCongEscolher = new VIBlend.WinForms.Controls.vButton();
			this.line1 = new AwesomeShapeControl.Line();
			this.txtNascimentoData = new CamadaUC.ucData();
			this.txtCNP = new System.Windows.Forms.MaskedTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbDizimista = new CamadaUC.ucComboLimitedValues();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(221, 0);
			this.lblTitulo.Size = new System.Drawing.Size(299, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "Cadastro de Contribuintes";
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
			// txtCongregacao
			// 
			this.txtCongregacao.Location = new System.Drawing.Point(134, 224);
			this.txtCongregacao.MaxLength = 30;
			this.txtCongregacao.Name = "txtCongregacao";
			this.txtCongregacao.Size = new System.Drawing.Size(228, 27);
			this.txtCongregacao.TabIndex = 15;
			this.txtCongregacao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.BackColor = System.Drawing.Color.Transparent;
			this.Label6.ForeColor = System.Drawing.Color.Black;
			this.Label6.Location = new System.Drawing.Point(33, 227);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(94, 19);
			this.Label6.TabIndex = 14;
			this.Label6.Text = "Congregação";
			// 
			// Label15
			// 
			this.Label15.AutoSize = true;
			this.Label15.BackColor = System.Drawing.Color.Transparent;
			this.Label15.ForeColor = System.Drawing.Color.Black;
			this.Label15.Location = new System.Drawing.Point(292, 161);
			this.Label15.Name = "Label15";
			this.Label15.Size = new System.Drawing.Size(105, 19);
			this.Label15.TabIndex = 10;
			this.Label15.Text = "Dt Nascimento";
			// 
			// Label10
			// 
			this.Label10.AutoSize = true;
			this.Label10.BackColor = System.Drawing.Color.Transparent;
			this.Label10.ForeColor = System.Drawing.Color.Black;
			this.Label10.Location = new System.Drawing.Point(72, 194);
			this.Label10.Name = "Label10";
			this.Label10.Size = new System.Drawing.Size(55, 19);
			this.Label10.TabIndex = 12;
			this.Label10.Text = "Celular";
			// 
			// txtTelefoneCelular
			// 
			this.txtTelefoneCelular.Location = new System.Drawing.Point(134, 191);
			this.txtTelefoneCelular.Mask = "(99) 99000-0000";
			this.txtTelefoneCelular.Name = "txtTelefoneCelular";
			this.txtTelefoneCelular.Size = new System.Drawing.Size(133, 27);
			this.txtTelefoneCelular.TabIndex = 13;
			// 
			// lblCongregacao
			// 
			this.lblCongregacao.AutoSize = true;
			this.lblCongregacao.BackColor = System.Drawing.Color.Transparent;
			this.lblCongregacao.ForeColor = System.Drawing.Color.Black;
			this.lblCongregacao.Location = new System.Drawing.Point(33, 77);
			this.lblCongregacao.Name = "lblCongregacao";
			this.lblCongregacao.Size = new System.Drawing.Size(89, 19);
			this.lblCongregacao.TabIndex = 1;
			this.lblCongregacao.Text = "Contribuinte";
			// 
			// txtContribuinte
			// 
			this.txtContribuinte.BackColor = System.Drawing.Color.White;
			this.txtContribuinte.Location = new System.Drawing.Point(134, 74);
			this.txtContribuinte.MaxLength = 100;
			this.txtContribuinte.Name = "txtContribuinte";
			this.txtContribuinte.Size = new System.Drawing.Size(371, 27);
			this.txtContribuinte.TabIndex = 2;
			// 
			// lblID
			// 
			this.lblID.BackColor = System.Drawing.Color.Transparent;
			this.lblID.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblID.ForeColor = System.Drawing.Color.AliceBlue;
			this.lblID.Location = new System.Drawing.Point(4, 18);
			this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblID.Name = "lblID";
			this.lblID.Size = new System.Drawing.Size(94, 30);
			this.lblID.TabIndex = 1;
			this.lblID.Text = "0001";
			this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbl_IdTexto
			// 
			this.lbl_IdTexto.AutoSize = true;
			this.lbl_IdTexto.BackColor = System.Drawing.Color.Transparent;
			this.lbl_IdTexto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_IdTexto.ForeColor = System.Drawing.Color.LightGray;
			this.lbl_IdTexto.Location = new System.Drawing.Point(31, 5);
			this.lbl_IdTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbl_IdTexto.Name = "lbl_IdTexto";
			this.lbl_IdTexto.Size = new System.Drawing.Size(35, 13);
			this.lbl_IdTexto.TabIndex = 1;
			this.lbl_IdTexto.Text = "Reg.";
			this.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(26, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 19);
			this.label3.TabIndex = 4;
			this.label3.Text = "Reg. Membro";
			// 
			// txtIDMembro
			// 
			this.txtIDMembro.BackColor = System.Drawing.Color.White;
			this.txtIDMembro.Location = new System.Drawing.Point(134, 125);
			this.txtIDMembro.MaxLength = 50;
			this.txtIDMembro.Name = "txtIDMembro";
			this.txtIDMembro.Size = new System.Drawing.Size(81, 27);
			this.txtIDMembro.TabIndex = 5;
			this.txtIDMembro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDMembro_KeyPress);
			this.txtIDMembro.Validating += new System.ComponentModel.CancelEventHandler(this.txtIDMembro_Validating);
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
			this.tspMenu.Location = new System.Drawing.Point(2, 290);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(555, 44);
			this.tspMenu.TabIndex = 17;
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
			// btnCongEscolher
			// 
			this.btnCongEscolher.AllowAnimations = true;
			this.btnCongEscolher.BackColor = System.Drawing.Color.Transparent;
			this.btnCongEscolher.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnCongEscolher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCongEscolher.Location = new System.Drawing.Point(368, 224);
			this.btnCongEscolher.Name = "btnCongEscolher";
			this.btnCongEscolher.RoundedCornersMask = ((byte)(15));
			this.btnCongEscolher.RoundedCornersRadius = 0;
			this.btnCongEscolher.Size = new System.Drawing.Size(34, 27);
			this.btnCongEscolher.TabIndex = 16;
			this.btnCongEscolher.TabStop = false;
			this.btnCongEscolher.Text = "...";
			this.btnCongEscolher.UseCompatibleTextRendering = true;
			this.btnCongEscolher.UseVisualStyleBackColor = false;
			this.btnCongEscolher.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnCongEscolher.Click += new System.EventHandler(this.btnCongregacaoEscolher_Click);
			// 
			// line1
			// 
			this.line1.EndPoint = new System.Drawing.Point(495, 5);
			this.line1.LineColor = System.Drawing.Color.SlateGray;
			this.line1.LineWidth = 3F;
			this.line1.Location = new System.Drawing.Point(25, 107);
			this.line1.Name = "line1";
			this.line1.Size = new System.Drawing.Size(500, 10);
			this.line1.StartPoint = new System.Drawing.Point(5, 5);
			this.line1.TabIndex = 3;
			this.line1.TabStop = false;
			// 
			// txtNascimentoData
			// 
			this.txtNascimentoData.Location = new System.Drawing.Point(405, 158);
			this.txtNascimentoData.Mask = "00/00/0000";
			this.txtNascimentoData.Name = "txtNascimentoData";
			this.txtNascimentoData.Size = new System.Drawing.Size(100, 27);
			this.txtNascimentoData.TabIndex = 11;
			// 
			// txtCNP
			// 
			this.txtCNP.Location = new System.Drawing.Point(134, 158);
			this.txtCNP.Mask = "000\\.000\\.000-00";
			this.txtCNP.Name = "txtCNP";
			this.txtCNP.Size = new System.Drawing.Size(133, 27);
			this.txtCNP.TabIndex = 9;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(89, 161);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 19);
			this.label1.TabIndex = 8;
			this.label1.Text = "CPF";
			// 
			// cmbDizimista
			// 
			this.cmbDizimista.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbDizimista.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbDizimista.FormattingEnabled = true;
			this.cmbDizimista.Location = new System.Drawing.Point(405, 125);
			this.cmbDizimista.Name = "cmbDizimista";
			this.cmbDizimista.Size = new System.Drawing.Size(75, 27);
			this.cmbDizimista.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(309, 128);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 19);
			this.label2.TabIndex = 6;
			this.label2.Text = "É Dizimista?";
			// 
			// frmContribuinte
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(560, 336);
			this.Controls.Add(this.cmbDizimista);
			this.Controls.Add(this.txtCNP);
			this.Controls.Add(this.txtNascimentoData);
			this.Controls.Add(this.line1);
			this.Controls.Add(this.btnCongEscolher);
			this.Controls.Add(this.tspMenu);
			this.Controls.Add(this.txtTelefoneCelular);
			this.Controls.Add(this.txtContribuinte);
			this.Controls.Add(this.txtIDMembro);
			this.Controls.Add(this.Label10);
			this.Controls.Add(this.txtCongregacao);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Label15);
			this.Controls.Add(this.lblCongregacao);
			this.Controls.Add(this.label3);
			this.KeyPreview = true;
			this.Name = "frmContribuinte";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmContribuinte_KeyPress);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.lblCongregacao, 0);
			this.Controls.SetChildIndex(this.Label15, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.Label6, 0);
			this.Controls.SetChildIndex(this.txtCongregacao, 0);
			this.Controls.SetChildIndex(this.Label10, 0);
			this.Controls.SetChildIndex(this.txtIDMembro, 0);
			this.Controls.SetChildIndex(this.txtContribuinte, 0);
			this.Controls.SetChildIndex(this.txtTelefoneCelular, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.btnCongEscolher, 0);
			this.Controls.SetChildIndex(this.line1, 0);
			this.Controls.SetChildIndex(this.txtNascimentoData, 0);
			this.Controls.SetChildIndex(this.txtCNP, 0);
			this.Controls.SetChildIndex(this.cmbDizimista, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal System.Windows.Forms.TextBox txtCongregacao;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label Label15;
		internal System.Windows.Forms.Label Label10;
		private CamadaUC.ucTelefone txtTelefoneCelular;
		internal System.Windows.Forms.Label lblCongregacao;
		internal System.Windows.Forms.TextBox txtContribuinte;
		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label lbl_IdTexto;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.TextBox txtIDMembro;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnNovo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnSalvar;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnAtivo;
		private System.Windows.Forms.ToolStripButton btnFechar;
		internal VIBlend.WinForms.Controls.vButton btnCongEscolher;
		private AwesomeShapeControl.Line line1;
		private CamadaUC.ucData txtNascimentoData;
		private System.Windows.Forms.MaskedTextBox txtCNP;
		internal System.Windows.Forms.Label label1;
		private CamadaUC.ucComboLimitedValues cmbDizimista;
		internal System.Windows.Forms.Label label2;
	}
}
