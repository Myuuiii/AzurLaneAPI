using AzurLaneAPI.Domain.Dtos.ShipStats;

namespace AzurLaneAPI.Domain.Dtos.Ship;

public class ShipDto
{
	public string Id { get; set; }

	public string EnglishName { get; set; }
	public string JapaneseName { get; set; }
	public string ChineseName { get; set; }

	public string ThumbnailImageUrl { get; set; }

	public string ConstructionTime { get; set; }
	public string Rarity { get; set; }

	public string Type { get; set; }
	public Guid TypeId { get; set; }
	public string Faction { get; set; }
	public Guid FactionId { get; set; }
	public string Subclass { get; set; }
	public Guid SubclassId { get; set; }

	public ShipStatsDto BaseStats { get; set; }
	public ShipStatsDto Level100Stats { get; set; }
	public ShipStatsDto Level120Stats { get; set; }
	public ShipStatsDto Level125Stats { get; set; }
}