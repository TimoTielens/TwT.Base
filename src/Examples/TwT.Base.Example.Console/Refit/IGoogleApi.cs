using Refit;

namespace TwT.Base.Example.Console.Refit
{
  internal interface IGoogleApi
  {
    [Get("/test")]
    Task<string> Test();
  }
}