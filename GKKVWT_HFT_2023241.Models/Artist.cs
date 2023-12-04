using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GKKVWT_HFT_2023241.Models
{
    public class Artist
    {
        public enum ArtistType
        {
            Group,Solo
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int Age { get; set; }
        public DateTime Birth { get; set; }
        public int Gender { get; set; }
        public ArtistType Type { get; set; }
        public string Nationality { get; set; }
        public virtual List<Song> Songs { get; set; }
    }
}
