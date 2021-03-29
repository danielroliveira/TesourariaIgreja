using System;
using System.ComponentModel;

namespace CamadaDTO
{
	//=================================================================================================
	// DESPESA
	//=================================================================================================
	public class objDespesaPeriodica : objDespesa, IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructDespesaPeriodica
		{
			// TBL DEPESA PERIODICA
			internal int _IDAPagarForma;
			internal string _APagarForma;
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
			internal string _Instalacao;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructDespesaPeriodica EditDataPeriodica;
		private StructDespesaPeriodica BackupDataPeriodica;

		public objDespesaPeriodica(long? IDDespesa) : base(IDDespesa)
		{
			EditDataPeriodica = new StructDespesaPeriodica()
			{
				_IniciarData = DateTime.Today,
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
				BackupDataPeriodica = EditDataPeriodica;
				inTxn = true;
			}
		}

		public void CancelEdit()
		{
			if (inTxn)
			{
				EditData = BackupData;
				EditDataPeriodica = BackupDataPeriodica;
				inTxn = false;
			}
		}

		public void EndEdit()
		{
			if (inTxn)
			{
				BackupData = new StructDespesa();
				BackupDataPeriodica = new StructDespesaPeriodica();
				inTxn = false;
			}
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================

		// Property IDAPagarForma
		//---------------------------------------------------------------
		public int IDAPagarForma
		{
			get => EditDataPeriodica._IDAPagarForma;
			set
			{
				if (value != EditDataPeriodica._IDAPagarForma)
				{
					EditDataPeriodica._IDAPagarForma = value;
					NotifyPropertyChanged("IDAPagarForma");
				}
			}
		}

		// Property APagarForma
		//---------------------------------------------------------------
		public string APagarForma
		{
			get => EditDataPeriodica._APagarForma;
			set => EditDataPeriodica._APagarForma = value;
		}

		// Property IniciarData
		//---------------------------------------------------------------
		public DateTime IniciarData
		{
			get => EditDataPeriodica._IniciarData;
			set
			{
				if (value != EditDataPeriodica._IniciarData)
				{
					EditDataPeriodica._IniciarData = value;
					NotifyPropertyChanged("IniciarData");
				}
			}
		}

		// Property RecorrenciaTipo
		//---------------------------------------------------------------
		public byte RecorrenciaTipo
		{
			get => EditDataPeriodica._RecorrenciaTipo;
			set
			{
				if (value != EditDataPeriodica._RecorrenciaTipo)
				{
					EditDataPeriodica._RecorrenciaTipo = value;
					NotifyPropertyChanged("RecorrenciaTipo");
				}
			}
		}

		// Property RecorrenciaTipoDescricao
		//---------------------------------------------------------------
		public string RecorrenciaTipoDescricao
		{
			get => EditDataPeriodica._RecorrenciaTipoDescricao;
			set => EditDataPeriodica._RecorrenciaTipoDescricao = value;
		}

		// Property RecorrenciaDia
		//---------------------------------------------------------------
		public byte? RecorrenciaDia
		{
			get => EditDataPeriodica._RecorrenciaDia;
			set
			{
				if (value != EditDataPeriodica._RecorrenciaDia)
				{
					EditDataPeriodica._RecorrenciaDia = value;
					NotifyPropertyChanged("RecorrenciaDia");
				}
			}
		}

		// Property RecorrenciaMes
		//---------------------------------------------------------------
		public byte? RecorrenciaMes
		{
			get => EditDataPeriodica._RecorrenciaMes;
			set
			{
				if (value != EditDataPeriodica._RecorrenciaMes)
				{
					EditDataPeriodica._RecorrenciaMes = value;
					NotifyPropertyChanged("RecorrenciaMes");
				}
			}
		}

		// Property RecorrenciaRepeticao
		//---------------------------------------------------------------
		public short? RecorrenciaRepeticao
		{
			get => EditDataPeriodica._RecorrenciaRepeticao;
			set
			{
				if (value != EditDataPeriodica._RecorrenciaRepeticao)
				{
					EditDataPeriodica._RecorrenciaRepeticao = value;
					NotifyPropertyChanged("RecorrenciaRepeticao");
				}
			}
		}

		// Property RecorrenciaSemana
		//---------------------------------------------------------------
		public byte? RecorrenciaSemana
		{
			get => EditDataPeriodica._RecorrenciaSemana;
			set
			{
				if (value != EditDataPeriodica._RecorrenciaSemana)
				{
					EditDataPeriodica._RecorrenciaSemana = value;
					NotifyPropertyChanged("RecorrenciaSemana");
				}
			}
		}

		// Property IDBanco
		//---------------------------------------------------------------
		public int? IDBanco
		{
			get => EditDataPeriodica._IDBanco;
			set
			{
				if (value != EditDataPeriodica._IDBanco)
				{
					EditDataPeriodica._IDBanco = value;
					NotifyPropertyChanged("IDBanco");
				}
			}
		}

		// Property BancoNome
		//---------------------------------------------------------------
		public string BancoNome
		{
			get => EditDataPeriodica._BancoNome;
			set => EditDataPeriodica._BancoNome = value;
		}

		// Property Ativa
		//---------------------------------------------------------------
		public bool Ativa
		{
			get => EditDataPeriodica._Ativa;
			set
			{
				if (value != EditDataPeriodica._Ativa)
				{
					EditDataPeriodica._Ativa = value;
					NotifyPropertyChanged("Ativa");
				}
			}
		}

		// Property Instalacao
		//---------------------------------------------------------------
		public string Instalacao
		{
			get => EditDataPeriodica._Instalacao;
			set
			{
				if (value != EditDataPeriodica._Instalacao)
				{
					EditDataPeriodica._Instalacao = value;
					NotifyPropertyChanged("Instalacao");
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
