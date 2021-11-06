using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace UTaxi.API.Controllers
{
    [Route("/api/v1/[controller]")]
    public class RouteController : ControllerBase
    {
        private readonly IRouter _router;

        public RouteController(IRouter router)
        {
            _router = router;
        }
    }
}