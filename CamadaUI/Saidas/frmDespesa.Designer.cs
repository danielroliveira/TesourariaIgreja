namespace CamadaUI.Saidas
{
	partial class frmDespesa
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDespesa));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnNovo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalvar = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuImagem = new System.Windows.Forms.ToolStripDropDownButton();
			this.btnInserirImagem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnVerImagem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnRemoverImagem = new System.Windows.Forms.ToolStripMenuItem();
			this.txtDespesaDescricao = new System.Windows.Forms.TextBox();
			this.lblCongregacao = new System.Windows.Forms.Label();
			this.dtpDespesaData = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDespesaValor = new CamadaUC.ucOnlyNumbers();
			this.label8 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtDocumentoNumero = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSetCredor = new VIBlend.WinForms.Controls.vButton();
			this.txtCredor = new System.Windows.Forms.TextBox();
			this.lblContribuinte = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDespesaTipo = new System.Windows.Forms.TextBox();
			this.btnSetDespesaTipo = new VIBlend.WinForms.Controls.vButton();
			this.btnSetSetor = new VIBlend.WinForms.Controls.vButton();
			this.txtSetor = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.chkParcelado = new System.Windows.Forms.CheckBox();
			this.pnlParcelas = new System.Windows.Forms.Panel();
			this.numParcelas = new System.Windows.Forms.NumericUpDown();
			this.lblParcelas = new System.Windows.Forms.Label();
			this.btnParcelasGerar = new VIBlend.WinForms.Controls.vButton();
			this.txtDocumentoTipo = new System.Windows.Forms.TextBox();
			this.btnSetDocumentoTipo = new VIBlend.WinForms.Controls.vButton();
			this.line2 = new AwesomeShapeControl.Line();
			this.label6 = new System.Windows.Forms.Label();
			this.dgvListagem = new System.Windows.Forms.DataGridView();
			this.clnIdentificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnForma = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnSituacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label7 = new System.Windows.Forms.Label();
			this.txtTitular = new System.Windows.Forms.TextBox();
			this.btnSetTitular = new VIBlend.WinForms.Controls.vButton();
			this.btnInsertTitular = new VIBlend.WinForms.Controls.vButton();
			this.pnlDataValor = new System.Windows.Forms.Panel();
			this.lblSitBlock = new System.Windows.Forms.Label();
			this.dtpDataInicial = new System.Windows.Forms.DateTimePicker();
			this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.chkReferencia = new System.Windows.Forms.CheckBox();
			this.pnlReferencia = new System.Windows.Forms.Panel();
			this.lblReferencia = new System.Windows.Forms.Label();
			this.mnuOperacoes = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuAdicionarAPagar = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuEditarAPagar = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuExcluirAPagar = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuImagemAPagar = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuImagemInserir = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuImagemVisualizar = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuImagemRemover = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.pnlParcelas.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numParcelas)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).BeginInit();
			this.pnlDataValor.SuspendLayout();
			this.pnlReferencia.SuspendLayout();
			this.mnuOperacoes.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(484, 0);
			this.lblTitulo.Size = new System.Drawing.Size(252, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "Cadastro de Despesas";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(736, 0);
			this.btnClose.TabIndex = 3;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblID);
			this.panel1.Controls.Add(this.lbl_IdTexto);
			this.panel1.Size = new System.Drawing.Size(776, 50);
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
            this.btnNovo,
            this.toolStripSeparator1,
            this.btnSalvar,
            this.btnCancelar,
            this.btnFechar,
            this.toolStripSeparator2,
            this.mnuImagem});
			this.tspMenu.Location = new System.Drawing.Point(2, 598);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(772, 44);
			this.tspMenu.TabIndex = 28;
			this.tspMenu.TabStop = true;
			this.tspMenu.Text = "toolStrip1";
			// 
			// btnNovo
			// 
			this.btnNovo.Image = global::CamadaUI.Properties.Resources.adicionar_30;
			this.btnNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNovo.Name = "btnNovo";
			this.btnNovo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnNovo.Size = new System.Drawing.Size(86, 41);
			this.btnNovo.Text = "&Nova";
			this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnNovo.ToolTipText = "Nova Despesa";
			this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 44);
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
			// mnuImagem
			// 
			this.mnuImagem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInserirImagem,
            this.btnVerImagem,
            this.toolStripSeparator3,
            this.btnRemoverImagem});
			this.mnuImagem.Image = ((System.Drawing.Image)(resources.GetObject("mnuImagem.Image")));
			this.mnuImagem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuImagem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuImagem.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
			this.mnuImagem.Name = "mnuImagem";
			this.mnuImagem.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.mnuImagem.Size = new System.Drawing.Size(174, 41);
			this.mnuImagem.Text = "Imagem Despesa";
			this.mnuImagem.Click += new System.EventHandler(this.mnuImagem_Click);
			// 
			// btnInserirImagem
			// 
			this.btnInserirImagem.Image = global::CamadaUI.Properties.Resources.add_16;
			this.btnInserirImagem.Name = "btnInserirImagem";
			this.btnInserirImagem.Size = new System.Drawing.Size(191, 24);
			this.btnInserirImagem.Text = "Inserir Imagem";
			this.btnInserirImagem.Click += new System.EventHandler(this.btnInserirImagem_Click);
			// 
			// btnVerImagem
			// 
			this.btnVerImagem.Image = global::CamadaUI.Properties.Resources.search_page_24;
			this.btnVerImagem.Name = "btnVerImagem";
			this.btnVerImagem.Size = new System.Drawing.Size(191, 24);
			this.btnVerImagem.Text = "Ver Imagem";
			this.btnVerImagem.Click += new System.EventHandler(this.btnVerImagem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(188, 6);
			// 
			// btnRemoverImagem
			// 
			this.btnRemoverImagem.Image = global::CamadaUI.Properties.Resources.delete_16;
			this.btnRemoverImagem.Name = "btnRemoverImagem";
			this.btnRemoverImagem.Size = new System.Drawing.Size(191, 24);
			this.btnRemoverImagem.Text = "Remover Imagem";
			this.btnRemoverImagem.Click += new System.EventHandler(this.btnRemoverImagem_Click);
			// 
			// txtDespesaDescricao
			// 
			this.txtDespesaDescricao.BackColor = System.Drawing.Color.White;
			this.txtDespesaDescricao.Location = new System.Drawing.Point(216, 258);
			this.txtDespesaDescricao.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtDespesaDescricao.MaxLength = 100;
			this.txtDespesaDescricao.Name = "txtDespesaDescricao";
			this.txtDespesaDescricao.Size = new System.Drawing.Size(507, 27);
			this.txtDespesaDescricao.TabIndex = 20;
			this.txtDespesaDescricao.Tag = "";
			this.txtDespesaDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// lblCongregacao
			// 
			this.lblCongregacao.AutoSize = true;
			this.lblCongregacao.BackColor = System.Drawing.Color.Transparent;
			this.lblCongregacao.ForeColor = System.Drawing.Color.Black;
			this.lblCongregacao.Location = new System.Drawing.Point(137, 261);
			this.lblCongregacao.Name = "lblCongregacao";
			this.lblCongregacao.Size = new System.Drawing.Size(73, 19);
			this.lblCongregacao.TabIndex = 19;
			this.lblCongregacao.Text = "Descrição";
			// 
			// dtpDespesaData
			// 
			this.dtpDespesaData.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpDespesaData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDespesaData.Location = new System.Drawing.Point(203, 6);
			this.dtpDespesaData.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.dtpDespesaData.Name = "dtpDespesaData";
			this.dtpDespesaData.Size = new System.Drawing.Size(145, 31);
			this.dtpDespesaData.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(77, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 19);
			this.label1.TabIndex = 3;
			this.label1.Text = "Data da Despesa";
			// 
			// txtDespesaValor
			// 
			this.txtDespesaValor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDespesaValor.Inteiro = false;
			this.txtDespesaValor.Location = new System.Drawing.Point(492, 6);
			this.txtDespesaValor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtDespesaValor.Moeda = false;
			this.txtDespesaValor.Name = "txtDespesaValor";
			this.txtDespesaValor.Positivo = true;
			this.txtDespesaValor.Size = new System.Drawing.Size(145, 31);
			this.txtDespesaValor.TabIndex = 2;
			this.txtDespesaValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.ForeColor = System.Drawing.Color.Black;
			this.label8.Location = new System.Drawing.Point(364, 12);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(122, 19);
			this.label8.TabIndex = 1;
			this.label8.Text = "Valor da Despesa";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(503, 222);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 19);
			this.label2.TabIndex = 17;
			this.label2.Text = "Doc. nº";
			// 
			// txtDocumentoNumero
			// 
			this.txtDocumentoNumero.BackColor = System.Drawing.Color.White;
			this.txtDocumentoNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtDocumentoNumero.Location = new System.Drawing.Point(566, 219);
			this.txtDocumentoNumero.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtDocumentoNumero.MaxLength = 30;
			this.txtDocumentoNumero.Name = "txtDocumentoNumero";
			this.txtDocumentoNumero.Size = new System.Drawing.Size(157, 27);
			this.txtDocumentoNumero.TabIndex = 18;
			this.txtDocumentoNumero.Tag = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(75, 222);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(135, 19);
			this.label3.TabIndex = 14;
			this.label3.Text = "Tipo de Documento";
			// 
			// btnSetCredor
			// 
			this.btnSetCredor.AllowAnimations = true;
			this.btnSetCredor.BackColor = System.Drawing.Color.Transparent;
			this.btnSetCredor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetCredor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetCredor.Location = new System.Drawing.Point(649, 102);
			this.btnSetCredor.Name = "btnSetCredor";
			this.btnSetCredor.RoundedCornersMask = ((byte)(15));
			this.btnSetCredor.RoundedCornersRadius = 0;
			this.btnSetCredor.Size = new System.Drawing.Size(34, 27);
			this.btnSetCredor.TabIndex = 6;
			this.btnSetCredor.TabStop = false;
			this.btnSetCredor.Text = "...";
			this.btnSetCredor.UseCompatibleTextRendering = true;
			this.btnSetCredor.UseVisualStyleBackColor = false;
			this.btnSetCredor.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetCredor.Click += new System.EventHandler(this.btnSetCredor_Click);
			// 
			// txtCredor
			// 
			this.txtCredor.Location = new System.Drawing.Point(216, 102);
			this.txtCredor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCredor.MaxLength = 30;
			this.txtCredor.Name = "txtCredor";
			this.txtCredor.Size = new System.Drawing.Size(427, 27);
			this.txtCredor.TabIndex = 5;
			this.txtCredor.Tag = "Pressione a tecla (+) para procurar";
			this.txtCredor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// lblContribuinte
			// 
			this.lblContribuinte.AutoSize = true;
			this.lblContribuinte.BackColor = System.Drawing.Color.Transparent;
			this.lblContribuinte.ForeColor = System.Drawing.Color.Black;
			this.lblContribuinte.Location = new System.Drawing.Point(72, 105);
			this.lblContribuinte.Name = "lblContribuinte";
			this.lblContribuinte.Size = new System.Drawing.Size(138, 19);
			this.lblContribuinte.TabIndex = 4;
			this.lblContribuinte.Text = "Credor / Fornecedor";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(93, 183);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(117, 19);
			this.label4.TabIndex = 11;
			this.label4.Text = "Tipo de Despesa";
			// 
			// txtDespesaTipo
			// 
			this.txtDespesaTipo.Location = new System.Drawing.Point(216, 180);
			this.txtDespesaTipo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtDespesaTipo.MaxLength = 30;
			this.txtDespesaTipo.Name = "txtDespesaTipo";
			this.txtDespesaTipo.Size = new System.Drawing.Size(427, 27);
			this.txtDespesaTipo.TabIndex = 12;
			this.txtDespesaTipo.Tag = "Pressione a tecla (+) para procurar";
			this.txtDespesaTipo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// btnSetDespesaTipo
			// 
			this.btnSetDespesaTipo.AllowAnimations = true;
			this.btnSetDespesaTipo.BackColor = System.Drawing.Color.Transparent;
			this.btnSetDespesaTipo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetDespesaTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetDespesaTipo.Location = new System.Drawing.Point(649, 180);
			this.btnSetDespesaTipo.Name = "btnSetDespesaTipo";
			this.btnSetDespesaTipo.RoundedCornersMask = ((byte)(15));
			this.btnSetDespesaTipo.RoundedCornersRadius = 0;
			this.btnSetDespesaTipo.Size = new System.Drawing.Size(34, 27);
			this.btnSetDespesaTipo.TabIndex = 13;
			this.btnSetDespesaTipo.TabStop = false;
			this.btnSetDespesaTipo.Text = "...";
			this.btnSetDespesaTipo.UseCompatibleTextRendering = true;
			this.btnSetDespesaTipo.UseVisualStyleBackColor = false;
			this.btnSetDespesaTipo.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetDespesaTipo.Click += new System.EventHandler(this.btnSetDespesaTipo_Click);
			// 
			// btnSetSetor
			// 
			this.btnSetSetor.AllowAnimations = true;
			this.btnSetSetor.BackColor = System.Drawing.Color.Transparent;
			this.btnSetSetor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetSetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetSetor.Location = new System.Drawing.Point(551, 63);
			this.btnSetSetor.Name = "btnSetSetor";
			this.btnSetSetor.RoundedCornersMask = ((byte)(15));
			this.btnSetSetor.RoundedCornersRadius = 0;
			this.btnSetSetor.Size = new System.Drawing.Size(34, 27);
			this.btnSetSetor.TabIndex = 3;
			this.btnSetSetor.TabStop = false;
			this.btnSetSetor.Text = "...";
			this.btnSetSetor.UseCompatibleTextRendering = true;
			this.btnSetSetor.UseVisualStyleBackColor = false;
			this.btnSetSetor.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetSetor.Click += new System.EventHandler(this.btnSetSetor_Click);
			// 
			// txtSetor
			// 
			this.txtSetor.Location = new System.Drawing.Point(216, 63);
			this.txtSetor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtSetor.MaxLength = 30;
			this.txtSetor.Name = "txtSetor";
			this.txtSetor.Size = new System.Drawing.Size(329, 27);
			this.txtSetor.TabIndex = 2;
			this.txtSetor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(105, 66);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(105, 19);
			this.label5.TabIndex = 1;
			this.label5.Text = "Setor Debitado";
			// 
			// chkParcelado
			// 
			this.chkParcelado.AutoSize = true;
			this.chkParcelado.Location = new System.Drawing.Point(16, 12);
			this.chkParcelado.Name = "chkParcelado";
			this.chkParcelado.Size = new System.Drawing.Size(99, 23);
			this.chkParcelado.TabIndex = 0;
			this.chkParcelado.Text = "Parcelado?";
			this.chkParcelado.UseVisualStyleBackColor = true;
			this.chkParcelado.CheckedChanged += new System.EventHandler(this.chkParcelado_CheckedChanged);
			// 
			// pnlParcelas
			// 
			this.pnlParcelas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pnlParcelas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(215)))), ((int)(((byte)(233)))));
			this.pnlParcelas.Controls.Add(this.numParcelas);
			this.pnlParcelas.Controls.Add(this.lblParcelas);
			this.pnlParcelas.Controls.Add(this.chkParcelado);
			this.pnlParcelas.Controls.Add(this.btnParcelasGerar);
			this.pnlParcelas.Location = new System.Drawing.Point(12, 419);
			this.pnlParcelas.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.pnlParcelas.Name = "pnlParcelas";
			this.pnlParcelas.Size = new System.Drawing.Size(129, 168);
			this.pnlParcelas.TabIndex = 26;
			// 
			// numParcelas
			// 
			this.numParcelas.Enabled = false;
			this.numParcelas.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numParcelas.Location = new System.Drawing.Point(31, 71);
			this.numParcelas.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.numParcelas.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numParcelas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numParcelas.Name = "numParcelas";
			this.numParcelas.Size = new System.Drawing.Size(65, 31);
			this.numParcelas.TabIndex = 2;
			this.numParcelas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numParcelas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numParcelas_KeyDown);
			// 
			// lblParcelas
			// 
			this.lblParcelas.AutoSize = true;
			this.lblParcelas.BackColor = System.Drawing.Color.Transparent;
			this.lblParcelas.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.lblParcelas.Location = new System.Drawing.Point(31, 46);
			this.lblParcelas.Name = "lblParcelas";
			this.lblParcelas.Size = new System.Drawing.Size(64, 19);
			this.lblParcelas.TabIndex = 1;
			this.lblParcelas.Text = "Parcelas";
			// 
			// btnParcelasGerar
			// 
			this.btnParcelasGerar.AllowAnimations = true;
			this.btnParcelasGerar.BackColor = System.Drawing.Color.Transparent;
			this.btnParcelasGerar.Enabled = false;
			this.btnParcelasGerar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnParcelasGerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnParcelasGerar.Location = new System.Drawing.Point(12, 121);
			this.btnParcelasGerar.Name = "btnParcelasGerar";
			this.btnParcelasGerar.RoundedCornersMask = ((byte)(15));
			this.btnParcelasGerar.RoundedCornersRadius = 0;
			this.btnParcelasGerar.Size = new System.Drawing.Size(102, 35);
			this.btnParcelasGerar.TabIndex = 3;
			this.btnParcelasGerar.Text = "Gerar";
			this.btnParcelasGerar.UseCompatibleTextRendering = true;
			this.btnParcelasGerar.UseVisualStyleBackColor = false;
			this.btnParcelasGerar.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			// 
			// txtDocumentoTipo
			// 
			this.txtDocumentoTipo.Location = new System.Drawing.Point(216, 219);
			this.txtDocumentoTipo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtDocumentoTipo.MaxLength = 30;
			this.txtDocumentoTipo.Name = "txtDocumentoTipo";
			this.txtDocumentoTipo.Size = new System.Drawing.Size(228, 27);
			this.txtDocumentoTipo.TabIndex = 15;
			this.txtDocumentoTipo.Tag = "Pressione a tecla (+) para procurar ou use atalho numérico";
			this.txtDocumentoTipo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			this.txtDocumentoTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
			// 
			// btnSetDocumentoTipo
			// 
			this.btnSetDocumentoTipo.AllowAnimations = true;
			this.btnSetDocumentoTipo.BackColor = System.Drawing.Color.Transparent;
			this.btnSetDocumentoTipo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetDocumentoTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetDocumentoTipo.Location = new System.Drawing.Point(450, 219);
			this.btnSetDocumentoTipo.Name = "btnSetDocumentoTipo";
			this.btnSetDocumentoTipo.RoundedCornersMask = ((byte)(15));
			this.btnSetDocumentoTipo.RoundedCornersRadius = 0;
			this.btnSetDocumentoTipo.Size = new System.Drawing.Size(34, 27);
			this.btnSetDocumentoTipo.TabIndex = 16;
			this.btnSetDocumentoTipo.TabStop = false;
			this.btnSetDocumentoTipo.Text = "n";
			this.btnSetDocumentoTipo.UseCompatibleTextRendering = true;
			this.btnSetDocumentoTipo.UseVisualStyleBackColor = false;
			this.btnSetDocumentoTipo.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetDocumentoTipo.Click += new System.EventHandler(this.btnSetDocumentoTipo_Click);
			// 
			// line2
			// 
			this.line2.EndPoint = new System.Drawing.Point(608, 5);
			this.line2.LineColor = System.Drawing.Color.LightSlateGray;
			this.line2.LineWidth = 3F;
			this.line2.Location = new System.Drawing.Point(153, 394);
			this.line2.Name = "line2";
			this.line2.Opacity = 0.5F;
			this.line2.Size = new System.Drawing.Size(613, 11);
			this.line2.StartPoint = new System.Drawing.Point(5, 6);
			this.line2.TabIndex = 25;
			this.line2.TabStop = false;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.LightSlateGray;
			this.label6.Location = new System.Drawing.Point(12, 388);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(141, 23);
			this.label6.TabIndex = 24;
			this.label6.Text = "PARCELAMENTO";
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
			this.dgvListagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.clnIdentificador,
            this.clnForma,
            this.clnSituacao,
            this.clnVencimento,
            this.clnValor});
			this.dgvListagem.EnableHeadersVisualStyles = false;
			this.dgvListagem.GridColor = System.Drawing.SystemColors.ActiveCaption;
			this.dgvListagem.Location = new System.Drawing.Point(153, 419);
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
			this.dgvListagem.TabIndex = 27;
			this.dgvListagem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvListagem_MouseDown);
			// 
			// clnIdentificador
			// 
			this.clnIdentificador.HeaderText = "No. Reg.:";
			this.clnIdentificador.Name = "clnIdentificador";
			this.clnIdentificador.ReadOnly = true;
			this.clnIdentificador.Width = 115;
			// 
			// clnForma
			// 
			this.clnForma.HeaderText = "Forma";
			this.clnForma.Name = "clnForma";
			this.clnForma.ReadOnly = true;
			this.clnForma.Width = 200;
			// 
			// clnSituacao
			// 
			this.clnSituacao.HeaderText = "Situação";
			this.clnSituacao.Name = "clnSituacao";
			this.clnSituacao.ReadOnly = true;
			this.clnSituacao.Width = 90;
			// 
			// clnVencimento
			// 
			this.clnVencimento.HeaderText = "Venc.";
			this.clnVencimento.Name = "clnVencimento";
			this.clnVencimento.ReadOnly = true;
			this.clnVencimento.Width = 80;
			// 
			// clnValor
			// 
			this.clnValor.HeaderText = "Valor";
			this.clnValor.Name = "clnValor";
			this.clnValor.ReadOnly = true;
			this.clnValor.Width = 80;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.ForeColor = System.Drawing.Color.Black;
			this.label7.Location = new System.Drawing.Point(123, 144);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(87, 19);
			this.label7.TabIndex = 7;
			this.label7.Text = "Titularidade";
			// 
			// txtTitular
			// 
			this.txtTitular.Location = new System.Drawing.Point(216, 141);
			this.txtTitular.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtTitular.MaxLength = 30;
			this.txtTitular.Name = "txtTitular";
			this.txtTitular.Size = new System.Drawing.Size(427, 27);
			this.txtTitular.TabIndex = 8;
			this.txtTitular.Tag = "Pressione a tecla (+) para procurar";
			this.txtTitular.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// btnSetTitular
			// 
			this.btnSetTitular.AllowAnimations = true;
			this.btnSetTitular.BackColor = System.Drawing.Color.Transparent;
			this.btnSetTitular.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetTitular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetTitular.Location = new System.Drawing.Point(649, 141);
			this.btnSetTitular.Name = "btnSetTitular";
			this.btnSetTitular.RoundedCornersMask = ((byte)(15));
			this.btnSetTitular.RoundedCornersRadius = 0;
			this.btnSetTitular.Size = new System.Drawing.Size(34, 27);
			this.btnSetTitular.TabIndex = 9;
			this.btnSetTitular.TabStop = false;
			this.btnSetTitular.Text = "...";
			this.btnSetTitular.UseCompatibleTextRendering = true;
			this.btnSetTitular.UseVisualStyleBackColor = false;
			this.btnSetTitular.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetTitular.Click += new System.EventHandler(this.btnSetTitular_Click);
			// 
			// btnInsertTitular
			// 
			this.btnInsertTitular.AllowAnimations = true;
			this.btnInsertTitular.BackColor = System.Drawing.Color.Transparent;
			this.btnInsertTitular.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnInsertTitular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInsertTitular.Image = global::CamadaUI.Properties.Resources.add_16;
			this.btnInsertTitular.ImageAbsolutePosition = new System.Drawing.Point(7, 3);
			this.btnInsertTitular.Location = new System.Drawing.Point(689, 141);
			this.btnInsertTitular.Name = "btnInsertTitular";
			this.btnInsertTitular.RoundedCornersMask = ((byte)(15));
			this.btnInsertTitular.RoundedCornersRadius = 0;
			this.btnInsertTitular.Size = new System.Drawing.Size(34, 27);
			this.btnInsertTitular.TabIndex = 10;
			this.btnInsertTitular.TabStop = false;
			this.btnInsertTitular.UseAbsoluteImagePositioning = true;
			this.btnInsertTitular.UseCompatibleTextRendering = true;
			this.btnInsertTitular.UseVisualStyleBackColor = false;
			this.btnInsertTitular.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnInsertTitular.Click += new System.EventHandler(this.btnInsertTitular_Click);
			// 
			// pnlDataValor
			// 
			this.pnlDataValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pnlDataValor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(215)))), ((int)(((byte)(233)))));
			this.pnlDataValor.Controls.Add(this.dtpDespesaData);
			this.pnlDataValor.Controls.Add(this.label1);
			this.pnlDataValor.Controls.Add(this.txtDespesaValor);
			this.pnlDataValor.Controls.Add(this.label8);
			this.pnlDataValor.Location = new System.Drawing.Point(12, 295);
			this.pnlDataValor.Name = "pnlDataValor";
			this.pnlDataValor.Size = new System.Drawing.Size(749, 44);
			this.pnlDataValor.TabIndex = 22;
			// 
			// lblSitBlock
			// 
			this.lblSitBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSitBlock.AutoSize = true;
			this.lblSitBlock.BackColor = System.Drawing.Color.AntiqueWhite;
			this.lblSitBlock.Font = new System.Drawing.Font("Pathway Gothic One", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSitBlock.ForeColor = System.Drawing.Color.Maroon;
			this.lblSitBlock.Location = new System.Drawing.Point(505, 607);
			this.lblSitBlock.Name = "lblSitBlock";
			this.lblSitBlock.Size = new System.Drawing.Size(157, 24);
			this.lblSitBlock.TabIndex = 0;
			this.lblSitBlock.Text = "- Apenas Visualização -";
			// 
			// dtpDataInicial
			// 
			this.dtpDataInicial.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDataInicial.Location = new System.Drawing.Point(261, 7);
			this.dtpDataInicial.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.dtpDataInicial.Name = "dtpDataInicial";
			this.dtpDataInicial.Size = new System.Drawing.Size(145, 31);
			this.dtpDataInicial.TabIndex = 3;
			// 
			// dtpDataFinal
			// 
			this.dtpDataFinal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDataFinal.Location = new System.Drawing.Point(492, 7);
			this.dtpDataFinal.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.dtpDataFinal.Name = "dtpDataFinal";
			this.dtpDataFinal.Size = new System.Drawing.Size(145, 31);
			this.dtpDataFinal.TabIndex = 5;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.ForeColor = System.Drawing.Color.Black;
			this.label10.Location = new System.Drawing.Point(208, 13);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(46, 15);
			this.label10.TabIndex = 2;
			this.label10.Text = "INICIAL";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.Transparent;
			this.label11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.Color.Black;
			this.label11.Location = new System.Drawing.Point(449, 13);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(39, 15);
			this.label11.TabIndex = 4;
			this.label11.Text = "FINAL";
			// 
			// chkReferencia
			// 
			this.chkReferencia.AutoSize = true;
			this.chkReferencia.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkReferencia.Location = new System.Drawing.Point(169, 14);
			this.chkReferencia.Name = "chkReferencia";
			this.chkReferencia.Size = new System.Drawing.Size(15, 14);
			this.chkReferencia.TabIndex = 1;
			this.chkReferencia.UseVisualStyleBackColor = true;
			this.chkReferencia.CheckedChanged += new System.EventHandler(this.chkReferencia_CheckedChanged);
			// 
			// pnlReferencia
			// 
			this.pnlReferencia.BackColor = System.Drawing.Color.Gainsboro;
			this.pnlReferencia.Controls.Add(this.dtpDataInicial);
			this.pnlReferencia.Controls.Add(this.chkReferencia);
			this.pnlReferencia.Controls.Add(this.label10);
			this.pnlReferencia.Controls.Add(this.dtpDataFinal);
			this.pnlReferencia.Controls.Add(this.label11);
			this.pnlReferencia.Controls.Add(this.lblReferencia);
			this.pnlReferencia.Location = new System.Drawing.Point(12, 338);
			this.pnlReferencia.Name = "pnlReferencia";
			this.pnlReferencia.Size = new System.Drawing.Size(749, 44);
			this.pnlReferencia.TabIndex = 23;
			// 
			// lblReferencia
			// 
			this.lblReferencia.AutoSize = true;
			this.lblReferencia.BackColor = System.Drawing.Color.Transparent;
			this.lblReferencia.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblReferencia.ForeColor = System.Drawing.Color.DimGray;
			this.lblReferencia.Location = new System.Drawing.Point(78, 11);
			this.lblReferencia.Name = "lblReferencia";
			this.lblReferencia.Size = new System.Drawing.Size(91, 19);
			this.lblReferencia.TabIndex = 0;
			this.lblReferencia.Text = "REFERÊNCIA";
			// 
			// mnuOperacoes
			// 
			this.mnuOperacoes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuOperacoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdicionarAPagar,
            this.mnuEditarAPagar,
            this.mnuExcluirAPagar,
            this.toolStripSeparator5,
            this.mnuImagemAPagar});
			this.mnuOperacoes.Name = "mnuOperacoes";
			this.mnuOperacoes.Size = new System.Drawing.Size(214, 154);
			// 
			// mnuAdicionarAPagar
			// 
			this.mnuAdicionarAPagar.Image = global::CamadaUI.Properties.Resources.add_24;
			this.mnuAdicionarAPagar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuAdicionarAPagar.Name = "mnuAdicionarAPagar";
			this.mnuAdicionarAPagar.Size = new System.Drawing.Size(213, 36);
			this.mnuAdicionarAPagar.Text = "Adicionar APagar";
			this.mnuAdicionarAPagar.Click += new System.EventHandler(this.mnuAdicionarAPagar_Click);
			// 
			// mnuEditarAPagar
			// 
			this.mnuEditarAPagar.Image = global::CamadaUI.Properties.Resources.editar_24;
			this.mnuEditarAPagar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuEditarAPagar.Name = "mnuEditarAPagar";
			this.mnuEditarAPagar.Size = new System.Drawing.Size(213, 36);
			this.mnuEditarAPagar.Text = "Editar APagar";
			this.mnuEditarAPagar.Click += new System.EventHandler(this.mnuEditarAPagar_Click);
			// 
			// mnuExcluirAPagar
			// 
			this.mnuExcluirAPagar.Image = global::CamadaUI.Properties.Resources.lixeira_24;
			this.mnuExcluirAPagar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuExcluirAPagar.Name = "mnuExcluirAPagar";
			this.mnuExcluirAPagar.Size = new System.Drawing.Size(213, 36);
			this.mnuExcluirAPagar.Text = "Excluir APagar";
			this.mnuExcluirAPagar.Click += new System.EventHandler(this.mnuExcluirAPagar_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(210, 6);
			// 
			// mnuImagemAPagar
			// 
			this.mnuImagemAPagar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImagemInserir,
            this.mnuImagemVisualizar,
            this.toolStripSeparator4,
            this.mnuImagemRemover});
			this.mnuImagemAPagar.Image = global::CamadaUI.Properties.Resources.ImagesFolder_30;
			this.mnuImagemAPagar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.mnuImagemAPagar.Name = "mnuImagemAPagar";
			this.mnuImagemAPagar.Size = new System.Drawing.Size(213, 36);
			this.mnuImagemAPagar.Text = "Imagem APagar";
			// 
			// mnuImagemInserir
			// 
			this.mnuImagemInserir.Image = global::CamadaUI.Properties.Resources.add_16;
			this.mnuImagemInserir.Name = "mnuImagemInserir";
			this.mnuImagemInserir.Size = new System.Drawing.Size(204, 26);
			this.mnuImagemInserir.Text = "Inserir Imagem";
			// 
			// mnuImagemVisualizar
			// 
			this.mnuImagemVisualizar.Image = global::CamadaUI.Properties.Resources.search_page_24;
			this.mnuImagemVisualizar.Name = "mnuImagemVisualizar";
			this.mnuImagemVisualizar.Size = new System.Drawing.Size(204, 26);
			this.mnuImagemVisualizar.Text = "Ver Imagem";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(201, 6);
			// 
			// mnuImagemRemover
			// 
			this.mnuImagemRemover.Image = global::CamadaUI.Properties.Resources.delete_page_30;
			this.mnuImagemRemover.Name = "mnuImagemRemover";
			this.mnuImagemRemover.Size = new System.Drawing.Size(204, 26);
			this.mnuImagemRemover.Text = "Remover Imagem";
			// 
			// frmDespesa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(776, 644);
			this.Controls.Add(this.pnlReferencia);
			this.Controls.Add(this.lblSitBlock);
			this.Controls.Add(this.pnlDataValor);
			this.Controls.Add(this.btnInsertTitular);
			this.Controls.Add(this.dgvListagem);
			this.Controls.Add(this.line2);
			this.Controls.Add(this.pnlParcelas);
			this.Controls.Add(this.btnSetSetor);
			this.Controls.Add(this.txtSetor);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnSetDocumentoTipo);
			this.Controls.Add(this.btnSetDespesaTipo);
			this.Controls.Add(this.btnSetTitular);
			this.Controls.Add(this.btnSetCredor);
			this.Controls.Add(this.txtDocumentoTipo);
			this.Controls.Add(this.txtDespesaTipo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtTitular);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtCredor);
			this.Controls.Add(this.lblContribuinte);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtDocumentoNumero);
			this.Controls.Add(this.txtDespesaDescricao);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblCongregacao);
			this.Controls.Add(this.tspMenu);
			this.KeyPreview = true;
			this.Name = "frmDespesa";
			this.Shown += new System.EventHandler(this.frmDespesa_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.lblCongregacao, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.txtDespesaDescricao, 0);
			this.Controls.SetChildIndex(this.txtDocumentoNumero, 0);
			this.Controls.SetChildIndex(this.label6, 0);
			this.Controls.SetChildIndex(this.lblContribuinte, 0);
			this.Controls.SetChildIndex(this.txtCredor, 0);
			this.Controls.SetChildIndex(this.label7, 0);
			this.Controls.SetChildIndex(this.txtTitular, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.txtDespesaTipo, 0);
			this.Controls.SetChildIndex(this.txtDocumentoTipo, 0);
			this.Controls.SetChildIndex(this.btnSetCredor, 0);
			this.Controls.SetChildIndex(this.btnSetTitular, 0);
			this.Controls.SetChildIndex(this.btnSetDespesaTipo, 0);
			this.Controls.SetChildIndex(this.btnSetDocumentoTipo, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.txtSetor, 0);
			this.Controls.SetChildIndex(this.btnSetSetor, 0);
			this.Controls.SetChildIndex(this.pnlParcelas, 0);
			this.Controls.SetChildIndex(this.line2, 0);
			this.Controls.SetChildIndex(this.dgvListagem, 0);
			this.Controls.SetChildIndex(this.btnInsertTitular, 0);
			this.Controls.SetChildIndex(this.pnlDataValor, 0);
			this.Controls.SetChildIndex(this.lblSitBlock, 0);
			this.Controls.SetChildIndex(this.pnlReferencia, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			this.pnlParcelas.ResumeLayout(false);
			this.pnlParcelas.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numParcelas)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvListagem)).EndInit();
			this.pnlDataValor.ResumeLayout(false);
			this.pnlDataValor.PerformLayout();
			this.pnlReferencia.ResumeLayout(false);
			this.pnlReferencia.PerformLayout();
			this.mnuOperacoes.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label lbl_IdTexto;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnNovo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnSalvar;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		private System.Windows.Forms.ToolStripButton btnFechar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		internal System.Windows.Forms.TextBox txtDespesaDescricao;
		internal System.Windows.Forms.Label lblCongregacao;
		private System.Windows.Forms.DateTimePicker dtpDespesaData;
		internal System.Windows.Forms.Label label1;
		private CamadaUC.ucOnlyNumbers txtDespesaValor;
		internal System.Windows.Forms.Label label8;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox txtDocumentoNumero;
		internal System.Windows.Forms.Label label3;
		internal VIBlend.WinForms.Controls.vButton btnSetCredor;
		internal System.Windows.Forms.TextBox txtCredor;
		internal System.Windows.Forms.Label lblContribuinte;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TextBox txtDespesaTipo;
		internal VIBlend.WinForms.Controls.vButton btnSetDespesaTipo;
		internal VIBlend.WinForms.Controls.vButton btnSetSetor;
		internal System.Windows.Forms.TextBox txtSetor;
		internal System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox chkParcelado;
		private System.Windows.Forms.Panel pnlParcelas;
		internal System.Windows.Forms.TextBox txtDocumentoTipo;
		internal VIBlend.WinForms.Controls.vButton btnSetDocumentoTipo;
		internal VIBlend.WinForms.Controls.vButton btnParcelasGerar;
		private System.Windows.Forms.NumericUpDown numParcelas;
		internal System.Windows.Forms.Label lblParcelas;
		private AwesomeShapeControl.Line line2;
		internal System.Windows.Forms.Label label6;
		internal System.Windows.Forms.DataGridView dgvListagem;
		internal System.Windows.Forms.Label label7;
		internal System.Windows.Forms.TextBox txtTitular;
		internal VIBlend.WinForms.Controls.vButton btnSetTitular;
		internal VIBlend.WinForms.Controls.vButton btnInsertTitular;
		private System.Windows.Forms.Panel pnlDataValor;
		private System.Windows.Forms.Label lblSitBlock;
		private System.Windows.Forms.ToolStripDropDownButton mnuImagem;
		private System.Windows.Forms.ToolStripMenuItem btnInserirImagem;
		private System.Windows.Forms.ToolStripMenuItem btnVerImagem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem btnRemoverImagem;
		private System.Windows.Forms.DateTimePicker dtpDataInicial;
		private System.Windows.Forms.DateTimePicker dtpDataFinal;
		internal System.Windows.Forms.Label label10;
		internal System.Windows.Forms.Label label11;
		private System.Windows.Forms.CheckBox chkReferencia;
		private System.Windows.Forms.Panel pnlReferencia;
		internal System.Windows.Forms.Label lblReferencia;
		private System.Windows.Forms.ContextMenuStrip mnuOperacoes;
		private System.Windows.Forms.ToolStripMenuItem mnuAdicionarAPagar;
		private System.Windows.Forms.ToolStripMenuItem mnuEditarAPagar;
		private System.Windows.Forms.ToolStripMenuItem mnuExcluirAPagar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem mnuImagemAPagar;
		private System.Windows.Forms.ToolStripMenuItem mnuImagemInserir;
		private System.Windows.Forms.ToolStripMenuItem mnuImagemVisualizar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem mnuImagemRemover;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnIdentificador;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnForma;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnSituacao;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnVencimento;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnValor;
	}
}
