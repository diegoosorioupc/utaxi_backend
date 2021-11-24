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
    public class StudentRouteController: ControllerBase
    {
        private readonly IStudentRouteService _studentRouteService;
        private readonly IMapper _mapper;
        public StudentRouteController(IStudentRouteService studentService, IMapper mapper)
        {
            _studentRouteService = studentService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<StudentRouteResource>> GetAllAsync()
        {
            var studentRoutes = await _studentRouteService.ListAsync();
            var resources = _mapper.Map<IEnumerable<StudentRoute>, IEnumerable<StudentRouteResource>>(studentRoutes);
            return resources;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] StudentRouteResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var studentRoute = _mapper.Map<StudentRouteResource, StudentRoute>(resource);
            var result = await _studentRouteService.SaveAsync(studentRoute);
            if (!result.Success)
                return BadRequest(result.Message);
            var studentRouteResource = _mapper.Map<StudentRoute, StudentRouteResource>(result.StudentRoute);
            return Ok(studentRouteResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id,[FromBody] StudentRouteResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var studentRoute = _mapper.Map<StudentRouteResource, StudentRoute>(resource);
            var result = await _studentRouteService.UpdateAsync(id,studentRoute);
            if (!result.Success)
                return BadRequest(result.Message);
            var studentRouteResource = _mapper.Map<StudentRoute, StudentRouteResource>(result.StudentRoute);
            return Ok(studentRouteResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _studentRouteService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var studentRouteResource = _mapper.Map<StudentRoute, StudentRouteResource>(result.StudentRoute);
            return Ok(studentRouteResource);
        }
    }
}