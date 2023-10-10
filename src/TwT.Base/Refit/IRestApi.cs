namespace TwT.Base.Refit
{
	/// <summary>
	/// Interface that can be used to access a REST endpoint
	/// </summary>
	/// <typeparam name="TApi">Interface that represents the API endpoint requests</typeparam>
	public interface IRestApi<TApi> where TApi : class
	{
    /// <summary>
    /// Checks whether the endpoint can be reached or that it's down
    /// </summary>
    EndpointReachAbility EndpointCanBeReached { get; }

    /// <summary>
		/// Endpoint requests
		/// </summary>
		TApi Endpoint { get; }
	}

	/// <summary>
	/// Enum that can be used to specify the reach ability of the server
	/// </summary>
	public enum EndpointReachAbility
  {
		/// <summary>
		/// Enum is not set
		/// </summary>
	  Unknown,
		/// <summary>
		/// Cannot be tested because there is no call that just can be used for this
		/// </summary>
		CanNotBeValidated,
		/// <summary>
		/// Server cannot be reached
		/// </summary>
		IsDown,
		/// <summary>
		/// Server can be reached
		/// </summary>
		IsUp,
  }
}