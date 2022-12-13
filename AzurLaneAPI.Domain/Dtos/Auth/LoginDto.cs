using System.ComponentModel.DataAnnotations;

namespace AzurLaneAPI.Domain.Dtos.Auth;

public class LoginDto
{
	[Required] public string UserName { get; set; }
	[Required] public string Password { get; set; }
}