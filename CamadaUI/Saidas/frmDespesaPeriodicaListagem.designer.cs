namespace CamadaUI.Saidas
{
	partial class frmDespesaPeriodicaListagem
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.btnFechar = new System.Windows.Forms.Button();
			this.btnAdicionar = new System.Windows.Forms.Button();
			this.btnVisualizar = new System.Windows.Forms.Button();
			this.dgvListagem = new System.Windows.Forms.DataGridView();
			this.clnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnData = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnCredor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnRecorrencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnAtivo = new System.Windows.Forms.DataGridViewImageColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.lblValorTotal = new System.Windows.Forms.Label();
			this.btnImprimir = new System.Windows.Forms.Button();
			this.lblValorMensal = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSetContribuinte = new VIBlend.WinForms.Controls.vButton();
			this.txtCredor = new System.Windows.Forms.TextBox();
			this.lblContribuinte = new System.Windows.Forms.Label();
			this.btnSetConta = new VIBlend.WinForms.Controls.vButton();
			this.btnSetSetor = new VIBlend.WinForms.Controls.vButton();
			this.txtDespesaTipo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtSetor = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.MenuListagem = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.AtivarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DesativarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.visualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.excluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnExcluir = new System.Windows.Forms.Button();
			this.line1 = new AwesomeShapeControl.Line();
			this.pnlSituacao = new System.Windows.Forms.Panel();
			this.rbtInativas = new System.Windows.Forms.RadioButton();
			this.rbtAtivas = new System.Windows.Forms.RadioButton();
			this.txtProcura = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).BeginInit();
			this.MenuListagem.SuspendLayout();
			this.pnlSituacao.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(961, 0);
			this.lblTitulo.Size = new System.Drawing.Size(304, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Procurar Despesa Periódica";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(1265, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(1305, 50);
			// 
			// btnFechar
			// 
			this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.delete_16;
			this.btnFechar.Location = new System.Drawing.Point(1196, 634);
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Size = new System.Drawing.Size(97, 42);
			this.btnFechar.TabIndex = 23;
			this.btnFechar.Text = "&Fechar";
			this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnFechar.UseVisualStyleBackColor = true;
			this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// btnAdicionar
			// 
			this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAdicionar.Image = global::CamadaUI.Properties.Resources.add_16;
			this.btnAdicionar.Location = new System.Drawing.Point(12, 634);
			this.btnAdicionar.Name = "btnAdicionar";
			this.btnAdicionar.Size = new System.Drawing.Size(126, 42);
			this.btnAdicionar.TabIndex = 14;
			this.btnAdicionar.Text = "&Adicionar";
			this.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAdicionar.UseVisualStyleBackColor = true;
			this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
			// 
			// btnVisualizar
			// 
			this.btnVisualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnVisualizar.Image = global::CamadaUI.Properties.Resources.search_page_24;
			this.btnVisualizar.Location = new System.Drawing.Point(143, 634);
			this.btnVisualizar.Name = "btnVisualizar";
			this.btnVisualizar.Size = new System.Drawing.Size(126, 42);
			this.btnVisualizar.TabIndex = 15;
			this.btnVisualizar.Text = "&Visualizar";
			this.btnVisualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnVisualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnVisualizar.UseVisualStyleBackColor = true;
			this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
			// 
			// dgvListagem
			// 
			this.dgvListagem.AllowUserToAddRows = false;
			this.dgvListagem.AllowUserToDeleteRows = false;
			this.dgvListagem.AllowUserToResizeColumns = false;
			this.dgvListagem.AllowUserToResizeRows = false;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.OldLace;
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
			this.dgvListagem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvListagem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvListagem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvListagem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvListagem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvListagem.ColumnHeadersHeight = 33;
			this.dgvListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvListagem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnID,
            this.clnData,
            this.clnSetor,
            this.clnTipo,
            this.clnDescricao,
            this.clnCredor,
            this.clnRecorrencia,
            this.clnValor,
            this.clnAtivo});
			this.dgvListagem.EnableHeadersVisualStyles = false;
			this.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption;
			this.dgvListagem.Location = new System.Drawing.Point(11, 134);
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
			this.dgvListagem.Size = new System.Drawing.Size(1282, 488);
			this.dgvListagem.TabIndex = 13;
			this.dgvListagem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListagem_CellFormatting);
			this.dgvListagem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListagem_KeyDown);
			this.dgvListagem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvListagem_MouseDown);
			// 
			// clnID
			// 
			this.clnID.Frozen = true;
			this.clnID.HeaderText = "Reg.";
			this.clnID.Name = "clnID";
			this.clnID.ReadOnly = true;
			this.clnID.Width = 60;
			// 
			// clnData
			// 
			this.clnData.Frozen = true;
			this.clnData.HeaderText = "Ponteiro";
			this.clnData.Name = "clnData";
			this.clnData.ReadOnly = true;
			this.clnData.Width = 85;
			// 
			// clnSetor
			// 
			this.clnSetor.Frozen = true;
			this.clnSetor.HeaderText = "Setor de Recursos";
			this.clnSetor.Name = "clnSetor";
			this.clnSetor.ReadOnly = true;
			this.clnSetor.Width = 200;
			// 
			// clnTipo
			// 
			this.clnTipo.Frozen = true;
			this.clnTipo.HeaderText = "Tipo de Despesa";
			this.clnTipo.Name = "clnTipo";
			this.clnTipo.ReadOnly = true;
			this.clnTipo.Width = 170;
			// 
			// clnDescricao
			// 
			this.clnDescricao.Frozen = true;
			this.clnDescricao.HeaderText = "Descrição";
			this.clnDescricao.Name = "clnDescricao";
			this.clnDescricao.ReadOnly = true;
			this.clnDescricao.Width = 230;
			// 
			// clnCredor
			// 
			this.clnCredor.HeaderText = "Credor";
			this.clnCredor.Name = "clnCredor";
			this.clnCredor.ReadOnly = true;
			this.clnCredor.Width = 200;
			// 
			// clnRecorrencia
			// 
			this.clnRecorrencia.HeaderText = "Recorrência";
			this.clnRecorrencia.Name = "clnRecorrencia";
			this.clnRecorrencia.ReadOnly = true;
			this.clnRecorrencia.Width = 120;
			// 
			// clnValor
			// 
			this.clnValor.HeaderText = "Valor";
			this.clnValor.Name = "clnValor";
			this.clnValor.ReadOnly = true;
			// 
			// clnAtivo
			// 
			this.clnAtivo.HeaderText = "Ativa";
			this.clnAtivo.Name = "clnAtivo";
			this.clnAtivo.ReadOnly = true;
			this.clnAtivo.Width = 70;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(1092, 624);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 15);
			this.label1.TabIndex = 20;
			this.label1.Text = "Valor Mensal:";
			// 
			// lblValorTotal
			// 
			this.lblValorTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValorTotal.BackColor = System.Drawing.Color.LightGray;
			this.lblValorTotal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorTotal.Location = new System.Drawing.Point(895, 643);
			this.lblValorTotal.Name = "lblValorTotal";
			this.lblValorTotal.Size = new System.Drawing.Size(137, 32);
			this.lblValorTotal.TabIndex = 21;
			this.lblValorTotal.Text = "R$ 0,00";
			this.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnImprimir
			// 
			this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnImprimir.Image = global::CamadaUI.Properties.Resources.imprimir_24;
			this.btnImprimir.Location = new System.Drawing.Point(426, 634);
			this.btnImprimir.Name = "btnImprimir";
			this.btnImprimir.Size = new System.Drawing.Size(182, 42);
			this.btnImprimir.TabIndex = 18;
			this.btnImprimir.Text = "&Imprimir Listagem";
			this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnImprimir.UseVisualStyleBackColor = true;
			this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
			// 
			// lblValorMensal
			// 
			this.lblValorMensal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValorMensal.BackColor = System.Drawing.Color.LightGray;
			this.lblValorMensal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorMensal.Location = new System.Drawing.Point(1038, 643);
			this.lblValorMensal.Name = "lblValorMensal";
			this.lblValorMensal.Size = new System.Drawing.Size(137, 32);
			this.lblValorMensal.TabIndex = 22;
			this.lblValorMensal.Text = "R$ 0,00";
			this.lblValorMensal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.DimGray;
			this.label3.Location = new System.Drawing.Point(963, 624);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 15);
			this.label3.TabIndex = 19;
			this.label3.Text = "Valor Total:";
			// 
			// btnSetContribuinte
			// 
			this.btnSetContribuinte.AllowAnimations = true;
			this.btnSetContribuinte.BackColor = System.Drawing.Color.Transparent;
			this.btnSetContribuinte.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetContribuinte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetContribuinte.Location = new System.Drawing.Point(981, 59);
			this.btnSetContribuinte.Name = "btnSetContribuinte";
			this.btnSetContribuinte.RoundedCornersMask = ((byte)(15));
			this.btnSetContribuinte.RoundedCornersRadius = 0;
			this.btnSetContribuinte.Size = new System.Drawing.Size(34, 27);
			this.btnSetContribuinte.TabIndex = 5;
			this.btnSetContribuinte.TabStop = false;
			this.btnSetContribuinte.Text = "...";
			this.btnSetContribuinte.UseCompatibleTextRendering = true;
			this.btnSetContribuinte.UseVisualStyleBackColor = false;
			this.btnSetContribuinte.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetContribuinte.Click += new System.EventHandler(this.btnSetCredor_Click);
			// 
			// txtCredor
			// 
			this.txtCredor.Location = new System.Drawing.Point(586, 59);
			this.txtCredor.MaxLength = 30;
			this.txtCredor.Name = "txtCredor";
			this.txtCredor.Size = new System.Drawing.Size(389, 27);
			this.txtCredor.TabIndex = 4;
			this.txtCredor.Tag = "Pressione a tecla (+) para procurar";
			this.txtCredor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// lblContribuinte
			// 
			this.lblContribuinte.AutoSize = true;
			this.lblContribuinte.BackColor = System.Drawing.Color.Transparent;
			this.lblContribuinte.ForeColor = System.Drawing.Color.Black;
			this.lblContribuinte.Location = new System.Drawing.Point(528, 62);
			this.lblContribuinte.Name = "lblContribuinte";
			this.lblContribuinte.Size = new System.Drawing.Size(52, 19);
			this.lblContribuinte.TabIndex = 3;
			this.lblContribuinte.Text = "Credor";
			// 
			// btnSetConta
			// 
			this.btnSetConta.AllowAnimations = true;
			this.btnSetConta.BackColor = System.Drawing.Color.Transparent;
			this.btnSetConta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetConta.Location = new System.Drawing.Point(517, 92);
			this.btnSetConta.Name = "btnSetConta";
			this.btnSetConta.RoundedCornersMask = ((byte)(15));
			this.btnSetConta.RoundedCornersRadius = 0;
			this.btnSetConta.Size = new System.Drawing.Size(34, 27);
			this.btnSetConta.TabIndex = 8;
			this.btnSetConta.TabStop = false;
			this.btnSetConta.Text = "...";
			this.btnSetConta.UseCompatibleTextRendering = true;
			this.btnSetConta.UseVisualStyleBackColor = false;
			this.btnSetConta.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetConta.Click += new System.EventHandler(this.btnSetTipo_Click);
			// 
			// btnSetSetor
			// 
			this.btnSetSetor.AllowAnimations = true;
			this.btnSetSetor.BackColor = System.Drawing.Color.Transparent;
			this.btnSetSetor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetSetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetSetor.Location = new System.Drawing.Point(981, 92);
			this.btnSetSetor.Name = "btnSetSetor";
			this.btnSetSetor.RoundedCornersMask = ((byte)(15));
			this.btnSetSetor.RoundedCornersRadius = 0;
			this.btnSetSetor.Size = new System.Drawing.Size(34, 27);
			this.btnSetSetor.TabIndex = 11;
			this.btnSetSetor.TabStop = false;
			this.btnSetSetor.Text = "...";
			this.btnSetSetor.UseCompatibleTextRendering = true;
			this.btnSetSetor.UseVisualStyleBackColor = false;
			this.btnSetSetor.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetSetor.Click += new System.EventHandler(this.btnSetSetor_Click);
			// 
			// txtDespesaTipo
			// 
			this.txtDespesaTipo.Location = new System.Drawing.Point(142, 92);
			this.txtDespesaTipo.MaxLength = 30;
			this.txtDespesaTipo.Name = "txtDespesaTipo";
			this.txtDespesaTipo.Size = new System.Drawing.Size(369, 27);
			this.txtDespesaTipo.TabIndex = 7;
			this.txtDespesaTipo.Tag = "Pressione a tecla (+) para procurar";
			this.txtDespesaTipo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(19, 95);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(117, 19);
			this.label4.TabIndex = 6;
			this.label4.Text = "Tipo de Despesa";
			// 
			// txtSetor
			// 
			this.txtSetor.Location = new System.Drawing.Point(699, 92);
			this.txtSetor.MaxLength = 30;
			this.txtSetor.Name = "txtSetor";
			this.txtSetor.Size = new System.Drawing.Size(276, 27);
			this.txtSetor.TabIndex = 10;
			this.txtSetor.Tag = "Pressione a tecla (+) para procurar";
			this.txtSetor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(584, 95);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(109, 19);
			this.label2.TabIndex = 9;
			this.label2.Text = "Setor de Débito";
			// 
			// MenuListagem
			// 
			this.MenuListagem.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.MenuListagem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AtivarToolStripMenuItem,
            this.DesativarToolStripMenuItem,
            this.toolStripSeparator1,
            this.visualizarToolStripMenuItem,
            this.excluirToolStripMenuItem});
			this.MenuListagem.Name = "MenuFab";
			this.MenuListagem.Size = new System.Drawing.Size(275, 114);
			// 
			// AtivarToolStripMenuItem
			// 
			this.AtivarToolStripMenuItem.Image = global::CamadaUI.Properties.Resources.accept_16;
			this.AtivarToolStripMenuItem.Name = "AtivarToolStripMenuItem";
			this.AtivarToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
			this.AtivarToolStripMenuItem.Text = "Ativar Despesa Periódica";
			this.AtivarToolStripMenuItem.Click += new System.EventHandler(this.AtivarDesativar_Click);
			// 
			// DesativarToolStripMenuItem
			// 
			this.DesativarToolStripMenuItem.Image = global::CamadaUI.Properties.Resources.block_16;
			this.DesativarToolStripMenuItem.Name = "DesativarToolStripMenuItem";
			this.DesativarToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
			this.DesativarToolStripMenuItem.Text = "Desativar Despesa Periódica";
			this.DesativarToolStripMenuItem.Click += new System.EventHandler(this.AtivarDesativar_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(271, 6);
			// 
			// visualizarToolStripMenuItem
			// 
			this.visualizarToolStripMenuItem.Image = global::CamadaUI.Properties.Resources.search_page_24;
			this.visualizarToolStripMenuItem.Name = "visualizarToolStripMenuItem";
			this.visualizarToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
			this.visualizarToolStripMenuItem.Text = "Visualizar";
			// 
			// excluirToolStripMenuItem
			// 
			this.excluirToolStripMenuItem.Image = global::CamadaUI.Properties.Resources.lixeira_24;
			this.excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
			this.excluirToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
			this.excluirToolStripMenuItem.Text = "Excluir";
			// 
			// btnExcluir
			// 
			this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnExcluir.Image = global::CamadaUI.Properties.Resources.lixeira_24;
			this.btnExcluir.Location = new System.Drawing.Point(275, 634);
			this.btnExcluir.Name = "btnExcluir";
			this.btnExcluir.Size = new System.Drawing.Size(126, 42);
			this.btnExcluir.TabIndex = 16;
			this.btnExcluir.Text = "&Excluir";
			this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnExcluir.UseVisualStyleBackColor = true;
			this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
			// 
			// line1
			// 
			this.line1.EndPoint = new System.Drawing.Point(5, 42);
			this.line1.LineColor = System.Drawing.Color.Silver;
			this.line1.LineWidth = 3F;
			this.line1.Location = new System.Drawing.Point(409, 630);
			this.line1.Name = "line1";
			this.line1.Size = new System.Drawing.Size(10, 47);
			this.line1.StartPoint = new System.Drawing.Point(5, 5);
			this.line1.TabIndex = 17;
			// 
			// pnlSituacao
			// 
			this.pnlSituacao.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.pnlSituacao.Controls.Add(this.rbtInativas);
			this.pnlSituacao.Controls.Add(this.rbtAtivas);
			this.pnlSituacao.Location = new System.Drawing.Point(1039, 73);
			this.pnlSituacao.Name = "pnlSituacao";
			this.pnlSituacao.Size = new System.Drawing.Size(254, 41);
			this.pnlSituacao.TabIndex = 12;
			// 
			// rbtInativas
			// 
			this.rbtInativas.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtInativas.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rbtInativas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.rbtInativas.Location = new System.Drawing.Point(128, 4);
			this.rbtInativas.Name = "rbtInativas";
			this.rbtInativas.Size = new System.Drawing.Size(111, 34);
			this.rbtInativas.TabIndex = 1;
			this.rbtInativas.Tag = "false";
			this.rbtInativas.Text = "Inativas";
			this.rbtInativas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtInativas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.rbtInativas.UseVisualStyleBackColor = true;
			// 
			// rbtAtivas
			// 
			this.rbtAtivas.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtAtivas.Checked = true;
			this.rbtAtivas.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rbtAtivas.Image = global::CamadaUI.Properties.Resources.accept_16;
			this.rbtAtivas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.rbtAtivas.Location = new System.Drawing.Point(12, 4);
			this.rbtAtivas.Name = "rbtAtivas";
			this.rbtAtivas.Size = new System.Drawing.Size(111, 34);
			this.rbtAtivas.TabIndex = 0;
			this.rbtAtivas.TabStop = true;
			this.rbtAtivas.Tag = "true";
			this.rbtAtivas.Text = "Ativas";
			this.rbtAtivas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtAtivas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.rbtAtivas.UseVisualStyleBackColor = true;
			// 
			// txtProcura
			// 
			this.txtProcura.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtProcura.Location = new System.Drawing.Point(142, 59);
			this.txtProcura.Name = "txtProcura";
			this.txtProcura.Size = new System.Drawing.Size(369, 27);
			this.txtProcura.TabIndex = 2;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 62);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(126, 19);
			this.label5.TabIndex = 1;
			this.label5.Text = "Procura Descrição";
			// 
			// frmDespesaPeriodicaListagem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(1305, 686);
			this.Controls.Add(this.txtProcura);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.pnlSituacao);
			this.Controls.Add(this.line1);
			this.Controls.Add(this.btnExcluir);
			this.Controls.Add(this.btnSetContribuinte);
			this.Controls.Add(this.txtCredor);
			this.Controls.Add(this.lblContribuinte);
			this.Controls.Add(this.btnSetConta);
			this.Controls.Add(this.btnSetSetor);
			this.Controls.Add(this.txtDespesaTipo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtSetor);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblValorMensal);
			this.Controls.Add(this.lblValorTotal);
			this.Controls.Add(this.dgvListagem);
			this.Controls.Add(this.btnFechar);
			this.Controls.Add(this.btnImprimir);
			this.Controls.Add(this.btnAdicionar);
			this.Controls.Add(this.btnVisualizar);
			this.KeyPreview = true;
			this.Name = "frmDespesaPeriodicaListagem";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.btnVisualizar, 0);
			this.Controls.SetChildIndex(this.btnAdicionar, 0);
			this.Controls.SetChildIndex(this.btnImprimir, 0);
			this.Controls.SetChildIndex(this.btnFechar, 0);
			this.Controls.SetChildIndex(this.dgvListagem, 0);
			this.Controls.SetChildIndex(this.lblValorTotal, 0);
			this.Controls.SetChildIndex(this.lblValorMensal, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.txtSetor, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.txtDespesaTipo, 0);
			this.Controls.SetChildIndex(this.btnSetSetor, 0);
			this.Controls.SetChildIndex(this.btnSetConta, 0);
			this.Controls.SetChildIndex(this.lblContribuinte, 0);
			this.Controls.SetChildIndex(this.txtCredor, 0);
			this.Controls.SetChildIndex(this.btnSetContribuinte, 0);
			this.Controls.SetChildIndex(this.btnExcluir, 0);
			this.Controls.SetChildIndex(this.line1, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.pnlSituacao, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.txtProcura, 0);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).EndInit();
			this.MenuListagem.ResumeLayout(false);
			this.pnlSituacao.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button btnFechar;
		internal System.Windows.Forms.Button btnAdicionar;
		internal System.Windows.Forms.Button btnVisualizar;
		internal System.Windows.Forms.DataGridView dgvListagem;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Label lblValorTotal;
		internal System.Windows.Forms.Button btnImprimir;
		internal System.Windows.Forms.Label lblValorMensal;
		internal System.Windows.Forms.Label label3;
		internal VIBlend.WinForms.Controls.vButton btnSetContribuinte;
		internal System.Windows.Forms.TextBox txtCredor;
		internal System.Windows.Forms.Label lblContribuinte;
		internal VIBlend.WinForms.Controls.vButton btnSetConta;
		internal VIBlend.WinForms.Controls.vButton btnSetSetor;
		internal System.Windows.Forms.TextBox txtDespesaTipo;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TextBox txtSetor;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.ContextMenuStrip MenuListagem;
		internal System.Windows.Forms.ToolStripMenuItem AtivarToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem DesativarToolStripMenuItem;
		internal System.Windows.Forms.Button btnExcluir;
		private AwesomeShapeControl.Line line1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem excluirToolStripMenuItem;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnID;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnData;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnSetor;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnTipo;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnDescricao;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnCredor;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnRecorrencia;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValor;
		private System.Windows.Forms.DataGridViewImageColumn clnAtivo;
		private System.Windows.Forms.Panel pnlSituacao;
		private System.Windows.Forms.RadioButton rbtInativas;
		private System.Windows.Forms.RadioButton rbtAtivas;
		internal System.Windows.Forms.TextBox txtProcura;
		internal System.Windows.Forms.Label label5;
	}
}
