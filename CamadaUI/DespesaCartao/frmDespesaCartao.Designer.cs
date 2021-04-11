namespace CamadaUI.DespesaCartao
{
	partial class frmDespesaCartao
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDespesaCartao));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnFinalizar = new System.Windows.Forms.ToolStripButton();
			this.btnExcluirDespesa = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuImagem = new System.Windows.Forms.ToolStripDropDownButton();
			this.btnInserirImagem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnVerImagem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnRemoverImagem = new System.Windows.Forms.ToolStripMenuItem();
			this.lblDespesaDescricao = new System.Windows.Forms.Label();
			this.lblCongregacao = new System.Windows.Forms.Label();
			this.lblCredor = new System.Windows.Forms.Label();
			this.lblContribuinte = new System.Windows.Forms.Label();
			this.btnSetSetor = new VIBlend.WinForms.Controls.vButton();
			this.txtSetor = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.line2 = new AwesomeShapeControl.Line();
			this.label6 = new System.Windows.Forms.Label();
			this.dgvListagem = new System.Windows.Forms.DataGridView();
			this.clnCredor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnIdentificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mnuOperacoes = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuAdicionarAPagar = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuExcluirAPagar = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuImagemAPagar = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuImagemInserir = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuImagemVisualizar = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuImagemRemover = new System.Windows.Forms.ToolStripMenuItem();
			this.lblDespesaData = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lblDespesaValor = new System.Windows.Forms.Label();
			this.btnIncluirItem = new System.Windows.Forms.Button();
			this.btnRemoverItem = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).BeginInit();
			this.mnuOperacoes.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(484, 0);
			this.lblTitulo.Size = new System.Drawing.Size(356, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "Despesas de Cartão de Crédito";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(840, 0);
			this.btnClose.TabIndex = 3;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblDespesaData);
			this.panel1.Controls.Add(this.lblID);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.lbl_IdTexto);
			this.panel1.Size = new System.Drawing.Size(880, 50);
			this.panel1.Controls.SetChildIndex(this.btnClose, 0);
			this.panel1.Controls.SetChildIndex(this.lblTitulo, 0);
			this.panel1.Controls.SetChildIndex(this.lbl_IdTexto, 0);
			this.panel1.Controls.SetChildIndex(this.label7, 0);
			this.panel1.Controls.SetChildIndex(this.lblID, 0);
			this.panel1.Controls.SetChildIndex(this.lblDespesaData, 0);
			// 
			// lblID
			// 
			this.lblID.BackColor = System.Drawing.Color.Transparent;
			this.lblID.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblID.ForeColor = System.Drawing.Color.AliceBlue;
			this.lblID.Location = new System.Drawing.Point(6, 17);
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
			this.lbl_IdTexto.Location = new System.Drawing.Point(33, 4);
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
            this.btnFinalizar,
            this.btnExcluirDespesa,
            this.btnFechar,
            this.toolStripSeparator2,
            this.mnuImagem});
			this.tspMenu.Location = new System.Drawing.Point(2, 551);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(876, 44);
			this.tspMenu.TabIndex = 28;
			this.tspMenu.TabStop = true;
			this.tspMenu.Text = "toolStrip1";
			// 
			// btnFinalizar
			// 
			this.btnFinalizar.Image = global::CamadaUI.Properties.Resources.accept_24;
			this.btnFinalizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnFinalizar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnFinalizar.Name = "btnFinalizar";
			this.btnFinalizar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnFinalizar.Size = new System.Drawing.Size(145, 41);
			this.btnFinalizar.Text = "&Concluir Fatura";
			this.btnFinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFinalizar.Click += new System.EventHandler(this.btnConcluir_Click);
			// 
			// btnExcluirDespesa
			// 
			this.btnExcluirDespesa.Image = global::CamadaUI.Properties.Resources.delete_24;
			this.btnExcluirDespesa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnExcluirDespesa.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExcluirDespesa.Name = "btnExcluirDespesa";
			this.btnExcluirDespesa.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnExcluirDespesa.Size = new System.Drawing.Size(135, 41);
			this.btnExcluirDespesa.Text = "&Excluir Fatura";
			this.btnExcluirDespesa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnExcluirDespesa.Click += new System.EventHandler(this.btnExcluirDespesa_Click);
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
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 44);
			// 
			// mnuImagem
			// 
			this.mnuImagem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInserirImagem,
            this.btnVerImagem,
            this.toolStripSeparator3,
            this.btnRemoverImagem});
			this.mnuImagem.Enabled = false;
			this.mnuImagem.Image = ((System.Drawing.Image)(resources.GetObject("mnuImagem.Image")));
			this.mnuImagem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuImagem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuImagem.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
			this.mnuImagem.Name = "mnuImagem";
			this.mnuImagem.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.mnuImagem.Size = new System.Drawing.Size(174, 41);
			this.mnuImagem.Text = "Imagem Despesa";
			this.mnuImagem.Click += new System.EventHandler(this.mnuImagem_Click);
			// 
			// btnInserirImagem
			// 
			this.btnInserirImagem.Image = global::CamadaUI.Properties.Resources.add_16;
			this.btnInserirImagem.Name = "btnInserirImagem";
			this.btnInserirImagem.Size = new System.Drawing.Size(191, 24);
			this.btnInserirImagem.Text = "Inserir Imagem";
			this.btnInserirImagem.Click += new System.EventHandler(this.btnInserirImagem_Click);
			// 
			// btnVerImagem
			// 
			this.btnVerImagem.Image = global::CamadaUI.Properties.Resources.search_page_24;
			this.btnVerImagem.Name = "btnVerImagem";
			this.btnVerImagem.Size = new System.Drawing.Size(191, 24);
			this.btnVerImagem.Text = "Ver Imagem";
			this.btnVerImagem.Click += new System.EventHandler(this.btnVerImagem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(188, 6);
			// 
			// btnRemoverImagem
			// 
			this.btnRemoverImagem.Image = global::CamadaUI.Properties.Resources.delete_16;
			this.btnRemoverImagem.Name = "btnRemoverImagem";
			this.btnRemoverImagem.Size = new System.Drawing.Size(191, 24);
			this.btnRemoverImagem.Text = "Remover Imagem";
			this.btnRemoverImagem.Click += new System.EventHandler(this.btnRemoverImagem_Click);
			// 
			// lblDespesaDescricao
			// 
			this.lblDespesaDescricao.BackColor = System.Drawing.Color.Transparent;
			this.lblDespesaDescricao.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDespesaDescricao.ForeColor = System.Drawing.Color.Black;
			this.lblDespesaDescricao.Location = new System.Drawing.Point(214, 107);
			this.lblDespesaDescricao.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.lblDespesaDescricao.Name = "lblDespesaDescricao";
			this.lblDespesaDescricao.Size = new System.Drawing.Size(507, 30);
			this.lblDespesaDescricao.TabIndex = 20;
			this.lblDespesaDescricao.Tag = "";
			this.lblDespesaDescricao.Text = "Descrição da Despesa";
			this.lblDespesaDescricao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblDespesaDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// lblCongregacao
			// 
			this.lblCongregacao.AutoSize = true;
			this.lblCongregacao.BackColor = System.Drawing.Color.Transparent;
			this.lblCongregacao.ForeColor = System.Drawing.Color.Black;
			this.lblCongregacao.Location = new System.Drawing.Point(135, 113);
			this.lblCongregacao.Name = "lblCongregacao";
			this.lblCongregacao.Size = new System.Drawing.Size(73, 19);
			this.lblCongregacao.TabIndex = 19;
			this.lblCongregacao.Text = "Descrição";
			// 
			// lblCredor
			// 
			this.lblCredor.BackColor = System.Drawing.Color.Transparent;
			this.lblCredor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCredor.ForeColor = System.Drawing.Color.Black;
			this.lblCredor.Location = new System.Drawing.Point(214, 66);
			this.lblCredor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.lblCredor.Name = "lblCredor";
			this.lblCredor.Size = new System.Drawing.Size(507, 30);
			this.lblCredor.TabIndex = 5;
			this.lblCredor.Tag = "Pressione a tecla (+) para procurar";
			this.lblCredor.Text = "Credor / Fornecedor";
			this.lblCredor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCredor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// lblContribuinte
			// 
			this.lblContribuinte.AutoSize = true;
			this.lblContribuinte.BackColor = System.Drawing.Color.Transparent;
			this.lblContribuinte.ForeColor = System.Drawing.Color.Black;
			this.lblContribuinte.Location = new System.Drawing.Point(70, 72);
			this.lblContribuinte.Name = "lblContribuinte";
			this.lblContribuinte.Size = new System.Drawing.Size(138, 19);
			this.lblContribuinte.TabIndex = 4;
			this.lblContribuinte.Text = "Credor / Fornecedor";
			// 
			// btnSetSetor
			// 
			this.btnSetSetor.AllowAnimations = true;
			this.btnSetSetor.BackColor = System.Drawing.Color.Transparent;
			this.btnSetSetor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetSetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetSetor.Location = new System.Drawing.Point(551, 152);
			this.btnSetSetor.Name = "btnSetSetor";
			this.btnSetSetor.RoundedCornersMask = ((byte)(15));
			this.btnSetSetor.RoundedCornersRadius = 0;
			this.btnSetSetor.Size = new System.Drawing.Size(34, 27);
			this.btnSetSetor.TabIndex = 3;
			this.btnSetSetor.TabStop = false;
			this.btnSetSetor.Text = "...";
			this.btnSetSetor.UseCompatibleTextRendering = true;
			this.btnSetSetor.UseVisualStyleBackColor = false;
			this.btnSetSetor.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetSetor.Click += new System.EventHandler(this.btnSetSetor_Click);
			// 
			// txtSetor
			// 
			this.txtSetor.Location = new System.Drawing.Point(216, 152);
			this.txtSetor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtSetor.MaxLength = 30;
			this.txtSetor.Name = "txtSetor";
			this.txtSetor.Size = new System.Drawing.Size(329, 27);
			this.txtSetor.TabIndex = 2;
			this.txtSetor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(105, 155);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(105, 19);
			this.label5.TabIndex = 1;
			this.label5.Text = "Setor Debitado";
			// 
			// line2
			// 
			this.line2.EndPoint = new System.Drawing.Point(601, 5);
			this.line2.LineColor = System.Drawing.Color.LightSlateGray;
			this.line2.LineWidth = 3F;
			this.line2.Location = new System.Drawing.Point(262, 206);
			this.line2.Name = "line2";
			this.line2.Opacity = 0.5F;
			this.line2.Size = new System.Drawing.Size(606, 11);
			this.line2.StartPoint = new System.Drawing.Point(5, 6);
			this.line2.TabIndex = 25;
			this.line2.TabStop = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.LightSlateGray;
			this.label6.Location = new System.Drawing.Point(16, 199);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(248, 23);
			this.label6.TabIndex = 24;
			this.label6.Text = "ITENS INSERIDOS NA DESPESA";
			// 
			// dgvListagem
			// 
			this.dgvListagem.AllowUserToAddRows = false;
			this.dgvListagem.AllowUserToDeleteRows = false;
			this.dgvListagem.AllowUserToResizeColumns = false;
			this.dgvListagem.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.OldLace;
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
			this.dgvListagem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvListagem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvListagem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvListagem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvListagem.ColumnHeadersHeight = 33;
			this.dgvListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvListagem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnCredor,
            this.clnIdentificador,
            this.clnVencimento,
            this.clnValor});
			this.dgvListagem.EnableHeadersVisualStyles = false;
			this.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption;
			this.dgvListagem.Location = new System.Drawing.Point(24, 234);
			this.dgvListagem.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
			this.dgvListagem.MultiSelect = false;
			this.dgvListagem.Name = "dgvListagem";
			this.dgvListagem.ReadOnly = true;
			this.dgvListagem.RowHeadersVisible = false;
			this.dgvListagem.RowHeadersWidth = 45;
			this.dgvListagem.RowTemplate.Height = 30;
			this.dgvListagem.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvListagem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgvListagem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvListagem.Size = new System.Drawing.Size(677, 265);
			this.dgvListagem.TabIndex = 27;
			this.dgvListagem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvListagem_MouseDown);
			// 
			// clnCredor
			// 
			this.clnCredor.HeaderText = "Credor";
			this.clnCredor.Name = "clnCredor";
			this.clnCredor.ReadOnly = true;
			this.clnCredor.Width = 350;
			// 
			// clnIdentificador
			// 
			this.clnIdentificador.HeaderText = "No. Reg.:";
			this.clnIdentificador.Name = "clnIdentificador";
			this.clnIdentificador.ReadOnly = true;
			this.clnIdentificador.Width = 115;
			// 
			// clnVencimento
			// 
			this.clnVencimento.HeaderText = "Venc.";
			this.clnVencimento.Name = "clnVencimento";
			this.clnVencimento.ReadOnly = true;
			this.clnVencimento.Width = 80;
			// 
			// clnValor
			// 
			this.clnValor.HeaderText = "Valor";
			this.clnValor.Name = "clnValor";
			this.clnValor.ReadOnly = true;
			this.clnValor.Width = 80;
			// 
			// mnuOperacoes
			// 
			this.mnuOperacoes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuOperacoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdicionarAPagar,
            this.mnuExcluirAPagar,
            this.toolStripSeparator5,
            this.mnuImagemAPagar});
			this.mnuOperacoes.Name = "mnuOperacoes";
			this.mnuOperacoes.Size = new System.Drawing.Size(211, 118);
			// 
			// mnuAdicionarAPagar
			// 
			this.mnuAdicionarAPagar.Image = global::CamadaUI.Properties.Resources.add_24;
			this.mnuAdicionarAPagar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuAdicionarAPagar.Name = "mnuAdicionarAPagar";
			this.mnuAdicionarAPagar.Size = new System.Drawing.Size(210, 36);
			this.mnuAdicionarAPagar.Text = "Incluir APagar";
			this.mnuAdicionarAPagar.Click += new System.EventHandler(this.mnuAdicionarAPagar_Click);
			// 
			// mnuExcluirAPagar
			// 
			this.mnuExcluirAPagar.Image = global::CamadaUI.Properties.Resources.lixeira_24;
			this.mnuExcluirAPagar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuExcluirAPagar.Name = "mnuExcluirAPagar";
			this.mnuExcluirAPagar.Size = new System.Drawing.Size(210, 36);
			this.mnuExcluirAPagar.Text = "Remover APagar";
			this.mnuExcluirAPagar.Click += new System.EventHandler(this.mnuRemoverAPagar_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(207, 6);
			// 
			// mnuImagemAPagar
			// 
			this.mnuImagemAPagar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImagemInserir,
            this.mnuImagemVisualizar,
            this.toolStripSeparator4,
            this.mnuImagemRemover});
			this.mnuImagemAPagar.Image = global::CamadaUI.Properties.Resources.ImagesFolder_30;
			this.mnuImagemAPagar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuImagemAPagar.Name = "mnuImagemAPagar";
			this.mnuImagemAPagar.Size = new System.Drawing.Size(210, 36);
			this.mnuImagemAPagar.Text = "Imagem APagar";
			// 
			// mnuImagemInserir
			// 
			this.mnuImagemInserir.Image = global::CamadaUI.Properties.Resources.add_16;
			this.mnuImagemInserir.Name = "mnuImagemInserir";
			this.mnuImagemInserir.Size = new System.Drawing.Size(204, 26);
			this.mnuImagemInserir.Text = "Inserir Imagem";
			// 
			// mnuImagemVisualizar
			// 
			this.mnuImagemVisualizar.Image = global::CamadaUI.Properties.Resources.search_page_24;
			this.mnuImagemVisualizar.Name = "mnuImagemVisualizar";
			this.mnuImagemVisualizar.Size = new System.Drawing.Size(204, 26);
			this.mnuImagemVisualizar.Text = "Ver Imagem";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(201, 6);
			// 
			// mnuImagemRemover
			// 
			this.mnuImagemRemover.Image = global::CamadaUI.Properties.Resources.delete_page_30;
			this.mnuImagemRemover.Name = "mnuImagemRemover";
			this.mnuImagemRemover.Size = new System.Drawing.Size(204, 26);
			this.mnuImagemRemover.Text = "Remover Imagem";
			// 
			// lblDespesaData
			// 
			this.lblDespesaData.BackColor = System.Drawing.Color.Transparent;
			this.lblDespesaData.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDespesaData.ForeColor = System.Drawing.Color.AliceBlue;
			this.lblDespesaData.Location = new System.Drawing.Point(148, 17);
			this.lblDespesaData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblDespesaData.Name = "lblDespesaData";
			this.lblDespesaData.Size = new System.Drawing.Size(179, 30);
			this.lblDespesaData.TabIndex = 0;
			this.lblDespesaData.Text = "00/00/0000";
			this.lblDespesaData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.LightGray;
			this.label7.Location = new System.Drawing.Point(178, 4);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(117, 13);
			this.label7.TabIndex = 1;
			this.label7.Text = "Data Vencimento";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.ForeColor = System.Drawing.Color.Black;
			this.label8.Location = new System.Drawing.Point(428, 514);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(122, 19);
			this.label8.TabIndex = 1;
			this.label8.Text = "Valor da Despesa";
			// 
			// lblDespesaValor
			// 
			this.lblDespesaValor.BackColor = System.Drawing.Color.Transparent;
			this.lblDespesaValor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDespesaValor.ForeColor = System.Drawing.Color.Black;
			this.lblDespesaValor.Location = new System.Drawing.Point(556, 508);
			this.lblDespesaValor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.lblDespesaValor.Name = "lblDespesaValor";
			this.lblDespesaValor.Size = new System.Drawing.Size(145, 31);
			this.lblDespesaValor.TabIndex = 2;
			this.lblDespesaValor.Text = "R$ 0,00";
			this.lblDespesaValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnIncluirItem
			// 
			this.btnIncluirItem.Image = global::CamadaUI.Properties.Resources.AddSimple_24;
			this.btnIncluirItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnIncluirItem.Location = new System.Drawing.Point(713, 234);
			this.btnIncluirItem.Name = "btnIncluirItem";
			this.btnIncluirItem.Size = new System.Drawing.Size(149, 42);
			this.btnIncluirItem.TabIndex = 29;
			this.btnIncluirItem.Text = "Incluir Item";
			this.btnIncluirItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnIncluirItem.UseVisualStyleBackColor = true;
			this.btnIncluirItem.Click += new System.EventHandler(this.btnIncluirItem_Click);
			// 
			// btnRemoverItem
			// 
			this.btnRemoverItem.Image = global::CamadaUI.Properties.Resources.MinusSimples_24;
			this.btnRemoverItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnRemoverItem.Location = new System.Drawing.Point(713, 282);
			this.btnRemoverItem.Name = "btnRemoverItem";
			this.btnRemoverItem.Size = new System.Drawing.Size(149, 42);
			this.btnRemoverItem.TabIndex = 30;
			this.btnRemoverItem.Text = "Remover Item";
			this.btnRemoverItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnRemoverItem.UseVisualStyleBackColor = true;
			this.btnRemoverItem.Click += new System.EventHandler(this.btnRemoverItem_Click);
			// 
			// frmDespesaCartao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(880, 597);
			this.Controls.Add(this.btnRemoverItem);
			this.Controls.Add(this.btnIncluirItem);
			this.Controls.Add(this.lblDespesaValor);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.dgvListagem);
			this.Controls.Add(this.line2);
			this.Controls.Add(this.btnSetSetor);
			this.Controls.Add(this.txtSetor);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lblCredor);
			this.Controls.Add(this.lblContribuinte);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.lblDespesaDescricao);
			this.Controls.Add(this.lblCongregacao);
			this.Controls.Add(this.tspMenu);
			this.KeyPreview = true;
			this.Name = "frmDespesaCartao";
			this.Shown += new System.EventHandler(this.frmDespesaCartao_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.lblCongregacao, 0);
			this.Controls.SetChildIndex(this.lblDespesaDescricao, 0);
			this.Controls.SetChildIndex(this.label6, 0);
			this.Controls.SetChildIndex(this.lblContribuinte, 0);
			this.Controls.SetChildIndex(this.lblCredor, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.txtSetor, 0);
			this.Controls.SetChildIndex(this.btnSetSetor, 0);
			this.Controls.SetChildIndex(this.line2, 0);
			this.Controls.SetChildIndex(this.dgvListagem, 0);
			this.Controls.SetChildIndex(this.label8, 0);
			this.Controls.SetChildIndex(this.lblDespesaValor, 0);
			this.Controls.SetChildIndex(this.btnIncluirItem, 0);
			this.Controls.SetChildIndex(this.btnRemoverItem, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).EndInit();
			this.mnuOperacoes.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label lbl_IdTexto;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnFinalizar;
		private System.Windows.Forms.ToolStripButton btnFechar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		internal System.Windows.Forms.Label lblDespesaDescricao;
		internal System.Windows.Forms.Label lblCongregacao;
		internal System.Windows.Forms.Label lblCredor;
		internal System.Windows.Forms.Label lblContribuinte;
		internal VIBlend.WinForms.Controls.vButton btnSetSetor;
		internal System.Windows.Forms.TextBox txtSetor;
		internal System.Windows.Forms.Label label5;
		private AwesomeShapeControl.Line line2;
		internal System.Windows.Forms.Label label6;
		internal System.Windows.Forms.DataGridView dgvListagem;
		private System.Windows.Forms.ToolStripDropDownButton mnuImagem;
		private System.Windows.Forms.ToolStripMenuItem btnInserirImagem;
		private System.Windows.Forms.ToolStripMenuItem btnVerImagem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem btnRemoverImagem;
		private System.Windows.Forms.ContextMenuStrip mnuOperacoes;
		private System.Windows.Forms.ToolStripMenuItem mnuAdicionarAPagar;
		private System.Windows.Forms.ToolStripMenuItem mnuExcluirAPagar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem mnuImagemAPagar;
		private System.Windows.Forms.ToolStripMenuItem mnuImagemInserir;
		private System.Windows.Forms.ToolStripMenuItem mnuImagemVisualizar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem mnuImagemRemover;
		internal System.Windows.Forms.Label lblDespesaData;
		internal System.Windows.Forms.Label label7;
		internal System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblDespesaValor;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnCredor;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnIdentificador;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnVencimento;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValor;
		private System.Windows.Forms.ToolStripButton btnExcluirDespesa;
		private System.Windows.Forms.Button btnIncluirItem;
		private System.Windows.Forms.Button btnRemoverItem;
	}
}
