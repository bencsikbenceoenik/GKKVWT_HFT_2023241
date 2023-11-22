using GKKVWT_HFT_2023241.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKKVWT_HFT_2023241.Repository.Repository
{
    public abstract class Repository<T> : IRespository<T> where T : class
    {

    }
}
