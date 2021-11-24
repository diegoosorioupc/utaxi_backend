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
    public class DetailsRouteController :ControllerBase
    {
        private readonly IDetailsRouteService _detailsRouteService;
        private readonly IMapper _mapper;

        public DetailsRouteController(IDetailsRouteService detailsRouteService, IMapper mapper)
        {
            _detailsRouteService = detailsRouteService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<DetailsRouteResource>> GetAllAsync()
        {
            var details = await _detailsRouteService.ListAsync();
            var resources = _mapper.Map<IEnumerable<DetailsRoute>, IEnumerable<DetailsRouteResource>>(details);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDetailsRouteResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var detailsRoute = _mapper.Map<SaveDetailsRouteResource, DetailsRoute>(resource);
            var result = await _detailsRouteService.SaveAsync(detailsRoute);
            if (!result.Success)
                return BadRequest(result.Message);
            var detailsRouteResource = _mapper.Map<DetailsRoute, DetailsRouteResource>(result.DetailsRoute);
            return Ok(detailsRouteResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDetailsRouteResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var detailsRoute = _mapper.Map<SaveDetailsRouteResource, DetailsRoute>(resource);
            var result = await _detailsRouteService.UpdateAsync(id,detailsRoute);
            if (!result.Success)
                return BadRequest(result.Message);
            var detailsRouteResource = _mapper.Map<DetailsRoute, DetailsRouteResource>(result.DetailsRoute);
            return Ok(detailsRouteResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _detailsRouteService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var detailsRouteResource = _mapper.Map<DetailsRoute, DetailsRouteResource>(result.DetailsRoute);
            return Ok(detailsRouteResource);
        }
        
    }
}