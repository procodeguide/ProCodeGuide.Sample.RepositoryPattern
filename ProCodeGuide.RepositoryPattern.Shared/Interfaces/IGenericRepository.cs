using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCodeGuide.RepositoryPattern.Shared.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        T GetById(int id);
        void Remove(T entity);
        IEnumerable<T> GetAll();
        int Complete();
    }
}
