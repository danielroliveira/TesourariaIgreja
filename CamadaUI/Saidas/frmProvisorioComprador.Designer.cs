namespace CamadaUI.Saidas
{
	partial class frmProvisorioComprador
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
			this.btnFechar = new System.Windows.Forms.Button();
			this.btnEscolher = new System.Windows.Forms.Button();
			this.lstItens = new ComponentOwl.BetterListView.BetterListView();
			this.clnComprador = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
			this.label1 = new System.Windows.Forms.Label();
			this.txtProcura = new CamadaUC.ucTextBoxUnclicked();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lstItens)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(226, 0);
			this.lblTitulo.Size = new System.Drawing.Size(236, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Escolher Comprador";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(462, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Size = new System.Drawing.Size(502, 50);
			// 
			// btnFechar
			// 
			this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.delete_24;
			this.btnFechar.Location = new System.Drawing.Point(337, 478);
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Size = new System.Drawing.Size(142, 42);
			this.btnFechar.TabIndex = 3;
			this.btnFechar.Text = "&Cancelar";
			this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnFechar.UseVisualStyleBackColor = true;
			this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// btnEscolher
			// 
			this.btnEscolher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnEscolher.Image = global::CamadaUI.Properties.Resources.accept_24;
			this.btnEscolher.Location = new System.Drawing.Point(22, 478);
			this.btnEscolher.Name = "btnEscolher";
			this.btnEscolher.Size = new System.Drawing.Size(142, 42);
			this.btnEscolher.TabIndex = 2;
			this.btnEscolher.Text = "&Escolher";
			this.btnEscolher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnEscolher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnEscolher.UseVisualStyleBackColor = true;
			this.btnEscolher.Click += new System.EventHandler(this.btnEscolher_Click);
			// 
			// lstItens
			// 
			this.lstItens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstItens.ColorSortedColumn = System.Drawing.Color.Transparent;
			this.lstItens.Columns.Add(this.clnComprador);
			this.lstItens.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstItens.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Nonclickable;
			this.lstItens.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection;
			this.lstItens.HotTracking = ComponentOwl.BetterListView.BetterListViewHotTracking.ItemHot;
			this.lstItens.Location = new System.Drawing.Point(22, 110);
			this.lstItens.Name = "lstItens";
			this.lstItens.Size = new System.Drawing.Size(457, 357);
			this.lstItens.TabIndex = 1;
			this.lstItens.ItemActivate += new ComponentOwl.BetterListView.BetterListViewItemActivateEventHandler(this.lstItens_ItemActivate);
			this.lstItens.DrawColumnHeader += new ComponentOwl.BetterListView.BetterListViewDrawColumnHeaderEventHandler(this.lstItens_DrawColumnHeader);
			this.lstItens.DrawItem += new ComponentOwl.BetterListView.BetterListViewDrawItemEventHandler(this.lstItens_DrawItem);
			// 
			// clnComprador
			// 
			this.clnComprador.AllowResize = false;
			this.clnComprador.Name = "clnComprador";
			this.clnComprador.Text = "Comprador | Recebedor Provisório";
			this.clnComprador.Width = 400;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 69);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 19);
			this.label1.TabIndex = 5;
			this.label1.Text = "Procura";
			// 
			// txtProcura
			// 
			this.txtProcura.Location = new System.Drawing.Point(82, 66);
			this.txtProcura.Name = "txtProcura";
			this.txtProcura.SelectionHighlightEnabled = false;
			this.txtProcura.Size = new System.Drawing.Size(285, 27);
			this.txtProcura.TabIndex = 6;
			this.txtProcura.TabStop = false;
			this.txtProcura.TextChanged += new System.EventHandler(this.txtProcura_TextChanged);
			// 
			// frmProvisorioComprador
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(502, 530);
			this.Controls.Add(this.txtProcura);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lstItens);
			this.Controls.Add(this.btnFechar);
			this.Controls.Add(this.btnEscolher);
			this.KeyPreview = true;
			this.Name = "frmProvisorioComprador";
			this.Activated += new System.EventHandler(this.frmProvisorioComprador_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProvisorioComprador_FormClosed);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form_KeyPress);
			this.Controls.SetChildIndex(this.btnEscolher, 0);
			this.Controls.SetChildIndex(this.btnFechar, 0);
			this.Controls.SetChildIndex(this.lstItens, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.txtProcura, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lstItens)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button btnFechar;
		internal System.Windows.Forms.Button btnEscolher;
		internal ComponentOwl.BetterListView.BetterListView lstItens;
		internal ComponentOwl.BetterListView.BetterListViewColumnHeader clnComprador;
		private System.Windows.Forms.Label label1;
		private CamadaUC.ucTextBoxUnclicked txtProcura;
	}
}
