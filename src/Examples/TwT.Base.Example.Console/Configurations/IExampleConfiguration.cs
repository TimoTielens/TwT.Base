using TwT.Base.Configurations;

namespace TwT.Base.Example.Console.Configurations
{
  public interface IExampleConfiguration : ITwTConfiguration
  {
    public bool Enabled { get; }
    public string Host { get; }
    public string Username { get; }
    public string Password { get; }
  }
}
