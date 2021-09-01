using ProCodeGuide.RepositoryPattern.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeGuide.RepositoryPattern.Api.Services
{
    public interface IUnitOfWorkService
    {
        int Save();
        IStudentRepository Student { get; set; }
        IStudentAddressRepository StudentAddress { get; set; }
        IStudentSportRepository StudentSport { get; set; }
    }
}
