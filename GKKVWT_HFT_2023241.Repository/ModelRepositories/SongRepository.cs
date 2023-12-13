using GKKVWT_HFT_2023241.Models;
using GKKVWT_HFT_2023241.Repository.Database;
using GKKVWT_HFT_2023241.Repository.Interface;
using GKKVWT_HFT_2023241.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKKVWT_HFT_2023241.Repository.ModelRepositories
{
    public class SongRepository : Repository<Song>, IRepository<Song>
    {
        public SongRepository(SongDbContext ctx) : base(ctx)
        {
        }

        public override Song Read(int id)
        {
            return ctx.Songs.FirstOrDefault(t => t.SongId == id);
        }

        public override void Update(Song item)
        {
           var prev = Read(item.SongId);
            foreach (var prop in prev.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(prev, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
