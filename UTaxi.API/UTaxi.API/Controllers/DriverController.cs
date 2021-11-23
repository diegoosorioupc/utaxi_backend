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
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly IMapper _mapper;

        public DriverController(IDriverService driverService, IMapper mapper)
        {
            _driverService = driverService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DriverResource>> GetAllAsync()
        {
            var drivers = await _driverService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Driver>, IEnumerable<DriverResource>>(drivers);
            return resources;
        }
    }
}