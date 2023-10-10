using TwT.Base.Configurations;

namespace TwT.Base.Refit
{
	/// <summary>
	/// Configuration that can be used to configure the RestApi
	/// </summary>
	public interface IRestApiConfiguration : ITwTConfiguration
	{
		/// <summary>
		/// Name of the useragent that needs to be added to the request
		/// </summary>
		string UserAgent { get; }

		/// <summary>
		/// Additional header values that need to be added to the request
		/// </summary>
		IDictionary<string, string>? Headers { get; }

		/// <summary>
		/// The vase address the implementation will use will use to send requests to
		/// </summary>
		string BaseUrl { get; }
	}
}