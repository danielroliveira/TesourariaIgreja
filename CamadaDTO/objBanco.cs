namespace CamadaDTO
{
	public class objBanco
	{
		struct BancoData
		{
			internal int? _IDBanco;
			internal string _BancoNome;
			internal string _Sigla;
			internal bool _Ativo;
		}

		private BancoData EditData;

		public objBanco()
		{
			EditData = new BancoData();
			EditData._Ativo = true;
		}

		public objBanco(int IDBanco) : base()
		{
			EditData._IDBanco = IDBanco;
		}

		// Property IDBanco
		//---------------------------------------------------------------
		public int? IDBanco
		{
			get => EditData._IDBanco;
			set => EditData._IDBanco = value;
		}

		// Property BancoNome
		//---------------------------------------------------------------
		public string BancoNome
		{
			get => EditData._BancoNome;
			set => EditData._BancoNome = value;
		}

		// Property Sigla
		//---------------------------------------------------------------
		public string Sigla
		{
			get => EditData._Sigla;
			set => EditData._Sigla = value;
		}

		// Property Ativo
		//---------------------------------------------------------------
		public bool Ativo
		{
			get => EditData._Ativo;
			set => EditData._Ativo = value;
		}
	}
}
