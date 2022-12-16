using System.ComponentModel.DataAnnotations;
using AzurLaneAPI.Domain.Dtos.ShipStats;
using AzurLaneAPI.Domain.Entities;

namespace AzurLaneAPI.Domain.Dtos.Ship;

public class ShipCreateDto
{
	[Required] public string Id { get; set; }

	[Required] public string EnglishName { get; set; }
	[Required] public string JapaneseName { get; set; }
	[Required] public string ChineseName { get; set; }

	[Required, Url] public string ThumbnailImageUrl { get; set; }
	
	[Required] public string ConstructionTime { get; set; }
	[Required] public Rarity Rarity { get; set; }

	[Required] public Guid TypeId { get; set; }
	[Required] public Guid FactionId { get; set; }
	[Required] public Guid SubclassId { get; set; }

	[Required] public ShipStatsCreateDto BaseStats { get; set; }
	[Required] public ShipStatsCreateDto Level100Stats { get; set; }
	[Required] public ShipStatsCreateDto Level120Stats { get; set; }
	[Required] public ShipStatsCreateDto Level125Stats { get; set; }
}