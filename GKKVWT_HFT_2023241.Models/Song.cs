﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace GKKVWT_HFT_2023241.Models
{
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SongId { get; set; }
        [StringLength(100)]
        public string SongTitle { get; set;}
        public string SongType { get; set;}/*Genre*/
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public string Language { get; set; }/*if it has more than one than it will be "mixed"*/
        //Foreign key
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        //Foreign key
        public int LabelId { get; set; }

        public virtual Label Label { get; set; }

        public Song()
        {

        }

        public Song(string input)
        {
            SongId = int.Parse(input.Split('#')[0]);
            SongTitle = input.Split('#')[1];
            SongType = input.Split('#')[2];
            ReleaseDate = DateTime.Parse(input.Split('#')[3]);
            Duration = int.Parse(input.Split('#')[4]);
            Language = input.Split('#')[5];
            ArtistId = int.Parse(input.Split('#')[6]);
            LabelId = int.Parse(input.Split('#')[7]);
        }
    }
}
