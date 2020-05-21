﻿namespace CamadaUI.APagar
{
	partial class frmAPagarListagem
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.btnFechar = new System.Windows.Forms.Button();
			this.btnVisualizar = new System.Windows.Forms.Button();
			this.dgvListagem = new System.Windows.Forms.DataGridView();
			this.clnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnForma = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnCredor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnSituacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnReferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValorPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.lblValorPago = new System.Windows.Forms.Label();
			this.btnFiltrar = new VIBlend.WinForms.Controls.vButton();
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
			this.lblFiltro = new System.Windows.Forms.Label();
			this.lblValor = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.pnlSituacao = new System.Windows.Forms.Panel();
			this.rbtSitTodas = new System.Windows.Forms.RadioButton();
			this.rbtNegociadas = new System.Windows.Forms.RadioButton();
			this.rbtNegativadas = new System.Windows.Forms.RadioButton();
			this.rbtCanceladas = new System.Windows.Forms.RadioButton();
			this.rbtQuitadas = new System.Windows.Forms.RadioButton();
			this.rbtEmAberto = new System.Windows.Forms.RadioButton();
			this.btnAlterar = new System.Windows.Forms.Button();
			this.btnQuitar = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).BeginInit();
			this.pnlPorMes.SuspendLayout();
			this.pnlPorPeriodo.SuspendLayout();
			this.Panel2.SuspendLayout();
			this.pnlSituacao.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(964, 0);
			this.lblTitulo.Size = new System.Drawing.Size(196, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Procurar APagar";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(1160, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(1200, 50);
			// 
			// btnFechar
			// 
			this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.delete_16;
			this.btnFechar.Location = new System.Drawing.Point(1043, 677);
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Size = new System.Drawing.Size(135, 42);
			this.btnFechar.TabIndex = 7;
			this.btnFechar.Text = "&Fechar";
			this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnFechar.UseVisualStyleBackColor = true;
			this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// btnVisualizar
			// 
			this.btnVisualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnVisualizar.Image = global::CamadaUI.Properties.Resources.search_page_24;
			this.btnVisualizar.Location = new System.Drawing.Point(22, 677);
			this.btnVisualizar.Name = "btnVisualizar";
			this.btnVisualizar.Size = new System.Drawing.Size(126, 42);
			this.btnVisualizar.TabIndex = 4;
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
            this.clnID,
            this.clnVencimento,
            this.clnForma,
            this.clnCredor,
            this.clnSituacao,
            this.clnReferencia,
            this.clnValor,
            this.clnValorPago});
			this.dgvListagem.EnableHeadersVisualStyles = false;
			this.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption;
			this.dgvListagem.Location = new System.Drawing.Point(22, 140);
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
			this.dgvListagem.Size = new System.Drawing.Size(1156, 478);
			this.dgvListagem.TabIndex = 2;
			this.dgvListagem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListagem_CellFormatting);
			this.dgvListagem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListagem_KeyDown);
			// 
			// clnID
			// 
			this.clnID.HeaderText = "Reg.";
			this.clnID.Name = "clnID";
			this.clnID.ReadOnly = true;
			this.clnID.Width = 60;
			// 
			// clnVencimento
			// 
			this.clnVencimento.HeaderText = "Venc.";
			this.clnVencimento.Name = "clnVencimento";
			this.clnVencimento.ReadOnly = true;
			this.clnVencimento.Width = 85;
			// 
			// clnForma
			// 
			this.clnForma.HeaderText = "Forma";
			this.clnForma.Name = "clnForma";
			this.clnForma.ReadOnly = true;
			this.clnForma.Width = 150;
			// 
			// clnCredor
			// 
			this.clnCredor.HeaderText = "Credor";
			this.clnCredor.Name = "clnCredor";
			this.clnCredor.ReadOnly = true;
			this.clnCredor.Width = 400;
			// 
			// clnSituacao
			// 
			this.clnSituacao.HeaderText = "Situação";
			this.clnSituacao.Name = "clnSituacao";
			this.clnSituacao.ReadOnly = true;
			// 
			// clnReferencia
			// 
			this.clnReferencia.HeaderText = "Ref.";
			this.clnReferencia.Name = "clnReferencia";
			this.clnReferencia.ReadOnly = true;
			// 
			// clnValor
			// 
			this.clnValor.HeaderText = "Valor";
			this.clnValor.Name = "clnValor";
			this.clnValor.ReadOnly = true;
			// 
			// clnValorPago
			// 
			this.clnValorPago.HeaderText = "Vl.Pago";
			this.clnValorPago.Name = "clnValorPago";
			this.clnValorPago.ReadOnly = true;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(1109, 621);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 15);
			this.label1.TabIndex = 8;
			this.label1.Text = "Valor Pago:";
			// 
			// lblValorPago
			// 
			this.lblValorPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValorPago.BackColor = System.Drawing.Color.LightGray;
			this.lblValorPago.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorPago.Location = new System.Drawing.Point(1041, 638);
			this.lblValorPago.Name = "lblValorPago";
			this.lblValorPago.Size = new System.Drawing.Size(137, 32);
			this.lblValorPago.TabIndex = 9;
			this.lblValorPago.Text = "R$ 0,00";
			this.lblValorPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnFiltrar
			// 
			this.btnFiltrar.AllowAnimations = true;
			this.btnFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnFiltrar.BackColor = System.Drawing.Color.Transparent;
			this.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFiltrar.HoverEffectsEnabled = true;
			this.btnFiltrar.Image = global::CamadaUI.Properties.Resources.search_24;
			this.btnFiltrar.ImageAbsolutePosition = new System.Drawing.Point(20, 3);
			this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnFiltrar.Location = new System.Drawing.Point(746, 628);
			this.btnFiltrar.Name = "btnFiltrar";
			this.btnFiltrar.PressedTextColor = System.Drawing.Color.LemonChiffon;
			this.btnFiltrar.RoundedCornersMask = ((byte)(15));
			this.btnFiltrar.RoundedCornersRadius = 2;
			this.btnFiltrar.Size = new System.Drawing.Size(138, 41);
			this.btnFiltrar.TabIndex = 3;
			this.btnFiltrar.TabStop = false;
			this.btnFiltrar.Text = "Filtrar...";
			this.btnFiltrar.TextAbsolutePosition = new System.Drawing.Point(25, 5);
			this.btnFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnFiltrar.UseAbsoluteImagePositioning = true;
			this.btnFiltrar.UseAbsoluteTextPositioning = true;
			this.btnFiltrar.UseCompatibleTextRendering = true;
			this.btnFiltrar.UseVisualStyleBackColor = false;
			this.btnFiltrar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICESILVER;
			this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
			// 
			// btnImprimir
			// 
			this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnImprimir.Image = global::CamadaUI.Properties.Resources.imprimir_24;
			this.btnImprimir.Location = new System.Drawing.Point(418, 677);
			this.btnImprimir.Name = "btnImprimir";
			this.btnImprimir.Size = new System.Drawing.Size(126, 42);
			this.btnImprimir.TabIndex = 6;
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
			this.Panel2.Location = new System.Drawing.Point(22, 67);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(674, 58);
			this.Panel2.TabIndex = 1;
			// 
			// lblFiltro
			// 
			this.lblFiltro.Font = new System.Drawing.Font("Pathway Gothic One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFiltro.Location = new System.Drawing.Point(717, 67);
			this.lblFiltro.Name = "lblFiltro";
			this.lblFiltro.Size = new System.Drawing.Size(461, 58);
			this.lblFiltro.TabIndex = 10;
			this.lblFiltro.Text = "Filtro";
			// 
			// lblValor
			// 
			this.lblValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValor.BackColor = System.Drawing.Color.LightGray;
			this.lblValor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValor.Location = new System.Drawing.Point(898, 637);
			this.lblValor.Name = "lblValor";
			this.lblValor.Size = new System.Drawing.Size(137, 32);
			this.lblValor.TabIndex = 9;
			this.lblValor.Text = "R$ 0,00";
			this.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.DimGray;
			this.label3.Location = new System.Drawing.Point(966, 620);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 15);
			this.label3.TabIndex = 8;
			this.label3.Text = "Valor Total:";
			// 
			// pnlSituacao
			// 
			this.pnlSituacao.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.pnlSituacao.Controls.Add(this.rbtSitTodas);
			this.pnlSituacao.Controls.Add(this.rbtNegociadas);
			this.pnlSituacao.Controls.Add(this.rbtNegativadas);
			this.pnlSituacao.Controls.Add(this.rbtCanceladas);
			this.pnlSituacao.Controls.Add(this.rbtQuitadas);
			this.pnlSituacao.Controls.Add(this.rbtEmAberto);
			this.pnlSituacao.Location = new System.Drawing.Point(22, 629);
			this.pnlSituacao.Name = "pnlSituacao";
			this.pnlSituacao.Size = new System.Drawing.Size(718, 41);
			this.pnlSituacao.TabIndex = 11;
			// 
			// rbtSitTodas
			// 
			this.rbtSitTodas.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtSitTodas.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rbtSitTodas.Location = new System.Drawing.Point(594, 3);
			this.rbtSitTodas.Name = "rbtSitTodas";
			this.rbtSitTodas.Size = new System.Drawing.Size(111, 34);
			this.rbtSitTodas.TabIndex = 0;
			this.rbtSitTodas.Tag = "6";
			this.rbtSitTodas.Text = "Todas";
			this.rbtSitTodas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtSitTodas.UseVisualStyleBackColor = true;
			// 
			// rbtNegociadas
			// 
			this.rbtNegociadas.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtNegociadas.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rbtNegociadas.Location = new System.Drawing.Point(477, 3);
			this.rbtNegociadas.Name = "rbtNegociadas";
			this.rbtNegociadas.Size = new System.Drawing.Size(111, 34);
			this.rbtNegociadas.TabIndex = 0;
			this.rbtNegociadas.Tag = "5";
			this.rbtNegociadas.Text = "Negativadas";
			this.rbtNegociadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtNegociadas.UseVisualStyleBackColor = true;
			// 
			// rbtNegativadas
			// 
			this.rbtNegativadas.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtNegativadas.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rbtNegativadas.Location = new System.Drawing.Point(360, 3);
			this.rbtNegativadas.Name = "rbtNegativadas";
			this.rbtNegativadas.Size = new System.Drawing.Size(111, 34);
			this.rbtNegativadas.TabIndex = 0;
			this.rbtNegativadas.Tag = "4";
			this.rbtNegativadas.Text = "Negociadas";
			this.rbtNegativadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtNegativadas.UseVisualStyleBackColor = true;
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
			this.rbtCanceladas.Text = "Canceladas";
			this.rbtCanceladas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtCanceladas.UseVisualStyleBackColor = true;
			// 
			// rbtQuitadas
			// 
			this.rbtQuitadas.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtQuitadas.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rbtQuitadas.Location = new System.Drawing.Point(128, 3);
			this.rbtQuitadas.Name = "rbtQuitadas";
			this.rbtQuitadas.Size = new System.Drawing.Size(111, 34);
			this.rbtQuitadas.TabIndex = 0;
			this.rbtQuitadas.Tag = "2";
			this.rbtQuitadas.Text = "Quitadas";
			this.rbtQuitadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtQuitadas.UseVisualStyleBackColor = true;
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
			// btnAlterar
			// 
			this.btnAlterar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAlterar.Image = global::CamadaUI.Properties.Resources.editar_24;
			this.btnAlterar.Location = new System.Drawing.Point(154, 677);
			this.btnAlterar.Name = "btnAlterar";
			this.btnAlterar.Size = new System.Drawing.Size(126, 42);
			this.btnAlterar.TabIndex = 4;
			this.btnAlterar.Text = "&Alterar";
			this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAlterar.UseVisualStyleBackColor = true;
			this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
			// 
			// btnQuitar
			// 
			this.btnQuitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnQuitar.Image = global::CamadaUI.Properties.Resources.dollar_24;
			this.btnQuitar.Location = new System.Drawing.Point(286, 677);
			this.btnQuitar.Name = "btnQuitar";
			this.btnQuitar.Size = new System.Drawing.Size(126, 42);
			this.btnQuitar.TabIndex = 4;
			this.btnQuitar.Text = "&Quitar";
			this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnQuitar.UseVisualStyleBackColor = true;
			this.btnQuitar.Click += new System.EventHandler(this.btnVisualizar_Click);
			// 
			// frmAPagarListagem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(1200, 728);
			this.Controls.Add(this.pnlSituacao);
			this.Controls.Add(this.lblFiltro);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblValor);
			this.Controls.Add(this.lblValorPago);
			this.Controls.Add(this.btnFiltrar);
			this.Controls.Add(this.Panel2);
			this.Controls.Add(this.dgvListagem);
			this.Controls.Add(this.btnFechar);
			this.Controls.Add(this.btnImprimir);
			this.Controls.Add(this.btnQuitar);
			this.Controls.Add(this.btnAlterar);
			this.Controls.Add(this.btnVisualizar);
			this.KeyPreview = true;
			this.Name = "frmAPagarListagem";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.Controls.SetChildIndex(this.btnVisualizar, 0);
			this.Controls.SetChildIndex(this.btnAlterar, 0);
			this.Controls.SetChildIndex(this.btnQuitar, 0);
			this.Controls.SetChildIndex(this.btnImprimir, 0);
			this.Controls.SetChildIndex(this.btnFechar, 0);
			this.Controls.SetChildIndex(this.dgvListagem, 0);
			this.Controls.SetChildIndex(this.Panel2, 0);
			this.Controls.SetChildIndex(this.btnFiltrar, 0);
			this.Controls.SetChildIndex(this.lblValorPago, 0);
			this.Controls.SetChildIndex(this.lblValor, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.lblFiltro, 0);
			this.Controls.SetChildIndex(this.pnlSituacao, 0);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).EndInit();
			this.pnlPorMes.ResumeLayout(false);
			this.pnlPorPeriodo.ResumeLayout(false);
			this.Panel2.ResumeLayout(false);
			this.pnlSituacao.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button btnFechar;
		internal System.Windows.Forms.Button btnVisualizar;
		internal System.Windows.Forms.DataGridView dgvListagem;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Label lblValorPago;
		internal VIBlend.WinForms.Controls.vButton btnFiltrar;
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
		private System.Windows.Forms.Label lblFiltro;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnID;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnVencimento;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnForma;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnCredor;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnSituacao;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnReferencia;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValor;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValorPago;
		internal System.Windows.Forms.Label lblValor;
		internal System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel pnlSituacao;
		private System.Windows.Forms.RadioButton rbtQuitadas;
		private System.Windows.Forms.RadioButton rbtEmAberto;
		private System.Windows.Forms.RadioButton rbtCanceladas;
		private System.Windows.Forms.RadioButton rbtNegativadas;
		private System.Windows.Forms.RadioButton rbtNegociadas;
		private System.Windows.Forms.RadioButton rbtSitTodas;
		internal System.Windows.Forms.Button btnAlterar;
		internal System.Windows.Forms.Button btnQuitar;
	}
}