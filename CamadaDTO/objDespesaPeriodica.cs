using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	//=================================================================================================
	// DESPESA
	//=================================================================================================
	public class objDespesaPeriodica : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructDespesa
		{
			// TBL DESPESA
			internal long? _IDDespesa;
			internal byte _DespesaOrigem; // 2:DespesaPeriodica
			internal string _DespesaDescricao;
			internal DateTime _DespesaData;
			internal decimal _DespesaValor;
			internal int _IDCredor;
			internal string _Credor;
			internal int _IDDespesaTipo;
			internal string _DespesaTipo;
			internal int _IDSetor;
			internal string _Setor;
			// TBL DEPESA PERIODICA
			internal int _IDCobrancaForma;
			internal string _CobrancaForma;
			internal int? _IDBanco;
			internal string _BancoNome;
			internal DateTime _IniciarData; // data do inicio da despesa
			internal byte _RecorrenciaTipo; // 1:Diaria | 2:Semanal | 3:Mensal por Dia | 4:Mensal por Semana | 5:Anual | 6: Anual por Mês Semana Dia
			internal string _RecorrenciaTipoDescricao;
			internal short? _RecorrenciaRepeticao; // Quantas Vezes?
			internal byte? _RecorrenciaDia; // Dia do vencimento
			internal byte? _RecorrenciaSemana; // Semana do vencimento
			internal byte? _RecorrenciaMes; // Mes do vencimento
			internal bool _Ativa;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructDespesa EditData;
		private StructDespesa BackupData;
		private bool inTxn = false;

		public objDespesaPeriodica(long? IDDespesa) : base()
		{
			EditData = new StructDespesa()
			{
				_IDDespesa = IDDespesa,
				_DespesaDescricao = "",
				_DespesaOrigem = 2,
				_DespesaData = DateTime.Today,
				_IniciarData = DateTime.Today,
				_DespesaValor = 0,
				_RecorrenciaTipo = 3, // DEFAULT: MENSAL POR DIA
				_RecorrenciaDia = 1,
				_RecorrenciaRepeticao = 1,
				_Ativa = true,

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
		public long? IDDespesa
		{
			get => EditData._IDDespesa;
			set => EditData._IDDespesa = value;
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

		// Property DespesaOrigem
		//---------------------------------------------------------------
		public byte DespesaOrigem
		{
			get => EditData._DespesaOrigem;
			set => EditData._DespesaOrigem = value;
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

		// Property IniciarData
		//---------------------------------------------------------------
		public DateTime IniciarData
		{
			get => EditData._IniciarData;
			set
			{
				if (value != EditData._IniciarData)
				{
					EditData._IniciarData = value;
					NotifyPropertyChanged("IniciarData");
				}
			}
		}

		// Property RecorrenciaTipo
		//---------------------------------------------------------------
		public byte RecorrenciaTipo
		{
			get => EditData._RecorrenciaTipo;
			set
			{
				if (value != EditData._RecorrenciaTipo)
				{
					EditData._RecorrenciaTipo = value;
					NotifyPropertyChanged("RecorrenciaTipo");
				}
			}
		}

		// Property RecorrenciaTipoDescricao
		//---------------------------------------------------------------
		public string RecorrenciaTipoDescricao
		{
			get => EditData._RecorrenciaTipoDescricao;
			set => EditData._RecorrenciaTipoDescricao = value;
		}

		// Property RecorrenciaDia
		//---------------------------------------------------------------
		public byte? RecorrenciaDia
		{
			get => EditData._RecorrenciaDia;
			set
			{
				if (value != EditData._RecorrenciaDia)
				{
					EditData._RecorrenciaDia = value;
					NotifyPropertyChanged("RecorrenciaDia");
				}
			}
		}

		// Property RecorrenciaMes
		//---------------------------------------------------------------
		public byte? RecorrenciaMes
		{
			get => EditData._RecorrenciaMes;
			set
			{
				if (value != EditData._RecorrenciaMes)
				{
					EditData._RecorrenciaMes = value;
					NotifyPropertyChanged("RecorrenciaMes");
				}
			}
		}

		// Property RecorrenciaRepeticao
		//---------------------------------------------------------------
		public short? RecorrenciaRepeticao
		{
			get => EditData._RecorrenciaRepeticao;
			set
			{
				if (value != EditData._RecorrenciaRepeticao)
				{
					EditData._RecorrenciaRepeticao = value;
					NotifyPropertyChanged("RecorrenciaRepeticao");
				}
			}
		}

		// Property RecorrenciaSemana
		//---------------------------------------------------------------
		public byte? RecorrenciaSemana
		{
			get => EditData._RecorrenciaSemana;
			set
			{
				if (value != EditData._RecorrenciaSemana)
				{
					EditData._RecorrenciaSemana = value;
					NotifyPropertyChanged("RecorrenciaSemana");
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

		// Property BancoNome
		//---------------------------------------------------------------
		public string BancoNome
		{
			get => EditData._BancoNome;
			set => EditData._BancoNome = value;
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

		// Property RecorrenciaTexto
		// Cria um texto com a descricao completa da Recorrencia
		//---------------------------------------------------------------
		public string RecorrenciaTexto
		{
			get
			{

				Func<string> DiaDaSemana = () => new System.Globalization.CultureInfo("pt-BR").DateTimeFormat.DayNames[(int)RecorrenciaDia];
				Func<string> MesDoAno = () => new System.Globalization.CultureInfo("pt-BR").DateTimeFormat.MonthNames[(int)RecorrenciaMes];

				// define o inicio da frase Masculino ou Feminino
				string repeticaoM = "Todos os";
				string repeticaoF = "Todas as";

				if (RecorrenciaRepeticao > 1)
				{
					repeticaoM = $"A cada {RecorrenciaRepeticao}";
					repeticaoF = $"A cada {RecorrenciaRepeticao}";
				}

				switch (RecorrenciaTipo)
				{
					case 1: // DIARIO
						return $"{repeticaoM} dias";
					case 2: // SEMANAL
						if (RecorrenciaDia == null) return "Favor preencher o dia...";
						return $"{repeticaoF} semanas nos dias de {DiaDaSemana()}";
					case 3: // MENSAL POR DIA
						if (RecorrenciaDia == null) return "Favor preencher o dia...";
						return $"{repeticaoM} meses no dia {((int)RecorrenciaDia).ToString("00")}";
					case 4: // MENSAL POR SEMANA
						if (RecorrenciaDia == null) return "Favor preencher o dia...";
						if (RecorrenciaDia > 6) RecorrenciaDia = 0;
						if (RecorrenciaSemana == null) return "Favor preencher a semana...";
						return $"{repeticaoM} meses na { RecorrenciaSemana }ª semana no dia de {DiaDaSemana()}";
					case 5: // ANUAL POR MES E DIA
						if (RecorrenciaDia == null) return "Favor preencher o dia...";
						if (RecorrenciaMes == null) return "Favor preencher o mês...";
						return $"{repeticaoM} anos mês de {MesDoAno()} no dia {((int)RecorrenciaDia).ToString("00")}";
					case 6: // ANUAL POR MES E SEMANA
						if (RecorrenciaDia == null) return "Favor preencher o dia...";
						if (RecorrenciaDia > 6) RecorrenciaDia = 0;
						if (RecorrenciaSemana == null) return "Favor preencher a semana...";
						if (RecorrenciaMes == null) return "Favor preencher o mês...";
						return $"{repeticaoM} anos no mês de {MesDoAno()} na { RecorrenciaSemana }ª semana no dia de {DiaDaSemana()}";
					default:
						return "";
				}
			}
		}

		// Property DespesaFatorDiario
		//---------------------------------------------------------------
		public decimal DespesaFatorDiario
		{
			get
			{
				decimal repeticao = RecorrenciaRepeticao ?? 1;

				switch (RecorrenciaTipo)
				{
					case 1: // DIARIO
						return Math.Round(30m / repeticao, 4);
					case 2: // SEMANAL
						return Math.Round(4m / repeticao, 4);
					case 3: // MENSAL POR DIA
					case 4: // MENSAL POR SEMANA
						return Math.Round(1m / repeticao, 4);
					case 5: // ANUAL POR MES E DIA
					case 6: // ANUAL POR MES E SEMANA
						return Math.Round(1m / 12m / repeticao, 4);
					default:
						return 1;
				}
			}
		}

		// Property DespesaValorMensal
		//---------------------------------------------------------------
		public decimal DespesaValorMensal
		{
			get => Math.Round(DespesaValor * DespesaFatorDiario, 2);
		}

	}
}
