using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CamadaDTO
{
	public class objReuniao : IEditableObject, INotifyPropertyChanged
	{
		// STRUCTURE
		//-------------------------------------------------------------------------------------------------
		struct StructReuniao
		{
			internal int? _IDReuniao;
			internal string _Reuniao;
			internal int? _IDCongregacao;
			internal int _RecorrenciaTipo; // 1:Diaria | 2:Semanal | 3:Mensal por Dia | 4:Mensal por Semana | 5:Anual | 6: Anual por Mês Semana Dia
			internal short _RecorrenciaRepeticao; // Quantas Vezes?
			internal byte? _RecorrenciaDia; // Dia da reuniao
			internal byte? _RecorrenciaSemana; // Semana da reuniao
			internal byte? _RecorrenciaMes; // Mes da reuniao
			internal DateTime _IniciarData; // data do inicio da reuniao
			internal bool _Ativa;
		}

		// VARIABLES | CONSTRUCTOR
		//-------------------------------------------------------------------------------------------------
		private StructReuniao EditData;
		private StructReuniao BackupData;
		private bool inTxn = false;

		public objReuniao(int? IDReuniao) : base()
		{
			EditData = new StructReuniao()
			{
				_IDReuniao = IDReuniao,
				_Reuniao = "",
				_IDCongregacao = null,
				_RecorrenciaTipo = 2, // semanal
				_RecorrenciaRepeticao = 1,
				_RecorrenciaDia = null,
				_RecorrenciaSemana = null,
				_RecorrenciaMes = null,
				_IniciarData = DateTime.Today,
				_Ativa = true
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
				BackupData = new StructReuniao();
				inTxn = false;
			}
		}

		// PROPERTY CHANGED
		//------------------------------------------------------------------------------------------------------------
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public override string ToString()
		{
			return EditData._Reuniao;
		}

		public bool RegistroAlterado
		{
			get => inTxn;
		}

		//=================================================================================================
		// PROPERTIES
		//=================================================================================================
		public int? IDReuniao
		{
			get => EditData._IDReuniao;
			set => EditData._IDReuniao = value;
		}

		// Property Reuniao
		//----------------------------------------------------------------
		public string Reuniao
		{
			get => EditData._Reuniao;
			set
			{
				if (value != EditData._Reuniao)
				{
					EditData._Reuniao = value;
					NotifyPropertyChanged("Reuniao");
				}
			}
		}

		// Property IDCongregacao
		//---------------------------------------------------------------
		public int? IDCongregacao
		{
			get => EditData._IDCongregacao;
			set
			{
				if (value != EditData._IDCongregacao)
				{
					EditData._IDCongregacao = value;
					NotifyPropertyChanged("IDCongregacao");
				}
			}
		}

		// Property Congregacao
		//---------------------------------------------------------------
		public string Congregacao { get; set; }

		// Property RecorrenciaTipo
		//---------------------------------------------------------------
		public int RecorrenciaTipo
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
		public string RecorrenciaTipoDescricao { get; set; }

		// Property RecorrenciaRepeticao
		//---------------------------------------------------------------
		public short RecorrenciaRepeticao
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

		// Property IniciarDataDiaDaSemana
		// Cria um texto com o Dia da Semana da Data do IniciarData
		//---------------------------------------------------------------
		public string IniciarDataDiaDaSemana
		{
			get => IniciarData.ToString("dddd");
		}


	}
}
