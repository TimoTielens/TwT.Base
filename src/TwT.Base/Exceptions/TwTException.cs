namespace TwT.Base.Exceptions
{
	/// <summary>
	/// Error thrown from the Vacancy Nuget
	/// </summary>
	public abstract class TwTException : Exception
	{
		/// <summary>
		/// Code that is linked to this error and should be described in some documentation
		/// </summary>
		public int ErrorCode { get; }

		/// <summary>Initializes a new instance of the <see cref="T:System.Exception"/> class with a specified error message</summary>
		/// <param name="errorCode">Code that is linked to this error and should be described in some documentation</param>
		/// <param name="message">The message that describes the error</param>
		protected TwTException(int errorCode, string message) : base(message)
		{
			ErrorCode = errorCode;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Exception"/> class with a specified error message and a reference to the inner exception that is the cause of this exception</summary>
		/// <param name="errorCode">Code that is linked to this error and should be described in some documentation</param>
		/// <param name="message">The error message that explains the reason for the exception</param>
		/// <param name="innerException">The exception that is the cause of the current exception</param>
		protected TwTException(int errorCode, string message, Exception innerException) : base(message, innerException)
		{
			ErrorCode = errorCode;
		}
	}
}