using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Services;

namespace UTaxi.API.Controllers
{
    [Route("/api/v1/[controller]")]
    public class TaxiController : ControllerBase
    {
        private readonly ITaxiService _taxiService;

        public TaxiController(ITaxiService taxiService)
        {
            _taxiService = taxiService;
        }
        public async Task<IEnumerable<Taxi>> GetAllAsync()
        {
            var taxis = await _taxiService.ListAsync();
            return taxis;
        }
    }
}