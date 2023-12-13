using GKKVWT_HFT_2023241.Logic.Interfaces;
using GKKVWT_HFT_2023241.Models;
using GKKVWT_HFT_2023241.Repository.Interface;
using GKKVWT_HFT_2023241.Repository.ModelRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKKVWT_HFT_2023241.Logic.Classes
{
    public class SongLogic : ISongLogic
    {

        IRepository<Song> songRepo;
        IRepository<Artist> artistRepo;
        IRepository<Label> labelRepo;
        public SongLogic(IRepository<Song> songRepo)
        {
            this.songRepo = songRepo;
        }
        public SongLogic(IRepository<Song> songRepo, IRepository<Artist> artistRepo)
        {
            this.songRepo = songRepo;
            this.artistRepo = artistRepo;
        }
        public SongLogic(IRepository<Song> songRepo, IRepository<Artist> artistRepo, IRepository<Label> labelRepo)
        {
            this.songRepo = songRepo;
            this.artistRepo = artistRepo;
            this.labelRepo = labelRepo;
        }

        public IEnumerable<Song> GetSongsByDurationAndArtistGender(int durationThreshold, string artistGender)
        {
            // Retrieve artists with the specified gender
            var artists = artistRepo.ReadAll().Where(a => a.Gender == artistGender).ToList();

            // Retrieve songs with a duration longer than the threshold by artists with the specified gender
            var songs = songRepo.ReadAll()
                .Where(s => s.Duration > durationThreshold && artists.Any(a => a.ArtistId == s.ArtistId));

            return songs;
        }

        public IEnumerable<Song> GetSongsByArtistsDebutedAfterYear(int debutYearThreshold)
        {
            // Retrieve artists who debuted after the specified year
            var artists = artistRepo.ReadAll().Where(a => a.DebutYear > debutYearThreshold).ToList();

            // Retrieve songs released by those artists
            var songs = songRepo.ReadAll()
                .Where(s => artists.Any(a => a.ArtistId == s.ArtistId));

            return songs;
        }
        public IEnumerable<Song> GetSongsByLabelWithValueGreaterThan(double thresholdValue, string labelName)
        {
            // Retrieve the label by name
            var label = labelRepo.ReadAll().FirstOrDefault(l => l.LabelName == labelName);

            if (label == null)
            {
                throw new ArgumentNullException($"Label with name '{labelName}' not found.");
            }

            // Retrieve songs from the specified label with a label value greater than the threshold
            var songs = songRepo.ReadAll()
                .Where(s => s.LabelId == label.LabelId && label.LabelValue > thresholdValue);

            return songs;
        }

        public IEnumerable<Song> GetSongsReleasedAfterYearByNationality(int releaseYear, string nationality)
        {
            // Retrieve artists by nationality
            var artists = artistRepo.ReadAll().Where(a => a.Nationality == nationality).ToList();

            // Retrieve songs released after a certain year by artists of the specified nationality
            var songs = songRepo.ReadAll()
                .Where(s => s.ReleaseDate.Year > releaseYear && artists.Any(a => a.ArtistId == s.ArtistId));

            return songs;
        }
        public IEnumerable<Song> GetSongsByArtistAndLabel(string artistName, string labelName)
        {
            // Retrieve the artist by name
            var artist = artistRepo.ReadAll().FirstOrDefault(a => a.ArtistName == artistName);

            if (artist == null)
            {
                throw new ArgumentException($"Artist with name '{artistName}' not found.");
            }

            // Retrieve the label by name
            var label = labelRepo.ReadAll().FirstOrDefault(l => l.LabelName == labelName);

            if (label == null)
            {
                throw new ArgumentException($"Label with name '{labelName}' not found.");
            }

            // Retrieve songs by artist and label
            var songs = songRepo.ReadAll()
                .Where(s => s.ArtistId == artist.ArtistId && s.LabelId == label.LabelId);

            return songs;
        }

        public void Create(Song item)
        {
            if (item.SongTitle.Length < 5)
            {
                throw new ArgumentException("Title too short");
            }
            this.songRepo.Create(item);
        }

        public void Delete(int id)
        {
            this.songRepo.Delete(id);
        }

        public Song Read(int id)
        {
            return this.songRepo.Read(id);
        }

        public IQueryable<Song> ReadAll()
        {
            return this.songRepo.ReadAll();
        }

        public void Update(Song item)
        {
            this.songRepo.Update(item);
        }
    }
}
