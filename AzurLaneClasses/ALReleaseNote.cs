using System;
using System.Text.Json.Serialization;

namespace AzurLaneClasses
{
	public class ALReleaseNote
	{
		[JsonIgnore]
		public Int32 Id { get; set; }
		public String Title { get; set; }
		public String Version { get; set; }
		public String Description { get; set; }
		public DateTime Created { get; private set; } = DateTime.Now;
	}
}