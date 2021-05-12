using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	//=================================================================================================
	// Entrada
	//=================================================================================================
	public class objEntrada : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructEntrada
		{
			internal long? _IDEntrada;
			internal DateTime _EntradaData;
			internal decimal _EntradaValor;
			internal objEntradaTipo _objEntradaTipo;
			internal int? _IDSetor;
			internal string _Setor;
			internal int _IDConta;
			internal string _Conta;
			internal objEntradaOrigem _objEntradaOrigem;
			internal string _EntradaDescricao;
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
				_objEntradaTipo = new objEntradaTipo(),
				_EntradaValor = 0,
				_objEntradaOrigem = new objEntradaOrigem()
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

		// Property EntradaTipo
		//---------------------------------------------------------------
		public objEntradaTipo EntradaTipo
		{
			get => EditData._objEntradaTipo;
			set
			{
				if (value != EditData._objEntradaTipo)
				{
					EditData._objEntradaTipo = value;
					NotifyPropertyChanged("EntradaTipo");
				}
			}
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

		// Property EntradaOrigem
		//---------------------------------------------------------------
		public objEntradaOrigem EntradaOrigem
		{
			get => EditData._objEntradaOrigem;
			set
			{
				if (value != EditData._objEntradaOrigem)
				{
					EditData._objEntradaOrigem = value;
					NotifyPropertyChanged("EntradaOrigem");
				}
			}
		}

		// Property EntradaDescricao
		//---------------------------------------------------------------
		public string EntradaDescricao
		{
			get => EditData._EntradaDescricao;
			set
			{
				if (value != EditData._EntradaDescricao)
				{
					EditData._EntradaDescricao = value;
					NotifyPropertyChanged("EntradaDescricao");
				}
			}
		}
	}

	//=================================================================================================
	// ENTRADA ORIGEM
	//=================================================================================================
	public class objEntradaOrigem
	{
		public int IDEntradaOrigem { get; set; }
		public string OrigemDescricao { get; set; }
		public string CNP { get; set; }
		public bool Ativo { get; set; }
	}

	//=================================================================================================
	// ENTRADA TIPO
	//=================================================================================================
	public class objEntradaTipo
	{
		public int IDEntradaTipo { get; set; }
		public string EntradaTipo { get; set; }
		public bool Ativo { get; set; }

		public objEntradaTipo()
		{
			IDEntradaTipo = 1;
			EntradaTipo = "Investimento";
			Ativo = true;
		}
	}
}
