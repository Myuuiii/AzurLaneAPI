namespace AzurLaneAPI.Domain.APIQueryParameters;

public sealed class PaginationParameters
{
	public int PageNumber { get; set; } = 1;
	public int PageSize { get; set; } = 10;
	
	public PaginationParameters()
	{
		PageNumber = 1;
		PageSize = 10;
	}
}