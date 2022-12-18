using Microsoft.AspNetCore.Identity;

namespace AzurLaneAPI.Domain.Identity;

public class ApiUser : IdentityUser<Guid>
{
	public ICollection<ApiUserRole> UserRoles { get; set; }
}