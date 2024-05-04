using GKKVWT_HFT_2023241.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_Client.Updatewindows;

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
                        ArtistId = value.ArtistId,
                        Age = value.Age,
                        DebutYear = value.DebutYear,
                        Gender = value.Gender,
                        Nationality = value.Nationality,
                        Songs = value.Songs,
                        Type = value.Type
                    };
                    //SetProperty(ref selectedArtist, value);
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
                        SongId = value.SongId,
                        SongType = value.SongType,
                        Artist = value.Artist,
                        ArtistId = value.ArtistId,
                        Duration = value.Duration,
                        Label = value.Label,
                        LabelId = value.LabelId,
                        Language = value.Language,
                        ReleaseDate = value.ReleaseDate
                    };
                    //SetProperty(ref selectedSong, value);
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
                        LabelId = value.LabelId,
                        BasedIn = value.BasedIn,
                        Founder = value.Founder,
                        FoundmentDate = value.FoundmentDate,
                        LabelValue = value.LabelValue,
                        Songs = value.Songs,
                    };
                    //SetProperty(ref selectedLabel, value);
                    OnPropertyChanged();
                    (DeleteLabelCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand CreateLabelCommand { get; set; }
        public ICommand DeleteLabelCommand { get; set; }
        public ICommand UpdateLabelCommand { get; set; }

        #endregion

        #region Label
        //public ObservableCollection<Song> noncrud { get; set; }

        private ObservableCollection<Song> nonCrud;

        public ObservableCollection<Song> NonCrud
        {
            get { return nonCrud; }
            set { SetProperty(ref nonCrud, value); }
        }

        private string noncrudinput1;

        public string Noncrudinput1
        {
            get { return noncrudinput1; }
            set { noncrudinput1 = value; }
        }
        
        private string noncrudinput2;

        public string Noncrudinput2
        {
            get { return noncrudinput2; }
            set { noncrudinput2 = value; }
        }
        public ICommand nonCrud1 { get; set; }
        public ICommand nonCrud2 { get; set; }
        public ICommand nonCrud3 { get; set; }
        public ICommand nonCrud4 { get; set; }
        public ICommand nonCrud5 { get; set; }

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
                        ArtistUpdateWindow artistUpdate = new ArtistUpdateWindow(SelectedArtist);
                        if (artistUpdate.ShowDialog() == true)
                        {
                            SelectedArtist = artistUpdate.SelectedArtist;
                            Artists.Update(SelectedArtist);
                        }
                        
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
                    return (SelectedArtist != null && Artists.Select(t => t.ArtistId).ToList().Contains(SelectedArtist.ArtistId));
                });
                //SelectedArtist = new Artist();

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
                        SongUpdateWindow songUpdate = new SongUpdateWindow(SelectedSong);
                        if (songUpdate.ShowDialog() == true)
                        {
                            SelectedSong = songUpdate.SelectedSong;
                            Songs.Update(SelectedSong);
                        }
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
                    return (SelectedSong != null && Songs.Select(t => t.SongId).ToList().Contains(SelectedSong.SongId));
                });
                //SelectedSong = new Song();

                #endregion

                #region Label

                Labels = new RestCollection<Label>("http://localhost:40338/", "label", "hub");
                CreateLabelCommand = new RelayCommand(() =>
                {
                    Labels.Add(new Label()
                    {
                        LabelName = SelectedLabel.LabelName,
                        FoundmentDate = DateTime.Now
                    });
                });

                UpdateLabelCommand = new RelayCommand(() =>
                {
                    try
                    {
                        LabelUpdateWindow labelUpdate = new LabelUpdateWindow(SelectedLabel);
                        if (labelUpdate.ShowDialog() == true)
                        {
                            SelectedLabel = labelUpdate.SelectedLabel;
                            Labels.Update(SelectedLabel);
                        }
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
                    return (SelectedLabel != null && Labels.Select(t => t.LabelId).ToList().Contains(SelectedLabel.LabelId));
                });
                //SelectedLabel = new Label();

                #endregion

                NonCrud = new ObservableCollection<Song>();
                nonCrud1 = new RelayCommand(() =>
                {
                    NonCrud.Clear();
                    Songs.rest.Get<Song>($"/Stat/GetSongsByDurationAndArtistGender?durationThreshold={Noncrudinput1}&artistGender={Noncrudinput2}").ForEach(t => { NonCrud.Add(t); });
                    OnPropertyChanged();
                });
                nonCrud2 = new RelayCommand(() =>
                {
                    NonCrud.Clear();
                    Songs.rest.Get<Song>($"/Stat/GetSongsByArtistsDebutedAfterYear?debutYearThreshold={Noncrudinput1}").ForEach(t => { NonCrud.Add(t); });
                    OnPropertyChanged();
                });
                nonCrud3 = new RelayCommand(() =>
                {
                    NonCrud.Clear();
                    Songs.rest.Get<Song>($"/Stat/GetSongsByLabelValueGreaterThan?thresholdValue={Noncrudinput1}").ForEach(t => { NonCrud.Add(t); });
                    OnPropertyChanged();
                });
                nonCrud4 = new RelayCommand(() =>
                {
                    NonCrud.Clear();
                    Songs.rest.Get<Song>($"/Stat/GetSongsReleasedAfterYearByNationality?releaseYear={Noncrudinput1}&nationality={Noncrudinput2}").ForEach(t => { NonCrud.Add(t); });
                    OnPropertyChanged();
                });
                nonCrud5 = new RelayCommand(() =>
                {
                    NonCrud.Clear();
                    Songs.rest.Get<Song>($"/Stat/GetSongsByArtistAndLabel?artistName={Noncrudinput1}&labelName={Noncrudinput2}").ForEach(t => { NonCrud.Add(t); });
                    OnPropertyChanged();
                });

            }
        }

    }
}
