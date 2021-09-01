using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCodeGuide.RepositoryPattern.Shared.DbEntities
{
    public class StudentAddressEntity
    {
        public int Id { get; set; }
        public string StudentCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Country { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsDeleted { get; set; }
    }
}
