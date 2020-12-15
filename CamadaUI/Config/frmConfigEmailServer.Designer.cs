namespace CamadaUI.Config
{
	partial class frmConfigEmailServer
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
			this.btnSalvar = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtLogoRemota = new System.Windows.Forms.TextBox();
			this.chkEnableSSL = new System.Windows.Forms.CheckBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtSite = new System.Windows.Forms.TextBox();
			this.txtSMTPHost = new System.Windows.Forms.TextBox();
			this.txtSMTPPort = new CamadaUC.ucOnlyNumbers();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.pnlPastas = new System.Windows.Forms.Panel();
			this.lblCaminho = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.pnlPastas.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Size = new System.Drawing.Size(704, 30);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "Definir Servidor de Email";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(704, 0);
			this.btnClose.TabIndex = 3;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(744, 30);
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
            this.btnSalvar,
            this.btnCancelar,
            this.btnFechar});
			this.tspMenu.Location = new System.Drawing.Point(2, 463);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(739, 44);
			this.tspMenu.TabIndex = 5;
			this.tspMenu.TabStop = true;
			this.tspMenu.Text = "toolStrip1";
			// 
			// btnSalvar
			// 
			this.btnSalvar.Image = global::CamadaUI.Properties.Resources.adicionar_30;
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
			this.btnCancelar.Image = global::CamadaUI.Properties.Resources.salvar_30;
			this.btnCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnCancelar.Size = new System.Drawing.Size(110, 41);
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(17, 211);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(124, 19);
			this.Label1.TabIndex = 27;
			this.Label1.Text = "URL Logo Remota";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtLogoRemota
			// 
			this.txtLogoRemota.Location = new System.Drawing.Point(147, 208);
			this.txtLogoRemota.Multiline = true;
			this.txtLogoRemota.Name = "txtLogoRemota";
			this.txtLogoRemota.Size = new System.Drawing.Size(272, 121);
			this.txtLogoRemota.TabIndex = 28;
			// 
			// chkEnableSSL
			// 
			this.chkEnableSSL.AutoSize = true;
			this.chkEnableSSL.Location = new System.Drawing.Point(148, 179);
			this.chkEnableSSL.Name = "chkEnableSSL";
			this.chkEnableSSL.Size = new System.Drawing.Size(104, 23);
			this.chkEnableSSL.TabIndex = 26;
			this.chkEnableSSL.Text = "Habilita SSL";
			this.chkEnableSSL.UseVisualStyleBackColor = true;
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(29, 338);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(112, 19);
			this.Label6.TabIndex = 22;
			this.Label6.Text = "Site Padrão URL";
			this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(62, 147);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(79, 19);
			this.Label5.TabIndex = 23;
			this.Label5.Text = "Host SMTP";
			this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(58, 114);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(83, 19);
			this.Label4.TabIndex = 20;
			this.Label4.Text = "Porta SMTP";
			this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(93, 81);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(48, 19);
			this.Label3.TabIndex = 18;
			this.Label3.Text = "Senha";
			this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(32, 48);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(109, 19);
			this.Label2.TabIndex = 16;
			this.Label2.Text = "Usuário / Email";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSite
			// 
			this.txtSite.Location = new System.Drawing.Point(147, 335);
			this.txtSite.Name = "txtSite";
			this.txtSite.Size = new System.Drawing.Size(272, 27);
			this.txtSite.TabIndex = 24;
			// 
			// txtSMTPHost
			// 
			this.txtSMTPHost.Location = new System.Drawing.Point(147, 144);
			this.txtSMTPHost.Name = "txtSMTPHost";
			this.txtSMTPHost.Size = new System.Drawing.Size(272, 27);
			this.txtSMTPHost.TabIndex = 25;
			// 
			// txtSMTPPort
			// 
			this.txtSMTPPort.Inteiro = false;
			this.txtSMTPPort.Location = new System.Drawing.Point(147, 111);
			this.txtSMTPPort.Moeda = false;
			this.txtSMTPPort.Name = "txtSMTPPort";
			this.txtSMTPPort.Positivo = true;
			this.txtSMTPPort.Size = new System.Drawing.Size(83, 27);
			this.txtSMTPPort.TabIndex = 21;
			this.txtSMTPPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(147, 78);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(211, 27);
			this.txtPassword.TabIndex = 19;
			this.txtPassword.UseSystemPasswordChar = true;
			// 
			// txtUser
			// 
			this.txtUser.Location = new System.Drawing.Point(147, 45);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(272, 27);
			this.txtUser.TabIndex = 17;
			// 
			// pnlPastas
			// 
			this.pnlPastas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlPastas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(221)))), ((int)(((byte)(234)))));
			this.pnlPastas.Controls.Add(this.lblCaminho);
			this.pnlPastas.Controls.Add(this.Label1);
			this.pnlPastas.Controls.Add(this.txtUser);
			this.pnlPastas.Controls.Add(this.txtLogoRemota);
			this.pnlPastas.Controls.Add(this.txtPassword);
			this.pnlPastas.Controls.Add(this.chkEnableSSL);
			this.pnlPastas.Controls.Add(this.txtSMTPPort);
			this.pnlPastas.Controls.Add(this.Label6);
			this.pnlPastas.Controls.Add(this.txtSMTPHost);
			this.pnlPastas.Controls.Add(this.Label5);
			this.pnlPastas.Controls.Add(this.txtSite);
			this.pnlPastas.Controls.Add(this.Label4);
			this.pnlPastas.Controls.Add(this.Label2);
			this.pnlPastas.Controls.Add(this.Label3);
			this.pnlPastas.Location = new System.Drawing.Point(12, 42);
			this.pnlPastas.Name = "pnlPastas";
			this.pnlPastas.Size = new System.Drawing.Size(720, 409);
			this.pnlPastas.TabIndex = 29;
			// 
			// lblCaminho
			// 
			this.lblCaminho.AutoSize = true;
			this.lblCaminho.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCaminho.Location = new System.Drawing.Point(10, 9);
			this.lblCaminho.Name = "lblCaminho";
			this.lblCaminho.Size = new System.Drawing.Size(122, 23);
			this.lblCaminho.TabIndex = 0;
			this.lblCaminho.Text = "Configurações";
			// 
			// frmConfigEmailServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(744, 509);
			this.Controls.Add(this.pnlPastas);
			this.Controls.Add(this.tspMenu);
			this.KeyPreview = true;
			this.Name = "frmConfigEmailServer";
			this.Shown += new System.EventHandler(this.frmConfigEmailServer_Shown);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.pnlPastas, 0);
			this.panel1.ResumeLayout(false);
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			this.pnlPastas.ResumeLayout(false);
			this.pnlPastas.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnSalvar;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		private System.Windows.Forms.ToolStripButton btnFechar;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox txtLogoRemota;
		internal System.Windows.Forms.CheckBox chkEnableSSL;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox txtSite;
		internal System.Windows.Forms.TextBox txtSMTPHost;
		internal CamadaUC.ucOnlyNumbers txtSMTPPort;
		internal System.Windows.Forms.TextBox txtPassword;
		internal System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.Panel pnlPastas;
		private System.Windows.Forms.Label lblCaminho;
	}
}
