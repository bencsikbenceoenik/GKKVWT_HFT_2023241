using GKKVWT_HFT_2023241.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_Client.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        #region Artist
        public RestCollection<Artist> Artists { get; set; }

        private Artist selectedArtist;

        public Artist SelectedArtist
        {
            get { return selectedArtist; }
            set
            {
                if (value != null)
                {
                    selectedArtist = new Artist()
                    {
                        ArtistName = value.ArtistName,
                        ArtistId = value.ArtistId
                    };
                    OnPropertyChanged();
                    (DeleteArtistCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand CreateArtistCommand { get; set; }
        public ICommand DeleteArtistCommand { get; set; }
        public ICommand UpdateArtistCommand { get; set; }

        #endregion

        #region Song
        public RestCollection<Song> Songs { get; set; }

        private Song selectedSong;

        public Song SelectedSong
        {
            get { return selectedSong; }
            set
            {
                if (value != null)
                {
                    selectedSong = new Song()
                    {
                        SongTitle = value.SongTitle,
                        SongId = value.SongId
                    };
                    OnPropertyChanged();
                    (DeleteSongCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand CreateSongCommand { get; set; }
        public ICommand DeleteSongCommand { get; set; }
        public ICommand UpdateSongCommand { get; set; }

        #endregion

        #region Label
        public RestCollection<Label> Labels { get; set; }

        private Label selectedLabel;

        public Label SelectedLabel
        {
            get { return selectedLabel; }
            set
            {
                if (value != null)
                {
                    selectedLabel = new Label()
                    {
                        LabelName = value.LabelName,
                        LabelId = value.LabelId
                    };
                    OnPropertyChanged();
                    (DeleteLabelCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand CreateLabelCommand { get; set; }
        public ICommand DeleteLabelCommand { get; set; }
        public ICommand UpdateLabelCommand { get; set; }

        #endregion

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                #region Artist

                Artists = new RestCollection<Artist>("http://localhost:40338/", "artist", "hub");
                CreateArtistCommand = new RelayCommand(() =>
                {
                    Artists.Add(new Artist()
                    {
                        ArtistName = SelectedArtist.ArtistName
                    });
                });

                UpdateArtistCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Artists.Update(SelectedArtist);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteArtistCommand = new RelayCommand(() =>
                {
                    Artists.Delete(SelectedArtist.ArtistId);
                },
                () =>
                {
                    return SelectedArtist != null;
                });
                SelectedArtist = new Artist();

                #endregion

                #region Song

                Songs = new RestCollection<Song>("http://localhost:40338/", "song", "hub");
                CreateSongCommand = new RelayCommand(() =>
                {
                    Songs.Add(new Song()
                    {
                        SongTitle = SelectedSong.SongTitle
                    });
                });

                UpdateSongCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Songs.Update(SelectedSong);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteSongCommand = new RelayCommand(() =>
                {
                    Songs.Delete(SelectedSong.SongId);
                },
                () =>
                {
                    return SelectedSong != null;
                });
                SelectedSong = new Song();

                #endregion

                #region Label

                Artists = new RestCollection<Artist>("http://localhost:40338/", "label", "hub");
                CreateLabelCommand = new RelayCommand(() =>
                {
                    Labels.Add(new Label()
                    {
                        LabelName = SelectedLabel.LabelName
                    });
                });

                UpdateLabelCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Labels.Update(SelectedLabel);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteLabelCommand = new RelayCommand(() =>
                {
                    Labels.Delete(SelectedLabel.LabelId);
                },
                () =>
                {
                    return SelectedLabel != null;
                });
                SelectedLabel = new Label();

                #endregion

            }
        }

    }
}
