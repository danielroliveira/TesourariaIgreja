using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	public class objDespesaProvisoria : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructDespesa
		{
			internal long? _IDProvisorio;
			internal string _Finalidade;
			internal string _Autorizante;
			internal decimal _ValorProvisorio;
			internal DateTime _RetiradaData;
			internal string _Comprador;
			internal DateTime? _DevolucaoData;
			internal decimal? _ValorRealizado;
			internal int _IDConta;
			internal string _Conta;
			internal int _IDSetor;
			internal string _Setor;
			internal decimal _ContaSaldo;
			internal DateTime? _BloqueioData;
			internal bool _Concluida;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructDespesa EditData;
		private StructDespesa BackupData;
		private bool inTxn = false;

		public objDespesaProvisoria(long? IDProvisorio) : base()
		{
			EditData = new StructDespesa()
			{
				_IDProvisorio = IDProvisorio,
				_Finalidade = "",
				_RetiradaData = DateTime.Today,
				_ValorProvisorio = 0,
				_Concluida = false,
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
			return EditData._Finalidade;
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public long? IDProvisorio
		{
			get => EditData._IDProvisorio;
			set => EditData._IDProvisorio = value;
		}

		// Property Finalidade
		//---------------------------------------------------------------
		public string Finalidade
		{
			get => EditData._Finalidade;
			set
			{
				if (value != EditData._Finalidade)
				{
					EditData._Finalidade = value;
					NotifyPropertyChanged("Finalidade");
				}
			}
		}

		// Property Autorizante
		//---------------------------------------------------------------
		public string Autorizante
		{
			get => EditData._Autorizante;
			set
			{
				if (value != EditData._Autorizante)
				{
					EditData._Autorizante = value;
					NotifyPropertyChanged("Autorizante");
				}
			}
		}

		// Property ValorProvisorio
		//---------------------------------------------------------------
		public decimal ValorProvisorio
		{
			get => EditData._ValorProvisorio;
			set
			{
				if (value != EditData._ValorProvisorio)
				{
					EditData._ValorProvisorio = value;
					NotifyPropertyChanged("ValorProvisorio");
				}
			}
		}

		// Property RetiradaData
		//---------------------------------------------------------------
		public DateTime RetiradaData
		{
			get => EditData._RetiradaData;
			set
			{
				if (value != EditData._RetiradaData)
				{
					EditData._RetiradaData = value;
					NotifyPropertyChanged("RetiradaData");
				}
			}
		}

		// Property Comprador
		//---------------------------------------------------------------
		public string Comprador
		{
			get => EditData._Comprador;
			set
			{
				if (value != EditData._Comprador)
				{
					EditData._Comprador = value;
					NotifyPropertyChanged("Comprador");
				}
			}
		}

		// Property ValorRealizado
		//---------------------------------------------------------------
		public decimal? ValorRealizado
		{
			get => EditData._ValorRealizado;
			set
			{
				if (value != EditData._ValorRealizado)
				{
					EditData._ValorRealizado = value;
					NotifyPropertyChanged("ValorRealizado");
				}
			}
		}

		// Property DevolucaoData
		//---------------------------------------------------------------
		public DateTime? DevolucaoData
		{
			get => EditData._DevolucaoData;
			set
			{
				if (value != EditData._DevolucaoData)
				{
					EditData._DevolucaoData = value;
					NotifyPropertyChanged("DevolucaoData");
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
			set => EditData._Setor = value;
		}

		// Property BloqueioData
		//---------------------------------------------------------------
		public DateTime? BloqueioData
		{
			get => EditData._BloqueioData;
			set => EditData._BloqueioData = value;
		}

		// Property Concluida
		//---------------------------------------------------------------
		public bool Concluida
		{
			get => EditData._Concluida;
			set
			{
				if (value != EditData._Concluida)
				{
					EditData._Concluida = value;
					NotifyPropertyChanged("Concluida");
				}
			}
		}

		// Recibo Texto
		//------------------------------------------------------------------------------------------------------------
		public string ReciboTexto { get; set; }

	}
}
