using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	//=================================================================================================
	// CLASSE CAIXA AJUSTE
	//=================================================================================================
	public class objCaixaAjuste : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructAjuste
		{
			internal int? _IDAjuste;
			internal byte _IDAjusteTipo;
			internal string _AjusteTipo;
			internal int _IDSetor;
			internal string _Setor;
			internal int _IDConta;
			internal string _Conta;
			internal DateTime _MovData;
			internal decimal _MovValor;
			internal decimal _MovValorReal;
			internal long? _IDCaixa;
			internal string _AjusteDescricao;
			internal int _IDUserAuth;
			internal string _UsuarioApelido;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructAjuste EditData;
		private StructAjuste BackupData;
		private bool inTxn = false;

		public objCaixaAjuste(int? ID) : base()
		{
			EditData = new StructAjuste()
			{
				_IDAjuste = ID,
				_IDAjusteTipo = 4,
				_AjusteTipo = "",
				_AjusteDescricao = "",
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
			return EditData._AjusteDescricao;
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public int? IDAjuste
		{
			get => EditData._IDAjuste;
			set => EditData._IDAjuste = value;
		}

		// Property AjusteDescricao
		//----------------------------------------------------------------
		public string AjusteDescricao
		{
			get => EditData._AjusteDescricao;
			set
			{
				if (value != EditData._AjusteDescricao)
				{
					EditData._AjusteDescricao = value;
					NotifyPropertyChanged("AjusteDescricao");
				}
			}
		}

		// Property IDAjusteTipo
		//---------------------------------------------------------------
		public byte IDAjusteTipo
		{
			get => EditData._IDAjusteTipo;
			set
			{
				if (value != EditData._IDAjusteTipo)
				{
					EditData._IDAjusteTipo = value;
					NotifyPropertyChanged("IDAjusteTipo");
				}
			}
		}

		// Property AjusteTipo
		//---------------------------------------------------------------
		public string AjusteTipo
		{
			get => EditData._AjusteTipo;
			set
			{
				if (value != EditData._AjusteTipo)
				{
					EditData._AjusteTipo = value;
					NotifyPropertyChanged("AjusteTipo");
				}
			}
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

		// Property MovValorReal
		//---------------------------------------------------------------
		public decimal MovValorReal
		{
			get => EditData._MovValorReal;
			set
			{
				if (value != EditData._MovValorReal)
				{
					EditData._MovValorReal = value;
					NotifyPropertyChanged("MovValorReal");
				}
			}
		}

		// Property IDUserAuth
		//---------------------------------------------------------------
		public int IDUserAuth
		{
			get => EditData._IDUserAuth;
			set
			{
				if (value != EditData._IDUserAuth)
				{
					EditData._IDUserAuth = value;
					NotifyPropertyChanged("IDUserAuth");
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

	}

}
