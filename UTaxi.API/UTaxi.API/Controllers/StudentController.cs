using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Services;
using UTaxi.API.Extensions;
using UTaxi.API.Resources;

namespace UTaxi.API.Controllers
{
    [Route("/api/v1/[controller]")]
    public class StudentController: ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<StudentResource>> GetAllAsync()
        {
            var students = await _studentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Student>, IEnumerable<StudentResource>>(students);
            return resources;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveStudentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var student = _mapper.Map<SaveStudentResource, Student>(resource);
            var result = await _studentService.SaveAsync(student);
            if (!result.Success)
                return BadRequest(result.Message);
            var studentResource = _mapper.Map<Student, StudentResource>(result.Student);
            return Ok(studentResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id,[FromBody] SaveStudentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var student = _mapper.Map<SaveStudentResource, Student>(resource);
            var result = await _studentService.UpdateAsync(id,student);
            if (!result.Success)
                return BadRequest(result.Message);
            var studentResource = _mapper.Map<Student, StudentResource>(result.Student);
            return Ok(studentResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _studentService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var studentResource = _mapper.Map<Student, StudentResource>(result.Student);
            return Ok(studentResource);
        }
    }
}