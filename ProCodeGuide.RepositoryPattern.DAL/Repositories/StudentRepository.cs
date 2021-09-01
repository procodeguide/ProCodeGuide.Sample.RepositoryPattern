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
    public class StudentRepository : GenericRepository<StudentEntity>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public StudentEntity GetByStudentCode(string studentCode)
        {
            return _dbcontext.Students.Where(student => student.StudentCode.Equals(studentCode)).FirstOrDefault();
        }
    }
}
