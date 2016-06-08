using KodiRemote.Code.Common;
using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.ViewModel {
    public class RemoteControlViewModel : ViewModelBase {
        public RemoteControlViewModel() {
            Title = "Remote Control";
        }

        private RelayCommand volumeUpCommand;
        public RelayCommand VolumeUpCommand {
            get {
                if (volumeUpCommand == null) {
                    volumeUpCommand = new RelayCommand(async () => {
                        await Kodi.Application.SetVolume(IncDecEnum.Increment);
                        //Kodi.Input.ExecuteAction(ExecActionEnum.VolumeUp);
                    });
                }
                return volumeUpCommand;
            }
        }

        private RelayCommand volumeDownCommand;
        public RelayCommand VolumeDownCommand {
            get {
                if (volumeDownCommand == null) {
                    volumeDownCommand = new RelayCommand(async () => {
                        await Kodi.Application.SetVolume(IncDecEnum.Decrement);
                        //Kodi.Input.ExecuteAction(ExecActionEnum.VolumeDown);
                    });
                }
                return volumeDownCommand;
            }
        }

        private RelayCommand volumeMuteCommand;
        public RelayCommand VolumeMuteCommand {
            get {
                if (volumeMuteCommand == null) {
                    volumeMuteCommand = new RelayCommand(async () => {
                        await Kodi.Application.SetMute(ToggleEnum.Toggle);
                    });
                }
                return volumeMuteCommand;
            }
        }

        private RelayCommand homeCommand;
        public RelayCommand HomeCommand {
            get {
                if (homeCommand == null) {
                    homeCommand = new RelayCommand(async () => {
                        await Kodi.GUI.ActivateWindow(WindowEnum.Home);
                    });
                }
                return homeCommand;
            }
        }

        private RelayCommand upCommand;
        public RelayCommand UpCommand {
            get {
                if (upCommand == null) {
                    upCommand = new RelayCommand(async () => {
                        await Kodi.Input.ExecuteAction(ExecActionEnum.Up);
                    });
                }
                return upCommand;
            }
        }

        private RelayCommand optionsCommand;
        public RelayCommand OptionsCommand {
            get {
                if (optionsCommand == null) {
                    optionsCommand = new RelayCommand(async () => {
                        await Kodi.Input.ExecuteAction(ExecActionEnum.Contextmenu);
                    });
                }
                return optionsCommand;
            }
        }

        private RelayCommand leftCommand;
        public RelayCommand LeftCommand {
            get {
                if (leftCommand == null) {
                    leftCommand = new RelayCommand(async () => {
                        await Kodi.Input.ExecuteAction(ExecActionEnum.Left);
                    });
                }
                return leftCommand;
            }
        }

        private RelayCommand goCommand;
        public RelayCommand GoCommand {
            get {
                if (goCommand == null) {
                    goCommand = new RelayCommand(async () => {
                        await Kodi.Input.ExecuteAction(ExecActionEnum.Select);
                    });
                }
                return goCommand;
            }
        }

        private RelayCommand rightCommand;
        public RelayCommand RightCommand {
            get {
                if (rightCommand == null) {
                    rightCommand = new RelayCommand(async () => {
                        await Kodi.Input.ExecuteAction(ExecActionEnum.Right);
                    });
                }
                return rightCommand;
            }
        }

        private RelayCommand backCommand;
        public RelayCommand BackCommand {
            get {
                if (backCommand == null) {
                    backCommand = new RelayCommand(async () => {
                        await Kodi.Input.ExecuteAction(ExecActionEnum.Back);
                    });
                }
                return backCommand;
            }
        }

        private RelayCommand downCommand;
        public RelayCommand DownCommand {
            get {
                if (downCommand == null) {
                    downCommand = new RelayCommand(async () => {
                        await Kodi.Input.ExecuteAction(ExecActionEnum.Down);
                    });
                }
                return downCommand;
            }
        }

        private RelayCommand keyboardCommand;
        public RelayCommand KeyboardCommand {
            get {
                if (keyboardCommand == null) {
                    keyboardCommand = new RelayCommand(() => {
                        //Keyboard anzeigen
                    });
                }
                return keyboardCommand;
            }
        }

        private RelayCommand turnOffCommand;
        public RelayCommand TurnOffCommand {
            get {
                if (turnOffCommand == null) {
                    turnOffCommand = new RelayCommand(async () => {
                        await Kodi.GUI.ActivateWindow(WindowEnum.Shutdownmenu);
                    });
                }
                return turnOffCommand;
            }
        }

        private RelayCommand movieCommand;
        public RelayCommand MovieCommand {
            get {
                if (movieCommand == null) {
                    movieCommand = new RelayCommand(async () => {
                        await Kodi.GUI.ActivateWindow(WindowEnum.Video, new List<string>() { "movietitles" });
                    });
                }
                return movieCommand;
            }
        }

        private RelayCommand seriesCommand;
        public RelayCommand SeriesCommand {
            get {
                if (seriesCommand == null) {
                    seriesCommand = new RelayCommand(async () => {
                        await Kodi.GUI.ActivateWindow(WindowEnum.Video, new List<string>() { "tvshowtitles" });
                    });
                }
                return seriesCommand;
            }
        }

        private RelayCommand musicCommand;
        public RelayCommand MusicCommand {
            get {
                if (musicCommand == null) {
                    musicCommand = new RelayCommand(async () => {
                        await Kodi.GUI.ActivateWindow(WindowEnum.Musiclibrary);
                    });
                }
                return musicCommand;
            }
        }

        private RelayCommand previousCommand;
        public RelayCommand PreviousCommand {
            get {
                if (previousCommand == null) {
                    previousCommand = new RelayCommand(async () => {
                        await Kodi.Input.ExecuteAction(ExecActionEnum.SkipPrevious);
                    });
                }
                return previousCommand;
            }
        }

        private RelayCommand nextCommand;
        public RelayCommand NextCommand {
            get {
                if (nextCommand == null) {
                    nextCommand = new RelayCommand(async () => {
                        await Kodi.Input.ExecuteAction(ExecActionEnum.SkipNext);
                    });
                }
                return nextCommand;
            }
        }

        private RelayCommand stopCommand;
        public RelayCommand StopCommand {
            get {
                if (stopCommand == null) {
                    stopCommand = new RelayCommand(async () => {
                        await Kodi.Input.ExecuteAction(ExecActionEnum.Stop);
                    });
                }
                return stopCommand;
            }
        }

        private RelayCommand fastBackwardCommand;
        public RelayCommand FastBackwardCommand {
            get {
                if (fastBackwardCommand == null) {
                    fastBackwardCommand = new RelayCommand(async () => {
                        await Kodi.Input.ExecuteAction(ExecActionEnum.Rewind);
                    });
                }
                return fastBackwardCommand;
            }
        }

        private RelayCommand fastForwardCommand;
        public RelayCommand FastForwardCommand {
            get {
                if (fastForwardCommand == null) {
                    fastForwardCommand = new RelayCommand(async () => {
                        await Kodi.Input.ExecuteAction(ExecActionEnum.FastForward);
                    });
                }
                return fastForwardCommand;
            }
        }
        private RelayCommand playPauseCommand;
        public RelayCommand PlayPauseCommand {
            get {
                if (playPauseCommand == null) {
                    playPauseCommand = new RelayCommand(async () => {
                        await Kodi.Input.ExecuteAction(ExecActionEnum.PlayPause);
                    });
                }
                return playPauseCommand;
            }
        }
    }
}
