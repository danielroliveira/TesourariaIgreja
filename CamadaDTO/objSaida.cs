using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	//=================================================================================================
	// SAIDA
	//=================================================================================================
	public class objSaida : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructSaida
		{
			internal long? _IDSaida;
			internal long _IDOrigem;
			internal int _Origem;
			internal DateTime _SaidaData;
			internal decimal _SaidaValor;
			internal decimal? _AcrescimoValor;
			internal int _IDSetor;
			internal string _Setor;
			internal int _IDConta;
			internal string _Conta;
			internal bool _Imagem;
			internal string _Observacao;
			internal long? _IDCaixa;
		}

		/* --- ORIGEM
		//-------------------------------------------------------------------------------------------------
			1: tblAPagar   | IDAPagar
			2: tblAReceber | IDAReceber : comissao do cartao gera saida
		*/

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructSaida EditData;
		private StructSaida BackupData;
		private bool inTxn = false;

		public objSaida(long? IDSaida) : base()
		{
			EditData = new StructSaida()
			{
				_IDSaida = IDSaida,
				_SaidaData = DateTime.Today,
				_SaidaValor = 0,
				_Imagem = false,
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
				BackupData = new StructSaida();
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
			return EditData._IDSaida?.ToString("D4");
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public long? IDSaida
		{
			get => EditData._IDSaida;
			set => EditData._IDSaida = value;
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

		// Property SaidaData
		//---------------------------------------------------------------
		public DateTime SaidaData
		{
			get => EditData._SaidaData;
			set
			{
				if (value != EditData._SaidaData)
				{
					EditData._SaidaData = value;
					NotifyPropertyChanged("SaidaData");
				}
			}
		}

		public int SaidaDia
		{
			get => SaidaData.Day;
			set
			{
				try
				{
					// format new Date
					string testDate = $"{value}/{SaidaData.Month}/{SaidaData.Year}";

					// check new date
					if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
					{
						SaidaData = newDate;
					}
					else
					{
						throw new AttributeException($"Data inválida:\n" +
							$"{value.ToString("D2") } / { SaidaData.Month.ToString("D2") } / {SaidaData.Year.ToString("D4")}\n" +
							$"Favor verificar o dia, mês e ano e inserir uma data válida.");
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}

			}
		}

		public int SaidaMes
		{
			get => SaidaData.Month;
			set
			{
				// format new Date
				string testDate = $"{SaidaData.Day}/{value}/{SaidaData.Year}";

				// check new date
				if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
				{
					SaidaData = newDate;
				}
				else
				{
					throw new AttributeException($"Data inválida:\n" +
						$"{SaidaData.Day.ToString("D2") } / { value.ToString("D2") } / {SaidaData.Year.ToString("D4")}\n" +
						$"Favor verificar o dia, mês e ano e inserir uma data válida.");
				}
			}
		}
		public int SaidaAno
		{
			get => SaidaData.Year;
			set
			{
				// format new Date
				string testDate = $"{SaidaData.Day}/{SaidaData.Month}/{value}";

				// check new date
				if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
				{
					SaidaData = newDate;
				}
				else
				{
					throw new AttributeException($"Data inválida:\n" +
						$"{ SaidaData.Day.ToString("D2") } / { SaidaData.Month.ToString("D2") } / { value.ToString("D4") }\n" +
						$"Favor verificar o dia, mês e ano e inserir uma data válida.");
				}
			}
		}

		// Property SaidaValor
		//---------------------------------------------------------------
		public decimal SaidaValor
		{
			get => EditData._SaidaValor;
			set
			{
				if (value != EditData._SaidaValor)
				{
					EditData._SaidaValor = value;
					NotifyPropertyChanged("SaidaValor");
				}
			}
		}

		// Property AcrescimoValor
		//---------------------------------------------------------------
		public decimal? AcrescimoValor
		{
			get => EditData._AcrescimoValor;
			set
			{
				if (value != EditData._AcrescimoValor)
				{
					EditData._AcrescimoValor = value;
					NotifyPropertyChanged("AcrescimoValor");
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

		// Property Imagem
		//---------------------------------------------------------------
		public bool Imagem
		{
			get => EditData._Imagem;
			set
			{
				if (value != EditData._Imagem)
				{
					EditData._Imagem = value;
					NotifyPropertyChanged("Imagem");
				}
			}
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
