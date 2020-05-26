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
			internal long? _IDEntrada;
			internal long _IDOrigem;
			internal int _Origem;
			internal DateTime _EntradaData;
			internal decimal _EntradaValor;
			internal int _IDSetor;
			internal string _Setor;
			internal int _IDConta;
			internal string _Conta;
			internal string _Observacao;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructEntrada EditData;
		private StructEntrada BackupData;
		private bool inTxn = false;

		public objEntrada(long? IDEntrada) : base()
		{
			EditData = new StructEntrada()
			{
				_IDEntrada = IDEntrada,
				_EntradaData = DateTime.Today,
				_EntradaValor = 0,
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
			return EditData._IDEntrada?.ToString("D4");
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public long? IDEntrada
		{
			get => EditData._IDEntrada;
			set => EditData._IDEntrada = value;
		}

		// Property IDOrigem
		//---------------------------------------------------------------
		public long IDOrigem
		{
			get => EditData._IDOrigem;
			set
			{
				if (value != EditData._IDOrigem)
				{
					EditData._IDOrigem = value;
					NotifyPropertyChanged("IDOrigem");
				}
			}
		}

		// Property Origem
		//---------------------------------------------------------------
		public int Origem
		{
			get => EditData._Origem;
			set
			{
				if (value != EditData._Origem)
				{
					EditData._Origem = value;
					NotifyPropertyChanged("Origem");
				}
			}
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
						throw new AttributeException($"Data inválida:\n" +
							$"{value.ToString("D2") } / { EntradaData.Month.ToString("D2") } / {EntradaData.Year.ToString("D4")}\n" +
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
					throw new AttributeException($"Data inválida:\n" +
						$"{EntradaData.Day.ToString("D2") } / { value.ToString("D2") } / {EntradaData.Year.ToString("D4")}\n" +
						$"Favor verificar o dia, mês e ano e inserir uma data válida.");
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
					throw new AttributeException($"Data inválida:\n" +
						$"{ EntradaData.Day.ToString("D2") } / { EntradaData.Month.ToString("D2") } / { value.ToString("D4") }\n" +
						$"Favor verificar o dia, mês e ano e inserir uma data válida.");
				}
			}
		}

		// Property EntradaValor
		//---------------------------------------------------------------
		public decimal EntradaValor
		{
			get => EditData._EntradaValor;
			set
			{
				if (value != EditData._EntradaValor)
				{
					EditData._EntradaValor = value;
					NotifyPropertyChanged("EntradaValor");
				}
			}
		}

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

		// Property Observacao
		//---------------------------------------------------------------
		public string Observacao
		{
			get => EditData._Observacao;
			set
			{
				if (value != EditData._Observacao)
				{
					EditData._Observacao = value;
					NotifyPropertyChanged("Observacao");
				}
			}
		}
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
	}
}
