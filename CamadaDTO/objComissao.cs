using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	//=================================================================================================
	// CLASSE COMISSAO
	//=================================================================================================
	public class objComissao : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructComissao
		{
			internal int? _IDComissao;
			internal int _IDCredor;
			internal string _Credor;
			internal int _IDSetor;
			internal string _Setor;
			internal decimal _ComissaoTaxa;
			internal DateTime _DataInicial;
			internal DateTime _DataFinal;
			internal decimal _ValorContribuicoes;
			internal decimal _ValorDescontado;
			internal decimal _ValorComissao;
			internal byte _IDSituacao;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructComissao EditData;
		private StructComissao BackupData;
		private bool inTxn = false;

		public objComissao(int? ID) : base()
		{
			EditData = new StructComissao()
			{
				_IDComissao = ID,
				_Credor = "",
				_ComissaoTaxa = 0,
				_ValorComissao = 0,
				_ValorContribuicoes = 0,
				_ValorDescontado = 0,
				_IDSituacao = 1,
			};

			IDDespesa = null;
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
				BackupData = new StructComissao();
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
			return EditData._IDComissao.ToString();
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public int? IDComissao
		{
			get => EditData._IDComissao;
			set => EditData._IDComissao = value;
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

		// Property IDSetor
		//---------------------------------------------------------------
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
			set
			{
				if (value != EditData._Setor)
				{
					EditData._Setor = value;
					NotifyPropertyChanged("Setor");
				}
			}
		}

		// Property ComissaoTaxa
		//---------------------------------------------------------------
		public decimal ComissaoTaxa
		{
			get => EditData._ComissaoTaxa;
			set
			{
				if (value != EditData._ComissaoTaxa)
				{
					EditData._ComissaoTaxa = value;
					NotifyPropertyChanged("ComissaoTaxa");
				}
			}
		}

		// Property DataInicial
		//---------------------------------------------------------------
		public DateTime DataInicial
		{
			get => EditData._DataInicial;
			set
			{
				if (value != EditData._DataInicial)
				{
					EditData._DataInicial = value;
					NotifyPropertyChanged("DataInicial");
				}
			}
		}

		// Property DataFinal
		//---------------------------------------------------------------
		public DateTime DataFinal
		{
			get => EditData._DataFinal;
			set
			{
				if (value != EditData._DataFinal)
				{
					EditData._DataFinal = value;
					NotifyPropertyChanged("DataFinal");
				}
			}
		}

		// Property ValorContribuicoes
		//---------------------------------------------------------------
		public decimal ValorContribuicoes
		{
			get => EditData._ValorContribuicoes;
			set
			{
				if (value != EditData._ValorContribuicoes)
				{
					EditData._ValorContribuicoes = value;
					NotifyPropertyChanged("ValorContribuicoes");
				}
			}
		}

		// Property ValorDescontado
		//---------------------------------------------------------------
		public decimal ValorDescontado
		{
			get => EditData._ValorDescontado;
			set
			{
				if (value != EditData._ValorDescontado)
				{
					EditData._ValorDescontado = value;
					NotifyPropertyChanged("ValorDescontado");
				}
			}
		}

		// Property ValorComissao
		//---------------------------------------------------------------
		public decimal ValorComissao
		{
			get => EditData._ValorComissao;
			set
			{
				if (value != EditData._ValorComissao)
				{
					EditData._ValorComissao = value;
					NotifyPropertyChanged("ValorComissao");
				}
			}
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

		public string Situacao
		{
			get
			{
				switch (IDSituacao)
				{
					case 1:
						return "Inicializado";
					case 2:
						return "Concluído";
					case 3:
						return "Pago";
					default:
						return "";
				}
			}
		}

		public long? IDDespesa { get; set; }

	}

	//=================================================================================================
	// CLASSE CONTRIBUICAO COMISSIONADA
	//=================================================================================================
	public class objContribuicaoComissionada
	{
		public long IDContribuicao { get; set; }
		public int IDComissao { get; set; }
		public decimal ValorComissionado { get; set; }
	}

}
