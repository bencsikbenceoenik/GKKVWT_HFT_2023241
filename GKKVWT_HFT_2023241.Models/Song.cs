using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKKVWT_HFT_2023241.Models
{
    public class Song
    {
        public string SongID { get; set; }
        public string SongName { get; set;}
        public string SongType { get; set;}/*Genre*/
        public string ArtistID { get; set; }
        public string LabelID { get; set; }
        public DateTime Released { get; set; }
        public int Length { get; set; }
        public string Language { get; set; }/*if it has more than one than it will be "mixed"*/
    }
}
