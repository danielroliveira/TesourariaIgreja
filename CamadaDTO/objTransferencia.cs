using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
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
			internal decimal _TransfValor;
			internal DateTime _TransfData;
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
				_TransfData = DateTime.Today,
				_TransfValor = 0
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

		// Property TransfData
		//---------------------------------------------------------------
		public DateTime TransfData
		{
			get => EditData._TransfData;
			set
			{
				if (value != EditData._TransfData)
				{
					EditData._TransfData = value;
					NotifyPropertyChanged("TransfData");
				}
			}
		}

		// Property TransfValor
		//---------------------------------------------------------------
		public decimal TransfValor
		{
			get => EditData._TransfValor;
			set
			{
				if (value != EditData._TransfValor)
				{
					EditData._TransfValor = value;
					NotifyPropertyChanged("TransfValor");
				}
			}
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
			internal decimal _TransfValor;
			internal DateTime _TransfData;
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
				_TransfData = DateTime.Today,
				_TransfValor = 0,
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

		// Property TransfData
		//---------------------------------------------------------------
		public DateTime TransfData
		{
			get => EditData._TransfData;
			set
			{
				if (value != EditData._TransfData)
				{
					EditData._TransfData = value;
					NotifyPropertyChanged("TransfData");
				}
			}
		}

		// Property TransfValor
		//---------------------------------------------------------------
		public decimal TransfValor
		{
			get => EditData._TransfValor;
			set
			{
				if (value != EditData._TransfValor)
				{
					EditData._TransfValor = value;
					NotifyPropertyChanged("TransfValor");
				}
			}
		}
	}
}
