using System;

namespace AzurLaneClasses
{
    public class CampaignLevel
    {
        public Guid Id {get;set;}
        public Int32 Chapter {get;set;}
        public Int32 Level {get;set;}
        public String EN_Name {get;set;}
        public String CN_Name {get;set;}
        public String JP_Name {get;set;}
    }
}