using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	//=================================================================================================
	// ENTRADA
	//=================================================================================================
	public class objTransferencia : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructTransferencia
		{
			internal long? _IDTransferencia;
			internal long _IDOrigem;
			internal int _Origem;
			internal DateTime _TransferenciaData;
			internal decimal _TransferenciaValor;
			internal int _IDSetor;
			internal string _Setor;
			internal int _IDConta;
			internal string _Conta;
			internal bool _Consolidado;
			internal string _Observacao;
			internal long? _IDCaixa;
		}

		/* ORIGEM
		*	1: tblTransfConta | IDTransfConta
		*	2: tblTransfSetor | IDTransfSetor
		*	3: tblAReceber    | IDAReceber 
		*/

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructTransferencia EditData;
		private StructTransferencia BackupData;
		private bool inTxn = false;

		public objTransferencia(long? IDTransferencia) : base()
		{
			EditData = new StructTransferencia()
			{
				_IDTransferencia = IDTransferencia,
				_TransferenciaData = DateTime.Today,
				_TransferenciaValor = 0,
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
				BackupData = new StructTransferencia();
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
			return EditData._IDTransferencia?.ToString("D4");
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public long? IDTransferencia
		{
			get => EditData._IDTransferencia;
			set => EditData._IDTransferencia = value;
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

		// Property TransferenciaData
		//---------------------------------------------------------------
		public DateTime TransferenciaData
		{
			get => EditData._TransferenciaData;
			set
			{
				if (value != EditData._TransferenciaData)
				{
					EditData._TransferenciaData = value;
					NotifyPropertyChanged("TransferenciaData");
				}
			}
		}

		public int TransferenciaDia
		{
			get => TransferenciaData.Day;
			set
			{
				try
				{
					// format new Date
					string testDate = $"{value}/{TransferenciaData.Month}/{TransferenciaData.Year}";

					// check new date
					if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
					{
						TransferenciaData = newDate;
					}
					else
					{
						throw new AttributeException($"Data inválida:\n" +
							$"{value.ToString("D2") } / { TransferenciaData.Month.ToString("D2") } / {TransferenciaData.Year.ToString("D4")}\n" +
							$"Favor verificar o dia, mês e ano e inserir uma data válida.");
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}

			}
		}

		public int TransferenciaMes
		{
			get => TransferenciaData.Month;
			set
			{
				// format new Date
				string testDate = $"{TransferenciaData.Day}/{value}/{TransferenciaData.Year}";

				// check new date
				if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
				{
					TransferenciaData = newDate;
				}
				else
				{
					throw new AttributeException($"Data inválida:\n" +
						$"{TransferenciaData.Day.ToString("D2") } / { value.ToString("D2") } / {TransferenciaData.Year.ToString("D4")}\n" +
						$"Favor verificar o dia, mês e ano e inserir uma data válida.");
				}
			}
		}
		public int TransferenciaAno
		{
			get => TransferenciaData.Year;
			set
			{
				// format new Date
				string testDate = $"{TransferenciaData.Day}/{TransferenciaData.Month}/{value}";

				// check new date
				if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
				{
					TransferenciaData = newDate;
				}
				else
				{
					throw new AttributeException($"Data inválida:\n" +
						$"{ TransferenciaData.Day.ToString("D2") } / { TransferenciaData.Month.ToString("D2") } / { value.ToString("D4") }\n" +
						$"Favor verificar o dia, mês e ano e inserir uma data válida.");
				}
			}
		}

		// Property TransferenciaValor
		//---------------------------------------------------------------
		public decimal TransferenciaValor
		{
			get => EditData._TransferenciaValor;
			set
			{
				if (value != EditData._TransferenciaValor)
				{
					EditData._TransferenciaValor = value;
					NotifyPropertyChanged("TransferenciaValor");
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

		// Property Consolidado
		//---------------------------------------------------------------
		public bool Consolidado
		{
			get => EditData._Consolidado;
			set => EditData._Consolidado = value;
		}

		// Property Observacao
		//---------------------------------------------------------------
		public string Observacao
		{
			get => EditData._Observacao;
			set => EditData._Observacao = value;
		}
	}
}
