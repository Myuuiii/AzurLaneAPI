using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using AzurLaneClasses.Import;

namespace AzurLaneClasses
{
	public class Barrage
	{
		public Barrage(){}
		public Barrage(BarrageDataImportModel importModel)
		{
			this.Id = importModel.id;
			this.Name = importModel.name;
			this.Type = importModel.type;
			this.IconUrl = importModel.icon;
			this.ImageUrl = importModel.image;
			this.Hull = importModel.hull;
			this.Ships = importModel.ships;

			this.Rounds = new List<Round>();
			foreach (var round in importModel.rounds)
			{
				this.Rounds.Add(new Round {
					Type = round.type,
					DmgL = round.dmgL,
					DmgM = round.dmgM,
					DmgH = round.dmgH,
					Note = round.note
				});
			}
		}
		
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