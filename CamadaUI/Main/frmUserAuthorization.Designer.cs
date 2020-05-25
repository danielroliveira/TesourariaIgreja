namespace CamadaUI.Main
{
	partial class frmUserAuthorization
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
			this.Label1 = new System.Windows.Forms.Label();
			this.lblMessage = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtSenha = new System.Windows.Forms.TextBox();
			this.txtApelido = new System.Windows.Forms.TextBox();
			this.lblSenha = new System.Windows.Forms.Label();
			this.lblApelido = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(266, 0);
			this.lblTitulo.Size = new System.Drawing.Size(148, 40);
			this.lblTitulo.Text = "Autorização";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(414, 0);
			this.btnClose.Size = new System.Drawing.Size(40, 40);
			this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(454, 40);
			// 
			// Label1
			// 
			this.Label1.Location = new System.Drawing.Point(25, 57);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(404, 25);
			this.Label1.TabIndex = 9;
			this.Label1.Text = "Solicitada autorização adminsitrativa para:";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblMessage
			// 
			this.lblMessage.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMessage.Location = new System.Drawing.Point(25, 82);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(404, 31);
			this.lblMessage.TabIndex = 10;
			this.lblMessage.Text = "objetivo";
			this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btnOK
			// 
			this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(239)))), ((int)(((byte)(226)))));
			this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOK.Image = global::CamadaUI.Properties.Resources.accept_16;
			this.btnOK.Location = new System.Drawing.Point(104, 185);
			this.btnOK.Margin = new System.Windows.Forms.Padding(4);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(119, 40);
			this.btnOK.TabIndex = 15;
			this.btnOK.Text = "&OK";
			this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnOK.UseVisualStyleBackColor = false;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(207)))));
			this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Image = global::CamadaUI.Properties.Resources.delete_16;
			this.btnCancel.Location = new System.Drawing.Point(231, 185);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(119, 40);
			this.btnCancel.TabIndex = 16;
			this.btnCancel.Text = "&Cancelar";
			this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtSenha
			// 
			this.txtSenha.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSenha.Location = new System.Drawing.Point(265, 139);
			this.txtSenha.Margin = new System.Windows.Forms.Padding(4);
			this.txtSenha.MaxLength = 8;
			this.txtSenha.Name = "txtSenha";
			this.txtSenha.PasswordChar = '*';
			this.txtSenha.Size = new System.Drawing.Size(118, 23);
			this.txtSenha.TabIndex = 14;
			this.txtSenha.Text = "12345678";
			// 
			// txtApelido
			// 
			this.txtApelido.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtApelido.Location = new System.Drawing.Point(79, 139);
			this.txtApelido.Margin = new System.Windows.Forms.Padding(4);
			this.txtApelido.Name = "txtApelido";
			this.txtApelido.Size = new System.Drawing.Size(156, 23);
			this.txtApelido.TabIndex = 12;
			this.txtApelido.Text = "Daniel";
			// 
			// lblSenha
			// 
			this.lblSenha.Location = new System.Drawing.Point(262, 117);
			this.lblSenha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblSenha.Name = "lblSenha";
			this.lblSenha.Size = new System.Drawing.Size(69, 22);
			this.lblSenha.TabIndex = 13;
			this.lblSenha.Text = "&Senha";
			this.lblSenha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblApelido
			// 
			this.lblApelido.Location = new System.Drawing.Point(76, 117);
			this.lblApelido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblApelido.Name = "lblApelido";
			this.lblApelido.Size = new System.Drawing.Size(146, 22);
			this.lblApelido.TabIndex = 11;
			this.lblApelido.Text = "&Nome do Usuário";
			this.lblApelido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmUserAuthorization
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(454, 249);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.lblMessage);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtSenha);
			this.Controls.Add(this.txtApelido);
			this.Controls.Add(this.lblSenha);
			this.Controls.Add(this.lblApelido);
			this.KeyPreview = true;
			this.Name = "frmUserAuthorization";
			this.Activated += new System.EventHandler(this.frm_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_FormClosed);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUserAuthorization_KeyDown);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.lblApelido, 0);
			this.Controls.SetChildIndex(this.lblSenha, 0);
			this.Controls.SetChildIndex(this.txtApelido, 0);
			this.Controls.SetChildIndex(this.txtSenha, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.lblMessage, 0);
			this.Controls.SetChildIndex(this.Label1, 0);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label lblMessage;
		internal System.Windows.Forms.Button btnOK;
		internal System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.TextBox txtSenha;
		internal System.Windows.Forms.TextBox txtApelido;
		internal System.Windows.Forms.Label lblSenha;
		internal System.Windows.Forms.Label lblApelido;
	}
}
