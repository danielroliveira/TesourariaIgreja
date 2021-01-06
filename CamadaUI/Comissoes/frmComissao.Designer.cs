namespace CamadaUI.Comissoes
{
	partial class frmComissao
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.label19 = new System.Windows.Forms.Label();
			this.lblDataFinalLabel = new System.Windows.Forms.Label();
			this.lblDataInicial = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnEfetuar = new System.Windows.Forms.Button();
			this.btnFechar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lblSetor = new System.Windows.Forms.Label();
			this.lblComissaoTaxa = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lblValorContribuicoes = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnRecibo = new System.Windows.Forms.Button();
			this.dgvListagem = new System.Windows.Forms.DataGridView();
			this.clnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnData = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnConta = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValorRecebido = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lblColaborador = new System.Windows.Forms.Label();
			this.lblDataFinal = new System.Windows.Forms.Label();
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblValorDescontado = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lblValorComissao = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblSituacao = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(843, 0);
			this.lblTitulo.Size = new System.Drawing.Size(283, 50);
			this.lblTitulo.TabIndex = 4;
			this.lblTitulo.Text = "Comissão de Colaborador";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(1126, 0);
			this.btnClose.TabIndex = 5;
			this.btnClose.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.lblSituacao);
			this.panel1.Controls.Add(this.lblID);
			this.panel1.Controls.Add(this.lbl_IdTexto);
			this.panel1.Size = new System.Drawing.Size(1166, 50);
			this.panel1.Controls.SetChildIndex(this.btnClose, 0);
			this.panel1.Controls.SetChildIndex(this.lblTitulo, 0);
			this.panel1.Controls.SetChildIndex(this.lbl_IdTexto, 0);
			this.panel1.Controls.SetChildIndex(this.lblID, 0);
			this.panel1.Controls.SetChildIndex(this.lblSituacao, 0);
			this.panel1.Controls.SetChildIndex(this.label4, 0);
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.BackColor = System.Drawing.Color.Transparent;
			this.label19.ForeColor = System.Drawing.Color.Black;
			this.label19.Location = new System.Drawing.Point(24, 75);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(92, 19);
			this.label19.TabIndex = 1;
			this.label19.Text = "Colaborador:";
			// 
			// lblDataFinalLabel
			// 
			this.lblDataFinalLabel.AutoSize = true;
			this.lblDataFinalLabel.BackColor = System.Drawing.Color.Transparent;
			this.lblDataFinalLabel.ForeColor = System.Drawing.Color.Black;
			this.lblDataFinalLabel.Location = new System.Drawing.Point(263, 167);
			this.lblDataFinalLabel.Name = "lblDataFinalLabel";
			this.lblDataFinalLabel.Size = new System.Drawing.Size(79, 19);
			this.lblDataFinalLabel.TabIndex = 8;
			this.lblDataFinalLabel.Text = "Data Final:";
			// 
			// lblDataInicial
			// 
			this.lblDataInicial.BackColor = System.Drawing.Color.White;
			this.lblDataInicial.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDataInicial.Location = new System.Drawing.Point(122, 162);
			this.lblDataInicial.Name = "lblDataInicial";
			this.lblDataInicial.Size = new System.Drawing.Size(127, 29);
			this.lblDataInicial.TabIndex = 6;
			this.lblDataInicial.Text = "00/00/0000";
			this.lblDataInicial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(27, 166);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 19);
			this.label3.TabIndex = 5;
			this.label3.Text = "Data Inicial:";
			// 
			// btnEfetuar
			// 
			this.btnEfetuar.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnEfetuar.Image = global::CamadaUI.Properties.Resources.accept_24;
			this.btnEfetuar.Location = new System.Drawing.Point(424, 7);
			this.btnEfetuar.Name = "btnEfetuar";
			this.btnEfetuar.Size = new System.Drawing.Size(158, 48);
			this.btnEfetuar.TabIndex = 0;
			this.btnEfetuar.Text = "&Efetuar";
			this.btnEfetuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnEfetuar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnEfetuar.UseVisualStyleBackColor = true;
			this.btnEfetuar.Click += new System.EventHandler(this.btnEfetuar_Click);
			// 
			// btnFechar
			// 
			this.btnFechar.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.fechar_24;
			this.btnFechar.Location = new System.Drawing.Point(590, 7);
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Size = new System.Drawing.Size(158, 48);
			this.btnFechar.TabIndex = 1;
			this.btnFechar.Text = "&Fechar";
			this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnFechar.UseVisualStyleBackColor = true;
			this.btnFechar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(68, 120);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 19);
			this.label1.TabIndex = 3;
			this.label1.Text = "Setor:";
			// 
			// lblSetor
			// 
			this.lblSetor.BackColor = System.Drawing.Color.White;
			this.lblSetor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSetor.Location = new System.Drawing.Point(122, 117);
			this.lblSetor.Name = "lblSetor";
			this.lblSetor.Size = new System.Drawing.Size(353, 29);
			this.lblSetor.TabIndex = 4;
			this.lblSetor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblComissaoTaxa
			// 
			this.lblComissaoTaxa.BackColor = System.Drawing.Color.White;
			this.lblComissaoTaxa.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblComissaoTaxa.Location = new System.Drawing.Point(234, 341);
			this.lblComissaoTaxa.Name = "lblComissaoTaxa";
			this.lblComissaoTaxa.Size = new System.Drawing.Size(151, 29);
			this.lblComissaoTaxa.TabIndex = 15;
			this.lblComissaoTaxa.Text = "0,00%";
			this.lblComissaoTaxa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(96, 347);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(130, 19);
			this.label5.TabIndex = 14;
			this.label5.Text = "Taxa da Comissão:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.ForeColor = System.Drawing.Color.Black;
			this.label7.Location = new System.Drawing.Point(60, 267);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(166, 19);
			this.label7.TabIndex = 10;
			this.label7.Text = "Valor das Contribuições:";
			// 
			// lblValorContribuicoes
			// 
			this.lblValorContribuicoes.BackColor = System.Drawing.Color.White;
			this.lblValorContribuicoes.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorContribuicoes.Location = new System.Drawing.Point(234, 261);
			this.lblValorContribuicoes.Name = "lblValorContribuicoes";
			this.lblValorContribuicoes.Size = new System.Drawing.Size(151, 29);
			this.lblValorContribuicoes.TabIndex = 11;
			this.lblValorContribuicoes.Text = "R$ 0,00";
			this.lblValorContribuicoes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
			this.panel2.Controls.Add(this.btnFechar);
			this.panel2.Controls.Add(this.btnRecibo);
			this.panel2.Controls.Add(this.btnEfetuar);
			this.panel2.Location = new System.Drawing.Point(2, 425);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1162, 62);
			this.panel2.TabIndex = 19;
			// 
			// btnRecibo
			// 
			this.btnRecibo.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnRecibo.Image = global::CamadaUI.Properties.Resources.imprimir_24;
			this.btnRecibo.Location = new System.Drawing.Point(967, 7);
			this.btnRecibo.Name = "btnRecibo";
			this.btnRecibo.Size = new System.Drawing.Size(185, 48);
			this.btnRecibo.TabIndex = 2;
			this.btnRecibo.Text = "&Imprimir Recibo";
			this.btnRecibo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnRecibo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnRecibo.UseVisualStyleBackColor = true;
			this.btnRecibo.Visible = false;
			this.btnRecibo.Click += new System.EventHandler(this.btnRecibo_Click);
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
            this.clnData,
            this.clnConta,
            this.clnTipo,
            this.clnValorRecebido});
			this.dgvListagem.EnableHeadersVisualStyles = false;
			this.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption;
			this.dgvListagem.Location = new System.Drawing.Point(494, 72);
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
			this.dgvListagem.Size = new System.Drawing.Size(660, 338);
			this.dgvListagem.TabIndex = 18;
			this.dgvListagem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListagem_KeyDown);
			// 
			// clnID
			// 
			this.clnID.HeaderText = "Reg.";
			this.clnID.Name = "clnID";
			this.clnID.ReadOnly = true;
			this.clnID.Width = 60;
			// 
			// clnData
			// 
			this.clnData.HeaderText = "Data";
			this.clnData.Name = "clnData";
			this.clnData.ReadOnly = true;
			this.clnData.Width = 85;
			// 
			// clnConta
			// 
			this.clnConta.HeaderText = "Conta de Entrada";
			this.clnConta.Name = "clnConta";
			this.clnConta.ReadOnly = true;
			this.clnConta.Width = 200;
			// 
			// clnTipo
			// 
			this.clnTipo.HeaderText = "Tipo de Contribuição";
			this.clnTipo.Name = "clnTipo";
			this.clnTipo.ReadOnly = true;
			this.clnTipo.Width = 170;
			// 
			// clnValorRecebido
			// 
			this.clnValorRecebido.HeaderText = "Vl Recebido";
			this.clnValorRecebido.Name = "clnValorRecebido";
			this.clnValorRecebido.ReadOnly = true;
			// 
			// lblColaborador
			// 
			this.lblColaborador.BackColor = System.Drawing.Color.White;
			this.lblColaborador.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblColaborador.Location = new System.Drawing.Point(122, 71);
			this.lblColaborador.Name = "lblColaborador";
			this.lblColaborador.Size = new System.Drawing.Size(353, 29);
			this.lblColaborador.TabIndex = 2;
			this.lblColaborador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblDataFinal
			// 
			this.lblDataFinal.BackColor = System.Drawing.Color.White;
			this.lblDataFinal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDataFinal.Location = new System.Drawing.Point(348, 162);
			this.lblDataFinal.Name = "lblDataFinal";
			this.lblDataFinal.Size = new System.Drawing.Size(127, 29);
			this.lblDataFinal.TabIndex = 7;
			this.lblDataFinal.Text = "00/00/0000";
			this.lblDataFinal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblID
			// 
			this.lblID.BackColor = System.Drawing.Color.Transparent;
			this.lblID.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblID.ForeColor = System.Drawing.Color.AliceBlue;
			this.lblID.Location = new System.Drawing.Point(8, 17);
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
			this.lbl_IdTexto.ForeColor = System.Drawing.Color.Silver;
			this.lbl_IdTexto.Location = new System.Drawing.Point(35, 4);
			this.lbl_IdTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbl_IdTexto.Name = "lbl_IdTexto";
			this.lbl_IdTexto.Size = new System.Drawing.Size(35, 13);
			this.lbl_IdTexto.TabIndex = 1;
			this.lbl_IdTexto.Text = "Reg.";
			this.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(81, 306);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(145, 19);
			this.label2.TabIndex = 12;
			this.label2.Text = "Valor dos Descontos:";
			// 
			// lblValorDescontado
			// 
			this.lblValorDescontado.BackColor = System.Drawing.Color.White;
			this.lblValorDescontado.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorDescontado.Location = new System.Drawing.Point(234, 300);
			this.lblValorDescontado.Name = "lblValorDescontado";
			this.lblValorDescontado.Size = new System.Drawing.Size(151, 29);
			this.lblValorDescontado.TabIndex = 13;
			this.lblValorDescontado.Text = "R$ 0,00";
			this.lblValorDescontado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.SlateGray;
			this.label6.Location = new System.Drawing.Point(146, 216);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(236, 29);
			this.label6.TabIndex = 9;
			this.label6.Text = "Resultado do Período:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.ForeColor = System.Drawing.Color.Black;
			this.label8.Location = new System.Drawing.Point(93, 387);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(133, 19);
			this.label8.TabIndex = 16;
			this.label8.Text = "Valor da Comissão:";
			// 
			// lblValorComissao
			// 
			this.lblValorComissao.BackColor = System.Drawing.Color.White;
			this.lblValorComissao.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorComissao.Location = new System.Drawing.Point(234, 381);
			this.lblValorComissao.Name = "lblValorComissao";
			this.lblValorComissao.Size = new System.Drawing.Size(151, 29);
			this.lblValorComissao.TabIndex = 17;
			this.lblValorComissao.Text = "R$ 0,00";
			this.lblValorComissao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.Silver;
			this.label4.Location = new System.Drawing.Point(193, 4);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Situação";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblSituacao
			// 
			this.lblSituacao.BackColor = System.Drawing.Color.Transparent;
			this.lblSituacao.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSituacao.ForeColor = System.Drawing.Color.White;
			this.lblSituacao.Location = new System.Drawing.Point(133, 21);
			this.lblSituacao.Name = "lblSituacao";
			this.lblSituacao.Size = new System.Drawing.Size(186, 23);
			this.lblSituacao.TabIndex = 3;
			this.lblSituacao.Text = "Em Aberto";
			this.lblSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmComissao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(1166, 489);
			this.Controls.Add(this.dgvListagem);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lblValorComissao);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.lblComissaoTaxa);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lblColaborador);
			this.Controls.Add(this.lblSetor);
			this.Controls.Add(this.lblValorDescontado);
			this.Controls.Add(this.lblValorContribuicoes);
			this.Controls.Add(this.lblDataFinal);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblDataInicial);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblDataFinalLabel);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label19);
			this.KeyPreview = true;
			this.Name = "frmComissao";
			this.Controls.SetChildIndex(this.label19, 0);
			this.Controls.SetChildIndex(this.label6, 0);
			this.Controls.SetChildIndex(this.lblDataFinalLabel, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label7, 0);
			this.Controls.SetChildIndex(this.lblDataInicial, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.lblDataFinal, 0);
			this.Controls.SetChildIndex(this.lblValorContribuicoes, 0);
			this.Controls.SetChildIndex(this.lblValorDescontado, 0);
			this.Controls.SetChildIndex(this.lblSetor, 0);
			this.Controls.SetChildIndex(this.lblColaborador, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.lblComissaoTaxa, 0);
			this.Controls.SetChildIndex(this.label8, 0);
			this.Controls.SetChildIndex(this.lblValorComissao, 0);
			this.Controls.SetChildIndex(this.panel2, 0);
			this.Controls.SetChildIndex(this.dgvListagem, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal System.Windows.Forms.Label label19;
		internal System.Windows.Forms.Label lblDataFinalLabel;
		private System.Windows.Forms.Label lblDataInicial;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.Button btnEfetuar;
		internal System.Windows.Forms.Button btnFechar;
		internal System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblSetor;
		private System.Windows.Forms.Label lblComissaoTaxa;
		internal System.Windows.Forms.Label label5;
		internal System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblValorContribuicoes;
		private System.Windows.Forms.Panel panel2;
		internal System.Windows.Forms.DataGridView dgvListagem;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnID;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnData;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnConta;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnTipo;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValorRecebido;
		private System.Windows.Forms.Label lblColaborador;
		private System.Windows.Forms.Label lblDataFinal;
		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label lbl_IdTexto;
		internal System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblValorDescontado;
		internal System.Windows.Forms.Label label6;
		internal System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblValorComissao;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.Label lblSituacao;
		internal System.Windows.Forms.Button btnRecibo;
	}
}
