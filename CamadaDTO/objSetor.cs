using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	public class objSetor : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructConta
		{
			internal int? _IDSetor;
			internal string _Setor;
			internal int? _IDCongregacao;
			internal string _Congregacao;
			internal decimal _SetorSaldo;
			internal bool _Ativa;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructConta EditData;
		private StructConta BackupData;
		private bool inTxn = false;

		public objSetor(int? IDSetor) : base()
		{
			EditData = new StructConta()
			{
				_IDSetor = IDSetor,
				_Setor = "",
				_IDCongregacao = null,
				_SetorSaldo = 0,
				_Ativa = true
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
			return EditData._Setor;
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		// GET SHALLOW COPY OF OBJECT
		//------------------------------------------------------------------------------------------------------------
		public objSetor ShallowCopy()
		{
			return (objSetor)this.MemberwiseClone();
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public int? IDSetor
		{
			get => EditData._IDSetor;
			set => EditData._IDSetor = value;
		}

		// Property Setor
		//----------------------------------------------------------------
		public string Setor
		{
			get => EditData._Setor;
			set
			{
				if (value != EditData._Setor)
				{
					EditData._Setor = value;
					NotifyPropertyChanged("Setor");
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

		// Property SetorSaldo
		//---------------------------------------------------------------
		public decimal SetorSaldo
		{
			get => EditData._SetorSaldo;
			set
			{
				if (value != EditData._SetorSaldo)
				{
					EditData._SetorSaldo = value;
					NotifyPropertyChanged("SetorSaldo");
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
