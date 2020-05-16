using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	public class objAPagar : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructAPagar
		{
			internal int? _IDAPagar;
			internal int _IDDespesa;
			internal string _DespesaDescricao;
			internal string _Identificador;
			internal byte? _Parcela;
			internal byte _IDCobrancaForma;
			internal string _CobrancaForma;
			internal int? _IDAPagarCartao;
			internal string _CartaoDescricao;
			internal decimal _APagarValor;
			internal byte _IDSituacao;
			internal string _Situacao;
			internal DateTime _Vencimento;
			internal DateTime? _PagamentoData;
			internal byte _Prioridade;
			internal decimal _ValorPago;
			internal int _ReferenciaMes;
			internal int _ReferenciaAno;
			internal bool _Imagem;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructAPagar EditData;
		private StructAPagar BackupData;
		private bool inTxn = false;

		public objAPagar(int? IDAPagar) : base()
		{
			EditData = new StructAPagar()
			{
				_IDAPagar = IDAPagar,
				_Parcela = 1,
				_IDCobrancaForma = 1,
				_APagarValor = 0,
				_IDSituacao = 1,
				_Prioridade = 1,
				_ValorPago = 0,
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
		public int? IDAPagar
		{
			get => EditData._IDAPagar;
			set => EditData._IDAPagar = value;
		}

		// Property IDDespesa
		//---------------------------------------------------------------
		public int IDDespesa
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
		public byte IDCobrancaForma
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

		// Property IDAPagarCartao
		//---------------------------------------------------------------
		public int? IDAPagarCartao
		{
			get => EditData._IDAPagarCartao;
			set
			{
				if (value != EditData._IDAPagarCartao)
				{
					EditData._IDAPagarCartao = value;
					NotifyPropertyChanged("IDAPagarCartao");
				}
			}
		}

		// Property CartaoDescricao
		//---------------------------------------------------------------
		public string CartaoDescricao
		{
			get => EditData._CartaoDescricao;
			set => EditData._CartaoDescricao = value;
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
			get => EditData._Situacao;
			set => EditData._Situacao = value;
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

		// Property ReferenciaMes
		//---------------------------------------------------------------
		public int ReferenciaMes
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
		public int ReferenciaAno
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
}
