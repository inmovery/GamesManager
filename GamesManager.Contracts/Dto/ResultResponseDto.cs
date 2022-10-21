namespace GamesManager.Contracts.Dto
{
	public class ResultResponseDto<TResponse>
	{
		/// <summary>
		/// Property that perform flag of success
		/// </summary>
		public bool IsSuccess { get; set; }

		/// <summary>
		/// Response parameter inside result
		/// </summary>
		public TResponse? Response { get; set; }

		/// <summary>
		/// List of errors
		/// </summary>
		public IEnumerable<string>? Errors { get; set; }
	}
}
