using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	//=================================================================================================
	// CARTAO TAXA
	//=================================================================================================
	public class objCartaoTaxa : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructCartao
		{
			internal int? _IDCartaoTaxa;
			internal int _IDCartaoOperadora;
			internal string _CartaoOperadora;
			internal int? _IDCartaoBandeira;
			internal string _CartaoBandeira;
			internal byte _PrazoDebito;
			internal byte _PrazoCredito;
			internal decimal? _TaxaDebito;
			internal decimal? _TaxaCredito;
			internal decimal? _Taxa2;
			internal decimal? _Taxa3;
			internal decimal? _Taxa4;
			internal decimal? _Taxa5;
			internal decimal? _Taxa6;
			internal decimal? _Taxa7;
			internal decimal? _Taxa8;
			internal decimal? _Taxa9;
			internal decimal? _Taxa10;
			internal decimal? _Taxa11;
			internal decimal? _Taxa12;
			internal bool _Ativo;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructCartao EditData;
		private StructCartao BackupData;
		private bool inTxn = false;

		public objCartaoTaxa(int? IDCartaoTaxa) : base()
		{
			EditData = new StructCartao()
			{
				_IDCartaoTaxa = IDCartaoTaxa,
				_PrazoDebito = 2,
				_PrazoCredito = 30,
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
			return EditData._IDCartaoTaxa?.ToString("D4");
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public int? IDCartaoTaxa
		{
			get => EditData._IDCartaoTaxa;
			set => EditData._IDCartaoTaxa = value;
		}

		// Property IDCartaoOperadora
		//---------------------------------------------------------------
		public int IDCartaoOperadora
		{
			get => EditData._IDCartaoOperadora;
			set
			{
				if (value != EditData._IDCartaoOperadora)
				{
					EditData._IDCartaoOperadora = value;
					NotifyPropertyChanged("IDCartaoOperadora");
				}
			}
		}

		// Property CartaoOperadora
		//---------------------------------------------------------------
		public string CartaoOperadora
		{
			get => EditData._CartaoOperadora;
			set => EditData._CartaoOperadora = value;
		}

		// Property IDContaProvisoria
		//---------------------------------------------------------------
		public int IDContaProvisoria { get; set; }

		// Property ContaProvisoria
		//---------------------------------------------------------------
		public string ContaProvisoria { get; set; }

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

		public string CartaoBandeira
		{
			get => (IDCartaoBandeira == null) ? "qualquer bandeira..." : EditData._CartaoBandeira;
			set => EditData._CartaoBandeira = value;
		}

		// Property PrazoDebito
		//---------------------------------------------------------------
		public byte PrazoDebito
		{
			get => EditData._PrazoDebito;
			set
			{
				if (value != EditData._PrazoDebito)
				{
					EditData._PrazoDebito = value;
					NotifyPropertyChanged("PrazoDebito");
				}
			}
		}

		// Property PrazoCredito
		//---------------------------------------------------------------
		public byte PrazoCredito
		{
			get => EditData._PrazoCredito;
			set
			{
				if (value != EditData._PrazoCredito)
				{
					EditData._PrazoCredito = value;
					NotifyPropertyChanged("PrazoCredito");
				}
			}
		}

		// Property TaxaDebito
		//---------------------------------------------------------------
		public decimal? TaxaDebito
		{
			get => EditData._TaxaDebito;
			set
			{
				if (value != EditData._TaxaDebito)
				{
					EditData._TaxaDebito = value;
					NotifyPropertyChanged("TaxaDebito");
				}
			}
		}

		// Property TaxaCredito
		//---------------------------------------------------------------
		public decimal? TaxaCredito
		{
			get => EditData._TaxaCredito;
			set
			{
				if (value != EditData._TaxaCredito)
				{
					EditData._TaxaCredito = value;
					NotifyPropertyChanged("TaxaCredito");
				}
			}
		}

		// Property Taxa2
		//---------------------------------------------------------------
		public decimal? Taxa2
		{
			get => EditData._Taxa2;
			set
			{
				if (value != EditData._Taxa2)
				{
					EditData._Taxa2 = value;
					NotifyPropertyChanged("Taxa2");
				}
			}
		}

		// Property Taxa3
		//---------------------------------------------------------------
		public decimal? Taxa3
		{
			get => EditData._Taxa3;
			set
			{
				if (value != EditData._Taxa3)
				{
					EditData._Taxa3 = value;
					NotifyPropertyChanged("Taxa3");
				}
			}
		}

		// Property Taxa4
		//---------------------------------------------------------------
		public decimal? Taxa4
		{
			get => EditData._Taxa4;
			set
			{
				if (value != EditData._Taxa4)
				{
					EditData._Taxa4 = value;
					NotifyPropertyChanged("Taxa4");
				}
			}
		}

		// Property Taxa5
		//---------------------------------------------------------------
		public decimal? Taxa5
		{
			get => EditData._Taxa5;
			set
			{
				if (value != EditData._Taxa5)
				{
					EditData._Taxa5 = value;
					NotifyPropertyChanged("Taxa5");
				}
			}
		}

		// Property Taxa6
		//---------------------------------------------------------------
		public decimal? Taxa6
		{
			get => EditData._Taxa6;
			set
			{
				if (value != EditData._Taxa6)
				{
					EditData._Taxa6 = value;
					NotifyPropertyChanged("Taxa6");
				}
			}
		}

		// Property Taxa7
		//---------------------------------------------------------------
		public decimal? Taxa7
		{
			get => EditData._Taxa7;
			set
			{
				if (value != EditData._Taxa7)
				{
					EditData._Taxa7 = value;
					NotifyPropertyChanged("Taxa7");
				}
			}
		}

		// Property Taxa8
		//---------------------------------------------------------------
		public decimal? Taxa8
		{
			get => EditData._Taxa8;
			set
			{
				if (value != EditData._Taxa8)
				{
					EditData._Taxa8 = value;
					NotifyPropertyChanged("Taxa8");
				}
			}
		}

		// Property Taxa9
		//---------------------------------------------------------------
		public decimal? Taxa9
		{
			get => EditData._Taxa9;
			set
			{
				if (value != EditData._Taxa9)
				{
					EditData._Taxa9 = value;
					NotifyPropertyChanged("Taxa9");
				}
			}
		}

		// Property Taxa10
		//---------------------------------------------------------------
		public decimal? Taxa10
		{
			get => EditData._Taxa10;
			set
			{
				if (value != EditData._Taxa10)
				{
					EditData._Taxa10 = value;
					NotifyPropertyChanged("Taxa10");
				}
			}
		}

		// Property Taxa11
		//---------------------------------------------------------------
		public decimal? Taxa11
		{
			get => EditData._Taxa11;
			set
			{
				if (value != EditData._Taxa11)
				{
					EditData._Taxa11 = value;
					NotifyPropertyChanged("Taxa11");
				}
			}
		}

		// Property Taxa12
		//---------------------------------------------------------------
		public decimal? Taxa12
		{
			get => EditData._Taxa12;
			set
			{
				if (value != EditData._Taxa12)
				{
					EditData._Taxa12 = value;
					NotifyPropertyChanged("Taxa12");
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
	// CARTAO OPERADORA
	//=================================================================================================
	public class objCartaoOperadora
	{
		public int IDCartaoOperadora { get; set; }
		public string CartaoOperadora { get; set; }
		public int IDConta { get; set; }
		public string Conta { get; set; }
		public bool Ativa { get; set; }
	}

	//=================================================================================================
	// CARTAO BANDEIRA
	//=================================================================================================
	public class objCartaoBandeira
	{
		public int IDCartaoBandeira { get; set; }
		public string CartaoBandeira { get; set; }
		public bool Ativa { get; set; }
	}
}
