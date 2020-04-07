using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	public class objUsuario : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructUsuario
		{
			internal int? _IDUsuario;
			internal string _UsuarioApelido;
			internal byte _UsuarioAcesso;
			internal string _UsuarioSenha;
			internal bool _UsuarioAtivo;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructUsuario EditData;
		private StructUsuario BackupData;
		private bool inTxn = false;

		public objUsuario(int? IDUsuario) : base()
		{
			EditData = new StructUsuario()
			{
				_IDUsuario = IDUsuario,
				_UsuarioApelido = "",
				_UsuarioAcesso = 3,
				_UsuarioSenha = "",
				_UsuarioAtivo = true,
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
				BackupData = new StructUsuario();
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
			return EditData._UsuarioApelido;
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public int? IDUsuario
		{
			get => EditData._IDUsuario;
		}

		// Property UsuarioApelido
		//----------------------------------------------------------------
		public string UsuarioApelido
		{
			get => EditData._UsuarioApelido;
			set
			{
				if (value != EditData._UsuarioApelido)
				{
					EditData._UsuarioApelido = value;
					NotifyPropertyChanged("UsuarioApelido");
				}
			}
		}

		// Property UsuarioAcesso
		//---------------------------------------------------------------
		public byte UsuarioAcesso
		{
			get => EditData._UsuarioAcesso;
			set
			{
				if (value != EditData._UsuarioAcesso)
				{
					EditData._UsuarioAcesso = value;
					NotifyPropertyChanged("UsuarioAcesso");
				}
			}
		}

		// Property UsuarioSenha
		//---------------------------------------------------------------
		public string UsuarioSenha
		{
			get => EditData._UsuarioSenha;
			set
			{
				if (value != EditData._UsuarioSenha)
				{
					EditData._UsuarioSenha = value;
					NotifyPropertyChanged("UsuarioSenha");
				}
			}
		}

		// Property Ativa
		//---------------------------------------------------------------
		public bool UsuarioAtivo
		{
			get => EditData._UsuarioAtivo;
			set
			{
				if (value != EditData._UsuarioAtivo)
				{
					EditData._UsuarioAtivo = value;
					NotifyPropertyChanged("UsuarioAtivo");
				}
			}
		}
	}
}
