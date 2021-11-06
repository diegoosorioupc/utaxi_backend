using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Services;

namespace UTaxi.API.Controllers
{
    [Route("/api/v1/[controller]")]
    public class DetailsRouteController :ControllerBase
    {
        private readonly IDetailsRouteService _detailsRouteService;


        public DetailsRouteController(IDetailsRouteService detailsRouteService)
        {
            _detailsRouteService = detailsRouteService;
        }

        public async Task<IEnumerable<DetailsRoute>> GetAllAsync()
        {
            var details = await _detailsRouteService.ListAsync();
            return details;
        }
    }
}