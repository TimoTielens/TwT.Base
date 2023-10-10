using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;
using Refit;
using TwT.Base.Exceptions;

namespace TwT.Base.Refit
{
  /// <summary>
  /// Class that can be used to access a REST endpoint
  /// </summary>
  /// <typeparam name="TApi">Interface that represents the API endpoint requests</typeparam>
  public class RestAPi<TApi> : IRestApi<TApi> where TApi : class
  {
    private static ILogger<RestAPi<TApi>> _logger;
    private readonly Func<TApi, EndpointReachAbility> _checkReachAbility;

    /// <summary>
    /// Checks whether the endpoint can be reached or that it's down 
    /// </summary>
    public EndpointReachAbility EndpointCanBeReached => _checkReachAbility.Invoke(Endpoint);

    /// <summary>
    /// Endpoint requests
    /// </summary>
    public TApi Endpoint { get; }

    /// <summary>
    /// Class that can be used to access a REST endpoint
    /// </summary>
    /// <param name="configuration">Configuration that will be used to configure the RestApi</param>
    /// <param name="logger">Logger that will be used for logging all the events that occur in this client</param>
    /// <param name="checkReachAbility">Function that will be called to check the reach ability of the server</param>
    /// <exception cref="ConfigurationValidationException">The provided configuration contains validation issues</exception>
    public RestAPi(IRestApiConfiguration configuration, ILogger<RestAPi<TApi>> logger, Func<TApi, EndpointReachAbility> checkReachAbility)
    {
      if (!configuration.IsValid())
        throw new ConfigurationValidationException(configuration.ValidationErrors);

      _logger = logger;
      _checkReachAbility = checkReachAbility;
      Endpoint = Configure(configuration);
    }

    /// <summary>
    /// Configures a new endpoint
    /// </summary>
    /// <param name="configuration">Configuration that will be used to configure the RestApi</param>
    /// <returns>Newly created endpoint</returns>
    private TApi Configure(IRestApiConfiguration configuration)
    {
      var client = new HttpClient
      {
        BaseAddress = new Uri(configuration.BaseUrl),
        DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrLower,
        Timeout = default
      };

      foreach (var header in configuration.Headers)
      {
        client.DefaultRequestHeaders.Add(header.Key, header.Value);
      }

      client.DefaultRequestHeaders.UserAgent.Clear();
      client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(configuration.UserAgent));

      return RestService.For<TApi>(client, new RefitSettings { ExceptionFactory = HandleException! });
    }

    /// <summary>
    /// Checks if the message can be excepted or not. When the server doesn't respond with an HTTP 200 -299 a <see cref="RestApiException"/> will be returned
    /// </summary>
    /// <param name="response">Response from the server</param>
    /// <returns></returns>
    private static async Task<Exception> HandleException(HttpResponseMessage response)
    {
      _logger.LogTrace("Received response from API status code: {status} ({reason})", response.StatusCode, response.ReasonPhrase);

      if (response.IsSuccessStatusCode) return null!;

      _logger.LogError("API didn't reply with an HTTP 200-299 response, but with {status} ({reason})", response.StatusCode, response.ReasonPhrase);
      return new RestApiException(response);
    }
  }
}