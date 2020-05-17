namespace CamadaUI.Saidas
{
	partial class frmDespesaTipo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDespesaTipo));
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDespesaTipoGrupo = new System.Windows.Forms.TextBox();
			this.btnSetDespesaTipoGrupo = new VIBlend.WinForms.Controls.vButton();
			this.label4 = new System.Windows.Forms.Label();
			this.txtPeriodicidade = new System.Windows.Forms.TextBox();
			this.btnSetPeriodicidade = new VIBlend.WinForms.Controls.vButton();
			this.label2 = new System.Windows.Forms.Label();
			this.txtDespesaTipo = new System.Windows.Forms.TextBox();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnNovo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalvar = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnAtivo = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(295, 0);
			this.lblTitulo.Size = new System.Drawing.Size(225, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Tipos de Despesa";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(520, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblID);
			this.panel1.Controls.Add(this.lbl_IdTexto);
			this.panel1.Size = new System.Drawing.Size(560, 50);
			this.panel1.Controls.SetChildIndex(this.btnClose, 0);
			this.panel1.Controls.SetChildIndex(this.lblTitulo, 0);
			this.panel1.Controls.SetChildIndex(this.lbl_IdTexto, 0);
			this.panel1.Controls.SetChildIndex(this.lblID, 0);
			// 
			// lblID
			// 
			this.lblID.BackColor = System.Drawing.Color.Transparent;
			this.lblID.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblID.ForeColor = System.Drawing.Color.AliceBlue;
			this.lblID.Location = new System.Drawing.Point(4, 16);
			this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblID.Name = "lblID";
			this.lblID.Size = new System.Drawing.Size(94, 30);
			this.lblID.TabIndex = 2;
			this.lblID.Text = "0001";
			this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbl_IdTexto
			// 
			this.lbl_IdTexto.AutoSize = true;
			this.lbl_IdTexto.BackColor = System.Drawing.Color.Transparent;
			this.lbl_IdTexto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_IdTexto.ForeColor = System.Drawing.Color.LightGray;
			this.lbl_IdTexto.Location = new System.Drawing.Point(31, 3);
			this.lbl_IdTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbl_IdTexto.Name = "lbl_IdTexto";
			this.lbl_IdTexto.Size = new System.Drawing.Size(35, 13);
			this.lbl_IdTexto.TabIndex = 3;
			this.lbl_IdTexto.Text = "Reg.";
			this.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(73, 120);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 19);
			this.label3.TabIndex = 3;
			this.label3.Text = "Classificação";
			// 
			// txtDespesaTipoGrupo
			// 
			this.txtDespesaTipoGrupo.Location = new System.Drawing.Point(173, 117);
			this.txtDespesaTipoGrupo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtDespesaTipoGrupo.MaxLength = 30;
			this.txtDespesaTipoGrupo.Name = "txtDespesaTipoGrupo";
			this.txtDespesaTipoGrupo.Size = new System.Drawing.Size(293, 27);
			this.txtDespesaTipoGrupo.TabIndex = 4;
			this.txtDespesaTipoGrupo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			this.txtDespesaTipoGrupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
			// 
			// btnSetDespesaTipoGrupo
			// 
			this.btnSetDespesaTipoGrupo.AllowAnimations = true;
			this.btnSetDespesaTipoGrupo.BackColor = System.Drawing.Color.Transparent;
			this.btnSetDespesaTipoGrupo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetDespesaTipoGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetDespesaTipoGrupo.Location = new System.Drawing.Point(472, 117);
			this.btnSetDespesaTipoGrupo.Name = "btnSetDespesaTipoGrupo";
			this.btnSetDespesaTipoGrupo.RoundedCornersMask = ((byte)(15));
			this.btnSetDespesaTipoGrupo.RoundedCornersRadius = 0;
			this.btnSetDespesaTipoGrupo.Size = new System.Drawing.Size(34, 27);
			this.btnSetDespesaTipoGrupo.TabIndex = 5;
			this.btnSetDespesaTipoGrupo.TabStop = false;
			this.btnSetDespesaTipoGrupo.Text = "n";
			this.btnSetDespesaTipoGrupo.UseCompatibleTextRendering = true;
			this.btnSetDespesaTipoGrupo.UseVisualStyleBackColor = false;
			this.btnSetDespesaTipoGrupo.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetDespesaTipoGrupo.Click += new System.EventHandler(this.btnSetDespesaTipoGrupo_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(70, 159);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(97, 19);
			this.label4.TabIndex = 6;
			this.label4.Text = "Periodicidade";
			// 
			// txtPeriodicidade
			// 
			this.txtPeriodicidade.Location = new System.Drawing.Point(173, 156);
			this.txtPeriodicidade.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtPeriodicidade.MaxLength = 30;
			this.txtPeriodicidade.Name = "txtPeriodicidade";
			this.txtPeriodicidade.Size = new System.Drawing.Size(186, 27);
			this.txtPeriodicidade.TabIndex = 7;
			this.txtPeriodicidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			this.txtPeriodicidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
			// 
			// btnSetPeriodicidade
			// 
			this.btnSetPeriodicidade.AllowAnimations = true;
			this.btnSetPeriodicidade.BackColor = System.Drawing.Color.Transparent;
			this.btnSetPeriodicidade.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetPeriodicidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetPeriodicidade.Location = new System.Drawing.Point(365, 156);
			this.btnSetPeriodicidade.Name = "btnSetPeriodicidade";
			this.btnSetPeriodicidade.RoundedCornersMask = ((byte)(15));
			this.btnSetPeriodicidade.RoundedCornersRadius = 0;
			this.btnSetPeriodicidade.Size = new System.Drawing.Size(34, 27);
			this.btnSetPeriodicidade.TabIndex = 8;
			this.btnSetPeriodicidade.TabStop = false;
			this.btnSetPeriodicidade.Text = "n";
			this.btnSetPeriodicidade.UseCompatibleTextRendering = true;
			this.btnSetPeriodicidade.UseVisualStyleBackColor = false;
			this.btnSetPeriodicidade.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetPeriodicidade.Click += new System.EventHandler(this.btnSetPeriodicidade_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(50, 81);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(117, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "Tipo de Despesa";
			// 
			// txtDespesaTipo
			// 
			this.txtDespesaTipo.Location = new System.Drawing.Point(173, 78);
			this.txtDespesaTipo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtDespesaTipo.MaxLength = 30;
			this.txtDespesaTipo.Name = "txtDespesaTipo";
			this.txtDespesaTipo.Size = new System.Drawing.Size(333, 27);
			this.txtDespesaTipo.TabIndex = 2;
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
            this.btnNovo,
            this.toolStripSeparator1,
            this.btnSalvar,
            this.btnCancelar,
            this.toolStripSeparator2,
            this.btnAtivo,
            this.btnFechar});
			this.tspMenu.Location = new System.Drawing.Point(2, 225);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(555, 44);
			this.tspMenu.TabIndex = 9;
			this.tspMenu.TabStop = true;
			this.tspMenu.Text = "toolStrip1";
			// 
			// btnNovo
			// 
			this.btnNovo.Image = global::CamadaUI.Properties.Resources.adicionar_30;
			this.btnNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNovo.Name = "btnNovo";
			this.btnNovo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnNovo.Size = new System.Drawing.Size(86, 41);
			this.btnNovo.Text = "&Novo";
			this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 44);
			// 
			// btnSalvar
			// 
			this.btnSalvar.Image = global::CamadaUI.Properties.Resources.salvar_30;
			this.btnSalvar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSalvar.Name = "btnSalvar";
			this.btnSalvar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnSalvar.Size = new System.Drawing.Size(92, 41);
			this.btnSalvar.Text = "&Salvar";
			this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Image = global::CamadaUI.Properties.Resources.delete_page_30;
			this.btnCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnCancelar.Size = new System.Drawing.Size(110, 41);
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 44);
			// 
			// btnAtivo
			// 
			this.btnAtivo.Image = ((System.Drawing.Image)(resources.GetObject("btnAtivo.Image")));
			this.btnAtivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnAtivo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAtivo.Name = "btnAtivo";
			this.btnAtivo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnAtivo.Size = new System.Drawing.Size(96, 41);
			this.btnAtivo.Text = "&Ativo";
			this.btnAtivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAtivo.Click += new System.EventHandler(this.btnAtivo_Click);
			// 
			// btnFechar
			// 
			this.btnFechar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.fechar_30;
			this.btnFechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnFechar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnFechar.Size = new System.Drawing.Size(96, 41);
			this.btnFechar.Text = "&Fechar";
			this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// frmDespesaTipo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(560, 271);
			this.Controls.Add(this.tspMenu);
			this.Controls.Add(this.btnSetDespesaTipoGrupo);
			this.Controls.Add(this.btnSetPeriodicidade);
			this.Controls.Add(this.txtDespesaTipo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtPeriodicidade);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtDespesaTipoGrupo);
			this.Controls.Add(this.label3);
			this.KeyPreview = true;
			this.Name = "frmDespesaTipo";
			this.Activated += new System.EventHandler(this.form_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_FormClosed);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.txtDespesaTipoGrupo, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.txtPeriodicidade, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.txtDespesaTipo, 0);
			this.Controls.SetChildIndex(this.btnSetPeriodicidade, 0);
			this.Controls.SetChildIndex(this.btnSetDespesaTipoGrupo, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label lbl_IdTexto;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.TextBox txtDespesaTipoGrupo;
		internal VIBlend.WinForms.Controls.vButton btnSetDespesaTipoGrupo;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TextBox txtPeriodicidade;
		internal VIBlend.WinForms.Controls.vButton btnSetPeriodicidade;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox txtDespesaTipo;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnNovo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnSalvar;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnAtivo;
		private System.Windows.Forms.ToolStripButton btnFechar;
	}
}
