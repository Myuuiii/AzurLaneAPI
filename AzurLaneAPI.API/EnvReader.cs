﻿namespace AzurLaneAPI.API;

public static class EnvReader
{
	public static string GetConnString()
	{
		return Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
		       throw new Exception("Database connection string Environment Variable was not set");
	}
}