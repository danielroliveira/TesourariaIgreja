namespace CamadaUI.Caixa
{
	partial class frmCaixa
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvListagem = new System.Windows.Forms.DataGridView();
			this.clnMovData = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnMovOrigem = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnOrigemTabela = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnIDOrigem = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValorReal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lblTTransf = new System.Windows.Forms.Label();
			this.Label11 = new System.Windows.Forms.Label();
			this.lblSaldoFinal = new System.Windows.Forms.Label();
			this.Label10 = new System.Windows.Forms.Label();
			this.lblTSaidas = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.lblSaldoAnterior = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.lblTEntradas = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.lblID = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.lblSituacao = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.lblDataFinal = new System.Windows.Forms.Label();
			this.lblDataInicial = new System.Windows.Forms.Label();
			this.lblConta = new System.Windows.Forms.Label();
			this.btnExcluirCaixa = new System.Windows.Forms.Button();
			this.btnFechar = new System.Windows.Forms.Button();
			this.btnFinalizar = new System.Windows.Forms.Button();
			this.btnAlterar = new System.Windows.Forms.Button();
			this.btnSalvarObservacao = new System.Windows.Forms.Button();
			this.txtObservacao = new System.Windows.Forms.TextBox();
			this.Label9 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(710, 0);
			this.lblTitulo.Size = new System.Drawing.Size(296, 50);
			this.lblTitulo.Text = "Fechamento de Caixa Conta";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(1006, 0);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblID);
			this.panel1.Controls.Add(this.Label6);
			this.panel1.Controls.Add(this.lbl_IdTexto);
			this.panel1.Controls.Add(this.lblSituacao);
			this.panel1.Size = new System.Drawing.Size(1046, 50);
			this.panel1.Controls.SetChildIndex(this.btnClose, 0);
			this.panel1.Controls.SetChildIndex(this.lblTitulo, 0);
			this.panel1.Controls.SetChildIndex(this.lblSituacao, 0);
			this.panel1.Controls.SetChildIndex(this.lbl_IdTexto, 0);
			this.panel1.Controls.SetChildIndex(this.Label6, 0);
			this.panel1.Controls.SetChildIndex(this.lblID, 0);
			// 
			// dgvListagem
			// 
			this.dgvListagem.AllowUserToAddRows = false;
			this.dgvListagem.AllowUserToDeleteRows = false;
			this.dgvListagem.AllowUserToResizeColumns = false;
			this.dgvListagem.AllowUserToResizeRows = false;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvListagem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvListagem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvListagem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvListagem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dgvListagem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvListagem.ColumnHeadersHeight = 33;
			this.dgvListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvListagem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnMovData,
            this.clnMovOrigem,
            this.clnOrigemTabela,
            this.clnIDOrigem,
            this.clnSetor,
            this.clnValorReal});
			this.dgvListagem.EnableHeadersVisualStyles = false;
			this.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption;
			this.dgvListagem.Location = new System.Drawing.Point(12, 122);
			this.dgvListagem.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
			this.dgvListagem.MultiSelect = false;
			this.dgvListagem.Name = "dgvListagem";
			this.dgvListagem.RowHeadersVisible = false;
			this.dgvListagem.RowHeadersWidth = 45;
			this.dgvListagem.RowTemplate.Height = 30;
			this.dgvListagem.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvListagem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgvListagem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvListagem.Size = new System.Drawing.Size(842, 394);
			this.dgvListagem.TabIndex = 6;
			// 
			// clnMovData
			// 
			this.clnMovData.HeaderText = "Data";
			this.clnMovData.Name = "clnMovData";
			// 
			// clnMovOrigem
			// 
			this.clnMovOrigem.HeaderText = "Tipo";
			this.clnMovOrigem.Name = "clnMovOrigem";
			this.clnMovOrigem.Width = 120;
			// 
			// clnOrigemTabela
			// 
			this.clnOrigemTabela.HeaderText = "Origem";
			this.clnOrigemTabela.Name = "clnOrigemTabela";
			this.clnOrigemTabela.Width = 150;
			// 
			// clnIDOrigem
			// 
			this.clnIDOrigem.HeaderText = "Reg.";
			this.clnIDOrigem.Name = "clnIDOrigem";
			// 
			// clnSetor
			// 
			this.clnSetor.HeaderText = "Setor";
			this.clnSetor.Name = "clnSetor";
			this.clnSetor.Width = 200;
			// 
			// clnValorReal
			// 
			this.clnValorReal.HeaderText = "Valor";
			this.clnValorReal.Name = "clnValorReal";
			this.clnValorReal.Width = 120;
			// 
			// lblTTransf
			// 
			this.lblTTransf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTTransf.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTTransf.ForeColor = System.Drawing.Color.DarkGreen;
			this.lblTTransf.Location = new System.Drawing.Point(723, 616);
			this.lblTTransf.Name = "lblTTransf";
			this.lblTTransf.Size = new System.Drawing.Size(121, 24);
			this.lblTTransf.TabIndex = 29;
			this.lblTTransf.Text = "R$ 0,00";
			this.lblTTransf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label11
			// 
			this.Label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Label11.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label11.Location = new System.Drawing.Point(583, 616);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(138, 24);
			this.Label11.TabIndex = 28;
			this.Label11.Text = "Transferências:";
			this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSaldoFinal
			// 
			this.lblSaldoFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSaldoFinal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSaldoFinal.Location = new System.Drawing.Point(723, 645);
			this.lblSaldoFinal.Name = "lblSaldoFinal";
			this.lblSaldoFinal.Size = new System.Drawing.Size(121, 24);
			this.lblSaldoFinal.TabIndex = 31;
			this.lblSaldoFinal.Text = "R$ 0,00";
			this.lblSaldoFinal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label10
			// 
			this.Label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Label10.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label10.Location = new System.Drawing.Point(583, 645);
			this.Label10.Name = "Label10";
			this.Label10.Size = new System.Drawing.Size(138, 24);
			this.Label10.TabIndex = 30;
			this.Label10.Text = "Saldo Final Total:";
			this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblTSaidas
			// 
			this.lblTSaidas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTSaidas.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTSaidas.ForeColor = System.Drawing.Color.DarkRed;
			this.lblTSaidas.Location = new System.Drawing.Point(723, 587);
			this.lblTSaidas.Name = "lblTSaidas";
			this.lblTSaidas.Size = new System.Drawing.Size(121, 24);
			this.lblTSaidas.TabIndex = 27;
			this.lblTSaidas.Text = "R$ 0,00";
			this.lblTSaidas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label7
			// 
			this.Label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label7.Location = new System.Drawing.Point(636, 587);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(85, 24);
			this.Label7.TabIndex = 26;
			this.Label7.Text = "Saídas:";
			this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSaldoAnterior
			// 
			this.lblSaldoAnterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSaldoAnterior.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSaldoAnterior.Location = new System.Drawing.Point(723, 529);
			this.lblSaldoAnterior.Name = "lblSaldoAnterior";
			this.lblSaldoAnterior.Size = new System.Drawing.Size(121, 24);
			this.lblSaldoAnterior.TabIndex = 23;
			this.lblSaldoAnterior.Text = "R$ 0,00";
			this.lblSaldoAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label8
			// 
			this.Label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Label8.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label8.Location = new System.Drawing.Point(583, 529);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(138, 24);
			this.Label8.TabIndex = 22;
			this.Label8.Text = "Saldo Anterior:";
			this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblTEntradas
			// 
			this.lblTEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTEntradas.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTEntradas.ForeColor = System.Drawing.Color.DarkBlue;
			this.lblTEntradas.Location = new System.Drawing.Point(723, 558);
			this.lblTEntradas.Name = "lblTEntradas";
			this.lblTEntradas.Size = new System.Drawing.Size(121, 24);
			this.lblTEntradas.TabIndex = 25;
			this.lblTEntradas.Text = "R$ 0,00";
			this.lblTEntradas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label5
			// 
			this.Label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.Location = new System.Drawing.Point(636, 558);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(85, 24);
			this.Label5.TabIndex = 24;
			this.Label5.Text = "Entradas:";
			this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblID
			// 
			this.lblID.BackColor = System.Drawing.Color.Transparent;
			this.lblID.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblID.ForeColor = System.Drawing.Color.AliceBlue;
			this.lblID.Location = new System.Drawing.Point(11, 17);
			this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblID.Name = "lblID";
			this.lblID.Size = new System.Drawing.Size(94, 30);
			this.lblID.TabIndex = 6;
			this.lblID.Text = "0001";
			this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.BackColor = System.Drawing.Color.Transparent;
			this.Label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label6.ForeColor = System.Drawing.Color.Silver;
			this.Label6.Location = new System.Drawing.Point(193, 4);
			this.Label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(63, 13);
			this.Label6.TabIndex = 9;
			this.Label6.Text = "Situação";
			this.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_IdTexto
			// 
			this.lbl_IdTexto.AutoSize = true;
			this.lbl_IdTexto.BackColor = System.Drawing.Color.Transparent;
			this.lbl_IdTexto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_IdTexto.ForeColor = System.Drawing.Color.Silver;
			this.lbl_IdTexto.Location = new System.Drawing.Point(44, 4);
			this.lbl_IdTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbl_IdTexto.Name = "lbl_IdTexto";
			this.lbl_IdTexto.Size = new System.Drawing.Size(23, 13);
			this.lbl_IdTexto.TabIndex = 7;
			this.lbl_IdTexto.Text = "id.";
			this.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblSituacao
			// 
			this.lblSituacao.BackColor = System.Drawing.Color.Transparent;
			this.lblSituacao.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSituacao.ForeColor = System.Drawing.Color.White;
			this.lblSituacao.Location = new System.Drawing.Point(133, 22);
			this.lblSituacao.Name = "lblSituacao";
			this.lblSituacao.Size = new System.Drawing.Size(186, 23);
			this.lblSituacao.TabIndex = 8;
			this.lblSituacao.Text = "Em Aberto";
			this.lblSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(143, 64);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(79, 19);
			this.Label4.TabIndex = 34;
			this.Label4.Text = "Data Final:";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Location = new System.Drawing.Point(374, 64);
			this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(51, 19);
			this.Label2.TabIndex = 36;
			this.Label2.Text = "Conta:";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(17, 64);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(87, 19);
			this.Label3.TabIndex = 32;
			this.Label3.Text = "Data Inicial:";
			// 
			// lblDataFinal
			// 
			this.lblDataFinal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDataFinal.Location = new System.Drawing.Point(143, 79);
			this.lblDataFinal.Name = "lblDataFinal";
			this.lblDataFinal.Size = new System.Drawing.Size(120, 31);
			this.lblDataFinal.TabIndex = 35;
			this.lblDataFinal.Text = "00/00/0000";
			this.lblDataFinal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblDataInicial
			// 
			this.lblDataInicial.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDataInicial.Location = new System.Drawing.Point(17, 79);
			this.lblDataInicial.Name = "lblDataInicial";
			this.lblDataInicial.Size = new System.Drawing.Size(120, 31);
			this.lblDataInicial.TabIndex = 33;
			this.lblDataInicial.Text = "00/00/0000";
			this.lblDataInicial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblConta
			// 
			this.lblConta.BackColor = System.Drawing.Color.Transparent;
			this.lblConta.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblConta.ForeColor = System.Drawing.Color.Black;
			this.lblConta.Location = new System.Drawing.Point(269, 81);
			this.lblConta.Name = "lblConta";
			this.lblConta.Size = new System.Drawing.Size(258, 27);
			this.lblConta.TabIndex = 37;
			this.lblConta.Text = "Conta";
			this.lblConta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnExcluirCaixa
			// 
			this.btnExcluirCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExcluirCaixa.BackColor = System.Drawing.Color.MistyRose;
			this.btnExcluirCaixa.FlatAppearance.BorderSize = 0;
			this.btnExcluirCaixa.Image = global::CamadaUI.Properties.Resources.delete_24;
			this.btnExcluirCaixa.Location = new System.Drawing.Point(870, 173);
			this.btnExcluirCaixa.Name = "btnExcluirCaixa";
			this.btnExcluirCaixa.Size = new System.Drawing.Size(159, 45);
			this.btnExcluirCaixa.TabIndex = 39;
			this.btnExcluirCaixa.Text = "&Excluir Caixa";
			this.btnExcluirCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnExcluirCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnExcluirCaixa.UseVisualStyleBackColor = false;
			// 
			// btnFechar
			// 
			this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFechar.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnFechar.FlatAppearance.BorderSize = 0;
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.fechar_24;
			this.btnFechar.Location = new System.Drawing.Point(870, 629);
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Size = new System.Drawing.Size(159, 45);
			this.btnFechar.TabIndex = 41;
			this.btnFechar.Text = "&Fechar";
			this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnFechar.UseVisualStyleBackColor = false;
			this.btnFechar.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnFinalizar
			// 
			this.btnFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFinalizar.BackColor = System.Drawing.Color.AliceBlue;
			this.btnFinalizar.FlatAppearance.BorderSize = 0;
			this.btnFinalizar.Image = global::CamadaUI.Properties.Resources.accept_24;
			this.btnFinalizar.Location = new System.Drawing.Point(870, 224);
			this.btnFinalizar.Name = "btnFinalizar";
			this.btnFinalizar.Size = new System.Drawing.Size(159, 63);
			this.btnFinalizar.TabIndex = 40;
			this.btnFinalizar.Text = "Finalizar &Caixa";
			this.btnFinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFinalizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnFinalizar.UseVisualStyleBackColor = false;
			// 
			// btnAlterar
			// 
			this.btnAlterar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAlterar.BackColor = System.Drawing.Color.Honeydew;
			this.btnAlterar.FlatAppearance.BorderSize = 0;
			this.btnAlterar.Image = global::CamadaUI.Properties.Resources.refresh_24;
			this.btnAlterar.Location = new System.Drawing.Point(870, 122);
			this.btnAlterar.Name = "btnAlterar";
			this.btnAlterar.Size = new System.Drawing.Size(159, 45);
			this.btnAlterar.TabIndex = 38;
			this.btnAlterar.Text = "&Alterar Período";
			this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAlterar.UseVisualStyleBackColor = false;
			// 
			// btnSalvarObservacao
			// 
			this.btnSalvarObservacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSalvarObservacao.Location = new System.Drawing.Point(147, 649);
			this.btnSalvarObservacao.Name = "btnSalvarObservacao";
			this.btnSalvarObservacao.Size = new System.Drawing.Size(157, 27);
			this.btnSalvarObservacao.TabIndex = 44;
			this.btnSalvarObservacao.Text = "Salvar Observação";
			this.btnSalvarObservacao.UseVisualStyleBackColor = true;
			// 
			// txtObservacao
			// 
			this.txtObservacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtObservacao.BackColor = System.Drawing.SystemColors.Control;
			this.txtObservacao.Location = new System.Drawing.Point(12, 547);
			this.txtObservacao.Multiline = true;
			this.txtObservacao.Name = "txtObservacao";
			this.txtObservacao.Size = new System.Drawing.Size(292, 93);
			this.txtObservacao.TabIndex = 43;
			this.txtObservacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Label9
			// 
			this.Label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Label9.AutoSize = true;
			this.Label9.Location = new System.Drawing.Point(12, 525);
			this.Label9.Name = "Label9";
			this.Label9.Size = new System.Drawing.Size(90, 19);
			this.Label9.TabIndex = 42;
			this.Label9.Text = "Observação:";
			this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmCaixa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(1046, 686);
			this.Controls.Add(this.btnSalvarObservacao);
			this.Controls.Add(this.txtObservacao);
			this.Controls.Add(this.Label9);
			this.Controls.Add(this.btnExcluirCaixa);
			this.Controls.Add(this.btnFechar);
			this.Controls.Add(this.btnFinalizar);
			this.Controls.Add(this.btnAlterar);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.lblDataFinal);
			this.Controls.Add(this.lblDataInicial);
			this.Controls.Add(this.lblConta);
			this.Controls.Add(this.lblTTransf);
			this.Controls.Add(this.Label11);
			this.Controls.Add(this.lblSaldoFinal);
			this.Controls.Add(this.Label10);
			this.Controls.Add(this.lblTSaidas);
			this.Controls.Add(this.Label7);
			this.Controls.Add(this.lblSaldoAnterior);
			this.Controls.Add(this.Label8);
			this.Controls.Add(this.lblTEntradas);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.dgvListagem);
			this.Name = "frmCaixa";
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.dgvListagem, 0);
			this.Controls.SetChildIndex(this.Label5, 0);
			this.Controls.SetChildIndex(this.lblTEntradas, 0);
			this.Controls.SetChildIndex(this.Label8, 0);
			this.Controls.SetChildIndex(this.lblSaldoAnterior, 0);
			this.Controls.SetChildIndex(this.Label7, 0);
			this.Controls.SetChildIndex(this.lblTSaidas, 0);
			this.Controls.SetChildIndex(this.Label10, 0);
			this.Controls.SetChildIndex(this.lblSaldoFinal, 0);
			this.Controls.SetChildIndex(this.Label11, 0);
			this.Controls.SetChildIndex(this.lblTTransf, 0);
			this.Controls.SetChildIndex(this.lblConta, 0);
			this.Controls.SetChildIndex(this.lblDataInicial, 0);
			this.Controls.SetChildIndex(this.lblDataFinal, 0);
			this.Controls.SetChildIndex(this.Label3, 0);
			this.Controls.SetChildIndex(this.Label2, 0);
			this.Controls.SetChildIndex(this.Label4, 0);
			this.Controls.SetChildIndex(this.btnAlterar, 0);
			this.Controls.SetChildIndex(this.btnFinalizar, 0);
			this.Controls.SetChildIndex(this.btnFechar, 0);
			this.Controls.SetChildIndex(this.btnExcluirCaixa, 0);
			this.Controls.SetChildIndex(this.Label9, 0);
			this.Controls.SetChildIndex(this.txtObservacao, 0);
			this.Controls.SetChildIndex(this.btnSalvarObservacao, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.DataGridView dgvListagem;
		internal System.Windows.Forms.Label lblTTransf;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Label lblSaldoFinal;
		internal System.Windows.Forms.Label Label10;
		internal System.Windows.Forms.Label lblTSaidas;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.Label lblSaldoAnterior;
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.Label lblTEntradas;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label lbl_IdTexto;
		internal System.Windows.Forms.Label lblSituacao;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label lblDataFinal;
		internal System.Windows.Forms.Label lblDataInicial;
		internal System.Windows.Forms.Label lblConta;
		internal System.Windows.Forms.Button btnExcluirCaixa;
		internal System.Windows.Forms.Button btnFechar;
		internal System.Windows.Forms.Button btnFinalizar;
		internal System.Windows.Forms.Button btnAlterar;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnMovData;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnMovOrigem;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnOrigemTabela;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnIDOrigem;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnSetor;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValorReal;
		internal System.Windows.Forms.Button btnSalvarObservacao;
		internal System.Windows.Forms.TextBox txtObservacao;
		internal System.Windows.Forms.Label Label9;
	}
}
