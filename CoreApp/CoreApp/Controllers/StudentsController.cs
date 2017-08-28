using CoreApp.DataAccess.Repository;
using CoreApp.DataAccess.UnitOfWork;
using CoreApp.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IUniversityUnitOfWork _universityUnitOfWork;

        public StudentsController(IRepository<Student> studentRepository, IUniversityUnitOfWork universityUnitOfWork)
        {
            _studentRepository = studentRepository;
            _universityUnitOfWork = universityUnitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            var result = await _studentRepository.GetManyAsync(s => true);
            return result;
        }

        [HttpPut]
        public async Task Put([FromBody]Student student)
        {
            _studentRepository.Update(student);
            await _universityUnitOfWork.CommitAsync();
        }

        [HttpPost]
        public async Task Post([FromBody]Student student)
        {
            _studentRepository.Create(student);
            await _universityUnitOfWork.CommitAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            _studentRepository.Delete(new Student { StudentId = id });
            await _universityUnitOfWork.CommitAsync();
        }
    }
}
