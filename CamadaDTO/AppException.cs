using System;

namespace CamadaDTO
{
	//==========================================================================================
	// APP EXCEPTION
	//==========================================================================================
	public class AppException : Exception
	{
		public AppException(string message)
			: base(message)
		{ }

		public AppException(string message, Exception inner)
			: base(message, inner)
		{ }

		public AppException()
		{
		}

	}

	//==========================================================================================
	// ATTRIBUTE EXCEPTION
	//==========================================================================================
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
