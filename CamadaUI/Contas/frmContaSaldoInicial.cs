using CamadaBLL;
using CamadaDTO;
using System;
using System.Drawing;
using System.Windows.Forms;
using static CamadaUI.FuncoesGlobais;
using static CamadaUI.Utilidades;

namespace CamadaUI.Contas
{
	public partial class frmContaSaldoInicial : CamadaUI.Modals.frmModFinBorder
	{
		public objConta propConta { get; set; }
		private BindingSource bind = new BindingSource();
		private Form _formOrigem;

		#region SUB NEW | PROPERTIES

		// SUB NEW
		//------------------------------------------------------------------------------------------------------------
		public frmContaSaldoInicial(objConta conta, Form formOrigem)
		{
			InitializeComponent();

			propConta = conta;
			_formOrigem = formOrigem;

			bind.DataSource = propConta;
			BindingCreator();

			HandlerKeyDownControl(this);
			this.Activated += form_Activated;
			this.FormClosed += form_FormClosed;
		}

		#endregion

		#region DATABINDING

		// ADD DATA BINDIGNS
		//------------------------------------------------------------------------------------------------------------
		private void BindingCreator()
		{
			// CREATE BINDINGS
			lblID.DataBindings.Add("Text", bind, "IDConta", true);
			lblConta.DataBindings.Add("Text", bind, "Conta", true, DataSourceUpdateMode.OnPropertyChanged);
			lblCongregacao.DataBindings.Add("Text", bind, "Congregacao", true, DataSourceUpdateMode.OnPropertyChanged);
			txtSaldoInicial.DataBindings.Add("Text", bind, "ContaSaldo", true, DataSourceUpdateMode.OnPropertyChanged);
			dtpDataInicial.DataBindings.Add("Value", bind, "BloqueioData", true, DataSourceUpdateMode.OnPropertyChanged);

			// FORMAT HANDLERS
			lblID.DataBindings["Text"].Format += FormatID;
			txtSaldoInicial.DataBindings["Text"].Format += FormatCurrency;
		}

		private void FormatID(object sender, ConvertEventArgs e)
		{
			e.Value = e.Value == DBNull.Value ? null : $"{e.Value: 0000}";
		}

		private void FormatCurrency(object sender, ConvertEventArgs e)
		{
			e.Value = string.Format("{0:c}", e.Value);
		}

		#endregion

		#region BUTTONS

		// FECHAR FORM
		//------------------------------------------------------------------------------------------------------------
		private void btnFechar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		// SALVAR UPDATE SALDO INICIAL
		//------------------------------------------------------------------------------------------------------------
		private void btnSalvar_Click(object sender, EventArgs e)
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- check data
				if (!CheckSaveData()) return;

				// create ajuste
				objCaixaAjuste ajuste = null;

				if (propConta.ContaSaldo > 0)
				{
					ajuste = CreateAjuste();
					if (ajuste == null) return;
				}

				//--- execute INSERT
				ContaBLL cBLL = new ContaBLL();
				cBLL.InsertSaldoInicialConta(ajuste, dtpDataInicial.Value, ContaSaldoLocalUpdate, SetorSaldoLocalUpdate);

				//--- emit massage
				AbrirDialog("Saldo Inicial e Data de Bloqueio inicial inseridos com sucesso!",
					"Registro Salvo", DialogType.OK, DialogIcon.Information);

				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Salvar Registro de Saldo Inicial..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		private bool CheckSaveData()
		{
			if (propConta.ContaSaldo == 0)
			{
				AbrirDialog("O valor do saldo incial da conta não foi informado ou é igual a zero..." + "\n" +
							"Favor informar o valor do SALDO INICIAL da nova CONTA.",
							"Saldo Inicial",
							DialogType.OK,
							DialogIcon.Information);

				txtSaldoInicial.Focus();
				txtSaldoInicial.SelectAll();
				return false;
			}

			if (dtpDataInicial.Value > DateTime.Today)
			{
				AbrirDialog("A Data Inicial não pode ser posterior à Data de hoje..." + "\n" +
							"Favor informar uma Data anterior ou igual à data de hoje.",
							"Data Inicial",
							DialogType.OK,
							DialogIcon.Information);

				dtpDataInicial.Focus();
				return false;
			}

			return true;
		}

		private objCaixaAjuste CreateAjuste()
		{
			// get Setor de Entrada
			objSetor setor = null;

			Setores.frmSetorProcura frm = new Setores.frmSetorProcura(this);
			frm.ShowDialog();

			//--- check return
			if (frm.DialogResult == DialogResult.OK)
			{
				setor = frm.propEscolha;

				if (propConta.IDCongregacao != setor.IDCongregacao)
				{
					var resp = AbrirDialog("A Congregação Padrão do Setor de Recursos escolhido é " +
						"diferente da congregação padrão da Nova Conta...\n" +
						"Deseja continuar assim mesmo?", "Congregação Divergente",
						DialogType.SIM_NAO, DialogIcon.Question, DialogDefaultButton.Second);

					if (resp == DialogResult.No) return null;
				}

			}
			else
			{
				return null;
			}

			objCaixaAjuste ajuste = new objCaixaAjuste(null)
			{
				AjusteDescricao = "Ajuste de Saldo Inicial Conta",
				IDConta = (int)propConta.IDConta,
				Conta = propConta.Conta,
				IDAjusteTipo = 1,
				IDSetor = (int)setor.IDSetor,
				Setor = setor.Setor,
				IDUserAuth = (int)Program.usuarioAtual.IDUsuario,
				MovData = dtpDataInicial.Value,
				MovValor = propConta.ContaSaldo,
				MovValorReal = propConta.ContaSaldo
			};

			return ajuste;
		}

		#endregion

		#region CONTROL FUNCTIONS

		// CLOSE WHEN PRESS ESC
		//------------------------------------------------------------------------------------------------------------
		private void frmContaSaldoInicial_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				e.Handled = true;
				btnFechar_Click(sender, new EventArgs());
			}
		}

		#endregion // CONTROL FUNCTIONS --- END

		#region DESIGN FORM FUNCTIONS

		private void form_Activated(object sender, EventArgs e)
		{
			if (_formOrigem != null)
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.Silver;
			}
		}

		private void form_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_formOrigem != null)
			{
				Panel pnl = (Panel)_formOrigem.Controls["Panel1"];
				pnl.BackColor = Color.SlateGray;
			}
		}

		#endregion // DESIGN FORM FUNCTIONS --- END
	}
}
