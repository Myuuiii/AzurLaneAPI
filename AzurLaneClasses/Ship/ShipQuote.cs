using System;
using Newtonsoft.Json;

namespace AzurLaneClasses.Ship
{
	public class ShipQuote
	{
		[JsonIgnore]
		public Guid Id { get; set; }

		public String Skin { get; set; }
		public String Event { get; set; }
		public String AudioUrl { get; set; }
		public String EN_Transcription { get; set; }
		public String JP_Transcription { get; set; }
		public String CN_Transcription { get; set; }
		public String Notes { get; set; }
	}
}