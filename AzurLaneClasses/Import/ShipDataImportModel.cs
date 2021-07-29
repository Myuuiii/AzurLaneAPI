using System.Collections.Generic;

namespace AzurLaneClasses.Import
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Names
    {
        public string cn { get; set; }
        public string code { get; set; }
        public string jp { get; set; }
        public string kr { get; set; }
        public string en { get; set; }
        public string tw { get; set; }
    }

    public class Exists
    {
        public bool en { get; set; }
        public bool cn { get; set; }
        public bool jp { get; set; }
        public bool kr { get; set; }
    }

    public class Stars
    {
        public string stars { get; set; }
        public int value { get; set; }
    }

    public class BaseStats
    {
        public string health { get; set; }
        public string armor { get; set; }
        public string reload { get; set; }
        public string luck { get; set; }
        public string firepower { get; set; }
        public string torpedo { get; set; }
        public string evasion { get; set; }
        public string speed { get; set; }
        public string antiair { get; set; }
        public string aviation { get; set; }
        public string oilConsumption { get; set; }
        public string accuracy { get; set; }
        public string antisubmarineWarfare { get; set; }
        public string oxygen { get; set; }
        public string ammunition { get; set; }
        public string huntingRange { get; set; }
    }

    public class Level100
    {
        public string health { get; set; }
        public string armor { get; set; }
        public string reload { get; set; }
        public string luck { get; set; }
        public string firepower { get; set; }
        public string torpedo { get; set; }
        public string evasion { get; set; }
        public string speed { get; set; }
        public string antiair { get; set; }
        public string aviation { get; set; }
        public string oilConsumption { get; set; }
        public string accuracy { get; set; }
        public string antisubmarineWarfare { get; set; }
        public string oxygen { get; set; }
        public string ammunition { get; set; }
        public string huntingRange { get; set; }
    }

    public class Level120
    {
        public string health { get; set; }
        public string armor { get; set; }
        public string reload { get; set; }
        public string luck { get; set; }
        public string firepower { get; set; }
        public string torpedo { get; set; }
        public string evasion { get; set; }
        public string speed { get; set; }
        public string antiair { get; set; }
        public string aviation { get; set; }
        public string oilConsumption { get; set; }
        public string accuracy { get; set; }
        public string antisubmarineWarfare { get; set; }
        public string oxygen { get; set; }
        public string ammunition { get; set; }
        public string huntingRange { get; set; }
    }

    public class Level100Retrofit
    {
        public string health { get; set; }
        public string armor { get; set; }
        public string reload { get; set; }
        public string luck { get; set; }
        public string firepower { get; set; }
        public string torpedo { get; set; }
        public string evasion { get; set; }
        public string speed { get; set; }
        public string antiair { get; set; }
        public string aviation { get; set; }
        public string oilConsumption { get; set; }
        public string accuracy { get; set; }
        public string antisubmarineWarfare { get; set; }
    }

    public class Level120Retrofit
    {
        public string health { get; set; }
        public string armor { get; set; }
        public string reload { get; set; }
        public string luck { get; set; }
        public string firepower { get; set; }
        public string torpedo { get; set; }
        public string evasion { get; set; }
        public string speed { get; set; }
        public string antiair { get; set; }
        public string aviation { get; set; }
        public string oilConsumption { get; set; }
        public string accuracy { get; set; }
        public string antisubmarineWarfare { get; set; }
    }

    public class Stats
    {
        public BaseStats baseStats { get; set; }
        public BaseStats level100 { get; set; }
        public BaseStats level120 { get; set; }
        public BaseStats level100Retrofit { get; set; }
        public BaseStats level120Retrofit { get; set; }
    }

    public class Slot
    {
        public int maxEfficiency { get; set; }
        public int minEfficiency { get; set; }
        public string type { get; set; }
        public int max { get; set; }
        public int? kaiEfficiency { get; set; }
    }

    public class EnhanceValue
    {
        public int firepower { get; set; }
        public int torpedo { get; set; }
        public int aviation { get; set; }
        public int reload { get; set; }
    }

    public class ScrapValue
    {
        public int coin { get; set; }
        public int oil { get; set; }
        public int medal { get; set; }
    }

    public class Skill
    {
        public string icon { get; set; }
        public Names names { get; set; }
        public string description { get; set; }
        public string color { get; set; }
    }

    public class Collection
    {
        public List<string> applicable { get; set; }
        public string bonus { get; set; }
        public string stat { get; set; }
    }

    public class MaxLevel
    {
        public List<string> applicable { get; set; }
        public string bonus { get; set; }
        public string stat { get; set; }
    }

    public class StatsBonus
    {
        public Collection collection { get; set; }
        public MaxLevel maxLevel { get; set; }
    }

    public class TechPoints
    {
        public int collection { get; set; }
        public int maxLimitBreak { get; set; }
        public int maxLevel { get; set; }
        public int total { get; set; }
    }

    public class FleetTech
    {
        public StatsBonus statsBonus { get; set; }
        public TechPoints techPoints { get; set; }
    }

    public class AvailableIn
    {
        public object light { get; set; }
        public object heavy { get; set; }
        public object aviation { get; set; }
        public object limited { get; set; }
        public object exchange { get; set; }
    }

    public class Construction
    {
        public string constructionTime { get; set; }
        public AvailableIn availableIn { get; set; }
    }

    public class ObtainedFrom
    {
        public string obtainedFrom { get; set; }
        public List<object> fromMaps { get; set; }
    }

    public class Artist
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Pixiv
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Twitter
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Web
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Voice
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Misc
    {
        public Artist artist { get; set; }
        public Pixiv pixiv { get; set; }
        public Twitter twitter { get; set; }
        public Web web { get; set; }
        public Voice voice { get; set; }
    }

    public class Info
    {
        public bool live2dModel { get; set; }
        public string obtainedFrom { get; set; }
        public string enClient { get; set; }
        public string cnClient { get; set; }
        public string jpClient { get; set; }
        public int? cost { get; set; }
    }

    public class Skin
    {
        public string name { get; set; }
        public string image { get; set; }
        public string background { get; set; }
        public string chibi { get; set; }
        public Info info { get; set; }
        public string bg { get; set; }
    }

    public class Gallery
    {
        public string description { get; set; }
        public string url { get; set; }
    }

    public class A
    {
        public string id { get; set; }
        public List<string> attributes { get; set; }
        public List<string> materials { get; set; }
        public int coins { get; set; }
        public int level { get; set; }
        public int levelBreakLevel { get; set; }
        public string levelBreakStars { get; set; }
        public int recurrence { get; set; }
        public List<object> require { get; set; }
        public string grade { get; set; }
    }

    public class B
    {
        public string id { get; set; }
        public List<string> attributes { get; set; }
        public List<string> materials { get; set; }
        public int coins { get; set; }
        public int level { get; set; }
        public int levelBreakLevel { get; set; }
        public string levelBreakStars { get; set; }
        public int recurrence { get; set; }
        public List<string> require { get; set; }
        public string grade { get; set; }
    }

    public class C
    {
        public string id { get; set; }
        public List<string> attributes { get; set; }
        public List<string> materials { get; set; }
        public int coins { get; set; }
        public int level { get; set; }
        public int levelBreakLevel { get; set; }
        public string levelBreakStars { get; set; }
        public int recurrence { get; set; }
        public List<string> require { get; set; }
        public string grade { get; set; }
    }

    public class D
    {
        public string id { get; set; }
        public List<string> attributes { get; set; }
        public List<string> materials { get; set; }
        public int coins { get; set; }
        public int level { get; set; }
        public int levelBreakLevel { get; set; }
        public string levelBreakStars { get; set; }
        public int recurrence { get; set; }
        public List<string> require { get; set; }
        public string grade { get; set; }
    }

    public class E
    {
        public string id { get; set; }
        public List<string> attributes { get; set; }
        public List<string> materials { get; set; }
        public int coins { get; set; }
        public int level { get; set; }
        public int levelBreakLevel { get; set; }
        public string levelBreakStars { get; set; }
        public int recurrence { get; set; }
        public List<string> require { get; set; }
        public string grade { get; set; }
    }

    public class F
    {
        public string id { get; set; }
        public List<string> attributes { get; set; }
        public List<string> materials { get; set; }
        public int coins { get; set; }
        public int level { get; set; }
        public int levelBreakLevel { get; set; }
        public string levelBreakStars { get; set; }
        public int recurrence { get; set; }
        public List<string> require { get; set; }
        public string grade { get; set; }
    }

    public class G
    {
        public string id { get; set; }
        public List<string> attributes { get; set; }
        public List<string> materials { get; set; }
        public int coins { get; set; }
        public int level { get; set; }
        public int levelBreakLevel { get; set; }
        public string levelBreakStars { get; set; }
        public int recurrence { get; set; }
        public List<string> require { get; set; }
        public string grade { get; set; }
    }

    public class H
    {
        public string id { get; set; }
        public List<string> attributes { get; set; }
        public List<string> materials { get; set; }
        public int coins { get; set; }
        public int level { get; set; }
        public int levelBreakLevel { get; set; }
        public string levelBreakStars { get; set; }
        public int recurrence { get; set; }
        public List<string> require { get; set; }
        public string grade { get; set; }
    }

    public class I
    {
        public string id { get; set; }
        public List<string> attributes { get; set; }
        public List<string> materials { get; set; }
        public int coins { get; set; }
        public int level { get; set; }
        public int levelBreakLevel { get; set; }
        public string levelBreakStars { get; set; }
        public int recurrence { get; set; }
        public List<string> require { get; set; }
        public string grade { get; set; }
    }

    public class J
    {
        public string id { get; set; }
        public List<string> attributes { get; set; }
        public List<string> materials { get; set; }
        public int coins { get; set; }
        public int level { get; set; }
        public int levelBreakLevel { get; set; }
        public string levelBreakStars { get; set; }
        public int recurrence { get; set; }
        public List<string> require { get; set; }
        public string grade { get; set; }
    }

    public class K
    {
        public string id { get; set; }
        public List<string> attributes { get; set; }
        public List<string> materials { get; set; }
        public int coins { get; set; }
        public int level { get; set; }
        public int levelBreakLevel { get; set; }
        public string levelBreakStars { get; set; }
        public int recurrence { get; set; }
        public List<string> require { get; set; }
    }

    public class L
    {
        public string id { get; set; }
        public List<string> attributes { get; set; }
        public List<string> materials { get; set; }
        public int coins { get; set; }
        public int level { get; set; }
        public int levelBreakLevel { get; set; }
        public string levelBreakStars { get; set; }
        public int recurrence { get; set; }
        public List<string> require { get; set; }
    }

    public class RetrofitProjects
    {
        public A A { get; set; }
        public B B { get; set; }
        public C C { get; set; }
        public D D { get; set; }
        public E E { get; set; }
        public F F { get; set; }
        public G G { get; set; }
        public H H { get; set; }
        public I I { get; set; }
        public J J { get; set; }
        public K K { get; set; }
        public L L { get; set; }
    }

    public class DevLevel
    {
        public string level { get; set; }
        public List<string> buffs { get; set; }
    }

    public class ShipDataImportModel
    {
        public string wikiUrl { get; set; }
        public string id { get; set; }
        public int _gid { get; set; }
        public List<int> _sid { get; set; }
        public int _code { get; set; }
        public Names names { get; set; }
        public Exists exists { get; set; }
        public List<int> hexagon { get; set; }
        public string @class { get; set; }
        public string nationality { get; set; }
        public string hullType { get; set; }
        public string thumbnail { get; set; }
        public string rarity { get; set; }
        public Stars stars { get; set; }
        public Stats stats { get; set; }
        public List<Slot> slots { get; set; }
        public EnhanceValue enhanceValue { get; set; }
        public ScrapValue scrapValue { get; set; }
        public List<Skill> skills { get; set; }
        public List<List<string>> limitBreaks { get; set; }
        public FleetTech fleetTech { get; set; }
        public Construction construction { get; set; }
        public ObtainedFrom obtainedFrom { get; set; }
        public Misc misc { get; set; }
        public List<Skin> skins { get; set; }
        public List<Gallery> gallery { get; set; }
        public bool? retrofit { get; set; }
        public string retrofitId { get; set; }
        public RetrofitProjects retrofitProjects { get; set; }
        public string retrofitHullType { get; set; }
        public List<DevLevel> devLevels { get; set; }
    }


}