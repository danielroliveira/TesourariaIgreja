using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	public class objReuniao : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructReuniao
		{
			internal int? _IDReuniao;
			internal string _Reuniao;
			internal int? _IDCongregacao;
			internal byte _RecorrenciaTipo; // 1:Diaria | 2:Semanal | 3:Mensal | 4:Anual
			internal byte? _RecorrenciaA; // Semanal -> Dia da Semana | Mensal -> Dia do Mes ou Semana do Mes | Anual -> Mes do ano
			internal byte? _RecorrenciaB; // Mensal -> Semana do Mes Dia | Anual -> Mes do Ano
			internal bool _Ativa;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructReuniao EditData;
		private StructReuniao BackupData;
		private bool inTxn = false;

		public objReuniao(int? IDReuniao) : base()
		{
			EditData = new StructReuniao()
			{
				_IDReuniao = IDReuniao,
				_Reuniao = "",
				_IDCongregacao = null,
				_RecorrenciaTipo = 2, // semanal
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
				BackupData = new StructReuniao();
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
			return EditData._Reuniao;
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public int? IDReuniao
		{
			get => EditData._IDReuniao;
			set => EditData._IDReuniao = value;
		}

		// Property Reuniao
		//----------------------------------------------------------------
		public string Reuniao
		{
			get => EditData._Reuniao;
			set
			{
				if (value != EditData._Reuniao)
				{
					EditData._Reuniao = value;
					NotifyPropertyChanged("Reuniao");
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
		public string Congregacao { get; set; }

		// Property RecorrenciaTipo
		//---------------------------------------------------------------
		public byte RecorrenciaTipo
		{
			get => EditData._RecorrenciaTipo;
			set
			{
				if (value != EditData._RecorrenciaTipo)
				{
					EditData._RecorrenciaTipo = value;
					NotifyPropertyChanged("RecorrenciaTipo");
				}
			}
		}

		// Property RecorrenciaTipoDescricao
		//---------------------------------------------------------------
		public string RecorrenciaTipoDescricao { get; set; }

		// Property RecorrenciaA
		//---------------------------------------------------------------
		public byte? RecorrenciaA
		{
			get => EditData._RecorrenciaA;
			set
			{
				if (value != EditData._RecorrenciaA)
				{
					EditData._RecorrenciaA = value;
					NotifyPropertyChanged("RecorrenciaA");
				}
			}
		}

		// Property RecorrenciaB
		//---------------------------------------------------------------
		public byte? RecorrenciaB
		{
			get => EditData._RecorrenciaB;
			set
			{
				if (value != EditData._RecorrenciaB)
				{
					EditData._RecorrenciaB = value;
					NotifyPropertyChanged("RecorrenciaB");
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
