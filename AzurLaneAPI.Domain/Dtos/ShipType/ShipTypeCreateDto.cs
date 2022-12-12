using System.ComponentModel.DataAnnotations;

namespace AzurLaneAPI.Domain.Dtos.ShipType;

public class ShipTypeCreateDto
{
	[Required] public string Name { get; set; }
	[Required] public string Description { get; set; }
}