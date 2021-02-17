
namespace CamadaUI.Mensagens
{
	partial class frmMensagens
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvListagem = new System.Windows.Forms.DataGridView();
			this.clnMensagemData = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnSituacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnMensagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lblUsuario = new System.Windows.Forms.Label();
			this.btnFechar = new System.Windows.Forms.Button();
			this.btnEnviarNova = new System.Windows.Forms.Button();
			this.btnExcluir = new System.Windows.Forms.Button();
			this.pnlSituacao = new System.Windows.Forms.Panel();
			this.rbtEnviadas = new System.Windows.Forms.RadioButton();
			this.rbtRecebidas = new System.Windows.Forms.RadioButton();
			this.mnuOperacoes = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuRecebida = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuItemResponder = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuEnviadas = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuEditar = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuRemover = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).BeginInit();
			this.pnlSituacao.SuspendLayout();
			this.mnuOperacoes.SuspendLayout();
			this.mnuEnviadas.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(647, 0);
			this.lblTitulo.Text = "Mensagens";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(906, 0);
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblUsuario);
			this.panel1.Size = new System.Drawing.Size(946, 50);
			this.panel1.Controls.SetChildIndex(this.btnClose, 0);
			this.panel1.Controls.SetChildIndex(this.lblTitulo, 0);
			this.panel1.Controls.SetChildIndex(this.lblUsuario, 0);
			// 
			// dgvListagem
			// 
			this.dgvListagem.AllowUserToAddRows = false;
			this.dgvListagem.AllowUserToDeleteRows = false;
			this.dgvListagem.AllowUserToResizeColumns = false;
			this.dgvListagem.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.OldLace;
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
			this.dgvListagem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvListagem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvListagem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvListagem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvListagem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvListagem.ColumnHeadersHeight = 33;
			this.dgvListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvListagem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.clnMensagemData,
			this.clnSituacao,
			this.clnMensagem,
			this.clnUsuario});
			this.dgvListagem.EnableHeadersVisualStyles = false;
			this.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption;
			this.dgvListagem.Location = new System.Drawing.Point(12, 62);
			this.dgvListagem.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
			this.dgvListagem.MultiSelect = false;
			this.dgvListagem.Name = "dgvListagem";
			this.dgvListagem.ReadOnly = true;
			this.dgvListagem.RowHeadersVisible = false;
			this.dgvListagem.RowHeadersWidth = 45;
			this.dgvListagem.RowTemplate.Height = 30;
			this.dgvListagem.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvListagem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgvListagem.Size = new System.Drawing.Size(922, 453);
			this.dgvListagem.TabIndex = 3;
			this.dgvListagem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListagem_CellFormatting);
			this.dgvListagem.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListagem_CellMouseEnter);
			this.dgvListagem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvListagem_MouseDown);
			// 
			// clnMensagemData
			// 
			this.clnMensagemData.HeaderText = "Data";
			this.clnMensagemData.Name = "clnMensagemData";
			this.clnMensagemData.ReadOnly = true;
			this.clnMensagemData.Width = 120;
			// 
			// clnSituacao
			// 
			this.clnSituacao.HeaderText = "Situação";
			this.clnSituacao.Name = "clnSituacao";
			this.clnSituacao.ReadOnly = true;
			// 
			// clnMensagem
			// 
			this.clnMensagem.HeaderText = "Mensagem";
			this.clnMensagem.Name = "clnMensagem";
			this.clnMensagem.ReadOnly = true;
			this.clnMensagem.Width = 500;
			// 
			// clnUsuario
			// 
			this.clnUsuario.HeaderText = "Origem de";
			this.clnUsuario.Name = "clnUsuario";
			this.clnUsuario.ReadOnly = true;
			this.clnUsuario.Width = 150;
			// 
			// lblUsuario
			// 
			this.lblUsuario.AutoSize = true;
			this.lblUsuario.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
			this.lblUsuario.ForeColor = System.Drawing.Color.White;
			this.lblUsuario.Location = new System.Drawing.Point(7, 11);
			this.lblUsuario.Name = "lblUsuario";
			this.lblUsuario.Size = new System.Drawing.Size(92, 29);
			this.lblUsuario.TabIndex = 2;
			this.lblUsuario.Text = "Usuário";
			// 
			// btnFechar
			// 
			this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.delete_16;
			this.btnFechar.Location = new System.Drawing.Point(799, 524);
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Size = new System.Drawing.Size(135, 42);
			this.btnFechar.TabIndex = 8;
			this.btnFechar.Text = "&Fechar";
			this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnFechar.UseVisualStyleBackColor = true;
			this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// btnEnviarNova
			// 
			this.btnEnviarNova.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEnviarNova.Image = global::CamadaUI.Properties.Resources.email_32;
			this.btnEnviarNova.Location = new System.Drawing.Point(472, 524);
			this.btnEnviarNova.Name = "btnEnviarNova";
			this.btnEnviarNova.Size = new System.Drawing.Size(189, 42);
			this.btnEnviarNova.TabIndex = 9;
			this.btnEnviarNova.Text = "&Enviar Mensagem";
			this.btnEnviarNova.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnEnviarNova.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnEnviarNova.UseVisualStyleBackColor = true;
			this.btnEnviarNova.Click += new System.EventHandler(this.btnEnviarNova_Click);
			// 
			// btnExcluir
			// 
			this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExcluir.Enabled = false;
			this.btnExcluir.Image = global::CamadaUI.Properties.Resources.lixeira_24;
			this.btnExcluir.Location = new System.Drawing.Point(667, 524);
			this.btnExcluir.Name = "btnExcluir";
			this.btnExcluir.Size = new System.Drawing.Size(126, 42);
			this.btnExcluir.TabIndex = 10;
			this.btnExcluir.Text = "&Remover";
			this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnExcluir.UseVisualStyleBackColor = true;
			// 
			// pnlSituacao
			// 
			this.pnlSituacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pnlSituacao.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.pnlSituacao.Controls.Add(this.rbtEnviadas);
			this.pnlSituacao.Controls.Add(this.rbtRecebidas);
			this.pnlSituacao.Location = new System.Drawing.Point(12, 525);
			this.pnlSituacao.Name = "pnlSituacao";
			this.pnlSituacao.Size = new System.Drawing.Size(251, 41);
			this.pnlSituacao.TabIndex = 12;
			// 
			// rbtEnviadas
			// 
			this.rbtEnviadas.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtEnviadas.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rbtEnviadas.Location = new System.Drawing.Point(128, 3);
			this.rbtEnviadas.Name = "rbtEnviadas";
			this.rbtEnviadas.Size = new System.Drawing.Size(111, 34);
			this.rbtEnviadas.TabIndex = 0;
			this.rbtEnviadas.Tag = "2";
			this.rbtEnviadas.Text = "Enviadas";
			this.rbtEnviadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtEnviadas.UseVisualStyleBackColor = true;
			// 
			// rbtRecebidas
			// 
			this.rbtRecebidas.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtRecebidas.Checked = true;
			this.rbtRecebidas.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rbtRecebidas.Location = new System.Drawing.Point(12, 3);
			this.rbtRecebidas.Name = "rbtRecebidas";
			this.rbtRecebidas.Size = new System.Drawing.Size(111, 34);
			this.rbtRecebidas.TabIndex = 0;
			this.rbtRecebidas.TabStop = true;
			this.rbtRecebidas.Tag = "1";
			this.rbtRecebidas.Text = "Mensagens";
			this.rbtRecebidas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtRecebidas.UseVisualStyleBackColor = true;
			// 
			// mnuOperacoes
			// 
			this.mnuOperacoes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuOperacoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mnuRecebida,
			this.toolStripSeparator1,
			this.mnuItemResponder});
			this.mnuOperacoes.Name = "mnuOperacoes";
			this.mnuOperacoes.Size = new System.Drawing.Size(253, 84);
			// 
			// mnuRecebida
			// 
			this.mnuRecebida.Image = global::CamadaUI.Properties.Resources.like_24;
			this.mnuRecebida.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuRecebida.Name = "mnuRecebida";
			this.mnuRecebida.Padding = new System.Windows.Forms.Padding(0);
			this.mnuRecebida.Size = new System.Drawing.Size(252, 36);
			this.mnuRecebida.Text = "Marcar como Lida";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(249, 6);
			// 
			// mnuItemResponder
			// 
			this.mnuItemResponder.Image = global::CamadaUI.Properties.Resources.email_32;
			this.mnuItemResponder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuItemResponder.Name = "mnuItemResponder";
			this.mnuItemResponder.Size = new System.Drawing.Size(252, 38);
			this.mnuItemResponder.Text = "Responder Mensagem";
			// 
			// mnuEnviadas
			// 
			this.mnuEnviadas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuEnviadas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mnuEditar,
			this.toolStripSeparator2,
			this.mnuRemover});
			this.mnuEnviadas.Name = "mnuOperacoes";
			this.mnuEnviadas.Size = new System.Drawing.Size(233, 68);
			// 
			// mnuEditar
			// 
			this.mnuEditar.Image = global::CamadaUI.Properties.Resources.editar_24;
			this.mnuEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuEditar.Name = "mnuEditar";
			this.mnuEditar.Padding = new System.Windows.Forms.Padding(0);
			this.mnuEditar.Size = new System.Drawing.Size(232, 28);
			this.mnuEditar.Text = "Editar Mensagem";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(229, 6);
			// 
			// mnuRemover
			// 
			this.mnuRemover.Image = global::CamadaUI.Properties.Resources.lixeira_24;
			this.mnuRemover.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuRemover.Name = "mnuRemover";
			this.mnuRemover.Size = new System.Drawing.Size(232, 30);
			this.mnuRemover.Text = "Remover Mensagem";
			// 
			// frmMensagens
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(946, 578);
			this.Controls.Add(this.pnlSituacao);
			this.Controls.Add(this.btnExcluir);
			this.Controls.Add(this.btnEnviarNova);
			this.Controls.Add(this.btnFechar);
			this.Controls.Add(this.dgvListagem);
			this.Name = "frmMensagens";
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.dgvListagem, 0);
			this.Controls.SetChildIndex(this.btnFechar, 0);
			this.Controls.SetChildIndex(this.btnEnviarNova, 0);
			this.Controls.SetChildIndex(this.btnExcluir, 0);
			this.Controls.SetChildIndex(this.pnlSituacao, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).EndInit();
			this.pnlSituacao.ResumeLayout(false);
			this.mnuOperacoes.ResumeLayout(false);
			this.mnuEnviadas.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.DataGridView dgvListagem;
		private System.Windows.Forms.Label lblUsuario;
		internal System.Windows.Forms.Button btnFechar;
		internal System.Windows.Forms.Button btnEnviarNova;
		internal System.Windows.Forms.Button btnExcluir;
		private System.Windows.Forms.Panel pnlSituacao;
		private System.Windows.Forms.RadioButton rbtEnviadas;
		private System.Windows.Forms.RadioButton rbtRecebidas;
		private System.Windows.Forms.ContextMenuStrip mnuOperacoes;
		private System.Windows.Forms.ToolStripMenuItem mnuRecebida;
		private System.Windows.Forms.ToolStripMenuItem mnuItemResponder;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnMensagemData;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnSituacao;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnMensagem;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnUsuario;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ContextMenuStrip mnuEnviadas;
		private System.Windows.Forms.ToolStripMenuItem mnuEditar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem mnuRemover;
	}
}
