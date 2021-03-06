﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	//=================================================================================================
	// ENTRADA
	//=================================================================================================
	public class objAReceber : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructAReceber
		{
			internal long? _IDAReceber;
			internal long _IDContribuicao;
			internal DateTime _CompensacaoData;
			internal decimal _ValorBruto;
			internal decimal _ValorLiquido;
			internal decimal _ValorRecebido;
			internal int _IDContaProvisoria;
			internal long _IDMovProvisoria; // ID movimentacao de entrada na conta provisoria
			internal string _Conta;
			internal int? _IDSetor;
			internal byte _IDSituacao; // 1: EmAberto | 2: Recebido | 3: Cancelada
			internal string _Situacao; // 1: EmAberto | 2: Recebido | 3: Cancelada
			internal byte _IDEntradaForma;
			internal string _EntradaForma;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructAReceber EditData;
		private StructAReceber BackupData;
		private bool inTxn = false;

		public objAReceber(long? IDAReceber) : base()
		{
			EditData = new StructAReceber()
			{
				_IDAReceber = IDAReceber,
				_CompensacaoData = DateTime.Today,
				_ValorBruto = 0,
				_ValorLiquido = 0,
				_ValorRecebido = 0,
				_IDSituacao = 1,
				_Situacao = "Em Aberto",
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
				BackupData = new StructAReceber();
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
			return EditData._IDAReceber?.ToString("D4");
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public long? IDAReceber
		{
			get => EditData._IDAReceber;
			set => EditData._IDAReceber = value;
		}

		// Property IDContribuicao
		//---------------------------------------------------------------
		public long IDContribuicao
		{
			get => EditData._IDContribuicao;
			set
			{
				if (value != EditData._IDContribuicao)
				{
					EditData._IDContribuicao = value;
					NotifyPropertyChanged("IDContribuicao");
				}
			}
		}

		// Property CompensacaoData
		//---------------------------------------------------------------
		public DateTime CompensacaoData
		{
			get => EditData._CompensacaoData;
			set
			{
				if (value != EditData._CompensacaoData)
				{
					EditData._CompensacaoData = value;
					NotifyPropertyChanged("CompensacaoData");
				}
			}
		}

		// Property ValorBruto
		//---------------------------------------------------------------
		public decimal ValorBruto
		{
			get => EditData._ValorBruto;
			set
			{
				if (value != EditData._ValorBruto)
				{
					EditData._ValorBruto = value;
					NotifyPropertyChanged("ValorBruto");
				}
			}
		}

		// Property ValorLiquido
		//---------------------------------------------------------------
		public decimal ValorLiquido
		{
			get => EditData._ValorLiquido;
			set
			{
				if (value != EditData._ValorLiquido)
				{
					EditData._ValorLiquido = value;
					NotifyPropertyChanged("ValorLiquido");
				}
			}
		}

		// Property ValorRecebido
		//---------------------------------------------------------------
		public decimal ValorRecebido
		{
			get => EditData._ValorRecebido;
			set
			{
				if (value != EditData._ValorRecebido)
				{
					EditData._ValorRecebido = value;
					NotifyPropertyChanged("ValorRecebido");
				}
			}
		}

		// Property IDContaProvisoria
		//---------------------------------------------------------------
		public int IDContaProvisoria
		{
			get => EditData._IDContaProvisoria;
			set
			{
				if (value != EditData._IDContaProvisoria)
				{
					EditData._IDContaProvisoria = value;
					NotifyPropertyChanged("IDContaProvisoria");
				}
			}
		}

		// Property IDMovProvisoria
		//---------------------------------------------------------------
		public long IDMovProvisoria
		{
			get => EditData._IDMovProvisoria;
			set
			{
				if (value != EditData._IDMovProvisoria)
				{
					EditData._IDMovProvisoria = value;
					NotifyPropertyChanged("IDMovProvisoria");
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

		// Property IDSetor
		//---------------------------------------------------------------
		public int? IDSetor
		{
			get => EditData._IDSetor;
			set => EditData._IDSetor = value;
		}

		// Property Situacao
		//---------------------------------------------------------------
		public byte IDSituacao
		{
			get => EditData._IDSituacao;
			set
			{
				if (value != EditData._IDSituacao)
				{
					EditData._IDSituacao = value;
					NotifyPropertyChanged("Situacao");
				}
			}
		}

		// Property Situacao
		//---------------------------------------------------------------
		public string Situacao
		{
			get
			{
				if (IDSituacao == 1 && CompensacaoData < DateTime.Today)
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

		// Property IDEntradaForma
		//---------------------------------------------------------------
		public byte IDEntradaForma
		{
			get => EditData._IDEntradaForma;
			set => EditData._IDEntradaForma = value;
		}

		// Property EntradaForma
		//---------------------------------------------------------------
		public string EntradaForma
		{
			get => EditData._EntradaForma;
			set => EditData._EntradaForma = value;
		}
	}

	//=================================================================================================
	// ENTRADA FORMA
	//=================================================================================================
	public class objAReceberForma : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructAReceber
		{
			internal byte? _IDAReceberForma;
			internal string _AReceberForma;
			internal bool _Ativa;
			internal byte _CompensacaoDias;
			internal decimal _TaxaComissao;
			internal int? _IDContaProvisoria;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructAReceber EditData;
		private StructAReceber BackupData;
		private bool inTxn = false;

		public objAReceberForma(byte? IDAReceberForma) : base()
		{
			EditData = new StructAReceber()
			{
				_IDAReceberForma = IDAReceberForma,
				_AReceberForma = "",
				_Ativa = true,
				_CompensacaoDias = 0,
				_TaxaComissao = 0,
				_IDContaProvisoria = null,
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
				BackupData = new StructAReceber();
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
			return EditData._AReceberForma;
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public byte? IDAReceberForma
		{
			get => EditData._IDAReceberForma;
			set => EditData._IDAReceberForma = value;
		}

		// Property AReceberForma
		//---------------------------------------------------------------
		public string AReceberForma
		{
			get => EditData._AReceberForma;
			set
			{
				if (value != EditData._AReceberForma)
				{
					EditData._AReceberForma = value;
					NotifyPropertyChanged("AReceberForma");
				}
			}
		}

		// Property Ativa
		//---------------------------------------------------------------
		public bool Ativa
		{
			get => EditData._Ativa;
			set
			{
				if (value != EditData._Ativa)
				{
					EditData._Ativa = value;
					NotifyPropertyChanged("Ativa");
				}
			}
		}

		// Property CompensacaoDias
		//---------------------------------------------------------------
		public byte CompensacaoDias
		{
			get => EditData._CompensacaoDias;
			set
			{
				if (value != EditData._CompensacaoDias)
				{
					EditData._CompensacaoDias = value;
					NotifyPropertyChanged("CompensacaoDias");
				}
			}
		}

		// Property TaxaComissao
		//---------------------------------------------------------------
		public decimal TaxaComissao
		{
			get => EditData._TaxaComissao;
			set
			{
				if (value != EditData._TaxaComissao)
				{
					EditData._TaxaComissao = value;
					NotifyPropertyChanged("TaxaComissao");
				}
			}
		}

		// Property IDContaProvisoria
		//---------------------------------------------------------------
		public int? IDContaProvisoria
		{
			get => EditData._IDContaProvisoria;
			set
			{
				if (value != EditData._IDContaProvisoria)
				{
					EditData._IDContaProvisoria = value;
					NotifyPropertyChanged("IDContaProvisoria");
				}
			}
		}
	}

}
