using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	//=================================================================================================
	// ENTRADA
	//=================================================================================================
	public class objEntrada : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructEntrada
		{
			internal int? _IDEntrada;
			internal DateTime _EntradaData;
			internal DateTime _CompensacaoData;
			internal byte _IDEntradaForma; // dinheiro, cheque, cartao
			internal decimal _ValorBruto;
			internal decimal _ValorLiquido;
			internal byte _IDEntradaTipo;
			internal int _IDSetor;
			internal int _IDConta;
			internal int? _IDContribuinte;
			internal string _OrigemDescricao;
			internal int? _IDReuniao;
			internal int? _IDCampanha;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructEntrada EditData;
		private StructEntrada BackupData;
		private bool inTxn = false;

		public objEntrada(int? IDEntrada) : base()
		{
			EditData = new StructEntrada()
			{
				_IDEntrada = IDEntrada,
				_EntradaData = DateTime.Today,
				_CompensacaoData = DateTime.Today,
				_IDEntradaForma = 1,
				_IDEntradaTipo = 1,
				_ValorBruto = 0,
				_ValorLiquido = 0
			};

			EntradaForma = "Dinheiro";
			EntradaTipo = "Ofertório Culto";
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
			return EditData._IDEntrada?.ToString("D4");
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public int? IDEntrada
		{
			get => EditData._IDEntrada;
			set => EditData._IDEntrada = value;
		}

		// Property EntradaData
		//---------------------------------------------------------------
		public DateTime EntradaData
		{
			get => EditData._EntradaData;
			set
			{
				if (value != EditData._EntradaData)
				{
					EditData._EntradaData = value;
					NotifyPropertyChanged("EntradaData");
				}
			}
		}

		public int EntradaDia
		{
			get => EntradaData.Day;
			set
			{
				try
				{
					// format new Date
					string testDate = $"{value}/{EntradaData.Month}/{EntradaData.Year}";

					// check new date
					if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
					{
						EntradaData = newDate;
					}
					else
					{
						throw new Exception("Data inválida...");
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
			get => EntradaData.Month;
			set
			{
				// format new Date
				string testDate = $"{EntradaData.Day}/{value}/{EntradaData.Year}";

				// check new date
				if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
				{
					EntradaData = newDate;
				}
				else
				{
					throw new Exception("Data inválida...");
				}
			}
		}
		public int EntradaAno
		{
			get => EntradaData.Year;
			set
			{
				// format new Date
				string testDate = $"{EntradaData.Day}/{EntradaData.Month}/{value}";

				// check new date
				if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
				{
					EntradaData = newDate;
				}
				else
				{
					throw new AppException("Data inválida...");
				}
			}
		}

		// Property CompensacaoData
		//---------------------------------------------------------------
		public DateTime CompensacaoData
		{
			get => EditData._CompensacaoData;
			set
			{
				if (value != EditData._CompensacaoData)
				{
					EditData._CompensacaoData = value;
					NotifyPropertyChanged("CompensacaoData");
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
		public string EntradaForma { get; set; }

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

		// Property ValorLiquido
		//---------------------------------------------------------------
		public decimal ValorLiquido
		{
			get => EditData._ValorLiquido;
			set
			{
				if (value != EditData._ValorLiquido)
				{
					EditData._ValorLiquido = value;
					NotifyPropertyChanged("ValorLiquido");
				}
			}
		}

		// Property IDEntradaTipo
		//---------------------------------------------------------------
		public byte IDEntradaTipo
		{
			get => EditData._IDEntradaTipo;
			set
			{
				if (value != EditData._IDEntradaTipo)
				{
					EditData._IDEntradaTipo = value;
					NotifyPropertyChanged("IDEntradaTipo");
				}
			}
		}

		public string EntradaTipo { get; set; }

		// Property IDSetor
		//---------------------------------------------------------------
		public int IDSetor
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

		public string Setor { get; set; }

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

		public string Conta { get; set; }

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

		public string Contribuinte { get; set; }

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

		public string Reuniao { get; set; }

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

		public string Campanha { get; set; }

	}

	//=================================================================================================
	// ENTRADA FORMA
	//=================================================================================================
	public class objEntradaForma : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructEntrada
		{
			internal byte? _IDEntradaForma;
			internal string _EntradaForma;
			internal bool _Ativa;
			internal byte _CompensacaoDias;
			internal decimal _TaxaComissao;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructEntrada EditData;
		private StructEntrada BackupData;
		private bool inTxn = false;

		public objEntradaForma(byte? IDEntradaForma) : base()
		{
			EditData = new StructEntrada()
			{
				_IDEntradaForma = IDEntradaForma,
				_EntradaForma = "",
				_Ativa = true,
				_CompensacaoDias = 0,
				_TaxaComissao = 0
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
			return EditData._EntradaForma;
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public byte? IDEntradaForma
		{
			get => EditData._IDEntradaForma;
			set => EditData._IDEntradaForma = value;
		}

		// Property EntradaForma
		//---------------------------------------------------------------
		public string EntradaForma
		{
			get => EditData._EntradaForma;
			set
			{
				if (value != EditData._EntradaForma)
				{
					EditData._EntradaForma = value;
					NotifyPropertyChanged("EntradaForma");
				}
			}
		}

		// Property Ativa
		//---------------------------------------------------------------
		public bool Ativa
		{
			get => EditData._Ativa;
			set
			{
				if (value != EditData._Ativa)
				{
					EditData._Ativa = value;
					NotifyPropertyChanged("Ativa");
				}
			}
		}

		// Property CompensacaoDias
		//---------------------------------------------------------------
		public byte CompensacaoDias
		{
			get => EditData._CompensacaoDias;
			set
			{
				if (value != EditData._CompensacaoDias)
				{
					EditData._CompensacaoDias = value;
					NotifyPropertyChanged("CompensacaoDias");
				}
			}
		}

		// Property TaxaComissao
		//---------------------------------------------------------------
		public decimal TaxaComissao
		{
			get => EditData._TaxaComissao;
			set
			{
				if (value != EditData._TaxaComissao)
				{
					EditData._TaxaComissao = value;
					NotifyPropertyChanged("TaxaComissao");
				}
			}
		}
	}

	//=================================================================================================
	// ENTRADA TIPO
	//=================================================================================================
	public class objEntradaTipo : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructEntrada
		{
			internal byte? _IDEntradaTipo;
			internal string _EntradaTipo;
			internal bool _ComOrigem;
			internal bool _ComAtividade;
			internal bool _ComCampanha;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructEntrada EditData;
		private StructEntrada BackupData;
		private bool inTxn = false;

		public objEntradaTipo(byte? IDEntradaTipo) : base()
		{
			EditData = new StructEntrada()
			{
				_IDEntradaTipo = IDEntradaTipo,
				_EntradaTipo = "",
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
			return EditData._EntradaTipo;
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public byte? IDEntradaTipo
		{
			get => EditData._IDEntradaTipo;
			set => EditData._IDEntradaTipo = value;
		}

		// Property EntradaTipo
		//---------------------------------------------------------------
		public string EntradaTipo
		{
			get => EditData._EntradaTipo;
			set
			{
				if (value != EditData._EntradaTipo)
				{
					EditData._EntradaTipo = value;
					NotifyPropertyChanged("EntradaTipo");
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
