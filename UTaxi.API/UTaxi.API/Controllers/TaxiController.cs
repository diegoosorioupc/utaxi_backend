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
    public class TaxiController : ControllerBase
    {
        private readonly ITaxiService _taxiService;
        private readonly IMapper _mapper;
        public TaxiController(ITaxiService taxiService, IMapper mapper)
        {
            _taxiService = taxiService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<TaxiResource>> GetAllAsync()
        {
            var taxis = await _taxiService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Taxi>, IEnumerable<TaxiResource>>(taxis);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveTaxiResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var taxi = _mapper.Map<SaveTaxiResource, Taxi>(resource);
            var result = await _taxiService.SaveAsync(taxi);
            if (!result.Success)
                return BadRequest(result.Message);
            var taxiResource = _mapper.Map<Taxi, TaxiResource>(result.Taxi);
            return Ok(taxiResource);
        }
    }
}