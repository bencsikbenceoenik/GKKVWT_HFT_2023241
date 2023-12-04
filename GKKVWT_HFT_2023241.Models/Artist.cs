using System;
using System.Collections.Generic;

namespace GKKVWT_HFT_2023241.Models
{
    public class Artist
    {
        public enum ArtistType
        {
            Group,Solo
        }
        public string ArtistID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birth { get; set; }
        public int Gender { get; set; }
        public ArtistType Type { get; set; }
        public string Nationality { get; set; }
        public List<Song> Songs { get; set; }
    }
}
