using AzurLaneAPI.Domain.Dtos.ShipTypeSubclass;

namespace AzurLaneAPI.Domain.Dtos.ShipType;

public class ShipTypeDto
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public ICollection<ShipTypeSubclassDto> Subclasses { get; set; }
}