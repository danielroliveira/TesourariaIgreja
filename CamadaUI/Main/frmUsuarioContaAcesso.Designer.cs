namespace CamadaUI.Main
{
	partial class frmUsuarioContaAcesso
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
			this.btnRemover = new System.Windows.Forms.Button();
			this.btnAdicionar = new System.Windows.Forms.Button();
			this.lstItens = new ComponentOwl.BetterListView.BetterListView();
			this.clnID = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
			this.clnItem = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
			this.lblUsuarioApelido = new System.Windows.Forms.Label();
			this.lblNome = new System.Windows.Forms.Label();
			this.btnFechar = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lstItens)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(91, 0);
			this.lblTitulo.Size = new System.Drawing.Size(250, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Permissões do Usuário";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(341, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Maroon;
			this.panel1.Size = new System.Drawing.Size(381, 50);
			// 
			// btnRemover
			// 
			this.btnRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnRemover.Image = global::CamadaUI.Properties.Resources.delete_page_30;
			this.btnRemover.Location = new System.Drawing.Point(138, 382);
			this.btnRemover.Name = "btnRemover";
			this.btnRemover.Size = new System.Drawing.Size(110, 42);
			this.btnRemover.TabIndex = 5;
			this.btnRemover.Text = "&Remover";
			this.btnRemover.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnRemover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnRemover.UseVisualStyleBackColor = true;
			this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
			// 
			// btnAdicionar
			// 
			this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAdicionar.Image = global::CamadaUI.Properties.Resources.add_24;
			this.btnAdicionar.Location = new System.Drawing.Point(22, 382);
			this.btnAdicionar.Name = "btnAdicionar";
			this.btnAdicionar.Size = new System.Drawing.Size(110, 42);
			this.btnAdicionar.TabIndex = 4;
			this.btnAdicionar.Text = "&Adicionar";
			this.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAdicionar.UseVisualStyleBackColor = true;
			this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
			// 
			// lstItens
			// 
			this.lstItens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstItens.ColorSortedColumn = System.Drawing.Color.Transparent;
			this.lstItens.Columns.Add(this.clnID);
			this.lstItens.Columns.Add(this.clnItem);
			this.lstItens.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstItens.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Nonclickable;
			this.lstItens.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection;
			this.lstItens.HotTracking = ComponentOwl.BetterListView.BetterListViewHotTracking.ItemHot;
			this.lstItens.Location = new System.Drawing.Point(22, 91);
			this.lstItens.Name = "lstItens";
			this.lstItens.Size = new System.Drawing.Size(342, 280);
			this.lstItens.TabIndex = 3;
			this.lstItens.DrawColumnHeader += new ComponentOwl.BetterListView.BetterListViewDrawColumnHeaderEventHandler(this.lstItens_DrawColumnHeader);
			this.lstItens.DrawItem += new ComponentOwl.BetterListView.BetterListViewDrawItemEventHandler(this.lstItens_DrawItem);
			// 
			// clnID
			// 
			this.clnID.AllowResize = false;
			this.clnID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.clnID.Name = "clnID";
			this.clnID.Text = "Reg.";
			this.clnID.Width = 60;
			// 
			// clnItem
			// 
			this.clnItem.AllowResize = false;
			this.clnItem.Name = "clnItem";
			this.clnItem.Text = "Conta Permitida";
			this.clnItem.Width = 230;
			// 
			// lblUsuarioApelido
			// 
			this.lblUsuarioApelido.BackColor = System.Drawing.Color.Transparent;
			this.lblUsuarioApelido.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUsuarioApelido.ForeColor = System.Drawing.Color.Black;
			this.lblUsuarioApelido.Location = new System.Drawing.Point(86, 57);
			this.lblUsuarioApelido.Name = "lblUsuarioApelido";
			this.lblUsuarioApelido.Size = new System.Drawing.Size(272, 25);
			this.lblUsuarioApelido.TabIndex = 2;
			this.lblUsuarioApelido.Text = "Nome do Usuário";
			// 
			// lblNome
			// 
			this.lblNome.AutoSize = true;
			this.lblNome.BackColor = System.Drawing.Color.Transparent;
			this.lblNome.ForeColor = System.Drawing.Color.Black;
			this.lblNome.Location = new System.Drawing.Point(21, 60);
			this.lblNome.Name = "lblNome";
			this.lblNome.Size = new System.Drawing.Size(59, 19);
			this.lblNome.TabIndex = 1;
			this.lblNome.Text = "Usuário";
			// 
			// btnFechar
			// 
			this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.fechar_24;
			this.btnFechar.Location = new System.Drawing.Point(254, 382);
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Size = new System.Drawing.Size(110, 42);
			this.btnFechar.TabIndex = 6;
			this.btnFechar.Text = "&Fechar";
			this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnFechar.UseVisualStyleBackColor = true;
			this.btnFechar.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// frmUsuarioContaAcesso
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(381, 436);
			this.Controls.Add(this.lblUsuarioApelido);
			this.Controls.Add(this.lblNome);
			this.Controls.Add(this.lstItens);
			this.Controls.Add(this.btnFechar);
			this.Controls.Add(this.btnRemover);
			this.Controls.Add(this.btnAdicionar);
			this.KeyPreview = true;
			this.Name = "frmUsuarioContaAcesso";
			this.Activated += new System.EventHandler(this.frmUsuarioContaAcesso_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUsuarioContaAcesso_FormClosed);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUsuarioContaAcesso_KeyDown);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.btnAdicionar, 0);
			this.Controls.SetChildIndex(this.btnRemover, 0);
			this.Controls.SetChildIndex(this.btnFechar, 0);
			this.Controls.SetChildIndex(this.lstItens, 0);
			this.Controls.SetChildIndex(this.lblNome, 0);
			this.Controls.SetChildIndex(this.lblUsuarioApelido, 0);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lstItens)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button btnRemover;
		internal System.Windows.Forms.Button btnAdicionar;
		internal ComponentOwl.BetterListView.BetterListView lstItens;
		internal ComponentOwl.BetterListView.BetterListViewColumnHeader clnID;
		internal ComponentOwl.BetterListView.BetterListViewColumnHeader clnItem;
		internal System.Windows.Forms.Label lblUsuarioApelido;
		internal System.Windows.Forms.Label lblNome;
		internal System.Windows.Forms.Button btnFechar;
	}
}
