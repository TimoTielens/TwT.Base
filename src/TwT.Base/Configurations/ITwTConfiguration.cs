namespace TwT.Base.Configurations
{
	/// <summary>
	/// Interface that should be used to define a configuration class
	/// </summary>
	public interface ITwTConfiguration
	{
		/// <summary>
		/// Number of validation errors for this configuration class
		/// </summary>
		public int ValidationErrorCount { get; }

		/// <summary>
		/// Validation errors for this configuration class
		/// </summary>
		public IReadOnlyCollection<string> ValidationErrors { get; }

		/// <summary>
		/// Checks if the configuration is valid
		/// </summary>
		/// <returns>True if there are no errors</returns>
		public bool IsValid();
	}
}