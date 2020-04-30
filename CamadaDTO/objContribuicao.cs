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
			internal int? _IDContribuicao;
			internal DateTime _ContribuicaoData;
			internal byte _IDEntradaForma; // dinheiro, cheque, cartao
			internal decimal _ValorBruto;
			internal byte _IDContribuicaoTipo;
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

		public objContribuicao(int? IDContribuicao) : base()
		{
			EditData = new StructEntrada()
			{
				_IDContribuicao = IDContribuicao,
				_ContribuicaoData = DateTime.Today,
				_IDEntradaForma = 1,
				_IDContribuicaoTipo = 1,
				_ValorBruto = 0,
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
		public int? IDContribuicao
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

		public string ContribuicaoTipo { get; set; }

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
