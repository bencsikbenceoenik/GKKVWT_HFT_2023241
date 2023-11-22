using System;

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
        public string SongID { get; set; }
        public ArtistType Type { get; set;}
        public string LabelID { get; set; }
        public string Nationality { get; set; }
    }
}
