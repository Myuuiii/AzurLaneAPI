using Microsoft.AspNetCore.Identity;

namespace AzurLaneAPI.Domain.Identity;

public class ApiUserRole : IdentityUserRole<Guid>
{
	public ApiUser User { get; set; }
	public ApiRole Role { get; set; }
}