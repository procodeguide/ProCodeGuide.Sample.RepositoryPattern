using ProCodeGuide.RepositoryPattern.Api.Models;
using ProCodeGuide.RepositoryPattern.Shared.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeGuide.RepositoryPattern.Api.Adapters
{
    public interface IStudentAdapter
    {
        StudentEntity Adapt(Student student);
        StudentAddressEntity AdaptToStudentAddress(Student student);
        StudentSportEntity AdaptToStudentSport(Student student);
        Student Adapt(StudentEntity studentEntity, StudentAddressEntity studentAddressEntity, StudentSportEntity studentSportEntity);
    }
}
