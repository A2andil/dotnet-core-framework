using Bussiness.IService.Shared;
using Data.Models.Locations;
using ViewModels.Locations.Cities;

namespace Bussiness.IService.Locations
{
    public interface ICityService : IBaseService<City, CityCreateVM, CityUpdateVM>
    {

    }
}
