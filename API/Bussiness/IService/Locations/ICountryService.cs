using Bussiness.IService.Shared;
using Data.Models.Locations;
using ViewModels.Locations.Countries;

namespace Bussiness.IService.Locations
{
    public interface ICountryService : IBaseService<Country, CountryCreateVM, CountryUpdateVM>
    {

    }
}
