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
			this.txtCobrancaForma = new System.Windows.Forms.TextBox();
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
			this.vButton1 = new VIBlend.WinForms.Controls.vButton();
			this.txtCartaoBandeira = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lstListagem)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(640, 0);
			this.lblTitulo.Size = new System.Drawing.Size(231, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Formas de Cobrança";
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
			// txtCobrancaForma
			// 
			this.txtCobrancaForma.BackColor = System.Drawing.Color.White;
			this.txtCobrancaForma.Location = new System.Drawing.Point(526, 104);
			this.txtCobrancaForma.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCobrancaForma.Name = "txtCobrancaForma";
			this.txtCobrancaForma.Size = new System.Drawing.Size(342, 27);
			this.txtCobrancaForma.TabIndex = 4;
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
            this.btnFechar});
			this.tspMenu.Location = new System.Drawing.Point(2, 403);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(906, 44);
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
			this.btnSetBanco.Location = new System.Drawing.Point(760, 143);
			this.btnSetBanco.Name = "btnSetBanco";
			this.btnSetBanco.RoundedCornersMask = ((byte)(15));
			this.btnSetBanco.RoundedCornersRadius = 0;
			this.btnSetBanco.Size = new System.Drawing.Size(34, 27);
			this.btnSetBanco.TabIndex = 7;
			this.btnSetBanco.TabStop = false;
			this.btnSetBanco.Text = "...";
			this.btnSetBanco.UseCompatibleTextRendering = true;
			this.btnSetBanco.UseVisualStyleBackColor = false;
			this.btnSetBanco.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetBanco.Click += new System.EventHandler(this.btnSetBanco_Click);
			// 
			// txtBanco
			// 
			this.txtBanco.Location = new System.Drawing.Point(526, 143);
			this.txtBanco.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtBanco.MaxLength = 30;
			this.txtBanco.Name = "txtBanco";
			this.txtBanco.Size = new System.Drawing.Size(228, 27);
			this.txtBanco.TabIndex = 6;
			this.txtBanco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.BackColor = System.Drawing.Color.Transparent;
			this.Label6.ForeColor = System.Drawing.Color.Black;
			this.Label6.Location = new System.Drawing.Point(471, 146);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(49, 19);
			this.Label6.TabIndex = 5;
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
			this.lstListagem.TabIndex = 14;
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
			this.cmbAtivo.Location = new System.Drawing.Point(526, 221);
			this.cmbAtivo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.cmbAtivo.Name = "cmbAtivo";
			this.cmbAtivo.Size = new System.Drawing.Size(103, 27);
			this.cmbAtivo.TabIndex = 12;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(478, 224);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 19);
			this.label3.TabIndex = 11;
			this.label3.Text = "Ativo";
			// 
			// vButton1
			// 
			this.vButton1.AllowAnimations = true;
			this.vButton1.BackColor = System.Drawing.Color.Transparent;
			this.vButton1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.vButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.vButton1.Location = new System.Drawing.Point(760, 182);
			this.vButton1.Name = "vButton1";
			this.vButton1.RoundedCornersMask = ((byte)(15));
			this.vButton1.RoundedCornersRadius = 0;
			this.vButton1.Size = new System.Drawing.Size(34, 27);
			this.vButton1.TabIndex = 10;
			this.vButton1.TabStop = false;
			this.vButton1.Text = "n";
			this.vButton1.UseCompatibleTextRendering = true;
			this.vButton1.UseVisualStyleBackColor = false;
			this.vButton1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.vButton1.Click += new System.EventHandler(this.btnSetBandeira_Click);
			// 
			// txtCartaoBandeira
			// 
			this.txtCartaoBandeira.Location = new System.Drawing.Point(526, 182);
			this.txtCartaoBandeira.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCartaoBandeira.MaxLength = 30;
			this.txtCartaoBandeira.Name = "txtCartaoBandeira";
			this.txtCartaoBandeira.Size = new System.Drawing.Size(228, 27);
			this.txtCartaoBandeira.TabIndex = 9;
			this.txtCartaoBandeira.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			this.txtCartaoBandeira.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(386, 185);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(134, 19);
			this.label4.TabIndex = 8;
			this.label4.Text = "Bandeira do Cartão";
			// 
			// frmCobrancaForma
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(911, 449);
			this.Controls.Add(this.vButton1);
			this.Controls.Add(this.txtCartaoBandeira);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cmbAtivo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lstListagem);
			this.Controls.Add(this.lblID);
			this.Controls.Add(this.btnSetBanco);
			this.Controls.Add(this.txtBanco);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.tspMenu);
			this.Controls.Add(this.txtCobrancaForma);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblCongregacao);
			this.KeyPreview = true;
			this.Name = "frmCobrancaForma";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.lblCongregacao, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.txtCobrancaForma, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.Label6, 0);
			this.Controls.SetChildIndex(this.txtBanco, 0);
			this.Controls.SetChildIndex(this.btnSetBanco, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.lblID, 0);
			this.Controls.SetChildIndex(this.lstListagem, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.cmbAtivo, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.txtCartaoBandeira, 0);
			this.Controls.SetChildIndex(this.vButton1, 0);
			this.panel1.ResumeLayout(false);
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.lstListagem)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal System.Windows.Forms.Label lblCongregacao;
		internal System.Windows.Forms.TextBox txtCobrancaForma;
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
		internal VIBlend.WinForms.Controls.vButton vButton1;
		internal System.Windows.Forms.TextBox txtCartaoBandeira;
		internal System.Windows.Forms.Label label4;
	}
}
