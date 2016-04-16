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
        public new Kodi Kodi {
            get {
                return ViewModelBase.Kodi;
            }
        }
        public RemoteControlViewModel() {
            ViewModelBase.KodiChanged += ViewModelBase_KodiChanged;
        }

        private void ViewModelBase_KodiChanged(object sender, EventArgs e) {
            RaisePropertyChanged(nameof(Kodi));
        }

        private RelayCommand volumeUpCommand;
        public RelayCommand VolumeUpCommand {
            get {
                if (volumeUpCommand == null) {
                    volumeUpCommand = new RelayCommand(() => {
                    });
                }
                return volumeUpCommand;
            }
        }

        private RelayCommand volumeDownCommand;
        public RelayCommand VolumeDownCommand {
            get {
                if (volumeDownCommand == null) {
                    volumeDownCommand = new RelayCommand(() => {
                    });
                }
                return volumeDownCommand;
            }
        }

        private RelayCommand volumeMuteCommand;
        public RelayCommand VolumeMuteCommand {
            get {
                if (volumeMuteCommand == null) {
                    volumeMuteCommand = new RelayCommand(() => {

                    });
                }
                return volumeMuteCommand;
            }
        }

        private RelayCommand homeCommand;
        public RelayCommand HomeCommand {
            get {
                if (homeCommand == null) {
                    homeCommand = new RelayCommand(() => {
                        //GoToWindow(WindowsEnum.home);
                    });
                }
                return homeCommand;
            }
        }

        private RelayCommand upCommand;
        public RelayCommand UpCommand {
            get {
                if (upCommand == null) {
                    upCommand = new RelayCommand(() => {
                        //InputMethod(ExecActionEnum.up);
                    });
                }
                return upCommand;
            }
        }

        private RelayCommand optionsCommand;
        public RelayCommand OptionsCommand {
            get {
                if (optionsCommand == null) {
                    optionsCommand = new RelayCommand(() => {
                        //InputMethod(ExecActionEnum.contextmenu);
                    });
                }
                return optionsCommand;
            }
        }

        private RelayCommand leftCommand;
        public RelayCommand LeftCommand {
            get {
                if (leftCommand == null) {
                    leftCommand = new RelayCommand(() => {
                        //InputMethod(ExecActionEnum.left);
                    });
                }
                return leftCommand;
            }
        }

        private RelayCommand goCommand;
        public RelayCommand GoCommand {
            get {
                if (goCommand == null) {
                    goCommand = new RelayCommand(() => {
                        //InputMethod(ExecActionEnum.select);
                    });
                }
                return goCommand;
            }
        }

        private RelayCommand rightCommand;
        public RelayCommand RightCommand {
            get {
                if (rightCommand == null) {
                    rightCommand = new RelayCommand(() => {
                        //InputMethod(ExecActionEnum.right);
                    });
                }
                return rightCommand;
            }
        }

        private RelayCommand backCommand;
        public RelayCommand BackCommand {
            get {
                if (backCommand == null) {
                    backCommand = new RelayCommand(() => {
                        //InputMethod(ExecActionEnum.back);
                    });
                }
                return backCommand;
            }
        }

        private RelayCommand downCommand;
        public RelayCommand DownCommand {
            get {
                if (downCommand == null) {
                    downCommand = new RelayCommand(() => {
                        //InputMethod(ExecActionEnum.down);
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
                    turnOffCommand = new RelayCommand(() => {
                        //GoToWindow(WindowsEnum.shutdownmenu);
                    });
                }
                return turnOffCommand;
            }
        }

        private RelayCommand movieCommand;
        public RelayCommand MovieCommand {
            get {
                if (movieCommand == null) {
                    movieCommand = new RelayCommand(() => {
                        //GoToWindow(WindowsEnum.video, new String[1] { "movietitles" });
                    });
                }
                return movieCommand;
            }
        }

        private RelayCommand seriesCommand;
        public RelayCommand SeriesCommand {
            get {
                if (seriesCommand == null) {
                    seriesCommand = new RelayCommand(() => {
                        //GoToWindow(WindowsEnum.video, new String[1] { "tvshowtitles" });
                    });
                }
                return seriesCommand;
            }
        }

        private RelayCommand musicCommand;
        public RelayCommand MusicCommand {
            get {
                if (musicCommand == null) {
                    musicCommand = new RelayCommand(() => {
                        //GoToWindow(WindowsEnum.musiclibrary);
                    });
                }
                return musicCommand;
            }
        }

        private RelayCommand previousCommand;
        public RelayCommand PreviousCommand {
            get {
                if (previousCommand == null) {
                    previousCommand = new RelayCommand(() => {
                        //InputMethod(ExecActionEnum.skipprevious);
                    });
                }
                return previousCommand;
            }
        }

        private RelayCommand nextCommand;
        public RelayCommand NextCommand {
            get {
                if (nextCommand == null) {
                    nextCommand = new RelayCommand(() => {
                        //InputMethod(ExecActionEnum.skipnext);
                    });
                }
                return nextCommand;
            }
        }

        private RelayCommand stopCommand;
        public RelayCommand StopCommand {
            get {
                if (stopCommand == null) {
                    stopCommand = new RelayCommand(() => {
                        //InputMethod(ExecActionEnum.stop);
                    });
                }
                return stopCommand;
            }
        }

        private RelayCommand fastBackwardCommand;
        public RelayCommand FastBackwardCommand {
            get {
                if (fastBackwardCommand == null) {
                    fastBackwardCommand = new RelayCommand(() => {
                        //InputMethod(ExecActionEnum.rewind);
                    });
                }
                return fastBackwardCommand;
            }
        }

        private RelayCommand fastForwardCommand;
        public RelayCommand FastForwardCommand {
            get {
                if (fastForwardCommand == null) {
                    fastForwardCommand = new RelayCommand(() => {
                        //InputMethod(ExecActionEnum.fastforward);
                    });
                }
                return fastForwardCommand;
            }
        }
        //private async void SetVolume(IncDecEnum incDec) {
        //    //await OnXbmcDo(async xbmc => await xbmc.Application.SetVolume(incDec));
        //}

        //private async void ToggleMute() {
        //    await OnXbmcDo(async xbmc => await xbmc.Application.SetMute(ToggleEnum.Toggle));
        //}

        //private async void GoToWindow(WindowsEnum window, string[] optionalParameter = null) {
        //    await OnXbmcDo(async xbmc => await xbmc.GUI.ActivateWindow(window, optionalParameter));
        //}

        //private async void InputMethod(ExecActionEnum inputAction) {
        //    await OnXbmcDo(async xbmc => await xbmc.Input.ExecuteAction(inputAction));
        //}
    }
}
