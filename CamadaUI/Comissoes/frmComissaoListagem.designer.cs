namespace CamadaUI.Comissoes
{
	partial class frmComissaoListagem
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
			this.btnSetColaborador = new VIBlend.WinForms.Controls.vButton();
			this.txtColaborador = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.btnSetSetor = new VIBlend.WinForms.Controls.vButton();
			this.txtSetor = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.pnlSituacao = new System.Windows.Forms.Panel();
			this.rbtPagas = new System.Windows.Forms.RadioButton();
			this.rbtConcluidas = new System.Windows.Forms.RadioButton();
			this.rbtIniciadas = new System.Windows.Forms.RadioButton();
			this.dgvListagem = new System.Windows.Forms.DataGridView();
			this.clnCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.clnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnDataInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnDataFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnCredor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValorContribuicoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValorDescontado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValorComissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnEfetuar = new System.Windows.Forms.Button();
			this.mnuOperacoes = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuVisualizar = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuImprimirRecibo = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuExcluir = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.pnlPorMes.SuspendLayout();
			this.pnlPorPeriodo.SuspendLayout();
			this.Panel2.SuspendLayout();
			this.pnlSituacao.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).BeginInit();
			this.mnuOperacoes.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(842, 0);
			this.lblTitulo.Size = new System.Drawing.Size(340, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Listagem de Comissões";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(1182, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(1222, 50);
			// 
			// btnFechar
			// 
			this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.delete_16;
			this.btnFechar.Location = new System.Drawing.Point(1074, 632);
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Size = new System.Drawing.Size(135, 42);
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
			this.btnAdicionar.Location = new System.Drawing.Point(529, 632);
			this.btnAdicionar.Name = "btnAdicionar";
			this.btnAdicionar.Size = new System.Drawing.Size(126, 42);
			this.btnAdicionar.TabIndex = 11;
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
			this.btnVisualizar.Location = new System.Drawing.Point(397, 632);
			this.btnVisualizar.Name = "btnVisualizar";
			this.btnVisualizar.Size = new System.Drawing.Size(126, 42);
			this.btnVisualizar.TabIndex = 10;
			this.btnVisualizar.Text = "&Visualizar";
			this.btnVisualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnVisualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnVisualizar.UseVisualStyleBackColor = true;
			this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
			// 
			// btnImprimir
			// 
			this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnImprimir.Image = global::CamadaUI.Properties.Resources.imprimir_24;
			this.btnImprimir.Location = new System.Drawing.Point(661, 632);
			this.btnImprimir.Name = "btnImprimir";
			this.btnImprimir.Size = new System.Drawing.Size(126, 42);
			this.btnImprimir.TabIndex = 12;
			this.btnImprimir.Text = "&Imprimir";
			this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnImprimir.UseVisualStyleBackColor = true;
			this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
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
			this.lblPeriodo.Text = "Novembro | 2017";
			this.lblPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			this.Panel2.Controls.Add(this.rbtPorMes);
			this.Panel2.Controls.Add(this.pnlPorPeriodo);
			this.Panel2.Controls.Add(this.pnlPorMes);
			this.Panel2.Location = new System.Drawing.Point(535, 64);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(674, 58);
			this.Panel2.TabIndex = 7;
			// 
			// btnSetColaborador
			// 
			this.btnSetColaborador.AllowAnimations = true;
			this.btnSetColaborador.BackColor = System.Drawing.Color.Transparent;
			this.btnSetColaborador.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetColaborador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetColaborador.Location = new System.Drawing.Point(470, 61);
			this.btnSetColaborador.Name = "btnSetColaborador";
			this.btnSetColaborador.RoundedCornersMask = ((byte)(15));
			this.btnSetColaborador.RoundedCornersRadius = 0;
			this.btnSetColaborador.Size = new System.Drawing.Size(34, 27);
			this.btnSetColaborador.TabIndex = 3;
			this.btnSetColaborador.TabStop = false;
			this.btnSetColaborador.Text = "...";
			this.btnSetColaborador.UseCompatibleTextRendering = true;
			this.btnSetColaborador.UseVisualStyleBackColor = false;
			this.btnSetColaborador.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetColaborador.Click += new System.EventHandler(this.btnSetColaborador_Click);
			// 
			// txtColaborador
			// 
			this.txtColaborador.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtColaborador.Location = new System.Drawing.Point(106, 61);
			this.txtColaborador.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtColaborador.MaxLength = 30;
			this.txtColaborador.Name = "txtColaborador";
			this.txtColaborador.Size = new System.Drawing.Size(358, 27);
			this.txtColaborador.TabIndex = 2;
			this.txtColaborador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.BackColor = System.Drawing.Color.Transparent;
			this.label19.ForeColor = System.Drawing.Color.Black;
			this.label19.Location = new System.Drawing.Point(8, 64);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(92, 19);
			this.label19.TabIndex = 1;
			this.label19.Text = "Colaborador:";
			// 
			// btnSetSetor
			// 
			this.btnSetSetor.AllowAnimations = true;
			this.btnSetSetor.BackColor = System.Drawing.Color.Transparent;
			this.btnSetSetor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetSetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetSetor.Location = new System.Drawing.Point(470, 97);
			this.btnSetSetor.Name = "btnSetSetor";
			this.btnSetSetor.RoundedCornersMask = ((byte)(15));
			this.btnSetSetor.RoundedCornersRadius = 0;
			this.btnSetSetor.Size = new System.Drawing.Size(34, 27);
			this.btnSetSetor.TabIndex = 6;
			this.btnSetSetor.TabStop = false;
			this.btnSetSetor.Text = "...";
			this.btnSetSetor.UseCompatibleTextRendering = true;
			this.btnSetSetor.UseVisualStyleBackColor = false;
			this.btnSetSetor.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetSetor.Click += new System.EventHandler(this.btnSetSetor_Click);
			// 
			// txtSetor
			// 
			this.txtSetor.Location = new System.Drawing.Point(106, 97);
			this.txtSetor.MaxLength = 30;
			this.txtSetor.Name = "txtSetor";
			this.txtSetor.Size = new System.Drawing.Size(358, 27);
			this.txtSetor.TabIndex = 5;
			this.txtSetor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(54, 100);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 19);
			this.label2.TabIndex = 4;
			this.label2.Text = "Setor:";
			// 
			// pnlSituacao
			// 
			this.pnlSituacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlSituacao.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.pnlSituacao.Controls.Add(this.rbtPagas);
			this.pnlSituacao.Controls.Add(this.rbtConcluidas);
			this.pnlSituacao.Controls.Add(this.rbtIniciadas);
			this.pnlSituacao.Location = new System.Drawing.Point(12, 633);
			this.pnlSituacao.Name = "pnlSituacao";
			this.pnlSituacao.Size = new System.Drawing.Size(367, 41);
			this.pnlSituacao.TabIndex = 9;
			// 
			// rbtPagas
			// 
			this.rbtPagas.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtPagas.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rbtPagas.Location = new System.Drawing.Point(244, 3);
			this.rbtPagas.Name = "rbtPagas";
			this.rbtPagas.Size = new System.Drawing.Size(111, 34);
			this.rbtPagas.TabIndex = 2;
			this.rbtPagas.Tag = "3";
			this.rbtPagas.Text = "Pagas";
			this.rbtPagas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtPagas.UseVisualStyleBackColor = true;
			// 
			// rbtConcluidas
			// 
			this.rbtConcluidas.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtConcluidas.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rbtConcluidas.Location = new System.Drawing.Point(128, 3);
			this.rbtConcluidas.Name = "rbtConcluidas";
			this.rbtConcluidas.Size = new System.Drawing.Size(111, 34);
			this.rbtConcluidas.TabIndex = 1;
			this.rbtConcluidas.Tag = "2";
			this.rbtConcluidas.Text = "Concluídas";
			this.rbtConcluidas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtConcluidas.UseVisualStyleBackColor = true;
			// 
			// rbtIniciadas
			// 
			this.rbtIniciadas.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtIniciadas.Checked = true;
			this.rbtIniciadas.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rbtIniciadas.Location = new System.Drawing.Point(12, 3);
			this.rbtIniciadas.Name = "rbtIniciadas";
			this.rbtIniciadas.Size = new System.Drawing.Size(111, 34);
			this.rbtIniciadas.TabIndex = 0;
			this.rbtIniciadas.TabStop = true;
			this.rbtIniciadas.Tag = "1";
			this.rbtIniciadas.Text = "Iniciadas";
			this.rbtIniciadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtIniciadas.UseVisualStyleBackColor = true;
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
            this.clnCheck,
            this.clnID,
            this.clnDataInicial,
            this.clnDataFinal,
            this.clnSetor,
            this.clnCredor,
            this.clnValorContribuicoes,
            this.clnValorDescontado,
            this.clnValorComissao});
			this.dgvListagem.EnableHeadersVisualStyles = false;
			this.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption;
			this.dgvListagem.Location = new System.Drawing.Point(11, 137);
			this.dgvListagem.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
			this.dgvListagem.MultiSelect = false;
			this.dgvListagem.Name = "dgvListagem";
			this.dgvListagem.RowHeadersVisible = false;
			this.dgvListagem.RowHeadersWidth = 45;
			this.dgvListagem.RowTemplate.Height = 30;
			this.dgvListagem.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvListagem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgvListagem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvListagem.Size = new System.Drawing.Size(1199, 482);
			this.dgvListagem.TabIndex = 8;
			this.dgvListagem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListagem_CellContentClick);
			this.dgvListagem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListagem_CellValueChanged);
			this.dgvListagem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListagem_KeyDown);
			// 
			// clnCheck
			// 
			this.clnCheck.HeaderText = "";
			this.clnCheck.IndeterminateValue = "";
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
			// clnDataInicial
			// 
			this.clnDataInicial.HeaderText = "Dt Inicial";
			this.clnDataInicial.Name = "clnDataInicial";
			this.clnDataInicial.Width = 85;
			// 
			// clnDataFinal
			// 
			this.clnDataFinal.HeaderText = "Dt. Final";
			this.clnDataFinal.Name = "clnDataFinal";
			this.clnDataFinal.Width = 85;
			// 
			// clnSetor
			// 
			this.clnSetor.HeaderText = "Setor de Recursos";
			this.clnSetor.Name = "clnSetor";
			this.clnSetor.Width = 220;
			// 
			// clnCredor
			// 
			this.clnCredor.HeaderText = "Colaborador";
			this.clnCredor.Name = "clnCredor";
			this.clnCredor.Width = 300;
			// 
			// clnValorContribuicoes
			// 
			this.clnValorContribuicoes.HeaderText = "Contribuições";
			this.clnValorContribuicoes.Name = "clnValorContribuicoes";
			this.clnValorContribuicoes.Width = 120;
			// 
			// clnValorDescontado
			// 
			this.clnValorDescontado.HeaderText = "Descontos";
			this.clnValorDescontado.Name = "clnValorDescontado";
			this.clnValorDescontado.Width = 120;
			// 
			// clnValorComissao
			// 
			this.clnValorComissao.HeaderText = "Vl. Comissão";
			this.clnValorComissao.Name = "clnValorComissao";
			this.clnValorComissao.Width = 120;
			// 
			// btnEfetuar
			// 
			this.btnEfetuar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnEfetuar.Enabled = false;
			this.btnEfetuar.Image = global::CamadaUI.Properties.Resources.accept_24;
			this.btnEfetuar.Location = new System.Drawing.Point(816, 632);
			this.btnEfetuar.Name = "btnEfetuar";
			this.btnEfetuar.Size = new System.Drawing.Size(208, 42);
			this.btnEfetuar.TabIndex = 12;
			this.btnEfetuar.Text = "&Concluir Selecionadas";
			this.btnEfetuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnEfetuar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnEfetuar.UseVisualStyleBackColor = true;
			this.btnEfetuar.Click += new System.EventHandler(this.btnEfetuar_Click);
			// 
			// mnuOperacoes
			// 
			this.mnuOperacoes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuOperacoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVisualizar,
            this.mnuImprimirRecibo,
            this.toolStripSeparator2,
            this.mnuExcluir});
			this.mnuOperacoes.Name = "mnuOperacoes";
			this.mnuOperacoes.Size = new System.Drawing.Size(220, 110);
			// 
			// mnuVisualizar
			// 
			this.mnuVisualizar.Image = global::CamadaUI.Properties.Resources.search_page_24;
			this.mnuVisualizar.Name = "mnuVisualizar";
			this.mnuVisualizar.Size = new System.Drawing.Size(219, 26);
			this.mnuVisualizar.Text = "Visualizar Comissão";
			this.mnuVisualizar.Click += new System.EventHandler(this.mnuVisualizar_Click);
			// 
			// mnuImprimirRecibo
			// 
			this.mnuImprimirRecibo.Image = global::CamadaUI.Properties.Resources.print_24;
			this.mnuImprimirRecibo.Name = "mnuImprimirRecibo";
			this.mnuImprimirRecibo.Size = new System.Drawing.Size(219, 26);
			this.mnuImprimirRecibo.Text = "Imprimir Recibo";
			this.mnuImprimirRecibo.Click += new System.EventHandler(this.mnuImprimirRecibo_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(216, 6);
			// 
			// mnuExcluir
			// 
			this.mnuExcluir.Image = global::CamadaUI.Properties.Resources.lixeira_24;
			this.mnuExcluir.Name = "mnuExcluir";
			this.mnuExcluir.Size = new System.Drawing.Size(219, 26);
			this.mnuExcluir.Text = "Excluir Comissão";
			this.mnuExcluir.Click += new System.EventHandler(this.mnuExcluir_Click);
			// 
			// frmComissaoListagem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(1222, 686);
			this.Controls.Add(this.pnlSituacao);
			this.Controls.Add(this.btnSetSetor);
			this.Controls.Add(this.txtSetor);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnSetColaborador);
			this.Controls.Add(this.txtColaborador);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.Panel2);
			this.Controls.Add(this.dgvListagem);
			this.Controls.Add(this.btnFechar);
			this.Controls.Add(this.btnEfetuar);
			this.Controls.Add(this.btnImprimir);
			this.Controls.Add(this.btnAdicionar);
			this.Controls.Add(this.btnVisualizar);
			this.KeyPreview = true;
			this.Name = "frmComissaoListagem";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.btnVisualizar, 0);
			this.Controls.SetChildIndex(this.btnAdicionar, 0);
			this.Controls.SetChildIndex(this.btnImprimir, 0);
			this.Controls.SetChildIndex(this.btnEfetuar, 0);
			this.Controls.SetChildIndex(this.btnFechar, 0);
			this.Controls.SetChildIndex(this.dgvListagem, 0);
			this.Controls.SetChildIndex(this.Panel2, 0);
			this.Controls.SetChildIndex(this.label19, 0);
			this.Controls.SetChildIndex(this.txtColaborador, 0);
			this.Controls.SetChildIndex(this.btnSetColaborador, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.txtSetor, 0);
			this.Controls.SetChildIndex(this.btnSetSetor, 0);
			this.Controls.SetChildIndex(this.pnlSituacao, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.panel1.ResumeLayout(false);
			this.pnlPorMes.ResumeLayout(false);
			this.pnlPorPeriodo.ResumeLayout(false);
			this.Panel2.ResumeLayout(false);
			this.pnlSituacao.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).EndInit();
			this.mnuOperacoes.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button btnFechar;
		internal System.Windows.Forms.Button btnAdicionar;
		internal System.Windows.Forms.Button btnVisualizar;
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
		internal VIBlend.WinForms.Controls.vButton btnSetColaborador;
		internal System.Windows.Forms.TextBox txtColaborador;
		internal System.Windows.Forms.Label label19;
		internal VIBlend.WinForms.Controls.vButton btnSetSetor;
		internal System.Windows.Forms.TextBox txtSetor;
		internal System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel pnlSituacao;
		private System.Windows.Forms.RadioButton rbtPagas;
		private System.Windows.Forms.RadioButton rbtConcluidas;
		private System.Windows.Forms.RadioButton rbtIniciadas;
		internal System.Windows.Forms.DataGridView dgvListagem;
		internal System.Windows.Forms.Button btnEfetuar;
		private System.Windows.Forms.DataGridViewCheckBoxColumn clnCheck;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnID;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnDataInicial;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnDataFinal;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnSetor;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnCredor;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValorContribuicoes;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValorDescontado;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValorComissao;
		private System.Windows.Forms.ContextMenuStrip mnuOperacoes;
		private System.Windows.Forms.ToolStripMenuItem mnuVisualizar;
		private System.Windows.Forms.ToolStripMenuItem mnuImprimirRecibo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem mnuExcluir;
	}
}
