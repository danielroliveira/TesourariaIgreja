using System;

namespace CamadaDTO
{
	public class objImagem
	{
		// tbl MovImagem
		public string ImagemPath { get; set; }
		public string ImagemFileName { get; set; }
		public EnumImagemOrigem Origem { get; set; }
		public long IDOrigem { get; set; }
		public DateTime? ReferenceDate { get; set; }

		// GET SHALLOW COPY OF OBJECT
		//------------------------------------------------------------------------------------------------------------
		public objImagem ShallowCopy()
		{
			return (objImagem)this.MemberwiseClone();
		}

	}
}
