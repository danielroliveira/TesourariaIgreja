
namespace CamadaUI.Mensagens
{
	partial class frmMensagemEditar
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
			this.lblUsuarioOrigem = new System.Windows.Forms.Label();
			this.txtMensagem = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUsuarioDestino = new System.Windows.Forms.TextBox();
			this.btnSetConta = new VIBlend.WinForms.Controls.vButton();
			this.label3 = new System.Windows.Forms.Label();
			this.lblMensagemData = new System.Windows.Forms.Label();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnEnviar = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.label4 = new System.Windows.Forms.Label();
			this.pnlAnteriores = new System.Windows.Forms.FlowLayoutPanel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.pnlAnteriores.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(450, 0);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Enviar Mensagem";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(709, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(749, 50);
			// 
			// lblUsuarioOrigem
			// 
			this.lblUsuarioOrigem.AutoSize = true;
			this.lblUsuarioOrigem.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUsuarioOrigem.ForeColor = System.Drawing.Color.Black;
			this.lblUsuarioOrigem.Location = new System.Drawing.Point(178, 110);
			this.lblUsuarioOrigem.Name = "lblUsuarioOrigem";
			this.lblUsuarioOrigem.Size = new System.Drawing.Size(89, 29);
			this.lblUsuarioOrigem.TabIndex = 4;
			this.lblUsuarioOrigem.Text = "Usuário";
			// 
			// txtMensagem
			// 
			this.txtMensagem.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMensagem.Location = new System.Drawing.Point(18, 387);
			this.txtMensagem.Multiline = true;
			this.txtMensagem.Name = "txtMensagem";
			this.txtMensagem.Size = new System.Drawing.Size(710, 158);
			this.txtMensagem.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(13, 350);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(124, 29);
			this.label1.TabIndex = 5;
			this.label1.Text = "Mensagem";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(80, 154);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(97, 29);
			this.label2.TabIndex = 8;
			this.label2.Text = "Destino:";
			// 
			// txtUsuarioDestino
			// 
			this.txtUsuarioDestino.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUsuarioDestino.Location = new System.Drawing.Point(183, 154);
			this.txtUsuarioDestino.Name = "txtUsuarioDestino";
			this.txtUsuarioDestino.Size = new System.Drawing.Size(328, 33);
			this.txtUsuarioDestino.TabIndex = 9;
			this.txtUsuarioDestino.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// btnSetConta
			// 
			this.btnSetConta.AllowAnimations = true;
			this.btnSetConta.BackColor = System.Drawing.Color.Transparent;
			this.btnSetConta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetConta.Location = new System.Drawing.Point(517, 154);
			this.btnSetConta.Name = "btnSetConta";
			this.btnSetConta.RoundedCornersMask = ((byte)(15));
			this.btnSetConta.RoundedCornersRadius = 0;
			this.btnSetConta.Size = new System.Drawing.Size(42, 33);
			this.btnSetConta.TabIndex = 10;
			this.btnSetConta.TabStop = false;
			this.btnSetConta.Text = "...";
			this.btnSetConta.UseCompatibleTextRendering = true;
			this.btnSetConta.UseVisualStyleBackColor = false;
			this.btnSetConta.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetConta.Click += new System.EventHandler(this.btnSetUser_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(83, 110);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 29);
			this.label3.TabIndex = 3;
			this.label3.Text = "Origem:";
			// 
			// lblMensagemData
			// 
			this.lblMensagemData.AutoSize = true;
			this.lblMensagemData.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMensagemData.ForeColor = System.Drawing.Color.Black;
			this.lblMensagemData.Location = new System.Drawing.Point(178, 69);
			this.lblMensagemData.Name = "lblMensagemData";
			this.lblMensagemData.Size = new System.Drawing.Size(127, 29);
			this.lblMensagemData.TabIndex = 2;
			this.lblMensagemData.Text = "00/00/0000";
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
            this.btnEnviar,
            this.btnCancelar});
			this.tspMenu.Location = new System.Drawing.Point(6, 566);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(738, 44);
			this.tspMenu.TabIndex = 7;
			this.tspMenu.TabStop = true;
			this.tspMenu.Text = "toolStrip1";
			// 
			// btnEnviar
			// 
			this.btnEnviar.Image = global::CamadaUI.Properties.Resources.email_32;
			this.btnEnviar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnEnviar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEnviar.Name = "btnEnviar";
			this.btnEnviar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnEnviar.Size = new System.Drawing.Size(95, 41);
			this.btnEnviar.Text = "&Enviar";
			this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
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
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(19, 69);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(158, 29);
			this.label4.TabIndex = 1;
			this.label4.Text = "Data do Envio:";
			// 
			// pnlAnteriores
			// 
			this.pnlAnteriores.AutoScroll = true;
			this.pnlAnteriores.Controls.Add(this.textBox1);
			this.pnlAnteriores.Controls.Add(this.textBox2);
			this.pnlAnteriores.Controls.Add(this.textBox3);
			this.pnlAnteriores.Controls.Add(this.textBox4);
			this.pnlAnteriores.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.pnlAnteriores.Location = new System.Drawing.Point(18, 224);
			this.pnlAnteriores.Name = "pnlAnteriores";
			this.pnlAnteriores.Size = new System.Drawing.Size(710, 104);
			this.pnlAnteriores.TabIndex = 11;
			this.pnlAnteriores.Visible = false;
			this.pnlAnteriores.WrapContents = false;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(3, 3);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(677, 27);
			this.textBox1.TabIndex = 0;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(3, 36);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(677, 27);
			this.textBox2.TabIndex = 1;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(3, 69);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(677, 27);
			this.textBox3.TabIndex = 2;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(3, 102);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(8, 27);
			this.textBox4.TabIndex = 3;
			// 
			// frmMensagemEditar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(749, 615);
			this.Controls.Add(this.pnlAnteriores);
			this.Controls.Add(this.tspMenu);
			this.Controls.Add(this.lblMensagemData);
			this.Controls.Add(this.lblUsuarioOrigem);
			this.Controls.Add(this.btnSetConta);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtUsuarioDestino);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtMensagem);
			this.Name = "frmMensagemEditar";
			this.Activated += new System.EventHandler(this.form_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_FormClosed);
			this.Controls.SetChildIndex(this.txtMensagem, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.txtUsuarioDestino, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.btnSetConta, 0);
			this.Controls.SetChildIndex(this.lblUsuarioOrigem, 0);
			this.Controls.SetChildIndex(this.lblMensagemData, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.pnlAnteriores, 0);
			this.panel1.ResumeLayout(false);
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			this.pnlAnteriores.ResumeLayout(false);
			this.pnlAnteriores.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblUsuarioOrigem;
		private System.Windows.Forms.TextBox txtMensagem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtUsuarioDestino;
		internal VIBlend.WinForms.Controls.vButton btnSetConta;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblMensagemData;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnEnviar;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.FlowLayoutPanel pnlAnteriores;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
	}
}
