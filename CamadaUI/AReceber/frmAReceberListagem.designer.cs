namespace CamadaUI.AReceber
{
	partial class frmAReceberListagem
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
			this.dgvListagem = new System.Windows.Forms.DataGridView();
			this.clnCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.clnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnCompensacaoData = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnEntradaForma = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnConta = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnSituacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValorBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValorLiquido = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValorRecebido = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.lblValorRecebido = new System.Windows.Forms.Label();
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
			this.lblValorBruto = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.pnlSituacao = new System.Windows.Forms.Panel();
			this.rbtSitTodas = new System.Windows.Forms.RadioButton();
			this.rbtCanceladas = new System.Windows.Forms.RadioButton();
			this.rbtRecebidos = new System.Windows.Forms.RadioButton();
			this.rbtEmAberto = new System.Windows.Forms.RadioButton();
			this.btnReceber = new System.Windows.Forms.Button();
			this.mnuOperacoes = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuItemReceber = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuItemEstornar = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuItemCancelar = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuItemNormalizar = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuItemVerOrigem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuItemAlterar = new System.Windows.Forms.ToolStripMenuItem();
			this.lblValorLiquido = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnSetConta = new VIBlend.WinForms.Controls.vButton();
			this.txtConta = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.lblBrutoSelected = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lblPrevisto = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.btnReceberLote = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).BeginInit();
			this.pnlPorMes.SuspendLayout();
			this.pnlPorPeriodo.SuspendLayout();
			this.Panel2.SuspendLayout();
			this.pnlSituacao.SuspendLayout();
			this.mnuOperacoes.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(762, 0);
			this.lblTitulo.Size = new System.Drawing.Size(326, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Procurar | Quitar - A Receber";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(1088, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(1128, 50);
			// 
			// btnFechar
			// 
			this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.delete_16;
			this.btnFechar.Location = new System.Drawing.Point(971, 678);
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
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.OldLace;
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
			this.dgvListagem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvListagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
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
            this.clnCheck,
            this.clnID,
            this.clnCompensacaoData,
            this.clnEntradaForma,
            this.clnConta,
            this.clnSituacao,
            this.clnValorBruto,
            this.clnValorLiquido,
            this.clnValorRecebido});
			this.dgvListagem.EnableHeadersVisualStyles = false;
			this.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption;
			this.dgvListagem.Location = new System.Drawing.Point(22, 140);
			this.dgvListagem.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
			this.dgvListagem.MultiSelect = false;
			this.dgvListagem.Name = "dgvListagem";
			this.dgvListagem.RowHeadersVisible = false;
			this.dgvListagem.RowHeadersWidth = 45;
			this.dgvListagem.RowTemplate.Height = 30;
			this.dgvListagem.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvListagem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgvListagem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvListagem.Size = new System.Drawing.Size(1084, 478);
			this.dgvListagem.TabIndex = 5;
			this.dgvListagem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListagem_CellContentClick);
			this.dgvListagem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListagem_CellDoubleClick);
			this.dgvListagem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListagem_CellFormatting);
			this.dgvListagem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListagem_KeyDown);
			this.dgvListagem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvListagem_MouseDown);
			// 
			// clnCheck
			// 
			this.clnCheck.HeaderText = "";
			this.clnCheck.Name = "clnCheck";
			this.clnCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.clnCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.clnCheck.Width = 40;
			// 
			// clnID
			// 
			this.clnID.HeaderText = "Reg.";
			this.clnID.Name = "clnID";
			this.clnID.Width = 60;
			// 
			// clnCompensacaoData
			// 
			this.clnCompensacaoData.HeaderText = "Comp. Dt.";
			this.clnCompensacaoData.Name = "clnCompensacaoData";
			this.clnCompensacaoData.Width = 85;
			// 
			// clnEntradaForma
			// 
			this.clnEntradaForma.HeaderText = "Forma de Entrada";
			this.clnEntradaForma.Name = "clnEntradaForma";
			this.clnEntradaForma.Width = 150;
			// 
			// clnConta
			// 
			this.clnConta.HeaderText = "Conta Provisória";
			this.clnConta.Name = "clnConta";
			this.clnConta.Width = 300;
			// 
			// clnSituacao
			// 
			this.clnSituacao.HeaderText = "Situação";
			this.clnSituacao.Name = "clnSituacao";
			// 
			// clnValorBruto
			// 
			this.clnValorBruto.HeaderText = "Valor";
			this.clnValorBruto.Name = "clnValorBruto";
			// 
			// clnValorLiquido
			// 
			this.clnValorLiquido.HeaderText = "Vl.Liquido";
			this.clnValorLiquido.Name = "clnValorLiquido";
			// 
			// clnValorRecebido
			// 
			this.clnValorRecebido.HeaderText = "Vl.Recebido";
			this.clnValorRecebido.Name = "clnValorRecebido";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(1014, 621);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 15);
			this.label1.TabIndex = 8;
			this.label1.Text = "Valor Recebido:";
			// 
			// lblValorRecebido
			// 
			this.lblValorRecebido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValorRecebido.BackColor = System.Drawing.Color.LightGray;
			this.lblValorRecebido.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorRecebido.Location = new System.Drawing.Point(969, 638);
			this.lblValorRecebido.Name = "lblValorRecebido";
			this.lblValorRecebido.Size = new System.Drawing.Size(137, 32);
			this.lblValorRecebido.TabIndex = 9;
			this.lblValorRecebido.Text = "R$ 0,00";
			this.lblValorRecebido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnImprimir
			// 
			this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnImprimir.Image = global::CamadaUI.Properties.Resources.imprimir_24;
			this.btnImprimir.Location = new System.Drawing.Point(839, 678);
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
			this.Panel2.Location = new System.Drawing.Point(387, 67);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(674, 58);
			this.Panel2.TabIndex = 4;
			// 
			// lblValorBruto
			// 
			this.lblValorBruto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValorBruto.BackColor = System.Drawing.Color.LightGray;
			this.lblValorBruto.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorBruto.Location = new System.Drawing.Point(683, 638);
			this.lblValorBruto.Name = "lblValorBruto";
			this.lblValorBruto.Size = new System.Drawing.Size(137, 32);
			this.lblValorBruto.TabIndex = 9;
			this.lblValorBruto.Text = "R$ 0,00";
			this.lblValorBruto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.DimGray;
			this.label3.Location = new System.Drawing.Point(707, 621);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(113, 15);
			this.label3.TabIndex = 8;
			this.label3.Text = "Vl. Bruto a Receber:";
			// 
			// pnlSituacao
			// 
			this.pnlSituacao.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.pnlSituacao.Controls.Add(this.rbtSitTodas);
			this.pnlSituacao.Controls.Add(this.rbtCanceladas);
			this.pnlSituacao.Controls.Add(this.rbtRecebidos);
			this.pnlSituacao.Controls.Add(this.rbtEmAberto);
			this.pnlSituacao.Location = new System.Drawing.Point(22, 679);
			this.pnlSituacao.Name = "pnlSituacao";
			this.pnlSituacao.Size = new System.Drawing.Size(488, 41);
			this.pnlSituacao.TabIndex = 6;
			// 
			// rbtSitTodas
			// 
			this.rbtSitTodas.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtSitTodas.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rbtSitTodas.Location = new System.Drawing.Point(361, 3);
			this.rbtSitTodas.Name = "rbtSitTodas";
			this.rbtSitTodas.Size = new System.Drawing.Size(111, 34);
			this.rbtSitTodas.TabIndex = 0;
			this.rbtSitTodas.Tag = "6";
			this.rbtSitTodas.Text = "Todos";
			this.rbtSitTodas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtSitTodas.UseVisualStyleBackColor = true;
			// 
			// rbtCanceladas
			// 
			this.rbtCanceladas.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtCanceladas.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rbtCanceladas.Location = new System.Drawing.Point(244, 3);
			this.rbtCanceladas.Name = "rbtCanceladas";
			this.rbtCanceladas.Size = new System.Drawing.Size(111, 34);
			this.rbtCanceladas.TabIndex = 0;
			this.rbtCanceladas.Tag = "3";
			this.rbtCanceladas.Text = "Cancelados";
			this.rbtCanceladas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtCanceladas.UseVisualStyleBackColor = true;
			// 
			// rbtRecebidos
			// 
			this.rbtRecebidos.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtRecebidos.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rbtRecebidos.Location = new System.Drawing.Point(128, 3);
			this.rbtRecebidos.Name = "rbtRecebidos";
			this.rbtRecebidos.Size = new System.Drawing.Size(111, 34);
			this.rbtRecebidos.TabIndex = 0;
			this.rbtRecebidos.Tag = "2";
			this.rbtRecebidos.Text = "Recebidos";
			this.rbtRecebidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtRecebidos.UseVisualStyleBackColor = true;
			// 
			// rbtEmAberto
			// 
			this.rbtEmAberto.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtEmAberto.Checked = true;
			this.rbtEmAberto.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rbtEmAberto.Location = new System.Drawing.Point(12, 3);
			this.rbtEmAberto.Name = "rbtEmAberto";
			this.rbtEmAberto.Size = new System.Drawing.Size(111, 34);
			this.rbtEmAberto.TabIndex = 0;
			this.rbtEmAberto.TabStop = true;
			this.rbtEmAberto.Tag = "1";
			this.rbtEmAberto.Text = "Em Aberto";
			this.rbtEmAberto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtEmAberto.UseVisualStyleBackColor = true;
			// 
			// btnReceber
			// 
			this.btnReceber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReceber.Image = global::CamadaUI.Properties.Resources.money_green_24;
			this.btnReceber.Location = new System.Drawing.Point(681, 678);
			this.btnReceber.Name = "btnReceber";
			this.btnReceber.Size = new System.Drawing.Size(152, 42);
			this.btnReceber.TabIndex = 8;
			this.btnReceber.Text = "&Receber";
			this.btnReceber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnReceber.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnReceber.UseVisualStyleBackColor = true;
			this.btnReceber.Click += new System.EventHandler(this.btnReceber_Click);
			// 
			// mnuOperacoes
			// 
			this.mnuOperacoes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuOperacoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemReceber,
            this.mnuItemEstornar,
            this.toolStripSeparator2,
            this.mnuItemCancelar,
            this.mnuItemNormalizar,
            this.toolStripSeparator1,
            this.mnuItemVerOrigem,
            this.mnuItemAlterar});
			this.mnuOperacoes.Name = "mnuOperacoes";
			this.mnuOperacoes.Size = new System.Drawing.Size(234, 172);
			// 
			// mnuItemReceber
			// 
			this.mnuItemReceber.Image = global::CamadaUI.Properties.Resources.money_green_24;
			this.mnuItemReceber.Name = "mnuItemReceber";
			this.mnuItemReceber.Size = new System.Drawing.Size(233, 26);
			this.mnuItemReceber.Text = "Receber";
			this.mnuItemReceber.Click += new System.EventHandler(this.mnuItemQuitar_Click);
			// 
			// mnuItemEstornar
			// 
			this.mnuItemEstornar.Image = global::CamadaUI.Properties.Resources.refresh_16;
			this.mnuItemEstornar.Name = "mnuItemEstornar";
			this.mnuItemEstornar.Size = new System.Drawing.Size(233, 26);
			this.mnuItemEstornar.Text = "Estornar Recebimento";
			this.mnuItemEstornar.Click += new System.EventHandler(this.mnuItemEstornar_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(230, 6);
			// 
			// mnuItemCancelar
			// 
			this.mnuItemCancelar.Image = global::CamadaUI.Properties.Resources.delete_16;
			this.mnuItemCancelar.Name = "mnuItemCancelar";
			this.mnuItemCancelar.Size = new System.Drawing.Size(233, 26);
			this.mnuItemCancelar.Text = "Cancelar";
			this.mnuItemCancelar.Click += new System.EventHandler(this.mnuItemCancelar_Click);
			// 
			// mnuItemNormalizar
			// 
			this.mnuItemNormalizar.Image = global::CamadaUI.Properties.Resources.accept_24;
			this.mnuItemNormalizar.Name = "mnuItemNormalizar";
			this.mnuItemNormalizar.Size = new System.Drawing.Size(233, 26);
			this.mnuItemNormalizar.Text = "Normalizar";
			this.mnuItemNormalizar.Click += new System.EventHandler(this.mnuItemNormalizar_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(230, 6);
			// 
			// mnuItemVerOrigem
			// 
			this.mnuItemVerOrigem.Image = global::CamadaUI.Properties.Resources.search_page_24;
			this.mnuItemVerOrigem.Name = "mnuItemVerOrigem";
			this.mnuItemVerOrigem.Size = new System.Drawing.Size(233, 26);
			this.mnuItemVerOrigem.Text = "Ver Origem";
			this.mnuItemVerOrigem.Click += new System.EventHandler(this.mnuItemVerOrigem_Click);
			// 
			// mnuItemAlterar
			// 
			this.mnuItemAlterar.Image = global::CamadaUI.Properties.Resources.refresh_24;
			this.mnuItemAlterar.Name = "mnuItemAlterar";
			this.mnuItemAlterar.Size = new System.Drawing.Size(233, 26);
			this.mnuItemAlterar.Text = "Alterar";
			this.mnuItemAlterar.Click += new System.EventHandler(this.mnuItemAlterar_Click);
			// 
			// lblValorLiquido
			// 
			this.lblValorLiquido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValorLiquido.BackColor = System.Drawing.Color.LightGray;
			this.lblValorLiquido.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorLiquido.Location = new System.Drawing.Point(826, 638);
			this.lblValorLiquido.Name = "lblValorLiquido";
			this.lblValorLiquido.Size = new System.Drawing.Size(137, 32);
			this.lblValorLiquido.TabIndex = 9;
			this.lblValorLiquido.Text = "R$ 0,00";
			this.lblValorLiquido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.DimGray;
			this.label4.Location = new System.Drawing.Point(840, 621);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(123, 15);
			this.label4.TabIndex = 8;
			this.label4.Text = "Vl. Líquido a Receber:";
			// 
			// btnSetConta
			// 
			this.btnSetConta.AllowAnimations = true;
			this.btnSetConta.BackColor = System.Drawing.Color.Transparent;
			this.btnSetConta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetConta.Location = new System.Drawing.Point(296, 87);
			this.btnSetConta.Name = "btnSetConta";
			this.btnSetConta.RoundedCornersMask = ((byte)(15));
			this.btnSetConta.RoundedCornersRadius = 0;
			this.btnSetConta.Size = new System.Drawing.Size(34, 27);
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
			this.txtConta.Location = new System.Drawing.Point(22, 87);
			this.txtConta.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtConta.MaxLength = 30;
			this.txtConta.Name = "txtConta";
			this.txtConta.Size = new System.Drawing.Size(268, 27);
			this.txtConta.TabIndex = 2;
			this.txtConta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.BackColor = System.Drawing.Color.Transparent;
			this.label19.ForeColor = System.Drawing.Color.Black;
			this.label19.Location = new System.Drawing.Point(18, 63);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(152, 19);
			this.label19.TabIndex = 1;
			this.label19.Text = "Filtar Conta Provisória";
			// 
			// lblBrutoSelected
			// 
			this.lblBrutoSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblBrutoSelected.BackColor = System.Drawing.Color.LightGray;
			this.lblBrutoSelected.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBrutoSelected.Location = new System.Drawing.Point(30, 638);
			this.lblBrutoSelected.Name = "lblBrutoSelected";
			this.lblBrutoSelected.Size = new System.Drawing.Size(137, 32);
			this.lblBrutoSelected.TabIndex = 9;
			this.lblBrutoSelected.Text = "R$ 0,00";
			this.lblBrutoSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.DimGray;
			this.label5.Location = new System.Drawing.Point(40, 621);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(127, 15);
			this.label5.TabIndex = 8;
			this.label5.Text = "Vl. Bruto Selecionado:";
			// 
			// lblPrevisto
			// 
			this.lblPrevisto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPrevisto.BackColor = System.Drawing.Color.LightGray;
			this.lblPrevisto.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPrevisto.Location = new System.Drawing.Point(173, 638);
			this.lblPrevisto.Name = "lblPrevisto";
			this.lblPrevisto.Size = new System.Drawing.Size(137, 32);
			this.lblPrevisto.TabIndex = 9;
			this.lblPrevisto.Text = "R$ 0,00";
			this.lblPrevisto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.DimGray;
			this.label7.Location = new System.Drawing.Point(223, 621);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(87, 15);
			this.label7.TabIndex = 8;
			this.label7.Text = "Valor Previsto:";
			// 
			// btnReceberLote
			// 
			this.btnReceberLote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReceberLote.ForeColor = System.Drawing.Color.Maroon;
			this.btnReceberLote.Image = global::CamadaUI.Properties.Resources.money_green_24;
			this.btnReceberLote.Location = new System.Drawing.Point(326, 629);
			this.btnReceberLote.Name = "btnReceberLote";
			this.btnReceberLote.Size = new System.Drawing.Size(168, 42);
			this.btnReceberLote.TabIndex = 8;
			this.btnReceberLote.Text = "&Receber Lote";
			this.btnReceberLote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnReceberLote.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnReceberLote.UseVisualStyleBackColor = true;
			this.btnReceberLote.Visible = false;
			this.btnReceberLote.Click += new System.EventHandler(this.btnReceberLote_Click);
			// 
			// frmAReceberListagem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(1128, 728);
			this.Controls.Add(this.btnSetConta);
			this.Controls.Add(this.txtConta);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.pnlSituacao);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblValorLiquido);
			this.Controls.Add(this.lblPrevisto);
			this.Controls.Add(this.lblBrutoSelected);
			this.Controls.Add(this.lblValorBruto);
			this.Controls.Add(this.lblValorRecebido);
			this.Controls.Add(this.Panel2);
			this.Controls.Add(this.dgvListagem);
			this.Controls.Add(this.btnFechar);
			this.Controls.Add(this.btnImprimir);
			this.Controls.Add(this.btnReceberLote);
			this.Controls.Add(this.btnReceber);
			this.KeyPreview = true;
			this.Name = "frmAReceberListagem";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.btnReceber, 0);
			this.Controls.SetChildIndex(this.btnReceberLote, 0);
			this.Controls.SetChildIndex(this.btnImprimir, 0);
			this.Controls.SetChildIndex(this.btnFechar, 0);
			this.Controls.SetChildIndex(this.dgvListagem, 0);
			this.Controls.SetChildIndex(this.Panel2, 0);
			this.Controls.SetChildIndex(this.lblValorRecebido, 0);
			this.Controls.SetChildIndex(this.lblValorBruto, 0);
			this.Controls.SetChildIndex(this.lblBrutoSelected, 0);
			this.Controls.SetChildIndex(this.lblPrevisto, 0);
			this.Controls.SetChildIndex(this.lblValorLiquido, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.label7, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.pnlSituacao, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.label19, 0);
			this.Controls.SetChildIndex(this.txtConta, 0);
			this.Controls.SetChildIndex(this.btnSetConta, 0);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).EndInit();
			this.pnlPorMes.ResumeLayout(false);
			this.pnlPorPeriodo.ResumeLayout(false);
			this.Panel2.ResumeLayout(false);
			this.pnlSituacao.ResumeLayout(false);
			this.mnuOperacoes.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button btnFechar;
		internal System.Windows.Forms.DataGridView dgvListagem;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Label lblValorRecebido;
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
		internal System.Windows.Forms.Label lblValorBruto;
		internal System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel pnlSituacao;
		private System.Windows.Forms.RadioButton rbtRecebidos;
		private System.Windows.Forms.RadioButton rbtEmAberto;
		private System.Windows.Forms.RadioButton rbtCanceladas;
		private System.Windows.Forms.RadioButton rbtSitTodas;
		internal System.Windows.Forms.Button btnReceber;
		private System.Windows.Forms.ContextMenuStrip mnuOperacoes;
		private System.Windows.Forms.ToolStripMenuItem mnuItemReceber;
		private System.Windows.Forms.ToolStripMenuItem mnuItemCancelar;
		private System.Windows.Forms.ToolStripMenuItem mnuItemNormalizar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem mnuItemVerOrigem;
		private System.Windows.Forms.ToolStripMenuItem mnuItemAlterar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem mnuItemEstornar;
		internal System.Windows.Forms.Label lblValorLiquido;
		internal System.Windows.Forms.Label label4;
		internal VIBlend.WinForms.Controls.vButton btnSetConta;
		internal System.Windows.Forms.TextBox txtConta;
		internal System.Windows.Forms.Label label19;
		private System.Windows.Forms.DataGridViewCheckBoxColumn clnCheck;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnID;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnCompensacaoData;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnEntradaForma;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnConta;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnSituacao;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValorBruto;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValorLiquido;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValorRecebido;
		internal System.Windows.Forms.Label lblBrutoSelected;
		internal System.Windows.Forms.Label label5;
		internal System.Windows.Forms.Label lblPrevisto;
		internal System.Windows.Forms.Label label7;
		internal System.Windows.Forms.Button btnReceberLote;
	}
}
