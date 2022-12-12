namespace AzurLaneAPI.Domain.Entities;

public class ShipType
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public virtual ICollection<ShipTypeSubclass> Subclasses { get; set; }
}