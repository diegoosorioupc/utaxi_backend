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
        }
    }
}