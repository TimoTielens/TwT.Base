namespace TwT.Base.Configurations
{
	/// <summary>
	/// Base that should be used to define a configuration class
	/// </summary>
	public abstract class TwTConfigurationBase : ITwTConfiguration
	{
		private IReadOnlyCollection<string>? _validationErrors;

		/// <summary>
		/// Number of validation errors for this configuration class
		/// </summary>
		public int ValidationErrorCount => GetValidationErrors().Count;

		/// <summary>
		/// Validation errors for this configuration class
		/// </summary>
		public IReadOnlyCollection<string> ValidationErrors => GetValidationErrors();

		/// <summary>
		/// Checks if the configuration is valid
		/// </summary>
		/// <returns>True if there are no errors</returns>
		public bool IsValid() => GetValidationErrors().Count == 0;

		/// <summary>
		/// Validates the configuration class and returns all the errors if any
		/// </summary>
		/// <returns>Any validation errors</returns>
		/// <remarks>Needs to be overriden</remarks>
		/// <exception cref="NotImplementedException">Validation is not implemented</exception>
		public virtual IReadOnlyCollection<string> Validate()
		{
			throw new NotImplementedException("Validation is not implemented");
		}

		/// <summary>
		/// Retrieves the validation errors if any
		/// </summary>
		/// <returns>Any validation errors</returns>
		private IReadOnlyCollection<string> GetValidationErrors()
		{
			return _validationErrors ??= Validate();
		}

		/// <summary>
		/// Generates a standard error message for an empty string
		/// </summary>
		/// <param name="propertyName">Name of the property that has the validation error</param>
		/// <returns>Error message generated for a specific property</returns>
    protected string GenerateErrorMessageForEmptyString(string propertyName)
    {
			return $"The property'{propertyName}' cannot be null or empty";
    }
	}
}