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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.label19 = new System.Windows.Forms.Label();
			this.lblDataFinalLabel = new System.Windows.Forms.Label();
			this.lblDataInicial = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnEfetuar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lblSetor = new System.Windows.Forms.Label();
			this.lblTaxa = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lblSomaTotal = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgvListagem = new System.Windows.Forms.DataGridView();
			this.clnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnData = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnConta = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValorRecebido = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lblColaborador = new System.Windows.Forms.Label();
			this.lblDataFinal = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(372, 0);
			this.lblTitulo.Size = new System.Drawing.Size(283, 50);
			this.lblTitulo.Text = "Comissão de Colaborador";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(655, 0);
			this.btnClose.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(695, 50);
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.BackColor = System.Drawing.Color.Transparent;
			this.label19.ForeColor = System.Drawing.Color.Black;
			this.label19.Location = new System.Drawing.Point(24, 75);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(92, 19);
			this.label19.TabIndex = 6;
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
			this.lblDataFinalLabel.TabIndex = 6;
			this.lblDataFinalLabel.Text = "Data Final:";
			// 
			// lblDataInicial
			// 
			this.lblDataInicial.BackColor = System.Drawing.Color.Gainsboro;
			this.lblDataInicial.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDataInicial.Location = new System.Drawing.Point(122, 162);
			this.lblDataInicial.Name = "lblDataInicial";
			this.lblDataInicial.Size = new System.Drawing.Size(127, 29);
			this.lblDataInicial.TabIndex = 11;
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
			this.label3.TabIndex = 6;
			this.label3.Text = "Data Inicial:";
			// 
			// btnEfetuar
			// 
			this.btnEfetuar.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnEfetuar.Enabled = false;
			this.btnEfetuar.Image = global::CamadaUI.Properties.Resources.accept_24;
			this.btnEfetuar.Location = new System.Drawing.Point(213, 7);
			this.btnEfetuar.Name = "btnEfetuar";
			this.btnEfetuar.Size = new System.Drawing.Size(120, 48);
			this.btnEfetuar.TabIndex = 17;
			this.btnEfetuar.Text = "&Efetuar";
			this.btnEfetuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnEfetuar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnEfetuar.UseVisualStyleBackColor = true;
			this.btnEfetuar.Click += new System.EventHandler(this.btnEfetuar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnCancelar.Image = global::CamadaUI.Properties.Resources.fechar_24;
			this.btnCancelar.Location = new System.Drawing.Point(343, 7);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(120, 48);
			this.btnCancelar.TabIndex = 18;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(68, 120);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 19);
			this.label1.TabIndex = 6;
			this.label1.Text = "Setor:";
			// 
			// lblSetor
			// 
			this.lblSetor.BackColor = System.Drawing.Color.Gainsboro;
			this.lblSetor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSetor.Location = new System.Drawing.Point(122, 117);
			this.lblSetor.Name = "lblSetor";
			this.lblSetor.Size = new System.Drawing.Size(353, 29);
			this.lblSetor.TabIndex = 11;
			this.lblSetor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTaxa
			// 
			this.lblTaxa.BackColor = System.Drawing.Color.Gainsboro;
			this.lblTaxa.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTaxa.Location = new System.Drawing.Point(116, 559);
			this.lblTaxa.Name = "lblTaxa";
			this.lblTaxa.Size = new System.Drawing.Size(151, 29);
			this.lblTaxa.TabIndex = 22;
			this.lblTaxa.Text = "0,00%";
			this.lblTaxa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(65, 564);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(43, 19);
			this.label5.TabIndex = 21;
			this.label5.Text = "Taxa:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.ForeColor = System.Drawing.Color.Black;
			this.label7.Location = new System.Drawing.Point(312, 565);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(166, 19);
			this.label7.TabIndex = 6;
			this.label7.Text = "Valor das Contribuições:";
			// 
			// lblSomaTotal
			// 
			this.lblSomaTotal.BackColor = System.Drawing.Color.Gainsboro;
			this.lblSomaTotal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSomaTotal.Location = new System.Drawing.Point(486, 559);
			this.lblSomaTotal.Name = "lblSomaTotal";
			this.lblSomaTotal.Size = new System.Drawing.Size(151, 29);
			this.lblSomaTotal.TabIndex = 11;
			this.lblSomaTotal.Text = "R$ 0,00";
			this.lblSomaTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
			this.panel2.Controls.Add(this.btnCancelar);
			this.panel2.Controls.Add(this.btnEfetuar);
			this.panel2.Location = new System.Drawing.Point(2, 610);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(691, 62);
			this.panel2.TabIndex = 23;
			// 
			// dgvListagem
			// 
			this.dgvListagem.AllowUserToAddRows = false;
			this.dgvListagem.AllowUserToDeleteRows = false;
			this.dgvListagem.AllowUserToResizeColumns = false;
			this.dgvListagem.AllowUserToResizeRows = false;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.OldLace;
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
			this.dgvListagem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvListagem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvListagem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvListagem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvListagem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
			this.dgvListagem.Location = new System.Drawing.Point(12, 217);
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
			this.dgvListagem.Size = new System.Drawing.Size(671, 320);
			this.dgvListagem.TabIndex = 24;
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
			this.lblColaborador.BackColor = System.Drawing.Color.Gainsboro;
			this.lblColaborador.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblColaborador.Location = new System.Drawing.Point(122, 71);
			this.lblColaborador.Name = "lblColaborador";
			this.lblColaborador.Size = new System.Drawing.Size(353, 29);
			this.lblColaborador.TabIndex = 11;
			this.lblColaborador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblDataFinal
			// 
			this.lblDataFinal.BackColor = System.Drawing.Color.Gainsboro;
			this.lblDataFinal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDataFinal.Location = new System.Drawing.Point(348, 162);
			this.lblDataFinal.Name = "lblDataFinal";
			this.lblDataFinal.Size = new System.Drawing.Size(127, 29);
			this.lblDataFinal.TabIndex = 11;
			this.lblDataFinal.Text = "00/00/0000";
			this.lblDataFinal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmComissao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(695, 674);
			this.Controls.Add(this.dgvListagem);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lblTaxa);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lblColaborador);
			this.Controls.Add(this.lblSetor);
			this.Controls.Add(this.lblSomaTotal);
			this.Controls.Add(this.lblDataFinal);
			this.Controls.Add(this.lblDataInicial);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblDataFinalLabel);
			this.Controls.Add(this.label19);
			this.KeyPreview = true;
			this.Name = "frmComissao";
			this.Controls.SetChildIndex(this.label19, 0);
			this.Controls.SetChildIndex(this.lblDataFinalLabel, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label7, 0);
			this.Controls.SetChildIndex(this.lblDataInicial, 0);
			this.Controls.SetChildIndex(this.lblDataFinal, 0);
			this.Controls.SetChildIndex(this.lblSomaTotal, 0);
			this.Controls.SetChildIndex(this.lblSetor, 0);
			this.Controls.SetChildIndex(this.lblColaborador, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.lblTaxa, 0);
			this.Controls.SetChildIndex(this.panel2, 0);
			this.Controls.SetChildIndex(this.dgvListagem, 0);
			this.panel1.ResumeLayout(false);
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
		internal System.Windows.Forms.Button btnCancelar;
		internal System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblSetor;
		private System.Windows.Forms.Label lblTaxa;
		internal System.Windows.Forms.Label label5;
		internal System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblSomaTotal;
		private System.Windows.Forms.Panel panel2;
		internal System.Windows.Forms.DataGridView dgvListagem;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnID;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnData;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnConta;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnTipo;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValorRecebido;
		private System.Windows.Forms.Label lblColaborador;
		private System.Windows.Forms.Label lblDataFinal;
	}
}
