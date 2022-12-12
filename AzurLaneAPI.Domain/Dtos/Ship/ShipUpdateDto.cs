using System.ComponentModel.DataAnnotations;
using AzurLaneAPI.Domain.Dtos.ShipStats;
using AzurLaneAPI.Domain.Entities;

namespace AzurLaneAPI.Domain.Dtos.Ship;

public class ShipUpdateDto
{
	[Required] public string EnglishName { get; set; }
	[Required] public string JapaneseName { get; set; }
	[Required] public string ChineseName { get; set; }

	[Required] public string ConstructionTime { get; set; }
	[Required] public Rarity Rarity { get; set; }

	[Required] public Guid TypeId { get; set; }
	[Required] public Guid FactionId { get; set; }
	[Required] public Guid SubclassId { get; set; }

	[Required] public ShipStatsCreateDto BaseStats { get; set; }
}