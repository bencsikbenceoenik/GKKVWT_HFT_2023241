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
    public class LabelRepository : Repository<Label>, IRepository<Label>
    {
        public LabelRepository(SongDbContext ctx) : base(ctx)
        {
        }

        public override Label Read(int id)
        {
            return ctx.Labels.FirstOrDefault(t => t.LabelId == id);
        }

        public override void Update(Label item)
        {
            var prev = Read(item.LabelId);
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
