namespace CamadaUI.Congregacoes
{
	partial class frmCongregacaoReuniao
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCongregacaoReuniao));
			this.lblReuniao = new System.Windows.Forms.Label();
			this.txtReuniao = new System.Windows.Forms.TextBox();
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnNovo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalvar = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnAtivo = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.line1 = new AwesomeShapeControl.Line();
			this.btnCongEscolher = new VIBlend.WinForms.Controls.vButton();
			this.txtCongregacao = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblDia = new System.Windows.Forms.Label();
			this.lblSemana = new System.Windows.Forms.Label();
			this.lblMes = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.dtpIniciarData = new System.Windows.Forms.DateTimePicker();
			this.label7 = new System.Windows.Forms.Label();
			this.lblRecorrenciaTexto = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblIniciarEmDiaDaSemana = new System.Windows.Forms.Label();
			this.txtRecorrenciaRepeticao = new CamadaUC.ucOnlyNumbers();
			this.cmbRecorrenciaMes = new CamadaUC.ucComboLimitedValues();
			this.cmbRecorrenciaSemana = new CamadaUC.ucComboLimitedValues();
			this.cmbRecorrenciaDia = new CamadaUC.ucComboLimitedValues();
			this.cmbRecorrenciaTipo = new CamadaUC.ucComboLimitedValues();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(267, 0);
			this.lblTitulo.Size = new System.Drawing.Size(253, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "Cadastro de Reuniões";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(520, 0);
			this.btnClose.TabIndex = 3;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblID);
			this.panel1.Controls.Add(this.lbl_IdTexto);
			this.panel1.Size = new System.Drawing.Size(560, 50);
			this.panel1.Controls.SetChildIndex(this.btnClose, 0);
			this.panel1.Controls.SetChildIndex(this.lblTitulo, 0);
			this.panel1.Controls.SetChildIndex(this.lbl_IdTexto, 0);
			this.panel1.Controls.SetChildIndex(this.lblID, 0);
			// 
			// lblReuniao
			// 
			this.lblReuniao.AutoSize = true;
			this.lblReuniao.BackColor = System.Drawing.Color.Transparent;
			this.lblReuniao.ForeColor = System.Drawing.Color.Black;
			this.lblReuniao.Location = new System.Drawing.Point(56, 94);
			this.lblReuniao.Name = "lblReuniao";
			this.lblReuniao.Size = new System.Drawing.Size(123, 19);
			this.lblReuniao.TabIndex = 1;
			this.lblReuniao.Text = "Título da Reunião";
			// 
			// txtReuniao
			// 
			this.txtReuniao.BackColor = System.Drawing.Color.White;
			this.txtReuniao.Location = new System.Drawing.Point(186, 91);
			this.txtReuniao.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtReuniao.MaxLength = 50;
			this.txtReuniao.Name = "txtReuniao";
			this.txtReuniao.Size = new System.Drawing.Size(319, 27);
			this.txtReuniao.TabIndex = 2;
			// 
			// lblID
			// 
			this.lblID.BackColor = System.Drawing.Color.Transparent;
			this.lblID.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblID.ForeColor = System.Drawing.Color.AliceBlue;
			this.lblID.Location = new System.Drawing.Point(4, 16);
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
			this.lbl_IdTexto.Location = new System.Drawing.Point(31, 3);
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
            this.toolStripSeparator2,
            this.btnAtivo,
            this.btnFechar});
			this.tspMenu.Location = new System.Drawing.Point(2, 504);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(555, 44);
			this.tspMenu.TabIndex = 21;
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
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 44);
			// 
			// btnAtivo
			// 
			this.btnAtivo.Image = ((System.Drawing.Image)(resources.GetObject("btnAtivo.Image")));
			this.btnAtivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnAtivo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAtivo.Name = "btnAtivo";
			this.btnAtivo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnAtivo.Size = new System.Drawing.Size(96, 41);
			this.btnAtivo.Text = "&Ativo";
			this.btnAtivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAtivo.Click += new System.EventHandler(this.btnAtivo_Click);
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
			// line1
			// 
			this.line1.EndPoint = new System.Drawing.Point(495, 5);
			this.line1.LineColor = System.Drawing.Color.SlateGray;
			this.line1.LineWidth = 3F;
			this.line1.Location = new System.Drawing.Point(20, 241);
			this.line1.Name = "line1";
			this.line1.Size = new System.Drawing.Size(500, 10);
			this.line1.StartPoint = new System.Drawing.Point(5, 5);
			this.line1.TabIndex = 9;
			this.line1.TabStop = false;
			// 
			// btnCongEscolher
			// 
			this.btnCongEscolher.AllowAnimations = true;
			this.btnCongEscolher.BackColor = System.Drawing.Color.Transparent;
			this.btnCongEscolher.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnCongEscolher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCongEscolher.Location = new System.Drawing.Point(420, 133);
			this.btnCongEscolher.Name = "btnCongEscolher";
			this.btnCongEscolher.RoundedCornersMask = ((byte)(15));
			this.btnCongEscolher.RoundedCornersRadius = 0;
			this.btnCongEscolher.Size = new System.Drawing.Size(34, 27);
			this.btnCongEscolher.TabIndex = 5;
			this.btnCongEscolher.TabStop = false;
			this.btnCongEscolher.Text = "...";
			this.btnCongEscolher.UseCompatibleTextRendering = true;
			this.btnCongEscolher.UseVisualStyleBackColor = false;
			this.btnCongEscolher.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnCongEscolher.Click += new System.EventHandler(this.btnCongregacaoEscolher_Click);
			// 
			// txtCongregacao
			// 
			this.txtCongregacao.Location = new System.Drawing.Point(186, 133);
			this.txtCongregacao.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCongregacao.MaxLength = 30;
			this.txtCongregacao.Name = "txtCongregacao";
			this.txtCongregacao.Size = new System.Drawing.Size(228, 27);
			this.txtCongregacao.TabIndex = 4;
			this.txtCongregacao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.BackColor = System.Drawing.Color.Transparent;
			this.Label6.ForeColor = System.Drawing.Color.Black;
			this.Label6.Location = new System.Drawing.Point(85, 136);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(94, 19);
			this.Label6.TabIndex = 3;
			this.Label6.Text = "Congregação";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(227, 303);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 19);
			this.label1.TabIndex = 13;
			this.label1.Text = "Tipo";
			// 
			// lblDia
			// 
			this.lblDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDia.BackColor = System.Drawing.Color.Transparent;
			this.lblDia.ForeColor = System.Drawing.Color.Black;
			this.lblDia.Location = new System.Drawing.Point(43, 357);
			this.lblDia.Name = "lblDia";
			this.lblDia.Size = new System.Drawing.Size(135, 19);
			this.lblDia.TabIndex = 15;
			this.lblDia.Text = "Dia";
			this.lblDia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSemana
			// 
			this.lblSemana.AutoSize = true;
			this.lblSemana.BackColor = System.Drawing.Color.Transparent;
			this.lblSemana.ForeColor = System.Drawing.Color.Black;
			this.lblSemana.Location = new System.Drawing.Point(118, 404);
			this.lblSemana.Name = "lblSemana";
			this.lblSemana.Size = new System.Drawing.Size(60, 19);
			this.lblSemana.TabIndex = 17;
			this.lblSemana.Text = "Semana";
			// 
			// lblMes
			// 
			this.lblMes.AutoSize = true;
			this.lblMes.BackColor = System.Drawing.Color.Transparent;
			this.lblMes.ForeColor = System.Drawing.Color.Black;
			this.lblMes.Location = new System.Drawing.Point(141, 450);
			this.lblMes.Name = "lblMes";
			this.lblMes.Size = new System.Drawing.Size(37, 19);
			this.lblMes.TabIndex = 19;
			this.lblMes.Text = "Mês";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(53, 303);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(105, 19);
			this.label5.TabIndex = 11;
			this.label5.Text = "Repetir a Cada";
			// 
			// dtpIniciarData
			// 
			this.dtpIniciarData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpIniciarData.Location = new System.Drawing.Point(185, 172);
			this.dtpIniciarData.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.dtpIniciarData.Name = "dtpIniciarData";
			this.dtpIniciarData.Size = new System.Drawing.Size(143, 27);
			this.dtpIniciarData.TabIndex = 7;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.ForeColor = System.Drawing.Color.Black;
			this.label7.Location = new System.Drawing.Point(105, 178);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(73, 19);
			this.label7.TabIndex = 6;
			this.label7.Text = "Iniciar Em";
			// 
			// lblRecorrenciaTexto
			// 
			this.lblRecorrenciaTexto.BackColor = System.Drawing.Color.Transparent;
			this.lblRecorrenciaTexto.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRecorrenciaTexto.ForeColor = System.Drawing.Color.Black;
			this.lblRecorrenciaTexto.Location = new System.Drawing.Point(9, 252);
			this.lblRecorrenciaTexto.Name = "lblRecorrenciaTexto";
			this.lblRecorrenciaTexto.Size = new System.Drawing.Size(533, 26);
			this.lblRecorrenciaTexto.TabIndex = 10;
			this.lblRecorrenciaTexto.Text = "Repetição...";
			this.lblRecorrenciaTexto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblRecorrenciaTexto.TextChanged += new System.EventHandler(this.lblRecorrenciaTexto_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.SlateGray;
			this.label2.Location = new System.Drawing.Point(29, 215);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(115, 26);
			this.label2.TabIndex = 8;
			this.label2.Text = "Recorrência";
			// 
			// lblIniciarEmDiaDaSemana
			// 
			this.lblIniciarEmDiaDaSemana.BackColor = System.Drawing.Color.Transparent;
			this.lblIniciarEmDiaDaSemana.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblIniciarEmDiaDaSemana.ForeColor = System.Drawing.Color.Black;
			this.lblIniciarEmDiaDaSemana.Location = new System.Drawing.Point(334, 172);
			this.lblIniciarEmDiaDaSemana.Name = "lblIniciarEmDiaDaSemana";
			this.lblIniciarEmDiaDaSemana.Size = new System.Drawing.Size(171, 26);
			this.lblIniciarEmDiaDaSemana.TabIndex = 10;
			this.lblIniciarEmDiaDaSemana.Text = "Repetição...";
			this.lblIniciarEmDiaDaSemana.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtRecorrenciaRepeticao
			// 
			this.txtRecorrenciaRepeticao.Inteiro = true;
			this.txtRecorrenciaRepeticao.Location = new System.Drawing.Point(164, 300);
			this.txtRecorrenciaRepeticao.MaxLength = 2;
			this.txtRecorrenciaRepeticao.Name = "txtRecorrenciaRepeticao";
			this.txtRecorrenciaRepeticao.Positivo = true;
			this.txtRecorrenciaRepeticao.Size = new System.Drawing.Size(57, 27);
			this.txtRecorrenciaRepeticao.TabIndex = 12;
			this.txtRecorrenciaRepeticao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cmbRecorrenciaMes
			// 
			this.cmbRecorrenciaMes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbRecorrenciaMes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbRecorrenciaMes.FormattingEnabled = true;
			this.cmbRecorrenciaMes.Location = new System.Drawing.Point(185, 447);
			this.cmbRecorrenciaMes.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.cmbRecorrenciaMes.Name = "cmbRecorrenciaMes";
			this.cmbRecorrenciaMes.Size = new System.Drawing.Size(234, 27);
			this.cmbRecorrenciaMes.TabIndex = 20;
			// 
			// cmbRecorrenciaSemana
			// 
			this.cmbRecorrenciaSemana.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbRecorrenciaSemana.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbRecorrenciaSemana.FormattingEnabled = true;
			this.cmbRecorrenciaSemana.Location = new System.Drawing.Point(185, 401);
			this.cmbRecorrenciaSemana.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.cmbRecorrenciaSemana.Name = "cmbRecorrenciaSemana";
			this.cmbRecorrenciaSemana.Size = new System.Drawing.Size(234, 27);
			this.cmbRecorrenciaSemana.TabIndex = 18;
			// 
			// cmbRecorrenciaDia
			// 
			this.cmbRecorrenciaDia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbRecorrenciaDia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbRecorrenciaDia.FormattingEnabled = true;
			this.cmbRecorrenciaDia.Location = new System.Drawing.Point(185, 354);
			this.cmbRecorrenciaDia.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.cmbRecorrenciaDia.Name = "cmbRecorrenciaDia";
			this.cmbRecorrenciaDia.Size = new System.Drawing.Size(88, 27);
			this.cmbRecorrenciaDia.TabIndex = 16;
			// 
			// cmbRecorrenciaTipo
			// 
			this.cmbRecorrenciaTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbRecorrenciaTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbRecorrenciaTipo.FormattingEnabled = true;
			this.cmbRecorrenciaTipo.Location = new System.Drawing.Point(271, 300);
			this.cmbRecorrenciaTipo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.cmbRecorrenciaTipo.Name = "cmbRecorrenciaTipo";
			this.cmbRecorrenciaTipo.Size = new System.Drawing.Size(234, 27);
			this.cmbRecorrenciaTipo.TabIndex = 14;
			this.cmbRecorrenciaTipo.SelectionChangeCommitted += new System.EventHandler(this.cmbRecorrenciaTipo_SelectionChangeCommitted);
			// 
			// frmCongregacaoReuniao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(560, 550);
			this.Controls.Add(this.txtRecorrenciaRepeticao);
			this.Controls.Add(this.dtpIniciarData);
			this.Controls.Add(this.cmbRecorrenciaMes);
			this.Controls.Add(this.cmbRecorrenciaSemana);
			this.Controls.Add(this.cmbRecorrenciaDia);
			this.Controls.Add(this.cmbRecorrenciaTipo);
			this.Controls.Add(this.btnCongEscolher);
			this.Controls.Add(this.txtCongregacao);
			this.Controls.Add(this.lblIniciarEmDiaDaSemana);
			this.Controls.Add(this.lblRecorrenciaTexto);
			this.Controls.Add(this.lblMes);
			this.Controls.Add(this.lblSemana);
			this.Controls.Add(this.lblDia);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.line1);
			this.Controls.Add(this.tspMenu);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtReuniao);
			this.Controls.Add(this.lblReuniao);
			this.KeyPreview = true;
			this.Name = "frmCongregacaoReuniao";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCongregacaoReuniao_KeyDown);
			this.Controls.SetChildIndex(this.lblReuniao, 0);
			this.Controls.SetChildIndex(this.txtReuniao, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.label7, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.line1, 0);
			this.Controls.SetChildIndex(this.Label6, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.lblDia, 0);
			this.Controls.SetChildIndex(this.lblSemana, 0);
			this.Controls.SetChildIndex(this.lblMes, 0);
			this.Controls.SetChildIndex(this.lblRecorrenciaTexto, 0);
			this.Controls.SetChildIndex(this.lblIniciarEmDiaDaSemana, 0);
			this.Controls.SetChildIndex(this.txtCongregacao, 0);
			this.Controls.SetChildIndex(this.btnCongEscolher, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.cmbRecorrenciaTipo, 0);
			this.Controls.SetChildIndex(this.cmbRecorrenciaDia, 0);
			this.Controls.SetChildIndex(this.cmbRecorrenciaSemana, 0);
			this.Controls.SetChildIndex(this.cmbRecorrenciaMes, 0);
			this.Controls.SetChildIndex(this.dtpIniciarData, 0);
			this.Controls.SetChildIndex(this.txtRecorrenciaRepeticao, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal System.Windows.Forms.Label lblReuniao;
		internal System.Windows.Forms.TextBox txtReuniao;
		internal System.Windows.Forms.Label lblID;
		internal System.Windows.Forms.Label lbl_IdTexto;
		private System.Windows.Forms.ToolStrip tspMenu;
		private System.Windows.Forms.ToolStripButton btnNovo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnSalvar;
		private System.Windows.Forms.ToolStripButton btnCancelar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnAtivo;
		private System.Windows.Forms.ToolStripButton btnFechar;
		private AwesomeShapeControl.Line line1;
		internal VIBlend.WinForms.Controls.vButton btnCongEscolher;
		internal System.Windows.Forms.TextBox txtCongregacao;
		internal System.Windows.Forms.Label Label6;
		private CamadaUC.ucComboLimitedValues cmbRecorrenciaTipo;
		private CamadaUC.ucComboLimitedValues cmbRecorrenciaDia;
		private CamadaUC.ucComboLimitedValues cmbRecorrenciaSemana;
		private CamadaUC.ucComboLimitedValues cmbRecorrenciaMes;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Label lblDia;
		internal System.Windows.Forms.Label lblSemana;
		internal System.Windows.Forms.Label lblMes;
		internal System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dtpIniciarData;
		internal System.Windows.Forms.Label label7;
		internal System.Windows.Forms.Label lblRecorrenciaTexto;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.Label lblIniciarEmDiaDaSemana;
		private CamadaUC.ucOnlyNumbers txtRecorrenciaRepeticao;
	}
}
