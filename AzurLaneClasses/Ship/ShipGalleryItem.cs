using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AzurLaneClasses.Ship
{
    public class ShipGalleryItem
    {
        [JsonIgnore] public Guid Id { get; set; }
        public String Description { get; set; }
        public String Url { get; set; }
    }
}