using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	//=================================================================================================
	// A PAGAR
	//=================================================================================================
	public class objAPagar : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructAPagar
		{
			internal long? _IDAPagar;
			internal long _IDDespesa;
			internal byte _DespesaOrigem; //-- 1:Despesa Comum | 2:DespesaPeriodica
			internal string _DespesaDescricao;
			internal string _Identificador;
			internal byte? _Parcela;
			internal int _IDAPagarForma;
			internal string _APagarForma;
			internal decimal _APagarValor;
			internal byte _IDSituacao; // 1: Em Aberto | 2: Quitadas | 3: Canceladas | 4:Negociadas | 5:Negativadas
			internal string _Situacao;
			internal int? _IDBanco;
			internal string _Banco;
			internal DateTime _Vencimento;
			internal DateTime? _PagamentoData;
			internal byte _Prioridade;
			internal decimal _ValorPago;
			internal decimal _ValorAcrescimo;
			internal decimal _ValorDesconto;
			internal int? _ReferenciaMes;
			internal int? _ReferenciaAno;
			internal int? _IDCredor;
			internal string _Credor;
			internal int _IDSetor;
			internal string _Setor;
			// from tblImagem
			internal objImagem _Imagem;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructAPagar EditData;
		private StructAPagar BackupData;
		private bool inTxn = false;

		public objAPagar(long? IDAPagar) : base()
		{
			EditData = new StructAPagar()
			{
				_IDAPagar = IDAPagar,
				_Parcela = 1,
				_IDAPagarForma = 1,
				_APagarForma = "Em Carteira",
				_APagarValor = 0,
				_IDSituacao = 1,
				_IDBanco = null,
				_Prioridade = 1,
				_ValorPago = 0,
				_ValorAcrescimo = 0,
				_ValorDesconto = 0,
				_Imagem = new objImagem()
				{
					Origem = EnumImagemOrigem.Despesa,
				},
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
				BackupData = new StructAPagar();
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

		// GET SHALLOW COPY OF OBJECT
		//------------------------------------------------------------------------------------------------------------
		public objAPagar ShallowCopy()
		{
			return (objAPagar)this.MemberwiseClone();
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public long? IDAPagar
		{
			get => EditData._IDAPagar;
			set => EditData._IDAPagar = value;
		}

		// Property IDDespesa
		//---------------------------------------------------------------
		public long IDDespesa
		{
			get => EditData._IDDespesa;
			set
			{
				if (value != EditData._IDDespesa)
				{
					EditData._IDDespesa = value;
					NotifyPropertyChanged("IDDespesa");
				}
			}
		}

		// Property Origem
		//---------------------------------------------------------------
		public byte DespesaOrigem
		{
			get => EditData._DespesaOrigem;
			set => EditData._DespesaOrigem = value;
		}

		// Property DespesaDescricao
		//---------------------------------------------------------------
		public string DespesaDescricao
		{
			get => EditData._DespesaDescricao;
			set => EditData._DespesaDescricao = value;
		}

		// Property Identificador
		//---------------------------------------------------------------
		public string Identificador
		{
			get => EditData._Identificador;
			set
			{
				if (value != EditData._Identificador)
				{
					EditData._Identificador = value;
					NotifyPropertyChanged("Identificador");
				}
			}
		}

		// Property Parcela
		//---------------------------------------------------------------
		public byte? Parcela
		{
			get => EditData._Parcela;
			set
			{
				if (value != EditData._Parcela)
				{
					EditData._Parcela = value;
					NotifyPropertyChanged("Parcela");
				}
			}
		}

		// Property IDAPagarForma
		//---------------------------------------------------------------
		public int IDAPagarForma
		{
			get => EditData._IDAPagarForma;
			set
			{
				if (value != EditData._IDAPagarForma)
				{
					EditData._IDAPagarForma = value;
					NotifyPropertyChanged("IDAPagarForma");
				}
			}
		}

		// Property APagarForma
		//---------------------------------------------------------------
		public string APagarForma
		{
			get => EditData._APagarForma;
			set => EditData._APagarForma = value;
		}

		// Property APagarValor
		//---------------------------------------------------------------
		public decimal APagarValor
		{
			get => EditData._APagarValor;
			set
			{
				if (value != EditData._APagarValor)
				{
					EditData._APagarValor = value;
					NotifyPropertyChanged("APagarValor");
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

		// Property Situacao
		//---------------------------------------------------------------
		public string Situacao
		{
			get
			{
				if (IDSituacao == 1 && Vencimento < DateTime.Today)
				{
					return "Vencida";
				}
				else
				{
					return EditData._Situacao;
				}
			}

			set => EditData._Situacao = value;
		}

		// Property IDBanco
		//---------------------------------------------------------------
		public int? IDBanco
		{
			get => EditData._IDBanco;
			set
			{
				if (value != EditData._IDBanco)
				{
					EditData._IDBanco = value;
					NotifyPropertyChanged("IDBanco");
				}
			}
		}

		// Property Banco
		//---------------------------------------------------------------
		public string Banco
		{
			get => EditData._Banco;
			set => EditData._Banco = value;
		}

		// Property Vencimento
		//---------------------------------------------------------------
		public DateTime Vencimento
		{
			get => EditData._Vencimento;
			set
			{
				if (value != EditData._Vencimento)
				{
					EditData._Vencimento = value;
					NotifyPropertyChanged("Vencimento");
				}
			}
		}

		// Property PagamentoData
		//---------------------------------------------------------------
		public DateTime? PagamentoData
		{
			get => EditData._PagamentoData;
			set
			{
				if (value != EditData._PagamentoData)
				{
					EditData._PagamentoData = value;
					NotifyPropertyChanged("PagamentoData");
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

		// Property ValorPago
		//---------------------------------------------------------------
		public decimal ValorPago
		{
			get => EditData._ValorPago;
			set
			{
				if (value != EditData._ValorPago)
				{
					EditData._ValorPago = value;
					NotifyPropertyChanged("ValorPago");
				}
			}
		}

		// Property ValorAcrescimo
		//---------------------------------------------------------------
		public decimal ValorAcrescimo
		{
			get => EditData._ValorAcrescimo;
			set
			{
				if (value != EditData._ValorAcrescimo)
				{
					EditData._ValorAcrescimo = value;
					NotifyPropertyChanged("ValorAcrescimo");
				}
			}
		}

		// Property ValorDesconto
		//---------------------------------------------------------------
		public decimal ValorDesconto
		{
			get => EditData._ValorDesconto;
			set
			{
				if (value != EditData._ValorDesconto)
				{
					EditData._ValorDesconto = value;
					NotifyPropertyChanged("ValorDesconto");
				}
			}
		}

		// Property ReferenciaMes
		//---------------------------------------------------------------
		public int? ReferenciaMes
		{
			get => EditData._ReferenciaMes;
			set
			{
				if (value != EditData._ReferenciaMes)
				{
					EditData._ReferenciaMes = value;
					NotifyPropertyChanged("ReferenciaMes");
				}
			}
		}

		// Property ReferenciaAno
		//---------------------------------------------------------------
		public int? ReferenciaAno
		{
			get => EditData._ReferenciaAno;
			set
			{
				if (value != EditData._ReferenciaAno)
				{
					EditData._ReferenciaAno = value;
					NotifyPropertyChanged("ReferenciaAno");
				}
			}
		}

		// Property Referencia
		//---------------------------------------------------------------
		public string Referencia
		{
			get
			{
				if (ReferenciaMes != null && ReferenciaAno != null)
				{
					DateTime dt = new DateTime((int)ReferenciaAno, (int)ReferenciaMes, 1);
					return dt.ToString("MMMM/yyyy");

				}
				else
				{
					return "Sem Referência...";
				}
			}
		}

		// Property IDCredor
		//---------------------------------------------------------------
		public int? IDCredor
		{
			get => EditData._IDCredor;
			set => EditData._IDCredor = value;
		}

		// Property Credor
		//---------------------------------------------------------------
		public string Credor
		{
			get => EditData._Credor;
			set => EditData._Credor = value;
		}

		// Property IDSetor
		//---------------------------------------------------------------
		public int IDSetor
		{
			get => EditData._IDSetor;
			set => EditData._IDSetor = value;
		}

		// Property Setor
		//---------------------------------------------------------------
		public string Setor
		{
			get => EditData._Setor;
			set => EditData._Setor = value;
		}

		// Property Imagem
		//---------------------------------------------------------------
		public objImagem Imagem
		{
			get
			{
				if (EditData._Imagem == null)
				{
					EditData._Imagem = new objImagem();
				}

				EditData._Imagem.Origem = EnumImagemOrigem.APagar;
				EditData._Imagem.ReferenceDate = Vencimento;
				if (IDAPagar != null) EditData._Imagem.IDOrigem = (long)IDAPagar;

				return EditData._Imagem;
			}

			set
			{
				EditData._Imagem = value;
			}
		}

	}

	//=================================================================================================
	// FORMAS DE COBRANCA
	//=================================================================================================
	public class objAPagarForma : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructCobranca
		{
			internal int? _IDAPagarForma;
			internal string _APagarForma;
			internal byte _IDPagFormaModo;
			internal string _PagFormaModo;
			internal int? _IDBanco;
			internal string _BancoNome;
			internal int? _IDCartaoCredito;
			internal bool _Ativo;
			internal objAPagarCartao _CartaoCredito;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructCobranca EditData;
		private StructCobranca BackupData;
		private bool inTxn = false;

		public objAPagarForma()
		{
			EditData = new StructCobranca()
			{
				_IDAPagarForma = null,
				_IDBanco = null,
				_IDCartaoCredito = null,
				_IDPagFormaModo = 1,
				_PagFormaModo = "Documento",
				_Ativo = true,
				_CartaoCredito = new objAPagarCartao(null),
			};
		}

		public objAPagarForma(int? IDAPagarForma) : base()
		{
			EditData._IDAPagarForma = IDAPagarForma;
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
				BackupData = new StructCobranca();
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
			return EditData._IDAPagarForma.ToString();
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public int? IDAPagarForma
		{
			get => EditData._IDAPagarForma;
			set => EditData._IDAPagarForma = value;
		}

		// Property APagarForma
		//---------------------------------------------------------------
		public string APagarForma
		{
			get => EditData._APagarForma;
			set
			{
				if (value != EditData._APagarForma)
				{
					EditData._APagarForma = value;
					NotifyPropertyChanged("APagarForma");
				}
			}
		}

		// Property IDPagFormaModo
		//---------------------------------------------------------------
		public byte IDPagFormaModo
		{
			get => EditData._IDPagFormaModo;
			set
			{
				if (value != EditData._IDPagFormaModo)
				{
					EditData._IDPagFormaModo = value;
					NotifyPropertyChanged("IDPagFormaModo");
				}
			}
		}

		// Property PagFormaModo
		//---------------------------------------------------------------
		public string PagFormaModo
		{
			get => EditData._PagFormaModo;
			set
			{
				if (value != EditData._PagFormaModo)
				{
					EditData._PagFormaModo = value;
					NotifyPropertyChanged("PagFormaModo");
				}
			}
		}

		// Property IDBanco
		//---------------------------------------------------------------
		public int? IDBanco
		{
			get => EditData._IDBanco;
			set
			{
				if (value != EditData._IDBanco)
				{
					EditData._IDBanco = value;
					NotifyPropertyChanged("IDBanco");
				}
			}
		}

		// Property Banco
		//---------------------------------------------------------------
		public string BancoNome
		{
			get => EditData._BancoNome;
			set => EditData._BancoNome = value;
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

		// Property IDCartaoCredito
		//---------------------------------------------------------------
		public int? IDCartaoCredito
		{
			get => EditData._IDCartaoCredito;
			set
			{
				if (value != EditData._IDCartaoCredito)
				{
					EditData._IDCartaoCredito = value;
					NotifyPropertyChanged("IDCartaoCredito");
				}
			}
		}

		// Property CartaoCredito
		//---------------------------------------------------------------
		public objAPagarCartao CartaoCredito
		{
			get
			{
				if (EditData._IDCartaoCredito == null)
				{
					return null;
				}
				else
				{
					if (EditData._CartaoCredito == null)
					{
						EditData._CartaoCredito = new objAPagarCartao(null);
					}

					return EditData._CartaoCredito;
				}
			}

			set
			{
				EditData._CartaoCredito = value;
			}
		}



	}

	//=================================================================================================
	// ACRESCIMO MOTIVO
	//=================================================================================================
	public class objAcrescimoMotivo : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructCobranca
		{
			internal byte? _IDAcrescimoMotivo;
			internal string _AcrescimoMotivo;
			internal bool _Ativo;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructCobranca EditData;
		private StructCobranca BackupData;
		private bool inTxn = false;

		public objAcrescimoMotivo()
		{
			EditData = new StructCobranca()
			{
				_IDAcrescimoMotivo = null,
				_AcrescimoMotivo = null,
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
				BackupData = new StructCobranca();
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
			return EditData._IDAcrescimoMotivo.ToString();
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public byte? IDAcrescimoMotivo
		{
			get => EditData._IDAcrescimoMotivo;
			set => EditData._IDAcrescimoMotivo = value;
		}

		// Property AcrescimoMotivo
		//---------------------------------------------------------------
		public string AcrescimoMotivo
		{
			get => EditData._AcrescimoMotivo;
			set
			{
				if (value != EditData._AcrescimoMotivo)
				{
					EditData._AcrescimoMotivo = value;
					NotifyPropertyChanged("AcrescimoMotivo");
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

	//=================================================================================================
	// DESPESA CARTAO DE CREDITO
	//=================================================================================================
	public class objAPagarCartao : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructCartao
		{
			internal int? _IDCartaoCredito;
			internal string _CartaoDescricao;
			internal byte _VencimentoDia;
			internal int? _IDCartaoBandeira;
			internal string _CartaoBandeira;
			internal string _CartaoNumeracao;
			internal int _IDCredor;
			internal string _Credor;
			internal int _IDSetor;
			internal string _Setor;
			internal bool _Ativo;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructCartao EditData;
		private StructCartao BackupData;
		private bool inTxn = false;

		public objAPagarCartao(int? IDCartaoCredito) : base()
		{
			EditData = new StructCartao()
			{
				_IDCartaoCredito = IDCartaoCredito,
				_CartaoDescricao = "",
				_VencimentoDia = 1,
				_Ativo = true,
			};
		}

		public objAPagarCartao()
		{
			EditData = new StructCartao()
			{
				_IDCartaoCredito = IDCartaoCredito,
				_CartaoDescricao = "",
				_VencimentoDia = 1,
				_Ativo = true,
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
				BackupData = new StructCartao();
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
			return EditData._CartaoDescricao;
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================

		// Property IDCartaoCredito
		//---------------------------------------------------------------
		public int? IDCartaoCredito
		{
			get => EditData._IDCartaoCredito;
			set
			{
				if (value != EditData._IDCartaoCredito)
				{
					EditData._IDCartaoCredito = value;
					NotifyPropertyChanged("IDCartaoCredito");
				}
			}
		}

		// Property CartaoDescricao
		//---------------------------------------------------------------
		public string CartaoDescricao
		{
			get => EditData._CartaoDescricao;
			set
			{
				if (value != EditData._CartaoDescricao)
				{
					EditData._CartaoDescricao = value;
					NotifyPropertyChanged("CartaoDescricao");
				}
			}
		}

		// Property VencimentoDia
		//---------------------------------------------------------------
		public byte VencimentoDia
		{
			get => EditData._VencimentoDia;
			set
			{
				if (value != EditData._VencimentoDia)
				{
					EditData._VencimentoDia = value;
					NotifyPropertyChanged("VencimentoDia");
				}
			}
		}

		// Property IDCartaoBandeira
		//---------------------------------------------------------------
		public int? IDCartaoBandeira
		{
			get => EditData._IDCartaoBandeira;
			set
			{
				if (value != EditData._IDCartaoBandeira)
				{
					EditData._IDCartaoBandeira = value;
					NotifyPropertyChanged("IDCartaoBandeira");
				}
			}
		}

		// Property CartaoBandeira
		//---------------------------------------------------------------
		public string CartaoBandeira
		{
			get => EditData._CartaoBandeira;
			set => EditData._CartaoBandeira = value;
		}

		// Property CartaoNumeracao
		//---------------------------------------------------------------
		public string CartaoNumeracao
		{
			get => EditData._CartaoNumeracao;
			set
			{
				if (value != EditData._CartaoNumeracao)
				{
					EditData._CartaoNumeracao = value;
					NotifyPropertyChanged("CartaoNumeracao");
				}
			}
		}

		// Property IDCredor
		//---------------------------------------------------------------
		public int IDCredorCartao
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
		public string CredorCartao
		{
			get => EditData._Credor;
			set => EditData._Credor = value;
		}

		// Property IDSetorCartao
		//---------------------------------------------------------------
		public int IDSetorCartao
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

		// Property SetorCartao
		//---------------------------------------------------------------
		public string SetorCartao
		{
			get => EditData._Setor;
			set => EditData._Setor = value;
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
