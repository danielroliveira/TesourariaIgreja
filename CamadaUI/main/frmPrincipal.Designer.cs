﻿namespace CamadaUI
{
	partial class frmPrincipal
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
			this.mnuPrincipal = new System.Windows.Forms.ToolStrip();
			this.btnSair = new System.Windows.Forms.ToolStripButton();
			this.btnCadastros = new System.Windows.Forms.ToolStripSplitButton();
			this.mnuContribuintes = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuCredores = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuCongregacoes = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSetoresCongregacao = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuReunioes = new System.Windows.Forms.ToolStripMenuItem();
			this.btnEntradas = new System.Windows.Forms.ToolStripSplitButton();
			this.mnuContribuicaoInserir = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuContribuicaoProcurar = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuCampanhas = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSaidas = new System.Windows.Forms.ToolStripSplitButton();
			this.mnuDespesaInserir = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDespesaProcurar = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuDespesaTipo = new System.Windows.Forms.ToolStripMenuItem();
			this.btnMovimentação = new System.Windows.Forms.ToolStripSplitButton();
			this.mnuFechamento = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuContas = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSetores = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuCartao = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuBanco = new System.Windows.Forms.ToolStripMenuItem();
			this.pnlTop = new System.Windows.Forms.Panel();
			this.lblTitulo = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnMinimizer = new System.Windows.Forms.Button();
			this.btnConfig = new System.Windows.Forms.Button();
			this.PainelInferior = new System.Windows.Forms.Panel();
			this.lblSetor = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lblConta = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.lblVersao = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.lblFilial = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.lblDataSis = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.lblHora = new System.Windows.Forms.Label();
			this.mnuDespesaGrupo = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuPrincipal.SuspendLayout();
			this.pnlTop.SuspendLayout();
			this.PainelInferior.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuPrincipal
			// 
			this.mnuPrincipal.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSair,
            this.btnCadastros,
            this.btnEntradas,
            this.btnSaidas,
            this.btnMovimentação});
			this.mnuPrincipal.Location = new System.Drawing.Point(0, 39);
			this.mnuPrincipal.Name = "mnuPrincipal";
			this.mnuPrincipal.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.mnuPrincipal.Size = new System.Drawing.Size(1110, 56);
			this.mnuPrincipal.TabIndex = 1;
			this.mnuPrincipal.Text = "Menu Principal";
			// 
			// btnSair
			// 
			this.btnSair.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnSair.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSair.Image = global::CamadaUI.Properties.Resources.sair_32;
			this.btnSair.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnSair.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSair.Margin = new System.Windows.Forms.Padding(5);
			this.btnSair.Name = "btnSair";
			this.btnSair.Padding = new System.Windows.Forms.Padding(5);
			this.btnSair.Size = new System.Drawing.Size(85, 46);
			this.btnSair.Text = "&Sair";
			this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSair.ToolTipText = "Sair do Aplicativo";
			this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
			// 
			// btnCadastros
			// 
			this.btnCadastros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuContribuintes,
            this.mnuCredores,
            this.toolStripSeparator1,
            this.mnuCongregacoes,
            this.mnuSetoresCongregacao,
            this.mnuReunioes});
			this.btnCadastros.Image = global::CamadaUI.Properties.Resources.adicionar_30;
			this.btnCadastros.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnCadastros.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCadastros.Margin = new System.Windows.Forms.Padding(5);
			this.btnCadastros.Name = "btnCadastros";
			this.btnCadastros.Size = new System.Drawing.Size(136, 46);
			this.btnCadastros.Text = "Cadastros";
			// 
			// mnuContribuintes
			// 
			this.mnuContribuintes.Font = new System.Drawing.Font("Calibri", 12F);
			this.mnuContribuintes.Image = global::CamadaUI.Properties.Resources.contribuinte_32;
			this.mnuContribuintes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuContribuintes.Name = "mnuContribuintes";
			this.mnuContribuintes.Size = new System.Drawing.Size(262, 38);
			this.mnuContribuintes.Text = "Contribuintes";
			// 
			// mnuCredores
			// 
			this.mnuCredores.Font = new System.Drawing.Font("Calibri", 12F);
			this.mnuCredores.Image = global::CamadaUI.Properties.Resources.credor_32;
			this.mnuCredores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuCredores.Name = "mnuCredores";
			this.mnuCredores.Size = new System.Drawing.Size(262, 38);
			this.mnuCredores.Text = "Credores";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(259, 6);
			// 
			// mnuCongregacoes
			// 
			this.mnuCongregacoes.Font = new System.Drawing.Font("Calibri", 12F);
			this.mnuCongregacoes.Image = global::CamadaUI.Properties.Resources.igreja_32;
			this.mnuCongregacoes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuCongregacoes.Name = "mnuCongregacoes";
			this.mnuCongregacoes.Size = new System.Drawing.Size(262, 38);
			this.mnuCongregacoes.Tag = "1";
			this.mnuCongregacoes.Text = "Congregações";
			// 
			// mnuSetoresCongregacao
			// 
			this.mnuSetoresCongregacao.Font = new System.Drawing.Font("Calibri", 12F);
			this.mnuSetoresCongregacao.Image = global::CamadaUI.Properties.Resources.add_24;
			this.mnuSetoresCongregacao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuSetoresCongregacao.Name = "mnuSetoresCongregacao";
			this.mnuSetoresCongregacao.Size = new System.Drawing.Size(262, 38);
			this.mnuSetoresCongregacao.Tag = "1";
			this.mnuSetoresCongregacao.Text = "Setores de Congregação";
			// 
			// mnuReunioes
			// 
			this.mnuReunioes.Font = new System.Drawing.Font("Calibri", 12F);
			this.mnuReunioes.Image = global::CamadaUI.Properties.Resources.add_24;
			this.mnuReunioes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuReunioes.Name = "mnuReunioes";
			this.mnuReunioes.Size = new System.Drawing.Size(262, 38);
			this.mnuReunioes.Text = "Reuniões de Congregação";
			// 
			// btnEntradas
			// 
			this.btnEntradas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuContribuicaoInserir,
            this.mnuContribuicaoProcurar,
            this.toolStripSeparator3,
            this.mnuCampanhas});
			this.btnEntradas.Image = global::CamadaUI.Properties.Resources.Entradas_32;
			this.btnEntradas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnEntradas.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEntradas.Margin = new System.Windows.Forms.Padding(5);
			this.btnEntradas.Name = "btnEntradas";
			this.btnEntradas.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.btnEntradas.Padding = new System.Windows.Forms.Padding(5);
			this.btnEntradas.Size = new System.Drawing.Size(138, 46);
			this.btnEntradas.Text = "Entradas";
			this.btnEntradas.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			this.btnEntradas.ButtonClick += new System.EventHandler(this.btnEntradas_ButtonClick);
			// 
			// mnuContribuicaoInserir
			// 
			this.mnuContribuicaoInserir.Font = new System.Drawing.Font("Calibri", 12F);
			this.mnuContribuicaoInserir.Image = global::CamadaUI.Properties.Resources.add_24;
			this.mnuContribuicaoInserir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuContribuicaoInserir.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.mnuContribuicaoInserir.Name = "mnuContribuicaoInserir";
			this.mnuContribuicaoInserir.Padding = new System.Windows.Forms.Padding(0);
			this.mnuContribuicaoInserir.Size = new System.Drawing.Size(240, 28);
			this.mnuContribuicaoInserir.Text = "Inserir Contribuição";
			// 
			// mnuContribuicaoProcurar
			// 
			this.mnuContribuicaoProcurar.Font = new System.Drawing.Font("Calibri", 12F);
			this.mnuContribuicaoProcurar.Image = global::CamadaUI.Properties.Resources.search_24;
			this.mnuContribuicaoProcurar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuContribuicaoProcurar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.mnuContribuicaoProcurar.Name = "mnuContribuicaoProcurar";
			this.mnuContribuicaoProcurar.Size = new System.Drawing.Size(240, 30);
			this.mnuContribuicaoProcurar.Text = "Procurar Contribuição";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(237, 6);
			// 
			// mnuCampanhas
			// 
			this.mnuCampanhas.Font = new System.Drawing.Font("Calibri", 12F);
			this.mnuCampanhas.Image = global::CamadaUI.Properties.Resources.money_green_24;
			this.mnuCampanhas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuCampanhas.Name = "mnuCampanhas";
			this.mnuCampanhas.Size = new System.Drawing.Size(240, 30);
			this.mnuCampanhas.Text = "Controle de Campanhas";
			// 
			// btnSaidas
			// 
			this.btnSaidas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDespesaInserir,
            this.mnuDespesaProcurar,
            this.toolStripSeparator4,
            this.mnuDespesaTipo,
            this.mnuDespesaGrupo});
			this.btnSaidas.Image = global::CamadaUI.Properties.Resources.Saidas;
			this.btnSaidas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnSaidas.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSaidas.Margin = new System.Windows.Forms.Padding(5);
			this.btnSaidas.Name = "btnSaidas";
			this.btnSaidas.Padding = new System.Windows.Forms.Padding(5);
			this.btnSaidas.Size = new System.Drawing.Size(120, 46);
			this.btnSaidas.Text = "Saídas";
			this.btnSaidas.Click += new System.EventHandler(this.btnSaidas_ButtonClick);
			// 
			// mnuDespesaInserir
			// 
			this.mnuDespesaInserir.Font = new System.Drawing.Font("Calibri", 12F);
			this.mnuDespesaInserir.Image = global::CamadaUI.Properties.Resources.add_24;
			this.mnuDespesaInserir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuDespesaInserir.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.mnuDespesaInserir.Name = "mnuDespesaInserir";
			this.mnuDespesaInserir.Size = new System.Drawing.Size(211, 30);
			this.mnuDespesaInserir.Text = "Inserir Despesa";
			// 
			// mnuDespesaProcurar
			// 
			this.mnuDespesaProcurar.Font = new System.Drawing.Font("Calibri", 12F);
			this.mnuDespesaProcurar.Image = global::CamadaUI.Properties.Resources.search_24;
			this.mnuDespesaProcurar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuDespesaProcurar.Name = "mnuDespesaProcurar";
			this.mnuDespesaProcurar.Size = new System.Drawing.Size(211, 30);
			this.mnuDespesaProcurar.Text = "Procurar Despesa";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(208, 6);
			// 
			// mnuDespesaTipo
			// 
			this.mnuDespesaTipo.Font = new System.Drawing.Font("Calibri", 12F);
			this.mnuDespesaTipo.Image = global::CamadaUI.Properties.Resources.search_24;
			this.mnuDespesaTipo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuDespesaTipo.Name = "mnuDespesaTipo";
			this.mnuDespesaTipo.Size = new System.Drawing.Size(211, 30);
			this.mnuDespesaTipo.Text = "Tipos de Despesa";
			// 
			// btnMovimentação
			// 
			this.btnMovimentação.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFechamento,
            this.toolStripSeparator2,
            this.mnuContas,
            this.mnuSetores,
            this.mnuCartao,
            this.mnuBanco});
			this.btnMovimentação.Image = global::CamadaUI.Properties.Resources.Caixa_32;
			this.btnMovimentação.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnMovimentação.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnMovimentação.Margin = new System.Windows.Forms.Padding(5);
			this.btnMovimentação.Name = "btnMovimentação";
			this.btnMovimentação.Size = new System.Drawing.Size(173, 46);
			this.btnMovimentação.Text = "Movimentação";
			// 
			// mnuFechamento
			// 
			this.mnuFechamento.Font = new System.Drawing.Font("Calibri", 12F);
			this.mnuFechamento.Image = global::CamadaUI.Properties.Resources.search_24;
			this.mnuFechamento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuFechamento.Name = "mnuFechamento";
			this.mnuFechamento.Size = new System.Drawing.Size(278, 30);
			this.mnuFechamento.Text = "Caixa Fechamento";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(275, 6);
			// 
			// mnuContas
			// 
			this.mnuContas.Font = new System.Drawing.Font("Calibri", 12F);
			this.mnuContas.Image = global::CamadaUI.Properties.Resources.search_24;
			this.mnuContas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuContas.Name = "mnuContas";
			this.mnuContas.Size = new System.Drawing.Size(278, 30);
			this.mnuContas.Tag = "1";
			this.mnuContas.Text = "Contas de Movimentação";
			// 
			// mnuSetores
			// 
			this.mnuSetores.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuSetores.Image = global::CamadaUI.Properties.Resources.search_24;
			this.mnuSetores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuSetores.Name = "mnuSetores";
			this.mnuSetores.Size = new System.Drawing.Size(278, 30);
			this.mnuSetores.Tag = "1";
			this.mnuSetores.Text = "Setores de Movimentação";
			// 
			// mnuCartao
			// 
			this.mnuCartao.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuCartao.Image = global::CamadaUI.Properties.Resources.search_24;
			this.mnuCartao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuCartao.Name = "mnuCartao";
			this.mnuCartao.Size = new System.Drawing.Size(278, 30);
			this.mnuCartao.Tag = "1";
			this.mnuCartao.Text = "Controle de Cartão de Crédito";
			// 
			// mnuBanco
			// 
			this.mnuBanco.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuBanco.Image = global::CamadaUI.Properties.Resources.search_24;
			this.mnuBanco.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuBanco.Name = "mnuBanco";
			this.mnuBanco.Size = new System.Drawing.Size(278, 30);
			this.mnuBanco.Tag = "1";
			this.mnuBanco.Text = "Controle de Banco";
			// 
			// pnlTop
			// 
			this.pnlTop.BackColor = System.Drawing.Color.SlateGray;
			this.pnlTop.Controls.Add(this.lblTitulo);
			this.pnlTop.Controls.Add(this.btnClose);
			this.pnlTop.Controls.Add(this.btnMinimizer);
			this.pnlTop.Controls.Add(this.btnConfig);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Size = new System.Drawing.Size(1110, 39);
			this.pnlTop.TabIndex = 0;
			// 
			// lblTitulo
			// 
			this.lblTitulo.AutoSize = true;
			this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblTitulo.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.lblTitulo.Location = new System.Drawing.Point(0, 0);
			this.lblTitulo.Margin = new System.Windows.Forms.Padding(0);
			this.lblTitulo.Name = "lblTitulo";
			this.lblTitulo.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
			this.lblTitulo.Size = new System.Drawing.Size(184, 32);
			this.lblTitulo.TabIndex = 12;
			this.lblTitulo.Text = "Tesouraria Igreja";
			this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.BackColor = System.Drawing.Color.Transparent;
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Image = global::CamadaUI.Properties.Resources.CloseIcon;
			this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnClose.Location = new System.Drawing.Point(1070, 0);
			this.btnClose.Margin = new System.Windows.Forms.Padding(0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(40, 40);
			this.btnClose.TabIndex = 11;
			this.btnClose.TabStop = false;
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnSair_Click);
			// 
			// btnMinimizer
			// 
			this.btnMinimizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMinimizer.BackColor = System.Drawing.Color.Transparent;
			this.btnMinimizer.FlatAppearance.BorderSize = 0;
			this.btnMinimizer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnMinimizer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			this.btnMinimizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMinimizer.Image = global::CamadaUI.Properties.Resources.DropdownIcon;
			this.btnMinimizer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnMinimizer.Location = new System.Drawing.Point(1030, 0);
			this.btnMinimizer.Margin = new System.Windows.Forms.Padding(0);
			this.btnMinimizer.Name = "btnMinimizer";
			this.btnMinimizer.Size = new System.Drawing.Size(40, 40);
			this.btnMinimizer.TabIndex = 11;
			this.btnMinimizer.TabStop = false;
			this.btnMinimizer.UseVisualStyleBackColor = false;
			this.btnMinimizer.Click += new System.EventHandler(this.btnMinimizer_Click);
			// 
			// btnConfig
			// 
			this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConfig.BackColor = System.Drawing.Color.Transparent;
			this.btnConfig.FlatAppearance.BorderSize = 0;
			this.btnConfig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
			this.btnConfig.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnConfig.Location = new System.Drawing.Point(990, 0);
			this.btnConfig.Margin = new System.Windows.Forms.Padding(0);
			this.btnConfig.Name = "btnConfig";
			this.btnConfig.Size = new System.Drawing.Size(40, 40);
			this.btnConfig.TabIndex = 11;
			this.btnConfig.TabStop = false;
			this.btnConfig.UseVisualStyleBackColor = false;
			this.btnConfig.Visible = false;
			this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
			// 
			// PainelInferior
			// 
			this.PainelInferior.BackColor = System.Drawing.Color.SlateGray;
			this.PainelInferior.Controls.Add(this.lblSetor);
			this.PainelInferior.Controls.Add(this.label5);
			this.PainelInferior.Controls.Add(this.lblConta);
			this.PainelInferior.Controls.Add(this.Label4);
			this.PainelInferior.Controls.Add(this.lblVersao);
			this.PainelInferior.Controls.Add(this.Label1);
			this.PainelInferior.Controls.Add(this.lblFilial);
			this.PainelInferior.Controls.Add(this.Label3);
			this.PainelInferior.Controls.Add(this.lblDataSis);
			this.PainelInferior.Controls.Add(this.Label2);
			this.PainelInferior.Controls.Add(this.lblHora);
			this.PainelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.PainelInferior.Location = new System.Drawing.Point(0, 697);
			this.PainelInferior.Name = "PainelInferior";
			this.PainelInferior.Size = new System.Drawing.Size(1110, 35);
			this.PainelInferior.TabIndex = 3;
			// 
			// lblSetor
			// 
			this.lblSetor.AutoSize = true;
			this.lblSetor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblSetor.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblSetor.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSetor.ForeColor = System.Drawing.Color.Transparent;
			this.lblSetor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblSetor.Location = new System.Drawing.Point(410, 0);
			this.lblSetor.Name = "lblSetor";
			this.lblSetor.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
			this.lblSetor.Size = new System.Drawing.Size(23, 24);
			this.lblSetor.TabIndex = 5;
			this.lblSetor.Text = "...";
			this.lblSetor.Click += new System.EventHandler(this.lblSetor_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.Transparent;
			this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label5.Location = new System.Drawing.Point(340, 0);
			this.label5.Name = "label5";
			this.label5.Padding = new System.Windows.Forms.Padding(20, 6, 0, 0);
			this.label5.Size = new System.Drawing.Size(70, 25);
			this.label5.TabIndex = 4;
			this.label5.Text = "Setor:";
			this.label5.Click += new System.EventHandler(this.lblSetor_Click);
			// 
			// lblConta
			// 
			this.lblConta.AutoSize = true;
			this.lblConta.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblConta.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblConta.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblConta.ForeColor = System.Drawing.Color.Transparent;
			this.lblConta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblConta.Location = new System.Drawing.Point(317, 0);
			this.lblConta.Name = "lblConta";
			this.lblConta.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
			this.lblConta.Size = new System.Drawing.Size(23, 24);
			this.lblConta.TabIndex = 5;
			this.lblConta.Text = "...";
			this.lblConta.Click += new System.EventHandler(this.lblConta_Click);
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.Label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = System.Drawing.Color.Transparent;
			this.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.Label4.Location = new System.Drawing.Point(244, 0);
			this.Label4.Name = "Label4";
			this.Label4.Padding = new System.Windows.Forms.Padding(20, 6, 0, 0);
			this.Label4.Size = new System.Drawing.Size(73, 25);
			this.Label4.TabIndex = 4;
			this.Label4.Text = "Conta:";
			this.Label4.Click += new System.EventHandler(this.lblConta_Click);
			// 
			// lblVersao
			// 
			this.lblVersao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblVersao.AutoSize = true;
			this.lblVersao.ForeColor = System.Drawing.Color.Transparent;
			this.lblVersao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblVersao.Location = new System.Drawing.Point(900, 7);
			this.lblVersao.Name = "lblVersao";
			this.lblVersao.Size = new System.Drawing.Size(26, 18);
			this.lblVersao.TabIndex = 3;
			this.lblVersao.Text = "...";
			// 
			// Label1
			// 
			this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = System.Drawing.Color.Transparent;
			this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.Label1.Location = new System.Drawing.Point(847, 7);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(57, 19);
			this.Label1.TabIndex = 2;
			this.Label1.Text = "Versão:";
			// 
			// lblFilial
			// 
			this.lblFilial.AutoSize = true;
			this.lblFilial.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblFilial.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFilial.ForeColor = System.Drawing.Color.Transparent;
			this.lblFilial.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblFilial.Location = new System.Drawing.Point(221, 0);
			this.lblFilial.Name = "lblFilial";
			this.lblFilial.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
			this.lblFilial.Size = new System.Drawing.Size(23, 24);
			this.lblFilial.TabIndex = 3;
			this.lblFilial.Text = "...";
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.Label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = System.Drawing.Color.Transparent;
			this.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.Label3.Location = new System.Drawing.Point(151, 0);
			this.Label3.Margin = new System.Windows.Forms.Padding(0);
			this.Label3.Name = "Label3";
			this.Label3.Padding = new System.Windows.Forms.Padding(20, 6, 0, 0);
			this.Label3.Size = new System.Drawing.Size(70, 25);
			this.Label3.TabIndex = 2;
			this.Label3.Text = "Igreja:";
			// 
			// lblDataSis
			// 
			this.lblDataSis.AutoSize = true;
			this.lblDataSis.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblDataSis.ForeColor = System.Drawing.Color.Transparent;
			this.lblDataSis.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblDataSis.Location = new System.Drawing.Point(125, 0);
			this.lblDataSis.Name = "lblDataSis";
			this.lblDataSis.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
			this.lblDataSis.Size = new System.Drawing.Size(26, 24);
			this.lblDataSis.TabIndex = 1;
			this.lblDataSis.Text = "...";
			this.lblDataSis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.Label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = System.Drawing.Color.Transparent;
			this.Label2.Location = new System.Drawing.Point(0, 0);
			this.Label2.Name = "Label2";
			this.Label2.Padding = new System.Windows.Forms.Padding(6, 6, 0, 0);
			this.Label2.Size = new System.Drawing.Size(125, 25);
			this.Label2.TabIndex = 0;
			this.Label2.Text = "Data do Sistema:";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblHora
			// 
			this.lblHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblHora.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
			this.lblHora.ForeColor = System.Drawing.Color.White;
			this.lblHora.Image = global::CamadaUI.Properties.Resources.RelogioIcon_peq;
			this.lblHora.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblHora.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblHora.Location = new System.Drawing.Point(1003, 3);
			this.lblHora.Name = "lblHora";
			this.lblHora.Size = new System.Drawing.Size(102, 30);
			this.lblHora.TabIndex = 6;
			this.lblHora.Text = "Hora";
			this.lblHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mnuDespesaGrupo
			// 
			this.mnuDespesaGrupo.Font = new System.Drawing.Font("Calibri", 12F);
			this.mnuDespesaGrupo.Image = global::CamadaUI.Properties.Resources.search_24;
			this.mnuDespesaGrupo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuDespesaGrupo.Name = "mnuDespesaGrupo";
			this.mnuDespesaGrupo.Size = new System.Drawing.Size(211, 30);
			this.mnuDespesaGrupo.Text = "Grupos de Despesa";
			// 
			// frmPrincipal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1110, 732);
			this.Controls.Add(this.PainelInferior);
			this.Controls.Add(this.mnuPrincipal);
			this.Controls.Add(this.pnlTop);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.Name = "frmPrincipal";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Principal";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmPrincipal_Load);
			this.mnuPrincipal.ResumeLayout(false);
			this.mnuPrincipal.PerformLayout();
			this.pnlTop.ResumeLayout(false);
			this.pnlTop.PerformLayout();
			this.PainelInferior.ResumeLayout(false);
			this.PainelInferior.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ToolStripButton btnSair;
		internal System.Windows.Forms.Button btnClose;
		internal System.Windows.Forms.Button btnMinimizer;
		private System.Windows.Forms.ToolStripSplitButton btnCadastros;
		private System.Windows.Forms.Label lblTitulo;
		private System.Windows.Forms.ToolStripSplitButton btnEntradas;
		private System.Windows.Forms.ToolStripMenuItem mnuContribuicaoInserir;
		private System.Windows.Forms.ToolStripMenuItem mnuContribuicaoProcurar;
		private System.Windows.Forms.ToolStripSplitButton btnSaidas;
		private System.Windows.Forms.ToolStripMenuItem mnuDespesaInserir;
		internal System.Windows.Forms.Panel PainelInferior;
		internal System.Windows.Forms.Label lblConta;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label lblVersao;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label lblFilial;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label lblDataSis;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label lblHora;
		private System.Windows.Forms.ToolStripMenuItem mnuCongregacoes;
		private System.Windows.Forms.ToolStripMenuItem mnuSetoresCongregacao;
		private System.Windows.Forms.ToolStripMenuItem mnuCredores;
		private System.Windows.Forms.ToolStripMenuItem mnuContribuintes;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		public System.Windows.Forms.Panel pnlTop;
		public System.Windows.Forms.ToolStrip mnuPrincipal;
		public System.Windows.Forms.Button btnConfig;
		private System.Windows.Forms.ToolStripSplitButton btnMovimentação;
		private System.Windows.Forms.ToolStripMenuItem mnuFechamento;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem mnuContas;
		private System.Windows.Forms.ToolStripMenuItem mnuSetores;
		private System.Windows.Forms.ToolStripMenuItem mnuDespesaProcurar;
		private System.Windows.Forms.ToolStripMenuItem mnuReunioes;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem mnuCampanhas;
		internal System.Windows.Forms.Label lblSetor;
		internal System.Windows.Forms.Label label5;
		private System.Windows.Forms.ToolStripMenuItem mnuCartao;
		private System.Windows.Forms.ToolStripMenuItem mnuBanco;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem mnuDespesaTipo;
		private System.Windows.Forms.ToolStripMenuItem mnuDespesaGrupo;
	}
}

