using KodiRemote.Code.Utils;
using System.Collections.Generic;

namespace KodiRemote.Code.JSON.Enums {
    //public enum ToggleEnum { Toggle, True, False }
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
        static public implicit operator bool? (ToggleEnum method) {
            if (method == ToggleEnum.True) {
                return true;
            } else if (method == ToggleEnum.False) {
                return false;
            }
            return null;
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
        protected static Dictionary<int, OptionalRepeatEnum> values = new Dictionary<int, OptionalRepeatEnum>();
        public static readonly OptionalRepeatEnum Null = new OptionalRepeatEnum(1, null);
        public static readonly OptionalRepeatEnum Off = new OptionalRepeatEnum(2, "off");
        public static readonly OptionalRepeatEnum One = new OptionalRepeatEnum(3, "one");
        public static readonly OptionalRepeatEnum All = new OptionalRepeatEnum(4, "all");

        private OptionalRepeatEnum(int value, string name) : base(value, name) {
            values[value] = this;
        }

        public static OptionalRepeatEnum FromInt(int value) {
            if (values.ContainsKey(value)) {
                return values[value];
            }
            return null;
        }
    }
    public class PartymodeEnum : StringEnum {
        public static readonly PartymodeEnum Music = new PartymodeEnum(1, "music");
        public static readonly PartymodeEnum Video = new PartymodeEnum(2, "video");

