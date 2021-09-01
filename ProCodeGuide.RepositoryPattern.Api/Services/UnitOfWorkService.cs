using ProCodeGuide.RepositoryPattern.DAL.DbContexts;
using ProCodeGuide.RepositoryPattern.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeGuide.RepositoryPattern.Api.Services
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWorkService(ApplicationDbContext dbContext, IStudentRepository studentRepository, IStudentSportRepository studentSportRepository, IStudentAddressRepository studentAddressRepository)
        {
            _dbContext = dbContext;
            Student = studentRepository;
            StudentSport = studentSportRepository;
            StudentAddress = studentAddressRepository;
        }

        public IStudentRepository Student { get; set; }
        public IStudentSportRepository StudentSport { get; set; }
        public IStudentAddressRepository StudentAddress { get; set; }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }
    }
}
