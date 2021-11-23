using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Services;

namespace UTaxi.API.Controllers
{
    [Route("/api/v1/[controller]")]
    public class StudentRouteController: ControllerBase
    {
        private readonly IStudentRouteService _studentRouteService;

        public StudentRouteController(IStudentRouteService studentService)
        {
            _studentRouteService = studentService;
        }
        public async Task<IEnumerable<StudentRoute>> GetAllAsync()
        {
            var studentroutes = await _studentRouteService.ListAsync();
            return studentroutes;
        }
    }
}