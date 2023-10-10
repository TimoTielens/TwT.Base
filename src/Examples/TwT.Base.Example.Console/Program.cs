using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using TwT.Base.Example.Console.Refit;
using TwT.Base.Refit;

namespace TwT.Base.Example.Console
{
  internal class Program
  {
    static void Main(string[] args)
    {
      System.Console.WriteLine("Demo");

      var config = new RestApiConfiguration()
      {
        UserAgent = "test",
        BaseUrl = "https://google.nl",
        Headers = null
      };

      System.Console.WriteLine($"Config has '{config.ValidationErrorCount}' errors");

      try
      {
        var api = new RestAPi<IGoogleApi>(config, NullLogger<RestAPi<IGoogleApi>>.Instance, checker);
        var foo = api.Endpoint.Test().Result;
      }
      catch (Exception e)
      {
        System.Console.WriteLine(e);
      }

      System.Console.Read();
    }

    private static EndpointReachAbility checker(IGoogleApi api)
    {
      return EndpointReachAbility.IsUp;
    }
  }
}