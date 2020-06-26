using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
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
