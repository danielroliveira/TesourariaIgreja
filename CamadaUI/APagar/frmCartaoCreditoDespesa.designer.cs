namespace CamadaUI.APagar
{
	partial class frmCartaoCreditoDespesa
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
			this.txtCartaoDescricao = new System.Windows.Forms.TextBox();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnNovo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalvar = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.btnCartoesCredito = new System.Windows.Forms.ToolStripButton();
			this.txtCartaoNumeracao = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.lstListagem = new ComponentOwl.BetterListView.BetterListView();
			this.clnID = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
			this.clnCadastro = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
			this.lblID = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbAtivo = new CamadaUC.ucComboLimitedValues();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtCartaoBandeira = new System.Windows.Forms.TextBox();
			this.btnSetBandeira = new VIBlend.WinForms.Controls.vButton();
			this.label4 = new System.Windows.Forms.Label();
			this.btnSetSetor = new VIBlend.WinForms.Controls.vButton();
			this.txtSetor = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnSetCredor = new VIBlend.WinForms.Controls.vButton();
			this.txtCredor = new System.Windows.Forms.TextBox();
			this.lblContribuinte = new System.Windows.Forms.Label();
			this.numVencimentoDia = new System.Windows.Forms.NumericUpDown();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lstListagem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numVencimentoDia)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(601, 0);
			this.lblTitulo.Size = new System.Drawing.Size(365, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Cartão de Crédito de Despesa";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(966, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(1006, 50);
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
			// txtCartaoDescricao
			// 
			this.txtCartaoDescricao.BackColor = System.Drawing.Color.White;
			this.txtCartaoDescricao.Location = new System.Drawing.Point(526, 104);
			this.txtCartaoDescricao.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCartaoDescricao.Name = "txtCartaoDescricao";
			this.txtCartaoDescricao.Size = new System.Drawing.Size(342, 27);
			this.txtCartaoDescricao.TabIndex = 4;
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
			this.tspMenu.Size = new System.Drawing.Size(1001, 44);
			this.tspMenu.TabIndex = 20;
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
			// btnCartoesCredito
			// 
			this.btnCartoesCredito.Image = global::CamadaUI.Properties.Resources.credit_card_32;
			this.btnCartoesCredito.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnCartoesCredito.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCartoesCredito.Name = "btnCartoesCredito";
			this.btnCartoesCredito.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnCartoesCredito.Size = new System.Drawing.Size(191, 41);
			this.btnCartoesCredito.Text = " &Bandeiras de Cartão";
			this.btnCartoesCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCartoesCredito.Click += new System.EventHandler(this.btnCartoesBandeira_Click);
			// 
			// txtCartaoNumeracao
			// 
			this.txtCartaoNumeracao.Location = new System.Drawing.Point(526, 183);
			this.txtCartaoNumeracao.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCartaoNumeracao.MaxLength = 30;
			this.txtCartaoNumeracao.Name = "txtCartaoNumeracao";
			this.txtCartaoNumeracao.Size = new System.Drawing.Size(140, 27);
			this.txtCartaoNumeracao.TabIndex = 9;
			this.txtCartaoNumeracao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCartaoNumeracao_KeyPress);
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.BackColor = System.Drawing.Color.Transparent;
			this.Label6.ForeColor = System.Drawing.Color.Black;
			this.Label6.Location = new System.Drawing.Point(437, 186);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(83, 19);
			this.Label6.TabIndex = 8;
			this.Label6.Text = "Numeração";
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
			this.lstListagem.TabIndex = 21;
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
			this.clnCadastro.Text = "Descrição";
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
			this.cmbAtivo.Location = new System.Drawing.Point(526, 300);
			this.cmbAtivo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.cmbAtivo.Name = "cmbAtivo";
			this.cmbAtivo.Size = new System.Drawing.Size(103, 27);
			this.cmbAtivo.TabIndex = 19;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(478, 303);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 19);
			this.label3.TabIndex = 18;
			this.label3.Text = "Ativo";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(453, 146);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 19);
			this.label1.TabIndex = 5;
			this.label1.Text = "Bandeira";
			// 
			// txtCartaoBandeira
			// 
			this.txtCartaoBandeira.Location = new System.Drawing.Point(526, 143);
			this.txtCartaoBandeira.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCartaoBandeira.MaxLength = 30;
			this.txtCartaoBandeira.Name = "txtCartaoBandeira";
			this.txtCartaoBandeira.Size = new System.Drawing.Size(228, 27);
			this.txtCartaoBandeira.TabIndex = 6;
			this.txtCartaoBandeira.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			this.txtCartaoBandeira.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
			// 
			// btnSetBandeira
			// 
			this.btnSetBandeira.AllowAnimations = true;
			this.btnSetBandeira.BackColor = System.Drawing.Color.Transparent;
			this.btnSetBandeira.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetBandeira.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetBandeira.Location = new System.Drawing.Point(760, 143);
			this.btnSetBandeira.Name = "btnSetBandeira";
			this.btnSetBandeira.RoundedCornersMask = ((byte)(15));
			this.btnSetBandeira.RoundedCornersRadius = 0;
			this.btnSetBandeira.Size = new System.Drawing.Size(34, 27);
			this.btnSetBandeira.TabIndex = 7;
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
			this.label4.Location = new System.Drawing.Point(676, 186);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(131, 19);
			this.label4.TabIndex = 10;
			this.label4.Text = "Dia do Vencimento";
			// 
			// btnSetSetor
			// 
			this.btnSetSetor.AllowAnimations = true;
			this.btnSetSetor.BackColor = System.Drawing.Color.Transparent;
			this.btnSetSetor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetSetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetSetor.Location = new System.Drawing.Point(872, 222);
			this.btnSetSetor.Name = "btnSetSetor";
			this.btnSetSetor.RoundedCornersMask = ((byte)(15));
			this.btnSetSetor.RoundedCornersRadius = 0;
			this.btnSetSetor.Size = new System.Drawing.Size(34, 27);
			this.btnSetSetor.TabIndex = 14;
			this.btnSetSetor.TabStop = false;
			this.btnSetSetor.Text = "...";
			this.btnSetSetor.UseCompatibleTextRendering = true;
			this.btnSetSetor.UseVisualStyleBackColor = false;
			this.btnSetSetor.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetSetor.Click += new System.EventHandler(this.btnSetSetor_Click);
			// 
			// txtSetor
			// 
			this.txtSetor.Location = new System.Drawing.Point(526, 222);
			this.txtSetor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtSetor.MaxLength = 30;
			this.txtSetor.Name = "txtSetor";
			this.txtSetor.Size = new System.Drawing.Size(340, 27);
			this.txtSetor.TabIndex = 13;
			this.txtSetor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			this.txtSetor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(415, 225);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(105, 19);
			this.label5.TabIndex = 12;
			this.label5.Text = "Setor Debitado";
			// 
			// btnSetCredor
			// 
			this.btnSetCredor.AllowAnimations = true;
			this.btnSetCredor.BackColor = System.Drawing.Color.Transparent;
			this.btnSetCredor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetCredor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetCredor.Location = new System.Drawing.Point(943, 261);
			this.btnSetCredor.Name = "btnSetCredor";
			this.btnSetCredor.RoundedCornersMask = ((byte)(15));
			this.btnSetCredor.RoundedCornersRadius = 0;
			this.btnSetCredor.Size = new System.Drawing.Size(34, 27);
			this.btnSetCredor.TabIndex = 17;
			this.btnSetCredor.TabStop = false;
			this.btnSetCredor.Text = "...";
			this.btnSetCredor.UseCompatibleTextRendering = true;
			this.btnSetCredor.UseVisualStyleBackColor = false;
			this.btnSetCredor.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetCredor.Click += new System.EventHandler(this.btnSetCredor_Click);
			// 
			// txtCredor
			// 
			this.txtCredor.Location = new System.Drawing.Point(526, 261);
			this.txtCredor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCredor.MaxLength = 30;
			this.txtCredor.Name = "txtCredor";
			this.txtCredor.Size = new System.Drawing.Size(411, 27);
			this.txtCredor.TabIndex = 16;
			this.txtCredor.Tag = "Pressione a tecla (+) para procurar";
			this.txtCredor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			this.txtCredor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
			// 
			// lblContribuinte
			// 
			this.lblContribuinte.AutoSize = true;
			this.lblContribuinte.BackColor = System.Drawing.Color.Transparent;
			this.lblContribuinte.ForeColor = System.Drawing.Color.Black;
			this.lblContribuinte.Location = new System.Drawing.Point(382, 264);
			this.lblContribuinte.Name = "lblContribuinte";
			this.lblContribuinte.Size = new System.Drawing.Size(138, 19);
			this.lblContribuinte.TabIndex = 15;
			this.lblContribuinte.Text = "Credor / Fornecedor";
			// 
			// numVencimentoDia
			// 
			this.numVencimentoDia.Location = new System.Drawing.Point(813, 183);
			this.numVencimentoDia.Maximum = new decimal(new int[] {
			28,
			0,
			0,
			0});
			this.numVencimentoDia.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.numVencimentoDia.Name = "numVencimentoDia";
			this.numVencimentoDia.Size = new System.Drawing.Size(53, 27);
			this.numVencimentoDia.TabIndex = 11;
			this.numVencimentoDia.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			// 
			// frmCartaoCreditoDespesa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(1006, 449);
			this.Controls.Add(this.numVencimentoDia);
			this.Controls.Add(this.btnSetSetor);
			this.Controls.Add(this.txtSetor);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnSetCredor);
			this.Controls.Add(this.txtCredor);
			this.Controls.Add(this.lblContribuinte);
			this.Controls.Add(this.btnSetBandeira);
			this.Controls.Add(this.txtCartaoBandeira);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cmbAtivo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lstListagem);
			this.Controls.Add(this.lblID);
			this.Controls.Add(this.txtCartaoNumeracao);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.tspMenu);
			this.Controls.Add(this.txtCartaoDescricao);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblCongregacao);
			this.KeyPreview = true;
			this.Name = "frmCartaoCreditoDespesa";
			this.Activated += new System.EventHandler(this.frmSetorProcura_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSetorProcura_FormClosed);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.lblCongregacao, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.txtCartaoDescricao, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.Label6, 0);
			this.Controls.SetChildIndex(this.txtCartaoNumeracao, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.lblID, 0);
			this.Controls.SetChildIndex(this.lstListagem, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.cmbAtivo, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.txtCartaoBandeira, 0);
			this.Controls.SetChildIndex(this.btnSetBandeira, 0);
			this.Controls.SetChildIndex(this.lblContribuinte, 0);
			this.Controls.SetChildIndex(this.txtCredor, 0);
			this.Controls.SetChildIndex(this.btnSetCredor, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.txtSetor, 0);
			this.Controls.SetChildIndex(this.btnSetSetor, 0);
			this.Controls.SetChildIndex(this.numVencimentoDia, 0);
			this.panel1.ResumeLayout(false);
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.lstListagem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numVencimentoDia)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal System.Windows.Forms.Label lblCongregacao;
		internal System.Windows.Forms.TextBox txtCartaoDescricao;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnNovo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnSalvar;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnFechar;
		internal System.Windows.Forms.TextBox txtCartaoNumeracao;
		internal System.Windows.Forms.Label Label6;
		private ComponentOwl.BetterListView.BetterListView lstListagem;
		private ComponentOwl.BetterListView.BetterListViewColumnHeader clnID;
		private ComponentOwl.BetterListView.BetterListViewColumnHeader clnCadastro;
		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label label2;
		private CamadaUC.ucComboLimitedValues cmbAtivo;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.TextBox txtCartaoBandeira;
		internal VIBlend.WinForms.Controls.vButton btnSetBandeira;
		private System.Windows.Forms.ToolStripButton btnCartoesCredito;
		internal System.Windows.Forms.Label label4;
		internal VIBlend.WinForms.Controls.vButton btnSetSetor;
		internal System.Windows.Forms.TextBox txtSetor;
		internal System.Windows.Forms.Label label5;
		internal VIBlend.WinForms.Controls.vButton btnSetCredor;
		internal System.Windows.Forms.TextBox txtCredor;
		internal System.Windows.Forms.Label lblContribuinte;
		private System.Windows.Forms.NumericUpDown numVencimentoDia;
	}
}
