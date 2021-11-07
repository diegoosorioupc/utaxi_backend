using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Services;

namespace UTaxi.API.Controllers
{
    [Route("/api/v1/[controller]")]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routerService)
        {
            _routeService = routerService;
        }
        public async Task<IEnumerable<Route>> GetAllAsync()
        {
            var routes = await _routeService.ListAsync();
            return routes;
        }
    }
}