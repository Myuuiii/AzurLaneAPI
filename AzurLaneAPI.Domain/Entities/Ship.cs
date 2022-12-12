using System.ComponentModel.DataAnnotations;

namespace AzurLaneAPI.Domain.Entities;

public class Ship
{
	[Key] public string Id { get; set; }

	public string EnglishName { get; set; }
	public string JapaneseName { get; set; }
	public string ChineseName { get; set; }

	public string ConstructionTime { get; set; }

	public Rarity Rarity { get; set; }

	public ShipType Type { get; set; }
	public Faction Faction { get; set; }
	public ShipTypeSubclass Subclass { get; set; }

	public ShipStats BaseStats { get; set; }
}