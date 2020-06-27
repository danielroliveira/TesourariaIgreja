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
			internal int _IDCobrancaForma;
			internal string _CobrancaForma;
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
			internal bool _Imagem;
			internal int? _IDCredor;
			internal string _Credor;
			internal int _IDSetor;
			internal string _Setor;
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
				_IDCobrancaForma = 1,
				_APagarValor = 0,
				_IDSituacao = 1,
				_IDBanco = null,
				_Prioridade = 1,
				_ValorPago = 0,
				_ValorAcrescimo = 0,
				_ValorDesconto = 0,
				_Imagem = false,
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

		// Property IDCobrancaForma
		//---------------------------------------------------------------
		public int IDCobrancaForma
		{
			get => EditData._IDCobrancaForma;
			set
			{
				if (value != EditData._IDCobrancaForma)
				{
					EditData._IDCobrancaForma = value;
					NotifyPropertyChanged("IDCobrancaForma");
				}
			}
		}

		// Property CobrancaForma
		//---------------------------------------------------------------
		public string CobrancaForma
		{
			get => EditData._CobrancaForma;
			set => EditData._CobrancaForma = value;
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

	}

	//=================================================================================================
	// FORMAS DE COBRANCA
	//=================================================================================================
	public class objCobrancaForma : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructCobranca
		{
			internal int? _IDCobrancaForma;
			internal string _CobrancaForma;
			internal int? _IDBanco;
			internal string _BancoNome;
			internal int? _IDCartaoBandeira;
			internal string _CartaoBandeira;
			internal bool _Ativo;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructCobranca EditData;
		private StructCobranca BackupData;
		private bool inTxn = false;

		public objCobrancaForma()
		{
			EditData = new StructCobranca()
			{
				_IDCobrancaForma = null,
				_IDBanco = null,
				_IDCartaoBandeira = null,
				_Ativo = true
			};
		}

		public objCobrancaForma(int? IDCobrancaForma) : base()
		{
			EditData._IDCobrancaForma = IDCobrancaForma;
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
			return EditData._IDCobrancaForma.ToString();
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public int? IDCobrancaForma
		{
			get => EditData._IDCobrancaForma;
			set => EditData._IDCobrancaForma = value;
		}

		// Property CobrancaForma
		//---------------------------------------------------------------
		public string CobrancaForma
		{
			get => EditData._CobrancaForma;
			set
			{
				if (value != EditData._CobrancaForma)
				{
					EditData._CobrancaForma = value;
					NotifyPropertyChanged("CobrancaForma");
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

}
