using System.Net;
using System.Text.Json;

namespace TwT.Base.Exceptions
{
	/// <summary>
	/// Error thrown when the API server doesn't response with an HTTP 200-299 response 
	/// </summary>
	public class RestApiException : TwTException
	{
    private new const int ErrorCode = 2;
    private const string ErrorMessage = "API didn't respond with an HTTP 200-299 response. See the attached 'ReasonPhrase' and 'StatusCode' for more information.";
		private readonly HttpResponseMessage _message;

		/// <summary>
		/// Status code of the HTTP response
		/// </summary>
		public HttpStatusCode StatusCode => _message.StatusCode;

		/// <summary>
		/// The reason phrase which sent by the server
		/// </summary>
		public string ReasonPhrase => _message.ReasonPhrase ?? string.Empty;

		/// <summary>
		/// The content of the HTTP response message
		/// </summary>
		public string Content => _message.Content.ReadAsStringAsync().Result;

		/// <summary>
		/// Error thrown when the API server doesn't response with an HTTP 200-299 response 
		/// </summary>
		/// <param name="message">Response from the server</param>
		public RestApiException(HttpResponseMessage message) : base(ErrorCode, ErrorMessage)
		{
			_message = message;
		}

		/// <summary>
		/// Gets the content of the HTTP response message in parsed form
		/// </summary>
		/// <typeparam name="TModel">Model that the message needs to parsed to</typeparam>
		/// <returns>Either the parsed message or default</returns>
		public TModel? GetContentAs<TModel>()
		{
			try
			{
				return JsonSerializer.Deserialize<TModel>(_message.Content.ReadAsStringAsync().Result);
			}
			catch
			{
				return default;
			}
		}
	}
}