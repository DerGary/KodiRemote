using KodiRemote.Code.Database.Utils;
using KodiRemote.Code.JSON.KAddons.Results;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.AddonTables {
    [Table("Addons")]
    public class AddonTableEntry : TableEntryBase {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AddonId { get; set; }
        public float Rating { get; set; }
        public string Author { get; set; }
        public bool Broken { get; set; }
        public bool Enabled { get; set; }
        public string Description { get; set; }
        public string Disclaimer { get; set; }
        public string Fanart { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Thumbnail { get; set; }
        public string Type { get; set; }
        public string Version { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return AddonId;
            }
        }

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
            this.Rating = rating;
            this.AddonId = addonid;
            this.Author = author;
            this.Broken = broken;
            this.Enabled = enabled;
            this.Description = description;
            this.Disclaimer = disclaimer;
            this.Fanart = fanart;
            this.Name = name;
            this.Summary = summary;
            this.Thumbnail = thumbnail;
            this.Type = type;
            this.Version = version;
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as AddonTableEntry);
        }

        public bool Equals(AddonTableEntry other) {
            if((object) other == null) {
                return false;
            }
            return IsKeyEqual(other)
                && Rating == other.Rating
                && Author == other.Author
                && Broken == other.Broken
                && Enabled == other.Enabled
                && Description == other.Description
                && Disclaimer == other.Disclaimer
                && Fanart == other.Fanart
                && Name == other.Name
                && Summary == other.Summary
                && Thumbnail == other.Thumbnail
                && Type == other.Type
                && Version == other.Version;
        }

        public override bool IsKeyEqual(TableEntryBase other) {
            var obj = other as AddonTableEntry;
            return AddonId == obj?.AddonId;
        }

        public override int GetHashCode() {
            return AddonId.GetHashCode();
        }
    }
}
