using System;

namespace AzurLaneAPI.Routes.V1
{
    public static class Routes
    {
        public const String Base = "/v1";

        public static class Ships
        {
            public const String GetShips = "/ships";
            public const String GetShipById = "/ships/{shipId}";
            public const String CreateShip = "/ships";
            public const String UpdateShip = "/ships/{id}";
            public const String DeleteShip = "/ships/{id}";
        }
    }
}