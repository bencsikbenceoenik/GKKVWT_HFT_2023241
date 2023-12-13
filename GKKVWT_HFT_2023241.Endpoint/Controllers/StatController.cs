using GKKVWT_HFT_2023241.Logic.Interfaces;
using GKKVWT_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GKKVWT_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ISongLogic logic;

        public StatController(ISongLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Song> GetSongsByDurationAndArtistGender(int durationThreshold, string artistGender)
        {
            return this.logic.GetSongsByDurationAndArtistGender(durationThreshold, artistGender);
        }

        [HttpGet]
        public IEnumerable<Song> GetSongsByArtistsDebutedAfterYear(int debutYearThreshold)
        {
            return this.logic.GetSongsByArtistsDebutedAfterYear(debutYearThreshold);
        }
        [HttpGet]
        public IEnumerable<Song> GetSongsByLabelValueGreaterThan(double thresholdValue)
        {
            return this.logic.GetSongsByLabelValueGreaterThan(thresholdValue);
        }
        [HttpGet]
        public IEnumerable<Song> GetSongsReleasedAfterYearByNationality(int releaseYear, string nationality)
        {
            return this.logic.GetSongsReleasedAfterYearByNationality(releaseYear, nationality);
        }
        [HttpGet]
        public IEnumerable<Song> GetSongsByArtistAndLabel(string artistName, string labelName)
        {
            return this.logic.GetSongsByArtistAndLabel(artistName, labelName);
        }
    }
}
