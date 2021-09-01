using ProCodeGuide.RepositoryPattern.DAL.DbContexts;
using ProCodeGuide.RepositoryPattern.Shared.DbEntities;
using ProCodeGuide.RepositoryPattern.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCodeGuide.RepositoryPattern.DAL.Repositories
{
    public class StudentAddressRepository : GenericRepository<StudentAddressEntity>, IStudentAddressRepository
    {
        public StudentAddressRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public StudentAddressEntity GetByStudentCode(string studentCode)
        {
            return _dbcontext.StudentAddress.Where(address => address.StudentCode.Equals(studentCode)).FirstOrDefault(); ;
        }
    }
}
