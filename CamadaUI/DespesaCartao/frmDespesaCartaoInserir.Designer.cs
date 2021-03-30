namespace CamadaUI.DespesaCartao
{
	partial class frmDespesaCartaoInserir
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
			this.btnSetConta = new VIBlend.WinForms.Controls.vButton();
			this.txtCartaoDescricao = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.lblDataFinalLabel = new System.Windows.Forms.Label();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnEfetuar = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.numRefDia = new System.Windows.Forms.NumericUpDown();
			this.numRefAno = new System.Windows.Forms.NumericUpDown();
			this.cmbRefMes = new CamadaUC.ucComboLimitedValues();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numRefDia)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numRefAno)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(134, 0);
			this.lblTitulo.Size = new System.Drawing.Size(379, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Inserir Despesa Cartão de Crédito";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(513, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(553, 50);
			// 
			// btnSetConta
			// 
			this.btnSetConta.AllowAnimations = true;
			this.btnSetConta.BackColor = System.Drawing.Color.Transparent;
			this.btnSetConta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetConta.Location = new System.Drawing.Point(450, 142);
			this.btnSetConta.Name = "btnSetConta";
			this.btnSetConta.RoundedCornersMask = ((byte)(15));
			this.btnSetConta.RoundedCornersRadius = 0;
			this.btnSetConta.Size = new System.Drawing.Size(34, 31);
			this.btnSetConta.TabIndex = 4;
			this.btnSetConta.TabStop = false;
			this.btnSetConta.Text = "n";
			this.btnSetConta.UseCompatibleTextRendering = true;
			this.btnSetConta.UseVisualStyleBackColor = false;
			this.btnSetConta.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetConta.Click += new System.EventHandler(this.btnSetCartao_Click);
			// 
			// txtCartaoDescricao
			// 
			this.txtCartaoDescricao.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCartaoDescricao.Location = new System.Drawing.Point(82, 142);
			this.txtCartaoDescricao.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCartaoDescricao.MaxLength = 30;
			this.txtCartaoDescricao.Name = "txtCartaoDescricao";
			this.txtCartaoDescricao.Size = new System.Drawing.Size(362, 31);
			this.txtCartaoDescricao.TabIndex = 3;
			this.txtCartaoDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			this.txtCartaoDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.BackColor = System.Drawing.Color.Transparent;
			this.label19.ForeColor = System.Drawing.Color.Black;
			this.label19.Location = new System.Drawing.Point(78, 117);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(123, 19);
			this.label19.TabIndex = 2;
			this.label19.Text = "Cartão de Crédito";
			// 
			// lblDataFinalLabel
			// 
			this.lblDataFinalLabel.AutoSize = true;
			this.lblDataFinalLabel.BackColor = System.Drawing.Color.Transparent;
			this.lblDataFinalLabel.ForeColor = System.Drawing.Color.Black;
			this.lblDataFinalLabel.Location = new System.Drawing.Point(133, 207);
			this.lblDataFinalLabel.Name = "lblDataFinalLabel";
			this.lblDataFinalLabel.Size = new System.Drawing.Size(138, 19);
			this.lblDataFinalLabel.TabIndex = 5;
			this.lblDataFinalLabel.Text = "Data de Referência:";
			// 
			// btnCancelar
			// 
			this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancelar.Image = global::CamadaUI.Properties.Resources.fechar_24;
			this.btnCancelar.Location = new System.Drawing.Point(281, 319);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(120, 48);
			this.btnCancelar.TabIndex = 10;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnEfetuar
			// 
			this.btnEfetuar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnEfetuar.Enabled = false;
			this.btnEfetuar.Image = global::CamadaUI.Properties.Resources.accept_24;
			this.btnEfetuar.Location = new System.Drawing.Point(151, 319);
			this.btnEfetuar.Name = "btnEfetuar";
			this.btnEfetuar.Size = new System.Drawing.Size(120, 48);
			this.btnEfetuar.TabIndex = 9;
			this.btnEfetuar.Text = "&Efetuar";
			this.btnEfetuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnEfetuar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnEfetuar.UseVisualStyleBackColor = true;
			this.btnEfetuar.Click += new System.EventHandler(this.btnEfetuar_Click);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(41, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(472, 25);
			this.label4.TabIndex = 1;
			this.label4.Text = "Escolha o CARTÃO e a DATA para efetuar o fechamento:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// numRefDia
			// 
			this.numRefDia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numRefDia.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numRefDia.Location = new System.Drawing.Point(137, 229);
			this.numRefDia.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
			this.numRefDia.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numRefDia.Name = "numRefDia";
			this.numRefDia.Size = new System.Drawing.Size(52, 31);
			this.numRefDia.TabIndex = 6;
			this.numRefDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numRefDia.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// numRefAno
			// 
			this.numRefAno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numRefAno.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numRefAno.Location = new System.Drawing.Point(351, 229);
			this.numRefAno.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numRefAno.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numRefAno.Name = "numRefAno";
			this.numRefAno.Size = new System.Drawing.Size(76, 31);
			this.numRefAno.TabIndex = 8;
			this.numRefAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numRefAno.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
			// 
			// cmbRefMes
			// 
			this.cmbRefMes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbRefMes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbRefMes.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbRefMes.FormattingEnabled = true;
			this.cmbRefMes.Location = new System.Drawing.Point(195, 229);
			this.cmbRefMes.Name = "cmbRefMes";
			this.cmbRefMes.Size = new System.Drawing.Size(150, 31);
			this.cmbRefMes.TabIndex = 7;
			// 
			// frmDespesaCartaoInserir
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(553, 390);
			this.Controls.Add(this.numRefDia);
			this.Controls.Add(this.numRefAno);
			this.Controls.Add(this.cmbRefMes);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnEfetuar);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnSetConta);
			this.Controls.Add(this.txtCartaoDescricao);
			this.Controls.Add(this.lblDataFinalLabel);
			this.Controls.Add(this.label19);
			this.KeyPreview = true;
			this.Name = "frmDespesaCartaoInserir";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.label19, 0);
			this.Controls.SetChildIndex(this.lblDataFinalLabel, 0);
			this.Controls.SetChildIndex(this.txtCartaoDescricao, 0);
			this.Controls.SetChildIndex(this.btnSetConta, 0);
			this.Controls.SetChildIndex(this.btnCancelar, 0);
			this.Controls.SetChildIndex(this.btnEfetuar, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.cmbRefMes, 0);
			this.Controls.SetChildIndex(this.numRefAno, 0);
			this.Controls.SetChildIndex(this.numRefDia, 0);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numRefDia)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numRefAno)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal VIBlend.WinForms.Controls.vButton btnSetConta;
		internal System.Windows.Forms.TextBox txtCartaoDescricao;
		internal System.Windows.Forms.Label label19;
		internal System.Windows.Forms.Label lblDataFinalLabel;
		internal System.Windows.Forms.Button btnCancelar;
		internal System.Windows.Forms.Button btnEfetuar;
		internal System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numRefDia;
		private System.Windows.Forms.NumericUpDown numRefAno;
		private CamadaUC.ucComboLimitedValues cmbRefMes;
	}
}
