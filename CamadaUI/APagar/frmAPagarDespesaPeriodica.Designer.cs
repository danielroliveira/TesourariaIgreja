
namespace CamadaUI.APagar
{
	partial class frmAPagarDespesaPeriodica
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvListagem = new System.Windows.Forms.DataGridView();
			this.clnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnForma = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnSituacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnReferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnPagamentoData = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValorPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnFechar = new System.Windows.Forms.Button();
			this.btnImprimir = new System.Windows.Forms.Button();
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.txtSetor = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDespesaTipo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtCredor = new System.Windows.Forms.TextBox();
			this.lblContribuinte = new System.Windows.Forms.Label();
			this.txtDespesaDescricao = new System.Windows.Forms.TextBox();
			this.lblCongregacao = new System.Windows.Forms.Label();
			this.mnuOperacoes = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuItemVerPagamentos = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuImagem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuImagemInserir = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuImagemVisualizar = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuImagemRemover = new System.Windows.Forms.ToolStripMenuItem();
			this.label8 = new System.Windows.Forms.Label();
			this.lblDespesaValor = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblIniciarData = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).BeginInit();
			this.mnuOperacoes.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(396, 0);
			this.lblTitulo.Size = new System.Drawing.Size(430, 50);
			this.lblTitulo.Text = "Listagem Despesa Periódica - Realizadas";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(826, 0);
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblID);
			this.panel1.Controls.Add(this.lbl_IdTexto);
			this.panel1.Size = new System.Drawing.Size(866, 50);
			this.panel1.Controls.SetChildIndex(this.btnClose, 0);
			this.panel1.Controls.SetChildIndex(this.lblTitulo, 0);
			this.panel1.Controls.SetChildIndex(this.lbl_IdTexto, 0);
			this.panel1.Controls.SetChildIndex(this.lblID, 0);
			// 
			// dgvListagem
			// 
			this.dgvListagem.AllowUserToAddRows = false;
			this.dgvListagem.AllowUserToDeleteRows = false;
			this.dgvListagem.AllowUserToResizeColumns = false;
			this.dgvListagem.AllowUserToResizeRows = false;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.OldLace;
			dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
			this.dgvListagem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
			this.dgvListagem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvListagem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvListagem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvListagem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.dgvListagem.ColumnHeadersHeight = 33;
			this.dgvListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvListagem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnID,
            this.clnVencimento,
            this.clnForma,
            this.clnSituacao,
            this.clnReferencia,
            this.clnValor,
            this.clnPagamentoData,
            this.clnValorPago});
			this.dgvListagem.EnableHeadersVisualStyles = false;
			this.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption;
			this.dgvListagem.Location = new System.Drawing.Point(12, 228);
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
			this.dgvListagem.Size = new System.Drawing.Size(841, 370);
			this.dgvListagem.TabIndex = 3;
			this.dgvListagem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListagem_CellDoubleClick);
			this.dgvListagem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvListagem_MouseDown);
			// 
			// clnID
			// 
			this.clnID.HeaderText = "Reg.";
			this.clnID.Name = "clnID";
			this.clnID.ReadOnly = true;
			this.clnID.Width = 50;
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
			// clnPagamentoData
			// 
			this.clnPagamentoData.HeaderText = "Dt.Pag.";
			this.clnPagamentoData.Name = "clnPagamentoData";
			this.clnPagamentoData.ReadOnly = true;
			// 
			// clnValorPago
			// 
			this.clnValorPago.HeaderText = "Vl.Pago";
			this.clnValorPago.Name = "clnValorPago";
			this.clnValorPago.ReadOnly = true;
			// 
			// btnFechar
			// 
			this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.delete_16;
			this.btnFechar.Location = new System.Drawing.Point(719, 606);
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Size = new System.Drawing.Size(135, 42);
			this.btnFechar.TabIndex = 11;
			this.btnFechar.Text = "&Fechar";
			this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnFechar.UseVisualStyleBackColor = true;
			this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// btnImprimir
			// 
			this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnImprimir.Image = global::CamadaUI.Properties.Resources.imprimir_24;
			this.btnImprimir.Location = new System.Drawing.Point(530, 606);
			this.btnImprimir.Name = "btnImprimir";
			this.btnImprimir.Size = new System.Drawing.Size(183, 42);
			this.btnImprimir.TabIndex = 10;
			this.btnImprimir.Text = "&Imprimir Listagem";
			this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnImprimir.UseVisualStyleBackColor = true;
			this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
			// 
			// lblID
			// 
			this.lblID.BackColor = System.Drawing.Color.Transparent;
			this.lblID.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblID.ForeColor = System.Drawing.Color.AliceBlue;
			this.lblID.Location = new System.Drawing.Point(5, 17);
			this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblID.Name = "lblID";
			this.lblID.Size = new System.Drawing.Size(94, 30);
			this.lblID.TabIndex = 2;
			this.lblID.Text = "0001";
			this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbl_IdTexto
			// 
			this.lbl_IdTexto.AutoSize = true;
			this.lbl_IdTexto.BackColor = System.Drawing.Color.Transparent;
			this.lbl_IdTexto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_IdTexto.ForeColor = System.Drawing.Color.Silver;
			this.lbl_IdTexto.Location = new System.Drawing.Point(32, 4);
			this.lbl_IdTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbl_IdTexto.Name = "lbl_IdTexto";
			this.lbl_IdTexto.Size = new System.Drawing.Size(35, 13);
			this.lbl_IdTexto.TabIndex = 3;
			this.lbl_IdTexto.Text = "Reg.";
			this.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtSetor
			// 
			this.txtSetor.Location = new System.Drawing.Point(160, 66);
			this.txtSetor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtSetor.MaxLength = 30;
			this.txtSetor.Name = "txtSetor";
			this.txtSetor.Size = new System.Drawing.Size(228, 27);
			this.txtSetor.TabIndex = 23;
			this.txtSetor.TabStop = false;
			this.txtSetor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(49, 69);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(105, 19);
			this.label5.TabIndex = 22;
			this.label5.Text = "Setor Debitado";
			// 
			// txtDespesaTipo
			// 
			this.txtDespesaTipo.Location = new System.Drawing.Point(160, 144);
			this.txtDespesaTipo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtDespesaTipo.MaxLength = 30;
			this.txtDespesaTipo.Name = "txtDespesaTipo";
			this.txtDespesaTipo.Size = new System.Drawing.Size(433, 27);
			this.txtDespesaTipo.TabIndex = 27;
			this.txtDespesaTipo.TabStop = false;
			this.txtDespesaTipo.Tag = "Pressione a tecla (+) para procurar";
			this.txtDespesaTipo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(37, 147);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(117, 19);
			this.label4.TabIndex = 26;
			this.label4.Text = "Tipo de Despesa";
			// 
			// txtCredor
			// 
			this.txtCredor.Location = new System.Drawing.Point(160, 105);
			this.txtCredor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCredor.MaxLength = 30;
			this.txtCredor.Name = "txtCredor";
			this.txtCredor.Size = new System.Drawing.Size(433, 27);
			this.txtCredor.TabIndex = 25;
			this.txtCredor.TabStop = false;
			this.txtCredor.Tag = "Pressione a tecla (+) para procurar";
			this.txtCredor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// lblContribuinte
			// 
			this.lblContribuinte.AutoSize = true;
			this.lblContribuinte.BackColor = System.Drawing.Color.Transparent;
			this.lblContribuinte.ForeColor = System.Drawing.Color.Black;
			this.lblContribuinte.Location = new System.Drawing.Point(16, 108);
			this.lblContribuinte.Name = "lblContribuinte";
			this.lblContribuinte.Size = new System.Drawing.Size(138, 19);
			this.lblContribuinte.TabIndex = 24;
			this.lblContribuinte.Text = "Credor / Fornecedor";
			// 
			// txtDespesaDescricao
			// 
			this.txtDespesaDescricao.BackColor = System.Drawing.Color.White;
			this.txtDespesaDescricao.Location = new System.Drawing.Point(160, 183);
			this.txtDespesaDescricao.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtDespesaDescricao.MaxLength = 100;
			this.txtDespesaDescricao.Name = "txtDespesaDescricao";
			this.txtDespesaDescricao.Size = new System.Drawing.Size(433, 27);
			this.txtDespesaDescricao.TabIndex = 29;
			this.txtDespesaDescricao.TabStop = false;
			this.txtDespesaDescricao.Tag = "";
			this.txtDespesaDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// lblCongregacao
			// 
			this.lblCongregacao.AutoSize = true;
			this.lblCongregacao.BackColor = System.Drawing.Color.Transparent;
			this.lblCongregacao.ForeColor = System.Drawing.Color.Black;
			this.lblCongregacao.Location = new System.Drawing.Point(81, 186);
			this.lblCongregacao.Name = "lblCongregacao";
			this.lblCongregacao.Size = new System.Drawing.Size(73, 19);
			this.lblCongregacao.TabIndex = 28;
			this.lblCongregacao.Text = "Descrição";
			// 
			// mnuOperacoes
			// 
			this.mnuOperacoes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuOperacoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemVerPagamentos,
            this.mnuImagem});
			this.mnuOperacoes.Name = "mnuOperacoes";
			this.mnuOperacoes.Size = new System.Drawing.Size(263, 56);
			// 
			// mnuItemVerPagamentos
			// 
			this.mnuItemVerPagamentos.Image = global::CamadaUI.Properties.Resources.search_page_24;
			this.mnuItemVerPagamentos.Name = "mnuItemVerPagamentos";
			this.mnuItemVerPagamentos.Size = new System.Drawing.Size(262, 26);
			this.mnuItemVerPagamentos.Text = "Ver Pagamentos | Estornar";
			this.mnuItemVerPagamentos.Click += new System.EventHandler(this.mnuItemVerPagamentos_Click);
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
			this.mnuImagem.Size = new System.Drawing.Size(262, 26);
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
			this.mnuImagemRemover.Click += new System.EventHandler(this.mnuImagemRemover_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.ForeColor = System.Drawing.Color.Black;
			this.label8.Location = new System.Drawing.Point(697, 73);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 19);
			this.label8.TabIndex = 32;
			this.label8.Text = "Valor da Atual";
			// 
			// lblDespesaValor
			// 
			this.lblDespesaValor.BackColor = System.Drawing.Color.Transparent;
			this.lblDespesaValor.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDespesaValor.ForeColor = System.Drawing.Color.Black;
			this.lblDespesaValor.Location = new System.Drawing.Point(663, 93);
			this.lblDespesaValor.Name = "lblDespesaValor";
			this.lblDespesaValor.Size = new System.Drawing.Size(174, 31);
			this.lblDespesaValor.TabIndex = 33;
			this.lblDespesaValor.Text = "R$ 0,00";
			this.lblDespesaValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(689, 147);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(118, 19);
			this.label1.TabIndex = 32;
			this.label1.Text = "Data do Ponteiro";
			// 
			// lblIniciarData
			// 
			this.lblIniciarData.BackColor = System.Drawing.Color.Transparent;
			this.lblIniciarData.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblIniciarData.ForeColor = System.Drawing.Color.Black;
			this.lblIniciarData.Location = new System.Drawing.Point(663, 167);
			this.lblIniciarData.Name = "lblIniciarData";
			this.lblIniciarData.Size = new System.Drawing.Size(174, 31);
			this.lblIniciarData.TabIndex = 33;
			this.lblIniciarData.Text = "00/00/0000";
			this.lblIniciarData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmAPagarDespesaPeriodica
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(866, 658);
			this.Controls.Add(this.lblIniciarData);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblDespesaValor);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtSetor);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtDespesaTipo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtCredor);
			this.Controls.Add(this.lblContribuinte);
			this.Controls.Add(this.txtDespesaDescricao);
			this.Controls.Add(this.lblCongregacao);
			this.Controls.Add(this.btnFechar);
			this.Controls.Add(this.btnImprimir);
			this.Controls.Add(this.dgvListagem);
			this.Name = "frmAPagarDespesaPeriodica";
			this.Activated += new System.EventHandler(this.frm_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_FormClosed);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.dgvListagem, 0);
			this.Controls.SetChildIndex(this.btnImprimir, 0);
			this.Controls.SetChildIndex(this.btnFechar, 0);
			this.Controls.SetChildIndex(this.lblCongregacao, 0);
			this.Controls.SetChildIndex(this.txtDespesaDescricao, 0);
			this.Controls.SetChildIndex(this.lblContribuinte, 0);
			this.Controls.SetChildIndex(this.txtCredor, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.txtDespesaTipo, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.txtSetor, 0);
			this.Controls.SetChildIndex(this.label8, 0);
			this.Controls.SetChildIndex(this.lblDespesaValor, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.lblIniciarData, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).EndInit();
			this.mnuOperacoes.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.DataGridView dgvListagem;
		internal System.Windows.Forms.Button btnFechar;
		internal System.Windows.Forms.Button btnImprimir;
		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label lbl_IdTexto;
		internal System.Windows.Forms.TextBox txtSetor;
		internal System.Windows.Forms.Label label5;
		internal System.Windows.Forms.TextBox txtDespesaTipo;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TextBox txtCredor;
		internal System.Windows.Forms.Label lblContribuinte;
		internal System.Windows.Forms.TextBox txtDespesaDescricao;
		internal System.Windows.Forms.Label lblCongregacao;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnID;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnVencimento;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnForma;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnSituacao;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnReferencia;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValor;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnPagamentoData;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValorPago;
		private System.Windows.Forms.ContextMenuStrip mnuOperacoes;
		private System.Windows.Forms.ToolStripMenuItem mnuItemVerPagamentos;
		private System.Windows.Forms.ToolStripMenuItem mnuImagem;
		private System.Windows.Forms.ToolStripMenuItem mnuImagemInserir;
		private System.Windows.Forms.ToolStripMenuItem mnuImagemVisualizar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem mnuImagemRemover;
		internal System.Windows.Forms.Label label8;
		internal System.Windows.Forms.Label lblDespesaValor;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Label lblIniciarData;
	}
}
