using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzurLaneClasses.Ship
{
    /// <summary>
    /// A ship's skin
    /// </summary>
    public class ShipSkin
    {
        [JsonIgnore] public Guid Id { get; set; } = Guid.NewGuid();
        public String Name { get; set; }
        public String ImageUrl { get; set; }
        public String BackgroundUrl { get; set; }
        public String ChibiUrl { get; set; }
        public Boolean Live2dModel { get; set; }
        public String ObtainedFrom { get; set; }
    }
}