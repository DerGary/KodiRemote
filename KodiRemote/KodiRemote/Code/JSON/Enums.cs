using KodiRemote.Code.Utils;

namespace KodiRemote.Code.JSON.Enums {
    //public enum ToggleEnum { Toggle, True, False }
    public enum OptionalBooleanEnum { Null, True, False }
    public class IncDecEnum : StringEnum {
        public static readonly IncDecEnum Increment = new IncDecEnum(1, "increment");
        public static readonly IncDecEnum Decrement = new IncDecEnum(2, "decrement");

        private IncDecEnum(int value, string name) : base(value, name) { }
    }
    public class ToggleEnum : StringEnum {
        public static readonly ToggleEnum Toggle = new ToggleEnum(1, "toggle");
        public static readonly ToggleEnum True = new ToggleEnum(2, "true");
        public static readonly ToggleEnum False = new ToggleEnum(3, "false");

        private ToggleEnum(int value, string name) : base(value, name) { }
        static public implicit operator bool(ToggleEnum method) {
            if (method == ToggleEnum.True) {
                return true;
            } else {
                return false;
            }
        }

    }
    public class ToEnum : StringEnum {
        public static readonly ToEnum Previous = new ToEnum(1, "previous");
        public static readonly ToEnum Next = new ToEnum(2, "next");

        private ToEnum(int value, string name) : base(value, name) { }
    }
    public class SeekEnum : StringEnum {
        public static readonly SeekEnum SmallForward = new SeekEnum(1, "smallforward");
        public static readonly SeekEnum SmallBackward = new SeekEnum(2, "smallbackward");
        public static readonly SeekEnum BigForward = new SeekEnum(3, "bigforward");
        public static readonly SeekEnum BigBackward = new SeekEnum(4, "bigbackward");

        private SeekEnum(int value, string name) : base(value, name) { }
    }
    public class DirectionEnum : StringEnum {
        public static readonly DirectionEnum Left = new DirectionEnum(1, "left");
        public static readonly DirectionEnum Right = new DirectionEnum(2, "right");
        public static readonly DirectionEnum Up = new DirectionEnum(3, "up");
        public static readonly DirectionEnum Down = new DirectionEnum(4, "down");

        private DirectionEnum(int value, string name) : base(value, name) { }
    }
    public class RotateEnum : StringEnum {
        public static readonly RotateEnum Clockwise = new RotateEnum(1, "clockwise");
        public static readonly RotateEnum CounterClockwise = new RotateEnum(2, "counterclockwise");

        private RotateEnum(int value, string name) : base(value, name) { }
    }
    public class ZoomEnum : StringEnum {
        public static readonly ZoomEnum In = new ZoomEnum(1, "in");
        public static readonly ZoomEnum Out = new ZoomEnum(2, "out");

        private ZoomEnum(int value, string name) : base(value, name) { }
    }
    public class SubtitleEnum : StringEnum {
        public static readonly SubtitleEnum Previous = new SubtitleEnum(1, "previous");
        public static readonly SubtitleEnum Next = new SubtitleEnum(2, "next");
        public static readonly SubtitleEnum Off = new SubtitleEnum(3, "off");
        public static readonly SubtitleEnum On = new SubtitleEnum(4, "on");

        private SubtitleEnum(int value, string name) : base(value, name) { }
    }
    public class ExtendRepeatEnum : StringEnum {
        public static readonly ExtendRepeatEnum Off = new ExtendRepeatEnum(1, "off");
        public static readonly ExtendRepeatEnum One = new ExtendRepeatEnum(2, "one");
        public static readonly ExtendRepeatEnum All = new ExtendRepeatEnum(3, "all");
        public static readonly ExtendRepeatEnum Cycle = new ExtendRepeatEnum(4, "cycle");

        private ExtendRepeatEnum(int value, string name) : base(value, name) { }
    }
    public class OptionalRepeatEnum : StringEnum {
        public static readonly OptionalRepeatEnum Null = new OptionalRepeatEnum(1, "null");
        public static readonly OptionalRepeatEnum Off = new OptionalRepeatEnum(2, "off");
        public static readonly OptionalRepeatEnum One = new OptionalRepeatEnum(3, "one");
        public static readonly OptionalRepeatEnum All = new OptionalRepeatEnum(4, "all");

        private OptionalRepeatEnum(int value, string name) : base(value, name) { }
    }
    public class PartymodeEnum : StringEnum {
        public static readonly PartymodeEnum Music = new PartymodeEnum(1, "music");
        public static readonly PartymodeEnum Video = new PartymodeEnum(2, "video");

