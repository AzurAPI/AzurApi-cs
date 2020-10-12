using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzurApi
{
#nullable enable
#nullable disable warnings
    public class AzurShip
    {
        public string wikiUrl;
        public string id;
        public ShipNames names;
        [JsonProperty("class")]
        public string shipClass;
        public string nationality;
        public string hullType;
        public string thumbnail;
        public string rarity;
        public ShipStars stars;
        public ShipStatsList stats;
        public ShipSlotsList slots;
        public ShipEnhanced enhanceValue;
        public ShipScrap scrapValue;
        public ShipSkill[] skills = new ShipSkill[0];
        public List<string[]> limitBreaks = new List<string[]>();
        public ShipFleetTech fleetTech;
        public bool retrofit;
        public string retrofitId;
        public ShipRetrofitProjectList? retrofitProjects;
        public ShipConstruction construction;
        public ShipObtained obtainedFrom;
        public ShipMisc misc;
        public ShipSkin[] skins;
        public ShipGallery[] gallery = new ShipGallery[0];
    }
    public class ShipNames
    {
        public string en;
        public string code;
        public string cn;
        public string jp;
        public string kr;
    }
    public class ShipStars
    {
        public string stars;
        public int value;
    }
    public class ShipStatsList
    {
        public ShipStats baseStats;
        public ShipStats level100;
        public ShipStats level120;
        public ShipStats? level100Retrofit;
        public ShipStats? level120Retrofit;
    }
    public class ShipStats
    {
        public string health;
        public string armor;
        public string reload;
        public string luck;
        public string firepower;
        public string torpedo;
        public string evasion;
        public string speed;
        public string antiair;
        public string aviation;
        public string oilConsumption;
        public string accuracy;
        public string antisubmarineWarfare;
        public string oxygen;
        public string ammunition;
    }
    public class ShipSlotsList
    {
        [JsonProperty("1")]
        public ShipSlot one;

        [JsonProperty("2")]
        public ShipSlot two;

        [JsonProperty("3")]
        public ShipSlot three;
    }
    public class ShipSlot
    {
        public string type;
        public int minEfficiency;
        public int maxEfficiency;
    }
    public class ShipEnhanced
    {
        public int firepower;
        public int torpedo;
        public int aviation;
        public int reload;
    }
    public class ShipScrap
    {
        public int coin;
        public int oil;
        public int medal;
    }
    public class ShipSkill
    {
        public string icon;
        public ShipSkillNames names;
        public string description;
        public string color;
    }
    public class ShipSkillNames
    {
        public string en;
        public string cn;
        public string jp;
    }
    public class ShipFleetTech
    {
        public ShipTechStats statsBonus;
        public ShipTechPoints techPoints;
    }
    public class ShipTechStats
    {
        public ShipTechCollection? collection;
        public ShipTechCollection? maxLevel;
    }
    public class ShipTechCollection
    {
        public string[] applicable = new string[0];
        public string stat;
        public string bonus;
    }
    public class ShipTechPoints
    {
        public int collection;
        public int maxLimitBreak;
        public int maxLevel;
        public int total;
    }
    public class ShipConstruction
    {
        public string constructionTime;
        public bool canBeConstructed
        {
            get { if (constructionTime == "Cannot Be Constructed") return false; return true; }
        }
        public ShipConstructAvailable availableIn;
    }
    public class ShipConstructAvailable
    {
        public bool light;
        public bool heavy;
        public bool aviation;
        public bool limited;
        public bool exchange;
    }
    public class ShipObtained
    {
        public string obtainedFrom;
        public string[] fromMaps = new string[0];
    }
    public class ShipMisc
    {
        public ShipSource? artist;
        public ShipSource? pixiv;
        public ShipSource? twitter;
        public ShipSource? web;
        public ShipSource? voice;
    }
    public class ShipSource
    {
        public string name;
        public string url;
    }
    public class ShipSkin
    {
        public string name;
        public string image;
        public string background;
        public string chibi;
        public ShipSkinInfo info;
    }
    public class ShipSkinInfo
    {
        public string obtainedFrom;
        public bool live2dModel;
    }

    public class ShipRetrofitProjectList
    {
        public ShipRetrofitProject A;
        public ShipRetrofitProject B;
        public ShipRetrofitProject C;
        public ShipRetrofitProject D;
        public ShipRetrofitProject E;
        public ShipRetrofitProject F;
        public ShipRetrofitProject G;
        public ShipRetrofitProject H;
        public ShipRetrofitProject I;
        public ShipRetrofitProject J;
        public ShipRetrofitProject K;
    }
    public class ShipRetrofitProject
    {
        public string name;
        public string grade;
        public string[] attributes = new string[0];
        public string[] materials = new string[0];
        public int coins;
        public int level;
        public int levelBreakLevel;
        public string levelBreakStars;
        public int recurrence;
        public string[] require = new string[0];
    }
    public class ShipGallery
    {
        public string description;
        public string url;
    }
}
