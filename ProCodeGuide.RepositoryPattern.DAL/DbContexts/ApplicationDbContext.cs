using Microsoft.EntityFrameworkCore;
using ProCodeGuide.RepositoryPattern.Shared.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCodeGuide.RepositoryPattern.DAL.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<StudentSportEntity> StudentSport { get; set; }
        public DbSet<StudentAddressEntity> StudentAddress { get; set; }
    }
}
