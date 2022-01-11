using System.Collections.Generic;
using ViewModels.Shared.Pagination;

namespace ViewModels.Locations.Cities
{
    public class CityListVM
    {
        public List<CityListItemVM> Entities { get; set; }
        public PaginationMetaData MetaData { get; set; }
    }
}