        private PartymodeEnum(int value, string name) : base(value, name) { }
    }
    public class ExecActionEnum : StringEnum {
        protected static Dictionary<int, ExecActionEnum> values = new Dictionary<int, ExecActionEnum>();
        public static readonly ExecActionEnum Left = new ExecActionEnum(1, "left");
        public static readonly ExecActionEnum Right = new ExecActionEnum(2, "right");
        public static readonly ExecActionEnum Up = new ExecActionEnum(3, "up");
        public static readonly ExecActionEnum Down = new ExecActionEnum(4, "down");
        public static readonly ExecActionEnum Pageup = new ExecActionEnum(5, "pageup");
        public static readonly ExecActionEnum Pagedown = new ExecActionEnum(6, "pagedown");
        public static readonly ExecActionEnum Select = new ExecActionEnum(7, "select");
        public static readonly ExecActionEnum Highlight = new ExecActionEnum(8, "highlight");
        public static readonly ExecActionEnum Parentdir = new ExecActionEnum(9, "parentdir");
        public static readonly ExecActionEnum Parentfolder = new ExecActionEnum(10, "parentfolder");
        public static readonly ExecActionEnum Back = new ExecActionEnum(11, "back");
        public static readonly ExecActionEnum Previousmenu = new ExecActionEnum(12, "previousmenu");
        public static readonly ExecActionEnum Info = new ExecActionEnum(13, "info");
        public static readonly ExecActionEnum Pause = new ExecActionEnum(14, "pause");
        public static readonly ExecActionEnum Stop = new ExecActionEnum(15, "stop");
        public static readonly ExecActionEnum SkipNext = new ExecActionEnum(16, "skipnext");
        public static readonly ExecActionEnum SkipPrevious = new ExecActionEnum(17, "skipprevious");
        public static readonly ExecActionEnum Fullscreen = new ExecActionEnum(18, "fullscreen");
        public static readonly ExecActionEnum Aspectratio = new ExecActionEnum(19, "aspectratio");
        public static readonly ExecActionEnum Stepforward = new ExecActionEnum(20, "stepforward");
        public static readonly ExecActionEnum Stepback = new ExecActionEnum(21, "stepback");
        public static readonly ExecActionEnum Bigstepforward = new ExecActionEnum(22, "bigstepforward");
        public static readonly ExecActionEnum Bigstepback = new ExecActionEnum(23, "bigstepback");
        public static readonly ExecActionEnum Osd = new ExecActionEnum(24, "osd");
        public static readonly ExecActionEnum Showsubtitles = new ExecActionEnum(25, "showsubtitles");
        public static readonly ExecActionEnum Nextsubtitle = new ExecActionEnum(26, "nextsubtitle");
        public static readonly ExecActionEnum Codecinfo = new ExecActionEnum(27, "codecinfo");
        public static readonly ExecActionEnum Nextpicture = new ExecActionEnum(28, "nextpicture");
        public static readonly ExecActionEnum Previouspicture = new ExecActionEnum(29, "previouspicture");
        public static readonly ExecActionEnum Zoomout = new ExecActionEnum(30, "zoomout");
        public static readonly ExecActionEnum Zoomin = new ExecActionEnum(31, "zoomin");
        public static readonly ExecActionEnum Playlist = new ExecActionEnum(32, "playlist");
        public static readonly ExecActionEnum Queue = new ExecActionEnum(33, "queue");
        public static readonly ExecActionEnum Zoomnormal = new ExecActionEnum(34, "zoomnormal");
        public static readonly ExecActionEnum Zoomlevel1 = new ExecActionEnum(35, "zoomlevel1");
        public static readonly ExecActionEnum Zoomlevel2 = new ExecActionEnum(36, "zoomlevel2");
        public static readonly ExecActionEnum Zoomlevel3 = new ExecActionEnum(37, "zoomlevel3");
        public static readonly ExecActionEnum Zoomlevel4 = new ExecActionEnum(38, "zoomlevel4");
        public static readonly ExecActionEnum Zoomlevel5 = new ExecActionEnum(39, "zoomlevel5");
        public static readonly ExecActionEnum Zoomlevel6 = new ExecActionEnum(40, "zoomlevel6");
        public static readonly ExecActionEnum Zoomlevel7 = new ExecActionEnum(41, "zoomlevel7");
        public static readonly ExecActionEnum Zoomlevel8 = new ExecActionEnum(42, "zoomlevel8");
        public static readonly ExecActionEnum Zoomlevel9 = new ExecActionEnum(43, "zoomlevel9");
        public static readonly ExecActionEnum Nextcalibration = new ExecActionEnum(44, "nextcalibration");
        public static readonly ExecActionEnum Resetcalibration = new ExecActionEnum(45, "resetcalibration");
        public static readonly ExecActionEnum Analogmove = new ExecActionEnum(46, "analogmove");
        public static readonly ExecActionEnum Rotate = new ExecActionEnum(47, "rotate");
        public static readonly ExecActionEnum Rotateccw = new ExecActionEnum(48, "rotateccw");
        public static readonly ExecActionEnum Close = new ExecActionEnum(49, "close");
        public static readonly ExecActionEnum Subtitledelayminus = new ExecActionEnum(50, "subtitledelayminus");
        public static readonly ExecActionEnum Subtitledelay = new ExecActionEnum(51, "subtitledelay");
        public static readonly ExecActionEnum Subtitledelayplus = new ExecActionEnum(52, "subtitledelayplus");
        public static readonly ExecActionEnum Audiodelayminus = new ExecActionEnum(53, "audiodelayminus");
        public static readonly ExecActionEnum Audiodelay = new ExecActionEnum(54, "audiodelay");
        public static readonly ExecActionEnum Audiodelayplus = new ExecActionEnum(55, "audiodelayplus");
        public static readonly ExecActionEnum Subtitleshiftup = new ExecActionEnum(56, "subtitleshiftup");
        public static readonly ExecActionEnum Subtitleshiftdown = new ExecActionEnum(57, "subtitleshiftdown");
        public static readonly ExecActionEnum Subtitlealign = new ExecActionEnum(58, "subtitlealign");
        public static readonly ExecActionEnum Audionextlanguage = new ExecActionEnum(59, "audionextlanguage");
        public static readonly ExecActionEnum Verticalshiftup = new ExecActionEnum(60, "verticalshiftup");
        public static readonly ExecActionEnum Verticalshiftdown = new ExecActionEnum(61, "verticalshiftdown");
        public static readonly ExecActionEnum Nextresolution = new ExecActionEnum(62, "nextresolution");
        public static readonly ExecActionEnum Audiotoggledigital = new ExecActionEnum(63, "audiotoggledigital");
        public static readonly ExecActionEnum Number0 = new ExecActionEnum(64, "number0");
        public static readonly ExecActionEnum Number1 = new ExecActionEnum(65, "number1");
        public static readonly ExecActionEnum Number2 = new ExecActionEnum(66, "number2");
        public static readonly ExecActionEnum Number3 = new ExecActionEnum(67, "number3");
        public static readonly ExecActionEnum Number4 = new ExecActionEnum(68, "number4");
        public static readonly ExecActionEnum Number5 = new ExecActionEnum(69, "number5");
        public static readonly ExecActionEnum Number6 = new ExecActionEnum(70, "number6");
        public static readonly ExecActionEnum Number7 = new ExecActionEnum(71, "number7");
        public static readonly ExecActionEnum Number8 = new ExecActionEnum(72, "number8");
        public static readonly ExecActionEnum Number9 = new ExecActionEnum(73, "number9");
        public static readonly ExecActionEnum Osdleft = new ExecActionEnum(74, "osdleft");
        public static readonly ExecActionEnum Osdright = new ExecActionEnum(75, "osdright");
        public static readonly ExecActionEnum Osdup = new ExecActionEnum(76, "osdup");
        public static readonly ExecActionEnum Osddown = new ExecActionEnum(77, "osddown");
        public static readonly ExecActionEnum Osdselect = new ExecActionEnum(78, "osdselect");
        public static readonly ExecActionEnum Osdvalueplus = new ExecActionEnum(79, "osdvalueplus");
        public static readonly ExecActionEnum Osdvalueminus = new ExecActionEnum(80, "osdvalueminus");
        public static readonly ExecActionEnum Smallstepback = new ExecActionEnum(81, "smallstepback");
        public static readonly ExecActionEnum FastForward = new ExecActionEnum(82, "fastforward");
        public static readonly ExecActionEnum Rewind = new ExecActionEnum(83, "rewind");
        public static readonly ExecActionEnum Play = new ExecActionEnum(84, "play");
        public static readonly ExecActionEnum PlayPause = new ExecActionEnum(85, "playpause");
        public static readonly ExecActionEnum Delete = new ExecActionEnum(86, "delete");
        public static readonly ExecActionEnum Copy = new ExecActionEnum(87, "copy");
        public static readonly ExecActionEnum Move = new ExecActionEnum(88, "move");
        public static readonly ExecActionEnum Mplayerosd = new ExecActionEnum(89, "mplayerosd");
        public static readonly ExecActionEnum Hidesubmenu = new ExecActionEnum(90, "hidesubmenu");
        public static readonly ExecActionEnum Screenshot = new ExecActionEnum(91, "screenshot");
        public static readonly ExecActionEnum Rename = new ExecActionEnum(92, "rename");
        public static readonly ExecActionEnum Togglewatched = new ExecActionEnum(93, "togglewatched");
        public static readonly ExecActionEnum Scanitem = new ExecActionEnum(94, "scanitem");
        public static readonly ExecActionEnum Reloadkeymaps = new ExecActionEnum(95, "reloadkeymaps");
        public static readonly ExecActionEnum VolumeUp = new ExecActionEnum(96, "volumeup");
        public static readonly ExecActionEnum VolumeDown = new ExecActionEnum(97, "volumedown");
        public static readonly ExecActionEnum Mute = new ExecActionEnum(98, "mute");
        public static readonly ExecActionEnum Backspace = new ExecActionEnum(99, "backspace");
        public static readonly ExecActionEnum Scrollup = new ExecActionEnum(100, "scrollup");
        public static readonly ExecActionEnum Scrolldown = new ExecActionEnum(101, "scrolldown");
        public static readonly ExecActionEnum Analogfastforward = new ExecActionEnum(102, "analogfastforward");
        public static readonly ExecActionEnum Analogrewind = new ExecActionEnum(103, "analogrewind");
        public static readonly ExecActionEnum Moveitemup = new ExecActionEnum(104, "moveitemup");
        public static readonly ExecActionEnum Moveitemdown = new ExecActionEnum(105, "moveitemdown");
        public static readonly ExecActionEnum Contextmenu = new ExecActionEnum(106, "contextmenu");
        public static readonly ExecActionEnum Shift = new ExecActionEnum(107, "shift");
        public static readonly ExecActionEnum Symbols = new ExecActionEnum(108, "symbols");
        public static readonly ExecActionEnum Cursorleft = new ExecActionEnum(109, "cursorleft");
        public static readonly ExecActionEnum Cursorright = new ExecActionEnum(110, "cursorright");
        public static readonly ExecActionEnum Showtime = new ExecActionEnum(111, "showtime");
        public static readonly ExecActionEnum Analogseekforward = new ExecActionEnum(112, "analogseekforward");
        public static readonly ExecActionEnum Analogseekback = new ExecActionEnum(113, "analogseekback");
        public static readonly ExecActionEnum Showpreset = new ExecActionEnum(114, "showpreset");
        public static readonly ExecActionEnum Presetlist = new ExecActionEnum(115, "presetlist");
        public static readonly ExecActionEnum Nextpreset = new ExecActionEnum(116, "nextpreset");
        public static readonly ExecActionEnum Previouspreset = new ExecActionEnum(117, "previouspreset");
        public static readonly ExecActionEnum Lockpreset = new ExecActionEnum(118, "lockpreset");
        public static readonly ExecActionEnum Randompreset = new ExecActionEnum(119, "randompreset");
        public static readonly ExecActionEnum Increasevisrating = new ExecActionEnum(120, "increasevisrating");
        public static readonly ExecActionEnum Decreasevisrating = new ExecActionEnum(121, "decreasevisrating");
        public static readonly ExecActionEnum Showvideomenu = new ExecActionEnum(122, "showvideomenu");
        public static readonly ExecActionEnum Enter = new ExecActionEnum(123, "enter");
        public static readonly ExecActionEnum Increaserating = new ExecActionEnum(124, "increaserating");
        public static readonly ExecActionEnum Decreaserating = new ExecActionEnum(125, "decreaserating");
        public static readonly ExecActionEnum Togglefullscreen = new ExecActionEnum(126, "togglefullscreen");
        public static readonly ExecActionEnum Nextscene = new ExecActionEnum(127, "nextscene");
        public static readonly ExecActionEnum Previousscene = new ExecActionEnum(128, "previousscene");
        public static readonly ExecActionEnum Nextletter = new ExecActionEnum(129, "nextletter");
        public static readonly ExecActionEnum Prevletter = new ExecActionEnum(130, "prevletter");
        public static readonly ExecActionEnum Jumpsms2 = new ExecActionEnum(131, "jumpsms2");
        public static readonly ExecActionEnum Jumpsms3 = new ExecActionEnum(132, "jumpsms3");
        public static readonly ExecActionEnum Jumpsms4 = new ExecActionEnum(133, "jumpsms4");
        public static readonly ExecActionEnum Jumpsms5 = new ExecActionEnum(134, "jumpsms5");
        public static readonly ExecActionEnum Jumpsms6 = new ExecActionEnum(135, "jumpsms6");
        public static readonly ExecActionEnum Jumpsms7 = new ExecActionEnum(136, "jumpsms7");
        public static readonly ExecActionEnum Jumpsms8 = new ExecActionEnum(137, "jumpsms8");
        public static readonly ExecActionEnum Jumpsms9 = new ExecActionEnum(138, "jumpsms9");
        public static readonly ExecActionEnum Filter = new ExecActionEnum(139, "filter");
        public static readonly ExecActionEnum Filterclear = new ExecActionEnum(140, "filterclear");
        public static readonly ExecActionEnum Filtersms2 = new ExecActionEnum(141, "filtersms2");
        public static readonly ExecActionEnum Filtersms3 = new ExecActionEnum(142, "filtersms3");
        public static readonly ExecActionEnum Filtersms4 = new ExecActionEnum(143, "filtersms4");
        public static readonly ExecActionEnum Filtersms5 = new ExecActionEnum(144, "filtersms5");
        public static readonly ExecActionEnum Filtersms6 = new ExecActionEnum(145, "filtersms6");
        public static readonly ExecActionEnum Filtersms7 = new ExecActionEnum(146, "filtersms7");
        public static readonly ExecActionEnum Filtersms8 = new ExecActionEnum(147, "filtersms8");
        public static readonly ExecActionEnum Filtersms9 = new ExecActionEnum(148, "filtersms9");
        public static readonly ExecActionEnum Firstpage = new ExecActionEnum(149, "firstpage");
        public static readonly ExecActionEnum Lastpage = new ExecActionEnum(150, "lastpage");
        public static readonly ExecActionEnum Guiprofile = new ExecActionEnum(151, "guiprofile");
        public static readonly ExecActionEnum Red = new ExecActionEnum(152, "red");
        public static readonly ExecActionEnum Green = new ExecActionEnum(153, "green");
        public static readonly ExecActionEnum Yellow = new ExecActionEnum(154, "yellow");
        public static readonly ExecActionEnum Blue = new ExecActionEnum(155, "blue");
        public static readonly ExecActionEnum Increasepar = new ExecActionEnum(156, "increasepar");
        public static readonly ExecActionEnum Decreasepar = new ExecActionEnum(157, "decreasepar");
        public static readonly ExecActionEnum Volampup = new ExecActionEnum(158, "volampup");
        public static readonly ExecActionEnum Volampdown = new ExecActionEnum(159, "volampdown");
        public static readonly ExecActionEnum Channelup = new ExecActionEnum(160, "channelup");
        public static readonly ExecActionEnum Channeldown = new ExecActionEnum(161, "channeldown");
        public static readonly ExecActionEnum Previouschannelgroup = new ExecActionEnum(162, "previouschannelgroup");
        public static readonly ExecActionEnum Nextchannelgroup = new ExecActionEnum(163, "nextchannelgroup");
        public static readonly ExecActionEnum Leftclick = new ExecActionEnum(164, "leftclick");
        public static readonly ExecActionEnum Rightclick = new ExecActionEnum(165, "rightclick");
        public static readonly ExecActionEnum Middleclick = new ExecActionEnum(166, "middleclick");
        public static readonly ExecActionEnum Doubleclick = new ExecActionEnum(167, "doubleclick");
        public static readonly ExecActionEnum Wheelup = new ExecActionEnum(168, "wheelup");
        public static readonly ExecActionEnum Wheeldown = new ExecActionEnum(169, "wheeldown");
        public static readonly ExecActionEnum Mousedrag = new ExecActionEnum(170, "mousedrag");
        public static readonly ExecActionEnum Mousemove = new ExecActionEnum(171, "mousemove");
        public static readonly ExecActionEnum Noop = new ExecActionEnum(172, "noop");

