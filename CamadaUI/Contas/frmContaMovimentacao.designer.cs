namespace CamadaUI.Contas
{
	partial class frmContaMovimentacao
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
			this.btnFechar = new System.Windows.Forms.Button();
			this.dgvListagem = new System.Windows.Forms.DataGridView();
			this.clnMovData = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnMovTipoDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnDescricaoOrigem = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnIDOrigem = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnConta = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnIDCaixa = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValorReal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.lblValorTransferido = new System.Windows.Forms.Label();
			this.btnImprimir = new System.Windows.Forms.Button();
			this.pnlPorMes = new System.Windows.Forms.Panel();
			this.btnPeriodoPosterior = new VIBlend.WinForms.Controls.vArrowButton();
			this.btnMesAtual = new VIBlend.WinForms.Controls.vButton();
			this.btnPeriodoAnterior = new VIBlend.WinForms.Controls.vArrowButton();
			this.lblPeriodo = new System.Windows.Forms.Label();
			this.rbtPorMes = new System.Windows.Forms.RadioButton();
			this.rbtPorPeriodo = new System.Windows.Forms.RadioButton();
			this.rbtTodas = new System.Windows.Forms.RadioButton();
			this.pnlPorPeriodo = new System.Windows.Forms.Panel();
			this.lblDtFinal = new System.Windows.Forms.Label();
			this.lblDtInicial = new System.Windows.Forms.Label();
			this.btnDtFinal = new VIBlend.WinForms.Controls.vButton();
			this.btnDtInicial = new VIBlend.WinForms.Controls.vButton();
			this.Panel2 = new System.Windows.Forms.Panel();
			this.lblValorEntradas = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.mnuOperacoes = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuItemVerOrigem = new System.Windows.Forms.ToolStripMenuItem();
			this.verCaixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuImagem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuImagemInserir = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuImagemVisualizar = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuImagemRemover = new System.Windows.Forms.ToolStripMenuItem();
			this.lblValorSaidas = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnSetConta = new VIBlend.WinForms.Controls.vButton();
			this.txtConta = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.lblValorProvisorias = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lblValorNaoRealizadas = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
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
			this.lblTitulo.Location = new System.Drawing.Point(917, 0);
			this.lblTitulo.Size = new System.Drawing.Size(288, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Movimentação de Contas";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(1205, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(1245, 50);
			// 
			// btnFechar
			// 
			this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.delete_16;
			this.btnFechar.Location = new System.Drawing.Point(1088, 632);
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Size = new System.Drawing.Size(135, 42);
			this.btnFechar.TabIndex = 10;
			this.btnFechar.Text = "&Fechar";
			this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnFechar.UseVisualStyleBackColor = true;
			this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// dgvListagem
			// 
			this.dgvListagem.AllowUserToAddRows = false;
			this.dgvListagem.AllowUserToDeleteRows = false;
			this.dgvListagem.AllowUserToResizeColumns = false;
			this.dgvListagem.AllowUserToResizeRows = false;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvListagem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvListagem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvListagem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvListagem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dgvListagem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvListagem.ColumnHeadersHeight = 33;
			this.dgvListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvListagem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnMovData,
            this.clnMovTipoDescricao,
            this.clnDescricaoOrigem,
            this.clnIDOrigem,
            this.clnConta,
            this.clnSetor,
            this.clnIDCaixa,
            this.clnValorReal});
			this.dgvListagem.EnableHeadersVisualStyles = false;
			this.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption;
			this.dgvListagem.Location = new System.Drawing.Point(22, 128);
			this.dgvListagem.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
			this.dgvListagem.MultiSelect = false;
			this.dgvListagem.Name = "dgvListagem";
			this.dgvListagem.RowHeadersVisible = false;
			this.dgvListagem.RowHeadersWidth = 45;
			this.dgvListagem.RowTemplate.Height = 30;
			this.dgvListagem.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvListagem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgvListagem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvListagem.Size = new System.Drawing.Size(1201, 494);
			this.dgvListagem.TabIndex = 5;
			this.dgvListagem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListagem_CellDoubleClick);
			this.dgvListagem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListagem_CellFormatting);
			this.dgvListagem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListagem_KeyDown);
			this.dgvListagem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvListagem_MouseDown);
			// 
			// clnMovData
			// 
			this.clnMovData.HeaderText = "Data";
			this.clnMovData.Name = "clnMovData";
			// 
			// clnMovTipoDescricao
			// 
			this.clnMovTipoDescricao.HeaderText = "Tipo";
			this.clnMovTipoDescricao.Name = "clnMovTipoDescricao";
			this.clnMovTipoDescricao.Width = 120;
			// 
			// clnDescricaoOrigem
			// 
			this.clnDescricaoOrigem.HeaderText = "Origem";
			this.clnDescricaoOrigem.Name = "clnDescricaoOrigem";
			this.clnDescricaoOrigem.Width = 230;
			// 
			// clnIDOrigem
			// 
			this.clnIDOrigem.HeaderText = "Reg.";
			this.clnIDOrigem.Name = "clnIDOrigem";
			this.clnIDOrigem.Width = 80;
			// 
			// clnConta
			// 
			this.clnConta.HeaderText = "Conta";
			this.clnConta.Name = "clnConta";
			this.clnConta.Width = 200;
			// 
			// clnSetor
			// 
			this.clnSetor.HeaderText = "Setor";
			this.clnSetor.Name = "clnSetor";
			this.clnSetor.Width = 200;
			// 
			// clnIDCaixa
			// 
			this.clnIDCaixa.HeaderText = "Caixa";
			this.clnIDCaixa.Name = "clnIDCaixa";
			// 
			// clnValorReal
			// 
			this.clnValorReal.HeaderText = "Valor";
			this.clnValorReal.Name = "clnValorReal";
			this.clnValorReal.Width = 120;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(639, 628);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 15);
			this.label1.TabIndex = 8;
			this.label1.Text = "Vl. Transferido:";
			// 
			// lblValorTransferido
			// 
			this.lblValorTransferido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValorTransferido.BackColor = System.Drawing.Color.LightGray;
			this.lblValorTransferido.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorTransferido.ForeColor = System.Drawing.Color.DarkGreen;
			this.lblValorTransferido.Location = new System.Drawing.Point(594, 645);
			this.lblValorTransferido.Name = "lblValorTransferido";
			this.lblValorTransferido.Size = new System.Drawing.Size(137, 32);
			this.lblValorTransferido.TabIndex = 9;
			this.lblValorTransferido.Text = "R$ 0,00";
			this.lblValorTransferido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnImprimir
			// 
			this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnImprimir.Image = global::CamadaUI.Properties.Resources.imprimir_24;
			this.btnImprimir.Location = new System.Drawing.Point(956, 632);
			this.btnImprimir.Name = "btnImprimir";
			this.btnImprimir.Size = new System.Drawing.Size(126, 42);
			this.btnImprimir.TabIndex = 9;
			this.btnImprimir.Text = "&Imprimir";
			this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnImprimir.UseVisualStyleBackColor = true;
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
			this.pnlPorMes.Tag = "";
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
			this.btnPeriodoPosterior.TabIndex = 4;
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
			this.lblPeriodo.Tag = "Clique aqui duas vezes para escolher o Ano e o Mês";
			this.lblPeriodo.Text = "Novembro | 2017";
			this.lblPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblPeriodo.DoubleClick += new System.EventHandler(this.lblPeriodo_DoubleClick);
			this.lblPeriodo.MouseHover += new System.EventHandler(this.lblPeriodo_MouseHover);
			// 
			// rbtPorMes
			// 
			this.rbtPorMes.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtPorMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
			this.rbtPorMes.Checked = true;
			this.rbtPorMes.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
			this.rbtPorMes.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue;
			this.rbtPorMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rbtPorMes.Location = new System.Drawing.Point(16, 10);
			this.rbtPorMes.Name = "rbtPorMes";
			this.rbtPorMes.Size = new System.Drawing.Size(102, 38);
			this.rbtPorMes.TabIndex = 0;
			this.rbtPorMes.TabStop = true;
			this.rbtPorMes.Text = "Por Mês";
			this.rbtPorMes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtPorMes.UseVisualStyleBackColor = false;
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
			this.rbtTodas.Text = "Todos";
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
			this.Panel2.Controls.Add(this.rbtPorMes);
			this.Panel2.Controls.Add(this.pnlPorPeriodo);
			this.Panel2.Controls.Add(this.pnlPorMes);
			this.Panel2.Location = new System.Drawing.Point(549, 60);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(674, 58);
			this.Panel2.TabIndex = 4;
			// 
			// lblValorEntradas
			// 
			this.lblValorEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValorEntradas.BackColor = System.Drawing.Color.LightGray;
			this.lblValorEntradas.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorEntradas.ForeColor = System.Drawing.Color.DarkBlue;
			this.lblValorEntradas.Location = new System.Drawing.Point(308, 645);
			this.lblValorEntradas.Name = "lblValorEntradas";
			this.lblValorEntradas.Size = new System.Drawing.Size(137, 32);
			this.lblValorEntradas.TabIndex = 9;
			this.lblValorEntradas.Text = "R$ 0,00";
			this.lblValorEntradas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.DimGray;
			this.label3.Location = new System.Drawing.Point(369, 628);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(76, 15);
			this.label3.TabIndex = 8;
			this.label3.Text = "Vl. Entradas:";
			// 
			// mnuOperacoes
			// 
			this.mnuOperacoes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuOperacoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemVerOrigem,
            this.verCaixaToolStripMenuItem,
            this.mnuImagem});
			this.mnuOperacoes.Name = "mnuOperacoes";
			this.mnuOperacoes.Size = new System.Drawing.Size(161, 82);
			// 
			// mnuItemVerOrigem
			// 
			this.mnuItemVerOrigem.Image = global::CamadaUI.Properties.Resources.search_page_24;
			this.mnuItemVerOrigem.Name = "mnuItemVerOrigem";
			this.mnuItemVerOrigem.Size = new System.Drawing.Size(160, 26);
			this.mnuItemVerOrigem.Text = "Ver Origem";
			this.mnuItemVerOrigem.Click += new System.EventHandler(this.mnuItemVerOrigem_Click);
			// 
			// verCaixaToolStripMenuItem
			// 
			this.verCaixaToolStripMenuItem.Image = global::CamadaUI.Properties.Resources.search_page_24;
			this.verCaixaToolStripMenuItem.Name = "verCaixaToolStripMenuItem";
			this.verCaixaToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
			this.verCaixaToolStripMenuItem.Text = "Ver Caixa";
			// 
			// mnuImagem
			// 
			this.mnuImagem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImagemInserir,
            this.mnuImagemVisualizar,
            this.toolStripSeparator3,
            this.mnuImagemRemover});
			this.mnuImagem.Image = global::CamadaUI.Properties.Resources.ImagesFolder_30;
			this.mnuImagem.Name = "mnuImagem";
			this.mnuImagem.Size = new System.Drawing.Size(160, 26);
			this.mnuImagem.Text = "Imagem";
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
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(201, 6);
			// 
			// mnuImagemRemover
			// 
			this.mnuImagemRemover.Image = global::CamadaUI.Properties.Resources.delete_page_30;
			this.mnuImagemRemover.Name = "mnuImagemRemover";
			this.mnuImagemRemover.Size = new System.Drawing.Size(204, 26);
			this.mnuImagemRemover.Text = "Remover Imagem";
			// 
			// lblValorSaidas
			// 
			this.lblValorSaidas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValorSaidas.BackColor = System.Drawing.Color.LightGray;
			this.lblValorSaidas.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorSaidas.ForeColor = System.Drawing.Color.DarkRed;
			this.lblValorSaidas.Location = new System.Drawing.Point(451, 645);
			this.lblValorSaidas.Name = "lblValorSaidas";
			this.lblValorSaidas.Size = new System.Drawing.Size(137, 32);
			this.lblValorSaidas.TabIndex = 9;
			this.lblValorSaidas.Text = "R$ 0,00";
			this.lblValorSaidas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.DimGray;
			this.label4.Location = new System.Drawing.Point(525, 628);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 15);
			this.label4.TabIndex = 8;
			this.label4.Text = "Vl. Saídas:";
			// 
			// btnSetConta
			// 
			this.btnSetConta.AllowAnimations = true;
			this.btnSetConta.BackColor = System.Drawing.Color.Transparent;
			this.btnSetConta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetConta.Location = new System.Drawing.Point(358, 79);
			this.btnSetConta.Name = "btnSetConta";
			this.btnSetConta.RoundedCornersMask = ((byte)(15));
			this.btnSetConta.RoundedCornersRadius = 0;
			this.btnSetConta.Size = new System.Drawing.Size(34, 31);
			this.btnSetConta.TabIndex = 3;
			this.btnSetConta.TabStop = false;
			this.btnSetConta.Text = "...";
			this.btnSetConta.UseCompatibleTextRendering = true;
			this.btnSetConta.UseVisualStyleBackColor = false;
			this.btnSetConta.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetConta.Click += new System.EventHandler(this.btnSetConta_Click);
			// 
			// txtConta
			// 
			this.txtConta.BackColor = System.Drawing.Color.White;
			this.txtConta.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtConta.Location = new System.Drawing.Point(22, 79);
			this.txtConta.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtConta.MaxLength = 30;
			this.txtConta.Name = "txtConta";
			this.txtConta.Size = new System.Drawing.Size(330, 31);
			this.txtConta.TabIndex = 2;
			this.txtConta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.BackColor = System.Drawing.Color.Transparent;
			this.label19.ForeColor = System.Drawing.Color.Black;
			this.label19.Location = new System.Drawing.Point(18, 55);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(106, 19);
			this.label19.TabIndex = 1;
			this.label19.Text = "Escolher Conta";
			// 
			// lblValorProvisorias
			// 
			this.lblValorProvisorias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValorProvisorias.BackColor = System.Drawing.Color.LightGray;
			this.lblValorProvisorias.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorProvisorias.ForeColor = System.Drawing.Color.DimGray;
			this.lblValorProvisorias.Location = new System.Drawing.Point(22, 645);
			this.lblValorProvisorias.Name = "lblValorProvisorias";
			this.lblValorProvisorias.Size = new System.Drawing.Size(137, 32);
			this.lblValorProvisorias.TabIndex = 9;
			this.lblValorProvisorias.Text = "R$ 0,00";
			this.lblValorProvisorias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.DimGray;
			this.label5.Location = new System.Drawing.Point(65, 628);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(91, 15);
			this.label5.TabIndex = 8;
			this.label5.Text = "Vl. Provisórias:";
			// 
			// lblValorNaoRealizadas
			// 
			this.lblValorNaoRealizadas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValorNaoRealizadas.BackColor = System.Drawing.Color.LightGray;
			this.lblValorNaoRealizadas.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorNaoRealizadas.ForeColor = System.Drawing.Color.DimGray;
			this.lblValorNaoRealizadas.Location = new System.Drawing.Point(165, 645);
			this.lblValorNaoRealizadas.Name = "lblValorNaoRealizadas";
			this.lblValorNaoRealizadas.Size = new System.Drawing.Size(137, 32);
			this.lblValorNaoRealizadas.TabIndex = 9;
			this.lblValorNaoRealizadas.Text = "R$ 0,00";
			this.lblValorNaoRealizadas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.DimGray;
			this.label6.Location = new System.Drawing.Point(226, 628);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(73, 15);
			this.label6.TabIndex = 8;
			this.label6.Text = "Vl. Cheques:";
			// 
			// frmContaMovimentacao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(1245, 686);
			this.Controls.Add(this.btnFechar);
			this.Controls.Add(this.btnImprimir);
			this.Controls.Add(this.btnSetConta);
			this.Controls.Add(this.txtConta);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblValorSaidas);
			this.Controls.Add(this.lblValorNaoRealizadas);
			this.Controls.Add(this.lblValorProvisorias);
			this.Controls.Add(this.lblValorEntradas);
			this.Controls.Add(this.lblValorTransferido);
			this.Controls.Add(this.Panel2);
			this.Controls.Add(this.dgvListagem);
			this.KeyPreview = true;
			this.Name = "frmContaMovimentacao";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.dgvListagem, 0);
			this.Controls.SetChildIndex(this.Panel2, 0);
			this.Controls.SetChildIndex(this.lblValorTransferido, 0);
			this.Controls.SetChildIndex(this.lblValorEntradas, 0);
			this.Controls.SetChildIndex(this.lblValorProvisorias, 0);
			this.Controls.SetChildIndex(this.lblValorNaoRealizadas, 0);
			this.Controls.SetChildIndex(this.lblValorSaidas, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.label6, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.label19, 0);
			this.Controls.SetChildIndex(this.txtConta, 0);
			this.Controls.SetChildIndex(this.btnSetConta, 0);
			this.Controls.SetChildIndex(this.btnImprimir, 0);
			this.Controls.SetChildIndex(this.btnFechar, 0);
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
		internal System.Windows.Forms.DataGridView dgvListagem;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Label lblValorTransferido;
		internal System.Windows.Forms.Button btnImprimir;
		internal System.Windows.Forms.Panel pnlPorMes;
		internal VIBlend.WinForms.Controls.vArrowButton btnPeriodoPosterior;
		internal VIBlend.WinForms.Controls.vButton btnMesAtual;
		internal VIBlend.WinForms.Controls.vArrowButton btnPeriodoAnterior;
		internal System.Windows.Forms.Label lblPeriodo;
		internal System.Windows.Forms.RadioButton rbtPorMes;
		internal System.Windows.Forms.RadioButton rbtPorPeriodo;
		internal System.Windows.Forms.RadioButton rbtTodas;
		internal System.Windows.Forms.Panel pnlPorPeriodo;
		internal System.Windows.Forms.Label lblDtFinal;
		internal System.Windows.Forms.Label lblDtInicial;
		internal VIBlend.WinForms.Controls.vButton btnDtFinal;
		internal VIBlend.WinForms.Controls.vButton btnDtInicial;
		internal System.Windows.Forms.Panel Panel2;
		internal System.Windows.Forms.Label lblValorEntradas;
		internal System.Windows.Forms.Label label3;
		private System.Windows.Forms.ContextMenuStrip mnuOperacoes;
		private System.Windows.Forms.ToolStripMenuItem mnuItemVerOrigem;
		internal System.Windows.Forms.Label lblValorSaidas;
		internal System.Windows.Forms.Label label4;
		internal VIBlend.WinForms.Controls.vButton btnSetConta;
		internal System.Windows.Forms.TextBox txtConta;
		internal System.Windows.Forms.Label label19;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnMovData;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnMovTipoDescricao;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnDescricaoOrigem;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnIDOrigem;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnConta;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnSetor;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnIDCaixa;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValorReal;
		private System.Windows.Forms.ToolStripMenuItem verCaixaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuImagem;
		private System.Windows.Forms.ToolStripMenuItem mnuImagemInserir;
		private System.Windows.Forms.ToolStripMenuItem mnuImagemVisualizar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem mnuImagemRemover;
		internal System.Windows.Forms.Label lblValorProvisorias;
		internal System.Windows.Forms.Label label5;
		internal System.Windows.Forms.Label lblValorNaoRealizadas;
		internal System.Windows.Forms.Label label6;
	}
}
