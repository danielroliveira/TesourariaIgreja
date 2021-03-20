using CamadaDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static CamadaUI.Utilidades;
using CamadaBLL;
using CamadaUI.Caixa;
using CamadaUI.Imagem;

namespace CamadaUI.APagar
{
	public partial class frmAPagarDetalhe : CamadaUI.Modals.frmModFinBorder
	{
		objAPagar _apagar;
		BindingSource bind = new BindingSource();
		List<objAPagarForma> listFormas = new List<objAPagarForma>();
		Form _formOrigem;

		#region SUB NEW | CONSTRUCTOR
		public frmAPagarDetalhe(objAPagar pag, Form formOrigem)
		{
			InitializeComponent();
			Size = new Size(530, 536);
			_formOrigem = formOrigem;
			_apagar = pag;

			CheckEditing();
		}

		// VERIFY IF IS EDITING FORM OR NOT EDIT
		//------------------------------------------------------------------------------------------------------------
		private void CheckEditing()
		{
			if (_apagar.IDAPagar == null)
			{
				pnlEditar.Visible = true;
				pnlVisualizar.Visible = false;
				GetFormasList();

				bind.DataSource = _apagar;
				BindingCreatorEditing();
			}
			else
			{
				pnlEditar.Visible = false;
				pnlVisualizar.Visible = true;
				pnlVisualizar.Location = new Point(12, 132);

				bind.DataSource = _apagar;
				BindingCreatorNotEditing();
			}
		}

		// GET LIST OF FORMAS DE COBRANCA
		//------------------------------------------------------------------------------------------------------------
		private void GetFormasList()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				listFormas = new APagarFormaBLL().GetListAPagarForma(true);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de Formas de Cobrança..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region DATABINDINGS

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreatorEditing()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDAPagar", true);
			lblDespesaDescricao.DataBindings.Add("Text", bind, "DespesaDescricao", true);
			lblCredor.DataBindings.Add("Text", bind, "Credor", true);
			txtIdentificador.DataBindings.Add("Text", bind, "Identificador", true, DataSourceUpdateMode.OnPropertyChanged);
			numParcela.DataBindings.Add("Value", bind, "Parcela", true, DataSourceUpdateMode.OnPropertyChanged);
			txtAPagarForma.DataBindings.Add("Text", bind, "APagarForma", true, DataSourceUpdateMode.OnPropertyChanged);
			txtBanco.DataBindings.Add("Text", bind, "Banco", true, DataSourceUpdateMode.OnPropertyChanged);
			dtpVencimento.DataBindings.Add("Value", bind, "Vencimento", true, DataSourceUpdateMode.OnPropertyChanged);
			txtAPagarValor.DataBindings.Add("Text", bind, "APagarValor", true, DataSourceUpdateMode.OnPropertyChanged);
			numReferenciaAno.DataBindings.Add("Value", bind, "ReferenciaAno", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			txtAPagarValor.DataBindings["Text"].Format += FormatCurrency;
			numParcela.DataBindings["Value"].Format += FormatD2;

			// CARREGA COMBO
			CarregaComboMes();
			cmbReferenciaMes.DataBindings.Add("SelectedValue", bind, "ReferenciaMes", true, DataSourceUpdateMode.OnPropertyChanged);
		}

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreatorNotEditing()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDAPagar", true);
			lblDespesaDescricao.DataBindings.Add("Text", bind, "DespesaDescricao", true);
			lblCredor.DataBindings.Add("Text", bind, "Credor", true);
			lblIdentificador.DataBindings.Add("Text", bind, "Identificador", true, DataSourceUpdateMode.OnPropertyChanged);
			lblParcela.DataBindings.Add("Text", bind, "Parcela", true, DataSourceUpdateMode.OnPropertyChanged);
			lblAPagarForma.DataBindings.Add("Text", bind, "APagarForma", true, DataSourceUpdateMode.OnPropertyChanged);
			lblBanco.DataBindings.Add("Text", bind, "Banco", true, DataSourceUpdateMode.OnPropertyChanged);
			lblVencimento.DataBindings.Add("Text", bind, "Vencimento", true, DataSourceUpdateMode.OnPropertyChanged);
			lblAPagarValor.DataBindings.Add("Text", bind, "APagarValor", true, DataSourceUpdateMode.OnPropertyChanged);
			lblReferencia.DataBindings.Add("Text", bind, "Referencia", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			lblAPagarValor.DataBindings["Text"].Format += FormatCurrency;
			lblParcela.DataBindings["Text"].Format += FormatD2;

			// CARREGA COMBO
			//CarregaComboMes();
			//cmbReferenciaMes.DataBindings.Add("SelectedValue", bind, "ReferenciaMes", true, DataSourceUpdateMode.OnPropertyChanged);
		}

