namespace AzurLaneAPI.Domain.Dtos.Faction;

public class FactionDto
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Prefix { get; set; }
	public string Description { get; set; }
	public string IconUrl { get; set; }
}