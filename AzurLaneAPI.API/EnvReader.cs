namespace AzurLaneAPI.API;

public static class EnvReader
{
	public static string GetConnString() =>
		Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
		throw new Exception("Database connection string Environment Variable was not set");

	public static string GetSigningKey() =>
		Environment.GetEnvironmentVariable("SIGNING_KEY") ??
		throw new Exception("Signing key Environment Variable was not set");
}