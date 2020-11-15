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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnSalvar = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.btnExcluir = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnRecibo = new System.Windows.Forms.ToolStripButton();
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
			this.btnSetComprador = new VIBlend.WinForms.Controls.vButton();
			this.txtComprador = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.btnInsertComprador = new VIBlend.WinForms.Controls.vButton();
			this.dgvListagem = new System.Windows.Forms.DataGridView();
			this.clnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnDespesaData = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnCredor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.line2 = new AwesomeShapeControl.Line();
			this.label6 = new System.Windows.Forms.Label();
			this.btnAnexarDespesa = new VIBlend.WinForms.Controls.vButton();
			this.btnInsertAutorizante = new VIBlend.WinForms.Controls.vButton();
			this.btnInserirDespesa = new VIBlend.WinForms.Controls.vButton();
			this.txtValorProvisorio = new CamadaUC.ucOnlyNumbers();
			this.btnFinalizar = new VIBlend.WinForms.Controls.vButton();
			this.mnuOperacoes = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuItemAnexar = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuItemDesvincular = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuItemInserir = new System.Windows.Forms.ToolStripMenuItem();
			this.lblConcluida = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).BeginInit();
			this.mnuOperacoes.SuspendLayout();
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
            this.btnExcluir,
            this.btnFechar,
            this.toolStripSeparator2,
            this.btnRecibo});
			this.tspMenu.Location = new System.Drawing.Point(2, 605);
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
			// btnExcluir
			// 
			this.btnExcluir.Image = global::CamadaUI.Properties.Resources.lixeira_24;
			this.btnExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExcluir.Name = "btnExcluir";
			this.btnExcluir.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnExcluir.Size = new System.Drawing.Size(90, 41);
			this.btnExcluir.Text = "&Excluir";
			this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
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
			// btnRecibo
			// 
			this.btnRecibo.Image = global::CamadaUI.Properties.Resources.imprimir_24;
			this.btnRecibo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnRecibo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRecibo.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
			this.btnRecibo.Name = "btnRecibo";
			this.btnRecibo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnRecibo.Size = new System.Drawing.Size(91, 41);
			this.btnRecibo.Text = "&Recibo";
			this.btnRecibo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnRecibo.Click += new System.EventHandler(this.btnRecibo_Click);
			// 
			// txtFinalidade
			// 
			this.txtFinalidade.BackColor = System.Drawing.Color.White;
			this.txtFinalidade.Location = new System.Drawing.Point(163, 255);
			this.txtFinalidade.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtFinalidade.MaxLength = 100;
			this.txtFinalidade.Name = "txtFinalidade";
			this.txtFinalidade.Size = new System.Drawing.Size(490, 27);
			this.txtFinalidade.TabIndex = 30;
			this.txtFinalidade.Tag = "";
			this.txtFinalidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// lblFin
			// 
			this.lblFin.AutoSize = true;
			this.lblFin.BackColor = System.Drawing.Color.Transparent;
			this.lblFin.ForeColor = System.Drawing.Color.Black;
			this.lblFin.Location = new System.Drawing.Point(81, 258);
			this.lblFin.Name = "lblFin";
			this.lblFin.Size = new System.Drawing.Size(76, 19);
			this.lblFin.TabIndex = 29;
			this.lblFin.Text = "Finalidade";
			// 
			// dtpRetiradaData
			// 
			this.dtpRetiradaData.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpRetiradaData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpRetiradaData.Location = new System.Drawing.Point(163, 310);
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
			this.label1.Location = new System.Drawing.Point(159, 288);
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
			this.label8.Location = new System.Drawing.Point(329, 288);
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
			this.btnSetAutorizante.Location = new System.Drawing.Point(580, 177);
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
			this.txtAutorizante.BackColor = System.Drawing.Color.White;
			this.txtAutorizante.Location = new System.Drawing.Point(163, 177);
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
			this.lblContribuinte.Location = new System.Drawing.Point(74, 180);
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
			this.btnSetSetor.Location = new System.Drawing.Point(397, 138);
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
			this.txtSetor.Location = new System.Drawing.Point(163, 138);
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
			this.label5.Location = new System.Drawing.Point(52, 141);
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
			this.btnSetConta.Location = new System.Drawing.Point(397, 69);
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
			this.txtConta.Location = new System.Drawing.Point(163, 69);
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
			this.lblContaDetalhe.Location = new System.Drawing.Point(163, 99);
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
			this.label19.Location = new System.Drawing.Point(47, 72);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(110, 19);
			this.label19.TabIndex = 1;
			this.label19.Text = "Conta Debitada";
			// 
			// btnSetComprador
			// 
			this.btnSetComprador.AllowAnimations = true;
			this.btnSetComprador.BackColor = System.Drawing.Color.Transparent;
			this.btnSetComprador.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetComprador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetComprador.Location = new System.Drawing.Point(580, 216);
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
			this.txtComprador.BackColor = System.Drawing.Color.White;
			this.txtComprador.Location = new System.Drawing.Point(163, 216);
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
			this.label14.Location = new System.Drawing.Point(77, 219);
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
			this.btnInsertComprador.Location = new System.Drawing.Point(620, 216);
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
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.OldLace;
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
			this.dgvListagem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvListagem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvListagem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvListagem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvListagem.ColumnHeadersHeight = 33;
			this.dgvListagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvListagem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnID,
            this.clnDespesaData,
            this.clnCredor,
            this.clnValor});
			this.dgvListagem.EnableHeadersVisualStyles = false;
			this.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption;
			this.dgvListagem.Location = new System.Drawing.Point(43, 384);
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
			this.dgvListagem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvListagem_MouseDown);
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
			// line2
			// 
			this.line2.EndPoint = new System.Drawing.Point(460, 5);
			this.line2.LineColor = System.Drawing.Color.LightSlateGray;
			this.line2.LineWidth = 3F;
			this.line2.Location = new System.Drawing.Point(192, 359);
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
			this.label6.Location = new System.Drawing.Point(23, 351);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(166, 23);
			this.label6.TabIndex = 50;
			this.label6.Text = "Despesas Efetuadas";
			// 
			// btnAnexarDespesa
			// 
			this.btnAnexarDespesa.AllowAnimations = true;
			this.btnAnexarDespesa.BackColor = System.Drawing.Color.Transparent;
			this.btnAnexarDespesa.Enabled = false;
			this.btnAnexarDespesa.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnAnexarDespesa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAnexarDespesa.Image = global::CamadaUI.Properties.Resources.money_red_24;
			this.btnAnexarDespesa.ImageAbsolutePosition = new System.Drawing.Point(6, 1);
			this.btnAnexarDespesa.Location = new System.Drawing.Point(43, 561);
			this.btnAnexarDespesa.Name = "btnAnexarDespesa";
			this.btnAnexarDespesa.RoundedCornersMask = ((byte)(15));
			this.btnAnexarDespesa.RoundedCornersRadius = 0;
			this.btnAnexarDespesa.Size = new System.Drawing.Size(162, 35);
			this.btnAnexarDespesa.TabIndex = 52;
			this.btnAnexarDespesa.Text = "Anexar Despesa";
			this.btnAnexarDespesa.TextAbsolutePosition = new System.Drawing.Point(25, 5);
			this.btnAnexarDespesa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAnexarDespesa.UseAbsoluteImagePositioning = true;
			this.btnAnexarDespesa.UseAbsoluteTextPositioning = true;
			this.btnAnexarDespesa.UseCompatibleTextRendering = true;
			this.btnAnexarDespesa.UseVisualStyleBackColor = false;
			this.btnAnexarDespesa.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnAnexarDespesa.Click += new System.EventHandler(this.btnAnexarDespesa_Click);
			// 
			// btnInsertAutorizante
			// 
			this.btnInsertAutorizante.AllowAnimations = true;
			this.btnInsertAutorizante.BackColor = System.Drawing.Color.Transparent;
			this.btnInsertAutorizante.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnInsertAutorizante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInsertAutorizante.Image = global::CamadaUI.Properties.Resources.add_16;
			this.btnInsertAutorizante.ImageAbsolutePosition = new System.Drawing.Point(7, 3);
			this.btnInsertAutorizante.Location = new System.Drawing.Point(620, 177);
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
			// btnInserirDespesa
			// 
			this.btnInserirDespesa.AllowAnimations = true;
			this.btnInserirDespesa.BackColor = System.Drawing.Color.Transparent;
			this.btnInserirDespesa.Enabled = false;
			this.btnInserirDespesa.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnInserirDespesa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInserirDespesa.Image = global::CamadaUI.Properties.Resources.add_24;
			this.btnInserirDespesa.ImageAbsolutePosition = new System.Drawing.Point(11, 6);
			this.btnInserirDespesa.Location = new System.Drawing.Point(211, 561);
			this.btnInserirDespesa.Name = "btnInserirDespesa";
			this.btnInserirDespesa.RoundedCornersMask = ((byte)(15));
			this.btnInserirDespesa.RoundedCornersRadius = 0;
			this.btnInserirDespesa.Size = new System.Drawing.Size(162, 35);
			this.btnInserirDespesa.TabIndex = 52;
			this.btnInserirDespesa.Text = "Inserir Despesa";
			this.btnInserirDespesa.TextAbsolutePosition = new System.Drawing.Point(25, 5);
			this.btnInserirDespesa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnInserirDespesa.UseAbsoluteImagePositioning = true;
			this.btnInserirDespesa.UseAbsoluteTextPositioning = true;
			this.btnInserirDespesa.UseCompatibleTextRendering = true;
			this.btnInserirDespesa.UseVisualStyleBackColor = false;
			this.btnInserirDespesa.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnInserirDespesa.Click += new System.EventHandler(this.btnInserirDespesa_Click);
			// 
			// txtValorProvisorio
			// 
			this.txtValorProvisorio.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtValorProvisorio.Inteiro = false;
			this.txtValorProvisorio.Location = new System.Drawing.Point(333, 310);
			this.txtValorProvisorio.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtValorProvisorio.Moeda = false;
			this.txtValorProvisorio.Name = "txtValorProvisorio";
			this.txtValorProvisorio.Positivo = true;
			this.txtValorProvisorio.Size = new System.Drawing.Size(145, 31);
			this.txtValorProvisorio.TabIndex = 35;
			this.txtValorProvisorio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnFinalizar
			// 
			this.btnFinalizar.AllowAnimations = true;
			this.btnFinalizar.BackColor = System.Drawing.Color.Transparent;
			this.btnFinalizar.Enabled = false;
			this.btnFinalizar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFinalizar.Image = global::CamadaUI.Properties.Resources.accept_24;
			this.btnFinalizar.ImageAbsolutePosition = new System.Drawing.Point(10, 5);
			this.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.TopRight;
			this.btnFinalizar.Location = new System.Drawing.Point(471, 561);
			this.btnFinalizar.Name = "btnFinalizar";
			this.btnFinalizar.RoundedCornersMask = ((byte)(15));
			this.btnFinalizar.RoundedCornersRadius = 0;
			this.btnFinalizar.Size = new System.Drawing.Size(180, 35);
			this.btnFinalizar.TabIndex = 53;
			this.btnFinalizar.Text = "Finalizar Provisória";
			this.btnFinalizar.TextAbsolutePosition = new System.Drawing.Point(25, 5);
			this.btnFinalizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnFinalizar.UseAbsoluteImagePositioning = true;
			this.btnFinalizar.UseAbsoluteTextPositioning = true;
			this.btnFinalizar.UseCompatibleTextRendering = true;
			this.btnFinalizar.UseVisualStyleBackColor = false;
			this.btnFinalizar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
			// 
			// mnuOperacoes
			// 
			this.mnuOperacoes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuOperacoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemAnexar,
            this.mnuItemDesvincular,
            this.mnuItemInserir});
			this.mnuOperacoes.Name = "mnuOperacoes";
			this.mnuOperacoes.Size = new System.Drawing.Size(224, 82);
			// 
			// mnuItemAnexar
			// 
			this.mnuItemAnexar.Image = global::CamadaUI.Properties.Resources.money_red_24;
			this.mnuItemAnexar.Name = "mnuItemAnexar";
			this.mnuItemAnexar.Size = new System.Drawing.Size(223, 26);
			this.mnuItemAnexar.Text = "Anexar Despesa";
			this.mnuItemAnexar.Click += new System.EventHandler(this.mnuItemAnexar_Click);
			// 
			// mnuItemDesvincular
			// 
			this.mnuItemDesvincular.Image = global::CamadaUI.Properties.Resources.delete_16;
			this.mnuItemDesvincular.Name = "mnuItemDesvincular";
			this.mnuItemDesvincular.Size = new System.Drawing.Size(223, 26);
			this.mnuItemDesvincular.Text = "Desvincular Despesa";
			this.mnuItemDesvincular.Click += new System.EventHandler(this.mnuItemDesvincular_Click);
			// 
			// mnuItemInserir
			// 
			this.mnuItemInserir.Image = global::CamadaUI.Properties.Resources.add_16;
			this.mnuItemInserir.Name = "mnuItemInserir";
			this.mnuItemInserir.Size = new System.Drawing.Size(223, 26);
			this.mnuItemInserir.Text = "Inserir Despesa";
			this.mnuItemInserir.Click += new System.EventHandler(this.mnuItemInserir_Click);
			// 
			// lblConcluida
			// 
			this.lblConcluida.AutoSize = true;
			this.lblConcluida.BackColor = System.Drawing.Color.AntiqueWhite;
			this.lblConcluida.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblConcluida.ForeColor = System.Drawing.Color.DarkRed;
			this.lblConcluida.Location = new System.Drawing.Point(434, 614);
			this.lblConcluida.Name = "lblConcluida";
			this.lblConcluida.Size = new System.Drawing.Size(144, 29);
			this.lblConcluida.TabIndex = 54;
			this.lblConcluida.Text = "CONCLUÍDA !";
			this.lblConcluida.Visible = false;
			// 
			// frmProvisorio
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(693, 652);
			this.Controls.Add(this.lblConcluida);
			this.Controls.Add(this.btnFinalizar);
			this.Controls.Add(this.btnInserirDespesa);
			this.Controls.Add(this.btnAnexarDespesa);
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
			this.Controls.SetChildIndex(this.btnAnexarDespesa, 0);
			this.Controls.SetChildIndex(this.btnInserirDespesa, 0);
			this.Controls.SetChildIndex(this.btnFinalizar, 0);
			this.Controls.SetChildIndex(this.lblConcluida, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).EndInit();
			this.mnuOperacoes.ResumeLayout(false);
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
		internal VIBlend.WinForms.Controls.vButton btnAnexarDespesa;
		internal VIBlend.WinForms.Controls.vButton btnInsertAutorizante;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnID;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnDespesaData;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnCredor;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValor;
		internal VIBlend.WinForms.Controls.vButton btnInserirDespesa;
		internal VIBlend.WinForms.Controls.vButton btnFinalizar;
		private System.Windows.Forms.ContextMenuStrip mnuOperacoes;
		private System.Windows.Forms.ToolStripMenuItem mnuItemAnexar;
		private System.Windows.Forms.ToolStripMenuItem mnuItemInserir;
		private System.Windows.Forms.ToolStripMenuItem mnuItemDesvincular;
		private System.Windows.Forms.ToolStripButton btnRecibo;
		private System.Windows.Forms.Label lblConcluida;
		private System.Windows.Forms.ToolStripButton btnExcluir;
	}
}
