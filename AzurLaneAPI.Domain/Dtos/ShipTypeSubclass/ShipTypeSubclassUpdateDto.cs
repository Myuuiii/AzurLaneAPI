using System.ComponentModel.DataAnnotations;

namespace AzurLaneAPI.Domain.Dtos.ShipTypeSubclass;

public class ShipTypeSubclassUpdateDto
{
	[Required] public string Name { get; set; }
	[Required] public string Description { get; set; }

	// External Link
	[Required] public Guid ShipTypeId { get; set; }
}