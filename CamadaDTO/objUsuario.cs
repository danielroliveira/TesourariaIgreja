using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	//=================================================================================================
	// USUARIO
	//=================================================================================================
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
			internal string _Email;
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
				_Email = ""
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
			set => EditData._IDUsuario = value;
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

		public string UsuarioAcessoDesc
		{
			get
			{
				switch (UsuarioAcesso)
				{
					case 1:
						return "Administrador";
					case 2:
						return "Usuário Senior";
					case 3:
						return "Usuário Comum";
					case 4:
						return "Usuário Local";
					default:
						return "";
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

		// Property Email
		//---------------------------------------------------------------
		public string Email
		{
			get => EditData._Email;
			set
			{
				if (value != EditData._Email)
				{
					EditData._Email = value;
					NotifyPropertyChanged("Email");
				}
			}
		}
	}

	//=================================================================================================
	// ACESSO USUARIO CONTA
	//=================================================================================================
	public class objUsuarioConta : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructUsuario
		{
			internal int? _IDUserConta;
			internal int? _IDUsuario;
			internal int? _IDConta;
			internal DateTime _LiberacaoData;
			internal bool _Ativo;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructUsuario EditData;
		private StructUsuario BackupData;
		private bool inTxn = false;

		public objUsuarioConta(int? IDUsuario, int? IDConta) : base()
		{
			EditData = new StructUsuario()
			{
				_IDUserConta = null,
				_IDUsuario = IDUsuario,
				_IDConta = IDConta,
				_LiberacaoData = DateTime.Today,
				_Ativo = true
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
			return $"User: {EditData._IDUsuario:0000} | Conta:{EditData._IDConta:0000}";
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public int? IDUserConta
		{
			get => EditData._IDUserConta;
			set => EditData._IDUserConta = value;
		}

		// Property IDUsuario
		//---------------------------------------------------------------
		public int? IDUsuario
		{
			get => EditData._IDUsuario;
			set
			{
				if (value != EditData._IDUsuario)
				{
					EditData._IDUsuario = value;
					NotifyPropertyChanged("IDUsuario");
				}
			}
		}

		public string UsuarioApelido { get; set; }

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

		public string Conta { get; set; }

		// Property LiberacaoData
		//---------------------------------------------------------------
		public DateTime LiberacaoData
		{
			get => EditData._LiberacaoData;
			set
			{
				if (value != EditData._LiberacaoData)
				{
					EditData._LiberacaoData = value;
					NotifyPropertyChanged("LiberacaoData");
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
	}
}
