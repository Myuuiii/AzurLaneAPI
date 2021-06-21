using System;
using System.ComponentModel.DataAnnotations;

namespace AzurLaneClasses.Ship
{
    /// <summary>
    /// A ship's class
    /// </summary>
    public class ShipClass
    {
        [Key] public Guid Id { get; set; }
        public String Name { get; set; }
        public String Summary { get; set; }
    }
}