using TwT.Base.Exceptions;

namespace TwT.Base.Example.Console
{
  internal class ExceptionExample
  {
    public void Example()
    {
      try
      {
        //Logic
      }
      catch (TwTException twtException)
      {
        switch (twtException)
        {
          case RestApiException apiException:
            System.Console.WriteLine($"API responded with an error. StatusCode from server: '{apiException.StatusCode}' || ReasonPhrase from server: '{apiException.ReasonPhrase}'");
            break;
          case ConfigurationValidationException exception:
            System.Console.WriteLine($"Whoops the configuration was incorrect. It has {exception.ValidationErrorCount} validation errors");
            break;
        }
      }
      catch (Exception twTException)
      {
        System.Console.WriteLine($"UnExpected exception. Message: '{twTException.Message}'");
      }
    }
  }
}
