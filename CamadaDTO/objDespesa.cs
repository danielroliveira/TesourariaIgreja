using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	//=================================================================================================
	// DESPESA
	//=================================================================================================
	public class objDespesa : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructDespesa
		{
			internal long? _IDDespesa;
			internal string _DespesaDescricao;
			internal byte _DespesaOrigem; // 1:DespesaComum
			internal DateTime _DespesaData;
			internal decimal _DespesaValor;
			internal string _DocumentoNumero;
			internal int _IDCredor;
			internal string _Credor;

			// from Despesa Titular
			internal int? _IDTitular;
			internal string _Titular;
			internal string _CNP;

			internal int _IDDespesaTipo;
			internal string _DespesaTipo;
			internal byte _IDDocumentoTipo;
			internal string _DocumentoTipo;
			internal int _IDSetor;
			internal string _Setor;
			internal byte _IDSituacao;
			internal string _Situacao;
			internal byte _Parcelas;
			internal byte _Prioridade;  // 1: Imediata | 2: Alta Prioridade | 3: Normal | 4: Baixa | 5: Suspender
			internal bool _Imagem;

		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructDespesa EditData;
		private StructDespesa BackupData;
		private bool inTxn = false;

		public objDespesa(long? IDDespesa) : base()
		{
			EditData = new StructDespesa()
			{
				_IDDespesa = IDDespesa,
				_DespesaDescricao = "",
				_DespesaOrigem = 1,
				_DespesaData = DateTime.Today,
				_DespesaValor = 0,
				_IDSituacao = 1,
				_Parcelas = 1,
				_Prioridade = 3, // prioridade NORMAL
				_Imagem = false,
				_IDTitular = null
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
				BackupData = new StructDespesa();
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
			return EditData._DespesaDescricao;
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public long? IDDespesa
		{
			get => EditData._IDDespesa;
			set => EditData._IDDespesa = value;
		}

		// Property DespesaDescricao
		//---------------------------------------------------------------
		public string DespesaDescricao
		{
			get => EditData._DespesaDescricao;
			set
			{
				if (value != EditData._DespesaDescricao)
				{
					EditData._DespesaDescricao = value;
					NotifyPropertyChanged("DespesaDescricao");
				}
			}
		}

		// Property DespesaOrigem
		//---------------------------------------------------------------
		public byte DespesaOrigem
		{
			get => EditData._DespesaOrigem;
			set => EditData._DespesaOrigem = value;
		}

		// Property DespesaData
		//---------------------------------------------------------------
		public DateTime DespesaData
		{
			get => EditData._DespesaData;
			set
			{
				if (value != EditData._DespesaData)
				{
					EditData._DespesaData = value;
					NotifyPropertyChanged("DespesaData");
				}
			}
		}

		// Property DespesaValor
		//---------------------------------------------------------------
		public decimal DespesaValor
		{
			get => EditData._DespesaValor;
			set
			{
				if (value != EditData._DespesaValor)
				{
					EditData._DespesaValor = value;
					NotifyPropertyChanged("DespesaValor");
				}
			}
		}

		// Property DocumentoNumero
		//---------------------------------------------------------------
		public string DocumentoNumero
		{
			get => EditData._DocumentoNumero;
			set
			{
				if (value != EditData._DocumentoNumero)
				{
					EditData._DocumentoNumero = value;
					NotifyPropertyChanged("DocumentoNumero");
				}
			}
		}

		// Property IDCredor
		//---------------------------------------------------------------
		public int IDCredor
		{
			get => EditData._IDCredor;
			set
			{
				if (value != EditData._IDCredor)
				{
					EditData._IDCredor = value;
					NotifyPropertyChanged("IDCredor");
				}
			}
		}

		// Property Credor
		//---------------------------------------------------------------
		public string Credor
		{
			get => EditData._Credor;
			set => EditData._Credor = value;
		}

		// Property IDTitular
		//---------------------------------------------------------------
		public int? IDTitular
		{
			get => EditData._IDTitular;
			set
			{
				if (value != EditData._IDTitular)
				{
					EditData._IDTitular = value;
					NotifyPropertyChanged("IDTitular");
				}
			}
		}

		// Property Titular
		//---------------------------------------------------------------
		public string Titular
		{
			get => EditData._Titular;
			set => EditData._Titular = value;
		}

		// Property CNP
		//---------------------------------------------------------------
		public string CNP
		{
			get => EditData._CNP;
			set => EditData._CNP = value;
		}

		// Property IDDespesaTipo
		//---------------------------------------------------------------
		public int IDDespesaTipo
		{
			get => EditData._IDDespesaTipo;
			set
			{
				if (value != EditData._IDDespesaTipo)
				{
					EditData._IDDespesaTipo = value;
					NotifyPropertyChanged("IDDespesaTipo");
				}
			}
		}

		// Property DespesaTipo
		//---------------------------------------------------------------
		public string DespesaTipo
		{
			get => EditData._DespesaTipo;
			set => EditData._DespesaTipo = value;
		}

		// Property IDDocumentoTipo
		//---------------------------------------------------------------
		public byte IDDocumentoTipo
		{
			get => EditData._IDDocumentoTipo;
			set
			{
				if (value != EditData._IDDocumentoTipo)
				{
					EditData._IDDocumentoTipo = value;
					NotifyPropertyChanged("IDDocumentoTipo");
				}
			}
		}

		// Property DocumentoTipo
		//---------------------------------------------------------------
		public string DocumentoTipo
		{
			get => EditData._DocumentoTipo;
			set => EditData._DocumentoTipo = value;
		}

		// Property Setor
		//----------------------------------------------------------------
		public int IDSetor
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

		// Property IDSituacao
		//---------------------------------------------------------------
		public byte IDSituacao
		{
			get => EditData._IDSituacao;
			set
			{
				if (value != EditData._IDSituacao)
				{
					EditData._IDSituacao = value;
					NotifyPropertyChanged("IDSituacao");
				}
			}
		}

		// Property Situacao
		//---------------------------------------------------------------
		public string Situacao
		{
			get => EditData._Situacao;
			set => EditData._Situacao = value;
		}

		// Property Parcelas
		//---------------------------------------------------------------
		public byte Parcelas
		{
			get => EditData._Parcelas;
			set
			{
				if (value != EditData._Parcelas)
				{
					EditData._Parcelas = value;
					NotifyPropertyChanged("Parcelas");
				}
			}
		}

		// Property Prioridade
		//---------------------------------------------------------------
		public byte Prioridade
		{
			get => EditData._Prioridade;
			set
			{
				if (value != EditData._Prioridade)
				{
					EditData._Prioridade = value;
					NotifyPropertyChanged("Prioridade");
				}
			}
		}

		public string PrioridadeDescricao
		{
			get
			{
				switch (Prioridade)
				{
					case 1:
						return "Imediata";
					case 2:
						return "Alta Prioridade";
					case 3:
						return "Normal";
					case 4:
						return "Baixa";
					case 5:
						return "Suspender";
					default:
						return "";
				}
			}
		}

		// Property Imagem
		//---------------------------------------------------------------
		public bool Imagem
		{
			get => EditData._Imagem;
			set
			{
				if (value != EditData._Imagem)
				{
					EditData._Imagem = value;
					NotifyPropertyChanged("Imagem");
				}
			}
		}

	}

	//=================================================================================================
	// DESPESA TIPO
	//=================================================================================================
	public class objDespesaTipo : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructDespesa
		{
			internal int? _IDDespesaTipo;
			internal string _DespesaTipo;
			internal byte _Periodicidade; // 1:Variavel | 2:Semanal | 3:Mensal | 4:Semestral | 5:Anual
			internal bool _DespesaFixa;
			internal byte _IDDespesaTipoGrupo;
			internal string _DespesaTipoGrupo;
			internal bool _Ativo;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructDespesa EditData;
		private StructDespesa BackupData;
		private bool inTxn = false;

		public objDespesaTipo(int? IDDespesaTipo) : base()
		{
			EditData = new StructDespesa()
			{
				_IDDespesaTipo = IDDespesaTipo,
				_DespesaTipo = "",
				_Periodicidade = 1,
				_DespesaFixa = false,
				_IDDespesaTipoGrupo = 1,
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
				BackupData = new StructDespesa();
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
			return EditData._DespesaTipo;
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public int? IDDespesaTipo
		{
			get => EditData._IDDespesaTipo;
			set => EditData._IDDespesaTipo = value;
		}

		// Property DespesaTipo
		//---------------------------------------------------------------
		public string DespesaTipo
		{
			get => EditData._DespesaTipo;
			set
			{
				if (value != EditData._DespesaTipo)
				{
					EditData._DespesaTipo = value;
					NotifyPropertyChanged("DespesaTipo");
				}
			}
		}

		// Property Periodicidade
		//---------------------------------------------------------------
		public byte Periodicidade
		{
			get => EditData._Periodicidade;
			set
			{
				if (value != EditData._Periodicidade)
				{
					EditData._Periodicidade = value;
					NotifyPropertyChanged("Periodicidade");
				}
			}
		}

		public string PeriodicidadeDescricao // 1:Variavel | 2:Semanal | 3:Mensal | 4:Semestral | 5:Anual
		{
			get
			{
				switch (Periodicidade)
				{
					case 1:
						return "Variável";
					case 2:
						return "Semanal";
					case 3:
						return "Mensal";
					case 4:
						return "Semestral";
					case 5:
						return "Anual";
					default:
						return "";
				}
			}
		}

		// Property DespesaFixa
		//---------------------------------------------------------------
		public bool DespesaFixa
		{
			get => EditData._DespesaFixa;
			set
			{
				if (value != EditData._DespesaFixa)
				{
					EditData._DespesaFixa = value;
					NotifyPropertyChanged("DespesaFixa");
				}
			}
		}

		// Property IDDespesaTipoGrupo
		//---------------------------------------------------------------
		public byte IDDespesaTipoGrupo
		{
			get => EditData._IDDespesaTipoGrupo;
			set
			{
				if (value != EditData._IDDespesaTipoGrupo)
				{
					EditData._IDDespesaTipoGrupo = value;
					NotifyPropertyChanged("IDDespesaTipoGrupo");
				}
			}
		}

		// Property DespesaTipoGrupo
		//---------------------------------------------------------------
		public string DespesaTipoGrupo
		{
			get => EditData._DespesaTipoGrupo;
			set => EditData._DespesaTipoGrupo = value;
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

	//=================================================================================================
	// DESPESA GRUPO
	//=================================================================================================
	public class objDespesaTipoGrupo
	{
		public int? IDDespesaTipoGrupo { get; set; }
		public string DespesaTipoGrupo { get; set; }
		public bool Ativo { get; set; }
	}

	//=================================================================================================
	// DESPESA DOCUMENTO TIPO
	//=================================================================================================
	public class objDespesaDocumentoTipo
	{
		public int IDDocumentoTipo { get; set; }
		public string DocumentoTipo { get; set; }
		public bool Ativo { get; set; }
	}

	//=================================================================================================
	// DESPESA DESPESA TITULAR
	//=================================================================================================
	public class objDespesaTitular
	{
		public int? IDTitular { get; set; }
		public string Titular { get; set; }
		public string CNP { get; set; }
		public bool Ativo { get; set; }
	}
}
