using GKKVWT_HFT_2023241.Models;
using GKKVWT_HFT_2023241.Repository.Repository;
using GKKVWT_HFT_2023241.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GKKVWT_HFT_2023241.Repository.Database;

namespace GKKVWT_HFT_2023241.Repository.ModelRepositories
{
    public class ArtistRepository : Repository<Artist>, IRepository<Artist>
    {
        public ArtistRepository(SongDbContext ctx) : base(ctx)
        {
        }

        public override Artist Read(int id)
        {
            return ctx.Artists.FirstOrDefault(t => t.ArtistId == id);
        }

        public override void Update(Artist item)
        {
            var prev = Read(item.ArtistId);
            foreach (var prop in prev.GetType().GetProperties())
            {
                prop.SetValue(prev, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
