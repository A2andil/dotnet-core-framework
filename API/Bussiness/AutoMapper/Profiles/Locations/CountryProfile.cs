using AutoMapper;
using Common.Enums;
using Common.Helpers.Languages;
using Data.Models.Locations;
using ViewModels.Locations.Countries;

namespace Bussiness.AutoMapper.Profiles.Locations
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryUpdateVM>().ReverseMap();

            CreateMap<Country, CountryCreateVM>().ReverseMap();


            CreateMap<Country, CountryGridItemVM>()
                .ForMember(dest => dest.Name, opt => 
                    opt.MapFrom(src => LanguageHelper.GetCurrentLanguage == CultureCode.en.AsString()? src.NameEn : src.NameAr));
        }
    }
}
