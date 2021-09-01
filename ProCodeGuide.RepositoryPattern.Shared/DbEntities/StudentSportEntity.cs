using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCodeGuide.RepositoryPattern.Shared.DbEntities
{
    public class StudentSportEntity
    {
        public int Id { get; set; }
        public string StudentCode { get; set; }
        public string Sport { get; set; }
        public bool IsDeleted { get; set; }
    }
}
