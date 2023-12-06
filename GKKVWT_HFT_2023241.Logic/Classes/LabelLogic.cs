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
    public class LabelLogic : ILabelLogic
    {
        IRepository<Label> repo;
        public LabelLogic(IRepository<Label> repo)
        {
            this.repo = repo;
        }

        public void Create(Label item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Label Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Label> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Label item)
        {
            this.repo.Update(item);
        }
    }
}
