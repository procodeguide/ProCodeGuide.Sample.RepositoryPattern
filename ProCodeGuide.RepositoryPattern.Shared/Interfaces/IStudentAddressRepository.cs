using ProCodeGuide.RepositoryPattern.Shared.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCodeGuide.RepositoryPattern.Shared.Interfaces
{
    public interface IStudentAddressRepository : IGenericRepository<StudentAddressEntity>
    {
        StudentAddressEntity GetByStudentCode(string studentCode);
    }
}
