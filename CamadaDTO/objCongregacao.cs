using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	//=================================================================================================
	// CLASSE CONGREGACAO
	//=================================================================================================
	public class objCongregacao : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructCongregacao
		{
			internal int? _IDCongregacao;
			internal string _Congregacao;
			internal string _EnderecoLogradouro;
			internal string _EnderecoNumero;
			internal string _EnderecoComplemento;
			internal string _Bairro;
			internal string _Cidade;
			internal string _UF;
			internal string _CEP;
			internal string _TelefoneFixo;
			internal string _TelefoneDirigente;
			internal string _Email;
			internal string _Dirigente;
			internal string _Tesoureiro;
			internal bool _Ativo;
			internal int? _IDCongregacaoSetor;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructCongregacao EditData;
		private StructCongregacao BackupData;
		private bool inTxn = false;

		public objCongregacao(int? ID) : base()
		{
			EditData = new StructCongregacao()
			{
				_IDCongregacao = ID,
				_Congregacao = "",
				_Ativo = true,
				_EnderecoLogradouro = "",
				_IDCongregacaoSetor = null
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
				BackupData = new StructCongregacao();
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
			return EditData._Congregacao;
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public int? IDCongregacao
		{
			get => EditData._IDCongregacao;
			set => EditData._IDCongregacao = value;
		}

		// Property Congregacao
		//----------------------------------------------------------------
		public string Congregacao
		{
			get => EditData._Congregacao;
			set
			{
				if (value != EditData._Congregacao)
				{
					EditData._Congregacao = value;
					NotifyPropertyChanged("Congregacao");
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

		// Property TelefoneDirigente
		//---------------------------------------------------------------
		public string TelefoneDirigente
		{
			get => EditData._TelefoneDirigente;
			set
			{
				if (value != EditData._TelefoneDirigente)
				{
					EditData._TelefoneDirigente = value;
					NotifyPropertyChanged("TelefoneDirigente");
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

		// Property Dirigente
		//---------------------------------------------------------------
		public string Dirigente
		{
			get => EditData._Dirigente;
			set
			{
				if (value != EditData._Dirigente)
				{
					EditData._Dirigente = value;
					NotifyPropertyChanged("Dirigente");
				}
			}
		}

		// Property Tesoureiro
		//---------------------------------------------------------------
		public string Tesoureiro
		{
			get => EditData._Tesoureiro;
			set
			{
				if (value != EditData._Tesoureiro)
				{
					EditData._Tesoureiro = value;
					NotifyPropertyChanged("Tesoureiro");
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

		// Property IDCongregacaoSetor
		//---------------------------------------------------------------
		public int? IDCongregacaoSetor
		{
			get => EditData._IDCongregacaoSetor;
			set
			{
				if (value != EditData._IDCongregacaoSetor)
				{
					EditData._IDCongregacaoSetor = value;
					NotifyPropertyChanged("IDCongregacaoSetor");
				}
			}
		}

		// Property CongregacaoSetor
		//---------------------------------------------------------------
		public string CongregacaoSetor { get; set; }
	}


	//=================================================================================================
	// CLASSE CONGREGACAO SETOR
	//=================================================================================================
	public class objCongregacaoSetor
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructSetor
		{
			internal int? _IDCongregacaoSetor;
			internal string _CongregacaoSetor;
			internal string _CoordenadorNome;
			internal string _CoordenadorTelefone;
			internal bool _Ativo;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructSetor EditData;
		private StructSetor BackupData;
		private bool inTxn = false;

		public objCongregacaoSetor(int? ID) : base()
		{
			EditData = new StructSetor()
			{
				_IDCongregacaoSetor = ID,
				_CongregacaoSetor = "",
				_CoordenadorNome = "",
				_CoordenadorTelefone = null,
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
				BackupData = new StructSetor();
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
			return EditData._CongregacaoSetor;
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public int? IDCongregacaoSetor
		{
			get => EditData._IDCongregacaoSetor;
			set => EditData._IDCongregacaoSetor = value;
		}

		// Property CongregacaoSetor
		//----------------------------------------------------------------
		public string CongregacaoSetor
		{
			get => EditData._CongregacaoSetor;
			set
			{
				if (value != EditData._CongregacaoSetor)
				{
					EditData._CongregacaoSetor = value;
					NotifyPropertyChanged("CongregacaoSetor");
				}
			}
		}

		// Property CoordenadorNome
		//---------------------------------------------------------------
		public string CoordenadorNome
		{
			get => EditData._CoordenadorNome;
			set
			{
				if (value != EditData._CoordenadorNome)
				{
					EditData._CoordenadorNome = value;
					NotifyPropertyChanged("CoordenadorNome");
				}
			}
		}

		// Property CoordenadorTelefone
		//---------------------------------------------------------------
		public string CoordenadorTelefone
		{
			get => EditData._CoordenadorTelefone;
			set
			{
				if (value != EditData._CoordenadorTelefone)
				{
					EditData._CoordenadorTelefone = value;
					NotifyPropertyChanged("CoordenadorTelefone");
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
