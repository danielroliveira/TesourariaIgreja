namespace CamadaUI.Registres
{
	partial class frmContribuinteListagem
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
			this.btnFechar = new System.Windows.Forms.Button();
			this.btnAdicionar = new System.Windows.Forms.Button();
			this.btnEditar = new System.Windows.Forms.Button();
			this.txtProcura = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.cmbAtivo = new CamadaUC.ucComboLimitedValues();
			this.dgvListagem = new System.Windows.Forms.DataGridView();
			this.clnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnCongregacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnImage = new System.Windows.Forms.DataGridViewImageColumn();
			this.MenuListagem = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.AtivarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DesativarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lblProc = new System.Windows.Forms.Label();
			this.btnProcurar = new System.Windows.Forms.Button();
			this.btnEscolher = new System.Windows.Forms.Button();
			this.lblRegistrosEncontrados = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).BeginInit();
			this.MenuListagem.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(586, 0);
			this.lblTitulo.Size = new System.Drawing.Size(162, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Contribuintes";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(748, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblRegistrosEncontrados);
			this.panel1.Size = new System.Drawing.Size(788, 50);
			this.panel1.Controls.SetChildIndex(this.btnClose, 0);
			this.panel1.Controls.SetChildIndex(this.lblTitulo, 0);
			this.panel1.Controls.SetChildIndex(this.lblRegistrosEncontrados, 0);
			// 
			// btnFechar
			// 
			this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.delete_16;
			this.btnFechar.Location = new System.Drawing.Point(640, 495);
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Size = new System.Drawing.Size(126, 42);
			this.btnFechar.TabIndex = 8;
			this.btnFechar.Text = "&Fechar";
			this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnFechar.UseVisualStyleBackColor = true;
			this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// btnAdicionar
			// 
			this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAdicionar.Image = global::CamadaUI.Properties.Resources.add_16;
			this.btnAdicionar.Location = new System.Drawing.Point(508, 495);
			this.btnAdicionar.Name = "btnAdicionar";
			this.btnAdicionar.Size = new System.Drawing.Size(126, 42);
			this.btnAdicionar.TabIndex = 7;
			this.btnAdicionar.Text = "&Adicionar";
			this.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAdicionar.UseVisualStyleBackColor = true;
			this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
			// 
			// btnEditar
			// 
			this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnEditar.Image = global::CamadaUI.Properties.Resources.editar_16;
			this.btnEditar.Location = new System.Drawing.Point(376, 495);
			this.btnEditar.Name = "btnEditar";
			this.btnEditar.Size = new System.Drawing.Size(126, 42);
			this.btnEditar.TabIndex = 6;
			this.btnEditar.Text = "E&ditar";
			this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnEditar.UseVisualStyleBackColor = true;
			this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
			// 
			// txtProcura
			// 
			this.txtProcura.Location = new System.Drawing.Point(90, 67);
			this.txtProcura.Margin = new System.Windows.Forms.Padding(6);
			this.txtProcura.Name = "txtProcura";
			this.txtProcura.Size = new System.Drawing.Size(282, 27);
			this.txtProcura.TabIndex = 2;
			this.txtProcura.TextChanged += new System.EventHandler(this.txtProcura_TextChanged);
			this.txtProcura.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProcura_KeyDown);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(396, 70);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(64, 19);
			this.Label2.TabIndex = 3;
			this.Label2.Text = "Situação";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(26, 70);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(58, 19);
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Procura";
			// 
			// cmbAtivo
			// 
			this.cmbAtivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbAtivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbAtivo.FormattingEnabled = true;
			this.cmbAtivo.Location = new System.Drawing.Point(466, 67);
			this.cmbAtivo.Name = "cmbAtivo";
			this.cmbAtivo.Size = new System.Drawing.Size(103, 27);
			this.cmbAtivo.TabIndex = 4;
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
			this.clnID,
			this.clnCadastro,
			this.clnCongregacao,
			this.clnImage});
			this.dgvListagem.EnableHeadersVisualStyles = false;
			this.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption;
			this.dgvListagem.Location = new System.Drawing.Point(22, 111);
			this.dgvListagem.MultiSelect = false;
			this.dgvListagem.Name = "dgvListagem";
			this.dgvListagem.ReadOnly = true;
			this.dgvListagem.RowHeadersVisible = false;
			this.dgvListagem.RowHeadersWidth = 45;
			this.dgvListagem.RowTemplate.Height = 30;
			this.dgvListagem.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvListagem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgvListagem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvListagem.Size = new System.Drawing.Size(744, 371);
			this.dgvListagem.TabIndex = 5;
			this.dgvListagem.DataSourceChanged += new System.EventHandler(this.dgvListagem_DataSourceChanged);
			this.dgvListagem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListagem_CellDoubleClick);
			this.dgvListagem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListagem_CellFormatting);
			this.dgvListagem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListagem_KeyDown);
			this.dgvListagem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvListagem_MouseDown);
			// 
			// clnID
			// 
			this.clnID.HeaderText = "Reg.";
			this.clnID.Name = "clnID";
			this.clnID.ReadOnly = true;
			this.clnID.Width = 80;
			// 
			// clnCadastro
			// 
			this.clnCadastro.HeaderText = "Contribuinte";
			this.clnCadastro.Name = "clnCadastro";
			this.clnCadastro.ReadOnly = true;
			this.clnCadastro.Width = 350;
			// 
			// clnCongregacao
			// 
			this.clnCongregacao.HeaderText = "Congregacao";
			this.clnCongregacao.Name = "clnCongregacao";
			this.clnCongregacao.ReadOnly = true;
			this.clnCongregacao.Width = 200;
			// 
			// clnImage
			// 
			this.clnImage.HeaderText = "Ativo";
			this.clnImage.Name = "clnImage";
			this.clnImage.ReadOnly = true;
			this.clnImage.Width = 70;
			// 
			// MenuListagem
			// 
			this.MenuListagem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.AtivarToolStripMenuItem,
			this.DesativarToolStripMenuItem});
			this.MenuListagem.Name = "MenuFab";
			this.MenuListagem.Size = new System.Drawing.Size(193, 48);
			// 
			// AtivarToolStripMenuItem
			// 
			this.AtivarToolStripMenuItem.Image = global::CamadaUI.Properties.Resources.accept_16;
			this.AtivarToolStripMenuItem.Name = "AtivarToolStripMenuItem";
			this.AtivarToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.AtivarToolStripMenuItem.Text = "Ativar Contribuinte";
			this.AtivarToolStripMenuItem.Click += new System.EventHandler(this.AtivarDesativar_Click);
			// 
			// DesativarToolStripMenuItem
			// 
			this.DesativarToolStripMenuItem.Image = global::CamadaUI.Properties.Resources.block_16;
			this.DesativarToolStripMenuItem.Name = "DesativarToolStripMenuItem";
			this.DesativarToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.DesativarToolStripMenuItem.Text = "Desativar Contribuinte";
			this.DesativarToolStripMenuItem.Click += new System.EventHandler(this.AtivarDesativar_Click);
			// 
			// lblProc
			// 
			this.lblProc.BackColor = System.Drawing.Color.White;
			this.lblProc.Font = new System.Drawing.Font("Calibri Light", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProc.Location = new System.Drawing.Point(198, 71);
			this.lblProc.Margin = new System.Windows.Forms.Padding(0);
			this.lblProc.Name = "lblProc";
			this.lblProc.Size = new System.Drawing.Size(172, 19);
			this.lblProc.TabIndex = 43;
			this.lblProc.Text = "Digite algo para procurar...";
			this.lblProc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblProc.Click += new System.EventHandler(this.lblProc_Click);
			// 
			// btnProcurar
			// 
			this.btnProcurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnProcurar.Enabled = false;
			this.btnProcurar.Image = global::CamadaUI.Properties.Resources.refresh_24;
			this.btnProcurar.Location = new System.Drawing.Point(22, 495);
			this.btnProcurar.Name = "btnProcurar";
			this.btnProcurar.Size = new System.Drawing.Size(120, 42);
			this.btnProcurar.TabIndex = 44;
			this.btnProcurar.Tag = "Clique aqui para Procurar";
			this.btnProcurar.Text = "&Procurar";
			this.btnProcurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnProcurar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnProcurar.UseVisualStyleBackColor = true;
			this.btnProcurar.EnabledChanged += new System.EventHandler(this.btnProcurar_EnabledChanged);
			this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
			// 
			// btnEscolher
			// 
			this.btnEscolher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnEscolher.Enabled = false;
			this.btnEscolher.Image = global::CamadaUI.Properties.Resources.accept_24;
			this.btnEscolher.Location = new System.Drawing.Point(148, 495);
			this.btnEscolher.Name = "btnEscolher";
			this.btnEscolher.Size = new System.Drawing.Size(120, 42);
			this.btnEscolher.TabIndex = 44;
			this.btnEscolher.Tag = "Clique aqui para Procurar";
			this.btnEscolher.Text = "&Escolher";
			this.btnEscolher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnEscolher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnEscolher.UseVisualStyleBackColor = true;
			this.btnEscolher.Click += new System.EventHandler(this.btnEscolher_Click);
			// 
			// lblRegistrosEncontrados
			// 
			this.lblRegistrosEncontrados.AutoSize = true;
			this.lblRegistrosEncontrados.BackColor = System.Drawing.Color.SlateGray;
			this.lblRegistrosEncontrados.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRegistrosEncontrados.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.lblRegistrosEncontrados.Location = new System.Drawing.Point(12, 11);
			this.lblRegistrosEncontrados.Name = "lblRegistrosEncontrados";
			this.lblRegistrosEncontrados.Size = new System.Drawing.Size(280, 26);
			this.lblRegistrosEncontrados.TabIndex = 45;
			this.lblRegistrosEncontrados.Text = "Nenhum registro encontrado...";
			this.lblRegistrosEncontrados.Visible = false;
			// 
			// frmContribuinteListagem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(788, 549);
			this.Controls.Add(this.btnEscolher);
			this.Controls.Add(this.btnProcurar);
			this.Controls.Add(this.lblProc);
			this.Controls.Add(this.dgvListagem);
			this.Controls.Add(this.cmbAtivo);
			this.Controls.Add(this.btnFechar);
			this.Controls.Add(this.btnAdicionar);
			this.Controls.Add(this.btnEditar);
			this.Controls.Add(this.txtProcura);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.KeyPreview = true;
			this.Name = "frmContribuinteListagem";
			this.Activated += new System.EventHandler(this.frmContribuinteListagem_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmContribuinteListagem_FormClosed);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmContribuinteListagem_KeyDown);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.Label1, 0);
			this.Controls.SetChildIndex(this.Label2, 0);
			this.Controls.SetChildIndex(this.txtProcura, 0);
			this.Controls.SetChildIndex(this.btnEditar, 0);
			this.Controls.SetChildIndex(this.btnAdicionar, 0);
			this.Controls.SetChildIndex(this.btnFechar, 0);
			this.Controls.SetChildIndex(this.cmbAtivo, 0);
			this.Controls.SetChildIndex(this.dgvListagem, 0);
			this.Controls.SetChildIndex(this.lblProc, 0);
			this.Controls.SetChildIndex(this.btnProcurar, 0);
			this.Controls.SetChildIndex(this.btnEscolher, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).EndInit();
			this.MenuListagem.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button btnFechar;
		internal System.Windows.Forms.Button btnAdicionar;
		internal System.Windows.Forms.Button btnEditar;
		internal System.Windows.Forms.TextBox txtProcura;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		private CamadaUC.ucComboLimitedValues cmbAtivo;
		internal System.Windows.Forms.DataGridView dgvListagem;
		internal System.Windows.Forms.ContextMenuStrip MenuListagem;
		internal System.Windows.Forms.ToolStripMenuItem AtivarToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem DesativarToolStripMenuItem;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnID;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnCadastro;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnCongregacao;
		private System.Windows.Forms.DataGridViewImageColumn clnImage;
		internal System.Windows.Forms.Label lblProc;
		internal System.Windows.Forms.Button btnProcurar;
		internal System.Windows.Forms.Button btnEscolher;
		private System.Windows.Forms.Label lblRegistrosEncontrados;
	}
}
