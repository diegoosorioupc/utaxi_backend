using AutoMapper;
using UTaxi.API.Domain.Models;
using UTaxi.API.Resources;

namespace UTaxi.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveDriverResource, Driver>();
            CreateMap<SaveStudentResource, Student>();
            CreateMap<SaveRouteResource, Route>();
            CreateMap<SaveTaxiResource, Taxi>();
            CreateMap<SaveDetailsRouteResource, DetailsRoute>();
            CreateMap<SaveStudentRouteResource, StudentRoute>();
            CreateMap<SavePaymentResource, Payment>();
        }
    }
}