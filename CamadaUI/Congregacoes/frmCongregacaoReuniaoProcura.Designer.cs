namespace CamadaUI.Congregacoes
{
	partial class frmCongregacaoReuniaoProcura
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
			this.clnID = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
			this.clnItem = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
			this.clnCongregacao = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
			this.Label1 = new System.Windows.Forms.Label();
			this.lblCongregacao = new System.Windows.Forms.Label();
			this.txtProcura = new CamadaUC.ucTextBoxUnclicked();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lstItens)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(394, 0);
			this.lblTitulo.Size = new System.Drawing.Size(191, 50);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "Escolher Reunião";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(585, 0);
			this.btnClose.TabIndex = 1;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblCongregacao);
			this.panel1.Size = new System.Drawing.Size(625, 50);
			this.panel1.Controls.SetChildIndex(this.btnClose, 0);
			this.panel1.Controls.SetChildIndex(this.lblCongregacao, 0);
			this.panel1.Controls.SetChildIndex(this.lblTitulo, 0);
			// 
			// btnFechar
			// 
			this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFechar.Image = global::CamadaUI.Properties.Resources.delete_24;
			this.btnFechar.Location = new System.Drawing.Point(460, 382);
			this.btnFechar.Name = "btnFechar";
			this.btnFechar.Size = new System.Drawing.Size(142, 42);
			this.btnFechar.TabIndex = 5;
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
			this.btnEscolher.Location = new System.Drawing.Point(22, 382);
			this.btnEscolher.Name = "btnEscolher";
			this.btnEscolher.Size = new System.Drawing.Size(142, 42);
			this.btnEscolher.TabIndex = 4;
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
			this.lstItens.Columns.Add(this.clnID);
			this.lstItens.Columns.Add(this.clnItem);
			this.lstItens.Columns.Add(this.clnCongregacao);
			this.lstItens.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstItens.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Nonclickable;
			this.lstItens.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection;
			this.lstItens.HotTracking = ComponentOwl.BetterListView.BetterListViewHotTracking.ItemHot;
			this.lstItens.Location = new System.Drawing.Point(22, 105);
			this.lstItens.Name = "lstItens";
			this.lstItens.Size = new System.Drawing.Size(580, 265);
			this.lstItens.TabIndex = 3;
			this.lstItens.ItemActivate += new ComponentOwl.BetterListView.BetterListViewItemActivateEventHandler(this.lstItens_ItemActivate);
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
			this.clnItem.Text = "Reuniões";
			this.clnItem.Width = 230;
			// 
			// clnCongregacao
			// 
			this.clnCongregacao.Name = "clnCongregacao";
			this.clnCongregacao.Text = "Congregação";
			this.clnCongregacao.Width = 250;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(22, 67);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(58, 19);
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Procura";
			// 
			// lblCongregacao
			// 
			this.lblCongregacao.AutoSize = true;
			this.lblCongregacao.BackColor = System.Drawing.Color.Transparent;
			this.lblCongregacao.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblCongregacao.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCongregacao.ForeColor = System.Drawing.Color.White;
			this.lblCongregacao.Location = new System.Drawing.Point(0, 0);
			this.lblCongregacao.Name = "lblCongregacao";
			this.lblCongregacao.Padding = new System.Windows.Forms.Padding(8, 8, 0, 0);
			this.lblCongregacao.Size = new System.Drawing.Size(149, 37);
			this.lblCongregacao.TabIndex = 1;
			this.lblCongregacao.Tag = "";
			this.lblCongregacao.Text = "Congregacao";
			this.lblCongregacao.Visible = false;
			// 
			// txtProcura
			// 
			this.txtProcura.Location = new System.Drawing.Point(86, 64);
			this.txtProcura.Name = "txtProcura";
			this.txtProcura.SelectionHighlightEnabled = false;
			this.txtProcura.Size = new System.Drawing.Size(335, 27);
			this.txtProcura.TabIndex = 6;
			this.txtProcura.TextChanged += new System.EventHandler(this.txtProcura_TextChanged);
			// 
			// frmCongregacaoReuniaoProcura
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(625, 436);
			this.Controls.Add(this.txtProcura);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.lstItens);
			this.Controls.Add(this.btnFechar);
			this.Controls.Add(this.btnEscolher);
			this.KeyPreview = true;
			this.Name = "frmCongregacaoReuniaoProcura";
			this.Activated += new System.EventHandler(this.frmReuniaoProcura_Activated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReuniaoProcura_FormClosed);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form_KeyPress);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.btnEscolher, 0);
			this.Controls.SetChildIndex(this.btnFechar, 0);
			this.Controls.SetChildIndex(this.lstItens, 0);
			this.Controls.SetChildIndex(this.Label1, 0);
			this.Controls.SetChildIndex(this.txtProcura, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.lstItens)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button btnFechar;
		internal System.Windows.Forms.Button btnEscolher;
		internal ComponentOwl.BetterListView.BetterListView lstItens;
		internal ComponentOwl.BetterListView.BetterListViewColumnHeader clnID;
		internal ComponentOwl.BetterListView.BetterListViewColumnHeader clnItem;
		internal System.Windows.Forms.Label Label1;
		private ComponentOwl.BetterListView.BetterListViewColumnHeader clnCongregacao;
		internal System.Windows.Forms.Label lblCongregacao;
		private CamadaUC.ucTextBoxUnclicked txtProcura;
	}
}
