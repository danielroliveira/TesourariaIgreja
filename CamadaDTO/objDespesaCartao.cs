using System;
using System.ComponentModel;

namespace CamadaDTO
{
	//=================================================================================================
	// DESPESA
	//=================================================================================================
	public class objDespesaCartao : objDespesa, IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructCartao
		{
			internal DateTime _ReferenciaData;
			internal byte _IDSituacao;
			internal string _Situacao;
			internal int _IDCartaoCredito;
			internal string _CartaoDescricao;
			internal byte _VencimentoDia;

			// from tblImagem
			internal objImagem _Imagem;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructCartao EditDataCartao;
		private StructCartao BackupDataCartao;

		public objDespesaCartao(long? IDDespesaCartao) : base(IDDespesaCartao)
		{
			DespesaOrigem = 3;

			EditDataCartao = new StructCartao()
			{
				_IDSituacao = 1,
				_Situacao = "Em Aberto",
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
				BackupDataCartao = EditDataCartao;
				inTxn = true;
			}
		}

		public void CancelEdit()
		{
			if (inTxn)
			{
				EditData = BackupData;
				EditDataCartao = BackupDataCartao;
				inTxn = false;
			}
		}

		public void EndEdit()
		{
			if (inTxn)
			{
				BackupData = new StructDespesa();
				BackupDataCartao = new StructCartao();
				inTxn = false;
			}
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================

		// Property ReferenciaData
		//---------------------------------------------------------------
		public DateTime ReferenciaData
		{
			get => EditDataCartao._ReferenciaData;
			set
			{
				if (value != EditDataCartao._ReferenciaData)
				{
					EditDataCartao._ReferenciaData = value;
					NotifyPropertyChanged("ReferenciaData");
				}
			}
		}

		// Property IDSituacao
		//---------------------------------------------------------------
		public byte IDSituacao
		{
			get => EditDataCartao._IDSituacao;
			set
			{
				if (value != EditDataCartao._IDSituacao)
				{
					EditDataCartao._IDSituacao = value;
					NotifyPropertyChanged("IDSituacao");
				}
			}
		}

		// Property Situacao
		//---------------------------------------------------------------
		public string Situacao
		{
			get => EditDataCartao._Situacao;
			set => EditDataCartao._Situacao = value;
		}

		// Property IDCartaoCredito
		//---------------------------------------------------------------
		public int IDCartaoCredito
		{
			get => EditDataCartao._IDCartaoCredito;
			set
			{
				if (value != EditDataCartao._IDCartaoCredito)
				{
					EditDataCartao._IDCartaoCredito = value;
					NotifyPropertyChanged("IDCartaoCredito");
				}
			}
		}

		// Property CartaoDescricao
		//---------------------------------------------------------------
		public string CartaoDescricao
		{
			get => EditDataCartao._CartaoDescricao;
			set => EditDataCartao._CartaoDescricao = value;
		}

		// Property VencimentoDia
		//---------------------------------------------------------------
		public byte VencimentoDia
		{
			get => EditDataCartao._VencimentoDia;
			set => EditDataCartao._VencimentoDia = value;
		}

		// Property Imagem
		//---------------------------------------------------------------
		public objImagem Imagem
		{
			get
			{
				if (EditDataCartao._Imagem == null)
				{
					EditDataCartao._Imagem = new objImagem();
				}

				EditDataCartao._Imagem.Origem = EnumImagemOrigem.Despesa;
				EditDataCartao._Imagem.ReferenceDate = DespesaData;
				if (IDDespesa != null) EditDataCartao._Imagem.IDOrigem = (long)IDDespesa;
				return EditDataCartao._Imagem;
			}
			set
			{
				EditDataCartao._Imagem = value;
			}
		}
	}

}
