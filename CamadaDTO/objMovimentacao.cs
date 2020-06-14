using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	//=================================================================================================
	// CLASS MOVIMENTACAO
	//=================================================================================================
	public class objMovimentacao : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructMov
		{
			internal long _MovID;
			internal string _MovOrigem;
			internal string _MovTabela;
			internal int _Origem;
			internal int _IDConta;
			internal string _Conta;
			internal int _IDSetor;
			internal string _Setor;
			internal DateTime _MovData;
			internal decimal _MovValor;
			internal decimal _MovValorReal;
			internal long? _IDCaixa;
			internal string _OrigemTabela;
			internal long _IDOrigem;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructMov EditData;
		private StructMov BackupData;
		private bool inTxn = false;

		public objMovimentacao(long MovID) : base()
		{
			EditData = new StructMov()
			{
				_MovID = MovID,
				_MovData = DateTime.Today,
				_MovValor = 0,
				_IDCaixa = null,
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
				BackupData = new StructMov();
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
			return EditData._MovID.ToString("D4");
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public long MovID
		{
			get => EditData._MovID;
			set => EditData._MovID = value;
		}

		// Property MovOrigem
		//---------------------------------------------------------------
		public string MovOrigem
		{
			get => EditData._MovOrigem;
			set => EditData._MovOrigem = value;
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

		// Property OrigemTabela
		//---------------------------------------------------------------
		public string OrigemTabela
		{
			get => EditData._OrigemTabela;
			set => EditData._OrigemTabela = value;
		}

		// Property MovTabela
		//---------------------------------------------------------------
		public string MovTabela
		{
			get => EditData._MovTabela;
			set => EditData._MovTabela = value;
		}

		// Property MovData
		//---------------------------------------------------------------
		public DateTime MovData
		{
			get => EditData._MovData;
			set
			{
				if (value != EditData._MovData)
				{
					EditData._MovData = value;
					NotifyPropertyChanged("MovData");
				}
			}
		}

		public int MovDia
		{
			get => MovData.Day;
			set
			{
				try
				{
					// format new Date
					string testDate = $"{value}/{MovData.Month}/{MovData.Year}";

					// check new date
					if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
					{
						MovData = newDate;
					}
					else
					{
						throw new AttributeException($"Data inválida:\n" +
							$"{value.ToString("D2") } / { MovData.Month.ToString("D2") } / {MovData.Year.ToString("D4")}\n" +
							$"Favor verificar o dia, mês e ano e inserir uma data válida.");
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}

			}
		}

		public int MovMes
		{
			get => MovData.Month;
			set
			{
				// format new Date
				string testDate = $"{MovData.Day}/{value}/{MovData.Year}";

				// check new date
				if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
				{
					MovData = newDate;
				}
				else
				{
					throw new AttributeException($"Data inválida:\n" +
						$"{MovData.Day.ToString("D2") } / { value.ToString("D2") } / {MovData.Year.ToString("D4")}\n" +
						$"Favor verificar o dia, mês e ano e inserir uma data válida.");
				}
			}
		}
		public int MovAno
		{
			get => MovData.Year;
			set
			{
				// format new Date
				string testDate = $"{MovData.Day}/{MovData.Month}/{value}";

				// check new date
				if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
				{
					MovData = newDate;
				}
				else
				{
					throw new AttributeException($"Data inválida:\n" +
						$"{ MovData.Day.ToString("D2") } / { MovData.Month.ToString("D2") } / { value.ToString("D4") }\n" +
						$"Favor verificar o dia, mês e ano e inserir uma data válida.");
				}
			}
		}

		// Property MovValor
		//---------------------------------------------------------------
		public decimal MovValor
		{
			get => EditData._MovValor;
			set
			{
				if (value != EditData._MovValor)
				{
					EditData._MovValor = value;
					NotifyPropertyChanged("MovValor");
				}
			}
		}

		// Property MovValorReal
		//---------------------------------------------------------------
		public decimal ValorReal
		{
			get => EditData._MovValorReal;
			set => EditData._MovValorReal = value;
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

		// Property IDCaixa
		//---------------------------------------------------------------
		public long? IDCaixa
		{
			get => EditData._IDCaixa;
			set
			{
				if (value != EditData._IDCaixa)
				{
					EditData._IDCaixa = value;
					NotifyPropertyChanged("IDCaixa");
				}
			}
		}
	}

}
