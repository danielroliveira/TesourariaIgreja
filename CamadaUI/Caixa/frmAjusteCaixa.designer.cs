namespace CamadaUI.Caixa
{
	partial class frmAjusteCaixa
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
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.lblConta = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.txtAjusteValue = new CamadaUC.ucOnlyNumbers();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.GroupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(124, 0);
			this.lblTitulo.Size = new System.Drawing.Size(225, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Ajuste de Caixa";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(349, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(389, 50);
			// 
			// GroupBox1
			// 
			this.GroupBox1.Controls.Add(this.lblConta);
			this.GroupBox1.Location = new System.Drawing.Point(26, 75);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(328, 70);
			this.GroupBox1.TabIndex = 1;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = " Conta de Nivelamento: ";
			// 
			// lblConta
			// 
			this.lblConta.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblConta.Location = new System.Drawing.Point(34, 25);
			this.lblConta.Name = "lblConta";
			this.lblConta.Size = new System.Drawing.Size(263, 29);
			this.lblConta.TabIndex = 0;
			this.lblConta.Text = "Conta do Caixa";
			this.lblConta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.Location = new System.Drawing.Point(43, 180);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(294, 23);
			this.Label4.TabIndex = 2;
			this.Label4.Text = "Informe o valor real que há na Conta";
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(58, 223);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(75, 19);
			this.Label3.TabIndex = 3;
			this.Label3.Text = "Valor Real";
			this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtAjusteValue
			// 
			this.txtAjusteValue.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtAjusteValue.Inteiro = false;
			this.txtAjusteValue.Location = new System.Drawing.Point(139, 217);
			this.txtAjusteValue.Moeda = true;
			this.txtAjusteValue.Name = "txtAjusteValue";
			this.txtAjusteValue.Positivo = true;
			this.txtAjusteValue.Size = new System.Drawing.Size(151, 33);
			this.txtAjusteValue.TabIndex = 4;
			this.txtAjusteValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnCancelar
			// 
			this.btnCancelar.CausesValidation = false;
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.FlatAppearance.BorderSize = 0;
			this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(220)))), ((int)(((byte)(185)))));
			this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancelar.Image = global::CamadaUI.Properties.Resources.fechar_24;
			this.btnCancelar.Location = new System.Drawing.Point(256, 2);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(119, 40);
			this.btnCancelar.TabIndex = 1;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// btnOK
			// 
			this.btnOK.FlatAppearance.BorderSize = 0;
			this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(220)))), ((int)(((byte)(185)))));
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOK.Image = global::CamadaUI.Properties.Resources.accept_24;
			this.btnOK.Location = new System.Drawing.Point(10, 2);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(119, 40);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "&Nivelar";
			this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.Color.AntiqueWhite;
			this.panel2.Controls.Add(this.btnOK);
			this.panel2.Controls.Add(this.btnCancelar);
			this.panel2.Location = new System.Drawing.Point(2, 300);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(384, 44);
			this.panel2.TabIndex = 5;
			// 
			// frmAjusteCaixa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(389, 346);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.txtAjusteValue);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.GroupBox1);
			this.KeyPreview = true;
			this.Name = "frmAjusteCaixa";
			this.Activated += new System.EventHandler(this.form_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_FormClosed);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.GroupBox1, 0);
			this.Controls.SetChildIndex(this.Label3, 0);
			this.Controls.SetChildIndex(this.Label4, 0);
			this.Controls.SetChildIndex(this.txtAjusteValue, 0);
			this.Controls.SetChildIndex(this.panel2, 0);
			this.panel1.ResumeLayout(false);
			this.GroupBox1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Label lblConta;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label3;
		private CamadaUC.ucOnlyNumbers txtAjusteValue;
		internal System.Windows.Forms.Button btnCancelar;
		internal System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Panel panel2;
	}
}
