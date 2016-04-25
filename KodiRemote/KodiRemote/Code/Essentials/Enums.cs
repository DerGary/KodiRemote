using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Essentials.Enums {
    public class ItemTypeEnum : StringEnum {
        public static readonly ItemTypeEnum Unknown = new ItemTypeEnum(0,"unknown" );
        public static readonly ItemTypeEnum Movie  = new ItemTypeEnum(1,"movie"  );
        public static readonly ItemTypeEnum Episode  = new ItemTypeEnum(2,"episode"  );
        public static readonly ItemTypeEnum Musicvideo  = new ItemTypeEnum(3,"musicvideo"  );
        public static readonly ItemTypeEnum Song  = new ItemTypeEnum(4,"song"  );
        public static readonly ItemTypeEnum Picture  = new ItemTypeEnum(5,"picture"  );
        public static readonly ItemTypeEnum Channel = new ItemTypeEnum(6,"channel" );

        public ItemTypeEnum(int value, string name) : base(value, name) {
        }
    }
    public class PlayerTypeEnum : StringEnum {
        public static readonly PlayerTypeEnum Audio = new PlayerTypeEnum(0, "audio");
        public static readonly PlayerTypeEnum Video = new PlayerTypeEnum(1, "video");
        public static readonly PlayerTypeEnum Picture = new PlayerTypeEnum(2, "picture");

        public PlayerTypeEnum(int value, string name) : base(value, name) {
        }
    }
    public class PlaylistTypeEnum : StringEnum {
        public static readonly PlaylistTypeEnum Audio = new PlaylistTypeEnum(0, "audio");
        public static readonly PlaylistTypeEnum Video = new PlaylistTypeEnum(1, "video");
        public static readonly PlaylistTypeEnum Picture = new PlaylistTypeEnum(2, "picture");
        public static readonly PlaylistTypeEnum Unkown = new PlaylistTypeEnum(3, "unknown");
        public static readonly PlaylistTypeEnum Mixed = new PlaylistTypeEnum(4, "mixed");

        public PlaylistTypeEnum(int value, string name) : base(value, name) {
        }
    }
}
