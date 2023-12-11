using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int Age { get; set; }
        public int DebutYear { get; set; }
        public string Gender { get; set; }
        public ArtistType Type { get; set; }
        public string Nationality { get; set; }
        public virtual List<Song> Songs { get; set; }

        public Artist()
        {

        }

        public Artist(string input)
        {
            this.ArtistId = int.Parse(input.Split('#')[0]);
            this.ArtistName = input.Split('#')[1];
            this.Type = (ArtistType)Enum.Parse(typeof(ArtistType), input.Split('#')[4]);
            if (Type == ArtistType.Group)
            {
                this.Age = 0;
            }
            else
            {
                this.Age = DateTime.Now.Subtract(DateTime.Parse(input.Split('#')[2])).Days / 365;
            }
            this.DebutYear = int.Parse(input.Split('#')[3]);
            this.Gender = input.Split('#')[5];
            this.Nationality = input.Split('#')[6];
        }
    }
}
