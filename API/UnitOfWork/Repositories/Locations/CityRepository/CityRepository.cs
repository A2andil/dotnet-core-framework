using Data.Context;
using UnitOfWork.Repositories.Locations.City;

namespace UnitOfWork.Repositories.Locations.CityRepository
{
    public class CityRepository : Repository<ApplicationDbContext, Data.Models.Locations.City>, ICityRepository
    {
        public CityRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
