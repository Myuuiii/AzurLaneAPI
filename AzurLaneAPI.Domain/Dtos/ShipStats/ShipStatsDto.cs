using AzurLaneAPI.Domain.Enums;

namespace AzurLaneAPI.Domain.Dtos.ShipStats;

public class ShipStatsDto
{
	public int Health { get; set; }
	public int Firepower { get; set; }
	public int Torpedo { get; set; }
	public int Aviation { get; set; }
	public int AntiAir { get; set; }
	public int Reload { get; set; }
	public int Evasion { get; set; }
	public Armor Armor { get; set; }
	public int Speed { get; set; }
	public int Accuracy { get; set; }
	public int Luck { get; set; }
	public int AntiSub { get; set; }
	public int OilConsumption { get; set; }
}