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
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;
        private readonly IMapper _mapper;
        public RouteController(IRouteService routerService, IMapper mapper)
        {
            _routeService = routerService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<RouteResource>> GetAllAsync()
        {
            var routes = await _routeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Route>, IEnumerable<RouteResource>>(routes);
            return resources;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveRouteResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var route = _mapper.Map<SaveRouteResource, Route>(resource);
            var result = await _routeService.SaveAsync(route);
            if (!result.Success)
                return BadRequest(result.Message);
            var routeResource = _mapper.Map<Route, RouteResource>(result.Route);
            return Ok(routeResource);
        }
    }
}