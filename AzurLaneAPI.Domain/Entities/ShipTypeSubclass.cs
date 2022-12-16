namespace AzurLaneAPI.Domain.Entities;

public class ShipTypeSubclass
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }

	public Guid ShipTypeId { get; set; }
	public virtual ShipType ShipType { get; set; }
}