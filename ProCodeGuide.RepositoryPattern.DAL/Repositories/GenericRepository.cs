using ProCodeGuide.RepositoryPattern.DAL.DbContexts;
using ProCodeGuide.RepositoryPattern.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCodeGuide.RepositoryPattern.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbcontext;
        public GenericRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Add(T entity)
        {
            _dbcontext.Set<T>().Add(entity);
        }

        public T GetById(int id)
        {
            return _dbcontext.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _dbcontext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbcontext.Set<T>().ToList();
        }

        public int Complete()
        {
            return _dbcontext.SaveChanges();
        }
    }
}
