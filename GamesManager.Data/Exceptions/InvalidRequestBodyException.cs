namespace GamesManager.Core.Exceptions
{
	public class InvalidRequestBodyException : Exception
	{
		public InvalidRequestBodyException()
		{
			Errors = Enumerable.Empty<string>();
		}

		public InvalidRequestBodyException(string message) : base(message)
		{
			Errors = Enumerable.Empty<string>();
		}

		public InvalidRequestBodyException(string message, IEnumerable<string> errors) : base(message)
		{
			Errors = errors;
		}

		public IEnumerable<string> Errors { get; set; }
	}
}
