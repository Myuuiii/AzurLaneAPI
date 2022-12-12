using System.ComponentModel.DataAnnotations;

namespace AzurLaneAPI.Domain.Dtos.ShipType;

public class ShipTypeUpdateDto
{
	[Required] public string Name { get; set; }
	[Required] public string Description { get; set; }
}