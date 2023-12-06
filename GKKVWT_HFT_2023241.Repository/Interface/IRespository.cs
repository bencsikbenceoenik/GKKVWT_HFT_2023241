using System.Linq;

namespace GKKVWT_HFT_2023241.Repository.Interface
{
    public interface IRespository<T> where T : class
    {
        IQueryable<T> ReadAll();
        T Read(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}