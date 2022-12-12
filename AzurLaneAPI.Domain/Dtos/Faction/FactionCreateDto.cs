using System.ComponentModel.DataAnnotations;

namespace AzurLaneAPI.Domain.Dtos.Faction;

public class FactionCreateDto
{
	[Required] public string Name { get; set; }
	[Required] public string Prefix { get; set; }
	[Required] public string Description { get; set; }
	[Required] public string IconUrl { get; set; }
}