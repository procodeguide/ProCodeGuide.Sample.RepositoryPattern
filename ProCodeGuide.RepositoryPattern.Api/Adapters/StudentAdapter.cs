using ProCodeGuide.RepositoryPattern.Api.Models;
using ProCodeGuide.RepositoryPattern.Shared.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeGuide.RepositoryPattern.Api.Adapters
{
    public class StudentAdapter : IStudentAdapter
    {
        public StudentEntity Adapt(Student student)
        {
            return new StudentEntity()
            {
                StudentCode = student.StudentCode,
                Name = student.Name,
                Grade = student.Grade,
                Age = student.Age,
                CreatedOn = DateTime.Now,
                IsDeleted = false,
                LastModifiedOn = DateTime.Now,
                LastModifiedBy = "User 1"
            };
        }

        public StudentSportEntity AdaptToStudentSport(Student student)
        {
            return new StudentSportEntity()
            {
                StudentCode = student.StudentCode,
                Sport = student.PreferredSport,
                IsDeleted = false
            };
        }

        public StudentAddressEntity AdaptToStudentAddress(Student student)
        {
            return new StudentAddressEntity()
            {
                Address = student.Address,
                State = student.State,
                City = student.City,
                Country = student.Country,
                PinCode = student.PinCode,
                StudentCode = student.StudentCode,
                IsPrimary = true,
                IsDeleted = false
            };
        }

        public Student Adapt(StudentEntity studentEntity, StudentAddressEntity studentAddressEntity, StudentSportEntity studentSportEntity)
        {
            return new Student()
            {
                StudentCode = studentEntity.StudentCode,
                Name = studentEntity.Name,
                Age = studentEntity.Age,
                Grade = studentEntity.Grade,

                Address = studentAddressEntity.Address,
                City = studentAddressEntity.City,
                Country = studentAddressEntity.Country,
                PinCode = studentAddressEntity.PinCode,
                State = studentAddressEntity.State,

                PreferredSport = studentSportEntity.Sport
            };
        }
    }
}
