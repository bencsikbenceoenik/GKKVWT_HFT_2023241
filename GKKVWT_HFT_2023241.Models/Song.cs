using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKKVWT_HFT_2023241.Models
{
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SongID { get; set; }
        public string SongTitle { get; set;}
        public string SongType { get; set;}/*Genre*/
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public string Language { get; set; }/*if it has more than one than it will be "mixed"*/
        //Foreign key
        public string ArtistId { get; set; }
        public Artist Artist { get; set; }
        //Foreign key
        public string LabelId { get; set; }
        public Label Label { get; set; }
    }
}
