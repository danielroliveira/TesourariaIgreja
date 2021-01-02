
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	//=================================================================================================
	// CLASSE CAIXA AJUSTE
	//=================================================================================================
	public class objCaixa : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructAjuste
		{
			internal long? _IDCaixa;
			internal DateTime _FechamentoData;

			internal int _IDConta;
			internal string _Conta;
			internal decimal _ContaSaldo;
			internal DateTime? _ContaBloqueioData;

			internal byte _IDSituacao;
			internal string _Situacao;

			internal DateTime _DataInicial;
			internal DateTime _DataFinal;

			internal decimal _SaldoAnterior;
			internal decimal _SaldoFinal;

			internal int _IDUsuario;
			internal string _UsuarioApelido;

			internal bool _CaixaFinalDoDia;
			internal string _Observacao;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructAjuste EditData;
		private StructAjuste BackupData;
		private bool inTxn = false;

		public objCaixa(long? IDCaixa) : base()
		{
			EditData = new StructAjuste()
			{
				_IDCaixa = IDCaixa,
				_FechamentoData = DateTime.Today,
				_IDSituacao = 1,
				_Situacao = "Iniciado",
				_CaixaFinalDoDia = false,
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
				BackupData = new StructAjuste();
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
			return EditData._IDCaixa == null ? "NOVO" : ((long)IDCaixa).ToString("D4");
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public long? IDCaixa
		{
			get => EditData._IDCaixa;
			set => EditData._IDCaixa = value;
		}

		// Property FechamentoData
		//---------------------------------------------------------------
		public DateTime FechamentoData
		{
			get => EditData._FechamentoData;
			set
			{
				if (value != EditData._FechamentoData)
				{
					EditData._FechamentoData = value;
					NotifyPropertyChanged("FechamentoData");
				}
			}
		}

		// Property IDConta
		//---------------------------------------------------------------
		public int IDConta
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

		// Property Conta
		//---------------------------------------------------------------
		public string Conta
		{
			get => EditData._Conta;
			set => EditData._Conta = value;
		}

		// Property ContaSaldo
		//---------------------------------------------------------------
		public decimal ContaSaldo
		{
			get => EditData._ContaSaldo;
			set => EditData._ContaSaldo = value;
		}

		// Property ContaBloqueioData
		//---------------------------------------------------------------
		public DateTime? ContaBloqueioData
		{
			get => EditData._ContaBloqueioData;
			set => EditData._ContaBloqueioData = value;
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

		// Property SaldoAnterior
		//---------------------------------------------------------------
		public decimal SaldoAnterior
		{
			get => EditData._SaldoAnterior;
			set
			{
				if (value != EditData._SaldoAnterior)
				{
					EditData._SaldoAnterior = value;
					NotifyPropertyChanged("SaldoAnterior");
				}
			}
		}

		// Property SaldoFinal
		//---------------------------------------------------------------
		public decimal SaldoFinal
		{
			get => EditData._SaldoFinal;
			set
			{
				if (value != EditData._SaldoFinal)
				{
					EditData._SaldoFinal = value;
					NotifyPropertyChanged("SaldoFinal");
				}
			}
		}

		// Property IDUsuario
		//---------------------------------------------------------------
		public int IDUsuario
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

		// Property UsuarioApelido
		//---------------------------------------------------------------
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

		// Property CaixaFinalDoDia
		//---------------------------------------------------------------
		public bool CaixaFinalDoDia
		{
			get => EditData._CaixaFinalDoDia;
			set
			{
				if (value != EditData._CaixaFinalDoDia)
				{
					EditData._CaixaFinalDoDia = value;
					NotifyPropertyChanged("CaixaFinalDoDia");
				}
			}
		}

		// Property Observacao
		//---------------------------------------------------------------
		public string Observacao
		{
			get => EditData._Observacao;
			set
			{
				if (value != EditData._Observacao)
				{
					EditData._Observacao = value;
					NotifyPropertyChanged("Observacao");
				}
			}
		}
	}
}
