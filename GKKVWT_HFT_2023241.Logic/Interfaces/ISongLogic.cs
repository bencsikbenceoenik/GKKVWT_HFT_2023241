using GKKVWT_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKKVWT_HFT_2023241.Logic.Interfaces
{
    public interface ISongLogic
    {
        void Create(Song item);
        void Delete(int id);
        Song Read(int id);
        IQueryable<Song> ReadAll();
        void Update(Song item);
        IEnumerable<Song> GetSongsByDurationAndArtistGender(int durationThreshold, string artistGender);
        IEnumerable<Song> GetSongsByArtistsDebutedAfterYear(int debutYearThreshold);
        IEnumerable<Song> GetSongsByLabelValueGreaterThan(double thresholdValue);
        IEnumerable<Song> GetSongsReleasedAfterYearByNationality(int releaseYear, string nationality);
        IEnumerable<Song> GetSongsByArtistAndLabel(string artistName, string labelName);
    }
}
