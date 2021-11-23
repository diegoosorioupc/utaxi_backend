using AutoMapper;
using UTaxi.API.Domain.Models;
using UTaxi.API.Resources;

namespace UTaxi.API.Mapping
{
    public class ModelToProfile : Profile
    {
        public ModelToProfile()
        {
            CreateMap<Driver, DriverResource>();
            CreateMap<Student, StudentResource>();
            CreateMap<Route,RouteResource>();
            CreateMap<Taxi,TaxiResource>();
            CreateMap<Payment,PaymentResource>();
            CreateMap<DetailsRoute,DetailsRouteResource>();
            CreateMap<StudentRoute,StudentRouteResource>();
        }
    }
}