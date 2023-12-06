using GKKVWT_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKKVWT_HFT_2023241.Logic.Interfaces
{
    public interface ILabelLogic
    {
        void Create(Label item);
        void Delete(int id);
        Label Read(int id);
        IQueryable<Label> ReadAll();
        void Update(Label item);
    }
}
