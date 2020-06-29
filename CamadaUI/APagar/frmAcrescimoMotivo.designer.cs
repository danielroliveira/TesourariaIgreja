namespace CamadaUI.APagar
{
	partial class frmAcrescimoMotivo
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
			this.btnSetMotivo = new VIBlend.WinForms.Controls.vButton();
			this.txtAcrescimoMotivo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitulo.Location = new System.Drawing.Point(473, 0);
			this.lblTitulo.Size = new System.Drawing.Size(25, 35);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(498, 0);
			this.btnClose.Size = new System.Drawing.Size(40, 35);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(538, 35);
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
			this.tspMenu.Location = new System.Drawing.Point(2, 146);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(533, 44);
			this.tspMenu.TabIndex = 4;
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
			// btnSetMotivo
			// 
			this.btnSetMotivo.AllowAnimations = true;
			this.btnSetMotivo.BackColor = System.Drawing.Color.Transparent;
			this.btnSetMotivo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetMotivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetMotivo.Location = new System.Drawing.Point(485, 88);
			this.btnSetMotivo.Name = "btnSetMotivo";
			this.btnSetMotivo.RoundedCornersMask = ((byte)(15));
			this.btnSetMotivo.RoundedCornersRadius = 0;
			this.btnSetMotivo.Size = new System.Drawing.Size(34, 31);
			this.btnSetMotivo.TabIndex = 3;
			this.btnSetMotivo.TabStop = false;
			this.btnSetMotivo.Text = "...";
			this.btnSetMotivo.UseCompatibleTextRendering = true;
			this.btnSetMotivo.UseVisualStyleBackColor = false;
			this.btnSetMotivo.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetMotivo.Click += new System.EventHandler(this.btnSetMotivo_Click);
			// 
			// txtAcrescimoMotivo
			// 
			this.txtAcrescimoMotivo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtAcrescimoMotivo.Location = new System.Drawing.Point(22, 88);
			this.txtAcrescimoMotivo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtAcrescimoMotivo.MaxLength = 30;
			this.txtAcrescimoMotivo.Name = "txtAcrescimoMotivo";
			this.txtAcrescimoMotivo.Size = new System.Drawing.Size(457, 31);
			this.txtAcrescimoMotivo.TabIndex = 2;
			this.txtAcrescimoMotivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(102, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(320, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Qual foi o motivo do Acrésimo cobrado?";
			// 
			// frmAcrescimoMotivo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(538, 192);
			this.Controls.Add(this.btnSetMotivo);
			this.Controls.Add(this.txtAcrescimoMotivo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tspMenu);
			this.KeyPreview = true;
			this.Name = "frmAcrescimoMotivo";
			this.Activated += new System.EventHandler(this.form_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_FormClosed);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.txtAcrescimoMotivo, 0);
			this.Controls.SetChildIndex(this.btnSetMotivo, 0);
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
		internal VIBlend.WinForms.Controls.vButton btnSetMotivo;
		internal System.Windows.Forms.TextBox txtAcrescimoMotivo;
		internal System.Windows.Forms.Label label1;
	}
}
