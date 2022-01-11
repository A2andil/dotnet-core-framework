using AutoMapper;
using Common.Helpers.Reflection;
using Data.Models.Locations;
using ViewModels.Locations.Cities;

namespace Bussiness.AutoMapper.Profiles.Locations
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityUpdateVM>().ReverseMap();

            CreateMap<City, CityCreateVM>().ReverseMap();

            CreateMap<City, CityListItemVM>()
                .ForMember(dest => dest.Name,
                            opt => opt.MapFrom(src => ReflectionHelper.GetTranslatedProperty(src, "Name")))
                .ForMember(dest => dest.CountryName, 
                            opt => opt.MapFrom(src => ReflectionHelper.GetTranslatedProperty(src.Country, "Name")));
        }
    }
}
