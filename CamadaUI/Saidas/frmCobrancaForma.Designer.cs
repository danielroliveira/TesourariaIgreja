namespace CamadaUI.Saidas
{
	partial class frmCobrancaForma
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
			this.lblCongregacao = new System.Windows.Forms.Label();
			this.txtAPagarForma = new System.Windows.Forms.TextBox();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnNovo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalvar = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.btnSetBanco = new VIBlend.WinForms.Controls.vButton();
			this.txtBanco = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.lstListagem = new ComponentOwl.BetterListView.BetterListView();
			this.clnID = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
			this.clnCadastro = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
			this.lblID = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbAtivo = new CamadaUC.ucComboLimitedValues();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSetCartao = new VIBlend.WinForms.Controls.vButton();
			this.txtCartaoCredito = new System.Windows.Forms.TextBox();
			this.lblCartao = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPagFormaModo = new System.Windows.Forms.TextBox();
			this.btnSetModo = new VIBlend.WinForms.Controls.vButton();
			this.btnCartoesCredito = new System.Windows.Forms.ToolStripButton();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lstListagem)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(506, 0);
			this.lblTitulo.Size = new System.Drawing.Size(365, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Formas de Pagamento | Cobrança";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(871, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(911, 50);
			// 
			// lblCongregacao
			// 
			this.lblCongregacao.AutoSize = true;
			this.lblCongregacao.BackColor = System.Drawing.Color.Transparent;
			this.lblCongregacao.ForeColor = System.Drawing.Color.Black;
			this.lblCongregacao.Location = new System.Drawing.Point(447, 107);
			this.lblCongregacao.Name = "lblCongregacao";
			this.lblCongregacao.Size = new System.Drawing.Size(73, 19);
			this.lblCongregacao.TabIndex = 3;
			this.lblCongregacao.Text = "Descrição";
			// 
			// txtAPagarForma
			// 
			this.txtAPagarForma.BackColor = System.Drawing.Color.White;
			this.txtAPagarForma.Location = new System.Drawing.Point(526, 104);
			this.txtAPagarForma.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtAPagarForma.Name = "txtAPagarForma";
			this.txtAPagarForma.Size = new System.Drawing.Size(342, 27);
			this.txtAPagarForma.TabIndex = 4;
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
            this.btnFechar,
            this.btnCartoesCredito});
			this.tspMenu.Location = new System.Drawing.Point(2, 403);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(906, 44);
			this.tspMenu.TabIndex = 16;
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
			// btnSetBanco
			// 
			this.btnSetBanco.AllowAnimations = true;
			this.btnSetBanco.BackColor = System.Drawing.Color.Transparent;
			this.btnSetBanco.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetBanco.Location = new System.Drawing.Point(760, 183);
			this.btnSetBanco.Name = "btnSetBanco";
			this.btnSetBanco.RoundedCornersMask = ((byte)(15));
			this.btnSetBanco.RoundedCornersRadius = 0;
			this.btnSetBanco.Size = new System.Drawing.Size(34, 27);
			this.btnSetBanco.TabIndex = 10;
			this.btnSetBanco.TabStop = false;
			this.btnSetBanco.Text = "...";
			this.btnSetBanco.UseCompatibleTextRendering = true;
			this.btnSetBanco.UseVisualStyleBackColor = false;
			this.btnSetBanco.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetBanco.Click += new System.EventHandler(this.btnSetBanco_Click);
			// 
			// txtBanco
			// 
			this.txtBanco.Location = new System.Drawing.Point(526, 183);
			this.txtBanco.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtBanco.MaxLength = 30;
			this.txtBanco.Name = "txtBanco";
			this.txtBanco.Size = new System.Drawing.Size(228, 27);
			this.txtBanco.TabIndex = 9;
			this.txtBanco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.BackColor = System.Drawing.Color.Transparent;
			this.Label6.ForeColor = System.Drawing.Color.Black;
			this.Label6.Location = new System.Drawing.Point(471, 186);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(49, 19);
			this.Label6.TabIndex = 8;
			this.Label6.Text = "Banco";
			// 
			// lstListagem
			// 
			this.lstListagem.Columns.Add(this.clnID);
			this.lstListagem.Columns.Add(this.clnCadastro);
			this.lstListagem.Font = new System.Drawing.Font("Calibri", 12F);
			this.lstListagem.FontColumns = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
			this.lstListagem.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.Disable;
			this.lstListagem.Location = new System.Drawing.Point(12, 63);
			this.lstListagem.Name = "lstListagem";
			this.lstListagem.Size = new System.Drawing.Size(353, 324);
			this.lstListagem.TabIndex = 17;
			this.lstListagem.TabStop = false;
			this.lstListagem.VScrollBarDisplayMode = ComponentOwl.BetterListView.BetterListViewScrollBarDisplayMode.ShowAlways;
			this.lstListagem.DrawColumnHeader += new ComponentOwl.BetterListView.BetterListViewDrawColumnHeaderEventHandler(this.list_DrawColumnHeader);
			this.lstListagem.DrawItem += new ComponentOwl.BetterListView.BetterListViewDrawItemEventHandler(this.list_DrawItem);
			// 
			// clnID
			// 
			this.clnID.Name = "clnID";
			this.clnID.Text = "Reg.:";
			this.clnID.Width = 50;
			// 
			// clnCadastro
			// 
			this.clnCadastro.Name = "clnCadastro";
			this.clnCadastro.Text = "Formas de Cobrança";
			this.clnCadastro.Width = 275;
			// 
			// lblID
			// 
			this.lblID.BackColor = System.Drawing.Color.Transparent;
			this.lblID.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblID.ForeColor = System.Drawing.Color.Black;
			this.lblID.Location = new System.Drawing.Point(522, 63);
			this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblID.Name = "lblID";
			this.lblID.Size = new System.Drawing.Size(94, 30);
			this.lblID.TabIndex = 2;
			this.lblID.Text = "0000";
			this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(483, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "Reg.";
			// 
			// cmbAtivo
			// 
			this.cmbAtivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbAtivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbAtivo.FormattingEnabled = true;
			this.cmbAtivo.Location = new System.Drawing.Point(526, 222);
			this.cmbAtivo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.cmbAtivo.Name = "cmbAtivo";
			this.cmbAtivo.Size = new System.Drawing.Size(103, 27);
			this.cmbAtivo.TabIndex = 12;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(478, 225);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 19);
			this.label3.TabIndex = 11;
			this.label3.Text = "Ativo";
			// 
			// btnSetCartao
			// 
			this.btnSetCartao.AllowAnimations = true;
			this.btnSetCartao.BackColor = System.Drawing.Color.Transparent;
			this.btnSetCartao.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetCartao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetCartao.Location = new System.Drawing.Point(760, 261);
			this.btnSetCartao.Name = "btnSetCartao";
			this.btnSetCartao.RoundedCornersMask = ((byte)(15));
			this.btnSetCartao.RoundedCornersRadius = 0;
			this.btnSetCartao.Size = new System.Drawing.Size(34, 27);
			this.btnSetCartao.TabIndex = 15;
			this.btnSetCartao.TabStop = false;
			this.btnSetCartao.Text = "n";
			this.btnSetCartao.UseCompatibleTextRendering = true;
			this.btnSetCartao.UseVisualStyleBackColor = false;
			this.btnSetCartao.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetCartao.Click += new System.EventHandler(this.btnSetCartao_Click);
			// 
			// txtCartaoCredito
			// 
			this.txtCartaoCredito.Location = new System.Drawing.Point(526, 261);
			this.txtCartaoCredito.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCartaoCredito.MaxLength = 30;
			this.txtCartaoCredito.Name = "txtCartaoCredito";
			this.txtCartaoCredito.Size = new System.Drawing.Size(228, 27);
			this.txtCartaoCredito.TabIndex = 14;
			this.txtCartaoCredito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			this.txtCartaoCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
			// 
			// lblCartao
			// 
			this.lblCartao.AutoSize = true;
			this.lblCartao.BackColor = System.Drawing.Color.Transparent;
			this.lblCartao.ForeColor = System.Drawing.Color.Black;
			this.lblCartao.Location = new System.Drawing.Point(397, 264);
			this.lblCartao.Name = "lblCartao";
			this.lblCartao.Size = new System.Drawing.Size(123, 19);
			this.lblCartao.TabIndex = 13;
			this.lblCartao.Text = "Cartão de Crédito";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(471, 146);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 19);
			this.label1.TabIndex = 5;
			this.label1.Text = "Modo";
			// 
			// txtPagFormaModo
			// 
			this.txtPagFormaModo.Location = new System.Drawing.Point(526, 143);
			this.txtPagFormaModo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtPagFormaModo.MaxLength = 30;
			this.txtPagFormaModo.Name = "txtPagFormaModo";
			this.txtPagFormaModo.Size = new System.Drawing.Size(228, 27);
			this.txtPagFormaModo.TabIndex = 6;
			this.txtPagFormaModo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			this.txtPagFormaModo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
			// 
			// btnSetModo
			// 
			this.btnSetModo.AllowAnimations = true;
			this.btnSetModo.BackColor = System.Drawing.Color.Transparent;
			this.btnSetModo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetModo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetModo.Location = new System.Drawing.Point(760, 143);
			this.btnSetModo.Name = "btnSetModo";
			this.btnSetModo.RoundedCornersMask = ((byte)(15));
			this.btnSetModo.RoundedCornersRadius = 0;
			this.btnSetModo.Size = new System.Drawing.Size(34, 27);
			this.btnSetModo.TabIndex = 7;
			this.btnSetModo.TabStop = false;
			this.btnSetModo.Text = "n";
			this.btnSetModo.UseCompatibleTextRendering = true;
			this.btnSetModo.UseVisualStyleBackColor = false;
			this.btnSetModo.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetModo.Click += new System.EventHandler(this.btnSetModo_Click);
			// 
			// btnCartoesCredito
			// 
			this.btnCartoesCredito.Image = global::CamadaUI.Properties.Resources.credit_card_32;
			this.btnCartoesCredito.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnCartoesCredito.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCartoesCredito.Name = "btnCartoesCredito";
			this.btnCartoesCredito.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnCartoesCredito.Size = new System.Drawing.Size(180, 41);
			this.btnCartoesCredito.Text = " Car&tões de Crédito";
			this.btnCartoesCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmCobrancaForma
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(911, 449);
			this.Controls.Add(this.btnSetModo);
			this.Controls.Add(this.btnSetCartao);
			this.Controls.Add(this.txtPagFormaModo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtCartaoCredito);
			this.Controls.Add(this.lblCartao);
			this.Controls.Add(this.cmbAtivo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lstListagem);
			this.Controls.Add(this.lblID);
			this.Controls.Add(this.btnSetBanco);
			this.Controls.Add(this.txtBanco);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.tspMenu);
			this.Controls.Add(this.txtAPagarForma);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblCongregacao);
			this.KeyPreview = true;
			this.Name = "frmCobrancaForma";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.lblCongregacao, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.txtAPagarForma, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.Label6, 0);
			this.Controls.SetChildIndex(this.txtBanco, 0);
			this.Controls.SetChildIndex(this.btnSetBanco, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.lblID, 0);
			this.Controls.SetChildIndex(this.lstListagem, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.cmbAtivo, 0);
			this.Controls.SetChildIndex(this.lblCartao, 0);
			this.Controls.SetChildIndex(this.txtCartaoCredito, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.txtPagFormaModo, 0);
			this.Controls.SetChildIndex(this.btnSetCartao, 0);
			this.Controls.SetChildIndex(this.btnSetModo, 0);
			this.panel1.ResumeLayout(false);
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.lstListagem)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal System.Windows.Forms.Label lblCongregacao;
		internal System.Windows.Forms.TextBox txtAPagarForma;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnNovo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnSalvar;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnFechar;
		internal VIBlend.WinForms.Controls.vButton btnSetBanco;
		internal System.Windows.Forms.TextBox txtBanco;
		internal System.Windows.Forms.Label Label6;
		private ComponentOwl.BetterListView.BetterListView lstListagem;
		private ComponentOwl.BetterListView.BetterListViewColumnHeader clnID;
		private ComponentOwl.BetterListView.BetterListViewColumnHeader clnCadastro;
		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label label2;
		private CamadaUC.ucComboLimitedValues cmbAtivo;
		internal System.Windows.Forms.Label label3;
		internal VIBlend.WinForms.Controls.vButton btnSetCartao;
		internal System.Windows.Forms.TextBox txtCartaoCredito;
		internal System.Windows.Forms.Label lblCartao;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.TextBox txtPagFormaModo;
		internal VIBlend.WinForms.Controls.vButton btnSetModo;
		private System.Windows.Forms.ToolStripButton btnCartoesCredito;
	}
}