		private void FormatID(object sender, ConvertEventArgs e)
		{
			if (e.Value == DBNull.Value || e.Value == null)
			{
				e.Value = "NOVO";
			}
			else
			{
				e.Value = $"{e.Value: 0000}";
			}
		}

		private void FormatD2(object sender, ConvertEventArgs e)
		{
			e.Value = $"{e.Value: 00}";
		}

		private void FormatCurrency(object sender, ConvertEventArgs e)
		{
			e.Value = string.Format("{0:c}", e.Value);
		}

		// CARREGA COMBO
		//------------------------------------------------------------------------------------------------------------
		private void CarregaComboMes()
		{
			//--- Create DataTable
			DataTable dtMeses = new DataTable();
			dtMeses.Columns.Add("ID", typeof(int));
			dtMeses.Columns.Add("Mes");

			// get values of EnumAgendaRecorrencia
			string[] EnumValues = new System.Globalization.CultureInfo("pt-BR").DateTimeFormat.MonthNames;
			int i = 1;

			// insert all item of EnumAgendaRecorrencia in datatable
			foreach (var mes in EnumValues)
			{
				if (string.IsNullOrEmpty(mes)) continue;
				dtMeses.Rows.Add(new object[] { i, mes });
				i++;
			}

			//--- Set DataTable
			cmbReferenciaMes.DataSource = dtMeses;
			cmbReferenciaMes.ValueMember = "ID";
			cmbReferenciaMes.DisplayMember = "Mes";
		}

		#endregion // DATABINDINGS --- END

		#region BUTTONS FUNCTION

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnSetForma_Click(object sender, EventArgs e)
		{
			if (listFormas.Count == 0)
			{
				AbrirDialog("Não há Formas de Cobrança cadastradas ou ativas...", "Formas de Cobrança",
					DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			var dic = listFormas.ToDictionary(x => (int)x.IDAPagarForma, x => x.APagarForma);
			var textBox = txtAPagarForma;
			Main.frmComboLista frm = new Main.frmComboLista(dic, textBox, _apagar.IDAPagarForma);

			// show form
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				_apagar.IDAPagarForma = (int)frm.propEscolha.Key;
				textBox.Text = frm.propEscolha.Value;
			}

			//--- select
			textBox.Focus();
			textBox.SelectAll();
		}

		private void btnSetBanco_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmBancoProcura frm = new frmBancoProcura(this, _apagar.IDBanco);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK) // SEARCH CREDOR
				{
					_apagar.IDBanco = (int)frm.propEscolha.IDBanco;
					txtBanco.Text = frm.propEscolha.BancoNome;
				}

				//--- select
				txtBanco.Focus();
				txtBanco.SelectAll();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao abrir formulário de procura..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // BUTTONS FUNCTION --- END

		#region DESIGN FORM FUNCTIONS

