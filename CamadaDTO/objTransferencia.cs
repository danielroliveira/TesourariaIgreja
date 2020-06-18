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
			internal int? _IDSetor;
			internal string _Setor;
			internal int? _IDConta;
			internal string _Conta;
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

		// GET SHALLOW COPY OF OBJECT
		//------------------------------------------------------------------------------------------------------------
		public objTransferencia ShallowCopy()
		{
			return (objTransferencia)this.MemberwiseClone();
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
		public int? IDConta
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

	//=================================================================================================
	// TRANSFERENCIA CONTA
	//=================================================================================================
	public class objTransfConta
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructTransferencia
		{
			internal long? _IDTransfConta;
			internal int _IDContaEntrada;
			internal string _ContaEntrada;
			internal int _IDContaSaida;
			internal string _ContaSaida;
			internal string _Descricao;
			internal objTransferencia _transf;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructTransferencia EditData;
		private StructTransferencia BackupData;
		private bool inTxn = false;

		public objTransfConta(long? iDTransfConta)
		{
			EditData = new StructTransferencia()
			{
				_IDTransfConta = iDTransfConta,
				_ContaEntrada = "",
				_ContaSaida = "",
				_Descricao = "",
				_transf = new objTransferencia(null)
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
			return EditData._IDTransfConta?.ToString("D4");
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		// Property IDTransfConta
		//---------------------------------------------------------------
		public long? IDTransfConta
		{
			get => EditData._IDTransfConta;
			set => EditData._IDTransfConta = value;
		}

		// Property IDContaEntrada
		//---------------------------------------------------------------
		public int IDContaEntrada
		{
			get => EditData._IDContaEntrada;
			set
			{
				if (value != EditData._IDContaEntrada)
				{
					EditData._IDContaEntrada = value;
					NotifyPropertyChanged("IDContaEntrada");
				}
			}
		}

		// Property ContaEntrada
		//---------------------------------------------------------------
		public string ContaEntrada
		{
			get => EditData._ContaEntrada;
			set => EditData._ContaEntrada = value;
		}

		// Property IDContaSaida
		//---------------------------------------------------------------
		public int IDContaSaida
		{
			get => EditData._IDContaSaida;
			set
			{
				if (value != EditData._IDContaSaida)
				{
					EditData._IDContaSaida = value;
					NotifyPropertyChanged("IDContaSaida");
				}
			}
		}

		// Property ContaSaida
		//---------------------------------------------------------------
		public string ContaSaida
		{
			get => EditData._ContaSaida;
			set => EditData._ContaSaida = value;
		}

		// Property Descricao
		//---------------------------------------------------------------
		public string Descricao
		{
			get => EditData._Descricao;
			set
			{
				if (value != EditData._Descricao)
				{
					EditData._Descricao = value;
					NotifyPropertyChanged("Descricao");
				}
			}
		}

		// TRANSFERENCIA OBJECT
		public virtual objTransferencia Transferencia
		{
			get => EditData._transf;
			set => EditData._transf = value;
		}
	}

	//=================================================================================================
	// TRANSFERENCIA SETOR
	//=================================================================================================
	public class objTransfSetor
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructTransferencia
		{
			internal long? _IDTransfSetor;
			internal int _IDSetorEntrada;
			internal string _SetorEntrada;
			internal int _IDSetorSaida;
			internal string _SetorSaida;
			internal string _Descricao;
			internal objTransferencia _transf;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructTransferencia EditData;
		private StructTransferencia BackupData;
		private bool inTxn = false;

		public objTransfSetor(long? iDTransfSetor)
		{
			EditData = new StructTransferencia()
			{
				_IDTransfSetor = iDTransfSetor,
				_SetorEntrada = "",
				_SetorSaida = "",
				_Descricao = "",
				_transf = new objTransferencia(null)
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
			return EditData._IDTransfSetor?.ToString("D4");
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		// Property IDTransfSetor
		//---------------------------------------------------------------
		public long? IDTransfSetor
		{
			get => EditData._IDTransfSetor;
			set => EditData._IDTransfSetor = value;
		}

		// Property IDSetorEntrada
		//---------------------------------------------------------------
		public int IDSetorEntrada
		{
			get => EditData._IDSetorEntrada;
			set
			{
				if (value != EditData._IDSetorEntrada)
				{
					EditData._IDSetorEntrada = value;
					NotifyPropertyChanged("IDSetorEntrada");
				}
			}
		}

		// Property SetorEntrada
		//---------------------------------------------------------------
		public string SetorEntrada
		{
			get => EditData._SetorEntrada;
			set => EditData._SetorEntrada = value;
		}

		// Property IDSetorSaida
		//---------------------------------------------------------------
		public int IDSetorSaida
		{
			get => EditData._IDSetorSaida;
			set
			{
				if (value != EditData._IDSetorSaida)
				{
					EditData._IDSetorSaida = value;
					NotifyPropertyChanged("IDSetorSaida");
				}
			}
		}

		// Property SetorSaida
		//---------------------------------------------------------------
		public string SetorSaida
		{
			get => EditData._SetorSaida;
			set => EditData._SetorSaida = value;
		}

		// Property Descricao
		//---------------------------------------------------------------
		public string Descricao
		{
			get => EditData._Descricao;
			set
			{
				if (value != EditData._Descricao)
				{
					EditData._Descricao = value;
					NotifyPropertyChanged("Descricao");
				}
			}
		}

		// TRANSFERENCIA OBJECT
		public virtual objTransferencia Transferencia
		{
			get => EditData._transf;
			set => EditData._transf = value;
		}
	}
}
