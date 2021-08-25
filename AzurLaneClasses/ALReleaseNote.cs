using System;

namespace AzurLaneClasses
{
	public class ALReleaseNote
	{
		public Int32 Id { get; set; }
		public String Title { get; set; }
		public String Version { get; set; }
		public String Description { get; set; }
		public DateTime Created { get; private set; } = DateTime.Now;
	}
}