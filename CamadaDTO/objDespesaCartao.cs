using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	//=================================================================================================
	// DESPESA
	//=================================================================================================
	public class objDespesaCartao : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructDespesa
		{
			internal long? _IDDespesaCartao;
			internal long _IDDespesaDestino;
			internal string _DespesaDescricao;
			internal DateTime _DespesaData;
			internal decimal _DespesaValor;
			internal string _DocumentoNumero;
			internal int _IDCredor;
			internal string _Credor;

			internal int _IDDespesaTipo;
			internal string _DespesaTipo;
			internal byte _IDDocumentoTipo;
			internal string _DocumentoTipo;
			internal int _IDSetor;
			internal string _Setor;
			internal byte _IDSituacao;
			internal string _Situacao;
			internal byte _Parcelas;
			internal DateTime? _ParcelaDataInicial;
			internal DateTime? _ParcelaDataFinal;
			internal int _IDCartaoCredito;
			internal string _CartaoDescricao;
			internal byte _VencimentoDia;

			// from tblImagem
			internal objImagem _Imagem;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructDespesa EditData;
		private StructDespesa BackupData;
		private bool inTxn = false;

		public objDespesaCartao(long? IDDespesaCartao) : base()
		{
			EditData = new StructDespesa()
			{
				_IDDespesaCartao = IDDespesaCartao,
				_DespesaDescricao = "",
				_DespesaData = DateTime.Today,
				_DespesaValor = 0,
				_IDSituacao = 1,
				_Parcelas = 1,
				_Imagem = new objImagem()
				{
					Origem = EnumImagemOrigem.Despesa,
				},
				_ParcelaDataFinal = null,
				_ParcelaDataInicial = null,
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
		public long? IDDespesaCartao
		{
			get => EditData._IDDespesaCartao;
			set => EditData._IDDespesaCartao = value;
		}

		// Property IDDespesaDestino
		//---------------------------------------------------------------
		public long IDDespesaDestino
		{
			get => EditData._IDDespesaDestino;
			set
			{
				if (value != EditData._IDDespesaDestino)
				{
					EditData._IDDespesaDestino = value;
					NotifyPropertyChanged("IDDespesa");
				}
			}
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

				EditData._Imagem.Origem = EnumImagemOrigem.Despesa;
				EditData._Imagem.ReferenceDate = DespesaData;
				if (IDDespesaCartao != null) EditData._Imagem.IDOrigem = (long)IDDespesaCartao;
				return EditData._Imagem;
			}

			set
			{
				EditData._Imagem = value;
			}
		}

		// Property DataInicial
		//---------------------------------------------------------------
		public DateTime? ParcelaDataInicial
		{
			get => EditData._ParcelaDataInicial;
			set
			{
				if (value != EditData._ParcelaDataInicial)
				{
					EditData._ParcelaDataInicial = value;
					NotifyPropertyChanged("DataInicial");
				}
			}
		}

		// Property DataFinal
		//---------------------------------------------------------------
		public DateTime? ParcelaDataFinal
		{
			get => EditData._ParcelaDataFinal;
			set
			{
				if (value != EditData._ParcelaDataFinal)
				{
					EditData._ParcelaDataFinal = value;
					NotifyPropertyChanged("DataFinal");
				}
			}
		}

		// Property IDCartaoCredito
		//---------------------------------------------------------------
		public int IDCartaoCredito
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
			set => EditData._CartaoDescricao = value;
		}

		// Property VencimentoDia
		//---------------------------------------------------------------
		public byte VencimentoDia
		{
			get => EditData._VencimentoDia;
			set => EditData._VencimentoDia = value;
		}

	}


	public class objCartaoCreditoDespesa
	{
		public int IDCartaoCredito { get; set; }
		public string CartaoDescricao { get; set; }
		public byte VencimentoDia { get; set; }
		public int? IDCartaoBandeira { get; set; }
		public string CartaoBandeira { get; set; }
		public string CartaoNumeracao { get; set; }
		public int IDCredor { get; set; }
		public string Credor { get; set; }
		public int IDSetor { get; set; }
		public string Setor { get; set; }
		public bool Ativo { get; set; }

	}
}
