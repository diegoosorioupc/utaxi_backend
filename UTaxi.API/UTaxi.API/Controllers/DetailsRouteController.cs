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
    public class DetailsRouteController :ControllerBase
    {
        private readonly IDetailsRouteService _detailsRouteService;
        private readonly IMapper _mapper;

        public DetailsRouteController(IDetailsRouteService detailsRouteService, IMapper mapper)
        {
            _detailsRouteService = detailsRouteService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DetailsRouteResource>> GetAllAsync()
        {
            var details = await _detailsRouteService.ListAsync();
            var resources = _mapper.Map<IEnumerable<DetailsRoute>, IEnumerable<DetailsRouteResource>>(details);
            return resources;
        }
    }
}