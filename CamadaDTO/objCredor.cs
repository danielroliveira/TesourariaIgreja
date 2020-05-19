using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	//=================================================================================================
	// CLASSE CREDOR
	//=================================================================================================
	public class objCredor : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructCredor
		{
			internal int? _IDCredor;
			internal string _Credor;
			internal byte _CredorTipo;
			internal string _CredorTipoDescricao;
			internal string _CNP;
			internal string _EnderecoLogradouro;
			internal string _EnderecoNumero;
			internal string _EnderecoComplemento;
			internal string _Bairro;
			internal string _Cidade;
			internal string _UF;
			internal string _CEP;
			internal string _TelefoneFixo;
			internal string _TelefoneCelular;
			internal bool _Whatsapp;
			internal string _Email;
			internal bool _Ativo;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructCredor EditData;
		private StructCredor BackupData;
		private bool inTxn = false;

		public objCredor(int? ID) : base()
		{
			EditData = new StructCredor()
			{
				_IDCredor = ID,
				_Credor = "",
				_Ativo = true,
				_EnderecoLogradouro = "",
				_CredorTipo = 4
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
				BackupData = new StructCredor();
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
			return EditData._Credor;
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public int? IDCredor
		{
			get => EditData._IDCredor;
			set => EditData._IDCredor = value;
		}

		// Property Credor
		//----------------------------------------------------------------
		public string Credor
		{
			get => EditData._Credor;
			set
			{
				if (value != EditData._Credor)
				{
					EditData._Credor = value;
					NotifyPropertyChanged("Credor");
				}
			}
		}

		// Property CredorTipo
		//---------------------------------------------------------------
		public byte CredorTipo
		{
			get => EditData._CredorTipo;
			set
			{
				if (value != EditData._CredorTipo)
				{
					EditData._CredorTipo = value;
					NotifyPropertyChanged("CredorTipo");
				}
			}
		}

		// Property CredorTipoDescricao
		//---------------------------------------------------------------
		public string CredorTipoDescricao
		{
			get
			{
				switch (CredorTipo)
				{
					case 1:
						return "Pessoa Física";
					case 2:
						return "Pessoa Jurídica";
					case 3:
						return "Órgão Público";
					case 4:
						return "Credor Simples";
					default:
						return "";
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

		// Property EnderecoLogradouro
		//---------------------------------------------------------------
		public string EnderecoLogradouro
		{
			get => EditData._EnderecoLogradouro;
			set
			{
				if (value != EditData._EnderecoLogradouro)
				{
					EditData._EnderecoLogradouro = value;
					NotifyPropertyChanged("EnderecoLogradouro");
				}
			}
		}

		// Property EnderecoNumero
		//---------------------------------------------------------------
		public string EnderecoNumero
		{
			get => EditData._EnderecoNumero;
			set
			{
				if (value != EditData._EnderecoNumero)
				{
					EditData._EnderecoNumero = value;
					NotifyPropertyChanged("EnderecoNumero");
				}
			}
		}

		// Property EnderecoComplemento
		//---------------------------------------------------------------
		public string EnderecoComplemento
		{
			get => EditData._EnderecoComplemento;
			set
			{
				if (value != EditData._EnderecoComplemento)
				{
					EditData._EnderecoComplemento = value;
					NotifyPropertyChanged("EnderecoComplemento");
				}
			}
		}

		// Property READONLY EnderecoCompleto
		//---------------------------------------------------------------
		public string Endereco
		{
			get
			{
				string retorno = "";

				if (!string.IsNullOrEmpty(EnderecoLogradouro))
				{
					retorno = EnderecoLogradouro;
				}

				if (!string.IsNullOrEmpty(EnderecoNumero))
				{
					retorno += ", " + EnderecoNumero;
				}
				else
				{
					retorno += ", S/N";
				}

				if (!string.IsNullOrEmpty(EnderecoComplemento))
				{
					retorno += " " + EnderecoComplemento;
				}

				return retorno;
			}
		}


		// Property Bairro
		//---------------------------------------------------------------
		public string Bairro
		{
			get => EditData._Bairro;
			set
			{
				if (value != EditData._Bairro)
				{
					EditData._Bairro = value;
					NotifyPropertyChanged("Bairro");
				}
			}
		}

		// Property Cidade
		//---------------------------------------------------------------
		public string Cidade
		{
			get => EditData._Cidade;
			set
			{
				if (value != EditData._Cidade)
				{
					EditData._Cidade = value;
					NotifyPropertyChanged("Cidade");
				}
			}
		}

		// Property UF
		//---------------------------------------------------------------
		public string UF
		{
			get => EditData._UF;
			set
			{
				if (value != EditData._UF)
				{
					EditData._UF = value;
					NotifyPropertyChanged("UF");
				}
			}
		}

		// Property CEP
		//---------------------------------------------------------------
		public string CEP
		{
			get => EditData._CEP;
			set
			{
				if (value != EditData._CEP)
				{
					EditData._CEP = value;
					NotifyPropertyChanged("CEP");
				}
			}
		}

		// Property TelefoneFixo
		//---------------------------------------------------------------
		public string TelefoneFixo
		{
			get => EditData._TelefoneFixo;
			set
			{
				if (value != EditData._TelefoneFixo)
				{
					EditData._TelefoneFixo = value;
					NotifyPropertyChanged("TelefoneFixo");
				}
			}
		}

		// Property TelefoneCelular
		//---------------------------------------------------------------
		public string TelefoneCelular
		{
			get => EditData._TelefoneCelular;
			set
			{
				if (value != EditData._TelefoneCelular)
				{
					EditData._TelefoneCelular = value;
					NotifyPropertyChanged("TelefoneCelular");
				}
			}
		}

		// Property Whatsapp
		//---------------------------------------------------------------
		public bool Whatsapp
		{
			get => EditData._Whatsapp;
			set
			{
				if (value != EditData._Whatsapp)
				{
					EditData._Whatsapp = value;
					NotifyPropertyChanged("Whatsapp");
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
