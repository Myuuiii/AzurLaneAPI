using System.ComponentModel.DataAnnotations;
using AzurLaneAPI.Domain.Enums;

namespace AzurLaneAPI.Domain.Entities;

public class Ship
{
	[Key] public string Id { get; set; }

	public string EnglishName { get; set; }
	public string JapaneseName { get; set; }
	public string ChineseName { get; set; }

	public string ThumbnailImageUrl { get; set; }

	public string ConstructionTime { get; set; }

	public Rarity Rarity { get; set; }


	public Guid TypeId { get; set; }
	public ShipType Type { get; set; }

	public Guid FactionId { get; set; }
	public Faction Faction { get; set; }

	public Guid SubclassId { get; set; }
	public ShipTypeSubclass Subclass { get; set; }

	public Guid BaseStatsId { get; set; }
	public ShipStats? BaseStats { get; set; }

	public Guid Level100StatsId { get; set; }
	public ShipStats? Level100Stats { get; set; }

	public Guid Level120StatsId { get; set; }
	public ShipStats? Level120Stats { get; set; }

	public Guid Level125StatsId { get; set; }
	public ShipStats? Level125Stats { get; set; }
}