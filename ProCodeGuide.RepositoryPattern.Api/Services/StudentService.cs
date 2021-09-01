using ProCodeGuide.RepositoryPattern.Api.Adapters;
using ProCodeGuide.RepositoryPattern.Api.Models;
using ProCodeGuide.RepositoryPattern.Shared.DbEntities;
using ProCodeGuide.RepositoryPattern.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeGuide.RepositoryPattern.Api.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentAdapter _studentAdapter;
        private readonly IUnitOfWorkService _unitOfWorkService;
        public StudentService(IUnitOfWorkService unitOfWorkService, IStudentAdapter studentAdapter)
        {
            _unitOfWorkService = unitOfWorkService;
            _studentAdapter = studentAdapter;
        }

        public void Add(Student student)
        {
            if (Validate(student))
            {
                _unitOfWorkService.Student.Add(_studentAdapter.Adapt(student));
                _unitOfWorkService.StudentSport.Add(_studentAdapter.AdaptToStudentSport(student));
                _unitOfWorkService.StudentAddress.Add(_studentAdapter.AdaptToStudentAddress(student));

                _unitOfWorkService.Save();
            }
        }

        public IEnumerable<Student> GetAll()
        {
            List<Student> listStudent = new List<Student>();
            foreach (StudentEntity studentEntity in _unitOfWorkService.Student.GetAll())
            {
                listStudent.Add(_studentAdapter.Adapt(studentEntity,
                    _unitOfWorkService.StudentAddress.GetByStudentCode(studentEntity.StudentCode),
                    _unitOfWorkService.StudentSport.GetByStudentCode(studentEntity.StudentCode)));
            }
            return listStudent;
        }

        public Student GetByStudentCode(string studentCode)
        {
            StudentEntity studentEntity = _unitOfWorkService.Student.GetByStudentCode(studentCode);
            return _studentAdapter.Adapt(studentEntity,
                _unitOfWorkService.StudentAddress.GetByStudentCode(studentEntity.StudentCode),
                _unitOfWorkService.StudentSport.GetByStudentCode(studentEntity.StudentCode));
        }

        public void Remove(Student student)
        {
            _unitOfWorkService.Student.Remove(_studentAdapter.Adapt(student));
            _unitOfWorkService.Save();
        }

        public bool Validate(Student student)
        {
            //Validate Students Data
            return true;
        }
    }
}
