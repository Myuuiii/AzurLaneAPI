using System;

namespace AzurLaneAPI.Routes.V1
{
    public static class Routes
    {
        public const String Base = "/v1";

        public static class Ships
        {
            public const String GetAll = "/ships";
            public const String GetId = "/ships/{id}";
            public const String Create = "/ships";
            public const String Update = "/ships/{id}";
            public const String Delete = "/ships/{id}";

            public static class ShipStats
            {
                public const String GetAll = "/ships/stats";
                public const String GetId = "/ships/stats/{id}";
                public const String Create = "/ships/stats/{id}";
                public const String Update = "/ships/stats/{id}";
                public const String Delete = "/ships/stats/{id}";
            }
        }

        public static class Events
        {
            public const String GetAll = "/events";
            public const String GetId = "/events/{id}";
            public const String Create = "/events";
            public const String Update = "/events/{eventId}";
            public const String Delete = "/events/{eventId}";
        }

        public static class Campaign
        {
            public const String GetAll = "/campaign";
            public const String GetId = "/campaign/{id}";
            public const String GetSelect = "/campaign/{chapter}/{level}";
        }

        public static class Construction
        {
            public const String GetPools = "/construction";
            public const String GetPool = "/construction/{id}";
        }

        public static class Equipment
        {
            public static class Guns 
            {
                public const String GetAll = "/equipment/guns";
                public const String GetId = "/equipment/guns/{id}";
                public const String Create = "/equipment/guns";
                public const String Update = "/equipment/guns/{id}";
                public const String Delete = "/equipment/guns/{id}";
            }

            public static class Torpedoes 
            {
                public const String GetAll = "/equipment/torpedoes";
                public const String GetId = "/equipment/torpedoes/{id}";
                public const String Create = "/equipment/torpedoes";
                public const String Update = "/equipment/torpedoes/{id}";
                public const String Delete = "/equipment/torpedoes/{id}";
            }

            public static class Planes
            {
                public const String GetAll = "/equipment/planes";
                public const String GetId = "/equipment/planes/{id}";
                public const String Create = "/equipment/planes";
                public const String Update = "/equipment/planes/{id}";
                public const String Delete = "/equipment/planes/{id}";
            }

            public static class AntiAir
            {
                public const String GetAll = "/equipment/antiair";
                public const String GetId = "/equipment/antiair/{id}";
                public const String Create = "/equipment/antiair";
                public const String Update = "/equipment/antiair/{id}";
                public const String Delete = "/equipment/antiair/{id}";
            }

            public static class Auxiliary 
            {
                public const String GetAll = "/equipment/auxiliary";
                public const String GetId = "/equipment/auxiliary/{id}";
                public const String Create = "/equipment/auxiliary";
                public const String Update = "/equipment/auxiliary/{id}";
                public const String Delete = "/equipment/auxiliary/{id}";
            }

            public static class Cargo 
            {
                public const String GetAll = "/equipment/cargo";
                public const String GetId = "/equipment/cargo/{id}";
                public const String Create = "/equipment/cargo";
                public const String Update = "/equipment/cargo/{id}";
                public const String Delete = "/equipment/cargo/{id}";
            }

            public static class AntiSubmarine 
            {
                public const String GetAll = "/equipment/antisubmarine";
                public const String GetId = "/equipment/antisubmarine/{id}";
                public const String Create = "/equipment/antisubmarine";
                public const String Update = "/equipment/antisubmarine/{id}";
                public const String Delete = "/equipment/antisubmarine/{id}";
            }
        }
    }
}