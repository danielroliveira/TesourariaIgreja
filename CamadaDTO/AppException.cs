using System;

namespace CamadaDTO
{
	//==========================================================================================
	// APP EXCEPTION
	//==========================================================================================
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2237:Mark ISerializable types with serializable", Justification = "<Pending>")]
	public class AppException : Exception
	{
		public AppException(string message)
			: base(message)
		{ }

		public AppException(string message, Exception inner)
			: base(message, inner)
		{ }

		public AppException(string message, int excNumber)
			: base(message)
		{ HResult = excNumber; }

		public AppException()
		{
		}

	}


	//==========================================================================================
	// ATTRIBUTE EXCEPTION
	//==========================================================================================
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2237:Mark ISerializable types with serializable", Justification = "<Pending>")]
	public class AttributeException : Exception
	{
		public AttributeException(string message)
			: base(message)
		{ }

		public AttributeException(string message, Exception inner)
			: base(message, inner)
		{ }

		public AttributeException()
		{
		}

	}
}
