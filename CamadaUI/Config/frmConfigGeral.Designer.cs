namespace CamadaUI.Config
{
	partial class frmConfigGeral
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
			this.btnSalvarConfig = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.pnlPastas = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.btnEditarFilial = new System.Windows.Forms.Button();
			this.txtIgrejaTitulo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnContaAdd = new System.Windows.Forms.Button();
			this.Label34 = new System.Windows.Forms.Label();
			this.btnAlteraConta = new System.Windows.Forms.Button();
			this.Label15 = new System.Windows.Forms.Label();
			this.btnFilialAdd = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.Label35 = new System.Windows.Forms.Label();
			this.btnAlteraFilial = new System.Windows.Forms.Button();
			this.dtpDataPadrao = new System.Windows.Forms.DateTimePicker();
			this.lblDataBloqueio = new System.Windows.Forms.Label();
			this.txtCongregacaoPadrao = new System.Windows.Forms.TextBox();
			this.Label22 = new System.Windows.Forms.Label();
			this.txtUFPadrao = new System.Windows.Forms.TextBox();
			this.txtCidadePadrao = new System.Windows.Forms.TextBox();
			this.txtContaPadrao = new System.Windows.Forms.TextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.pnlPastas.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.BackColor = System.Drawing.Color.SlateGray;
			this.lblTitulo.Padding = new System.Windows.Forms.Padding(20, 0, 0, 4);
			this.lblTitulo.Size = new System.Drawing.Size(704, 30);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Configuração Geral";
			// 
			// btnClose
			// 
			this.btnClose.BackColor = System.Drawing.Color.SlateGray;
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(704, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(744, 30);
			// 
			// btnSalvarConfig
			// 
			this.btnSalvarConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSalvarConfig.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.btnSalvarConfig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightYellow;
			this.btnSalvarConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			this.btnSalvarConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSalvarConfig.Image = global::CamadaUI.Properties.Resources.save_24;
			this.btnSalvarConfig.Location = new System.Drawing.Point(484, 531);
			this.btnSalvarConfig.Name = "btnSalvarConfig";
			this.btnSalvarConfig.Size = new System.Drawing.Size(121, 36);
			this.btnSalvarConfig.TabIndex = 2;
			this.btnSalvarConfig.Text = "&Salvar";
			this.btnSalvarConfig.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSalvarConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSalvarConfig.UseVisualStyleBackColor = true;
			this.btnSalvarConfig.Click += new System.EventHandler(this.btnSalvarConfig_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightYellow;
			this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancelar.Image = global::CamadaUI.Properties.Resources.delete_24;
			this.btnCancelar.Location = new System.Drawing.Point(611, 531);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(121, 36);
			this.btnCancelar.TabIndex = 3;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// pnlPastas
			// 
			this.pnlPastas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(221)))), ((int)(((byte)(234)))));
			this.pnlPastas.Controls.Add(this.label4);
			this.pnlPastas.Controls.Add(this.btnEditarFilial);
			this.pnlPastas.Controls.Add(this.txtIgrejaTitulo);
			this.pnlPastas.Controls.Add(this.label1);
			this.pnlPastas.Controls.Add(this.btnContaAdd);
			this.pnlPastas.Controls.Add(this.Label34);
			this.pnlPastas.Controls.Add(this.btnAlteraConta);
			this.pnlPastas.Controls.Add(this.Label15);
			this.pnlPastas.Controls.Add(this.btnFilialAdd);
			this.pnlPastas.Controls.Add(this.label5);
			this.pnlPastas.Controls.Add(this.label2);
			this.pnlPastas.Controls.Add(this.Label35);
			this.pnlPastas.Controls.Add(this.btnAlteraFilial);
			this.pnlPastas.Controls.Add(this.dtpDataPadrao);
			this.pnlPastas.Controls.Add(this.lblDataBloqueio);
			this.pnlPastas.Controls.Add(this.txtCongregacaoPadrao);
			this.pnlPastas.Controls.Add(this.Label22);
			this.pnlPastas.Controls.Add(this.txtUFPadrao);
			this.pnlPastas.Controls.Add(this.txtCidadePadrao);
			this.pnlPastas.Controls.Add(this.txtContaPadrao);
			this.pnlPastas.Location = new System.Drawing.Point(12, 42);
			this.pnlPastas.Name = "pnlPastas";
			this.pnlPastas.Size = new System.Drawing.Size(720, 309);
			this.pnlPastas.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(70, 53);
			this.label4.Margin = new System.Windows.Forms.Padding(0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(111, 19);
			this.label4.TabIndex = 1;
			this.label4.Text = "Título da Igreja:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnEditarFilial
			// 
			this.btnEditarFilial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(221)))), ((int)(((byte)(234)))));
			this.btnEditarFilial.FlatAppearance.BorderSize = 0;
			this.btnEditarFilial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEditarFilial.Image = global::CamadaUI.Properties.Resources.editar_16;
			this.btnEditarFilial.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnEditarFilial.Location = new System.Drawing.Point(590, 114);
			this.btnEditarFilial.Name = "btnEditarFilial";
			this.btnEditarFilial.Size = new System.Drawing.Size(81, 30);
			this.btnEditarFilial.TabIndex = 9;
			this.btnEditarFilial.TabStop = false;
			this.btnEditarFilial.Text = "Editar";
			this.btnEditarFilial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnEditarFilial.UseVisualStyleBackColor = false;
			// 
			// txtIgrejaTitulo
			// 
			this.txtIgrejaTitulo.Font = new System.Drawing.Font("Verdana", 12F);
			this.txtIgrejaTitulo.Location = new System.Drawing.Point(187, 50);
			this.txtIgrejaTitulo.Name = "txtIgrejaTitulo";
			this.txtIgrejaTitulo.Size = new System.Drawing.Size(484, 27);
			this.txtIgrejaTitulo.TabIndex = 2;
			this.txtIgrejaTitulo.Validating += new System.ComponentModel.CancelEventHandler(this.txtIgrejaTitulo_Validating);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(9, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(133, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Valores Padrão:";
			// 
			// btnContaAdd
			// 
			this.btnContaAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(221)))), ((int)(((byte)(234)))));
			this.btnContaAdd.FlatAppearance.BorderSize = 0;
			this.btnContaAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnContaAdd.Image = global::CamadaUI.Properties.Resources.add_16;
			this.btnContaAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnContaAdd.Location = new System.Drawing.Point(503, 147);
			this.btnContaAdd.Name = "btnContaAdd";
			this.btnContaAdd.Size = new System.Drawing.Size(81, 30);
			this.btnContaAdd.TabIndex = 13;
			this.btnContaAdd.TabStop = false;
			this.btnContaAdd.Text = "Nova";
			this.btnContaAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnContaAdd.UseVisualStyleBackColor = false;
			// 
			// Label34
			// 
			this.Label34.AutoSize = true;
			this.Label34.BackColor = System.Drawing.Color.Transparent;
			this.Label34.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label34.Location = new System.Drawing.Point(88, 87);
			this.Label34.Name = "Label34";
			this.Label34.Size = new System.Drawing.Size(93, 19);
			this.Label34.TabIndex = 3;
			this.Label34.Text = "Data Padrão:";
			this.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnAlteraConta
			// 
			this.btnAlteraConta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(221)))), ((int)(((byte)(234)))));
			this.btnAlteraConta.FlatAppearance.BorderSize = 0;
			this.btnAlteraConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAlteraConta.Image = global::CamadaUI.Properties.Resources.refresh_16;
			this.btnAlteraConta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAlteraConta.Location = new System.Drawing.Point(412, 147);
			this.btnAlteraConta.Name = "btnAlteraConta";
			this.btnAlteraConta.Size = new System.Drawing.Size(81, 30);
			this.btnAlteraConta.TabIndex = 12;
			this.btnAlteraConta.TabStop = false;
			this.btnAlteraConta.Text = "Alterar";
			this.btnAlteraConta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAlteraConta.UseVisualStyleBackColor = false;
			this.btnAlteraConta.Click += new System.EventHandler(this.btnAlteraConta_Click);
			// 
			// Label15
			// 
			this.Label15.AutoSize = true;
			this.Label15.BackColor = System.Drawing.Color.Transparent;
			this.Label15.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label15.Location = new System.Drawing.Point(34, 120);
			this.Label15.Name = "Label15";
			this.Label15.Size = new System.Drawing.Size(147, 19);
			this.Label15.TabIndex = 5;
			this.Label15.Text = "Congregação Padrão:";
			this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnFilialAdd
			// 
			this.btnFilialAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(221)))), ((int)(((byte)(234)))));
			this.btnFilialAdd.FlatAppearance.BorderSize = 0;
			this.btnFilialAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFilialAdd.Image = global::CamadaUI.Properties.Resources.add_16;
			this.btnFilialAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFilialAdd.Location = new System.Drawing.Point(503, 114);
			this.btnFilialAdd.Name = "btnFilialAdd";
			this.btnFilialAdd.Size = new System.Drawing.Size(81, 30);
			this.btnFilialAdd.TabIndex = 8;
			this.btnFilialAdd.TabStop = false;
			this.btnFilialAdd.Text = "Nova";
			this.btnFilialAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnFilialAdd.UseVisualStyleBackColor = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(418, 216);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(79, 19);
			this.label5.TabIndex = 18;
			this.label5.Text = "UF Padrão:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(74, 216);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(107, 19);
			this.label2.TabIndex = 16;
			this.label2.Text = "Cidade Padrão:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label35
			// 
			this.Label35.AutoSize = true;
			this.Label35.BackColor = System.Drawing.Color.Transparent;
			this.Label35.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label35.Location = new System.Drawing.Point(81, 152);
			this.Label35.Name = "Label35";
			this.Label35.Size = new System.Drawing.Size(100, 19);
			this.Label35.TabIndex = 10;
			this.Label35.Text = "Conta Padrão:";
			this.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnAlteraFilial
			// 
			this.btnAlteraFilial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(221)))), ((int)(((byte)(234)))));
			this.btnAlteraFilial.FlatAppearance.BorderSize = 0;
			this.btnAlteraFilial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAlteraFilial.Image = global::CamadaUI.Properties.Resources.refresh_16;
			this.btnAlteraFilial.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAlteraFilial.Location = new System.Drawing.Point(412, 114);
			this.btnAlteraFilial.Name = "btnAlteraFilial";
			this.btnAlteraFilial.Size = new System.Drawing.Size(81, 30);
			this.btnAlteraFilial.TabIndex = 7;
			this.btnAlteraFilial.TabStop = false;
			this.btnAlteraFilial.Text = "Alterar";
			this.btnAlteraFilial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAlteraFilial.UseVisualStyleBackColor = false;
			this.btnAlteraFilial.Click += new System.EventHandler(this.btnAlteraFilial_Click);
			// 
			// dtpDataPadrao
			// 
			this.dtpDataPadrao.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpDataPadrao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDataPadrao.Location = new System.Drawing.Point(187, 83);
			this.dtpDataPadrao.Name = "dtpDataPadrao";
			this.dtpDataPadrao.Size = new System.Drawing.Size(155, 27);
			this.dtpDataPadrao.TabIndex = 4;
			// 
			// lblDataBloqueio
			// 
			this.lblDataBloqueio.BackColor = System.Drawing.Color.Transparent;
			this.lblDataBloqueio.Location = new System.Drawing.Point(307, 179);
			this.lblDataBloqueio.Name = "lblDataBloqueio";
			this.lblDataBloqueio.Size = new System.Drawing.Size(92, 18);
			this.lblDataBloqueio.TabIndex = 15;
			this.lblDataBloqueio.Text = "01/01/2018";
			// 
			// txtCongregacaoPadrao
			// 
			this.txtCongregacaoPadrao.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCongregacaoPadrao.Location = new System.Drawing.Point(187, 116);
			this.txtCongregacaoPadrao.Name = "txtCongregacaoPadrao";
			this.txtCongregacaoPadrao.Size = new System.Drawing.Size(212, 27);
			this.txtCongregacaoPadrao.TabIndex = 6;
			this.txtCongregacaoPadrao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// Label22
			// 
			this.Label22.AutoSize = true;
			this.Label22.BackColor = System.Drawing.Color.Transparent;
			this.Label22.Location = new System.Drawing.Point(184, 179);
			this.Label22.Name = "Label22";
			this.Label22.Size = new System.Drawing.Size(117, 19);
			this.Label22.TabIndex = 14;
			this.Label22.Text = "Data Bloqueada:";
			// 
			// txtUFPadrao
			// 
			this.txtUFPadrao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtUFPadrao.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUFPadrao.Location = new System.Drawing.Point(503, 213);
			this.txtUFPadrao.MaxLength = 2;
			this.txtUFPadrao.Name = "txtUFPadrao";
			this.txtUFPadrao.Size = new System.Drawing.Size(46, 27);
			this.txtUFPadrao.TabIndex = 19;
			// 
			// txtCidadePadrao
			// 
			this.txtCidadePadrao.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCidadePadrao.Location = new System.Drawing.Point(187, 213);
			this.txtCidadePadrao.MaxLength = 50;
			this.txtCidadePadrao.Name = "txtCidadePadrao";
			this.txtCidadePadrao.Size = new System.Drawing.Size(212, 27);
			this.txtCidadePadrao.TabIndex = 17;
			// 
			// txtContaPadrao
			// 
			this.txtContaPadrao.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtContaPadrao.Location = new System.Drawing.Point(187, 149);
			this.txtContaPadrao.Name = "txtContaPadrao";
			this.txtContaPadrao.Size = new System.Drawing.Size(212, 27);
			this.txtContaPadrao.TabIndex = 11;
			this.txtContaPadrao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(221)))), ((int)(((byte)(234)))));
			this.panel3.Controls.Add(this.label3);
			this.panel3.Location = new System.Drawing.Point(12, 396);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(720, 107);
			this.panel3.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(9, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(163, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "Definição de Cores:";
			// 
			// frmConfigGeral
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(744, 579);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.pnlPastas);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnSalvarConfig);
			this.Name = "frmConfigGeral";
			this.Load += new System.EventHandler(this.frmConfigGeral_Load);
			this.Controls.SetChildIndex(this.btnSalvarConfig, 0);
			this.Controls.SetChildIndex(this.btnCancelar, 0);
			this.Controls.SetChildIndex(this.pnlPastas, 0);
			this.Controls.SetChildIndex(this.panel3, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.panel1.ResumeLayout(false);
			this.pnlPastas.ResumeLayout(false);
			this.pnlPastas.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btnSalvarConfig;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Panel pnlPastas;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtIgrejaTitulo;
		private System.Windows.Forms.Label label4;
		internal System.Windows.Forms.Button btnEditarFilial;
		internal System.Windows.Forms.Button btnContaAdd;
		internal System.Windows.Forms.Button btnAlteraConta;
		internal System.Windows.Forms.Button btnFilialAdd;
		internal System.Windows.Forms.Button btnAlteraFilial;
		internal System.Windows.Forms.Label lblDataBloqueio;
		internal System.Windows.Forms.Label Label22;
		internal System.Windows.Forms.TextBox txtContaPadrao;
		internal System.Windows.Forms.TextBox txtCongregacaoPadrao;
		internal System.Windows.Forms.DateTimePicker dtpDataPadrao;
		internal System.Windows.Forms.Label Label35;
		internal System.Windows.Forms.Label Label34;
		internal System.Windows.Forms.Label Label15;
		internal System.Windows.Forms.Label label5;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox txtUFPadrao;
		internal System.Windows.Forms.TextBox txtCidadePadrao;
	}
}