        private ExecActionEnum(int value, string name) : base(value, name) {
            values[value] = this;
        }

        public static ExecActionEnum FromInt(int value) {
            if (values.ContainsKey(value)) {
                return values[value];
            }
            return null;
        }
    }
    public class WindowEnum : StringEnum {
        protected static Dictionary<int, WindowEnum> values = new Dictionary<int, WindowEnum>();
        public static readonly WindowEnum Home = new WindowEnum(1, "home");
        public static readonly WindowEnum Programs = new WindowEnum(2, "programs");
        public static readonly WindowEnum Pictures = new WindowEnum(3, "pictures");
        public static readonly WindowEnum Filemanager = new WindowEnum(4, "filemanager");
        public static readonly WindowEnum Files = new WindowEnum(5, "files");
        public static readonly WindowEnum Settings = new WindowEnum(6, "settings");
        public static readonly WindowEnum Music = new WindowEnum(7, "music");
        public static readonly WindowEnum Video = new WindowEnum(8, "video");
        public static readonly WindowEnum Videos = new WindowEnum(9, "videos");
        public static readonly WindowEnum Tv = new WindowEnum(10, "tv");
        public static readonly WindowEnum Pvr = new WindowEnum(11, "pvr");
        public static readonly WindowEnum Pvrguideinfo = new WindowEnum(12, "pvrguideinfo");
        public static readonly WindowEnum Pvrrecordinginfo = new WindowEnum(13, "pvrrecordinginfo");
        public static readonly WindowEnum Pvrtimersetting = new WindowEnum(14, "pvrtimersetting");
        public static readonly WindowEnum Pvrgroupmanager = new WindowEnum(15, "pvrgroupmanager");
        public static readonly WindowEnum Pvrchannelmanager = new WindowEnum(16, "pvrchannelmanager");
        public static readonly WindowEnum Pvrguidesearch = new WindowEnum(17, "pvrguidesearch");
        public static readonly WindowEnum Pvrchannelscan = new WindowEnum(18, "pvrchannelscan");
        public static readonly WindowEnum Pvrupdateprogress = new WindowEnum(19, "pvrupdateprogress");
        public static readonly WindowEnum Pvrosdchannels = new WindowEnum(20, "pvrosdchannels");
        public static readonly WindowEnum Pvrosdguide = new WindowEnum(21, "pvrosdguide");
        public static readonly WindowEnum Pvrosddirector = new WindowEnum(22, "pvrosddirector");
        public static readonly WindowEnum Pvrosdcutter = new WindowEnum(23, "pvrosdcutter");
        public static readonly WindowEnum Pvrosdteletext = new WindowEnum(24, "pvrosdteletext");
        public static readonly WindowEnum Systeminfo = new WindowEnum(25, "systeminfo");
        public static readonly WindowEnum Testpattern = new WindowEnum(26, "testpattern");
        public static readonly WindowEnum Screencalibration = new WindowEnum(27, "screencalibration");
        public static readonly WindowEnum Guicalibration = new WindowEnum(28, "guicalibration");
        public static readonly WindowEnum Picturessettings = new WindowEnum(29, "picturessettings");
        public static readonly WindowEnum Programssettings = new WindowEnum(30, "programssettings");
        public static readonly WindowEnum Weathersettings = new WindowEnum(31, "weathersettings");
        public static readonly WindowEnum Musicsettings = new WindowEnum(32, "musicsettings");
        public static readonly WindowEnum Systemsettings = new WindowEnum(33, "systemsettings");
        public static readonly WindowEnum Videossettings = new WindowEnum(34, "videossettings");
        public static readonly WindowEnum Networksettings = new WindowEnum(35, "networksettings");
        public static readonly WindowEnum Servicesettings = new WindowEnum(36, "servicesettings");
        public static readonly WindowEnum Appearancesettings = new WindowEnum(37, "appearancesettings");
        public static readonly WindowEnum Pvrsettings = new WindowEnum(38, "pvrsettings");
        public static readonly WindowEnum Tvsettings = new WindowEnum(39, "tvsettings");
        public static readonly WindowEnum Scripts = new WindowEnum(40, "scripts");
        public static readonly WindowEnum Videofiles = new WindowEnum(41, "videofiles");
        public static readonly WindowEnum Videolibrary = new WindowEnum(42, "videolibrary");
        public static readonly WindowEnum Videoplaylist = new WindowEnum(43, "videoplaylist");
        public static readonly WindowEnum Loginscreen = new WindowEnum(44, "loginscreen");
        public static readonly WindowEnum Profiles = new WindowEnum(45, "profiles");
        public static readonly WindowEnum Skinsettings = new WindowEnum(46, "skinsettings");
        public static readonly WindowEnum Addonbrowser = new WindowEnum(47, "addonbrowser");
        public static readonly WindowEnum Yesnodialog = new WindowEnum(48, "yesnodialog");
        public static readonly WindowEnum Progressdialog = new WindowEnum(49, "progressdialog");
        public static readonly WindowEnum Virtualkeyboard = new WindowEnum(50, "virtualkeyboard");
        public static readonly WindowEnum Volumebar = new WindowEnum(51, "volumebar");
        public static readonly WindowEnum Submenu = new WindowEnum(52, "submenu");
        public static readonly WindowEnum Favourites = new WindowEnum(53, "favourites");
        public static readonly WindowEnum Contextmenu = new WindowEnum(54, "contextmenu");
        public static readonly WindowEnum Infodialog = new WindowEnum(55, "infodialog");
        public static readonly WindowEnum Numericinput = new WindowEnum(56, "numericinput");
        public static readonly WindowEnum Gamepadinput = new WindowEnum(57, "gamepadinput");
        public static readonly WindowEnum Shutdownmenu = new WindowEnum(58, "shutdownmenu");
        public static readonly WindowEnum Mutebug = new WindowEnum(59, "mutebug");
        public static readonly WindowEnum Playercontrols = new WindowEnum(60, "playercontrols");
        public static readonly WindowEnum Seekbar = new WindowEnum(61, "seekbar");
        public static readonly WindowEnum Musicosd = new WindowEnum(62, "musicosd");
        public static readonly WindowEnum Addonsettings = new WindowEnum(63, "addonsettings");
        public static readonly WindowEnum Visualisationsettings = new WindowEnum(64, "visualisationsettings");
        public static readonly WindowEnum Visualisationpresetlist = new WindowEnum(65, "visualisationpresetlist");
        public static readonly WindowEnum Osdvideosettings = new WindowEnum(66, "osdvideosettings");
        public static readonly WindowEnum Osdaudiosettings = new WindowEnum(67, "osdaudiosettings");
        public static readonly WindowEnum Videobookmarks = new WindowEnum(68, "videobookmarks");
        public static readonly WindowEnum Filebrowser = new WindowEnum(69, "filebrowser");
        public static readonly WindowEnum Networksetup = new WindowEnum(70, "networksetup");
        public static readonly WindowEnum Mediasource = new WindowEnum(71, "mediasource");
        public static readonly WindowEnum Profilesettings = new WindowEnum(72, "profilesettings");
        public static readonly WindowEnum Locksettings = new WindowEnum(73, "locksettings");
        public static readonly WindowEnum Contentsettings = new WindowEnum(74, "contentsettings");
        public static readonly WindowEnum Songinformation = new WindowEnum(75, "songinformation");
        public static readonly WindowEnum Smartplaylisteditor = new WindowEnum(76, "smartplaylisteditor");
        public static readonly WindowEnum Smartplaylistrule = new WindowEnum(77, "smartplaylistrule");
        public static readonly WindowEnum Busydialog = new WindowEnum(78, "busydialog");
        public static readonly WindowEnum Pictureinfo = new WindowEnum(79, "pictureinfo");
        public static readonly WindowEnum Accesspoints = new WindowEnum(80, "accesspoints");
        public static readonly WindowEnum Fullscreeninfo = new WindowEnum(81, "fullscreeninfo");
        public static readonly WindowEnum Karaokeselector = new WindowEnum(82, "karaokeselector");
        public static readonly WindowEnum Karaokelargeselector = new WindowEnum(83, "karaokelargeselector");
        public static readonly WindowEnum Sliderdialog = new WindowEnum(84, "sliderdialog");
        public static readonly WindowEnum Addoninformation = new WindowEnum(85, "addoninformation");
        public static readonly WindowEnum Musicplaylist = new WindowEnum(86, "musicplaylist");
        public static readonly WindowEnum Musicfiles = new WindowEnum(87, "musicfiles");
        public static readonly WindowEnum Musiclibrary = new WindowEnum(88, "musiclibrary");
        public static readonly WindowEnum Musicplaylisteditor = new WindowEnum(89, "musicplaylisteditor");
        public static readonly WindowEnum Teletext = new WindowEnum(90, "teletext");
        public static readonly WindowEnum Selectdialog = new WindowEnum(91, "selectdialog");
        public static readonly WindowEnum Musicinformation = new WindowEnum(92, "musicinformation");
        public static readonly WindowEnum Okdialog = new WindowEnum(93, "okdialog");
        public static readonly WindowEnum Movieinformation = new WindowEnum(94, "movieinformation");
        public static readonly WindowEnum Textviewer = new WindowEnum(95, "textviewer");
        public static readonly WindowEnum Fullscreenvideo = new WindowEnum(96, "fullscreenvideo");
        public static readonly WindowEnum Fullscreenlivetv = new WindowEnum(97, "fullscreenlivetv");
        public static readonly WindowEnum Visualisation = new WindowEnum(98, "visualisation");
        public static readonly WindowEnum Slideshow = new WindowEnum(99, "slideshow");
        public static readonly WindowEnum Filestackingdialog = new WindowEnum(100, "filestackingdialog");
        public static readonly WindowEnum Karaoke = new WindowEnum(101, "karaoke");
        public static readonly WindowEnum Weather = new WindowEnum(102, "weather");
        public static readonly WindowEnum Screensaver = new WindowEnum(103, "screensaver");
        public static readonly WindowEnum Videoosd = new WindowEnum(104, "videoosd");
        public static readonly WindowEnum Videomenu = new WindowEnum(105, "videomenu");
        public static readonly WindowEnum Videotimeseek = new WindowEnum(106, "videotimeseek");
        public static readonly WindowEnum Musicoverlay = new WindowEnum(107, "musicoverlay");
        public static readonly WindowEnum Videooverlay = new WindowEnum(108, "videooverlay");
        public static readonly WindowEnum Startwindow = new WindowEnum(109, "startwindow");
        public static readonly WindowEnum Startup = new WindowEnum(110, "startup");
        public static readonly WindowEnum Peripherals = new WindowEnum(111, "peripherals");
        public static readonly WindowEnum Peripheralsettings = new WindowEnum(112, "peripheralsettings");
        public static readonly WindowEnum Extendedprogressdialog = new WindowEnum(113, "extendedprogressdialog");
        public static readonly WindowEnum Mediafilter = new WindowEnum(114, "mediafilter");

