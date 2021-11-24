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
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly IMapper _mapper;

        public DriverController(IDriverService driverService, IMapper mapper)
        {
            _driverService = driverService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<DriverResource>> GetAllAsync()
        {
            var drivers = await _driverService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Driver>, IEnumerable<DriverResource>>(drivers);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDriverResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var driver = _mapper.Map<SaveDriverResource, Driver>(resource);
            var result = await _driverService.SaveAsync(driver);
            if (!result.Success)
                return BadRequest(result.Message);
            var driverResource = _mapper.Map<Driver, DriverResource>(result.Driver);
            return Ok(driverResource);
        }
    }
}