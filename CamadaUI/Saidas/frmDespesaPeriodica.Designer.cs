﻿namespace CamadaUI.Saidas
{
	partial class frmDespesaPeriodica
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDespesaPeriodica));
			this.lblID = new System.Windows.Forms.Label();
			this.lbl_IdTexto = new System.Windows.Forms.Label();
			this.tspMenu = new System.Windows.Forms.ToolStrip();
			this.btnNovo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalvar = new System.Windows.Forms.ToolStripButton();
			this.btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.btnFechar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.txtDespesaDescricao = new System.Windows.Forms.TextBox();
			this.lblCongregacao = new System.Windows.Forms.Label();
			this.dtpDespesaData = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDespesaValor = new CamadaUC.ucOnlyNumbers();
			this.label8 = new System.Windows.Forms.Label();
			this.btnSetCredor = new VIBlend.WinForms.Controls.vButton();
			this.txtCredor = new System.Windows.Forms.TextBox();
			this.lblContribuinte = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDespesaTipo = new System.Windows.Forms.TextBox();
			this.btnSetDespesaTipo = new VIBlend.WinForms.Controls.vButton();
			this.btnSetSetor = new VIBlend.WinForms.Controls.vButton();
			this.txtSetor = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.line1 = new AwesomeShapeControl.Line();
			this.line2 = new AwesomeShapeControl.Line();
			this.label6 = new System.Windows.Forms.Label();
			this.dtpIniciarData = new System.Windows.Forms.DateTimePicker();
			this.btnSetForma = new VIBlend.WinForms.Controls.vButton();
			this.txtCobrancaForma = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btnSetBanco = new VIBlend.WinForms.Controls.vButton();
			this.txtBanco = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtRecorrenciaRepeticao = new CamadaUC.ucOnlyNumbers();
			this.cmbRecorrenciaMes = new CamadaUC.ucComboLimitedValues();
			this.cmbRecorrenciaSemana = new CamadaUC.ucComboLimitedValues();
			this.cmbRecorrenciaDia = new CamadaUC.ucComboLimitedValues();
			this.cmbRecorrenciaTipo = new CamadaUC.ucComboLimitedValues();
			this.lblRecorrenciaTexto = new System.Windows.Forms.Label();
			this.lblMes = new System.Windows.Forms.Label();
			this.lblSemana = new System.Windows.Forms.Label();
			this.lblDia = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.line3 = new AwesomeShapeControl.Line();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnAtivo = new System.Windows.Forms.ToolStripButton();
			this.panel1.SuspendLayout();
			this.tspMenu.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(416, 0);
			this.lblTitulo.Size = new System.Drawing.Size(252, 50);
			this.lblTitulo.TabIndex = 2;
			this.lblTitulo.Text = "Cadastro de Despesas";
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
			this.btnClose.Location = new System.Drawing.Point(668, 0);
			this.btnClose.TabIndex = 3;
			this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblID);
			this.panel1.Controls.Add(this.lbl_IdTexto);
			this.panel1.Size = new System.Drawing.Size(708, 50);
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
            this.btnAtivo});
			this.tspMenu.Location = new System.Drawing.Point(2, 674);
			this.tspMenu.Name = "tspMenu";
			this.tspMenu.Size = new System.Drawing.Size(704, 44);
			this.tspMenu.TabIndex = 27;
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
			// txtDespesaDescricao
			// 
			this.txtDespesaDescricao.BackColor = System.Drawing.Color.White;
			this.txtDespesaDescricao.Location = new System.Drawing.Point(197, 303);
			this.txtDespesaDescricao.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtDespesaDescricao.MaxLength = 100;
			this.txtDespesaDescricao.Name = "txtDespesaDescricao";
			this.txtDespesaDescricao.Size = new System.Drawing.Size(433, 27);
			this.txtDespesaDescricao.TabIndex = 19;
			this.txtDespesaDescricao.Tag = "";
			this.txtDespesaDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// lblCongregacao
			// 
			this.lblCongregacao.AutoSize = true;
			this.lblCongregacao.BackColor = System.Drawing.Color.Transparent;
			this.lblCongregacao.ForeColor = System.Drawing.Color.Black;
			this.lblCongregacao.Location = new System.Drawing.Point(118, 306);
			this.lblCongregacao.Name = "lblCongregacao";
			this.lblCongregacao.Size = new System.Drawing.Size(73, 19);
			this.lblCongregacao.TabIndex = 18;
			this.lblCongregacao.Text = "Descrição";
			// 
			// dtpDespesaData
			// 
			this.dtpDespesaData.CalendarFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpDespesaData.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpDespesaData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDespesaData.Location = new System.Drawing.Point(197, 69);
			this.dtpDespesaData.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.dtpDespesaData.Name = "dtpDespesaData";
			this.dtpDespesaData.Size = new System.Drawing.Size(132, 27);
			this.dtpDespesaData.TabIndex = 2;
			this.dtpDespesaData.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(71, 73);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "Data do Contrato";
			// 
			// txtDespesaValor
			// 
			this.txtDespesaValor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDespesaValor.Inteiro = false;
			this.txtDespesaValor.Location = new System.Drawing.Point(485, 365);
			this.txtDespesaValor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtDespesaValor.Name = "txtDespesaValor";
			this.txtDespesaValor.Positivo = true;
			this.txtDespesaValor.Size = new System.Drawing.Size(145, 31);
			this.txtDespesaValor.TabIndex = 24;
			this.txtDespesaValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.ForeColor = System.Drawing.Color.Black;
			this.label8.Location = new System.Drawing.Point(357, 371);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(122, 19);
			this.label8.TabIndex = 23;
			this.label8.Text = "Valor da Despesa";
			// 
			// btnSetCredor
			// 
			this.btnSetCredor.AllowAnimations = true;
			this.btnSetCredor.BackColor = System.Drawing.Color.Transparent;
			this.btnSetCredor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetCredor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetCredor.Location = new System.Drawing.Point(596, 147);
			this.btnSetCredor.Name = "btnSetCredor";
			this.btnSetCredor.RoundedCornersMask = ((byte)(15));
			this.btnSetCredor.RoundedCornersRadius = 0;
			this.btnSetCredor.Size = new System.Drawing.Size(34, 27);
			this.btnSetCredor.TabIndex = 8;
			this.btnSetCredor.TabStop = false;
			this.btnSetCredor.Text = "...";
			this.btnSetCredor.UseCompatibleTextRendering = true;
			this.btnSetCredor.UseVisualStyleBackColor = false;
			this.btnSetCredor.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetCredor.Click += new System.EventHandler(this.btnSetCredor_Click);
			// 
			// txtCredor
			// 
			this.txtCredor.Location = new System.Drawing.Point(197, 147);
			this.txtCredor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCredor.MaxLength = 30;
			this.txtCredor.Name = "txtCredor";
			this.txtCredor.Size = new System.Drawing.Size(393, 27);
			this.txtCredor.TabIndex = 7;
			this.txtCredor.Tag = "Pressione a tecla (+) para procurar";
			this.txtCredor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// lblContribuinte
			// 
			this.lblContribuinte.AutoSize = true;
			this.lblContribuinte.BackColor = System.Drawing.Color.Transparent;
			this.lblContribuinte.ForeColor = System.Drawing.Color.Black;
			this.lblContribuinte.Location = new System.Drawing.Point(53, 150);
			this.lblContribuinte.Name = "lblContribuinte";
			this.lblContribuinte.Size = new System.Drawing.Size(138, 19);
			this.lblContribuinte.TabIndex = 6;
			this.lblContribuinte.Text = "Credor / Fornecedor";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(74, 189);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(117, 19);
			this.label4.TabIndex = 9;
			this.label4.Text = "Tipo de Despesa";
			// 
			// txtDespesaTipo
			// 
			this.txtDespesaTipo.Location = new System.Drawing.Point(197, 186);
			this.txtDespesaTipo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtDespesaTipo.MaxLength = 30;
			this.txtDespesaTipo.Name = "txtDespesaTipo";
			this.txtDespesaTipo.Size = new System.Drawing.Size(393, 27);
			this.txtDespesaTipo.TabIndex = 10;
			this.txtDespesaTipo.Tag = "Pressione a tecla (+) para procurar";
			this.txtDespesaTipo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// btnSetDespesaTipo
			// 
			this.btnSetDespesaTipo.AllowAnimations = true;
			this.btnSetDespesaTipo.BackColor = System.Drawing.Color.Transparent;
			this.btnSetDespesaTipo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetDespesaTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetDespesaTipo.Location = new System.Drawing.Point(596, 186);
			this.btnSetDespesaTipo.Name = "btnSetDespesaTipo";
			this.btnSetDespesaTipo.RoundedCornersMask = ((byte)(15));
			this.btnSetDespesaTipo.RoundedCornersRadius = 0;
			this.btnSetDespesaTipo.Size = new System.Drawing.Size(34, 27);
			this.btnSetDespesaTipo.TabIndex = 11;
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
			this.btnSetSetor.Location = new System.Drawing.Point(431, 108);
			this.btnSetSetor.Name = "btnSetSetor";
			this.btnSetSetor.RoundedCornersMask = ((byte)(15));
			this.btnSetSetor.RoundedCornersRadius = 0;
			this.btnSetSetor.Size = new System.Drawing.Size(34, 27);
			this.btnSetSetor.TabIndex = 5;
			this.btnSetSetor.TabStop = false;
			this.btnSetSetor.Text = "...";
			this.btnSetSetor.UseCompatibleTextRendering = true;
			this.btnSetSetor.UseVisualStyleBackColor = false;
			this.btnSetSetor.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			this.btnSetSetor.Click += new System.EventHandler(this.btnSetSetor_Click);
			// 
			// txtSetor
			// 
			this.txtSetor.Location = new System.Drawing.Point(197, 108);
			this.txtSetor.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtSetor.MaxLength = 30;
			this.txtSetor.Name = "txtSetor";
			this.txtSetor.Size = new System.Drawing.Size(228, 27);
			this.txtSetor.TabIndex = 4;
			this.txtSetor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(86, 111);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(105, 19);
			this.label5.TabIndex = 3;
			this.label5.Text = "Setor Debitado";
			// 
			// line1
			// 
			this.line1.EndPoint = new System.Drawing.Point(645, 5);
			this.line1.LineColor = System.Drawing.Color.LightSlateGray;
			this.line1.LineWidth = 3F;
			this.line1.Location = new System.Drawing.Point(25, 345);
			this.line1.Name = "line1";
			this.line1.Opacity = 0.5F;
			this.line1.Size = new System.Drawing.Size(650, 10);
			this.line1.StartPoint = new System.Drawing.Point(5, 5);
			this.line1.TabIndex = 20;
			this.line1.TabStop = false;
			// 
			// line2
			// 
			this.line2.EndPoint = new System.Drawing.Point(645, 5);
			this.line2.LineColor = System.Drawing.Color.LightSlateGray;
			this.line2.LineWidth = 3F;
			this.line2.Location = new System.Drawing.Point(25, 406);
			this.line2.Name = "line2";
			this.line2.Opacity = 0.5F;
			this.line2.Size = new System.Drawing.Size(650, 10);
			this.line2.StartPoint = new System.Drawing.Point(5, 5);
			this.line2.TabIndex = 25;
			this.line2.TabStop = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.ForeColor = System.Drawing.Color.Black;
			this.label6.Location = new System.Drawing.Point(58, 371);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(99, 19);
			this.label6.TabIndex = 21;
			this.label6.Text = "Data do Início";
			// 
			// dtpIniciarData
			// 
			this.dtpIniciarData.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpIniciarData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpIniciarData.Location = new System.Drawing.Point(163, 365);
			this.dtpIniciarData.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.dtpIniciarData.Name = "dtpIniciarData";
			this.dtpIniciarData.Size = new System.Drawing.Size(145, 31);
			this.dtpIniciarData.TabIndex = 22;
			// 
			// btnSetForma
			// 
			this.btnSetForma.AllowAnimations = true;
			this.btnSetForma.BackColor = System.Drawing.Color.Transparent;
			this.btnSetForma.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetForma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetForma.Location = new System.Drawing.Point(470, 225);
			this.btnSetForma.Name = "btnSetForma";
			this.btnSetForma.RoundedCornersMask = ((byte)(15));
			this.btnSetForma.RoundedCornersRadius = 0;
			this.btnSetForma.Size = new System.Drawing.Size(34, 27);
			this.btnSetForma.TabIndex = 14;
			this.btnSetForma.TabStop = false;
			this.btnSetForma.Text = "...";
			this.btnSetForma.UseCompatibleTextRendering = true;
			this.btnSetForma.UseVisualStyleBackColor = false;
			this.btnSetForma.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			// 
			// txtCobrancaForma
			// 
			this.txtCobrancaForma.Location = new System.Drawing.Point(197, 225);
			this.txtCobrancaForma.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtCobrancaForma.MaxLength = 30;
			this.txtCobrancaForma.Name = "txtCobrancaForma";
			this.txtCobrancaForma.Size = new System.Drawing.Size(267, 27);
			this.txtCobrancaForma.TabIndex = 13;
			this.txtCobrancaForma.Tag = "Pressione a tecla (+) para procurar";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.ForeColor = System.Drawing.Color.Black;
			this.label7.Location = new System.Drawing.Point(57, 228);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(134, 19);
			this.label7.TabIndex = 12;
			this.label7.Text = "Forma de Cobrança";
			// 
			// btnSetBanco
			// 
			this.btnSetBanco.AllowAnimations = true;
			this.btnSetBanco.BackColor = System.Drawing.Color.Transparent;
			this.btnSetBanco.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnSetBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetBanco.Location = new System.Drawing.Point(470, 264);
			this.btnSetBanco.Name = "btnSetBanco";
			this.btnSetBanco.RoundedCornersMask = ((byte)(15));
			this.btnSetBanco.RoundedCornersRadius = 0;
			this.btnSetBanco.Size = new System.Drawing.Size(34, 27);
			this.btnSetBanco.TabIndex = 17;
			this.btnSetBanco.TabStop = false;
			this.btnSetBanco.Text = "...";
			this.btnSetBanco.UseCompatibleTextRendering = true;
			this.btnSetBanco.UseVisualStyleBackColor = false;
			this.btnSetBanco.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
			// 
			// txtBanco
			// 
			this.txtBanco.Location = new System.Drawing.Point(197, 264);
			this.txtBanco.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtBanco.MaxLength = 30;
			this.txtBanco.Name = "txtBanco";
			this.txtBanco.Size = new System.Drawing.Size(267, 27);
			this.txtBanco.TabIndex = 16;
			this.txtBanco.Tag = "Pressione a tecla (+) para procurar";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.ForeColor = System.Drawing.Color.Black;
			this.label9.Location = new System.Drawing.Point(142, 267);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(49, 19);
			this.label9.TabIndex = 15;
			this.label9.Text = "Banco";
			// 
			// txtRecorrenciaRepeticao
			// 
			this.txtRecorrenciaRepeticao.Inteiro = true;
			this.txtRecorrenciaRepeticao.Location = new System.Drawing.Point(176, 62);
			this.txtRecorrenciaRepeticao.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.txtRecorrenciaRepeticao.MaxLength = 2;
			this.txtRecorrenciaRepeticao.Name = "txtRecorrenciaRepeticao";
			this.txtRecorrenciaRepeticao.Positivo = true;
			this.txtRecorrenciaRepeticao.Size = new System.Drawing.Size(57, 27);
			this.txtRecorrenciaRepeticao.TabIndex = 4;
			this.txtRecorrenciaRepeticao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cmbRecorrenciaMes
			// 
			this.cmbRecorrenciaMes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbRecorrenciaMes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbRecorrenciaMes.FormattingEnabled = true;
			this.cmbRecorrenciaMes.Location = new System.Drawing.Point(176, 179);
			this.cmbRecorrenciaMes.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.cmbRecorrenciaMes.Name = "cmbRecorrenciaMes";
			this.cmbRecorrenciaMes.Size = new System.Drawing.Size(234, 27);
			this.cmbRecorrenciaMes.TabIndex = 12;
			// 
			// cmbRecorrenciaSemana
			// 
			this.cmbRecorrenciaSemana.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbRecorrenciaSemana.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbRecorrenciaSemana.FormattingEnabled = true;
			this.cmbRecorrenciaSemana.Location = new System.Drawing.Point(176, 140);
			this.cmbRecorrenciaSemana.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.cmbRecorrenciaSemana.Name = "cmbRecorrenciaSemana";
			this.cmbRecorrenciaSemana.Size = new System.Drawing.Size(234, 27);
			this.cmbRecorrenciaSemana.TabIndex = 10;
			// 
			// cmbRecorrenciaDia
			// 
			this.cmbRecorrenciaDia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbRecorrenciaDia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbRecorrenciaDia.FormattingEnabled = true;
			this.cmbRecorrenciaDia.Location = new System.Drawing.Point(176, 101);
			this.cmbRecorrenciaDia.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.cmbRecorrenciaDia.Name = "cmbRecorrenciaDia";
			this.cmbRecorrenciaDia.Size = new System.Drawing.Size(88, 27);
			this.cmbRecorrenciaDia.TabIndex = 8;
			// 
			// cmbRecorrenciaTipo
			// 
			this.cmbRecorrenciaTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbRecorrenciaTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbRecorrenciaTipo.FormattingEnabled = true;
			this.cmbRecorrenciaTipo.Location = new System.Drawing.Point(283, 62);
			this.cmbRecorrenciaTipo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.cmbRecorrenciaTipo.Name = "cmbRecorrenciaTipo";
			this.cmbRecorrenciaTipo.Size = new System.Drawing.Size(234, 27);
			this.cmbRecorrenciaTipo.TabIndex = 6;
			this.cmbRecorrenciaTipo.SelectionChangeCommitted += new System.EventHandler(this.cmbRecorrenciaTipo_SelectionChangeCommitted);
			// 
			// lblRecorrenciaTexto
			// 
			this.lblRecorrenciaTexto.BackColor = System.Drawing.Color.Transparent;
			this.lblRecorrenciaTexto.Font = new System.Drawing.Font("Pathway Gothic One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRecorrenciaTexto.ForeColor = System.Drawing.Color.Black;
			this.lblRecorrenciaTexto.Location = new System.Drawing.Point(162, 14);
			this.lblRecorrenciaTexto.Name = "lblRecorrenciaTexto";
			this.lblRecorrenciaTexto.Size = new System.Drawing.Size(477, 26);
			this.lblRecorrenciaTexto.TabIndex = 1;
			this.lblRecorrenciaTexto.Text = "Repetição...";
			this.lblRecorrenciaTexto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMes
			// 
			this.lblMes.AutoSize = true;
			this.lblMes.BackColor = System.Drawing.Color.Transparent;
			this.lblMes.ForeColor = System.Drawing.Color.Black;
			this.lblMes.Location = new System.Drawing.Point(132, 182);
			this.lblMes.Name = "lblMes";
			this.lblMes.Size = new System.Drawing.Size(37, 19);
			this.lblMes.TabIndex = 11;
			this.lblMes.Text = "Mês";
			// 
			// lblSemana
			// 
			this.lblSemana.AutoSize = true;
			this.lblSemana.BackColor = System.Drawing.Color.Transparent;
			this.lblSemana.ForeColor = System.Drawing.Color.Black;
			this.lblSemana.Location = new System.Drawing.Point(109, 143);
			this.lblSemana.Name = "lblSemana";
			this.lblSemana.Size = new System.Drawing.Size(60, 19);
			this.lblSemana.TabIndex = 9;
			this.lblSemana.Text = "Semana";
			// 
			// lblDia
			// 
			this.lblDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDia.BackColor = System.Drawing.Color.Transparent;
			this.lblDia.ForeColor = System.Drawing.Color.Black;
			this.lblDia.Location = new System.Drawing.Point(34, 104);
			this.lblDia.Name = "lblDia";
			this.lblDia.Size = new System.Drawing.Size(135, 19);
			this.lblDia.TabIndex = 7;
			this.lblDia.Text = "Dia";
			this.lblDia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.ForeColor = System.Drawing.Color.Black;
			this.label10.Location = new System.Drawing.Point(239, 65);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(37, 19);
			this.label10.TabIndex = 5;
			this.label10.Text = "Tipo";
			// 
			// line3
			// 
			this.line3.EndPoint = new System.Drawing.Point(645, 5);
			this.line3.LineColor = System.Drawing.Color.LightSlateGray;
			this.line3.LineWidth = 3F;
			this.line3.Location = new System.Drawing.Point(9, 40);
			this.line3.Name = "line3";
			this.line3.Opacity = 0.5F;
			this.line3.Size = new System.Drawing.Size(650, 10);
			this.line3.StartPoint = new System.Drawing.Point(5, 5);
			this.line3.TabIndex = 2;
			this.line3.TabStop = false;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.Transparent;
			this.label11.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.Color.SlateGray;
			this.label11.Location = new System.Drawing.Point(41, 14);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(115, 26);
			this.label11.TabIndex = 0;
			this.label11.Text = "Recorrência";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.BackColor = System.Drawing.Color.Transparent;
			this.label12.ForeColor = System.Drawing.Color.Black;
			this.label12.Location = new System.Drawing.Point(65, 65);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(105, 19);
			this.label12.TabIndex = 3;
			this.label12.Text = "Repetir a Cada";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(224)))));
			this.panel2.Controls.Add(this.txtRecorrenciaRepeticao);
			this.panel2.Controls.Add(this.lblRecorrenciaTexto);
			this.panel2.Controls.Add(this.cmbRecorrenciaMes);
			this.panel2.Controls.Add(this.label12);
			this.panel2.Controls.Add(this.cmbRecorrenciaSemana);
			this.panel2.Controls.Add(this.label11);
			this.panel2.Controls.Add(this.cmbRecorrenciaDia);
			this.panel2.Controls.Add(this.line3);
			this.panel2.Controls.Add(this.cmbRecorrenciaTipo);
			this.panel2.Controls.Add(this.label10);
			this.panel2.Controls.Add(this.lblDia);
			this.panel2.Controls.Add(this.lblMes);
			this.panel2.Controls.Add(this.lblSemana);
			this.panel2.Location = new System.Drawing.Point(19, 435);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(671, 222);
			this.panel2.TabIndex = 26;
			// 
			// btnAtivo
			// 
			this.btnAtivo.Image = ((System.Drawing.Image)(resources.GetObject("btnAtivo.Image")));
			this.btnAtivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnAtivo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAtivo.Name = "btnAtivo";
			this.btnAtivo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.btnAtivo.Size = new System.Drawing.Size(96, 41);
			this.btnAtivo.Text = "&Ativa";
			this.btnAtivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAtivo.ToolTipText = "Ativa";
			this.btnAtivo.Click += new System.EventHandler(this.btnAtivo_Click);
			// 
			// frmDespesaPeriodica
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.ClientSize = new System.Drawing.Size(708, 721);
			this.Controls.Add(this.btnSetBanco);
			this.Controls.Add(this.txtBanco);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.btnSetForma);
			this.Controls.Add(this.dtpDespesaData);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtCobrancaForma);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.line2);
			this.Controls.Add(this.line1);
			this.Controls.Add(this.btnSetSetor);
			this.Controls.Add(this.txtSetor);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnSetDespesaTipo);
			this.Controls.Add(this.btnSetCredor);
			this.Controls.Add(this.txtDespesaTipo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtCredor);
			this.Controls.Add(this.lblContribuinte);
			this.Controls.Add(this.txtDespesaValor);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.dtpIniciarData);
			this.Controls.Add(this.txtDespesaDescricao);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.lblCongregacao);
			this.Controls.Add(this.tspMenu);
			this.Controls.Add(this.panel2);
			this.KeyPreview = true;
			this.Name = "frmDespesaPeriodica";
			this.Shown += new System.EventHandler(this.frmDespesaPeriodica_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
			this.Controls.SetChildIndex(this.panel2, 0);
			this.Controls.SetChildIndex(this.tspMenu, 0);
			this.Controls.SetChildIndex(this.lblCongregacao, 0);
			this.Controls.SetChildIndex(this.label6, 0);
			this.Controls.SetChildIndex(this.txtDespesaDescricao, 0);
			this.Controls.SetChildIndex(this.dtpIniciarData, 0);
			this.Controls.SetChildIndex(this.label8, 0);
			this.Controls.SetChildIndex(this.txtDespesaValor, 0);
			this.Controls.SetChildIndex(this.lblContribuinte, 0);
			this.Controls.SetChildIndex(this.txtCredor, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.txtDespesaTipo, 0);
			this.Controls.SetChildIndex(this.btnSetCredor, 0);
			this.Controls.SetChildIndex(this.btnSetDespesaTipo, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.txtSetor, 0);
			this.Controls.SetChildIndex(this.btnSetSetor, 0);
			this.Controls.SetChildIndex(this.line1, 0);
			this.Controls.SetChildIndex(this.line2, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.label7, 0);
			this.Controls.SetChildIndex(this.txtCobrancaForma, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.dtpDespesaData, 0);
			this.Controls.SetChildIndex(this.btnSetForma, 0);
			this.Controls.SetChildIndex(this.label9, 0);
			this.Controls.SetChildIndex(this.txtBanco, 0);
			this.Controls.SetChildIndex(this.btnSetBanco, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tspMenu.ResumeLayout(false);
			this.tspMenu.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
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
		internal VIBlend.WinForms.Controls.vButton btnSetCredor;
		internal System.Windows.Forms.TextBox txtCredor;
		internal System.Windows.Forms.Label lblContribuinte;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TextBox txtDespesaTipo;
		internal VIBlend.WinForms.Controls.vButton btnSetDespesaTipo;
		internal VIBlend.WinForms.Controls.vButton btnSetSetor;
		internal System.Windows.Forms.TextBox txtSetor;
		internal System.Windows.Forms.Label label5;
		private AwesomeShapeControl.Line line1;
		private AwesomeShapeControl.Line line2;
		internal System.Windows.Forms.Label label6;
		private System.Windows.Forms.DateTimePicker dtpIniciarData;
		internal VIBlend.WinForms.Controls.vButton btnSetForma;
		internal System.Windows.Forms.TextBox txtCobrancaForma;
		internal System.Windows.Forms.Label label7;
		internal VIBlend.WinForms.Controls.vButton btnSetBanco;
		internal System.Windows.Forms.TextBox txtBanco;
		internal System.Windows.Forms.Label label9;
		private CamadaUC.ucOnlyNumbers txtRecorrenciaRepeticao;
		private CamadaUC.ucComboLimitedValues cmbRecorrenciaMes;
		private CamadaUC.ucComboLimitedValues cmbRecorrenciaSemana;
		private CamadaUC.ucComboLimitedValues cmbRecorrenciaDia;
		private CamadaUC.ucComboLimitedValues cmbRecorrenciaTipo;
		internal System.Windows.Forms.Label lblRecorrenciaTexto;
		internal System.Windows.Forms.Label lblMes;
		internal System.Windows.Forms.Label lblSemana;
		internal System.Windows.Forms.Label lblDia;
		internal System.Windows.Forms.Label label10;
		private AwesomeShapeControl.Line line3;
		internal System.Windows.Forms.Label label11;
		internal System.Windows.Forms.Label label12;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ToolStripButton btnAtivo;
	}
}
