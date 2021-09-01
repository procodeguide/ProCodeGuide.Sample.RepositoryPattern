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
    public class StudentSportRepository : GenericRepository<StudentSportEntity>, IStudentSportRepository
    {
        public StudentSportRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public StudentSportEntity GetByStudentCode(string studentCode)
        {
            return _dbcontext.StudentSport.Where(sport => sport.StudentCode.Equals(studentCode)).FirstOrDefault(); ;
        }
    }
}
