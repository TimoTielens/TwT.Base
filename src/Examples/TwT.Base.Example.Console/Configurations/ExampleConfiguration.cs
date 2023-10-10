using TwT.Base.Configurations;

namespace TwT.Base.Example.Console.Configurations
{
  internal class ExampleConfiguration : TwTConfigurationBase
  {
    public bool Enabled { get; set; }
    public string Host { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public override IReadOnlyCollection<string> Validate()
    {
      var result = new List<string>();

      if (Enabled)
      {
        if(string.IsNullOrWhiteSpace(Host))
          result.Add(GenerateErrorMessageForEmptyString(nameof(Host)));

        if (string.IsNullOrWhiteSpace(Username))
          result.Add(GenerateErrorMessageForEmptyString(nameof(Username)));

        if (string.IsNullOrWhiteSpace(Password))
          result.Add(GenerateErrorMessageForEmptyString(nameof(Password)));
      }
      
      return result;
    }
  }
}