        private WindowEnum(int value, string name) : base(value, name) {
            values[value] = this;
        }

        public static WindowEnum FromInt(int value) {
            if (values.ContainsKey(value)) {
                return values[value];
            }
            return null;
        }
    }
    public class ImageEnum : StringEnum {
        protected static Dictionary<int, ImageEnum> values = new Dictionary<int, ImageEnum>();
        public static readonly ImageEnum Null = new ImageEnum(1, null);
        public static readonly ImageEnum Info = new ImageEnum(2, "info");
        public static readonly ImageEnum Warning = new ImageEnum(3, "warning");
        public static readonly ImageEnum Error = new ImageEnum(4, "error");

        private ImageEnum(int value, string name) : base(value, name) {
            values[value] = this;
        }
        public static ImageEnum FromInt(int value) {
            if (values.ContainsKey(value)) {
                return values[value];
            }
            return null;
        }
    }
    public class ContentEnum : StringEnum {

        public static readonly ContentEnum Null = new ContentEnum(1, null);
        public static readonly ContentEnum Unknown = new ContentEnum(2, "unknown");
        public static readonly ContentEnum Video = new ContentEnum(3, "video");
        public static readonly ContentEnum Audio = new ContentEnum(4, "audio");
        public static readonly ContentEnum Image = new ContentEnum(5, "image");
        public static readonly ContentEnum Executable = new ContentEnum(6, "executable");

