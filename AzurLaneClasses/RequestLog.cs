using System;

namespace AzurLaneClasses
{
	public class RequestLog
	{
		public Int32 Id { get; set; }
		public String Method { get; set; }
		public String Path { get; set; }
		public String QueryString { get; set; }
		public String Protocol { get; set; }
		public String ContentType { get; set; }
		public String ResonseStatusCode { get; set; } = "";
		public String AppliedToken { get; set; }
		public DateTime ExecutionTime { get; set; } = DateTime.UtcNow;
	}
}