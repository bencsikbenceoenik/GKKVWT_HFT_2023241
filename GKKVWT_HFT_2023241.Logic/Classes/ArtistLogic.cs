using GKKVWT_HFT_2023241.Logic.Interfaces;
using GKKVWT_HFT_2023241.Repository.Interface;
using GKKVWT_HFT_2023241.Models;
using System;
using System.Linq;

namespace GKKVWT_HFT_2023241.Logic.Classes
{
    public class ArtistLogic : IArtistLogic
    {
        IRepository<Artist> repo;
        public ArtistLogic(IRepository<Artist> repo)
        {
            this.repo = repo;
        }
        public void Create(Artist item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Artist Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Artist> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Artist item)
        {
            this.repo.Update(item);
        }
    }
}