        private ContentEnum(int value, string name) : base(value, name) {
            values[value] = this;
        }

        protected static Dictionary<int, ContentEnum> values = new Dictionary<int, ContentEnum>();

        public static ContentEnum FromInt(int value) {
            if (values.ContainsKey(value)) {
                return values[value];
            }
            return null;
        }
    }
    public class EnabledEnum : StringEnum {
        protected static Dictionary<int, EnabledEnum> values = new Dictionary<int, EnabledEnum>();
        public static readonly EnabledEnum All = new EnabledEnum(1, null);
        public static readonly EnabledEnum True = new EnabledEnum(2, "true");
        public static readonly EnabledEnum False = new EnabledEnum(3, "false");

        private EnabledEnum(int value, string name) : base(value, name) {
            values[value] = this;
        }

        static public implicit operator bool? (EnabledEnum method) {
            if (method == EnabledEnum.True) {
                return true;
            } else if (method == EnabledEnum.False) {
                return false;
            }
            return null;
        }

        public static EnabledEnum FromInt(int value) {
            if (values.ContainsKey(value)) {
                return values[value];
            }
            return null;
        }
    }
    public class MediaEnum : StringEnum {
        protected static Dictionary<int, MediaEnum> values = new Dictionary<int, MediaEnum>();
        public static readonly MediaEnum Null = new MediaEnum(1, null);
        public static readonly MediaEnum Video = new MediaEnum(2, "video");
        public static readonly MediaEnum Music = new MediaEnum(3, "music");
        public static readonly MediaEnum Pictures = new MediaEnum(4, "pictures");
        public static readonly MediaEnum Files = new MediaEnum(5, "files");
        public static readonly MediaEnum Programs = new MediaEnum(6, "programs");

