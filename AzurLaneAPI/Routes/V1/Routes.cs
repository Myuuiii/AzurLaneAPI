using System;

namespace AzurLaneAPI.Routes.V1
{
    public static class Routes
    {
        public const String Base = "/v1";

        public static class Ships
        {
            public const String GetAll = "/ships";
            public const String GetId = "/ships/{shipId}";
            public const String Create = "/ships";
            public const String Update = "/ships/{id}";
            public const String Delete = "/ships/{id}";

            public static class ShipStats 
            {
                public const String GetAll = "/ships/stats";
                public const String GetId = "/ships/stats/{statsId}";
                public const String Create = "/ships/stats/{shipId}";
                public const String Update = "/ships/stats/{statsId}";
                public const String Delete = "/ships/stats/{statsId}";
            }
        }

        public static class Events 
        {
            public const String GetAll = "/events";
            public const String GetId = "/events/{eventId}";
            public const String Create = "/events";
            public const String Update = "/events/{eventId}";
            public const String Delete = "/events/{eventId}";
        }

        public static class Campaign {
            public const String GetAll = "/campaign";
            public const String GetId = "/campaign/{id}";
            public const String GetSelect = "/campaign/{chapter}/{level}";
        }
    }
}