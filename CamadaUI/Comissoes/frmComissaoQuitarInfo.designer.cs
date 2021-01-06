namespace CamadaUI.Comissoes
{
	partial class frmComissaoQuitarInfo
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
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnOK = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.btnSetConta = new VIBlend.WinForms.Controls.vButton();
			this.txtConta = new System.Windows.Forms.TextBox();
			this.lblContaDetalhe = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.dtpDespesaData = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.txtObservacao = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.lblColaborador = new System.Windows.Forms.Label();
			this.lblSetor = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblValorTotal = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(291, 0);
			this.lblTitulo.Size = new System.Drawing.Size(286, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Detalhes do Pagamento";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(577, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(617, 50);
			// 
			// tspMenu
			// 
			this.tspMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tspMenu.AutoSize = false;
			this.tspMenu.BackColor = System.Drawing.Color.AntiqueWhite;
			this.tspMenu.Dock = System.Windows.Forms.DockStyle.None;
			this.tspMenu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tspMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOK,
            this.btnCancelar});
			this.tspMenu.Location = new System.Drawing.Point(2, 373);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(612, 44);
			this.tspMenu.TabIndex = 15;
			this.tspMenu.TabStop = true;
			this.tspMenu.Text = "toolStrip1";
			// 
			// btnOK
			// 
			this.btnOK.AutoSize = false;
			this.btnOK.Image = global::CamadaUI.Properties.Resources.accept_24;
			this.btnOK.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnOK.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnOK.Name = "btnOK";
			this.btnOK.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnOK.Size = new System.Drawing.Size(110, 41);
			this.btnOK.Text = "&OK";
			this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnCancelar.Image = global::CamadaUI.Properties.Resources.fechar_30;
			this.btnCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnCancelar.Size = new System.Drawing.Size(110, 41);
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// btnSetConta
			// 
			this.btnSetConta.AllowAnimations = true;
			this.btnSetConta.BackColor = System.Drawing.Color.Transparent;
			this.btnSetConta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetConta.Location = new System.Drawing.Point(488, 68);
			this.btnSetConta.Name = "btnSetConta";
			this.btnSetConta.RoundedCornersMask = ((byte)(15));
			this.btnSetConta.RoundedCornersRadius = 0;
			this.btnSetConta.Size = new System.Drawing.Size(34, 31);
			this.btnSetConta.TabIndex = 3;
			this.btnSetConta.TabStop = false;
			this.btnSetConta.Text = "...";
			this.btnSetConta.UseCompatibleTextRendering = true;
			this.btnSetConta.UseVisualStyleBackColor = false;
			this.btnSetConta.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			// 
			// txtConta
			// 
			this.txtConta.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtConta.Location = new System.Drawing.Point(167, 68);
			this.txtConta.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtConta.MaxLength = 30;
			this.txtConta.Name = "txtConta";
			this.txtConta.Size = new System.Drawing.Size(315, 31);
			this.txtConta.TabIndex = 2;
			// 
			// lblContaDetalhe
			// 
			this.lblContaDetalhe.BackColor = System.Drawing.Color.Transparent;
			this.lblContaDetalhe.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblContaDetalhe.ForeColor = System.Drawing.Color.Black;
			this.lblContaDetalhe.Location = new System.Drawing.Point(167, 103);
			this.lblContaDetalhe.Name = "lblContaDetalhe";
			this.lblContaDetalhe.Size = new System.Drawing.Size(228, 35);
			this.lblContaDetalhe.TabIndex = 4;
			this.lblContaDetalhe.Text = "Saldo da Conta: R$ 0,00\r\nData de Bloqueio até: 01/01/2000";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.BackColor = System.Drawing.Color.Transparent;
			this.label19.ForeColor = System.Drawing.Color.Black;
			this.label19.Location = new System.Drawing.Point(45, 74);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(114, 19);
			this.label19.TabIndex = 1;
			this.label19.Text = "Conta Debitada:";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dtpDespesaData
			// 
			this.dtpDespesaData.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpDespesaData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDespesaData.Location = new System.Drawing.Point(167, 278);
			this.dtpDespesaData.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.dtpDespesaData.Name = "dtpDespesaData";
			this.dtpDespesaData.Size = new System.Drawing.Size(145, 31);
			this.dtpDespesaData.TabIndex = 12;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(18, 284);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(141, 19);
			this.label3.TabIndex = 11;
			this.label3.Text = "Data do Pagamento:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtObservacao
			// 
			this.txtObservacao.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtObservacao.Location = new System.Drawing.Point(167, 323);
			this.txtObservacao.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtObservacao.Name = "txtObservacao";
			this.txtObservacao.Size = new System.Drawing.Size(355, 27);
			this.txtObservacao.TabIndex = 14;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(69, 326);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(90, 19);
			this.label20.TabIndex = 13;
			this.label20.Text = "Observação:";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblColaborador
			// 
			this.lblColaborador.BackColor = System.Drawing.Color.White;
			this.lblColaborador.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblColaborador.Location = new System.Drawing.Point(169, 149);
			this.lblColaborador.Name = "lblColaborador";
			this.lblColaborador.Size = new System.Drawing.Size(353, 29);
			this.lblColaborador.TabIndex = 6;
			this.lblColaborador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblSetor
			// 
			this.lblSetor.BackColor = System.Drawing.Color.White;
			this.lblSetor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSetor.Location = new System.Drawing.Point(169, 191);
			this.lblSetor.Name = "lblSetor";
			this.lblSetor.Size = new System.Drawing.Size(353, 29);
			this.lblSetor.TabIndex = 8;
			this.lblSetor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(113, 196);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 19);
			this.label1.TabIndex = 7;
			this.label1.Text = "Setor:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(67, 155);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 19);
			this.label2.TabIndex = 5;
			this.label2.Text = "Colaborador:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblValorTotal
			// 
			this.lblValorTotal.BackColor = System.Drawing.Color.White;
			this.lblValorTotal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValorTotal.Location = new System.Drawing.Point(169, 234);
			this.lblValorTotal.Name = "lblValorTotal";
			this.lblValorTotal.Size = new System.Drawing.Size(143, 29);
			this.lblValorTotal.TabIndex = 10;
			this.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(77, 240);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(82, 19);
			this.label5.TabIndex = 9;
			this.label5.Text = "Valor Total:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmComissaoQuitarInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(617, 420);
			this.Controls.Add(this.lblValorTotal);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lblColaborador);
			this.Controls.Add(this.lblSetor);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtObservacao);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.dtpDespesaData);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnSetConta);
			this.Controls.Add(this.txtConta);
			this.Controls.Add(this.lblContaDetalhe);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.tspMenu);
			this.KeyPreview = true;
			this.Name = "frmComissaoQuitarInfo";
			this.Activated += new System.EventHandler(this.form_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_FormClosed);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.label19, 0);
			this.Controls.SetChildIndex(this.lblContaDetalhe, 0);
			this.Controls.SetChildIndex(this.txtConta, 0);
			this.Controls.SetChildIndex(this.btnSetConta, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.dtpDespesaData, 0);
			this.Controls.SetChildIndex(this.label20, 0);
			this.Controls.SetChildIndex(this.txtObservacao, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.lblSetor, 0);
			this.Controls.SetChildIndex(this.lblColaborador, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.lblValorTotal, 0);
			this.panel1.ResumeLayout(false);
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnOK;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		internal VIBlend.WinForms.Controls.vButton btnSetConta;
		internal System.Windows.Forms.TextBox txtConta;
		internal System.Windows.Forms.Label lblContaDetalhe;
		internal System.Windows.Forms.Label label19;
		private System.Windows.Forms.DateTimePicker dtpDespesaData;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.TextBox txtObservacao;
		internal System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label lblColaborador;
		private System.Windows.Forms.Label lblSetor;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblValorTotal;
		internal System.Windows.Forms.Label label5;
	}
}
