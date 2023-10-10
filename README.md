# TwT.Base
[![Build & Publish NuGet to GitHub Registry](https://github.com/TimoTielens/TwT.Base/actions/workflows/main.yml/badge.svg)](https://github.com/TimoTielens/TwT.Base/actions/workflows/main.yml)

Base package that will be used by all the other projects from me. This base package isn't intended to have all the possible usable code that there is. 
It just contains the most used logic or logic that I think should always used (E.G. interface for configurations).

## 🚀 About Me
I'm a full stack developer mainly working with Umbraco, however my passion will always be at the Back-End. I started as an Embedded Engineer and slowly rolled into C# which I am using 
now for over more then 8 years

## License
This package is not made for anyone but myself. However feel free the use, clone and/or modify it [MIT](https://choosealicense.com/licenses/mit/). Also requests for change or pull request are welcome. 
If you do make money of it, congratz on you! 

If you mind a buying me a coffee that's ofcourse always appreciated!
[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/TimoTielens)

## Features
The following version are available

### Version 1.0.0 (10-10-2023)
First release

- Configuration base and interface ITwTConfiguration
- TwTException
- IRestApi with Refit implementation

## Roadmap
At the moment there are no concrete items for the roadmap. However at some point I'm sure that I will add logic.

### Security
At least twice a year this package will be checked for secuirty issues. If a high security issues arises earlier, it will be patched directlly.

## Installation
```bash
dotnet add package TwT.Base 
```

## Usage/Examples
Below are some samples of code that do work with this package

### Configuration
Every configuration file used should inherited from *TwTConfigurationBase* this helps with making sure that the interface *ITwTConfiguration* is always implemented in the same way.

```javascript
  public interface IExampleConfiguration : ITwTConfiguration
  {
    public bool Enabled { get; }
    public string Host { get; }
    public string Username { get; }
    public string Password { get; }
  }

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
```

### Exceptions
All the exceptions should inherited from *TwTException* so that it can be easly catched

```javascript
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
```

### API
This package has a defualt wrapper for https://github.com/reactiveui/refit that can be used for setting up API clients

```javascript
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

    private static EndpointReachAbility checker(IGoogleApi api)
    {
      return EndpointReachAbility.IsUp;
    }
```
