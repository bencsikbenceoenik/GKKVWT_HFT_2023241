using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKKVWT_HFT_2023241.Models
{
    public class Label
    {
        public int LabelID { get; set; }
        public string LabelName { get; set; }
        public int LabelValue { get; set; }
        public string BasedIn { get; set; }/*Country and City*/
        public DateTime FoundmentDate { get; set; }
        public string Founder { get; set; }
    }
}