        private MediaEnum(int value, string name) : base(value, name) {
            values[value] = this;
        }
        public static MediaEnum FromInt(int value) {
            if (values.ContainsKey(value)) {
                return values[value];
            }
            return null;
        }
    }
    public class MediaNotNullEnum : StringEnum {
        protected static Dictionary<int, MediaNotNullEnum> values = new Dictionary<int, MediaNotNullEnum>();
        public static readonly MediaNotNullEnum Video = new MediaNotNullEnum(2, "video");
        public static readonly MediaNotNullEnum Music = new MediaNotNullEnum(3, "music");
        public static readonly MediaNotNullEnum Pictures = new MediaNotNullEnum(4, "pictures");
        public static readonly MediaNotNullEnum Files = new MediaNotNullEnum(5, "files");
        public static readonly MediaNotNullEnum Programs = new MediaNotNullEnum(6, "programs");

        private MediaNotNullEnum(int value, string name) : base(value, name) {
            values[value] = this;
        }
        public static MediaNotNullEnum FromInt(int value) {
            if (values.ContainsKey(value)) {
                return values[value];
            }
            return null;
        }
    }
    public class ChannelTypeEnum : StringEnum {
        public static readonly ChannelTypeEnum TV = new ChannelTypeEnum(1, "tv");
        public static readonly ChannelTypeEnum Radio = new ChannelTypeEnum(2, "radio");

