using Microsoft.AspNetCore.Identity;

namespace AzurLaneAPI.Domain.Identity;

public class ApiRole : IdentityRole<Guid>
{
	public ICollection<ApiUserRole> UserRoles { get; set; }
}