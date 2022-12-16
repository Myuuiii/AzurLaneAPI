namespace AzurLaneAPI.Domain.APIQueryParameters;

public sealed class PaginationParameters
{
	public PaginationParameters()
	{
		PageNumber = 1;
		PageSize = 10;
	}

	public int PageNumber { get; set; } = 1;
	public int PageSize { get; set; } = 10;
}