        private ChannelTypeEnum(int value, string name) : base(value, name) { }
    }
    public class OrderEnum : StringEnum {
        public static readonly OrderEnum ascending = new OrderEnum(1, "ascending");
        public static readonly OrderEnum descending = new OrderEnum(2, "descending");

        private OrderEnum(int value, string name) : base(value, name) { }
    }
    public class MethodEnum : StringEnum {
        public static readonly MethodEnum None = new MethodEnum(1, "none");
        public static readonly MethodEnum Label = new MethodEnum(2, "label");
        public static readonly MethodEnum Date = new MethodEnum(3, "date");
        public static readonly MethodEnum Size = new MethodEnum(4, "size");
        public static readonly MethodEnum File = new MethodEnum(5, "file");
        public static readonly MethodEnum Path = new MethodEnum(6, "path");
        public static readonly MethodEnum Drivetype = new MethodEnum(7, "drivetype");
        public static readonly MethodEnum Title = new MethodEnum(8, "title");
        public static readonly MethodEnum Track = new MethodEnum(9, "track");
        public static readonly MethodEnum Time = new MethodEnum(10, "time");
        public static readonly MethodEnum Artist = new MethodEnum(11, "artist");
        public static readonly MethodEnum Album = new MethodEnum(12, "album");
        public static readonly MethodEnum Albumtype = new MethodEnum(13, "albumtype");
        public static readonly MethodEnum Genre = new MethodEnum(14, "genre");
        public static readonly MethodEnum Country = new MethodEnum(15, "country");
        public static readonly MethodEnum Year = new MethodEnum(16, "year");
        public static readonly MethodEnum Rating = new MethodEnum(17, "rating");
        public static readonly MethodEnum Votes = new MethodEnum(18, "votes");
        public static readonly MethodEnum Top250 = new MethodEnum(19, "top250");
        public static readonly MethodEnum Programcount = new MethodEnum(20, "programcount");
        public static readonly MethodEnum Playlist = new MethodEnum(21, "playlist");
        public static readonly MethodEnum Episode = new MethodEnum(22, "episode");
        public static readonly MethodEnum Season = new MethodEnum(23, "season");
        public static readonly MethodEnum Totalepisodes = new MethodEnum(24, "totalepisodes");
        public static readonly MethodEnum Watchedepisodes = new MethodEnum(25, "watchedepisodes");
        public static readonly MethodEnum Tvshowstatus = new MethodEnum(26, "tvshowstatus");
        public static readonly MethodEnum Tvshowtitle = new MethodEnum(27, "tvshowtitle");
        public static readonly MethodEnum Sorttitle = new MethodEnum(28, "sorttitle");
        public static readonly MethodEnum Productioncode = new MethodEnum(29, "productioncode");
        public static readonly MethodEnum Mpaa = new MethodEnum(30, "mpaa");
        public static readonly MethodEnum Studio = new MethodEnum(31, "studio");
        public static readonly MethodEnum Dateadded = new MethodEnum(32, "dateadded");
        public static readonly MethodEnum Lastplayed = new MethodEnum(33, "lastplayed");
        public static readonly MethodEnum Playcount = new MethodEnum(34, "playcount");
        public static readonly MethodEnum Listeners = new MethodEnum(35, "listeners");
        public static readonly MethodEnum Bitrate = new MethodEnum(36, "bitrate");
        public static readonly MethodEnum Random = new MethodEnum(37, "random");

        private MethodEnum(int value, string name) : base(value, name) { }
    }
    public enum SpeedNumbersEnum : int { minusthirtytwo = -32, minussixteen = -16, minuseight = -8, minusfour = -4, minustwo = -2, minusone = -1, zero = 0, one = 1, two = 2, four = 4, eight = 8, sixteen = 16, thirtytwo = 32 }
    public enum ZoomNumbersEnum : int { one = 1, two = 2, three = 3, four = 4, five = 5, six = 6, seven = 7, eight = 8, nine = 9, ten = 10 }
    public class TypeEnum : StringEnum {
        public static readonly TypeEnum Movie = new TypeEnum(1, "movie");
        public static readonly TypeEnum TVShow = new TypeEnum(2, "tvshow");
        public static readonly TypeEnum MusicVideo = new TypeEnum(3, "musicvideo");

        private TypeEnum(int value, string name) : base(value, name) { }
    }
}