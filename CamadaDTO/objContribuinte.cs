﻿using System;
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
			internal DateTime? _NascimentoData;
			internal bool _Dizimista;
			internal bool _Ativo;
			internal int? _IDMembro;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructContribuinte EditData;
		private StructContribuinte BackupData;
		private bool inTxn = false;

		public objContribuinte(int? IDContribuinte) : base()
		{
			EditData = new StructContribuinte() {
				_IDContribuinte = IDContribuinte,
				_Contribuinte = "", 
				_Ativo = true, 
				_CNP = "", 
				_Dizimista = false,
				_NascimentoData = null,
				_IDMembro = null
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

		// PROPERTY CHANGED
		//------------------------------------------------------------------------------------------------------------
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public override string ToString()
		{
			return EditData._Contribuinte;
		}

		public bool RegistroAlterado 
		{
			get => inTxn;  
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public int? IDContribuinte
		{ 
			get => EditData._IDContribuinte; 
		}

		// Property Contribuinte
		//----------------------------------------------------------------
		public string Contribuinte
		{
			get => EditData._Contribuinte;
			set
			{
				if (value != EditData._Contribuinte)
				{
					EditData._Contribuinte = value;
					NotifyPropertyChanged("Contribuinte");
				}
			}
		}

		// Property CNP
		//---------------------------------------------------------------
		public string CNP
		{
			get => EditData._CNP;
			set
			{
				if (value != EditData._CNP)
				{
					EditData._CNP = value;
					NotifyPropertyChanged("CNP");
				}
			}
		}

		// Property NascimentoData
		//---------------------------------------------------------------
		public DateTime? NascimentoData
		{
			get => EditData._NascimentoData;
			set
			{
				if (value != EditData._NascimentoData)
				{
					EditData._NascimentoData = value;
					NotifyPropertyChanged("NascimentoData");
				}
			}
		}

		// Property Dizimista
		//---------------------------------------------------------------
		public bool Dizimista
		{
			get => EditData._Dizimista;
			set
			{
				if (value != EditData._Dizimista)
				{
					EditData._Dizimista = value;
					NotifyPropertyChanged("Dizimista");
				}
			}
		}

		// Property Ativo
		//---------------------------------------------------------------
		public bool Ativo
		{
			get => EditData._Ativo;
			set
			{
				if (value != EditData._Ativo)
				{
					EditData._Ativo = value;
					NotifyPropertyChanged("Ativo");
				}
			}
		}

		// Property IDMembro
		//---------------------------------------------------------------
		public int? IDMembro
		{
			get => EditData._IDMembro;
			set
			{
				if (value != EditData._IDMembro)
				{
					EditData._IDMembro = value;
					NotifyPropertyChanged("IDMembro");
				}
			}
		}
	}
}
