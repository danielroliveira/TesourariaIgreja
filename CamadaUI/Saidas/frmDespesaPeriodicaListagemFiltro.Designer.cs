namespace CamadaUI.Saidas
{
	partial class frmDespesaPeriodicaListagemFiltro
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
			this.btnSetContribuinte = new VIBlend.WinForms.Controls.vButton();
			this.txtCredor = new System.Windows.Forms.TextBox();
			this.lblContribuinte = new System.Windows.Forms.Label();
			this.btnSetConta = new VIBlend.WinForms.Controls.vButton();
			this.btnSetSetor = new VIBlend.WinForms.Controls.vButton();
			this.txtDespesaTipo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtSetor = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnProcurar = new VIBlend.WinForms.Controls.vButton();
			this.btnLimpar = new VIBlend.WinForms.Controls.vButton();
			this.btnCancelar = new VIBlend.WinForms.Controls.vButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(430, 0);
			this.lblTitulo.Size = new System.Drawing.Size(180, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Filtrar Procura";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(610, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(650, 50);
			// 
			// btnSetContribuinte
			// 
			this.btnSetContribuinte.AllowAnimations = true;
			this.btnSetContribuinte.BackColor = System.Drawing.Color.Transparent;
			this.btnSetContribuinte.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetContribuinte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetContribuinte.Location = new System.Drawing.Point(576, 158);
			this.btnSetContribuinte.Name = "btnSetContribuinte";
			this.btnSetContribuinte.RoundedCornersMask = ((byte)(15));
			this.btnSetContribuinte.RoundedCornersRadius = 0;
			this.btnSetContribuinte.Size = new System.Drawing.Size(34, 27);
			this.btnSetContribuinte.TabIndex = 18;
			this.btnSetContribuinte.TabStop = false;
			this.btnSetContribuinte.Text = "...";
			this.btnSetContribuinte.UseCompatibleTextRendering = true;
			this.btnSetContribuinte.UseVisualStyleBackColor = false;
			this.btnSetContribuinte.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetContribuinte.Click += new System.EventHandler(this.btnSetCredor_Click);
			// 
			// txtCredor
			// 
			this.txtCredor.Location = new System.Drawing.Point(181, 158);
			this.txtCredor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCredor.MaxLength = 30;
			this.txtCredor.Name = "txtCredor";
			this.txtCredor.Size = new System.Drawing.Size(389, 27);
			this.txtCredor.TabIndex = 17;
			this.txtCredor.Tag = "Pressione a tecla (+) para procurar";
			// 
			// lblContribuinte
			// 
			this.lblContribuinte.AutoSize = true;
			this.lblContribuinte.BackColor = System.Drawing.Color.Transparent;
			this.lblContribuinte.ForeColor = System.Drawing.Color.Black;
			this.lblContribuinte.Location = new System.Drawing.Point(123, 161);
			this.lblContribuinte.Name = "lblContribuinte";
			this.lblContribuinte.Size = new System.Drawing.Size(52, 19);
			this.lblContribuinte.TabIndex = 16;
			this.lblContribuinte.Text = "Credor";
			// 
			// btnSetConta
			// 
			this.btnSetConta.AllowAnimations = true;
			this.btnSetConta.BackColor = System.Drawing.Color.Transparent;
			this.btnSetConta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetConta.Location = new System.Drawing.Point(415, 80);
			this.btnSetConta.Name = "btnSetConta";
			this.btnSetConta.RoundedCornersMask = ((byte)(15));
			this.btnSetConta.RoundedCornersRadius = 0;
			this.btnSetConta.Size = new System.Drawing.Size(34, 27);
			this.btnSetConta.TabIndex = 3;
			this.btnSetConta.TabStop = false;
			this.btnSetConta.Text = "...";
			this.btnSetConta.UseCompatibleTextRendering = true;
			this.btnSetConta.UseVisualStyleBackColor = false;
			this.btnSetConta.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetConta.Click += new System.EventHandler(this.btnSetTipo_Click);
			// 
			// btnSetSetor
			// 
			this.btnSetSetor.AllowAnimations = true;
			this.btnSetSetor.BackColor = System.Drawing.Color.Transparent;
			this.btnSetSetor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetSetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetSetor.Location = new System.Drawing.Point(415, 119);
			this.btnSetSetor.Name = "btnSetSetor";
			this.btnSetSetor.RoundedCornersMask = ((byte)(15));
			this.btnSetSetor.RoundedCornersRadius = 0;
			this.btnSetSetor.Size = new System.Drawing.Size(34, 27);
			this.btnSetSetor.TabIndex = 6;
			this.btnSetSetor.TabStop = false;
			this.btnSetSetor.Text = "...";
			this.btnSetSetor.UseCompatibleTextRendering = true;
			this.btnSetSetor.UseVisualStyleBackColor = false;
			this.btnSetSetor.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetSetor.Click += new System.EventHandler(this.btnSetSetor_Click);
			// 
			// txtDespesaTipo
			// 
			this.txtDespesaTipo.Location = new System.Drawing.Point(181, 80);
			this.txtDespesaTipo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtDespesaTipo.MaxLength = 30;
			this.txtDespesaTipo.Name = "txtDespesaTipo";
			this.txtDespesaTipo.Size = new System.Drawing.Size(228, 27);
			this.txtDespesaTipo.TabIndex = 2;
			this.txtDespesaTipo.Tag = "Pressione a tecla (+) para procurar";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(58, 83);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(117, 19);
			this.label4.TabIndex = 1;
			this.label4.Text = "Tipo de Despesa";
			// 
			// txtSetor
			// 
			this.txtSetor.Location = new System.Drawing.Point(181, 119);
			this.txtSetor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtSetor.MaxLength = 30;
			this.txtSetor.Name = "txtSetor";
			this.txtSetor.Size = new System.Drawing.Size(228, 27);
			this.txtSetor.TabIndex = 5;
			this.txtSetor.Tag = "Pressione a tecla (+) para procurar";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(62, 122);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(113, 19);
			this.label3.TabIndex = 4;
			this.label3.Text = "Setor de Crédito";
			// 
			// btnProcurar
			// 
			this.btnProcurar.AllowAnimations = true;
			this.btnProcurar.BackColor = System.Drawing.Color.Transparent;
			this.btnProcurar.Enabled = false;
			this.btnProcurar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnProcurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnProcurar.HoverEffectsEnabled = true;
			this.btnProcurar.Image = global::CamadaUI.Properties.Resources.search_24;
			this.btnProcurar.ImageAbsolutePosition = new System.Drawing.Point(20, 3);
			this.btnProcurar.Location = new System.Drawing.Point(80, 9);
			this.btnProcurar.Name = "btnProcurar";
			this.btnProcurar.PressedTextColor = System.Drawing.Color.LemonChiffon;
			this.btnProcurar.RoundedCornersMask = ((byte)(15));
			this.btnProcurar.RoundedCornersRadius = 2;
			this.btnProcurar.Size = new System.Drawing.Size(136, 43);
			this.btnProcurar.TabIndex = 19;
			this.btnProcurar.Tag = "Pressione aqui para procurar...";
			this.btnProcurar.Text = "&Procurar";
			this.btnProcurar.TextAbsolutePosition = new System.Drawing.Point(30, 5);
			this.btnProcurar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnProcurar.UseAbsoluteImagePositioning = true;
			this.btnProcurar.UseAbsoluteTextPositioning = true;
			this.btnProcurar.UseCompatibleTextRendering = true;
			this.btnProcurar.UseVisualStyleBackColor = false;
			this.btnProcurar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICEBLACK;
			this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
			// 
			// btnLimpar
			// 
			this.btnLimpar.AllowAnimations = true;
			this.btnLimpar.BackColor = System.Drawing.Color.Transparent;
			this.btnLimpar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLimpar.HoverEffectsEnabled = true;
			this.btnLimpar.Image = global::CamadaUI.Properties.Resources.deletepage_24;
			this.btnLimpar.ImageAbsolutePosition = new System.Drawing.Point(20, 7);
			this.btnLimpar.Location = new System.Drawing.Point(230, 9);
			this.btnLimpar.Name = "btnLimpar";
			this.btnLimpar.PressedTextColor = System.Drawing.Color.LemonChiffon;
			this.btnLimpar.RoundedCornersMask = ((byte)(15));
			this.btnLimpar.RoundedCornersRadius = 2;
			this.btnLimpar.Size = new System.Drawing.Size(136, 43);
			this.btnLimpar.TabIndex = 20;
			this.btnLimpar.Text = "&Limpar";
			this.btnLimpar.TextAbsolutePosition = new System.Drawing.Point(30, 5);
			this.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnLimpar.UseAbsoluteImagePositioning = true;
			this.btnLimpar.UseAbsoluteTextPositioning = true;
			this.btnLimpar.UseCompatibleTextRendering = true;
			this.btnLimpar.UseVisualStyleBackColor = false;
			this.btnLimpar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.AllowAnimations = true;
			this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
			this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancelar.HoverEffectsEnabled = true;
			this.btnCancelar.Image = global::CamadaUI.Properties.Resources.fechar_24;
			this.btnCancelar.ImageAbsolutePosition = new System.Drawing.Point(23, 10);
			this.btnCancelar.Location = new System.Drawing.Point(380, 9);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.PressedTextColor = System.Drawing.Color.LemonChiffon;
			this.btnCancelar.RoundedCornersMask = ((byte)(15));
			this.btnCancelar.RoundedCornersRadius = 2;
			this.btnCancelar.Size = new System.Drawing.Size(136, 43);
			this.btnCancelar.TabIndex = 21;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAbsolutePosition = new System.Drawing.Point(35, 5);
			this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancelar.UseAbsoluteImagePositioning = true;
			this.btnCancelar.UseAbsoluteTextPositioning = true;
			this.btnCancelar.UseCompatibleTextRendering = true;
			this.btnCancelar.UseVisualStyleBackColor = false;
			this.btnCancelar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.STEEL;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(224)))));
			this.panel2.Controls.Add(this.btnCancelar);
			this.panel2.Controls.Add(this.btnProcurar);
			this.panel2.Controls.Add(this.btnLimpar);
			this.panel2.Location = new System.Drawing.Point(12, 221);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(626, 60);
			this.panel2.TabIndex = 22;
			// 
			// frmDespesaPeriodicaListagemFiltro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(650, 293);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.btnSetContribuinte);
			this.Controls.Add(this.txtCredor);
			this.Controls.Add(this.lblContribuinte);
			this.Controls.Add(this.btnSetConta);
			this.Controls.Add(this.btnSetSetor);
			this.Controls.Add(this.txtDespesaTipo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtSetor);
			this.Controls.Add(this.label3);
			this.KeyPreview = true;
			this.Name = "frmDespesaPeriodicaListagemFiltro";
			this.Activated += new System.EventHandler(this.frm_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_FormClosed);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.txtSetor, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.txtDespesaTipo, 0);
			this.Controls.SetChildIndex(this.btnSetSetor, 0);
			this.Controls.SetChildIndex(this.btnSetConta, 0);
			this.Controls.SetChildIndex(this.lblContribuinte, 0);
			this.Controls.SetChildIndex(this.txtCredor, 0);
			this.Controls.SetChildIndex(this.btnSetContribuinte, 0);
			this.Controls.SetChildIndex(this.panel2, 0);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal VIBlend.WinForms.Controls.vButton btnSetContribuinte;
		internal System.Windows.Forms.TextBox txtCredor;
		internal System.Windows.Forms.Label lblContribuinte;
		internal VIBlend.WinForms.Controls.vButton btnSetConta;
		internal VIBlend.WinForms.Controls.vButton btnSetSetor;
		internal System.Windows.Forms.TextBox txtDespesaTipo;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TextBox txtSetor;
		internal System.Windows.Forms.Label label3;
		internal VIBlend.WinForms.Controls.vButton btnProcurar;
		internal VIBlend.WinForms.Controls.vButton btnLimpar;
		internal VIBlend.WinForms.Controls.vButton btnCancelar;
		private System.Windows.Forms.Panel panel2;
	}
}
