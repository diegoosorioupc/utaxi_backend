using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Services;
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
            var studentroutes = await _studentRouteService.ListAsync();
            var resources = _mapper.Map<IEnumerable<StudentRoute>, IEnumerable<StudentRouteResource>>(studentroutes);
            return resources;
        }
    }
}