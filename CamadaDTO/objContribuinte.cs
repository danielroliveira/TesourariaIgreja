using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDTO
{
    public class objContribuinte : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructContribuinte
		{
			internal int? _IDContribuinte;
			internal string _Contribuinte;
			internal string _CNP;
			internal DateTime _NascimentoData;
			internal bool _Dizimista;
			internal bool _Ativo;
			internal int _IDMembro;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructContribuinte EditData;
		private StructContribuinte BackupData;
		private bool inTxn = false;

		public objContribuinte()
		{
			EditData = new StructContribuinte() {
				_IDContribuinte = null,
				_Contribuinte = "", 
				_Ativo = true, 
				_CNP = "", 
				_Dizimista = false
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

		public void EndEdit()
		{
			if (inTxn)
			{
				EditData = BackupData;
				inTxn = false;
			}
		}

		public void CancelEdit()
		{
			if (inTxn)
			{
				BackupData = new StructContribuinte();
				inTxn = false;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}


		// PROPERTIES
		//-------------------------------------------------------------------------------------------------
		public int? IDContribuinte
		{
			get
			{
				return EditData._IDContribuinte;
			}
		}

		public string Contribuinte
		{
			get
			{
				return EditData._Contribuinte;
			}

			set
			{
				if (value != EditData._Contribuinte)
				{
					EditData._Contribuinte = value;
					NotifyPropertyChanged("Contribuinte");
				}
			}
		}


		/*
		public event EventHandler Alterado;

		protected virtual void OnAlterado(EventArgs e)
		{
			EventHandler handler = Alterado;
			handler?.Invoke(this, e);
		}
		*/


		/*
		    '
			'-- _EVENTO PUBLIC AOALTERAR
			Public Event AoAlterar()
			'
			Public Overrides Function ToString() As String
				Return IDVenda.ToString
			End Function
			'
			Public ReadOnly Property RegistroAlterado As Boolean
				Get
					Return inTxn
				End Get
			End Property
		
		*/


	}
}
