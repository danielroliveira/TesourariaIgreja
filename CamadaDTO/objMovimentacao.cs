using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	//=================================================================================================
	// CLASS MOVIMENTACAO
	//=================================================================================================
	public class objMovimentacao : IEditableObject, INotifyPropertyChanged
	{

		/* --- ORIGEM
		//-------------------------------------------------------------------------------------------------
		1:	tblContribuicao	| IDContribuicao
		2:	tblAReceber		| IDAReceber
		3:	tblAPagar		| IDAPagar
		4:	tblCaixaAjuste	| IDAjuste
		5:	tblTransfConta	| IDTransfConta
		6:	tblTransfSetor	| IDTransfSetor
		*/

		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		protected struct StructMov
		{
			internal long? _IDMovimentacao;
			internal byte _MovTipo; // 1: ENTRADA | 2: SAIDA | 3: TRANSFERENCIA
			internal string _MovTipoDescricao; // ENTRADA | SAIDA | TRANSFERENCIA
			internal byte _Origem;
			internal long _IDOrigem;
			internal int? _IDConta;
			internal string _Conta;
			internal int? _IDSetor;
			internal string _Setor;
			internal DateTime _MovData;
			internal decimal _MovValor;
			internal decimal _MovValorAbsoluto;
			internal long? _IDCaixa;
			internal string _DescricaoOrigem;
			internal bool _Consolidado;
			internal string _Observacao;

			// tblMovAcrescimo
			internal decimal? _AcrescimoValor;
			internal byte? _IDAcrescimoMotivo;
			internal string _AcrescimoMotivo;

			// tblImagem
			internal objImagem _Imagem;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		protected StructMov EditData;
		protected StructMov BackupData;
		private bool inTxn = false;

		public objMovimentacao(long? IDMovimentacao) : base()
		{
			EditData = new StructMov()
			{
				_IDMovimentacao = IDMovimentacao,
				_MovData = DateTime.Today,
				_MovValor = 0,
				_IDCaixa = null,
				_Consolidado = true,
				_AcrescimoValor = null,
				_IDAcrescimoMotivo = null,
				_AcrescimoMotivo = "",
				_Imagem = new objImagem()
				{
					ImagemFileName = "",
					ImagemPath = "",
					Origem = EnumImagemOrigem.Movimentacao,
				}
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
				BackupData = new StructMov();
				inTxn = false;
			}
		}

		// PROPERTY CHANGED
		//------------------------------------------------------------------------------------------------------------
		public event PropertyChangedEventHandler PropertyChanged;

		protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public override string ToString()
		{
			return EditData._IDMovimentacao?.ToString("D4");
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public long? IDMovimentacao
		{
			get => EditData._IDMovimentacao;
			set => EditData._IDMovimentacao = value;
		}

		// Property MovTipo
		//---------------------------------------------------------------
		public byte MovTipo // 1: ENTRADA | 2: SAIDA | 3: TRANSFERENCIA
		{
			get => EditData._MovTipo;
			set => EditData._MovTipo = value;
		}

		// Property MovTipoDescricao
		//---------------------------------------------------------------
		public string MovTipoDescricao
		{
			get => EditData._MovTipoDescricao;
			set => EditData._MovTipoDescricao = value;
		}

		// Property MovTipoSigla
		//---------------------------------------------------------------
		public string MovTipoSigla
		{
			get
			{
				if (string.IsNullOrEmpty(MovTipoDescricao)) return "";
				return MovTipoDescricao.Substring(0, 1).ToUpper();
			}
		}

		// Property IDOrigem
		//---------------------------------------------------------------
		public long IDOrigem
		{
			get => EditData._IDOrigem;
			set
			{
				if (value != EditData._IDOrigem)
				{
					EditData._IDOrigem = value;
					NotifyPropertyChanged("IDOrigem");
				}
			}
		}

		// Property Origem
		//---------------------------------------------------------------
		public EnumMovOrigem Origem
		{
			get => (EnumMovOrigem)EditData._Origem;
			set
			{
				if (value != (EnumMovOrigem)EditData._Origem)
				{
					EditData._Origem = (byte)value;
					NotifyPropertyChanged("Origem");
				}
			}
		}

		// Property MovData
		//---------------------------------------------------------------
		public DateTime MovData
		{
			get => EditData._MovData;
			set
			{
				if (value != EditData._MovData)
				{
					EditData._MovData = value;
					NotifyPropertyChanged("MovData");
				}
			}
		}

		public int MovDia
		{
			get => MovData.Day;
			set
			{
				try
				{
					// format new Date
					string testDate = $"{value}/{MovData.Month}/{MovData.Year}";

					// check new date
					if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
					{
						MovData = newDate;
					}
					else
					{
						throw new AttributeException($"Data inválida:\n" +
							$"{value.ToString("D2") } / { MovData.Month.ToString("D2") } / {MovData.Year.ToString("D4")}\n" +
							$"Favor verificar o dia, mês e ano e inserir uma data válida.");
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}

			}
		}

		public int MovMes
		{
			get => MovData.Month;
			set
			{
				// format new Date
				string testDate = $"{MovData.Day}/{value}/{MovData.Year}";

				// check new date
				if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
				{
					MovData = newDate;
				}
				else
				{
					throw new AttributeException($"Data inválida:\n" +
						$"{MovData.Day.ToString("D2") } / { value.ToString("D2") } / {MovData.Year.ToString("D4")}\n" +
						$"Favor verificar o dia, mês e ano e inserir uma data válida.");
				}
			}
		}
		public int MovAno
		{
			get => MovData.Year;
			set
			{
				// format new Date
				string testDate = $"{MovData.Day}/{MovData.Month}/{value}";

				// check new date
				if (DateTime.TryParse(testDate, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime newDate))
				{
					MovData = newDate;
				}
				else
				{
					throw new AttributeException($"Data inválida:\n" +
						$"{ MovData.Day.ToString("D2") } / { MovData.Month.ToString("D2") } / { value.ToString("D4") }\n" +
						$"Favor verificar o dia, mês e ano e inserir uma data válida.");
				}
			}
		}

		// Property MovValor
		//---------------------------------------------------------------
		public decimal MovValor
		{
			get => EditData._MovValor;
			set
			{
				if (value != EditData._MovValor)
				{
					EditData._MovValor = value;
					NotifyPropertyChanged("MovValor");
				}
			}
		}

		// Property MovValorAbsoluto
		//---------------------------------------------------------------
		public decimal MovValorAbsoluto
		{
			get
			{
				if (EditData._MovValorAbsoluto == 0)
				{
					return Math.Abs(MovValor);
				}
				else
				{
					return EditData._MovValorAbsoluto;
				}
			}

			set => EditData._MovValorAbsoluto = value;
		}

		// Property IDSetor
		//---------------------------------------------------------------
		public int? IDSetor
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

		// Property IDConta
		//---------------------------------------------------------------
		public int? IDConta
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

		// Property IDCaixa
		//---------------------------------------------------------------
		public long? IDCaixa
		{
			get => EditData._IDCaixa;
			set
			{
				if (value != EditData._IDCaixa)
				{
					EditData._IDCaixa = value;
					NotifyPropertyChanged("IDCaixa");
				}
			}
		}

		// Property DescricaoOrigem
		//---------------------------------------------------------------
		public string DescricaoOrigem
		{
			get => EditData._DescricaoOrigem;
			set
			{
				if (value != EditData._DescricaoOrigem)
				{
					EditData._DescricaoOrigem = value;
					NotifyPropertyChanged("DescricaoOrigem");
				}
			}
		}

		// Property Consolidado
		//---------------------------------------------------------------
		public bool Consolidado
		{
			get => EditData._Consolidado;
			set
			{
				if (value != EditData._Consolidado)
				{
					EditData._Consolidado = value;
					NotifyPropertyChanged("Consolidado");
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

		//=================================================================================================
		// tblMovAcrescimo AND tblMovImagem
		//=================================================================================================
		// Property AcrescimoValor
		//---------------------------------------------------------------
		public decimal? AcrescimoValor
		{
			get => EditData._AcrescimoValor;
			set
			{
				if (value != EditData._AcrescimoValor)
				{
					EditData._AcrescimoValor = value;
					NotifyPropertyChanged("AcrescimoValor");
				}
			}
		}

		// Property IDAcrescimoMotivo
		//---------------------------------------------------------------
		public byte? IDAcrescimoMotivo
		{
			get => EditData._IDAcrescimoMotivo;
			set
			{
				if (value != EditData._IDAcrescimoMotivo)
				{
					EditData._IDAcrescimoMotivo = value;
					NotifyPropertyChanged("IDAcrescimoMotivo");
				}
			}
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

		// Property ImagemPath
		//---------------------------------------------------------------
		public string ImagemPath
		{
			get => EditData._Imagem.ImagemPath;
			set
			{
				if (value != EditData._Imagem.ImagemPath)
				{
					EditData._Imagem.ImagemPath = value;
					NotifyPropertyChanged("ImagemPath");
				}
			}
		}

		// Property ImagemFileName
		//---------------------------------------------------------------
		public string ImagemFileName
		{
			get => EditData._Imagem.ImagemFileName;
			set
			{
				if (value != EditData._Imagem.ImagemFileName)
				{
					EditData._Imagem.ImagemFileName = value;
					NotifyPropertyChanged("ImagemFileName");
				}
			}
		}

	}
}
