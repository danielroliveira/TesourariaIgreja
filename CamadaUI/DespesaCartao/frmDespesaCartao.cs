using CamadaBLL;
using CamadaDTO;
using CamadaUI.Imagem;
using CamadaUI.Setores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.DespesaCartao
{
	public partial class frmDespesaCartao : CamadaUI.Modals.frmModFinBorder
	{
		private objDespesaCartao _despesa;
		private DespesaCartaoBLL despBLL = new DespesaCartaoBLL();
		private BindingSource bind = new BindingSource();
		private BindingSource bindParcelas = new BindingSource();
		private EnumFlagEstado _Sit;
		private List<objAPagar> listAPagar = new List<objAPagar>();

		private List<objDespesaDocumentoTipo> listDocTipos;
		private objSetor setorSelected;
		private Form _formOrigem;

		private ErrorProvider EP = new ErrorProvider(); // default error provider

		#region SUB NEW | CONSTRUCTOR | PROPERTIES

		// CONSTRUCTOR WITH DESPESA
		//------------------------------------------------------------------------------------------------------------
		public frmDespesaCartao(objDespesaCartao despesa, Form formOrigem = null)
		{
			InitializeComponent();
			_formOrigem = formOrigem;
			ConstructorContinue(despesa);
		}

		// CONSTRUCTOR WITH ID
		//------------------------------------------------------------------------------------------------------------
		public frmDespesaCartao(long IDDespesa)
		{
			InitializeComponent();
			var desp = GetDespesaByID(IDDespesa);

			if (desp == null) return;

			ConstructorContinue(desp);
		}

		// CONSTRUCTOR CONTINUE AFTER GET DESPESA
		//------------------------------------------------------------------------------------------------------------
		private void ConstructorContinue(objDespesaCartao despesa)
		{
			_despesa = despesa;

			// Define Conta and Setor padrao
			frmPrincipal principal = Application.OpenForms.OfType<frmPrincipal>().First();
			setorSelected = principal.propSetorPadrao;

			// binding
			bind.DataSource = typeof(objDespesa);
			bind.Add(_despesa);
			BindingCreator();

			if (_despesa.IDDespesa == null)
			{
				Sit = EnumFlagEstado.NovoRegistro;
				_despesa.IDSetor = (int)setorSelected.IDSetor;
				_despesa.Setor = setorSelected.Setor;
				_despesa.DespesaData = DataPadrao();
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
				GetAPagar();
			}

			// format Datagridview
			FormataListagem();
			bindParcelas.DataSource = listAPagar;
			dgvListagem.DataSource = bindParcelas;

			// handlers
			_despesa.PropertyChanged += RegistroAlterado;
			HandlerKeyDownControl(this);
		}

		// SHOW
		//------------------------------------------------------------------------------------------------------------
		private void frmDespesaCartao_Shown(object sender, EventArgs e)
		{
			if (_despesa == null)
			{
				Close();
				return;
			}

			txtSetor.Enter += text_Enter;
			lblDespesaTipo.Enter += text_Enter;
			lblDocumentoTipo.Enter += text_Enter;

			// block keyDown then Sit = Alterado
			txtDocumentoNumero.KeyDown += control_KeyDown_Block;
			txtDespesaValor.KeyDown += control_KeyDown_Block;

			// if frmListagem is ENABLED
			if (Modal)
			{
				btnNovo.Enabled = false;
				return;
			}
		}

		// PROPERTY SITUACAO
		//------------------------------------------------------------------------------------------------------------
		public EnumFlagEstado Sit
		{
			get { return _Sit; }
			set
			{
				_Sit = value;

				if (value == EnumFlagEstado.NovoRegistro)
				{
					btnNovo.Enabled = false;
					btnSalvar.Enabled = true;
					btnCancelar.Enabled = true;
					lblSitBlock.Visible = false;
				}
				else
				{
					btnNovo.Enabled = true;
					btnSalvar.Enabled = false;
					btnCancelar.Enabled = false;
					lblSitBlock.Visible = true;
				}

				// btnSET ENABLE | DISABLE
				btnSetSetor.Enabled = value == EnumFlagEstado.NovoRegistro;
			}
		}

		// GET DESPESA BY ID
		//------------------------------------------------------------------------------------------------------------
		private objDespesaCartao GetDespesaByID(long ID)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				return despBLL.GetDespesaCartaoByID(ID);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a Despesa..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
				return null;
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// GET PARCELAMENTO | APAGAR
		//------------------------------------------------------------------------------------------------------------
		private void GetAPagar()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				listAPagar = new APagarBLL().GetListAPagarByDespesa((long)_despesa.IDDespesa);

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao obter a lista de Parcelamento..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // SUB NEW | CONSTRUCTOR --- END

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDDespesa", true);
			txtSetor.DataBindings.Add("Text", bind, "Setor", true, DataSourceUpdateMode.OnPropertyChanged);
			//txtCredor.DataBindings.Add("Text", bind, "Credor", true, DataSourceUpdateMode.OnPropertyChanged);
			lblDespesaTipo.DataBindings.Add("Text", bind, "DespesaTipo", true, DataSourceUpdateMode.OnPropertyChanged);
			lblDocumentoTipo.DataBindings.Add("Text", bind, "DocumentoTipo", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDocumentoNumero.DataBindings.Add("Text", bind, "DocumentoNumero", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDespesaDescricao.DataBindings.Add("Text", bind, "DespesaDescricao", true, DataSourceUpdateMode.OnPropertyChanged);
			lblDespesaData.DataBindings.Add("Text", bind, "DespesaData", true, DataSourceUpdateMode.OnPropertyChanged);
			txtDespesaValor.DataBindings.Add("Text", bind, "DespesaValor", true, DataSourceUpdateMode.OnPropertyChanged);
			//txtTitular.DataBindings.Add("Text", bind, "Titular", true, DataSourceUpdateMode.OnPropertyChanged);

			//dtpDataInicial.DataBindings.Add("Value", bind, "DataInicial", true, DataSourceUpdateMode.OnPropertyChanged);
			//dtpDataFinal.DataBindings.Add("Value", bind, "DataFinal", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			txtDespesaValor.DataBindings["Text"].Format += FormatCurrency;
			//txtTitular.DataBindings["Text"].Format += FormatNomeCNP;
		}

		private void FormatID(object sender, ConvertEventArgs e)
		{
			if (e.Value == DBNull.Value || e.Value == null)
			{
				e.Value = "NOVA";
			}
			else
			{
				e.Value = $"{e.Value: 0000}";
			}
		}

		private void FormatNomeCNP(object sender, ConvertEventArgs e)
		{
			e.Value = string.IsNullOrEmpty(_despesa.CNP) ? e.Value : $"{e.Value} ({_despesa.CNP})";
		}

		private void FormatCurrency(object sender, ConvertEventArgs e)
		{
			e.Value = string.Format("{0:c}", e.Value);
		}

		private void RegistroAlterado(object sender, PropertyChangedEventArgs e)
		{
			if (Sit != EnumFlagEstado.Alterado && Sit != EnumFlagEstado.NovoRegistro)
			{
				Sit = EnumFlagEstado.Alterado;
			}

			EP.Clear();
		}

		#endregion // DATABINDING --- END

		#region BUTTONS

		private void btnNovo_Click(object sender, EventArgs e)
		{
			// if frmAPagarListagem is ENABLED then exit
			if (Modal)
			{
				btnNovo.Enabled = false;
				return;
			}

			if (Sit == EnumFlagEstado.NovoRegistro || Sit == EnumFlagEstado.RegistroBloqueado) return;

			_despesa = new objDespesaCartao(null);
			Sit = EnumFlagEstado.NovoRegistro;
			bind.DataSource = _despesa;
			listAPagar = new List<objAPagar>();
			bindParcelas.DataSource = listAPagar;
			txtSetor.Focus();
		}

		private void btnFechar_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.Alterado || Sit == EnumFlagEstado.NovoRegistro)
			{
				AbrirDialog("Esse registro ainda não foi salvo... \n" +
					"Favor SALVAR ou CANCELAR a edição do registro atual antes de fechar.",
					"Registro Novo ou Alterado", DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			Close();

			if (_formOrigem != null && _formOrigem.Name == "frmDespesaCartaoListagem")
			{
				var frm = new Saidas.frmDespesaListagem();
				frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
				frm.Show();
			}
			else
			{
				MostraMenuPrincipal();
			}
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.NovoRegistro)
			{
				var response = AbrirDialog("Deseja cancelar a inserção de um novo registro?",
							   "Cancelar", DialogType.SIM_NAO, DialogIcon.Question);

				if (response == DialogResult.Yes)
				{
					Close();
					MostraMenuPrincipal();
				}
			}
			else if (Sit == EnumFlagEstado.Alterado)
			{
				bind.CancelEdit();
				Sit = EnumFlagEstado.RegistroSalvo;
			}
			else
			{
				Sit = EnumFlagEstado.RegistroSalvo;
			}

		}

		#endregion // BUTTONS --- END

		#region BUTTONS PROCURA

		private void btnSetSetor_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				frmSetorProcura frm = new frmSetorProcura(this, _despesa.IDSetor);
				frm.ShowDialog();

				//--- check return
				if (frm.DialogResult == DialogResult.OK)
				{
					if (Sit != EnumFlagEstado.NovoRegistro && _despesa.IDSetor != frm.propEscolha.IDSetor)
						Sit = EnumFlagEstado.Alterado;

					_despesa.IDSetor = (int)frm.propEscolha.IDSetor;
					txtSetor.Text = frm.propEscolha.Setor;
				}

				//--- select
				txtSetor.Focus();
				txtSetor.SelectAll();
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao abrir o formulário de procura..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // BUTTONS PROCURA --- END

		#region CONTROL FUNCTIONS

		// BLOCK KEY (+) FOR SOME CONTROLS
		//------------------------------------------------------------------------------------------------------------
		private void frm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 43)
			{
				//--- cria uma lista de controles que serao impedidos de receber '+'
				Control[] controlesBloqueados = {
					lblDespesaTipo,
					lblDocumentoTipo,
					txtSetor,
					txtDespesaDescricao,
				};

				if (controlesBloqueados.Contains(ActiveControl)) e.Handled = true;
			}
		}

		// CLOSE WHEN PRESS ESC
		//------------------------------------------------------------------------------------------------------------
		private void frm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				e.Handled = true;
				btnFechar_Click(sender, new EventArgs());
			}
		}

		// CONTROL KEYDOWN: BLOCK (+), CREATE (DELETE), BLOCK EDIT
		//------------------------------------------------------------------------------------------------------------
		private void Control_KeyDown(object sender, KeyEventArgs e)
		{
			// previne to accepts changes if SIT = RegistroSalvo
			//---------------------------------------------------
			if (Sit == EnumFlagEstado.RegistroSalvo)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				return;
			}
			//---------------------------------------------------

			Control ctr = (Control)sender;

			if (e.KeyCode == Keys.Add || e.KeyCode == Keys.F4)
			{
				e.Handled = true;

				switch (ctr.Name)
				{
					case "txtSetor":
						btnSetSetor_Click(sender, new EventArgs());
						break;
					default:
						break;
				}
			}
			else if (e.KeyCode == Keys.Delete)
			{
				switch (ctr.Name)
				{
					case "txtDespesaDescricao":
						e.Handled = false;
						break;
					default:
						e.Handled = true;
						break;
				}
			}
			else if ((e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9) | (e.KeyCode >= Keys.NumPad1 && e.KeyCode <= Keys.NumPad9))
			{
				//--- cria um array de controles que serao liberados ao KEYPRESS
				Control[] controlesBloqueados = {
					lblDocumentoTipo, txtDespesaDescricao,
				};

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = false;
				}
				else
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
			else if (e.Alt) // permite O 'ALT'
			{
				e.Handled = false;
			}
			else // finaly block all inserts changes
			{
				//--- cria um array de controles que serão bloqueados de alteracao
				Control[] controlesBloqueados = {
					txtSetor,
					lblDespesaTipo,
					lblDocumentoTipo,
				 };

				if (controlesBloqueados.Contains(ctr))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
		}

		// EMITE TOOLTIP ON ENTER E DESABILITA
		//------------------------------------------------------------------------------------------------------------
		private void text_Enter(object sender, EventArgs e)
		{
			ShowToolTip(sender as Control);
			((TextBox)sender).Enter -= text_Enter;
		}

		// PREVINE CHANGES IN SIT => REGISTRO SALVO
		private void control_KeyDown_Block(object sender, KeyEventArgs e)
		{
			// previne to accepts changes if SIT = RegistroSalvo
			//---------------------------------------------------
			if (Sit == EnumFlagEstado.RegistroSalvo)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				return;
			}
			//---------------------------------------------------
		}

		#endregion // CONTROL FUNCTIONS --- END

		#region TOOLTIP

		private void ShowToolTip(Control controle)
		{
			//Cria a ToolTip e associa com o Form container.
			ToolTip toolTip1 = new ToolTip()
			{
				AutoPopDelay = 2000, // Define o delay para a ToolTip
				InitialDelay = 2000,
				ReshowDelay = 500,
				IsBalloon = true,
				UseAnimation = true,
				UseFading = true
			};

			if (controle.Tag == null)
			{
				toolTip1.Show("Clique aqui...", controle, controle.Width - 30, -40, 2000);
			}
			else
			{
				toolTip1.Show(controle.Tag.ToString(), controle, controle.Width - 30, -40, 2000);
			}
		}

		#endregion

		#region MENU A PAGAR

		private void dgvListagem_MouseDown(object sender, MouseEventArgs e)
		{
			// check button
			if (e.Button != MouseButtons.Right) return;

			Control c = (Control)sender;
			DataGridView.HitTestInfo hit = dgvListagem.HitTest(e.X, e.Y);
			dgvListagem.ClearSelection();

			if (hit.Type == DataGridViewHitTestType.Cell)
			{
				// seleciona o ROW
				dgvListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
				dgvListagem.CurrentCell = dgvListagem.Rows[hit.RowIndex].Cells[2];
				dgvListagem.Rows[hit.RowIndex].Selected = true;

				// mostra o MENU ativar e desativar
				objAPagar desp = (objAPagar)dgvListagem.Rows[hit.RowIndex].DataBoundItem;

				// mnuImagem
				bool IsThereImagem = desp.Imagem != null && !string.IsNullOrEmpty(desp.Imagem.ImagemFileName);

				mnuImagemRemover.Enabled = IsThereImagem;
				mnuImagemInserir.Text = IsThereImagem ? "Alterar Imagem" : "Inserir Imagem";
				mnuImagemVisualizar.Enabled = IsThereImagem;

				mnuEditarAPagar.Enabled = true;
				mnuExcluirAPagar.Enabled = true;
				mnuImagemAPagar.Enabled = true;
			}
			else
			{
				mnuEditarAPagar.Enabled = false;
				mnuExcluirAPagar.Enabled = false;
				mnuImagemAPagar.Enabled = false;
			}

			// revela menu
			mnuOperacoes.Show(c.PointToScreen(e.Location));

		}

		// INSERT IMAGE
		//------------------------------------------------------------------------------------------------------------
		private void mnuImagemInserir_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Inserir Imagem...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objAPagar item = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

			if (item.IDAPagar == null)
			{
				AbrirDialog("Não é possível inserir imagem de uma Parcela de APagar num Despesa que ainda não foi salva..." +
					"\nSalvar a Despesa antes de Inserir a imagem.",
					"Inserir Imagem", DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				objImagem imagem = new objImagem()
				{
					IDOrigem = (long)item.IDAPagar,
					Origem = EnumImagemOrigem.APagar,
					ImagemFileName = item.Imagem == null ? string.Empty : item.Imagem.ImagemFileName,
					ImagemPath = item.Imagem == null ? string.Empty : item.Imagem.ImagemPath,
					ReferenceDate = item.Vencimento,
				};

				// open form to edit or save image
				bool IsNew = item.Imagem == null || string.IsNullOrEmpty(item.Imagem.ImagemPath);
				imagem = ImagemUtil.ImagemGetFileAndSave(imagem, this);

				// check if isUpdated
				bool IsUpdated = false;
				if (item.Imagem != null && imagem != null)
				{
					IsUpdated = (item.Imagem.ImagemFileName != imagem.ImagemFileName) || (item.Imagem.ImagemPath != imagem.ImagemPath);
				}

				// update imagem object
				item.Imagem = imagem;

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

		private void mnuImagemVisualizar_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Visualizar Imagem...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objAPagar item = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

			if (item.IDAPagar == null)
			{
				AbrirDialog("Não é possível visualizar imagem de uma Parcela de APagar numa Despesa que ainda não foi salva..." +
					"\nSalvar a Despesa antes de Visualizar a imagem.",
					"Inserir Imagem", DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;
				ImagemUtil.ImagemVisualizar(item.Imagem);
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

		private void mnuImagemRemover_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Visualizar Imagem...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objAPagar item = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

			if (item.IDAPagar == null)
			{
				AbrirDialog("Não é possível REMOVER imagem de uma Parcela de APagar numa Despesa que ainda não foi salva..." +
					"\nSalvar a Despesa antes de REMOVER a imagem.",
					"Inserir Imagem", DialogType.OK, DialogIcon.Exclamation);
				return;
			}

			DialogResult resp;

			resp = AbrirDialog("Deseja realmente REMOVER ou DESASSOCIAR a imagem da despesa selecionada?" +
				"\nA imagem não será excluída mas movida para pasta de Imagens Removidas...",
				"Remover Imagem", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

			if (resp != DialogResult.Yes) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//_despesa.Imagem.ReferenceDate = _despesa.DespesaData;
				item.Imagem = ImagemUtil.ImagemRemover(item.Imagem);

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

		// ADICIONAR APAGAR
		//------------------------------------------------------------------------------------------------------------
		private void mnuAdicionarAPagar_Click(object sender, EventArgs e)
		{
			try
			{
				//--- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- CHECK DESPESA VALUE
				if (_despesa.DespesaValor <= 0)
				{
					AbrirDialog("O valor da Despesa precisa ser maior do que Zero...\n" +
						"Favor inserir o valor desta despesa corretamente.",
						"Valor da Despesa",
						DialogType.OK,
						DialogIcon.Exclamation);
					EP.SetError(txtDespesaValor, "Valor necessário...");
					txtDespesaValor.Focus();
					return;
				}

				//--- define value
				decimal vlMaximo = _despesa.DespesaValor - listAPagar.Sum(x => x.APagarValor);

				if (vlMaximo <= 0)
				{
					AbrirDialog("O Valor Total das Parcelas APagar já alcançou o valor da Despesa..." +
						"\nNão há possibilidade de criar Novas Parcelas.",
						"Valor Alcançado", DialogType.OK, DialogIcon.Exclamation);
					return;
				}

				//--- define date
				DateTime newDate = _despesa.DespesaData;

				//--- define LAST APagar
				objAPagar LastPag = null;

				if (listAPagar.Count > 0)
				{
					LastPag = listAPagar.OrderBy(x => x.Vencimento).Last();
				}

				//--- define new apagar
				var newParcela = new objAPagar(null)
				{
					APagarValor = vlMaximo,
					Vencimento = LastPag != null ? LastPag.Vencimento.AddMonths(1) : newDate,
					IDBanco = LastPag != null ? LastPag.IDBanco : null,
					Banco = LastPag != null ? LastPag.Banco : "",
					IDAPagarForma = LastPag != null ? LastPag.IDAPagarForma : 1,
					APagarForma = LastPag != null ? LastPag.APagarForma : "Em Carteira"
				};

				//--- open Form
				var frm = new Saidas.frmDespesaAPagarItem(newParcela, vlMaximo, _despesa.DespesaData, this);
				frm.ShowDialog();

				if (frm.DialogResult != DialogResult.OK) return;

				bindParcelas.Add(newParcela);
				bindParcelas.ResetBindings(false);
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Adicionar parcela de APagar..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// EDITAR A PAGAR
		//------------------------------------------------------------------------------------------------------------
		private void mnuEditarAPagar_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para Editar...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objAPagar item = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

			if (item.IDAPagar != null)
			{
				AbrirDialog("Não é possível editar uma parcela de APagar que já está salva.",
					"Registro Bloqueado",
					DialogType.OK,
					DialogIcon.Exclamation);
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- CHECK DESPESA VALUE
				if (_despesa.DespesaValor <= 0)
				{
					AbrirDialog("O valor da Despesa precisa ser maior do que Zero...\n" +
						"Favor inserir o valor desta despesa corretamente.",
						"Valor da Despesa",
						DialogType.OK,
						DialogIcon.Exclamation);
					EP.SetError(txtDespesaValor, "Valor necessário...");
					txtDespesaValor.Focus();
					return;
				}

				//--- define value
				decimal vlMaximo = _despesa.DespesaValor - listAPagar.Sum(x => x.APagarValor) + item.APagarValor;

				//--- define date
				DateTime newDate = item.Vencimento;

				if (listAPagar.Count > 0)
				{
					newDate = listAPagar.OrderBy(x => x.Vencimento).Last().Vencimento.AddMonths(1);
				}

				//--- define new apagar
				var Parcela = item;

				//--- open Form
				var frm = new Saidas.frmDespesaAPagarItem(Parcela, vlMaximo, _despesa.DespesaData, this);
				frm.ShowDialog();

				if (frm.DialogResult != DialogResult.OK) return;

				bindParcelas.ResetBindings(false);

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Editar a Parcela..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// EXCLUIR APAGAR
		//------------------------------------------------------------------------------------------------------------
		private void mnuExcluirAPagar_Click(object sender, EventArgs e)
		{
			//--- check selected item
			if (dgvListagem.SelectedRows.Count == 0)
			{
				AbrirDialog("Favor selecionar um registro para EXCLUIR...",
					"Selecionar Registro", DialogType.OK, DialogIcon.Information);
				return;
			}

			//--- get Selected item
			objAPagar item = (objAPagar)dgvListagem.SelectedRows[0].DataBoundItem;

			if (item.IDAPagar != null)
			{
				AbrirDialog("Não é possível EXCLUIR uma parcela de APagar que já está salva.",
					"Registro Bloqueado",
					DialogType.OK,
					DialogIcon.Exclamation);
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				bindParcelas.Remove(item);
				bindParcelas.ResetBindings(false);

			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Excluir registro de APagar..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		#endregion // MENU A PAGAR --- END

		#region DATAGRID LIST FUNCTIONS

		// FORMATA LISTAGEM
		//------------------------------------------------------------------------------------------------------------
		private void FormataListagem()
		{
			dgvListagem.Columns.Clear();
			dgvListagem.AutoGenerateColumns = false;
			dgvListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvListagem.MultiSelect = false;
			dgvListagem.ColumnHeadersVisible = true;
			dgvListagem.AllowUserToResizeRows = false;
			dgvListagem.AllowUserToResizeColumns = false;
			dgvListagem.RowHeadersWidth = 36;
			dgvListagem.RowTemplate.Height = 30;
			dgvListagem.StandardTab = true;
			dgvListagem.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;

			// DEFINE COLUMN FONT
			Font clnFont = new Font("Pathway Gothic One", 13.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

			//--- (1) COLUNA FORMA
			clnForma.DataPropertyName = "APagarForma";
			clnForma.Visible = true;
			clnForma.ReadOnly = true;
			clnForma.Resizable = DataGridViewTriState.False;
			clnForma.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnForma.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnForma.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnForma.DefaultCellStyle.Font = clnFont;

			//--- (2) COLUNA SITUACAO
			clnSituacao.DataPropertyName = "Situacao";
			clnSituacao.Visible = true;
			clnSituacao.ReadOnly = true;
			clnSituacao.Resizable = DataGridViewTriState.False;
			clnSituacao.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnSituacao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnSituacao.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnSituacao.DefaultCellStyle.Font = clnFont;

			//--- (3) COLUNA ID
			clnIdentificador.DataPropertyName = "Identificador";
			clnIdentificador.Visible = true;
			clnIdentificador.ReadOnly = true;
			clnIdentificador.Resizable = DataGridViewTriState.False;
			clnIdentificador.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnIdentificador.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnIdentificador.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnIdentificador.DefaultCellStyle.Font = clnFont;

			//--- (4) COLUNA VENCIMENTO
			clnVencimento.DataPropertyName = "Vencimento";
			clnVencimento.Visible = true;
			clnVencimento.ReadOnly = true;
			clnVencimento.Resizable = DataGridViewTriState.False;
			clnVencimento.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnVencimento.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnVencimento.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnVencimento.DefaultCellStyle.Font = clnFont;

			//--- (5) COLUNA VALOR
			clnValor.DataPropertyName = "APagarValor";
			clnValor.Visible = true;
			clnValor.ReadOnly = true;
			clnValor.Resizable = DataGridViewTriState.False;
			clnValor.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			clnValor.DefaultCellStyle.Format = "#,##0.00";
			clnValor.DefaultCellStyle.Font = clnFont;

			//--- Add Columns
			dgvListagem.Columns.AddRange(clnForma, clnSituacao, clnIdentificador, clnVencimento, clnValor);
		}

		#endregion

		#region SALVAR REGISTRO

		private void btnSalvar_Click(object sender, EventArgs e)
		{
			if (Sit == EnumFlagEstado.Alterado)
			{
				AbrirDialog("Não é possível alterar um registro de Despesa...", "Alterar Despesa");
				return;
			}

			if (!VerificaRegistro()) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;



			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Evento..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}


		}

		// CHECK REGISTRES
		private bool VerificaRegistro()
		{
			// CHECK FIELDS
			if (!VerificaDadosClasse(txtSetor, "Setor Debitado", _despesa, EP)) return false;
			if (!VerificaDadosClasse(lblDespesaTipo, "Tipo de Despesa", _despesa, EP)) return false;
			if (!VerificaDadosClasse(lblDocumentoTipo, "Tipo de Documento", _despesa, EP)) return false;
			if (!VerificaDadosClasse(txtDocumentoNumero, "Número do Documento", _despesa, EP)) return false;
			if (!VerificaDadosClasse(txtDespesaDescricao, "Descrição da Despesa", _despesa, EP)) return false;

			// CHECK DESPESA VALUE
			if (_despesa.DespesaValor <= 0)
			{
				AbrirDialog("O valor da Despesa precisa ser maior do que Zero...\n" +
					"Favor inserir o valor desta despesa corretamente.", "Valor da Despesa",
					DialogType.OK, DialogIcon.Exclamation);
				EP.SetError(txtDespesaValor, "Valor necessário...");
				txtDespesaValor.Focus();
				return false;
			}

			//--- Check and Create APagar
			if (listAPagar.Count == 0)
			{
				AbrirDialog("Informe as Parcelas de APagar dessa Despesa\n" +
					"Use o segundo botão do mouse na listagem e adicione uma ou mais parcelas.",
					"Informar Parcelamento",
					DialogType.OK,
					DialogIcon.Information);
				return false;
			}

			// CHECK PARCELAS VALUE AND PARCELAS QUANTITY
			if (listAPagar.Count > 0)
			{
				// check VALUE
				decimal parcTotal = listAPagar.Sum(x => x.APagarValor);

				if (Math.Abs(_despesa.DespesaValor - parcTotal) > 1)
				{
					AbrirDialog($"O valor do somatório das parcelas: {parcTotal:c} não pode ser maior que o valor da Despesa:{_despesa.DespesaValor:c}\n" +
								"Favor verificar se o valor das parcelas está correto.", "Valor das Parcelas",
								DialogType.OK, DialogIcon.Exclamation);
					txtDespesaValor.Focus();
					return false;
				}

			}

			return true;
		}


		#endregion // SALVAR REGISTRO --- END

		#region IMAGE CONTROL
		private void btnInserirImagem_Click(object sender, EventArgs e)
		{
			if (_despesa.IDDespesa == null)
			{
				AbrirDialog("É necessário salvar a despesa para anexar uma imagem...",
					"Necessário Salvar", DialogType.OK, DialogIcon.Warning);
				return;
			}

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				objImagem imagem = new objImagem()
				{
					IDOrigem = (long)_despesa.IDDespesa,
					Origem = EnumImagemOrigem.Despesa,
					ImagemFileName = _despesa.Imagem == null ? string.Empty : _despesa.Imagem.ImagemFileName,
					ImagemPath = _despesa.Imagem == null ? string.Empty : _despesa.Imagem.ImagemPath,
					ReferenceDate = _despesa.DespesaData,
				};

				// open form to edit or save image
				bool IsNew = _despesa.Imagem == null || string.IsNullOrEmpty(_despesa.Imagem.ImagemPath);
				imagem = ImagemUtil.ImagemGetFileAndSave(imagem, this);

				// check if isUpdated
				bool IsUpdated = false;
				if (_despesa.Imagem != null && imagem != null)
				{
					IsUpdated = (_despesa.Imagem.ImagemFileName != imagem.ImagemFileName) || (_despesa.Imagem.ImagemPath != imagem.ImagemPath);
				}

				// update imagem object
				_despesa.Imagem = imagem;

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
			if (_despesa.IDDespesa == null)
			{
				AbrirDialog("Ainda não existe nenhuma imagem associada a essa Despesa..." +
					"\nÉ necessário salvar a despesa para anexar uma imagem...",
					"Necessário Salvar", DialogType.OK, DialogIcon.Warning);
				return;
			}

			if (_despesa.Imagem == null || string.IsNullOrEmpty(_despesa.Imagem.ImagemFileName))
			{
				var resp = AbrirDialog("Ainda não existe nenhuma imagem associada a essa Despesa..." +
					"\nDeseja INSERIR uma nova imagem à despesa?",
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
				ImagemUtil.ImagemVisualizar(_despesa.Imagem);
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
			if (_despesa.Imagem == null || string.IsNullOrEmpty(_despesa.Imagem.ImagemFileName))
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

			if (_despesa.Imagem == null || string.IsNullOrEmpty(_despesa.Imagem.ImagemFileName))
			{
				AbrirDialog("Ainda não existe nenhuma imagem associada a essa Despesa para que seja removida...",
					"Não há Imagem", DialogType.OK, DialogIcon.Warning);
				return;
			}

			resp = AbrirDialog("Deseja realmente REMOVER ou DESASSOCIAR a imagem da despesa atual?" +
				"\nA imagem não será excluída mas movida para pasta de Imagens Removidas...",
				"Remover Imagem", DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

			if (resp != DialogResult.Yes) return;

			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//_despesa.Imagem.ReferenceDate = _despesa.DespesaData;
				_despesa.Imagem = ImagemUtil.ImagemRemover(_despesa.Imagem);

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
