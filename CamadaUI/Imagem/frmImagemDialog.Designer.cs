namespace CamadaUI.Imagem
{
	partial class frmImagemDialog
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
			this.btnProcurar = new VIBlend.WinForms.Controls.vButton();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSalvar = new System.Windows.Forms.Button();
			this.btnAlterar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnVisualizar = new System.Windows.Forms.Button();
			this.lblPath = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(369, 0);
			this.lblTitulo.Size = new System.Drawing.Size(201, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Escolher Imagem";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(570, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(610, 50);
			// 
			// btnProcurar
			// 
			this.btnProcurar.AllowAnimations = true;
			this.btnProcurar.BackColor = System.Drawing.Color.Transparent;
			this.btnProcurar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnProcurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnProcurar.Location = new System.Drawing.Point(558, 70);
			this.btnProcurar.Name = "btnProcurar";
			this.btnProcurar.RoundedCornersMask = ((byte)(15));
			this.btnProcurar.RoundedCornersRadius = 0;
			this.btnProcurar.Size = new System.Drawing.Size(34, 27);
			this.btnProcurar.TabIndex = 2;
			this.btnProcurar.TabStop = false;
			this.btnProcurar.Text = "...";
			this.btnProcurar.UseCompatibleTextRendering = true;
			this.btnProcurar.UseVisualStyleBackColor = false;
			this.btnProcurar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(273, 100);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(279, 19);
			this.label1.TabIndex = 3;
			this.label1.Text = "imagem de comprovante, nfe, boleto, etc.";
			// 
			// btnSalvar
			// 
			this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSalvar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.btnSalvar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightYellow;
			this.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSalvar.Image = global::CamadaUI.Properties.Resources.accept_16;
			this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSalvar.Location = new System.Drawing.Point(20, 143);
			this.btnSalvar.Name = "btnSalvar";
			this.btnSalvar.Size = new System.Drawing.Size(145, 40);
			this.btnSalvar.TabIndex = 4;
			this.btnSalvar.Text = "&Salvar Imagem";
			this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSalvar.UseVisualStyleBackColor = true;
			this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
			// 
			// btnAlterar
			// 
			this.btnAlterar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAlterar.Enabled = false;
			this.btnAlterar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.btnAlterar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightYellow;
			this.btnAlterar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			this.btnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAlterar.Image = global::CamadaUI.Properties.Resources.add_16;
			this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAlterar.Location = new System.Drawing.Point(171, 143);
			this.btnAlterar.Name = "btnAlterar";
			this.btnAlterar.Size = new System.Drawing.Size(145, 40);
			this.btnAlterar.TabIndex = 5;
			this.btnAlterar.Text = "&Alterar Imagem";
			this.btnAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAlterar.UseVisualStyleBackColor = true;
			this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightYellow;
			this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
			this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancelar.Image = global::CamadaUI.Properties.Resources.delete_16;
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.Location = new System.Drawing.Point(477, 143);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(115, 40);
			this.btnCancelar.TabIndex = 7;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnVisualizar
			// 
			this.btnVisualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnVisualizar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.btnVisualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightYellow;
			this.btnVisualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			this.btnVisualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnVisualizar.Image = global::CamadaUI.Properties.Resources.search_24;
			this.btnVisualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnVisualizar.Location = new System.Drawing.Point(322, 143);
			this.btnVisualizar.Name = "btnVisualizar";
			this.btnVisualizar.Size = new System.Drawing.Size(145, 40);
			this.btnVisualizar.TabIndex = 6;
			this.btnVisualizar.Text = "&Visualizar";
			this.btnVisualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnVisualizar.UseVisualStyleBackColor = true;
			this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
			// 
			// lblPath
			// 
			this.lblPath.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblPath.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPath.Location = new System.Drawing.Point(16, 70);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(536, 27);
			this.lblPath.TabIndex = 1;
			this.lblPath.Text = "C:/";
			this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmImagemDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(610, 200);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnAlterar);
			this.Controls.Add(this.btnVisualizar);
			this.Controls.Add(this.btnSalvar);
			this.Controls.Add(this.lblPath);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnProcurar);
			this.Name = "frmImagemDialog";
			this.Activated += new System.EventHandler(this.frmDateGet_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDateGet_FormClosed);
			this.Load += new System.EventHandler(this.frmImagemDialog_Load);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.btnProcurar, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.lblPath, 0);
			this.Controls.SetChildIndex(this.btnSalvar, 0);
			this.Controls.SetChildIndex(this.btnVisualizar, 0);
			this.Controls.SetChildIndex(this.btnAlterar, 0);
			this.Controls.SetChildIndex(this.btnCancelar, 0);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal VIBlend.WinForms.Controls.vButton btnProcurar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSalvar;
		private System.Windows.Forms.Button btnAlterar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnVisualizar;
		private System.Windows.Forms.Label lblPath;
	}
}
