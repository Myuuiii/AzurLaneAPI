using System;

namespace AzurLaneClasses
{
    public class ConstructionPool
    {
        public ConstructionPool(Int32 coins, Int32 wisdomCubes, Boolean cV, Boolean cVL, Boolean dD, Boolean cL, Boolean cA, Boolean bM, Boolean bC, Boolean bB, Boolean aR, Boolean sS)
        {
            this.Coins = coins;
            this.WisdomCubes = wisdomCubes;
            this.CV = cV;
            this.CVL = cVL;
            this.DD = dD;
            this.CL = cL;
            this.CA = cA;
            this.BM = bM;
            this.BC = bC;
            this.BB = bB;
            this.AR = aR;
            this.SS = sS;
        }

        public Int32 Coins { get; set; } = 600;
        public Int32 WisdomCubes { get; set; } = 1;

        public Boolean CV { get; set; }
        public Boolean CVL { get; set; }

        public Boolean DD { get; set; }

        public Boolean CL { get; set; }
        public Boolean CA { get; set; }

        public Boolean BM { get; set; }
        public Boolean BC { get; set; }
        public Boolean BB { get; set; }

        public Boolean AR { get; set; }

        public Boolean SS { get; set; }
    }
}