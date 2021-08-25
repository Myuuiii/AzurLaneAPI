using System;
using System.IO;
using Newtonsoft.Json;

namespace AzurLaneClasses
{
	public class ConfigLoader
	{
		private const String ConfigFileName = "./appConfiguration.json";

		public static ApplicationConfiguration GetConfiguration()
		{
			if (File.Exists(ConfigFileName))
			{
				return JsonConvert.DeserializeObject<ApplicationConfiguration>(File.ReadAllText(ConfigFileName));
			}
			else
			{
				File.WriteAllText(ConfigFileName, JsonConvert.SerializeObject(new ApplicationConfiguration()));
				throw new FileNotFoundException("A new configuration file has been created due to it not existing.");
			}
		}
	}
}