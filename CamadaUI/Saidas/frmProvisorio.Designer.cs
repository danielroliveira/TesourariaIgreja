namespace CamadaUI.Saidas
{
	partial class frmProvisorio
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnSalvar = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.txtFinalidade = new System.Windows.Forms.TextBox();
			this.lblFin = new System.Windows.Forms.Label();
			this.dtpRetiradaData = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.btnSetAutorizante = new VIBlend.WinForms.Controls.vButton();
			this.txtAutorizante = new System.Windows.Forms.TextBox();
			this.lblContribuinte = new System.Windows.Forms.Label();
			this.btnSetSetor = new VIBlend.WinForms.Controls.vButton();
			this.txtSetor = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnSetConta = new VIBlend.WinForms.Controls.vButton();
			this.txtConta = new System.Windows.Forms.TextBox();
			this.lblContaDetalhe = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.txtValorProvisorio = new CamadaUC.ucOnlyNumbers();
			this.btnSetComprador = new VIBlend.WinForms.Controls.vButton();
			this.txtComprador = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.btnInsertComprador = new VIBlend.WinForms.Controls.vButton();
			this.dgvListagem = new System.Windows.Forms.DataGridView();
			this.line2 = new AwesomeShapeControl.Line();
			this.label6 = new System.Windows.Forms.Label();
			this.btnInserirDespesa = new VIBlend.WinForms.Controls.vButton();
			this.btnConcluir = new VIBlend.WinForms.Controls.vButton();
			this.btnInsertAutorizante = new VIBlend.WinForms.Controls.vButton();
			this.clnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnDespesaData = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnCredor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(434, 0);
			this.lblTitulo.Size = new System.Drawing.Size(219, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "Despesa Provisória";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(653, 0);
			this.btnClose.TabIndex = 3;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblID);
			this.panel1.Controls.Add(this.lbl_IdTexto);
			this.panel1.Size = new System.Drawing.Size(693, 50);
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
			this.lblID.Location = new System.Drawing.Point(6, 17);
			this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblID.Name = "lblID";
			this.lblID.Size = new System.Drawing.Size(94, 30);
			this.lblID.TabIndex = 0;
			this.lblID.Text = "0001";
			this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbl_IdTexto
			// 
			this.lbl_IdTexto.AutoSize = true;
			this.lbl_IdTexto.BackColor = System.Drawing.Color.Transparent;
			this.lbl_IdTexto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_IdTexto.ForeColor = System.Drawing.Color.LightGray;
			this.lbl_IdTexto.Location = new System.Drawing.Point(33, 4);
			this.lbl_IdTexto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbl_IdTexto.Name = "lbl_IdTexto";
			this.lbl_IdTexto.Size = new System.Drawing.Size(35, 13);
			this.lbl_IdTexto.TabIndex = 1;
			this.lbl_IdTexto.Text = "Reg.";
			this.lbl_IdTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.btnFechar,
            this.toolStripSeparator2});
			this.tspMenu.Location = new System.Drawing.Point(2, 667);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(689, 44);
			this.tspMenu.TabIndex = 48;
			this.tspMenu.TabStop = true;
			this.tspMenu.Text = "toolStrip1";
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
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 44);
			// 
			// txtFinalidade
			// 
			this.txtFinalidade.BackColor = System.Drawing.Color.White;
			this.txtFinalidade.Location = new System.Drawing.Point(165, 255);
			this.txtFinalidade.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtFinalidade.MaxLength = 100;
			this.txtFinalidade.Name = "txtFinalidade";
			this.txtFinalidade.Size = new System.Drawing.Size(451, 27);
			this.txtFinalidade.TabIndex = 30;
			this.txtFinalidade.Tag = "";
			this.txtFinalidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// lblFin
			// 
			this.lblFin.AutoSize = true;
			this.lblFin.BackColor = System.Drawing.Color.Transparent;
			this.lblFin.ForeColor = System.Drawing.Color.Black;
			this.lblFin.Location = new System.Drawing.Point(83, 258);
			this.lblFin.Name = "lblFin";
			this.lblFin.Size = new System.Drawing.Size(76, 19);
			this.lblFin.TabIndex = 29;
			this.lblFin.Text = "Finalidade";
			// 
			// dtpRetiradaData
			// 
			this.dtpRetiradaData.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpRetiradaData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpRetiradaData.Location = new System.Drawing.Point(162, 326);
			this.dtpRetiradaData.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.dtpRetiradaData.Name = "dtpRetiradaData";
			this.dtpRetiradaData.Size = new System.Drawing.Size(145, 31);
			this.dtpRetiradaData.TabIndex = 33;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(161, 301);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(119, 19);
			this.label1.TabIndex = 32;
			this.label1.Text = "Data da Retirada";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.ForeColor = System.Drawing.Color.Black;
			this.label8.Location = new System.Drawing.Point(331, 301);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(119, 19);
			this.label8.TabIndex = 34;
			this.label8.Text = "Valor Antecipado";
			// 
			// btnSetAutorizante
			// 
			this.btnSetAutorizante.AllowAnimations = true;
			this.btnSetAutorizante.BackColor = System.Drawing.Color.Transparent;
			this.btnSetAutorizante.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetAutorizante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetAutorizante.Location = new System.Drawing.Point(582, 177);
			this.btnSetAutorizante.Name = "btnSetAutorizante";
			this.btnSetAutorizante.RoundedCornersMask = ((byte)(15));
			this.btnSetAutorizante.RoundedCornersRadius = 0;
			this.btnSetAutorizante.Size = new System.Drawing.Size(34, 27);
			this.btnSetAutorizante.TabIndex = 10;
			this.btnSetAutorizante.TabStop = false;
			this.btnSetAutorizante.Text = "...";
			this.btnSetAutorizante.UseCompatibleTextRendering = true;
			this.btnSetAutorizante.UseVisualStyleBackColor = false;
			this.btnSetAutorizante.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetAutorizante.Click += new System.EventHandler(this.btnSetAutorizante_Click);
			// 
			// txtAutorizante
			// 
			this.txtAutorizante.Location = new System.Drawing.Point(165, 177);
			this.txtAutorizante.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtAutorizante.MaxLength = 30;
			this.txtAutorizante.Name = "txtAutorizante";
			this.txtAutorizante.Size = new System.Drawing.Size(411, 27);
			this.txtAutorizante.TabIndex = 9;
			this.txtAutorizante.Tag = "Pressione a tecla (+) para procurar";
			this.txtAutorizante.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// lblContribuinte
			// 
			this.lblContribuinte.AutoSize = true;
			this.lblContribuinte.BackColor = System.Drawing.Color.Transparent;
			this.lblContribuinte.ForeColor = System.Drawing.Color.Black;
			this.lblContribuinte.Location = new System.Drawing.Point(76, 180);
			this.lblContribuinte.Name = "lblContribuinte";
			this.lblContribuinte.Size = new System.Drawing.Size(83, 19);
			this.lblContribuinte.TabIndex = 8;
			this.lblContribuinte.Text = "Autorizante";
			// 
			// btnSetSetor
			// 
			this.btnSetSetor.AllowAnimations = true;
			this.btnSetSetor.BackColor = System.Drawing.Color.Transparent;
			this.btnSetSetor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetSetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetSetor.Location = new System.Drawing.Point(399, 138);
			this.btnSetSetor.Name = "btnSetSetor";
			this.btnSetSetor.RoundedCornersMask = ((byte)(15));
			this.btnSetSetor.RoundedCornersRadius = 0;
			this.btnSetSetor.Size = new System.Drawing.Size(34, 27);
			this.btnSetSetor.TabIndex = 7;
			this.btnSetSetor.TabStop = false;
			this.btnSetSetor.Text = "...";
			this.btnSetSetor.UseCompatibleTextRendering = true;
			this.btnSetSetor.UseVisualStyleBackColor = false;
			this.btnSetSetor.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetSetor.Click += new System.EventHandler(this.btnSetSetor_Click);
			// 
			// txtSetor
			// 
			this.txtSetor.Location = new System.Drawing.Point(165, 138);
			this.txtSetor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtSetor.MaxLength = 30;
			this.txtSetor.Name = "txtSetor";
			this.txtSetor.Size = new System.Drawing.Size(228, 27);
			this.txtSetor.TabIndex = 6;
			this.txtSetor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(54, 141);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(105, 19);
			this.label5.TabIndex = 5;
			this.label5.Text = "Setor Debitado";
			// 
			// btnSetConta
			// 
			this.btnSetConta.AllowAnimations = true;
			this.btnSetConta.BackColor = System.Drawing.Color.Transparent;
			this.btnSetConta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetConta.Location = new System.Drawing.Point(399, 69);
			this.btnSetConta.Name = "btnSetConta";
			this.btnSetConta.RoundedCornersMask = ((byte)(15));
			this.btnSetConta.RoundedCornersRadius = 0;
			this.btnSetConta.Size = new System.Drawing.Size(34, 27);
			this.btnSetConta.TabIndex = 3;
			this.btnSetConta.TabStop = false;
			this.btnSetConta.Text = "...";
			this.btnSetConta.UseCompatibleTextRendering = true;
			this.btnSetConta.UseVisualStyleBackColor = false;
			this.btnSetConta.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetConta.Click += new System.EventHandler(this.btnSetConta_Click);
			// 
			// txtConta
			// 
			this.txtConta.Location = new System.Drawing.Point(165, 69);
			this.txtConta.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtConta.MaxLength = 30;
			this.txtConta.Name = "txtConta";
			this.txtConta.Size = new System.Drawing.Size(228, 27);
			this.txtConta.TabIndex = 2;
			this.txtConta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// lblContaDetalhe
			// 
			this.lblContaDetalhe.BackColor = System.Drawing.Color.Transparent;
			this.lblContaDetalhe.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblContaDetalhe.ForeColor = System.Drawing.Color.Black;
			this.lblContaDetalhe.Location = new System.Drawing.Point(165, 99);
			this.lblContaDetalhe.Name = "lblContaDetalhe";
			this.lblContaDetalhe.Size = new System.Drawing.Size(228, 35);
			this.lblContaDetalhe.TabIndex = 4;
			this.lblContaDetalhe.Text = "Saldo da Conta: R$ 0,00\r\nData de Bloqueio até: 01/01/2000";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.BackColor = System.Drawing.Color.Transparent;
			this.label19.ForeColor = System.Drawing.Color.Black;
			this.label19.Location = new System.Drawing.Point(49, 72);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(110, 19);
			this.label19.TabIndex = 1;
			this.label19.Text = "Conta Debitada";
			// 
			// txtValorProvisorio
			// 
			this.txtValorProvisorio.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtValorProvisorio.Inteiro = false;
			this.txtValorProvisorio.Location = new System.Drawing.Point(335, 326);
			this.txtValorProvisorio.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtValorProvisorio.Moeda = false;
			this.txtValorProvisorio.Name = "txtValorProvisorio";
			this.txtValorProvisorio.Positivo = true;
			this.txtValorProvisorio.Size = new System.Drawing.Size(145, 31);
			this.txtValorProvisorio.TabIndex = 35;
			this.txtValorProvisorio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnSetComprador
			// 
			this.btnSetComprador.AllowAnimations = true;
			this.btnSetComprador.BackColor = System.Drawing.Color.Transparent;
			this.btnSetComprador.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetComprador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetComprador.Location = new System.Drawing.Point(582, 216);
			this.btnSetComprador.Name = "btnSetComprador";
			this.btnSetComprador.RoundedCornersMask = ((byte)(15));
			this.btnSetComprador.RoundedCornersRadius = 0;
			this.btnSetComprador.Size = new System.Drawing.Size(34, 27);
			this.btnSetComprador.TabIndex = 13;
			this.btnSetComprador.TabStop = false;
			this.btnSetComprador.Text = "...";
			this.btnSetComprador.UseCompatibleTextRendering = true;
			this.btnSetComprador.UseVisualStyleBackColor = false;
			this.btnSetComprador.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetComprador.Click += new System.EventHandler(this.btnSetComprador_Click);
			// 
			// txtComprador
			// 
			this.txtComprador.Location = new System.Drawing.Point(165, 216);
			this.txtComprador.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtComprador.MaxLength = 30;
			this.txtComprador.Name = "txtComprador";
			this.txtComprador.Size = new System.Drawing.Size(411, 27);
			this.txtComprador.TabIndex = 12;
			this.txtComprador.Tag = "Pressione a tecla (+) para procurar";
			this.txtComprador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.BackColor = System.Drawing.Color.Transparent;
			this.label14.ForeColor = System.Drawing.Color.Black;
			this.label14.Location = new System.Drawing.Point(79, 219);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(80, 19);
			this.label14.TabIndex = 11;
			this.label14.Text = "Comprador";
			// 
			// btnInsertComprador
			// 
			this.btnInsertComprador.AllowAnimations = true;
			this.btnInsertComprador.BackColor = System.Drawing.Color.Transparent;
			this.btnInsertComprador.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnInsertComprador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInsertComprador.Image = global::CamadaUI.Properties.Resources.add_16;
			this.btnInsertComprador.ImageAbsolutePosition = new System.Drawing.Point(7, 3);
			this.btnInsertComprador.Location = new System.Drawing.Point(622, 216);
			this.btnInsertComprador.Name = "btnInsertComprador";
			this.btnInsertComprador.RoundedCornersMask = ((byte)(15));
			this.btnInsertComprador.RoundedCornersRadius = 0;
			this.btnInsertComprador.Size = new System.Drawing.Size(34, 27);
			this.btnInsertComprador.TabIndex = 14;
			this.btnInsertComprador.TabStop = false;
			this.btnInsertComprador.UseAbsoluteImagePositioning = true;
			this.btnInsertComprador.UseCompatibleTextRendering = true;
			this.btnInsertComprador.UseVisualStyleBackColor = false;
			this.btnInsertComprador.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnInsertComprador.Click += new System.EventHandler(this.btnInsertComprador_Click);
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
            this.clnDespesaData,
            this.clnCredor,
            this.clnValor});
			this.dgvListagem.EnableHeadersVisualStyles = false;
			this.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption;
			this.dgvListagem.Location = new System.Drawing.Point(45, 423);
			this.dgvListagem.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
			this.dgvListagem.MultiSelect = false;
			this.dgvListagem.Name = "dgvListagem";
			this.dgvListagem.ReadOnly = true;
			this.dgvListagem.RowHeadersVisible = false;
			this.dgvListagem.RowHeadersWidth = 45;
			this.dgvListagem.RowTemplate.Height = 30;
			this.dgvListagem.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvListagem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgvListagem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvListagem.Size = new System.Drawing.Size(608, 168);
			this.dgvListagem.TabIndex = 49;
			// 
			// line2
			// 
			this.line2.EndPoint = new System.Drawing.Point(460, 5);
			this.line2.LineColor = System.Drawing.Color.LightSlateGray;
			this.line2.LineWidth = 3F;
			this.line2.Location = new System.Drawing.Point(194, 390);
			this.line2.Name = "line2";
			this.line2.Opacity = 0.5F;
			this.line2.Size = new System.Drawing.Size(465, 10);
			this.line2.StartPoint = new System.Drawing.Point(5, 5);
			this.line2.TabIndex = 51;
			this.line2.TabStop = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.LightSlateGray;
			this.label6.Location = new System.Drawing.Point(25, 382);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(166, 23);
			this.label6.TabIndex = 50;
			this.label6.Text = "Despesas Efetuadas";
			// 
			// btnInserirDespesa
			// 
			this.btnInserirDespesa.AllowAnimations = true;
			this.btnInserirDespesa.BackColor = System.Drawing.Color.Transparent;
			this.btnInserirDespesa.Enabled = false;
			this.btnInserirDespesa.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnInserirDespesa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInserirDespesa.Location = new System.Drawing.Point(45, 608);
			this.btnInserirDespesa.Name = "btnInserirDespesa";
			this.btnInserirDespesa.RoundedCornersMask = ((byte)(15));
			this.btnInserirDespesa.RoundedCornersRadius = 0;
			this.btnInserirDespesa.Size = new System.Drawing.Size(162, 35);
			this.btnInserirDespesa.TabIndex = 52;
			this.btnInserirDespesa.Text = "Anexar Despesa";
			this.btnInserirDespesa.UseCompatibleTextRendering = true;
			this.btnInserirDespesa.UseVisualStyleBackColor = false;
			this.btnInserirDespesa.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnInserirDespesa.Click += new System.EventHandler(this.btnInserirDespesa_Click);
			// 
			// btnConcluir
			// 
			this.btnConcluir.AllowAnimations = true;
			this.btnConcluir.BackColor = System.Drawing.Color.Transparent;
			this.btnConcluir.Enabled = false;
			this.btnConcluir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnConcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnConcluir.Location = new System.Drawing.Point(218, 608);
			this.btnConcluir.Name = "btnConcluir";
			this.btnConcluir.RoundedCornersMask = ((byte)(15));
			this.btnConcluir.RoundedCornersRadius = 0;
			this.btnConcluir.Size = new System.Drawing.Size(215, 35);
			this.btnConcluir.TabIndex = 52;
			this.btnConcluir.Text = "Concluir Despesa Provisória";
			this.btnConcluir.UseCompatibleTextRendering = true;
			this.btnConcluir.UseVisualStyleBackColor = false;
			this.btnConcluir.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			// 
			// btnInsertAutorizante
			// 
			this.btnInsertAutorizante.AllowAnimations = true;
			this.btnInsertAutorizante.BackColor = System.Drawing.Color.Transparent;
			this.btnInsertAutorizante.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnInsertAutorizante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInsertAutorizante.Image = global::CamadaUI.Properties.Resources.add_16;
			this.btnInsertAutorizante.ImageAbsolutePosition = new System.Drawing.Point(7, 3);
			this.btnInsertAutorizante.Location = new System.Drawing.Point(622, 177);
			this.btnInsertAutorizante.Name = "btnInsertAutorizante";
			this.btnInsertAutorizante.RoundedCornersMask = ((byte)(15));
			this.btnInsertAutorizante.RoundedCornersRadius = 0;
			this.btnInsertAutorizante.Size = new System.Drawing.Size(34, 27);
			this.btnInsertAutorizante.TabIndex = 14;
			this.btnInsertAutorizante.TabStop = false;
			this.btnInsertAutorizante.UseAbsoluteImagePositioning = true;
			this.btnInsertAutorizante.UseCompatibleTextRendering = true;
			this.btnInsertAutorizante.UseVisualStyleBackColor = false;
			this.btnInsertAutorizante.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnInsertAutorizante.Click += new System.EventHandler(this.btnInsertAutorizante_Click);
			// 
			// clnID
			// 
			this.clnID.HeaderText = "Reg.:";
			this.clnID.Name = "clnID";
			this.clnID.ReadOnly = true;
			this.clnID.Width = 80;
			// 
			// clnDespesaData
			// 
			this.clnDespesaData.HeaderText = "Data";
			this.clnDespesaData.Name = "clnDespesaData";
			this.clnDespesaData.ReadOnly = true;
			this.clnDespesaData.Width = 90;
			// 
			// clnCredor
			// 
			this.clnCredor.HeaderText = "Credor";
			this.clnCredor.Name = "clnCredor";
			this.clnCredor.ReadOnly = true;
			this.clnCredor.Width = 300;
			// 
			// clnValor
			// 
			this.clnValor.HeaderText = "Valor";
			this.clnValor.Name = "clnValor";
			this.clnValor.ReadOnly = true;
			// 
			// frmProvisorio
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(693, 714);
			this.Controls.Add(this.btnConcluir);
			this.Controls.Add(this.btnInserirDespesa);
			this.Controls.Add(this.line2);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.dgvListagem);
			this.Controls.Add(this.btnInsertAutorizante);
			this.Controls.Add(this.btnInsertComprador);
			this.Controls.Add(this.btnSetComprador);
			this.Controls.Add(this.txtComprador);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.btnSetConta);
			this.Controls.Add(this.txtConta);
			this.Controls.Add(this.lblContaDetalhe);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.btnSetSetor);
			this.Controls.Add(this.txtSetor);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnSetAutorizante);
			this.Controls.Add(this.txtAutorizante);
			this.Controls.Add(this.lblContribuinte);
			this.Controls.Add(this.txtValorProvisorio);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.dtpRetiradaData);
			this.Controls.Add(this.txtFinalidade);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblFin);
			this.Controls.Add(this.tspMenu);
			this.KeyPreview = true;
			this.Name = "frmProvisorio";
			this.Shown += new System.EventHandler(this.frmProvisorio_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.lblFin, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.txtFinalidade, 0);
			this.Controls.SetChildIndex(this.dtpRetiradaData, 0);
			this.Controls.SetChildIndex(this.label8, 0);
			this.Controls.SetChildIndex(this.txtValorProvisorio, 0);
			this.Controls.SetChildIndex(this.lblContribuinte, 0);
			this.Controls.SetChildIndex(this.txtAutorizante, 0);
			this.Controls.SetChildIndex(this.btnSetAutorizante, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.txtSetor, 0);
			this.Controls.SetChildIndex(this.btnSetSetor, 0);
			this.Controls.SetChildIndex(this.label19, 0);
			this.Controls.SetChildIndex(this.lblContaDetalhe, 0);
			this.Controls.SetChildIndex(this.txtConta, 0);
			this.Controls.SetChildIndex(this.btnSetConta, 0);
			this.Controls.SetChildIndex(this.label14, 0);
			this.Controls.SetChildIndex(this.txtComprador, 0);
			this.Controls.SetChildIndex(this.btnSetComprador, 0);
			this.Controls.SetChildIndex(this.btnInsertComprador, 0);
			this.Controls.SetChildIndex(this.btnInsertAutorizante, 0);
			this.Controls.SetChildIndex(this.dgvListagem, 0);
			this.Controls.SetChildIndex(this.label6, 0);
			this.Controls.SetChildIndex(this.line2, 0);
			this.Controls.SetChildIndex(this.btnInserirDespesa, 0);
			this.Controls.SetChildIndex(this.btnConcluir, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label lbl_IdTexto;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnSalvar;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		private System.Windows.Forms.ToolStripButton btnFechar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		internal System.Windows.Forms.TextBox txtFinalidade;
		internal System.Windows.Forms.Label lblFin;
		private System.Windows.Forms.DateTimePicker dtpRetiradaData;
		internal System.Windows.Forms.Label label1;
		private CamadaUC.ucOnlyNumbers txtValorProvisorio;
		internal System.Windows.Forms.Label label8;
		internal VIBlend.WinForms.Controls.vButton btnSetAutorizante;
		internal System.Windows.Forms.TextBox txtAutorizante;
		internal System.Windows.Forms.Label lblContribuinte;
		internal VIBlend.WinForms.Controls.vButton btnSetSetor;
		internal System.Windows.Forms.TextBox txtSetor;
		internal System.Windows.Forms.Label label5;
		internal VIBlend.WinForms.Controls.vButton btnSetConta;
		internal System.Windows.Forms.TextBox txtConta;
		internal System.Windows.Forms.Label lblContaDetalhe;
		internal System.Windows.Forms.Label label19;
		internal VIBlend.WinForms.Controls.vButton btnSetComprador;
		internal System.Windows.Forms.TextBox txtComprador;
		internal System.Windows.Forms.Label label14;
		internal VIBlend.WinForms.Controls.vButton btnInsertComprador;
		internal System.Windows.Forms.DataGridView dgvListagem;
		private AwesomeShapeControl.Line line2;
		internal System.Windows.Forms.Label label6;
		internal VIBlend.WinForms.Controls.vButton btnInserirDespesa;
		internal VIBlend.WinForms.Controls.vButton btnConcluir;
		internal VIBlend.WinForms.Controls.vButton btnInsertAutorizante;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnID;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnDespesaData;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnCredor;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValor;
	}
}
