namespace CamadaUI.DespesaCartao
{
	partial class frmDespesaCartaoListagem
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.btnFechar = new System.Windows.Forms.Button();
			this.btnAdicionar = new System.Windows.Forms.Button();
			this.btnVisualizar = new System.Windows.Forms.Button();
			this.dgvListagem = new System.Windows.Forms.DataGridView();
			this.clnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnData = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnDespesaDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnCredor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnSituacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.lblValorTotal = new System.Windows.Forms.Label();
			this.btnImprimirListagem = new System.Windows.Forms.Button();
			this.pnlPorMes = new System.Windows.Forms.Panel();
			this.btnPeriodoPosterior = new VIBlend.WinForms.Controls.vArrowButton();
			this.btnMesAtual = new VIBlend.WinForms.Controls.vButton();
			this.btnPeriodoAnterior = new VIBlend.WinForms.Controls.vArrowButton();
			this.lblPeriodo = new System.Windows.Forms.Label();
			this.rbtPorAno = new System.Windows.Forms.RadioButton();
			this.rbtPorPeriodo = new System.Windows.Forms.RadioButton();
			this.rbtTodas = new System.Windows.Forms.RadioButton();
			this.pnlPorPeriodo = new System.Windows.Forms.Panel();
			this.lblDtFinal = new System.Windows.Forms.Label();
			this.lblDtInicial = new System.Windows.Forms.Label();
			this.btnDtFinal = new VIBlend.WinForms.Controls.vButton();
			this.btnDtInicial = new VIBlend.WinForms.Controls.vButton();
			this.Panel2 = new System.Windows.Forms.Panel();
			this.btnExcluir = new System.Windows.Forms.Button();
			this.mnuOperacoes = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuVisualizar = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuImagem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuImagemInserir = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuImagemVisualizar = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuImagemRemover = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuExcluir = new System.Windows.Forms.ToolStripMenuItem();
			this.line1 = new AwesomeShapeControl.Line();
			this.btnSetConta = new VIBlend.WinForms.Controls.vButton();
			this.txtCartaoDescricao = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).BeginInit();
			this.pnlPorMes.SuspendLayout();
			this.pnlPorPeriodo.SuspendLayout();
			this.Panel2.SuspendLayout();
			this.mnuOperacoes.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(722, 0);
			this.lblTitulo.Size = new System.Drawing.Size(543, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Procurar Despesa de Fatura de Cartão de Crédito";
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
			this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.delete_16;
			this.btnFechar.Location = new System.Drawing.Point(1189, 634);
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Size = new System.Drawing.Size(104, 42);
			this.btnFechar.TabIndex = 14;
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
			this.btnAdicionar.Location = new System.Drawing.Point(11, 632);
			this.btnAdicionar.Name = "btnAdicionar";
			this.btnAdicionar.Size = new System.Drawing.Size(126, 42);
			this.btnAdicionar.TabIndex = 7;
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
			this.btnVisualizar.Location = new System.Drawing.Point(143, 632);
			this.btnVisualizar.Name = "btnVisualizar";
			this.btnVisualizar.Size = new System.Drawing.Size(126, 42);
			this.btnVisualizar.TabIndex = 8;
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
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.OldLace;
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
			this.dgvListagem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvListagem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.clnID,
            this.clnData,
            this.clnSetor,
            this.clnDespesaDescricao,
            this.clnCredor,
            this.clnSituacao,
            this.clnValor});
			this.dgvListagem.EnableHeadersVisualStyles = false;
			this.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption;
			this.dgvListagem.Location = new System.Drawing.Point(11, 130);
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
			this.dgvListagem.Size = new System.Drawing.Size(1282, 492);
			this.dgvListagem.TabIndex = 4;
			this.dgvListagem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListagem_KeyDown);
			this.dgvListagem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvListagem_MouseDown);
			// 
			// clnID
			// 
			this.clnID.HeaderText = "Reg.";
			this.clnID.Name = "clnID";
			this.clnID.ReadOnly = true;
			this.clnID.Width = 50;
			// 
			// clnData
			// 
			this.clnData.HeaderText = "Data";
			this.clnData.Name = "clnData";
			this.clnData.ReadOnly = true;
			// 
			// clnSetor
			// 
			this.clnSetor.HeaderText = "Setor";
			this.clnSetor.Name = "clnSetor";
			this.clnSetor.ReadOnly = true;
			this.clnSetor.Width = 180;
			// 
			// clnDespesaDescricao
			// 
			this.clnDespesaDescricao.HeaderText = "Descrição";
			this.clnDespesaDescricao.Name = "clnDespesaDescricao";
			this.clnDespesaDescricao.ReadOnly = true;
			this.clnDespesaDescricao.Width = 320;
			// 
			// clnCredor
			// 
			this.clnCredor.HeaderText = "Credor";
			this.clnCredor.Name = "clnCredor";
			this.clnCredor.ReadOnly = true;
			this.clnCredor.Width = 320;
			// 
			// clnSituacao
			// 
			this.clnSituacao.HeaderText = "Situação";
			this.clnSituacao.Name = "clnSituacao";
			this.clnSituacao.ReadOnly = true;
			// 
			// clnValor
			// 
			this.clnValor.HeaderText = "Valor";
			this.clnValor.Name = "clnValor";
			this.clnValor.ReadOnly = true;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(1110, 623);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 15);
			this.label1.TabIndex = 12;
			this.label1.Text = "Valor Total:";
			// 
			// lblValorTotal
			// 
			this.lblValorTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValorTotal.BackColor = System.Drawing.Color.LightGray;
			this.lblValorTotal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorTotal.Location = new System.Drawing.Point(1042, 642);
			this.lblValorTotal.Name = "lblValorTotal";
			this.lblValorTotal.Size = new System.Drawing.Size(137, 32);
			this.lblValorTotal.TabIndex = 13;
			this.lblValorTotal.Text = "R$ 0,00";
			this.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnImprimirListagem
			// 
			this.btnImprimirListagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnImprimirListagem.Image = global::CamadaUI.Properties.Resources.imprimir_24;
			this.btnImprimirListagem.Location = new System.Drawing.Point(423, 632);
			this.btnImprimirListagem.Name = "btnImprimirListagem";
			this.btnImprimirListagem.Size = new System.Drawing.Size(185, 42);
			this.btnImprimirListagem.TabIndex = 11;
			this.btnImprimirListagem.Text = "&Imprimir Listagem";
			this.btnImprimirListagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnImprimirListagem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnImprimirListagem.UseVisualStyleBackColor = true;
			this.btnImprimirListagem.Click += new System.EventHandler(this.btnImprimirListagem_Click);
			// 
			// pnlPorMes
			// 
			this.pnlPorMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
			this.pnlPorMes.Controls.Add(this.btnPeriodoPosterior);
			this.pnlPorMes.Controls.Add(this.btnMesAtual);
			this.pnlPorMes.Controls.Add(this.btnPeriodoAnterior);
			this.pnlPorMes.Controls.Add(this.lblPeriodo);
			this.pnlPorMes.Location = new System.Drawing.Point(344, 10);
			this.pnlPorMes.Name = "pnlPorMes";
			this.pnlPorMes.Size = new System.Drawing.Size(321, 38);
			this.pnlPorMes.TabIndex = 3;
			// 
			// btnPeriodoPosterior
			// 
			this.btnPeriodoPosterior.AllowAnimations = true;
			this.btnPeriodoPosterior.ArrowDirection = System.Windows.Forms.ArrowDirection.Right;
			this.btnPeriodoPosterior.Location = new System.Drawing.Point(220, 7);
			this.btnPeriodoPosterior.Maximum = 100;
			this.btnPeriodoPosterior.Minimum = 0;
			this.btnPeriodoPosterior.Name = "btnPeriodoPosterior";
			this.btnPeriodoPosterior.Size = new System.Drawing.Size(25, 25);
			this.btnPeriodoPosterior.TabIndex = 0;
			this.btnPeriodoPosterior.TabStop = false;
			this.btnPeriodoPosterior.Text = "VArrowButton1";
			this.btnPeriodoPosterior.Value = 0;
			this.btnPeriodoPosterior.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnPeriodoPosterior.Click += new System.EventHandler(this.btnPeriodoPosterior_Click);
			// 
			// btnMesAtual
			// 
			this.btnMesAtual.AllowAnimations = true;
			this.btnMesAtual.BackColor = System.Drawing.Color.Transparent;
			this.btnMesAtual.Location = new System.Drawing.Point(251, 7);
			this.btnMesAtual.Name = "btnMesAtual";
			this.btnMesAtual.RoundedCornersMask = ((byte)(15));
			this.btnMesAtual.RoundedCornersRadius = 0;
			this.btnMesAtual.Size = new System.Drawing.Size(63, 25);
			this.btnMesAtual.TabIndex = 5;
			this.btnMesAtual.TabStop = false;
			this.btnMesAtual.Text = "Atual";
			this.btnMesAtual.UseVisualStyleBackColor = false;
			this.btnMesAtual.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnMesAtual.Click += new System.EventHandler(this.btnMesAtual_Click);
			// 
			// btnPeriodoAnterior
			// 
			this.btnPeriodoAnterior.AllowAnimations = true;
			this.btnPeriodoAnterior.ArrowDirection = System.Windows.Forms.ArrowDirection.Left;
			this.btnPeriodoAnterior.Location = new System.Drawing.Point(13, 6);
			this.btnPeriodoAnterior.Maximum = 100;
			this.btnPeriodoAnterior.Minimum = 0;
			this.btnPeriodoAnterior.Name = "btnPeriodoAnterior";
			this.btnPeriodoAnterior.Size = new System.Drawing.Size(25, 25);
			this.btnPeriodoAnterior.TabIndex = 3;
			this.btnPeriodoAnterior.TabStop = false;
			this.btnPeriodoAnterior.Text = "VArrowButton1";
			this.btnPeriodoAnterior.Value = 0;
			this.btnPeriodoAnterior.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnPeriodoAnterior.Click += new System.EventHandler(this.btnPeriodoAnterior_Click);
			// 
			// lblPeriodo
			// 
			this.lblPeriodo.BackColor = System.Drawing.Color.Transparent;
			this.lblPeriodo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPeriodo.Location = new System.Drawing.Point(9, 4);
			this.lblPeriodo.Name = "lblPeriodo";
			this.lblPeriodo.Size = new System.Drawing.Size(238, 30);
			this.lblPeriodo.TabIndex = 2;
			this.lblPeriodo.Text = "Novembro | 2017";
			this.lblPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// rbtPorAno
			// 
			this.rbtPorAno.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtPorAno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
			this.rbtPorAno.Checked = true;
			this.rbtPorAno.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
			this.rbtPorAno.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue;
			this.rbtPorAno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rbtPorAno.Location = new System.Drawing.Point(16, 10);
			this.rbtPorAno.Name = "rbtPorAno";
			this.rbtPorAno.Size = new System.Drawing.Size(102, 38);
			this.rbtPorAno.TabIndex = 0;
			this.rbtPorAno.TabStop = true;
			this.rbtPorAno.Text = "Por Ano";
			this.rbtPorAno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtPorAno.UseVisualStyleBackColor = false;
			// 
			// rbtPorPeriodo
			// 
			this.rbtPorPeriodo.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtPorPeriodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
			this.rbtPorPeriodo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
			this.rbtPorPeriodo.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue;
			this.rbtPorPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rbtPorPeriodo.Location = new System.Drawing.Point(124, 10);
			this.rbtPorPeriodo.Name = "rbtPorPeriodo";
			this.rbtPorPeriodo.Size = new System.Drawing.Size(102, 38);
			this.rbtPorPeriodo.TabIndex = 1;
			this.rbtPorPeriodo.Text = "Por Período";
			this.rbtPorPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtPorPeriodo.UseVisualStyleBackColor = false;
			// 
			// rbtTodas
			// 
			this.rbtTodas.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtTodas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
			this.rbtTodas.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
			this.rbtTodas.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue;
			this.rbtTodas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rbtTodas.Location = new System.Drawing.Point(232, 10);
			this.rbtTodas.Name = "rbtTodas";
			this.rbtTodas.Size = new System.Drawing.Size(102, 38);
			this.rbtTodas.TabIndex = 2;
			this.rbtTodas.Text = "Todas";
			this.rbtTodas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtTodas.UseVisualStyleBackColor = false;
			// 
			// pnlPorPeriodo
			// 
			this.pnlPorPeriodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
			this.pnlPorPeriodo.Controls.Add(this.lblDtFinal);
			this.pnlPorPeriodo.Controls.Add(this.lblDtInicial);
			this.pnlPorPeriodo.Controls.Add(this.btnDtFinal);
			this.pnlPorPeriodo.Controls.Add(this.btnDtInicial);
			this.pnlPorPeriodo.Location = new System.Drawing.Point(344, 10);
			this.pnlPorPeriodo.Name = "pnlPorPeriodo";
			this.pnlPorPeriodo.Size = new System.Drawing.Size(321, 38);
			this.pnlPorPeriodo.TabIndex = 3;
			this.pnlPorPeriodo.Visible = false;
			// 
			// lblDtFinal
			// 
			this.lblDtFinal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDtFinal.Location = new System.Drawing.Point(256, 7);
			this.lblDtFinal.Name = "lblDtFinal";
			this.lblDtFinal.Size = new System.Drawing.Size(60, 25);
			this.lblDtFinal.TabIndex = 3;
			this.lblDtFinal.Text = "10/10";
			this.lblDtFinal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblDtInicial
			// 
			this.lblDtInicial.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDtInicial.Location = new System.Drawing.Point(99, 7);
			this.lblDtInicial.Name = "lblDtInicial";
			this.lblDtInicial.Size = new System.Drawing.Size(60, 25);
			this.lblDtInicial.TabIndex = 1;
			this.lblDtInicial.Text = "10/10";
			this.lblDtInicial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnDtFinal
			// 
			this.btnDtFinal.AllowAnimations = true;
			this.btnDtFinal.BackColor = System.Drawing.Color.Transparent;
			this.btnDtFinal.Location = new System.Drawing.Point(165, 7);
			this.btnDtFinal.Name = "btnDtFinal";
			this.btnDtFinal.RoundedCornersMask = ((byte)(15));
			this.btnDtFinal.RoundedCornersRadius = 0;
			this.btnDtFinal.Size = new System.Drawing.Size(85, 25);
			this.btnDtFinal.TabIndex = 2;
			this.btnDtFinal.TabStop = false;
			this.btnDtFinal.Text = "Dt. Final";
			this.btnDtFinal.UseVisualStyleBackColor = false;
			this.btnDtFinal.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnDtFinal.Click += new System.EventHandler(this.btnDt_Click);
			// 
			// btnDtInicial
			// 
			this.btnDtInicial.AllowAnimations = true;
			this.btnDtInicial.BackColor = System.Drawing.Color.Transparent;
			this.btnDtInicial.Location = new System.Drawing.Point(8, 7);
			this.btnDtInicial.Name = "btnDtInicial";
			this.btnDtInicial.RoundedCornersMask = ((byte)(15));
			this.btnDtInicial.RoundedCornersRadius = 0;
			this.btnDtInicial.Size = new System.Drawing.Size(85, 25);
			this.btnDtInicial.TabIndex = 0;
			this.btnDtInicial.TabStop = false;
			this.btnDtInicial.Text = "Dt. Inicial";
			this.btnDtInicial.UseVisualStyleBackColor = false;
			this.btnDtInicial.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnDtInicial.Click += new System.EventHandler(this.btnDt_Click);
			// 
			// Panel2
			// 
			this.Panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.Panel2.Controls.Add(this.rbtTodas);
			this.Panel2.Controls.Add(this.rbtPorPeriodo);
			this.Panel2.Controls.Add(this.rbtPorAno);
			this.Panel2.Controls.Add(this.pnlPorPeriodo);
			this.Panel2.Controls.Add(this.pnlPorMes);
			this.Panel2.Location = new System.Drawing.Point(619, 60);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(674, 58);
			this.Panel2.TabIndex = 15;
			// 
			// btnExcluir
			// 
			this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnExcluir.Image = global::CamadaUI.Properties.Resources.lixeira_24;
			this.btnExcluir.Location = new System.Drawing.Point(275, 632);
			this.btnExcluir.Name = "btnExcluir";
			this.btnExcluir.Size = new System.Drawing.Size(126, 42);
			this.btnExcluir.TabIndex = 9;
			this.btnExcluir.Text = "&Excluir";
			this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnExcluir.UseVisualStyleBackColor = true;
			this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
			// 
			// mnuOperacoes
			// 
			this.mnuOperacoes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuOperacoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVisualizar,
            this.mnuImagem,
            this.toolStripSeparator2,
            this.mnuExcluir});
			this.mnuOperacoes.Name = "mnuOperacoes";
			this.mnuOperacoes.Size = new System.Drawing.Size(224, 118);
			// 
			// mnuVisualizar
			// 
			this.mnuVisualizar.Image = global::CamadaUI.Properties.Resources.search_page_24;
			this.mnuVisualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuVisualizar.Name = "mnuVisualizar";
			this.mnuVisualizar.Size = new System.Drawing.Size(223, 36);
			this.mnuVisualizar.Text = "Visualizar Despesa";
			this.mnuVisualizar.Click += new System.EventHandler(this.mnuVisualizar_Click);
			// 
			// mnuImagem
			// 
			this.mnuImagem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImagemInserir,
            this.mnuImagemVisualizar,
            this.toolStripSeparator1,
            this.mnuImagemRemover});
			this.mnuImagem.Image = global::CamadaUI.Properties.Resources.ImagesFolder_30;
			this.mnuImagem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuImagem.Name = "mnuImagem";
			this.mnuImagem.Size = new System.Drawing.Size(223, 36);
			this.mnuImagem.Text = "Imagem";
			// 
			// mnuImagemInserir
			// 
			this.mnuImagemInserir.Image = global::CamadaUI.Properties.Resources.add_16;
			this.mnuImagemInserir.Name = "mnuImagemInserir";
			this.mnuImagemInserir.Size = new System.Drawing.Size(204, 26);
			this.mnuImagemInserir.Text = "Inserir Imagem";
			this.mnuImagemInserir.Click += new System.EventHandler(this.mnuImagemInserir_Click);
			// 
			// mnuImagemVisualizar
			// 
			this.mnuImagemVisualizar.Image = global::CamadaUI.Properties.Resources.search_page_24;
			this.mnuImagemVisualizar.Name = "mnuImagemVisualizar";
			this.mnuImagemVisualizar.Size = new System.Drawing.Size(204, 26);
			this.mnuImagemVisualizar.Text = "Ver Imagem";
			this.mnuImagemVisualizar.Click += new System.EventHandler(this.mnuImagemVisualizar_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
			// 
			// mnuImagemRemover
			// 
			this.mnuImagemRemover.Image = global::CamadaUI.Properties.Resources.delete_page_30;
			this.mnuImagemRemover.Name = "mnuImagemRemover";
			this.mnuImagemRemover.Size = new System.Drawing.Size(204, 26);
			this.mnuImagemRemover.Text = "Remover Imagem";
			this.mnuImagemRemover.Click += new System.EventHandler(this.mnuImagemRemover_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(220, 6);
			// 
			// mnuExcluir
			// 
			this.mnuExcluir.Image = global::CamadaUI.Properties.Resources.lixeira_24;
			this.mnuExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuExcluir.Name = "mnuExcluir";
			this.mnuExcluir.Size = new System.Drawing.Size(223, 36);
			this.mnuExcluir.Text = "Excluir Despesa";
			this.mnuExcluir.Click += new System.EventHandler(this.mnuExcluir_Click);
			// 
			// line1
			// 
			this.line1.EndPoint = new System.Drawing.Point(5, 42);
			this.line1.LineColor = System.Drawing.Color.Silver;
			this.line1.LineWidth = 3F;
			this.line1.Location = new System.Drawing.Point(407, 629);
			this.line1.Name = "line1";
			this.line1.Size = new System.Drawing.Size(10, 47);
			this.line1.StartPoint = new System.Drawing.Point(5, 5);
			this.line1.TabIndex = 10;
			// 
			// btnSetConta
			// 
			this.btnSetConta.AllowAnimations = true;
			this.btnSetConta.BackColor = System.Drawing.Color.Transparent;
			this.btnSetConta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetConta.Location = new System.Drawing.Point(427, 74);
			this.btnSetConta.Name = "btnSetConta";
			this.btnSetConta.RoundedCornersMask = ((byte)(15));
			this.btnSetConta.RoundedCornersRadius = 0;
			this.btnSetConta.Size = new System.Drawing.Size(34, 27);
			this.btnSetConta.TabIndex = 18;
			this.btnSetConta.TabStop = false;
			this.btnSetConta.Text = "n";
			this.btnSetConta.UseCompatibleTextRendering = true;
			this.btnSetConta.UseVisualStyleBackColor = false;
			this.btnSetConta.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetConta.Click += new System.EventHandler(this.btnSetCartao_Click);
			// 
			// txtCartaoDescricao
			// 
			this.txtCartaoDescricao.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCartaoDescricao.Location = new System.Drawing.Point(143, 74);
			this.txtCartaoDescricao.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCartaoDescricao.MaxLength = 30;
			this.txtCartaoDescricao.Name = "txtCartaoDescricao";
			this.txtCartaoDescricao.Size = new System.Drawing.Size(278, 27);
			this.txtCartaoDescricao.TabIndex = 17;
			this.txtCartaoDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			this.txtCartaoDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.BackColor = System.Drawing.Color.Transparent;
			this.label19.ForeColor = System.Drawing.Color.Black;
			this.label19.Location = new System.Drawing.Point(14, 76);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(123, 19);
			this.label19.TabIndex = 16;
			this.label19.Text = "Cartão de Crédito";
			// 
			// frmDespesaCartaoListagem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(1305, 686);
			this.Controls.Add(this.btnSetConta);
			this.Controls.Add(this.txtCartaoDescricao);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.line1);
			this.Controls.Add(this.btnExcluir);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblValorTotal);
			this.Controls.Add(this.Panel2);
			this.Controls.Add(this.dgvListagem);
			this.Controls.Add(this.btnFechar);
			this.Controls.Add(this.btnImprimirListagem);
			this.Controls.Add(this.btnAdicionar);
			this.Controls.Add(this.btnVisualizar);
			this.KeyPreview = true;
			this.Name = "frmDespesaCartaoListagem";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.Controls.SetChildIndex(this.btnVisualizar, 0);
			this.Controls.SetChildIndex(this.btnAdicionar, 0);
			this.Controls.SetChildIndex(this.btnImprimirListagem, 0);
			this.Controls.SetChildIndex(this.btnFechar, 0);
			this.Controls.SetChildIndex(this.dgvListagem, 0);
			this.Controls.SetChildIndex(this.Panel2, 0);
			this.Controls.SetChildIndex(this.lblValorTotal, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.btnExcluir, 0);
			this.Controls.SetChildIndex(this.line1, 0);
			this.Controls.SetChildIndex(this.label19, 0);
			this.Controls.SetChildIndex(this.txtCartaoDescricao, 0);
			this.Controls.SetChildIndex(this.btnSetConta, 0);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).EndInit();
			this.pnlPorMes.ResumeLayout(false);
			this.pnlPorPeriodo.ResumeLayout(false);
			this.Panel2.ResumeLayout(false);
			this.mnuOperacoes.ResumeLayout(false);
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
		internal System.Windows.Forms.Button btnImprimirListagem;
		internal System.Windows.Forms.Panel pnlPorMes;
		internal VIBlend.WinForms.Controls.vArrowButton btnPeriodoPosterior;
		internal VIBlend.WinForms.Controls.vButton btnMesAtual;
		internal VIBlend.WinForms.Controls.vArrowButton btnPeriodoAnterior;
		internal System.Windows.Forms.Label lblPeriodo;
		internal System.Windows.Forms.RadioButton rbtPorAno;
		internal System.Windows.Forms.RadioButton rbtPorPeriodo;
		internal System.Windows.Forms.RadioButton rbtTodas;
		internal System.Windows.Forms.Panel pnlPorPeriodo;
		internal System.Windows.Forms.Label lblDtFinal;
		internal System.Windows.Forms.Label lblDtInicial;
		internal VIBlend.WinForms.Controls.vButton btnDtFinal;
		internal VIBlend.WinForms.Controls.vButton btnDtInicial;
		internal System.Windows.Forms.Panel Panel2;
		internal System.Windows.Forms.Button btnExcluir;
		private System.Windows.Forms.ContextMenuStrip mnuOperacoes;
		private System.Windows.Forms.ToolStripMenuItem mnuVisualizar;
		private System.Windows.Forms.ToolStripMenuItem mnuImagem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem mnuExcluir;
		private System.Windows.Forms.ToolStripMenuItem mnuImagemInserir;
		private System.Windows.Forms.ToolStripMenuItem mnuImagemVisualizar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem mnuImagemRemover;
		private AwesomeShapeControl.Line line1;
		internal VIBlend.WinForms.Controls.vButton btnSetConta;
		internal System.Windows.Forms.TextBox txtCartaoDescricao;
		internal System.Windows.Forms.Label label19;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnID;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnData;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnSetor;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnDespesaDescricao;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnCredor;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnSituacao;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValor;
	}
}
