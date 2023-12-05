using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Globalization;

namespace GKKVWT_HFT_2023241.Models
{
    public class Label
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LabelId { get; set; }
        public string LabelName { get; set; }
        public double LabelValue { get; set; }
        public string BasedIn { get; set; }/*Country and City*/
        public DateTime FoundmentDate { get; set; }
        public string Founder { get; set; }
        public virtual List<Song> Songs { get; set; }

        public Label()
        {

        }

        public Label(string input)
        {
            LabelId = int.Parse(input.Split('#')[0]);
            LabelName = input.Split('#')[1];
            if (input.Split('#')[2].Contains(' '))
            {
                if (input.Split('#')[2].Split(' ')[1] == "Billion")
                {
                    string temp = input.Split('#')[2].Split(' ')[0];
                    LabelValue = double.Parse(input.Split('#')[2].Split(' ')[0], CultureInfo.InvariantCulture)*1000000000;
                }
                else
                {
                    LabelValue = double.Parse(input.Split('#')[2].Split(' ')[0])*1000000;
                }
            }
            else
            {
                LabelValue = long.Parse(input.Split('#')[2]);
            }
            BasedIn = input.Split('#')[3];
            FoundmentDate = DateTime.Parse(input.Split('#')[4]);
            Founder = input.Split('#')[5];
        }
    }
}
