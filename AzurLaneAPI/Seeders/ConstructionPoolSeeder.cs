using System.Linq;
using AzurLaneClasses;

namespace AzurLaneAPI.Seeders
{
    public class ConstructionPoolSeeder
    {
        public static void Seed()
        {
            AzurLaneDbContext ctx = new AzurLaneDbContext();

            if (ctx.ConstructionPools.ToArray().Length == 0)
            {
                ctx.ConstructionPools.Add(new ConstructionPool(600, 1, false, true, true, true, false, false, false, false, true, false) { Name = "Light" });
                ctx.ConstructionPools.Add(new ConstructionPool(1500, 2, false, false, false, true, true, true, true, true, false, false) { Name = "Heavy" });
                ctx.ConstructionPools.Add(new ConstructionPool(1500, 2, true, true, false, true, true, false, false, false, true, true) { Name = "Special" });
                ctx.SaveChanges();
            }
        }
    }
}