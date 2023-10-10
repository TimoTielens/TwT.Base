using TwT.Base.Configurations;

namespace TwT.Base.Refit
{
	public class RestApiConfiguration : TwTConfigurationBase, IRestApiConfiguration
  {
    /// <summary>
    /// Name of the useragent that needs to be added to the request
    /// </summary>
    public required string UserAgent { get; set; }

    /// <summary>
    /// Additional header values that need to be added to the request
    /// </summary>
    public IDictionary<string, string>? Headers { get; set; }

    /// <summary>
    /// The vase address the implementation will use will use to send requests to
    /// </summary>
    public required string BaseUrl { get; set; }

    /// <summary>
    /// Validates the configuration class and returns all the errors if any
    /// </summary>
    /// <returns>Any validation errors</returns>
    public override IReadOnlyCollection<string> Validate()
		{
			var errors = new List<string>();

      if (string.IsNullOrWhiteSpace(UserAgent))
        errors.Add($"{nameof(UserAgent)} cannot be null");

      if (string.IsNullOrWhiteSpace(BaseUrl))
        errors.Add($"{nameof(BaseUrl)} cannot be null");

      return errors;
    }
	}
}