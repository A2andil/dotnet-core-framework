using Bussiness.IService.Locations;
using Bussiness.Services.Shared;
using Common.Shared.Interfaces;
using Data.Models.Locations;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using UnitOfWork.UnitOfWork;
using ViewModels.Locations.Countries;
using ViewModels.Shared.Searching;

namespace Bussiness.Services.Locations
{
    public class CountryService : BaseService<Country>, ICountryService
    {
        #region Services
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public CountryService(IUnitOfWork unitOWork, IConfiguration configuration) : base(unitOWork)
        {
            _configuration = configuration;
        }
        #endregion

        #region Methods
        public IResponse GetMany(SearchModelVM searchModel)
        {
            throw new System.NotImplementedException();
        }

        public IResponse Create(CountryCreateVM createVM)
        {
            var checkResult = _unitOfWork.GetRepository<Country>()
                .Where(x => x.NameAr.Trim().ToLower().Equals(createVM.NameAr.Trim().ToLower())
                || x.NameEn.Trim().ToLower().Equals(createVM.NameEn.Trim().ToLower())).FirstOrDefault();
            if (checkResult == null)
            {
                createVM.IsActive = true;
                var result = _unitOfWork.GetRepository<Country>().Add(_mapper.Map<Country>(createVM));
                int ans = _unitOfWork.Complete();
                return ServiceResponse(ans > 0, ans > 0 ? "Country Created Successfully" : "Can't Create This Successfully");
            }
            return ServiceResponse(false, "Country added Before!");
        }

        public IResponse Delete(int? id)
        {
            var result = _unitOfWork.GetRepository<Country>().Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                _unitOfWork.GetRepository<Country>().Remove(result);
                int ans = _unitOfWork.Complete();
                return ServiceResponse(ans > 0, ans > 0 ? "Model Removed Successfully" : "Can Delete Vacation");
            }
            return ServiceResponse(false, "Model Removed Successfully");
        }

        public IResponse Update(CountryUpdateVM updateVM)
        {
            var oldCountry = _unitOfWork.GetRepository<Country>()
               .FirstOrDefault(c => c.Id == updateVM.Id);
            updateVM.IsActive = oldCountry.IsActive;

            _unitOfWork.GetRepository<Country>().Update(oldCountry, _mapper.Map<Country>(updateVM));

            int ret = _unitOfWork.Complete();

            return ServiceResponse(ret > 0, updateVM);
        }

        public IResponse GetById(int? id)
        {
            var result = _unitOfWork.GetRepository<Country>().Where(x => x.Id == id).SingleOrDefault();
            return ServiceResponse(result != null, result);
        }

        public IResponse Activate(List<int> ids)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
