using GKKVWT_HFT_2023241.Repository.Database;
using GKKVWT_HFT_2023241.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKKVWT_HFT_2023241.Repository.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected SongDbContext ctx;
        public Repository(SongDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Read(id));
            ctx.SaveChanges();
        }
        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        public abstract T Read(int id);
        public abstract void Update(T item);
    }
}
