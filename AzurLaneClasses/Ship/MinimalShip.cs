using System;

namespace AzurLaneClasses.Ship
{
    public class MinimalShip
    {
        public MinimalShip(Ship ship)
        { 
            this.Id = ship.Id;
            this.ShipId = ship.ShipId;
            this.Name = ship.Name;
            this.Thumbnail = ship.ThumbnailImage;
        }

        public Guid Id { get; set; }
        public String ShipId { get; set; }
        public String Name { get; set; }
        public String Thumbnail { get; set; }
    }
}