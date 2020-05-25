﻿namespace CamadaUI.APagar
{
	partial class frmAPagarQuitar
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
			this.lblDespesaDescricao = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label11 = new System.Windows.Forms.Label();
			this.lblCredor = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtObservacao = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.lblSaidaValor = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.txtSaidaDia = new CamadaUC.ucOnlyNumbers();
			this.txtSaidaAno = new CamadaUC.ucOnlyNumbers();
			this.cmbSaidaMes = new CamadaUC.ucComboLimitedValues();
			this.btnSetConta = new VIBlend.WinForms.Controls.vButton();
			this.btnSetSetor = new VIBlend.WinForms.Controls.vButton();
			this.txtConta = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.txtSetor = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.v = new AwesomeShapeControl.Line();
			this.btnQuitar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.ucOnlyNumbers1 = new CamadaUC.ucOnlyNumbers();
			this.ucOnlyNumbers2 = new CamadaUC.ucOnlyNumbers();
			this.line1 = new AwesomeShapeControl.Line();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(243, 0);
			this.lblTitulo.Size = new System.Drawing.Size(193, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "Quitar - A Pagar";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(436, 0);
			this.btnClose.TabIndex = 3;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(476, 50);
			// 
			// lblDespesaDescricao
			// 
			this.lblDespesaDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDespesaDescricao.BackColor = System.Drawing.Color.Transparent;
			this.lblDespesaDescricao.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDespesaDescricao.Location = new System.Drawing.Point(92, 6);
			this.lblDespesaDescricao.Name = "lblDespesaDescricao";
			this.lblDespesaDescricao.Size = new System.Drawing.Size(348, 27);
			this.lblDespesaDescricao.TabIndex = 1;
			this.lblDespesaDescricao.Text = "Descrição da Despesa";
			this.lblDespesaDescricao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
			this.panel2.Controls.Add(this.label11);
			this.panel2.Controls.Add(this.lblCredor);
			this.panel2.Controls.Add(this.label10);
			this.panel2.Controls.Add(this.lblDespesaDescricao);
			this.panel2.Location = new System.Drawing.Point(12, 60);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(453, 64);
			this.panel2.TabIndex = 21;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.Transparent;
			this.label11.ForeColor = System.Drawing.Color.DarkGray;
			this.label11.Location = new System.Drawing.Point(9, 9);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(77, 19);
			this.label11.TabIndex = 2;
			this.label11.Text = "Descrição:";
			// 
			// lblCredor
			// 
			this.lblCredor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCredor.BackColor = System.Drawing.Color.Transparent;
			this.lblCredor.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCredor.Location = new System.Drawing.Point(91, 33);
			this.lblCredor.Name = "lblCredor";
			this.lblCredor.Size = new System.Drawing.Size(349, 27);
			this.lblCredor.TabIndex = 1;
			this.lblCredor.Text = "Credor";
			this.lblCredor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.ForeColor = System.Drawing.Color.DarkGray;
			this.label10.Location = new System.Drawing.Point(30, 36);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 19);
			this.label10.TabIndex = 2;
			this.label10.Text = "Credor:";
			// 
			// txtObservacao
			// 
			this.txtObservacao.Location = new System.Drawing.Point(162, 436);
			this.txtObservacao.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtObservacao.Multiline = true;
			this.txtObservacao.Name = "txtObservacao";
			this.txtObservacao.Size = new System.Drawing.Size(258, 54);
			this.txtObservacao.TabIndex = 33;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(66, 436);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(90, 19);
			this.label20.TabIndex = 32;
			this.label20.Text = "Observação:";
			// 
			// lblSaidaValor
			// 
			this.lblSaidaValor.BackColor = System.Drawing.Color.Transparent;
			this.lblSaidaValor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSaidaValor.Location = new System.Drawing.Point(162, 393);
			this.lblSaidaValor.Name = "lblSaidaValor";
			this.lblSaidaValor.Size = new System.Drawing.Size(150, 31);
			this.lblSaidaValor.TabIndex = 31;
			this.lblSaidaValor.Text = "R$ 0,00";
			this.lblSaidaValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(38, 397);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(118, 19);
			this.label21.TabIndex = 30;
			this.label21.Text = "Valor a ser Pago:";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(77, 355);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(80, 19);
			this.label22.TabIndex = 29;
			this.label22.Text = "Acréscimo:";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(89, 312);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(68, 19);
			this.label23.TabIndex = 28;
			this.label23.Text = "Do Valor:";
			// 
			// txtSaidaDia
			// 
			this.txtSaidaDia.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSaidaDia.Inteiro = true;
			this.txtSaidaDia.Location = new System.Drawing.Point(104, 263);
			this.txtSaidaDia.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtSaidaDia.Name = "txtSaidaDia";
			this.txtSaidaDia.Positivo = true;
			this.txtSaidaDia.Size = new System.Drawing.Size(52, 31);
			this.txtSaidaDia.TabIndex = 42;
			this.txtSaidaDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtSaidaAno
			// 
			this.txtSaidaAno.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSaidaAno.Inteiro = true;
			this.txtSaidaAno.Location = new System.Drawing.Point(318, 263);
			this.txtSaidaAno.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtSaidaAno.Name = "txtSaidaAno";
			this.txtSaidaAno.Positivo = true;
			this.txtSaidaAno.Size = new System.Drawing.Size(63, 31);
			this.txtSaidaAno.TabIndex = 44;
			this.txtSaidaAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cmbSaidaMes
			// 
			this.cmbSaidaMes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbSaidaMes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbSaidaMes.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbSaidaMes.FormattingEnabled = true;
			this.cmbSaidaMes.Location = new System.Drawing.Point(162, 263);
			this.cmbSaidaMes.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.cmbSaidaMes.Name = "cmbSaidaMes";
			this.cmbSaidaMes.Size = new System.Drawing.Size(150, 31);
			this.cmbSaidaMes.TabIndex = 43;
			// 
			// btnSetConta
			// 
			this.btnSetConta.AllowAnimations = true;
			this.btnSetConta.BackColor = System.Drawing.Color.Transparent;
			this.btnSetConta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetConta.Location = new System.Drawing.Point(387, 137);
			this.btnSetConta.Name = "btnSetConta";
			this.btnSetConta.RoundedCornersMask = ((byte)(15));
			this.btnSetConta.RoundedCornersRadius = 0;
			this.btnSetConta.Size = new System.Drawing.Size(34, 27);
			this.btnSetConta.TabIndex = 36;
			this.btnSetConta.TabStop = false;
			this.btnSetConta.Text = "...";
			this.btnSetConta.UseCompatibleTextRendering = true;
			this.btnSetConta.UseVisualStyleBackColor = false;
			this.btnSetConta.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			// 
			// btnSetSetor
			// 
			this.btnSetSetor.AllowAnimations = true;
			this.btnSetSetor.BackColor = System.Drawing.Color.Transparent;
			this.btnSetSetor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetSetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetSetor.Location = new System.Drawing.Point(387, 176);
			this.btnSetSetor.Name = "btnSetSetor";
			this.btnSetSetor.RoundedCornersMask = ((byte)(15));
			this.btnSetSetor.RoundedCornersRadius = 0;
			this.btnSetSetor.Size = new System.Drawing.Size(34, 27);
			this.btnSetSetor.TabIndex = 39;
			this.btnSetSetor.TabStop = false;
			this.btnSetSetor.Text = "...";
			this.btnSetSetor.UseCompatibleTextRendering = true;
			this.btnSetSetor.UseVisualStyleBackColor = false;
			this.btnSetSetor.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			// 
			// txtConta
			// 
			this.txtConta.Location = new System.Drawing.Point(153, 137);
			this.txtConta.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtConta.MaxLength = 30;
			this.txtConta.Name = "txtConta";
			this.txtConta.Size = new System.Drawing.Size(228, 27);
			this.txtConta.TabIndex = 35;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.BackColor = System.Drawing.Color.Transparent;
			this.label19.ForeColor = System.Drawing.Color.Black;
			this.label19.Location = new System.Drawing.Point(37, 140);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(110, 19);
			this.label19.TabIndex = 34;
			this.label19.Text = "Conta Debitada";
			// 
			// txtSetor
			// 
			this.txtSetor.Location = new System.Drawing.Point(153, 176);
			this.txtSetor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtSetor.MaxLength = 30;
			this.txtSetor.Name = "txtSetor";
			this.txtSetor.Size = new System.Drawing.Size(228, 27);
			this.txtSetor.TabIndex = 38;
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.BackColor = System.Drawing.Color.Transparent;
			this.label25.ForeColor = System.Drawing.Color.Black;
			this.label25.Location = new System.Drawing.Point(41, 179);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(105, 19);
			this.label25.TabIndex = 37;
			this.label25.Text = "Setor Debitado";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.BackColor = System.Drawing.Color.Transparent;
			this.label26.ForeColor = System.Drawing.Color.Black;
			this.label26.Location = new System.Drawing.Point(100, 241);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(99, 19);
			this.label26.TabIndex = 41;
			this.label26.Text = "Data da Saída";
			// 
			// v
			// 
			this.v.EndPoint = new System.Drawing.Point(452, 5);
			this.v.LineColor = System.Drawing.Color.SlateGray;
			this.v.LineWidth = 3F;
			this.v.Location = new System.Drawing.Point(25, 219);
			this.v.Name = "v";
			this.v.Size = new System.Drawing.Size(420, 10);
			this.v.StartPoint = new System.Drawing.Point(5, 5);
			this.v.TabIndex = 40;
			this.v.TabStop = false;
			// 
			// btnQuitar
			// 
			this.btnQuitar.Image = global::CamadaUI.Properties.Resources.money_red_32;
			this.btnQuitar.Location = new System.Drawing.Point(121, 522);
			this.btnQuitar.Name = "btnQuitar";
			this.btnQuitar.Size = new System.Drawing.Size(120, 49);
			this.btnQuitar.TabIndex = 45;
			this.btnQuitar.Text = "&Quitar";
			this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnQuitar.UseVisualStyleBackColor = true;
			// 
			// btnCancelar
			// 
			this.btnCancelar.Image = global::CamadaUI.Properties.Resources.fechar_24;
			this.btnCancelar.Location = new System.Drawing.Point(251, 522);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(120, 49);
			this.btnCancelar.TabIndex = 46;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancelar.UseVisualStyleBackColor = true;
			// 
			// ucOnlyNumbers1
			// 
			this.ucOnlyNumbers1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ucOnlyNumbers1.Inteiro = false;
			this.ucOnlyNumbers1.Location = new System.Drawing.Point(162, 306);
			this.ucOnlyNumbers1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.ucOnlyNumbers1.Name = "ucOnlyNumbers1";
			this.ucOnlyNumbers1.Positivo = true;
			this.ucOnlyNumbers1.Size = new System.Drawing.Size(150, 31);
			this.ucOnlyNumbers1.TabIndex = 47;
			this.ucOnlyNumbers1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// ucOnlyNumbers2
			// 
			this.ucOnlyNumbers2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ucOnlyNumbers2.Inteiro = false;
			this.ucOnlyNumbers2.Location = new System.Drawing.Point(162, 349);
			this.ucOnlyNumbers2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.ucOnlyNumbers2.Name = "ucOnlyNumbers2";
			this.ucOnlyNumbers2.Positivo = true;
			this.ucOnlyNumbers2.Size = new System.Drawing.Size(150, 31);
			this.ucOnlyNumbers2.TabIndex = 47;
			this.ucOnlyNumbers2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// line1
			// 
			this.line1.EndPoint = new System.Drawing.Point(452, 5);
			this.line1.LineColor = System.Drawing.Color.SlateGray;
			this.line1.LineWidth = 3F;
			this.line1.Location = new System.Drawing.Point(25, 501);
			this.line1.Name = "line1";
			this.line1.Size = new System.Drawing.Size(420, 10);
			this.line1.StartPoint = new System.Drawing.Point(5, 5);
			this.line1.TabIndex = 48;
			this.line1.TabStop = false;
			// 
			// frmAPagarQuitar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(476, 583);
			this.Controls.Add(this.line1);
			this.Controls.Add(this.ucOnlyNumbers2);
			this.Controls.Add(this.ucOnlyNumbers1);
			this.Controls.Add(this.btnQuitar);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.txtSaidaDia);
			this.Controls.Add(this.txtSaidaAno);
			this.Controls.Add(this.cmbSaidaMes);
			this.Controls.Add(this.btnSetConta);
			this.Controls.Add(this.btnSetSetor);
			this.Controls.Add(this.txtConta);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.txtSetor);
			this.Controls.Add(this.label25);
			this.Controls.Add(this.label26);
			this.Controls.Add(this.v);
			this.Controls.Add(this.txtObservacao);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.lblSaidaValor);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.label22);
			this.Controls.Add(this.label23);
			this.Controls.Add(this.panel2);
			this.Name = "frmAPagarQuitar";
			this.Activated += new System.EventHandler(this.form_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_FormClosed);
			this.Controls.SetChildIndex(this.panel2, 0);
			this.Controls.SetChildIndex(this.label23, 0);
			this.Controls.SetChildIndex(this.label22, 0);
			this.Controls.SetChildIndex(this.label21, 0);
			this.Controls.SetChildIndex(this.lblSaidaValor, 0);
			this.Controls.SetChildIndex(this.label20, 0);
			this.Controls.SetChildIndex(this.txtObservacao, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.v, 0);
			this.Controls.SetChildIndex(this.label26, 0);
			this.Controls.SetChildIndex(this.label25, 0);
			this.Controls.SetChildIndex(this.txtSetor, 0);
			this.Controls.SetChildIndex(this.label19, 0);
			this.Controls.SetChildIndex(this.txtConta, 0);
			this.Controls.SetChildIndex(this.btnSetSetor, 0);
			this.Controls.SetChildIndex(this.btnSetConta, 0);
			this.Controls.SetChildIndex(this.cmbSaidaMes, 0);
			this.Controls.SetChildIndex(this.txtSaidaAno, 0);
			this.Controls.SetChildIndex(this.txtSaidaDia, 0);
			this.Controls.SetChildIndex(this.btnCancelar, 0);
			this.Controls.SetChildIndex(this.btnQuitar, 0);
			this.Controls.SetChildIndex(this.ucOnlyNumbers1, 0);
			this.Controls.SetChildIndex(this.ucOnlyNumbers2, 0);
			this.Controls.SetChildIndex(this.line1, 0);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lblDespesaDescricao;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblCredor;
		internal System.Windows.Forms.Label label11;
		internal System.Windows.Forms.Label label10;
		internal System.Windows.Forms.TextBox txtObservacao;
		internal System.Windows.Forms.Label label20;
		internal System.Windows.Forms.Label lblSaidaValor;
		internal System.Windows.Forms.Label label21;
		internal System.Windows.Forms.Label label22;
		internal System.Windows.Forms.Label label23;
		private CamadaUC.ucOnlyNumbers txtSaidaDia;
		private CamadaUC.ucOnlyNumbers txtSaidaAno;
		private CamadaUC.ucComboLimitedValues cmbSaidaMes;
		internal VIBlend.WinForms.Controls.vButton btnSetConta;
		internal VIBlend.WinForms.Controls.vButton btnSetSetor;
		internal System.Windows.Forms.TextBox txtConta;
		internal System.Windows.Forms.Label label19;
		internal System.Windows.Forms.TextBox txtSetor;
		internal System.Windows.Forms.Label label25;
		internal System.Windows.Forms.Label label26;
		private AwesomeShapeControl.Line v;
		internal System.Windows.Forms.Button btnQuitar;
		internal System.Windows.Forms.Button btnCancelar;
		private CamadaUC.ucOnlyNumbers ucOnlyNumbers1;
		private CamadaUC.ucOnlyNumbers ucOnlyNumbers2;
		private AwesomeShapeControl.Line line1;
	}
}