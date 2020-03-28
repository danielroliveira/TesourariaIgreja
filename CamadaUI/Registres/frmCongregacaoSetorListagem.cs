using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDTO;
using CamadaBLL;
using static CamadaUI.Utilidades;
using System.Linq;

namespace CamadaUI.Registres
{
	public partial class frmCongregacaoSetorListagem : CamadaUI.modals.frmModFinBorder
	{
		private List<objCongregacaoSetor> listSetor = new List<objCongregacaoSetor>();
		private bool _Procura;
		private Image ImgInativo = Properties.Resources.block_24;
		private Image ImgAtivo = Properties.Resources.accept_24;
		private Form _formOrigem;

		//--- PROPRIEDADE DE ESCOLHA
		public objCongregacaoSetor propEscolha { get; set; }

		public frmCongregacaoSetorListagem(bool Procura = false, Form formOrigem = null)
		{
			InitializeComponent();

			//--- Add any initialization after the InitializeComponent() call.
			CarregaCmbAtivo();
			_Procura = Procura;
			_formOrigem = formOrigem;

			//--- Verifica se o form foi aberto para PROCURA ou para CONTROLE 
			if (Procura == true) //--- nesse caso foi aberto para procura
			{
				btnEditar.Text = "&Escolher";
				btnEditar.Image = Properties.Resources.accept_24;
				btnAdicionar.Enabled = false;
				btnFechar.Text = "&Cancelar";
				lblTitulo.Text = "Escolher Fornecedor";
			}
			else
			{
				btnEditar.Text = "&Editar";
				btnEditar.Image = Properties.Resources.editar_24;
				btnAdicionar.Enabled = true;
				btnFechar.Text = "&Fechar";
				lblTitulo.Text = "Procurar Fornecedor";
			}

			ObterDados();
			FormataListagem();
		}

		private void ObterDados()
		{
			try
			{
				// --- Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				CongregacaoBLL cBLL = new CongregacaoBLL();
				listSetor = cBLL.GetListCongregacaoSetor();

				dgvListagem.DataSource = listSetor;
			}
			catch (Exception ex)
			{
				AbrirDialog("Uma exceção ocorreu ao Obter os Dados da listagem..." + "\n" +
							ex.Message, "Exceção", DialogType.OK, DialogIcon.Exclamation);
			}
			finally
			{
				// --- Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}

		}

		private void CarregaCmbAtivo()
		{
			//--- Create DataTable
			DataTable dtAtivo = new DataTable();
			dtAtivo.Columns.Add("Ativo");
			dtAtivo.Columns.Add("Texto");
			dtAtivo.Rows.Add(new object[] { false, "Inativo" });
			dtAtivo.Rows.Add(new object[] { true, "Ativo" });

			//--- Set DataTable
			cmbAtivo.DataSource = dtAtivo;
			cmbAtivo.ValueMember = "Ativo";
			cmbAtivo.DisplayMember = "Texto";
			cmbAtivo.SelectedValue = true;
		}

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

			//--- (1) COLUNA REG
			Padding newPadding = new Padding(5, 0, 0, 0);
			clnID.DataPropertyName = "IDCongregacaoSetor";
			clnID.Visible = true;
			clnID.ReadOnly = true;
			clnID.Resizable = DataGridViewTriState.False;
			clnID.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnID.DefaultCellStyle.Padding = newPadding;
			clnID.DefaultCellStyle.Format = "0000";

			//--- (2) COLUNA CADASTRO
			clnCadastro.DataPropertyName = "CongregacaoSetor";
			clnCadastro.Visible = true;
			clnCadastro.ReadOnly = true;
			clnCadastro.Resizable = DataGridViewTriState.False;
			clnCadastro.SortMode = DataGridViewColumnSortMode.NotSortable;
			clnCadastro.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			clnCadastro.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

			//--- (3) Coluna da imagem
			clnImage.Name = "Ativo";
			clnImage.Resizable = DataGridViewTriState.False;
			clnImage.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			clnImage.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

			//--- Add Columns
			dgvListagem.Columns.AddRange(clnID, clnCadastro, clnImage);
		}

		private void btnFechar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnAdicionar_Click(object sender, EventArgs e)
		{
			frmCongregacaoSetor frm = new frmCongregacaoSetor(new objCongregacaoSetor(null));
			frm.MdiParent = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
		}

		private void btnEditar_Click(object sender, EventArgs e)
		{

		}
	}
}
