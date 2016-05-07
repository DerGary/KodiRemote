using KodiRemote.Code.JSON.KAddons.Results;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.AddonTables {
    [Table("Addons")]
    public class AddonTableEntry {
        [PrimaryKey]
        public string addonid { get; set; }
        public float rating { get; set; }
        public string author { get; set; }
        public bool broken { get; set; }
        public bool enabled { get; set; }
        public string description { get; set; }
        public string disclaimer { get; set; }
        public string fanart { get; set; }
        public string name { get; set; }
        public string summary { get; set; }
        public string thumbnail { get; set; }
        public string type { get; set; }
        public string version { get; set; }
        public AddonTableEntry() {

        }
        public AddonTableEntry(float rating, string addonid, string author, bool broken, bool enabled, string description, string disclaimer, string fanart, string name, string summary, string thumbnail, string type, string version) {
            update(rating, addonid, author, broken, enabled, description, disclaimer, fanart, name, summary, thumbnail, type, version);
        }
        public AddonTableEntry(Addon addon) {
            update(addon);
        }
        public void update(Addon addon) {
            update(addon.Rating, addon.AddonId, addon.Author, addon.Broken, addon.Enabled, addon.Description, addon.Disclaimer, addon.Fanart, addon.Name, addon.Summary, addon.Thumbnail, addon.Type, addon.Version);
        }
        public void update(float rating, string addonid, string author, bool broken, bool enabled, string description, string disclaimer, string fanart, string name, string summary, string thumbnail, string type, string version) {
            this.rating = rating;
            this.addonid = addonid;
            this.author = author;
            this.broken = broken;
            this.enabled = enabled;
            this.description = description;
            this.disclaimer = disclaimer;
            this.fanart = fanart;
            this.name = name;
            this.summary = summary;
            this.thumbnail = thumbnail;
            this.type = type;
            this.version = version;
        }
    }
}
