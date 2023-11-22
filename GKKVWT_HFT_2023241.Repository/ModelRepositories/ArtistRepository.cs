using GKKVWT_HFT_2023241.Models;
using GKKVWT_HFT_2023241.Repository.Repository;
using GKKVWT_HFT_2023241.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKKVWT_HFT_2023241.Repository.ModelRepositories
{
    public class ArtistRepository : Repository<Artist> , IRespository<Artist>
    {
    }
}
