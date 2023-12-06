using GKKVWT_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKKVWT_HFT_2023241.Logic.Interfaces
{
    public interface IArtistLogic
    {
        void Create(Artist item);
        void Delete(int id);
        Artist Read(int id);
        IQueryable<Artist> ReadAll();
        void Update(Artist item);
    }
}
