using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AzurLaneClasses
{
	public class Barrage
	{
		public Barrage(){}
		
		public String Id { get; set; }
		public String Name { get; set; }
		public String Type { get; set; }
		public String IconUrl { get; set; }
		public String ImageUrl { get; set; }
		public String Hull { get; set; }
		public IEnumerable<String> Ships { get; set; }
		public List<Round> Rounds { get; set; }
	}

	public class Round
	{
		public Round(){}
		public Round(String type, Double dmgL, Double dmgM, Double dmgH, String note)
		{
			this.Type = type;
			this.DmgL = dmgL;
			this.DmgM = dmgM;
			this.DmgH = dmgH;
			this.Note = note;
		}
		
		[JsonIgnore]
		public Guid Id { get; set; }
        public String Type { get; set; }
        public Double DmgL { get; set; }
        public Double DmgM { get; set; }
        public Double DmgH { get; set; }
        public String Note { get; set; }
	}
}