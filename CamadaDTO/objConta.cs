using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	public class objConta : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructConta
		{
			internal int? _IDConta;
			internal string _Conta;
			internal int? _IDCongregacao;
			internal string _Congregacao;
			internal decimal _ContaSaldo;
			internal bool _Bancaria;
			internal bool _OperadoraCartao;
			internal DateTime? _BloqueioData;
			internal bool _Ativa;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructConta EditData;
		private StructConta BackupData;
		private bool inTxn = false;

		public objConta(int? IDConta) : base()
		{
			EditData = new StructConta()
			{
				_IDConta = IDConta,
				_Conta = "",
				_IDCongregacao = null,
				_ContaSaldo = 0,
				_Bancaria = false,
				_OperadoraCartao = false,
				_Ativa = true,
				_BloqueioData = DateTime.Today
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
				BackupData = new StructConta();
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
			return EditData._Conta;
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		// GET COPY OF CONTA OBJECT
		//------------------------------------------------------------------------------------------------------------
		public objConta GetCopyOf()
		{
			return new objConta(IDConta)
			{
				Ativa = EditData._Ativa,
				Bancaria = EditData._Bancaria,
				BloqueioData = EditData._BloqueioData,
				Congregacao = EditData._Congregacao,
				Conta = EditData._Conta,
				ContaSaldo = EditData._ContaSaldo,
				IDCongregacao = EditData._IDCongregacao,
				IDConta = EditData._IDConta,
				OperadoraCartao = EditData._OperadoraCartao
			};
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public int? IDConta
		{
			get => EditData._IDConta;
			set => EditData._IDConta = value;
		}

		// Property Conta
		//----------------------------------------------------------------
		public string Conta
		{
			get => EditData._Conta;
			set
			{
				if (value != EditData._Conta)
				{
					EditData._Conta = value;
					NotifyPropertyChanged("Conta");
				}
			}
		}

		// Property IDCongregacao
		//---------------------------------------------------------------
		public int? IDCongregacao
		{
			get => EditData._IDCongregacao;
			set
			{
				if (value != EditData._IDCongregacao)
				{
					EditData._IDCongregacao = value;
					NotifyPropertyChanged("IDCongregacao");
				}
			}
		}

		// Property Congregacao
		//---------------------------------------------------------------
		public string Congregacao
		{
			get => EditData._Congregacao;
			set => EditData._Congregacao = value;
		}

		// Property ContaSaldo
		//---------------------------------------------------------------
		public decimal ContaSaldo
		{
			get => EditData._ContaSaldo;
			set
			{
				if (value != EditData._ContaSaldo)
				{
					EditData._ContaSaldo = value;
					NotifyPropertyChanged("ContaSaldo");
				}
			}
		}

		// Property Bancaria
		//---------------------------------------------------------------
		public bool Bancaria
		{
			get => EditData._Bancaria;
			set
			{
				if (value != EditData._Bancaria)
				{
					EditData._Bancaria = value;
					NotifyPropertyChanged("Bancaria");
				}
			}
		}

		// Property Operadora
		//---------------------------------------------------------------
		public bool OperadoraCartao
		{
			get => EditData._OperadoraCartao;
			set
			{
				if (value != EditData._OperadoraCartao)
				{
					EditData._OperadoraCartao = value;
					NotifyPropertyChanged("Operadora");
				}
			}
		}

		// Property BloqueioData
		//---------------------------------------------------------------
		public DateTime? BloqueioData
		{
			get => EditData._BloqueioData;
			set
			{
				if (value != EditData._BloqueioData)
				{
					EditData._BloqueioData = value;
					NotifyPropertyChanged("BloqueioData");
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