        private PartymodeEnum(int value, string name) : base(value, name) { }
    }
    public enum OrderEnum { ascending, descending }
    public enum MethodEnum { none, label, date, size, file, path, drivetype, title, track, time, artist, album, albumtype, genre, country, year, rating, votes, top250, programcount, playlist, episode, season, totalepisodes, watchedepisodes, tvshowstatus, tvshowtitle, sorttitle, productioncode, mpaa, studio, dateadded, lastplayed, playcount, listeners, bitrate, random }
    public enum MediaEnum { NULL, video, music, pictures, files, programs }
    public enum MediaNotNullEnum { video, music, pictures, files, programs }
    public enum EnabledEnum { All, True, False }
    public enum ContentEnum { Null, unknown, video, audio, image, executable }
    public enum AlbumartistonlyEnum { NULL, True, False }
    public enum WindowsEnum { home, programs, pictures, filemanager, files, settings, music, video, videos, tv, pvr, pvrguideinfo, pvrrecordinginfo, pvrtimersetting, pvrgroupmanager, pvrchannelmanager, pvrguidesearch, pvrchannelscan, pvrupdateprogress, pvrosdchannels, pvrosdguide, pvrosddirector, pvrosdcutter, pvrosdteletext, systeminfo, testpattern, screencalibration, guicalibration, picturessettings, programssettings, weathersettings, musicsettings, systemsettings, videossettings, networksettings, servicesettings, appearancesettings, pvrsettings, tvsettings, scripts, videofiles, videolibrary, videoplaylist, loginscreen, profiles, skinsettings, addonbrowser, yesnodialog, progressdialog, virtualkeyboard, volumebar, submenu, favourites, contextmenu, infodialog, numericinput, gamepadinput, shutdownmenu, mutebug, playercontrols, seekbar, musicosd, addonsettings, visualisationsettings, visualisationpresetlist, osdvideosettings, osdaudiosettings, videobookmarks, filebrowser, networksetup, mediasource, profilesettings, locksettings, contentsettings, songinformation, smartplaylisteditor, smartplaylistrule, busydialog, pictureinfo, accesspoints, fullscreeninfo, karaokeselector, karaokelargeselector, sliderdialog, addoninformation, musicplaylist, musicfiles, musiclibrary, musicplaylisteditor, teletext, selectdialog, musicinformation, okdialog, movieinformation, textviewer, fullscreenvideo, fullscreenlivetv, visualisation, slideshow, filestackingdialog, karaoke, weather, screensaver, videoosd, videomenu, videotimeseek, musicoverlay, videooverlay, startwindow, startup, peripherals, peripheralsettings, extendedprogressdialog, mediafilter }
    public enum ImageEnum { Null, info, warning, error }
    public enum ExecActionEnum { left, right, up, down, pageup, pagedown, select, highlight, parentdir, parentfolder, back, previousmenu, info, pause, stop, skipnext, skipprevious, fullscreen, aspectratio, stepforward, stepback, bigstepforward, bigstepback, osd, showsubtitles, nextsubtitle, codecinfo, nextpicture, previouspicture, zoomout, zoomin, playlist, queue, zoomnormal, zoomlevel1, zoomlevel2, zoomlevel3, zoomlevel4, zoomlevel5, zoomlevel6, zoomlevel7, zoomlevel8, zoomlevel9, nextcalibration, resetcalibration, analogmove, rotate, rotateccw, close, subtitledelayminus, subtitledelay, subtitledelayplus, audiodelayminus, audiodelay, audiodelayplus, subtitleshiftup, subtitleshiftdown, subtitlealign, audionextlanguage, verticalshiftup, verticalshiftdown, nextresolution, audiotoggledigital, number0, number1, number2, number3, number4, number5, number6, number7, number8, number9, osdleft, osdright, osdup, osddown, osdselect, osdvalueplus, osdvalueminus, smallstepback, fastforward, rewind, play, playpause, delete, copy, move, mplayerosd, hidesubmenu, screenshot, rename, togglewatched, scanitem, reloadkeymaps, volumeup, volumedown, mute, backspace, scrollup, scrolldown, analogfastforward, analogrewind, moveitemup, moveitemdown, contextmenu, shift, symbols, cursorleft, cursorright, showtime, analogseekforward, analogseekback, showpreset, presetlist, nextpreset, previouspreset, lockpreset, randompreset, increasevisrating, decreasevisrating, showvideomenu, enter, increaserating, decreaserating, togglefullscreen, nextscene, previousscene, nextletter, prevletter, jumpsms2, jumpsms3, jumpsms4, jumpsms5, jumpsms6, jumpsms7, jumpsms8, jumpsms9, filter, filterclear, filtersms2, filtersms3, filtersms4, filtersms5, filtersms6, filtersms7, filtersms8, filtersms9, firstpage, lastpage, guiprofile, red, green, yellow, blue, increasepar, decreasepar, volampup, volampdown, channelup, channeldown, previouschannelgroup, nextchannelgroup, leftclick, rightclick, middleclick, doubleclick, wheelup, wheeldown, mousedrag, mousemove, noop }

    //public enum RepeatEnum { Null, off, one, all }


    public enum SpeedNumbersEnum : int { minusthirtytwo = -32, minussixteen = -16, minuseight = -8, minusfour = -4, minustwo = -2, minusone = -1, zero = 0, one = 1, two = 2, four = 4, eight = 8, sixteen = 16, thirtytwo = 32 }

    public enum ZoomNumbersEnum : int { one = 1, two = 2, three = 3, four = 4, five = 5, six = 6, seven = 7, eight = 8, nine = 9, ten = 10 }
    public enum ChannelTypeEnum { tv, radio }
    public enum TypeEnum { movie, tvshow, musicvideo }
}