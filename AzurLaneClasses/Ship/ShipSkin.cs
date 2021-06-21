using System;
using System.ComponentModel.DataAnnotations;

namespace AzurLaneClasses.Ship
{
    /// <summary>
    /// A ship's skin
    /// </summary>
    public class ShipSkin
    {
        // * Identity Properties
        [Key] public Guid Id { get; set; }
        public String ShipId { get; set; }

        // * Properties
        public String Name_English { get; set; }
        public String Name_Japanese { get; set; }
        public String Name_Chinese { get; set; }

        public String FullImage { get; set; }
        public String ChibiImage { get; set; }
    }
}