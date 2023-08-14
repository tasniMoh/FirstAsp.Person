using AutoMapper;
using FirstAspPerson.Models;
using FirstAspPerson.ModelsDTO;
using System.Diagnostics.Metrics;

namespace FirstAspPerson.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Person, CreatePersonDTO>().ReverseMap();
            CreateMap<Image, ImageDTO>().ReverseMap();
            CreateMap<Image, CreateImageDTO>().ReverseMap();
        }
    }
}
