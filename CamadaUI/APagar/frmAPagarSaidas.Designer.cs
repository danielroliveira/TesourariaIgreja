namespace CamadaUI.APagar
{
	partial class frmAPagarSaidas
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
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.lblDespesaDescricao = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblCredor = new System.Windows.Forms.Label();
			this.lblVencimento = new System.Windows.Forms.Label();
			this.lblAtrasoDias = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.lblIdentificador = new System.Windows.Forms.Label();
			this.lblCobrancaForma = new System.Windows.Forms.Label();
			this.lblBanco = new System.Windows.Forms.Label();
			this.lblAPagarValor = new System.Windows.Forms.Label();
			this.lblReferencia = new System.Windows.Forms.Label();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnQuitar = new System.Windows.Forms.ToolStripButton();
			this.btnEstornar = new System.Windows.Forms.ToolStripButton();
			this.btnConcederDesconto = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvListagem = new System.Windows.Forms.DataGridView();
			this.clnData = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnConta = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnObservacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label2 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.txtValorDesconto = new CamadaUC.ucTextBoxUnclicked();
			this.lblValorPago = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblValorEmAberto = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.label19 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.lblValorAcrescimo = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).BeginInit();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel6.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(338, 0);
			this.lblTitulo.Size = new System.Drawing.Size(334, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "A Pagar - Saídas | Pagamentos";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(672, 0);
			this.btnClose.TabIndex = 3;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblID);
			this.panel1.Controls.Add(this.lbl_IdTexto);
			this.panel1.Size = new System.Drawing.Size(712, 50);
			this.panel1.Controls.SetChildIndex(this.btnClose, 0);
			this.panel1.Controls.SetChildIndex(this.lblTitulo, 0);
			this.panel1.Controls.SetChildIndex(this.lbl_IdTexto, 0);
			this.panel1.Controls.SetChildIndex(this.lblID, 0);
			// 
			// lblID
			// 
			this.lblID.BackColor = System.Drawing.Color.Transparent;
			this.lblID.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblID.ForeColor = System.Drawing.Color.AliceBlue;
			this.lblID.Location = new System.Drawing.Point(6, 16);
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
			this.lbl_IdTexto.Location = new System.Drawing.Point(33, 3);
			this.lbl_IdTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbl_IdTexto.Name = "lbl_IdTexto";
			this.lbl_IdTexto.Size = new System.Drawing.Size(35, 13);
			this.lbl_IdTexto.TabIndex = 1;
			this.lbl_IdTexto.Text = "Reg.";
			this.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblDespesaDescricao
			// 
			this.lblDespesaDescricao.BackColor = System.Drawing.Color.Transparent;
			this.lblDespesaDescricao.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDespesaDescricao.Location = new System.Drawing.Point(17, 6);
			this.lblDespesaDescricao.Name = "lblDespesaDescricao";
			this.lblDespesaDescricao.Size = new System.Drawing.Size(369, 27);
			this.lblDespesaDescricao.TabIndex = 1;
			this.lblDespesaDescricao.Text = "Descrição da Despesa";
			this.lblDespesaDescricao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
			this.panel2.Controls.Add(this.lblCredor);
			this.panel2.Controls.Add(this.lblVencimento);
			this.panel2.Controls.Add(this.lblAtrasoDias);
			this.panel2.Location = new System.Drawing.Point(2, 76);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(708, 37);
			this.panel2.TabIndex = 21;
			// 
			// lblCredor
			// 
			this.lblCredor.BackColor = System.Drawing.Color.Transparent;
			this.lblCredor.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCredor.Location = new System.Drawing.Point(17, 5);
			this.lblCredor.Name = "lblCredor";
			this.lblCredor.Size = new System.Drawing.Size(406, 27);
			this.lblCredor.TabIndex = 1;
			this.lblCredor.Text = "Credor";
			this.lblCredor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblVencimento
			// 
			this.lblVencimento.BackColor = System.Drawing.Color.Transparent;
			this.lblVencimento.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblVencimento.Location = new System.Drawing.Point(427, 5);
			this.lblVencimento.Name = "lblVencimento";
			this.lblVencimento.Size = new System.Drawing.Size(120, 27);
			this.lblVencimento.TabIndex = 1;
			this.lblVencimento.Text = "Vencimento";
			this.lblVencimento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblAtrasoDias
			// 
			this.lblAtrasoDias.BackColor = System.Drawing.Color.Transparent;
			this.lblAtrasoDias.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAtrasoDias.Location = new System.Drawing.Point(568, 5);
			this.lblAtrasoDias.Name = "lblAtrasoDias";
			this.lblAtrasoDias.Size = new System.Drawing.Size(89, 27);
			this.lblAtrasoDias.TabIndex = 1;
			this.lblAtrasoDias.Text = "00";
			this.lblAtrasoDias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.Transparent;
			this.label11.ForeColor = System.Drawing.Color.DarkGray;
			this.label11.Location = new System.Drawing.Point(16, 182);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(77, 19);
			this.label11.TabIndex = 2;
			this.label11.Text = "Descrição:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.ForeColor = System.Drawing.Color.DarkGray;
			this.label10.Location = new System.Drawing.Point(16, 54);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 19);
			this.label10.TabIndex = 2;
			this.label10.Text = "Credor:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.BackColor = System.Drawing.Color.Transparent;
			this.label12.ForeColor = System.Drawing.Color.DarkGray;
			this.label12.Location = new System.Drawing.Point(481, 118);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(68, 19);
			this.label12.TabIndex = 2;
			this.label12.Text = "No. Reg.:";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.BackColor = System.Drawing.Color.Transparent;
			this.label13.ForeColor = System.Drawing.Color.DarkGray;
			this.label13.Location = new System.Drawing.Point(570, 53);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(55, 19);
			this.label13.TabIndex = 4;
			this.label13.Text = "Atraso:";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.BackColor = System.Drawing.Color.Transparent;
			this.label14.ForeColor = System.Drawing.Color.DarkGray;
			this.label14.Location = new System.Drawing.Point(16, 118);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(138, 19);
			this.label14.TabIndex = 6;
			this.label14.Text = "Forma de Cobrança:";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.BackColor = System.Drawing.Color.Transparent;
			this.label16.ForeColor = System.Drawing.Color.DarkGray;
			this.label16.Location = new System.Drawing.Point(429, 54);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(89, 19);
			this.label16.TabIndex = 12;
			this.label16.Text = "Vencimento:";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.BackColor = System.Drawing.Color.Transparent;
			this.label17.ForeColor = System.Drawing.Color.DarkGray;
			this.label17.Location = new System.Drawing.Point(481, 182);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(83, 19);
			this.label17.TabIndex = 18;
			this.label17.Text = "Referência:";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.BackColor = System.Drawing.Color.Transparent;
			this.label18.ForeColor = System.Drawing.Color.Black;
			this.label18.Location = new System.Drawing.Point(16, 2);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(46, 19);
			this.label18.TabIndex = 14;
			this.label18.Text = "Valor:";
			// 
			// lblIdentificador
			// 
			this.lblIdentificador.BackColor = System.Drawing.Color.Transparent;
			this.lblIdentificador.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblIdentificador.Location = new System.Drawing.Point(479, 4);
			this.lblIdentificador.Name = "lblIdentificador";
			this.lblIdentificador.Size = new System.Drawing.Size(178, 27);
			this.lblIdentificador.TabIndex = 1;
			this.lblIdentificador.Text = "Identificador";
			this.lblIdentificador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblCobrancaForma
			// 
			this.lblCobrancaForma.BackColor = System.Drawing.Color.Transparent;
			this.lblCobrancaForma.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCobrancaForma.Location = new System.Drawing.Point(17, 4);
			this.lblCobrancaForma.Name = "lblCobrancaForma";
			this.lblCobrancaForma.Size = new System.Drawing.Size(186, 27);
			this.lblCobrancaForma.TabIndex = 1;
			this.lblCobrancaForma.Text = "Forma de Cobrança";
			this.lblCobrancaForma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblBanco
			// 
			this.lblBanco.BackColor = System.Drawing.Color.Transparent;
			this.lblBanco.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBanco.Location = new System.Drawing.Point(203, 4);
			this.lblBanco.Name = "lblBanco";
			this.lblBanco.Size = new System.Drawing.Size(270, 27);
			this.lblBanco.TabIndex = 1;
			this.lblBanco.Text = "Banco de Cobrança";
			this.lblBanco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblAPagarValor
			// 
			this.lblAPagarValor.BackColor = System.Drawing.Color.Transparent;
			this.lblAPagarValor.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAPagarValor.Location = new System.Drawing.Point(15, 5);
			this.lblAPagarValor.Name = "lblAPagarValor";
			this.lblAPagarValor.Size = new System.Drawing.Size(130, 27);
			this.lblAPagarValor.TabIndex = 1;
			this.lblAPagarValor.Text = "R$ 0,00";
			this.lblAPagarValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblReferencia
			// 
			this.lblReferencia.BackColor = System.Drawing.Color.Transparent;
			this.lblReferencia.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblReferencia.Location = new System.Drawing.Point(483, 6);
			this.lblReferencia.Name = "lblReferencia";
			this.lblReferencia.Size = new System.Drawing.Size(215, 27);
			this.lblReferencia.TabIndex = 1;
			this.lblReferencia.Text = "Mes/Ano";
			this.lblReferencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tspMenu
			// 
			this.tspMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tspMenu.AutoSize = false;
			this.tspMenu.BackColor = System.Drawing.Color.AntiqueWhite;
			this.tspMenu.Dock = System.Windows.Forms.DockStyle.None;
			this.tspMenu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tspMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuitar,
            this.btnEstornar,
            this.btnConcederDesconto,
            this.btnFechar});
			this.tspMenu.Location = new System.Drawing.Point(2, 593);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(708, 44);
			this.tspMenu.TabIndex = 22;
			this.tspMenu.TabStop = true;
			this.tspMenu.Text = "toolStrip1";
			// 
			// btnQuitar
			// 
			this.btnQuitar.AutoSize = false;
			this.btnQuitar.Image = global::CamadaUI.Properties.Resources.money_red_32;
			this.btnQuitar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnQuitar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnQuitar.Name = "btnQuitar";
			this.btnQuitar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnQuitar.Size = new System.Drawing.Size(145, 41);
			this.btnQuitar.Text = "&Quitar";
			this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
			// 
			// btnEstornar
			// 
			this.btnEstornar.AutoSize = false;
			this.btnEstornar.Image = global::CamadaUI.Properties.Resources.refresh_32;
			this.btnEstornar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnEstornar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEstornar.Name = "btnEstornar";
			this.btnEstornar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnEstornar.Size = new System.Drawing.Size(140, 41);
			this.btnEstornar.Text = "E&stornar";
			this.btnEstornar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnEstornar.Click += new System.EventHandler(this.btnEstornar_Click);
			// 
			// btnConcederDesconto
			// 
			this.btnConcederDesconto.AutoSize = false;
			this.btnConcederDesconto.Image = global::CamadaUI.Properties.Resources.editar_24;
			this.btnConcederDesconto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnConcederDesconto.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnConcederDesconto.Name = "btnConcederDesconto";
			this.btnConcederDesconto.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnConcederDesconto.Size = new System.Drawing.Size(145, 41);
			this.btnConcederDesconto.Text = "&Editar Desconto";
			this.btnConcederDesconto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnConcederDesconto.Click += new System.EventHandler(this.btnConcederDesconto_Click);
			// 
			// btnFechar
			// 
			this.btnFechar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.fechar_30;
			this.btnFechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnFechar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnFechar.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnFechar.Size = new System.Drawing.Size(96, 41);
			this.btnFechar.Text = "&Fechar";
			this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFechar.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
			this.panel3.Controls.Add(this.lblIdentificador);
			this.panel3.Controls.Add(this.lblCobrancaForma);
			this.panel3.Controls.Add(this.lblBanco);
			this.panel3.Location = new System.Drawing.Point(2, 140);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(708, 37);
			this.panel3.TabIndex = 22;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.DarkGray;
			this.label1.Location = new System.Drawing.Point(205, 118);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 19);
			this.label1.TabIndex = 6;
			this.label1.Text = "Banco:";
			// 
			// dgvListagem
			// 
			this.dgvListagem.AllowUserToAddRows = false;
			this.dgvListagem.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
			this.dgvListagem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvListagem.BackgroundColor = System.Drawing.Color.AliceBlue;
			this.dgvListagem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvListagem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvListagem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvListagem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvListagem.ColumnHeadersHeight = 25;
			this.dgvListagem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnData,
            this.clnValor,
            this.clnConta,
            this.clnObservacao});
			this.dgvListagem.EnableHeadersVisualStyles = false;
			this.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption;
			this.dgvListagem.Location = new System.Drawing.Point(33, 355);
			this.dgvListagem.MultiSelect = false;
			this.dgvListagem.Name = "dgvListagem";
			this.dgvListagem.ReadOnly = true;
			this.dgvListagem.RowHeadersWidth = 30;
			this.dgvListagem.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.dgvListagem.Size = new System.Drawing.Size(651, 214);
			this.dgvListagem.TabIndex = 26;
			// 
			// clnData
			// 
			this.clnData.HeaderText = "Data";
			this.clnData.Name = "clnData";
			this.clnData.ReadOnly = true;
			// 
			// clnValor
			// 
			this.clnValor.HeaderText = "Valor";
			this.clnValor.Name = "clnValor";
			this.clnValor.ReadOnly = true;
			// 
			// clnConta
			// 
			this.clnConta.HeaderText = "Conta";
			this.clnConta.Name = "clnConta";
			this.clnConta.ReadOnly = true;
			this.clnConta.Width = 150;
			// 
			// clnObservacao
			// 
			this.clnObservacao.HeaderText = "Observação";
			this.clnObservacao.Name = "clnObservacao";
			this.clnObservacao.ReadOnly = true;
			this.clnObservacao.Width = 200;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.SlateGray;
			this.label2.Location = new System.Drawing.Point(35, 324);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(124, 26);
			this.label2.TabIndex = 27;
			this.label2.Text = "Pagamentos:";
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
			this.panel4.Controls.Add(this.lblDespesaDescricao);
			this.panel4.Controls.Add(this.lblReferencia);
			this.panel4.Location = new System.Drawing.Point(2, 204);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(708, 37);
			this.panel4.TabIndex = 23;
			// 
			// txtValorDesconto
			// 
			this.txtValorDesconto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
			this.txtValorDesconto.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtValorDesconto.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtValorDesconto.Location = new System.Drawing.Point(159, 6);
			this.txtValorDesconto.Name = "txtValorDesconto";
			this.txtValorDesconto.ReadOnly = true;
			this.txtValorDesconto.SelectionHighlightEnabled = false;
			this.txtValorDesconto.Size = new System.Drawing.Size(126, 26);
			this.txtValorDesconto.TabIndex = 29;
			this.txtValorDesconto.TabStop = false;
			this.txtValorDesconto.Text = "R$ 0,00";
			this.txtValorDesconto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorDesconto_KeyDown);
			this.txtValorDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UcOnlyNumbers_KeyPress);
			this.txtValorDesconto.Leave += new System.EventHandler(this.txtValorDesconto_Leave);
			// 
			// lblValorPago
			// 
			this.lblValorPago.BackColor = System.Drawing.Color.Transparent;
			this.lblValorPago.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorPago.ForeColor = System.Drawing.Color.DarkBlue;
			this.lblValorPago.Location = new System.Drawing.Point(291, 5);
			this.lblValorPago.Name = "lblValorPago";
			this.lblValorPago.Size = new System.Drawing.Size(130, 27);
			this.lblValorPago.TabIndex = 1;
			this.lblValorPago.Text = "R$ 0,00";
			this.lblValorPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(291, 2);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(82, 19);
			this.label4.TabIndex = 14;
			this.label4.Text = "Valor Pago:";
			// 
			// lblValorEmAberto
			// 
			this.lblValorEmAberto.BackColor = System.Drawing.Color.Transparent;
			this.lblValorEmAberto.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorEmAberto.ForeColor = System.Drawing.Color.DarkRed;
			this.lblValorEmAberto.Location = new System.Drawing.Point(429, 5);
			this.lblValorEmAberto.Name = "lblValorEmAberto";
			this.lblValorEmAberto.Size = new System.Drawing.Size(130, 27);
			this.lblValorEmAberto.TabIndex = 1;
			this.lblValorEmAberto.Text = "R$ 0,00";
			this.lblValorEmAberto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(428, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(117, 19);
			this.label3.TabIndex = 14;
			this.label3.Text = "Valor Em Aberto:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(155, 2);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(74, 19);
			this.label5.TabIndex = 14;
			this.label5.Text = "Desconto:";
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.White;
			this.panel5.Controls.Add(this.label19);
			this.panel5.Controls.Add(this.label3);
			this.panel5.Controls.Add(this.label18);
			this.panel5.Controls.Add(this.label4);
			this.panel5.Controls.Add(this.label5);
			this.panel5.Location = new System.Drawing.Point(2, 252);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(708, 24);
			this.panel5.TabIndex = 28;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.BackColor = System.Drawing.Color.Transparent;
			this.label19.ForeColor = System.Drawing.Color.Black;
			this.label19.Location = new System.Drawing.Point(568, 2);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(116, 19);
			this.label19.TabIndex = 14;
			this.label19.Text = "Acréscimo Pago:";
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
			this.panel6.Controls.Add(this.txtValorDesconto);
			this.panel6.Controls.Add(this.lblValorAcrescimo);
			this.panel6.Controls.Add(this.lblValorEmAberto);
			this.panel6.Controls.Add(this.lblAPagarValor);
			this.panel6.Controls.Add(this.lblValorPago);
			this.panel6.Location = new System.Drawing.Point(2, 275);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(708, 37);
			this.panel6.TabIndex = 28;
			// 
			// lblValorAcrescimo
			// 
			this.lblValorAcrescimo.BackColor = System.Drawing.Color.Transparent;
			this.lblValorAcrescimo.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorAcrescimo.ForeColor = System.Drawing.Color.DarkRed;
			this.lblValorAcrescimo.Location = new System.Drawing.Point(567, 5);
			this.lblValorAcrescimo.Name = "lblValorAcrescimo";
			this.lblValorAcrescimo.Size = new System.Drawing.Size(130, 27);
			this.lblValorAcrescimo.TabIndex = 1;
			this.lblValorAcrescimo.Text = "R$ 0,00";
			this.lblValorAcrescimo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmAPagarSaidas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(712, 640);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.dgvListagem);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.tspMenu);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.label16);
			this.KeyPreview = true;
			this.Name = "frmAPagarSaidas";
			this.Activated += new System.EventHandler(this.form_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_FormClosed);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAPagarSaidas_KeyDown);
			this.Controls.SetChildIndex(this.label16, 0);
			this.Controls.SetChildIndex(this.panel2, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.label13, 0);
			this.Controls.SetChildIndex(this.label14, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label10, 0);
			this.Controls.SetChildIndex(this.label12, 0);
			this.Controls.SetChildIndex(this.label17, 0);
			this.Controls.SetChildIndex(this.panel3, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.dgvListagem, 0);
			this.Controls.SetChildIndex(this.panel4, 0);
			this.Controls.SetChildIndex(this.label11, 0);
			this.Controls.SetChildIndex(this.panel5, 0);
			this.Controls.SetChildIndex(this.panel6, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).EndInit();
			this.panel4.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label lbl_IdTexto;
		private System.Windows.Forms.Label lblDespesaDescricao;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblCredor;
		internal System.Windows.Forms.Label label11;
		internal System.Windows.Forms.Label label10;
		internal System.Windows.Forms.Label label12;
		internal System.Windows.Forms.Label label13;
		internal System.Windows.Forms.Label label14;
		internal System.Windows.Forms.Label label16;
		internal System.Windows.Forms.Label label17;
		internal System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label lblIdentificador;
		private System.Windows.Forms.Label lblAtrasoDias;
		private System.Windows.Forms.Label lblCobrancaForma;
		private System.Windows.Forms.Label lblBanco;
		private System.Windows.Forms.Label lblVencimento;
		private System.Windows.Forms.Label lblAPagarValor;
		private System.Windows.Forms.Label lblReferencia;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnEstornar;
		private System.Windows.Forms.ToolStripButton btnFechar;
		private System.Windows.Forms.Panel panel3;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.DataGridView dgvListagem;
		internal System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label lblValorPago;
		internal System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblValorEmAberto;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		internal System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label lblValorAcrescimo;
		private CamadaUC.ucTextBoxUnclicked txtValorDesconto;
		private System.Windows.Forms.ToolStripButton btnQuitar;
		private System.Windows.Forms.ToolStripButton btnConcederDesconto;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnData;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValor;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnConta;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnObservacao;
	}
}
