using Bussiness.IService.Locations;
using Bussiness.Services.Shared;
using Common.Helpers.Linq;
using Common.Shared.Interfaces;
using Data.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitOfWork.UnitOfWork;
using ViewModels.Locations.Cities;
using ViewModels.Shared.Searching;

namespace Bussiness.Services.Locations
{
    public class CityService : BaseService<City>, ICityService
    {
        #region Constructor
        public CityService(IUnitOfWork unitOWork) : base(unitOWork)
        {
            // System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ar-Eg");
            // System.Threading.Thread.CurrentThread.CurrentCulture = ci;
        }
        #endregion

        #region Methods
        public IResponse GetMany(SearchModelVM searchModel)
        {
            try
            {
                var resultBeforeMapping = _unitOfWork.Cities.Include(x => x.Country)
                                                            .Where(x => x.IsActive)
                                                            .DynamicSearch(searchModel);

                CityListVM result = new CityListVM()
                {
                    Entities = _mapper.Map<List<CityListItemVM>>(resultBeforeMapping.Entities),
                    MetaData = resultBeforeMapping.MetaData
                };

                return ServiceResponse(true, result);
            }
            catch (Exception ex)
            {
                return ServiceResponse(false, null, "Failed to retrieve data");
            }
        }

        public IResponse Create(CityCreateVM createVM)
        {
            var firstOrDefault = _unitOfWork.Cities
                                  .FirstOrDefault(x => x.NameAr.Trim().ToLower().Equals(createVM.NameAr.Trim().ToLower())
                                                     || x.NameEn.Trim().ToLower().Equals(createVM.NameEn.Trim().ToLower()));

            if (firstOrDefault == null)
            {
                //createVM.IsActive = true;
                var mappedData = _mapper.Map<City>(createVM);

                var result = _unitOfWork.Cities.Add(_mapper.Map<City>(createVM));
                int ans = _unitOfWork.Complete();
                return ServiceResponse(ans > 0, ans > 0 ? "City Created Successfully" 
                                                        : "Can't Create This Successfully");
            }

            return ServiceResponse(false, "City added Before!");
        }

        public IResponse Delete(int? id)
        {
            var result = _unitOfWork.Cities.Find(id);
            if (result != null)
            {
                _unitOfWork.Cities.Remove(result);
                int ans = _unitOfWork.Complete();
                return ServiceResponse(ans > 0, ans > 0 ? "Model Removed Successfully" : "Can Delete Vacation");
            }
            return ServiceResponse(false, "Model Removed Successfully");
        }

        public IResponse Update(CityUpdateVM updateVM)
        {
            var oldCity = _unitOfWork.Cities.Find(updateVM.Id);
            _unitOfWork.Cities.Update(oldCity, _mapper.Map<City>(updateVM));

            int ret = _unitOfWork.Complete();

            return ServiceResponse(ret > 0, updateVM);
        }

        public IResponse GetById(int? id)
        {
            //IEnumerable<char> query = "Not what you might expect";
            //string vowels = "aeiou";
            //for (int i = 0; i < vowels.Length; i++)
            //    query = query.Where(c => c != vowels[i]);
            //foreach (char c in query) Console.Write(c);
            //return null;
            var result = _unitOfWork.Cities.FirstOrDefault(w => w.Id == id, j => j.Country);

            if (result == null)
                return ServiceResponse(false, null, "city is not found");

            return ServiceResponse(true, result);
        }

        public IResponse Activate(List<int> ids)
        {
            var result = _unitOfWork.Cities.Where(x => ids.Contains(x.Id)).ToList();

            for (int i = 0; i < result.Count; i++)
                result[i].IsActive = !result[i].IsActive;

            int complete = _unitOfWork.Complete();

            return ServiceResponse(complete > 0, result);
        }
        #endregion
    }
}
