using System;

namespace AzurLaneAPI.Routes.V1
{
    public static class Routes
    {
        public const String Base = "/v1";

        public static class Ships
        {
            public const String GetAll = "/ships";
            public const String GetAllMinimal = "/ships/minimal";
            public const String GetId = "/ships/{id}";
            public const String GetMinimalId = "/ships/{id}/minimal";
            public const String GetName = "/ships/name/{name}";
            public const String GetMinimalName = "/ships/name/{name}/minimal";
            public const String Import = "/ships/";

            public static class ShipSkins
            {
                public const String GetAll = "/shipskins";
                public const String GetAllByShipId = "/shipskins/{id}";
                public const String GetAllByShipName = "/shipskins/name/{name}";
            }

            public static class ShipStats
            {
                public const String Base = "/ships/{id}/basestats";
                public const String BaseName = "/ships/name/{name}/basestats";

                public const String Lvl100 = "/ships/{id}/lvl100stats";
                public const String Lvl100Name = "/ships/name/{name}/lvl100stats";

                public const String Lvl100Retro = "/ships/{id}/lvl100retrofitstats";
                public const String Lvl100RetroName = "/ships/name/{name}/lvl100retrofitstats";

                public const String Lvl120 = "/ships/{id}/lvl120stats";
                public const String Lvl120Name = "/ships/name/{name}/lvl120stats";
                
                public const String Lvl120Retro = "/ships/{id}/lvl120retrofitstats";
                public const String Lvl120RetroName = "/ships/name/{name}/lvl120retrofitstats";
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
            public static class DestroyerGuns
            {
                public const String GetAll = "/equipment/destroyerguns";
                public const String GetId = "/equipment/destroyerguns/{id}";
                public const String Create = "/equipment/destroyerguns";
                public const String Update = "/equipment/destroyerguns/{id}";
                public const String Delete = "/equipment/destroyerguns/{id}";
            }

            public static class LightCruiserGuns
            {
                public const String GetAll = "/equipment/lightcruiserguns";
                public const String GetId = "/equipment/lightcruiserguns/{id}";
                public const String Create = "/equipment/lightcruiserguns";
                public const String Update = "/equipment/lightcruiserguns/{id}";
                public const String Delete = "/equipment/lightcruiserguns/{id}";
            }

            public static class HeavyCruiserGuns
            {
                public const String GetAll = "/equipment/heavycruiserguns";
                public const String GetId = "/equipment/heavycruiserguns/{id}";
                public const String Create = "/equipment/heavycruiserguns";
                public const String Update = "/equipment/heavycruiserguns/{id}";
                public const String Delete = "/equipment/heavycruiserguns/{id}";
            }

            public static class LargeCruiserGuns
            {
                public const String GetAll = "/equipment/largecruiserguns";
                public const String GetId = "/equipment/largecruiserguns/{id}";
                public const String Create = "/equipment/largecruiserguns";
                public const String Update = "/equipment/largecruiserguns/{id}";
                public const String Delete = "/equipment/largecruiserguns/{id}";
            }

            public static class BattleshipGuns
            {
                public const String GetAll = "/equipment/battleshipguns";
                public const String GetId = "/equipment/battleshipguns/{id}";
                public const String Create = "/equipment/battleshipguns";
                public const String Update = "/equipment/battleshipguns/{id}";
                public const String Delete = "/equipment/battleshipguns/{id}";
            }

            public static class Torpedoes
            {
                public const String GetAll = "/equipment/torpedoes";
                public const String GetId = "/equipment/torpedoes/{id}";
                public const String Create = "/equipment/torpedoes";
                public const String Update = "/equipment/torpedoes/{id}";
                public const String Delete = "/equipment/torpedoes/{id}";
            }

            public static class SubmarineTorpedoes
            {
                public const String GetAll = "/equipment/submarinetorpedoes";
                public const String GetId = "/equipment/submarinetorpedoes/{id}";
                public const String Create = "/equipment/submarinetorpedoes";
                public const String Update = "/equipment/submarinetorpedoes/{id}";
                public const String Delete = "/equipment/submarinetorpedoes/{id}";
            }

            public static class FighterPlanes
            {
                public const String GetAll = "/equipment/fighterplanes";
                public const String GetId = "/equipment/fighterplanes/{id}";
                public const String Create = "/equipment/fighterplanes";
                public const String Update = "/equipment/fighterplanes/{id}";
                public const String Delete = "/equipment/fighterplanes/{id}";
            }

            public static class DiveBomberPlanes
            {
                public const String GetAll = "/equipment/divebomberplanes";
                public const String GetId = "/equipment/divebomberplanes/{id}";
                public const String Create = "/equipment/divebomberplanes";
                public const String Update = "/equipment/divebomberplanes/{id}";
                public const String Delete = "/equipment/divebomberplanes/{id}";
            }

            public static class TorpedoBomberPlanes
            {
                public const String GetAll = "/equipment/torpedobomberplanes";
                public const String GetId = "/equipment/torpedobomberplanes/{id}";
                public const String Create = "/equipment/torpedobomberplanes";
                public const String Update = "/equipment/torpedobomberplanes/{id}";
                public const String Delete = "/equipment/torpedobomberplanes/{id}";
            }

            public static class Seaplanes
            {
                public const String GetAll = "/equipment/seaplanes";
                public const String GetId = "/equipment/seaplanes/{id}";
                public const String Create = "/equipment/seaplanes";
                public const String Update = "/equipment/seaplanes/{id}";
                public const String Delete = "/equipment/seaplanes/{id}";
            }

            public static class AntiAirGuns
            {
                public const String GetAll = "/equipment/antiairguns";
                public const String GetId = "/equipment/antiairguns/{id}";
                public const String Create = "/equipment/antiairguns";
                public const String Update = "/equipment/antiairguns/{id}";
                public const String Delete = "/equipment/antiairguns/{id}";
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