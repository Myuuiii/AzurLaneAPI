namespace AzurLaneAPI.Domain.Identity;

public class SignupCode
{
	public int Id { get; set; }
	public string Code { get; set; }
	public DateTime Expiration { get; set; }
	public bool Used { get; set; }
	public DateTime? UsedAt { get; set; }
	public string? UsedBy { get; set; }
}