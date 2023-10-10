namespace TwT.Base.Exceptions
{
	/// <summary>
	/// Exception that will be thrown when a configuration file with validation issues is used
	/// </summary>
	public class ConfigurationValidationException : TwTException
	{
    private new const int ErrorCode = 1;

    /// <summary>
		/// Number of validation errors for this configuration class
		/// </summary>
		public int ValidationErrorCount { get; init; }

		/// <summary>
		/// Validation errors for this configuration class
		/// </summary>
		public IReadOnlyCollection<string> ValidationErrors { get; init; }

		/// <summary>
		/// Exception that will be thrown when a configuration file with validation issues is used
		/// </summary>
		/// <param name="validationErrors">Validation errors for this configuration class</param>
		public ConfigurationValidationException(IReadOnlyCollection<string> validationErrors) : base(ErrorCode, GenerateMessage(validationErrors))
		{
			ValidationErrorCount = validationErrors.Count;
      ValidationErrors = validationErrors;
    }

		/// <summary>
		/// Generates an error message based on the provided validation errors
		/// </summary>
		/// <param name="validationErrors">Validation errors for this configuration class</param>
		/// <returns>Error message based on the provided validation errors</returns>
		private static string GenerateMessage(IReadOnlyCollection<string>? validationErrors)
		{
			if (validationErrors == null || !validationErrors.Any())
				return "Configuration cannot be used although there are no direct validation issues";

			return $"Configuration contains {validationErrors.Count} validation issues. See the attached validation errors for more information.";
		}
	}
}