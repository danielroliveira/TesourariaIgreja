using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	//=================================================================================================
	// CONTRIBUICAO
	//=================================================================================================
	public class objContribuicao : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructEntrada
		{
			internal long? _IDContribuicao;
			internal DateTime _ContribuicaoData;
			internal byte _IDEntradaForma; // dinheiro, cheque, cartao
			internal string _EntradaForma;
			internal decimal _ValorBruto;
			internal byte _IDContribuicaoTipo;
			internal string _ContribuicaoTipo;
			internal int? _IDSetor;
			internal string _Setor;
			internal int _IDConta;
			internal string _Conta;
			internal int? _IDContribuinte;
			internal string _Contribuinte;
			internal string _OrigemDescricao;
			internal int? _IDReuniao;
			internal string _Reuniao;
			internal int? _IDCampanha;
			internal string _Campanha;
			internal decimal _ValorRecebido;
			internal bool _Realizado;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructEntrada EditData;
		private StructEntrada BackupData;
		private bool inTxn = false;

		public objContribuicao(long? IDContribuicao) : base()
		{
			EditData = new StructEntrada()
			{
				_IDContribuicao = IDContribuicao,
				_ContribuicaoData = DateTime.Today,
				_IDEntradaForma = 1,
				_IDContribuicaoTipo = 1,
				_ValorBruto = 0,
				_ValorRecebido = 0,
				_Realizado = false,
			};

			EntradaForma = "Dinheiro";
			ContribuicaoTipo = "Ofertório Culto";
		}

		// IEDITABLE OBJECT IMPLEMENTATION
		//-------------------------------------------------------------------------------------------------
		public void BeginEdit()
		{
			if (!inTxn)
			{
				BackupData = EditData;
				inTxn = true;
			}
		}

		public void CancelEdit()
		{
			if (inTxn)
			{
				EditData = BackupData;
				inTxn = false;
			}
		}

		public void EndEdit()
		{
			if (inTxn)
			{
				BackupData = new StructEntrada();
				inTxn = false;
			}
		}

		// PROPERTY CHANGED
		//------------------------------------------------------------------------------------------------------------
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public override string ToString()
		{
			return EditData._IDContribuicao?.ToString("D4");
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public long? IDContribuicao
		{
			get => EditData._IDContribuicao;
			set => EditData._IDContribuicao = value;
		}

		// Property ContribuicaoData
		//---------------------------------------------------------------
		public DateTime ContribuicaoData
		{
			get => EditData._ContribuicaoData;
			set
			{
				if (value != EditData._ContribuicaoData)
				{
					EditData._ContribuicaoData = value;
					NotifyPropertyChanged("ContribuicaoData");
				}
			}
		}

		public int EntradaDia
		{
			get => ContribuicaoData.Day;
			set
			{
				try
				{
					// format new Date
					string testDate = $"{value}/{ContribuicaoData.Month}/{ContribuicaoData.Year}";

					// check new date
					if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
					{
						ContribuicaoData = newDate;
					}
					else
					{
						throw new AttributeException($"Data inválida:\n" +
							$"{value.ToString("D2") } / { ContribuicaoData.Month.ToString("D2") } / {ContribuicaoData.Year.ToString("D4")}\n" +
							$"Favor verificar o dia, mês e ano e inserir uma data válida.");
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}

			}
		}

		public int EntradaMes
		{
			get => ContribuicaoData.Month;
			set
			{
				// format new Date
				string testDate = $"{ContribuicaoData.Day}/{value}/{ContribuicaoData.Year}";

				// check new date
				if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
				{
					ContribuicaoData = newDate;
				}
				else
				{
					throw new AttributeException($"Data inválida:\n" +
						$"{ContribuicaoData.Day.ToString("D2") } / { value.ToString("D2") } / {ContribuicaoData.Year.ToString("D4")}\n" +
						$"Favor verificar o dia, mês e ano e inserir uma data válida.");
				}
			}
		}
		public int EntradaAno
		{
			get => ContribuicaoData.Year;
			set
			{
				// format new Date
				string testDate = $"{ContribuicaoData.Day}/{ContribuicaoData.Month}/{value}";

				// check new date
				if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
				{
					ContribuicaoData = newDate;
				}
				else
				{
					throw new AttributeException($"Data inválida:\n" +
						$"{ ContribuicaoData.Day.ToString("D2") } / { ContribuicaoData.Month.ToString("D2") } / { value.ToString("D4") }\n" +
						$"Favor verificar o dia, mês e ano e inserir uma data válida.");
				}
			}
		}

		// Property IDEntradaForma
		//---------------------------------------------------------------
		public byte IDEntradaForma
		{
			get => EditData._IDEntradaForma;
			set
			{
				if (value != EditData._IDEntradaForma)
				{
					EditData._IDEntradaForma = value;
					NotifyPropertyChanged("IDEntradaForma");
				}
			}
		}

		// Property EntradaForma
		//---------------------------------------------------------------
		public string EntradaForma
		{
			get => EditData._EntradaForma;
			set => EditData._EntradaForma = value;
		}

		// Property ValorBruto
		//---------------------------------------------------------------
		public decimal ValorBruto
		{
			get => EditData._ValorBruto;
			set
			{
				if (value != EditData._ValorBruto)
				{
					EditData._ValorBruto = value;
					NotifyPropertyChanged("ValorBruto");
				}
			}
		}

		// Property IDContribuicaoTipo
		//---------------------------------------------------------------
		public byte IDContribuicaoTipo
		{
			get => EditData._IDContribuicaoTipo;
			set
			{
				if (value != EditData._IDContribuicaoTipo)
				{
					EditData._IDContribuicaoTipo = value;
					NotifyPropertyChanged("IDContribuicaoTipo");
				}
			}
		}

		// Property ContribuicaoTipo
		//---------------------------------------------------------------
		public string ContribuicaoTipo
		{
			get => EditData._ContribuicaoTipo;
			set => EditData._ContribuicaoTipo = value;
		}

		// Property IDSetor
		//---------------------------------------------------------------
		public int? IDSetor
		{
			get => EditData._IDSetor;
			set
			{
				if (value != EditData._IDSetor)
				{
					EditData._IDSetor = value;
					NotifyPropertyChanged("IDSetor");
				}
			}
		}

		// Property Setor
		//---------------------------------------------------------------
		public string Setor
		{
			get => EditData._Setor;
			set => EditData._Setor = value;
		}

		// Property IDConta
		//---------------------------------------------------------------
		public int IDConta
		{
			get => EditData._IDConta;
			set
			{
				if (value != EditData._IDConta)
				{
					EditData._IDConta = value;
					NotifyPropertyChanged("IDConta");
				}
			}
		}

		// Property Conta
		//---------------------------------------------------------------
		public string Conta
		{
			get => EditData._Conta;
			set => EditData._Conta = value;
		}

		// Property IDContribuinte
		//---------------------------------------------------------------
		public int? IDContribuinte
		{
			get => EditData._IDContribuinte;
			set
			{
				if (value != EditData._IDContribuinte)
				{
					EditData._IDContribuinte = value;
					NotifyPropertyChanged("IDContribuinte");
				}
			}
		}

		// Property Contribuinte
		//---------------------------------------------------------------
		public string Contribuinte
		{
			get => EditData._Contribuinte;
			set => EditData._Contribuinte = value;
		}

		// Property OrigemDescricao
		//---------------------------------------------------------------
		public string OrigemDescricao
		{
			get => EditData._OrigemDescricao;
			set
			{
				if (value != EditData._OrigemDescricao)
				{
					EditData._OrigemDescricao = value;
					NotifyPropertyChanged("OrigemDescricao");
				}
			}
		}

		// Property IDReuniao
		//---------------------------------------------------------------
		public int? IDReuniao
		{
			get => EditData._IDReuniao;
			set
			{
				if (value != EditData._IDReuniao)
				{
					EditData._IDReuniao = value;
					NotifyPropertyChanged("IDReuniao");
				}
			}
		}

		// Property Reuniao
		//---------------------------------------------------------------
		public string Reuniao
		{
			get
			{
				if (string.IsNullOrEmpty(EditData._Reuniao))
				{
					return "Não Informada";
				}
				else
				{
					return EditData._Reuniao;
				}
			}
			set => EditData._Reuniao = value;
		}

		// Property IDCampanha
		//---------------------------------------------------------------
		public int? IDCampanha
		{
			get => EditData._IDCampanha;
			set
			{
				if (value != EditData._IDCampanha)
				{
					EditData._IDCampanha = value;
					NotifyPropertyChanged("IDCampanha");
				}
			}
		}

		// Property Campanha
		//---------------------------------------------------------------
		public string Campanha
		{
			get => EditData._Campanha;
			set => EditData._Campanha = value;
		}

		// Property ValorRecebido
		//---------------------------------------------------------------
		public decimal ValorRecebido
		{
			get => EditData._ValorRecebido;
			set
			{
				if (value != EditData._ValorRecebido)
				{
					EditData._ValorRecebido = value;
					NotifyPropertyChanged("ValorRecebido");
				}
			}
		}

		// Property Realizado
		//---------------------------------------------------------------
		public bool Realizado
		{
			get => EditData._Realizado;
			set
			{
				if (value != EditData._Realizado)
				{
					EditData._Realizado = value;
					NotifyPropertyChanged("Realizado");
				}
			}
		}
	}

	//=================================================================================================
	// CONTRIBUICAO CARTAO
	//=================================================================================================
	public class objContribuicaoCartao : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructEntrada
		{
			internal long? _IDContribuicao;
			internal byte _CartaoTipo;
			internal int _IDCartaoOperadora;
			internal string _CartaoOperadora;
			internal int _IDContaProvisoria;
			internal string _ContaProvisoria;
			internal int _IDCartaoBandeira;
			internal string _CartaoBandeira;
			internal byte _Parcelas;
			internal decimal _TaxaAplicada;
			internal byte _Prazo;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructEntrada EditData;
		private StructEntrada BackupData;
		private bool inTxn = false;

		public objContribuicaoCartao(long? IDContribuicao) : base()
		{
			EditData = new StructEntrada()
			{
				_IDContribuicao = IDContribuicao,
				_TaxaAplicada = 0,
				_Parcelas = 1,
			};
		}

		// IEDITABLE OBJECT IMPLEMENTATION
		//-------------------------------------------------------------------------------------------------
		public void BeginEdit()
		{
			if (!inTxn)
			{
				BackupData = EditData;
				inTxn = true;
			}
		}

		public void CancelEdit()
		{
			if (inTxn)
			{
				EditData = BackupData;
				inTxn = false;
			}
		}

		public void EndEdit()
		{
			if (inTxn)
			{
				BackupData = new StructEntrada();
				inTxn = false;
			}
		}

		// PROPERTY CHANGED
		//------------------------------------------------------------------------------------------------------------
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public override string ToString()
		{
			return EditData._IDContribuicao?.ToString("D4");
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public long? IDContribuicao
		{
			get => EditData._IDContribuicao;
			set => EditData._IDContribuicao = value;
		}

		// Property CartaoTipo
		//---------------------------------------------------------------
		public byte CartaoTipo
		{
			get => EditData._CartaoTipo;
			set
			{
				if (value != EditData._CartaoTipo)
				{
					EditData._CartaoTipo = value;
					NotifyPropertyChanged("CartaoTipo");
				}
			}
		}

		public string CartaoTipoDescricao { get; set; }

		// Property IDCartaoOperadora
		//---------------------------------------------------------------
		public int IDCartaoOperadora
		{
			get => EditData._IDCartaoOperadora;
			set
			{
				if (value != EditData._IDCartaoOperadora)
				{
					EditData._IDCartaoOperadora = value;
					NotifyPropertyChanged("IDCartaoOperadora");
				}
			}
		}

		// Property CartaoOperadora
		//---------------------------------------------------------------
		public string CartaoOperadora
		{
			get => EditData._CartaoOperadora;
			set => EditData._CartaoOperadora = value;
		}

		// Property IDContaProvisoria
		//---------------------------------------------------------------
		public int IDContaProvisoria
		{
			get => EditData._IDContaProvisoria;
			set
			{
				if (value != EditData._IDContaProvisoria)
				{
					EditData._IDContaProvisoria = value;
					NotifyPropertyChanged("IDContaProvisoria");
				}
			}
		}

		// Property ContaProvisoria
		//---------------------------------------------------------------
		public string ContaProvisoria
		{
			get => EditData._ContaProvisoria;
			set => EditData._ContaProvisoria = value;
		}

		// Property IDCartaoBandeira
		//---------------------------------------------------------------
		public int IDCartaoBandeira
		{
			get => EditData._IDCartaoBandeira;
			set
			{
				if (value != EditData._IDCartaoBandeira)
				{
					EditData._IDCartaoBandeira = value;
					NotifyPropertyChanged("IDCartaoBandeira");
				}
			}
		}

		// Property CartaoBandeira
		//---------------------------------------------------------------
		public string CartaoBandeira
		{
			get => EditData._CartaoBandeira;
			set => EditData._CartaoBandeira = value;
		}

		// Property Parcelas
		//---------------------------------------------------------------
		public byte Parcelas
		{
			get => EditData._Parcelas;
			set
			{
				if (value != EditData._Parcelas)
				{
					EditData._Parcelas = value;
					NotifyPropertyChanged("Parcelas");
				}
			}
		}

		// Property TaxaAplicada
		//---------------------------------------------------------------
		public decimal TaxaAplicada
		{
			get => EditData._TaxaAplicada;
			set
			{
				if (value != EditData._TaxaAplicada)
				{
					EditData._TaxaAplicada = value;
					NotifyPropertyChanged("TaxaAplicada");
				}
			}
		}

		// Property Prazo
		//---------------------------------------------------------------
		public byte Prazo
		{
			get => EditData._Prazo;
			set
			{
				if (value != EditData._Prazo)
				{
					EditData._Prazo = value;
					NotifyPropertyChanged("Prazo");
				}
			}
		}
	}

	//=================================================================================================
	// CONTRIBUICAO CHEQUE
	//=================================================================================================
	public class objContribuicaoCheque : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructEntrada
		{
			internal long? _IDContribuicao;
			internal string _ChequeNumero;
			internal int _IDBanco;
			internal string _Banco;
			internal DateTime _DepositoData;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructEntrada EditData;
		private StructEntrada BackupData;
		private bool inTxn = false;

		public objContribuicaoCheque(long? IDContribuicao) : base()
		{
			EditData = new StructEntrada()
			{
				_IDContribuicao = IDContribuicao,
				_DepositoData = DateTime.Today,
			};
		}

		// IEDITABLE OBJECT IMPLEMENTATION
		//-------------------------------------------------------------------------------------------------
		public void BeginEdit()
		{
			if (!inTxn)
			{
				BackupData = EditData;
				inTxn = true;
			}
		}

		public void CancelEdit()
		{
			if (inTxn)
			{
				EditData = BackupData;
				inTxn = false;
			}
		}

		public void EndEdit()
		{
			if (inTxn)
			{
				BackupData = new StructEntrada();
				inTxn = false;
			}
		}

		// PROPERTY CHANGED
		//------------------------------------------------------------------------------------------------------------
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public override string ToString()
		{
			return EditData._IDContribuicao?.ToString("D4");
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public long? IDContribuicao
		{
			get => EditData._IDContribuicao;
			set => EditData._IDContribuicao = value;
		}

		// Property ChequeNumero
		//---------------------------------------------------------------
		public string ChequeNumero
		{
			get => EditData._ChequeNumero;
			set
			{
				if (value != EditData._ChequeNumero)
				{
					EditData._ChequeNumero = value;
					NotifyPropertyChanged("ChequeNumero");
				}
			}
		}

		// Property IDBanco
		//---------------------------------------------------------------
		public int IDBanco
		{
			get => EditData._IDBanco;
			set
			{
				if (value != EditData._IDBanco)
				{
					EditData._IDBanco = value;
					NotifyPropertyChanged("IDBanco");
				}
			}
		}

		// Property Banco
		//---------------------------------------------------------------
		public string Banco
		{
			get => EditData._Banco;
			set => EditData._Banco = value;
		}

		// Property DepositoData
		//---------------------------------------------------------------
		public DateTime DepositoData
		{
			get => EditData._DepositoData;
			set
			{
				if (value != EditData._DepositoData)
				{
					EditData._DepositoData = value;
					NotifyPropertyChanged("DepositoData");
				}
			}
		}

	}

	//=================================================================================================
	// ENTRADA TIPO
	//=================================================================================================
	public class objContribuicaoTipo : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructEntrada
		{
			internal byte? _IDContribuicaoTipo;
			internal string _ContribuicaoTipo;
			internal bool _ComOrigem;
			internal bool _ComAtividade;
			internal bool _ComCampanha;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructEntrada EditData;
		private StructEntrada BackupData;
		private bool inTxn = false;

		public objContribuicaoTipo(byte? IDContribuicaoTipo) : base()
		{
			EditData = new StructEntrada()
			{
				_IDContribuicaoTipo = IDContribuicaoTipo,
				_ContribuicaoTipo = "",
				_ComOrigem = false,
				_ComAtividade = false,
				_ComCampanha = false
			};
		}

		// IEDITABLE OBJECT IMPLEMENTATION
		//-------------------------------------------------------------------------------------------------
		public void BeginEdit()
		{
			if (!inTxn)
			{
				BackupData = EditData;
				inTxn = true;
			}
		}

		public void CancelEdit()
		{
			if (inTxn)
			{
				EditData = BackupData;
				inTxn = false;
			}
		}

		public void EndEdit()
		{
			if (inTxn)
			{
				BackupData = new StructEntrada();
				inTxn = false;
			}
		}

		// PROPERTY CHANGED
		//------------------------------------------------------------------------------------------------------------
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public override string ToString()
		{
			return EditData._ContribuicaoTipo;
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public byte? IDContribuicaoTipo
		{
			get => EditData._IDContribuicaoTipo;
			set => EditData._IDContribuicaoTipo = value;
		}

		// Property ContribuicaoTipo
		//---------------------------------------------------------------
		public string ContribuicaoTipo
		{
			get => EditData._ContribuicaoTipo;
			set
			{
				if (value != EditData._ContribuicaoTipo)
				{
					EditData._ContribuicaoTipo = value;
					NotifyPropertyChanged("ContribuicaoTipo");
				}
			}
		}

		// Property ComOrigem
		//---------------------------------------------------------------
		public bool ComOrigem
		{
			get => EditData._ComOrigem;
			set
			{
				if (value != EditData._ComOrigem)
				{
					EditData._ComOrigem = value;
					NotifyPropertyChanged("ComOrigem");
				}
			}
		}

		// Property ComAtividade
		//---------------------------------------------------------------
		public bool ComAtividade
		{
			get => EditData._ComAtividade;
			set
			{
				if (value != EditData._ComAtividade)
				{
					EditData._ComAtividade = value;
					NotifyPropertyChanged("ComAtividade");
				}
			}
		}

		// Property ComCampanha
		//---------------------------------------------------------------
		public bool ComCampanha
		{
			get => EditData._ComCampanha;
			set
			{
				if (value != EditData._ComCampanha)
				{
					EditData._ComCampanha = value;
					NotifyPropertyChanged("ComCampanha");
				}
			}
		}
	}
}
