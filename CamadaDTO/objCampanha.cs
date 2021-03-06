﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	public class objCampanha : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructCampanha
		{
			internal int? _IDCampanha;
			internal string _Campanha;
			internal int? _IDSetor;
			internal string _Setor;
			internal decimal _CampanhaSaldo;
			internal decimal _ObjetivoValor;
			internal DateTime _InicioData;
			internal DateTime? _ConclusaoData;
			internal bool _Ativa;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructCampanha EditData;
		private StructCampanha BackupData;
		private bool inTxn = false;

		public objCampanha(int? IDCampanha) : base()
		{
			EditData = new StructCampanha()
			{
				_IDCampanha = IDCampanha,
				_Campanha = "",
				_IDSetor = null,
				_CampanhaSaldo = 0,
				_InicioData = DateTime.Today,
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
				BackupData = new StructCampanha();
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
			return EditData._Campanha;
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public int? IDCampanha
		{
			get => EditData._IDCampanha;
			set => EditData._IDCampanha = value;
		}

		// Property Campanha
		//----------------------------------------------------------------
		public string Campanha
		{
			get => EditData._Campanha;
			set
			{
				if (value != EditData._Campanha)
				{
					EditData._Campanha = value;
					NotifyPropertyChanged("Campanha");
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

		// Property CampanhaSaldo
		//---------------------------------------------------------------
		public decimal CampanhaSaldo
		{
			get => EditData._CampanhaSaldo;
			set
			{
				if (value != EditData._CampanhaSaldo)
				{
					EditData._CampanhaSaldo = value;
					NotifyPropertyChanged("CampanhaSaldo");
				}
			}
		}

		// Property ObjetivoValor
		//---------------------------------------------------------------
		public decimal ObjetivoValor
		{
			get => EditData._ObjetivoValor;
			set
			{
				if (value != EditData._ObjetivoValor)
				{
					EditData._ObjetivoValor = value;
					NotifyPropertyChanged("ObjetivoValor");
				}
			}
		}

		// Property InicioData
		//---------------------------------------------------------------
		public DateTime InicioData
		{
			get => EditData._InicioData;
			set
			{
				if (value != EditData._InicioData)
				{
					EditData._InicioData = value;
					NotifyPropertyChanged("InicioData");
				}
			}
		}

		// Property ConclusaoData
		//---------------------------------------------------------------
		public DateTime? ConclusaoData
		{
			get => EditData._ConclusaoData;
			set
			{
				if (value != EditData._ConclusaoData)
				{
					EditData._ConclusaoData = value;
					NotifyPropertyChanged("ConclusaoData");
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