		// CRIAR EFEITO VISUAL DE FORM SELECIONADO
		//------------------------------------------------------------------------------------------------------------
		private void form_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null && _formOrigem.GetType() != typeof(frmPrincipal))
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void form_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_formOrigem != null && _formOrigem.GetType() != typeof(frmPrincipal))
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.SlateGray;

			}
		}

		// CONTROLA TOOLTIP
		//------------------------------------------------------------------------------------------------------------
		private void ShowToolTip(Control control)
		{
			//--- Cria a ToolTip e associa com o Form container.
			ToolTip toolTip1 = new ToolTip();

			//--- Define o delay para a ToolTip.
			toolTip1.AutoPopDelay = 2000;
			toolTip1.InitialDelay = 2000;
			toolTip1.ReshowDelay = 500;
			toolTip1.IsBalloon = true;
			toolTip1.UseAnimation = true;
			toolTip1.UseFading = true;

			if (string.IsNullOrEmpty(control.Tag.ToString()))
				toolTip1.Show("Clique aqui...", control, control.Width - 30, -40, 2000);
			else
				toolTip1.Show(control.Tag.ToString(), control, control.Width - 30, -40, 2000);
		}

		private void btnProcurar_EnabledChanged(object sender, EventArgs e)
		{
			Control control = (Control)sender;

			if (control.Enabled == true)
				ShowToolTip(control);
		}

		#endregion // DESIGN FORM FUNCTIONS --- END

		#region IMAGE CONTROL
		private void btnInserirImagem_Click(object sender, EventArgs e)
		{
			if (_apagar.IDAPagar == null)
			{
				AbrirDialog("É necessário salvar a despesa para anexar uma imagem ao pagamento...",
					"Necessário Salvar", DialogType.OK, DialogIcon.Warning);
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				objImagem imagem = new objImagem()
				{
					IDOrigem = (long)_apagar.IDAPagar,
					Origem = EnumImagemOrigem.APagar,
					ImagemFileName = _apagar.Imagem == null ? string.Empty : _apagar.Imagem.ImagemFileName,
					ImagemPath = _apagar.Imagem == null ? string.Empty : _apagar.Imagem.ImagemPath,
					ReferenceDate = _apagar.Vencimento,
				};

				// open form to edit or save image
				bool IsNew = _apagar.Imagem == null || string.IsNullOrEmpty(_apagar.Imagem.ImagemPath);
				imagem = ImagemUtil.ImagemGetFileAndSave(imagem, this);

				// check if isUpdated
				bool IsUpdated = false;
				if (_apagar.Imagem != null && imagem != null)
				{
					IsUpdated = (_apagar.Imagem.ImagemFileName != imagem.ImagemFileName) || (_apagar.Imagem.ImagemPath != imagem.ImagemPath);
				}

				// update imagem object
				_apagar.Imagem = imagem;

				// emit message
				if (IsNew && imagem != null)
				{
					AbrirDialog("Imagem associada e salva com sucesso!" +
								"\nPor segurança a imagem foi transferida para a pasta padrão.",
								"Imagem Salva", DialogType.OK, DialogIcon.Information);
				}
				else if (IsUpdated)
				{
					AbrirDialog("Imagem alterada com sucesso!" +
								"\nPor segurança a imagem anterior foi transferida para a pasta de imagens removidas.",
								"Imagem Alterada", DialogType.OK, DialogIcon.Information);
				}
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a imagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		private void btnVerImagem_Click(object sender, EventArgs e)
		{
			if (_apagar.IDAPagar == null)
			{
				AbrirDialog("Ainda não existe nenhuma imagem associada a esse APagar..." +
					"\nÉ necessário salvar a despesa para anexar uma imagem...",
					"Necessário Salvar", DialogType.OK, DialogIcon.Warning);
				return;
			}

			if (_apagar.Imagem == null || string.IsNullOrEmpty(_apagar.Imagem.ImagemFileName))
			{
				var resp = AbrirDialog("Ainda não existe nenhuma imagem associada a esse APagar..." +
					"\nDeseja INSERIR uma nova imagem ao APagar?",
					"Não há Imagem", DialogType.SIM_NAO, DialogIcon.Question);

				if (resp == DialogResult.Yes)
				{
					btnInserirImagem_Click(sender, e);
				}

				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				ImagemUtil.ImagemVisualizar(_apagar.Imagem);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Visualizar a imagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		private void mnuImagem_Click(object sender, EventArgs e)
		{
			if (_apagar.Imagem == null || string.IsNullOrEmpty(_apagar.Imagem.ImagemFileName))
			{
				btnInserirImagem.Text = "Inserir Imagem";
				btnRemoverImagem.Enabled = false;
			}
			else
			{
				btnInserirImagem.Text = "Alterar Imagem";
				btnRemoverImagem.Enabled = true;
			}
		}

		private void btnRemoverImagem_Click(object sender, EventArgs e)
		{
			DialogResult resp;

			if (_apagar.Imagem == null || string.IsNullOrEmpty(_apagar.Imagem.ImagemFileName))
			{
				AbrirDialog("Ainda não existe nenhuma imagem associada a esse APagar para que seja removida...",
					"Não há Imagem", DialogType.OK, DialogIcon.Warning);
				return;
			}

			resp = AbrirDialog("Deseja realmente REMOVER ou DESASSOCIAR a imagem do APagar atual?" +
				"\nA imagem não será excluída mas movida para pasta de Imagens Removidas...",
				"Remover Imagem", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

			if (resp != DialogResult.Yes) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//_despesa.Imagem.ReferenceDate = _despesa.DespesaData;
				_apagar.Imagem = ImagemUtil.ImagemRemover(_apagar.Imagem);

				AbrirDialog("Imagem desassociada com sucesso!" +
					"\nPor segurança a imagem foi guardada na pasta de Imagens Removidas.",
					"Imagem Removida", DialogType.OK, DialogIcon.Information);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Remover a imagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		#endregion // IMAGE CONTROL --- END
	}
}
