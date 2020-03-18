namespace CamadaUI
{
    partial class frmPrincipal
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
			this.mnuPrincipal = new System.Windows.Forms.ToolStrip();
			this.btnSair = new System.Windows.Forms.ToolStripButton();
			this.btnEntradas = new System.Windows.Forms.ToolStripSplitButton();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSaidas = new System.Windows.Forms.ToolStripSplitButton();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.btnAvisos = new System.Windows.Forms.ToolStripSplitButton();
			this.pnlTop = new System.Windows.Forms.Panel();
			this.lblTitulo = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnMinimizer = new System.Windows.Forms.Button();
			this.btnConfig = new System.Windows.Forms.Button();
			this.mnuPrincipal.SuspendLayout();
			this.pnlTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuPrincipal
			// 
			this.mnuPrincipal.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSair,
            this.btnEntradas,
            this.btnSaidas,
            this.btnAvisos});
			this.mnuPrincipal.Location = new System.Drawing.Point(0, 39);
			this.mnuPrincipal.Name = "mnuPrincipal";
			this.mnuPrincipal.Size = new System.Drawing.Size(1110, 56);
			this.mnuPrincipal.TabIndex = 1;
			this.mnuPrincipal.Text = "toolStrip1";
			// 
			// btnSair
			// 
			this.btnSair.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnSair.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSair.Image = global::CamadaUI.Properties.Resources.sair_32;
			this.btnSair.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnSair.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSair.Margin = new System.Windows.Forms.Padding(5);
			this.btnSair.Name = "btnSair";
			this.btnSair.Padding = new System.Windows.Forms.Padding(5);
			this.btnSair.Size = new System.Drawing.Size(85, 46);
			this.btnSair.Text = "&Sair";
			this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSair.ToolTipText = "Sair do Aplicativo";
			this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
			// 
			// btnEntradas
			// 
			this.btnEntradas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
			this.btnEntradas.Image = global::CamadaUI.Properties.Resources.Entradas_32;
			this.btnEntradas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnEntradas.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEntradas.Margin = new System.Windows.Forms.Padding(5);
			this.btnEntradas.Name = "btnEntradas";
			this.btnEntradas.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.btnEntradas.Padding = new System.Windows.Forms.Padding(5);
			this.btnEntradas.Size = new System.Drawing.Size(138, 46);
			this.btnEntradas.Text = "Entradas";
			this.btnEntradas.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			this.btnEntradas.ButtonClick += new System.EventHandler(this.btnEntradas_ButtonClick);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(238, 22);
			this.toolStripMenuItem2.Text = "toolStripMenuItem2";
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(238, 22);
			this.toolStripMenuItem3.Text = "toolStripMenuItem3";
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(238, 22);
			this.toolStripMenuItem4.Text = "toolStripMenuItem4";
			// 
			// btnSaidas
			// 
			this.btnSaidas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
			this.btnSaidas.Image = global::CamadaUI.Properties.Resources.Saidas;
			this.btnSaidas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnSaidas.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSaidas.Margin = new System.Windows.Forms.Padding(5);
			this.btnSaidas.Name = "btnSaidas";
			this.btnSaidas.Padding = new System.Windows.Forms.Padding(5);
			this.btnSaidas.Size = new System.Drawing.Size(120, 46);
			this.btnSaidas.Text = "Saídas";
			this.btnSaidas.Click += new System.EventHandler(this.btnSaidas_ButtonClick);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(238, 22);
			this.toolStripMenuItem1.Text = "toolStripMenuItem1";
			// 
			// btnAvisos
			// 
			this.btnAvisos.Image = global::CamadaUI.Properties.Resources.agenda_32;
			this.btnAvisos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnAvisos.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAvisos.Name = "btnAvisos";
			this.btnAvisos.Size = new System.Drawing.Size(117, 53);
			this.btnAvisos.Text = "Avisos";
			// 
			// pnlTop
			// 
			this.pnlTop.BackColor = System.Drawing.Color.SlateGray;
			this.pnlTop.Controls.Add(this.lblTitulo);
			this.pnlTop.Controls.Add(this.btnClose);
			this.pnlTop.Controls.Add(this.btnMinimizer);
			this.pnlTop.Controls.Add(this.btnConfig);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Size = new System.Drawing.Size(1110, 39);
			this.pnlTop.TabIndex = 0;
			// 
			// lblTitulo
			// 
			this.lblTitulo.AutoSize = true;
			this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblTitulo.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.lblTitulo.Location = new System.Drawing.Point(0, 0);
			this.lblTitulo.Margin = new System.Windows.Forms.Padding(0);
			this.lblTitulo.Name = "lblTitulo";
			this.lblTitulo.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
			this.lblTitulo.Size = new System.Drawing.Size(184, 32);
			this.lblTitulo.TabIndex = 12;
			this.lblTitulo.Text = "Tesouraria Igreja";
			this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.BackColor = System.Drawing.Color.Transparent;
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Image = global::CamadaUI.Properties.Resources.CloseIcon;
			this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnClose.Location = new System.Drawing.Point(1070, 0);
			this.btnClose.Margin = new System.Windows.Forms.Padding(0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(40, 40);
			this.btnClose.TabIndex = 11;
			this.btnClose.TabStop = false;
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnSair_Click);
			// 
			// btnMinimizer
			// 
			this.btnMinimizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMinimizer.BackColor = System.Drawing.Color.Transparent;
			this.btnMinimizer.FlatAppearance.BorderSize = 0;
			this.btnMinimizer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnMinimizer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			this.btnMinimizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMinimizer.Image = global::CamadaUI.Properties.Resources.DropdownIcon;
			this.btnMinimizer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnMinimizer.Location = new System.Drawing.Point(1030, 0);
			this.btnMinimizer.Margin = new System.Windows.Forms.Padding(0);
			this.btnMinimizer.Name = "btnMinimizer";
			this.btnMinimizer.Size = new System.Drawing.Size(40, 40);
			this.btnMinimizer.TabIndex = 11;
			this.btnMinimizer.TabStop = false;
			this.btnMinimizer.UseVisualStyleBackColor = false;
			this.btnMinimizer.Click += new System.EventHandler(this.btnMinimizer_Click);
			// 
			// btnConfig
			// 
			this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConfig.BackColor = System.Drawing.Color.Transparent;
			this.btnConfig.FlatAppearance.BorderSize = 0;
			this.btnConfig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
			this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
			this.btnConfig.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnConfig.Location = new System.Drawing.Point(990, 0);
			this.btnConfig.Margin = new System.Windows.Forms.Padding(0);
			this.btnConfig.Name = "btnConfig";
			this.btnConfig.Size = new System.Drawing.Size(40, 40);
			this.btnConfig.TabIndex = 11;
			this.btnConfig.TabStop = false;
			this.btnConfig.UseVisualStyleBackColor = false;
			this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
			// 
			// frmPrincipal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1110, 732);
			this.Controls.Add(this.mnuPrincipal);
			this.Controls.Add(this.pnlTop);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.Name = "frmPrincipal";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Principal";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmPrincipal_Load);
			this.mnuPrincipal.ResumeLayout(false);
			this.mnuPrincipal.PerformLayout();
			this.pnlTop.ResumeLayout(false);
			this.pnlTop.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mnuPrincipal;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.ToolStripButton btnSair;
        internal System.Windows.Forms.Button btnConfig;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnMinimizer;
		private System.Windows.Forms.ToolStripSplitButton btnAvisos;
		private System.Windows.Forms.Label lblTitulo;
		private System.Windows.Forms.ToolStripSplitButton btnEntradas;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
		private System.Windows.Forms.ToolStripSplitButton btnSaidas;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
	}
}

