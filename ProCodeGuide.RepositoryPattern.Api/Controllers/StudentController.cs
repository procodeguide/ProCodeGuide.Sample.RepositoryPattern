using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProCodeGuide.RepositoryPattern.Api.Models;
using ProCodeGuide.RepositoryPattern.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeGuide.RepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _studentService.GetAll();
        }

        [HttpGet("{studentCode}")]
        public Student GetByStudentCode(string studentCode)
        {
            return _studentService.GetByStudentCode(studentCode);
        }

        [HttpPost]
        [Route("Add")]
        public void Add([FromBody] Student student)
        {
            _studentService.Add(student);
        }
    }
}
