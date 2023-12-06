using GKKVWT_HFT_2023241.Logic.Interfaces;
using GKKVWT_HFT_2023241.Models;
using GKKVWT_HFT_2023241.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKKVWT_HFT_2023241.Logic.Classes
{
    public class SongLogic : ISongLogic
    {
        IRepository<Song> repo;
        public SongLogic(IRepository<Song> repo)
        {
            this.repo = repo;
        }
        public void Create(Song item)
        {
            if (item.SongTitle.Length < 5)
            {
                throw new ArgumentException("Title too short");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Song Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Song> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Song item)
        {
            this.repo.Update(item);
        }
    }
}
