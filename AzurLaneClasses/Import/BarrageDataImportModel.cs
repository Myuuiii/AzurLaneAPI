using System;
using System.Collections.Generic;

namespace AzurLaneClasses.Import
{
    		public class Round
		{
			public String type { get; set; }
			public Double dmgL { get; set; }
			public Double dmgM { get; set; }
			public Double dmgH { get; set; }
			public String note { get; set; }
		}

		public class BarrageDataImportModel
		{
			public String id { get; set; }
			public String type { get; set; }
			public String icon { get; set; }
			public String name { get; set; }
			public List<String> ships { get; set; }
			public String hull { get; set; }
			public List<Round> rounds { get; set; }
			public String image { get; set; }
		}
}