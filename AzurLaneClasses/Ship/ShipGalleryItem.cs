using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzurLaneClasses.Ship
{
    public class ShipGalleryItem
    {
        [JsonIgnore] public Guid Id { get; set; }
        public String Description { get; set; }
        public String Url { get; set; }
    }
}