using Bussiness.IService.CourseContent;
using Bussiness.Services.Shared;
using Common.Shared.Interfaces;
using Data.Models.CourseContent;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using UnitOfWork.UnitOfWork;
using ViewModels.CourseContent.Sections;
using ViewModels.Shared.Searching;

namespace Bussiness.Services.CourseContent
{
    public class SectionService : BaseService<Section>, ISectionService
    {
        private readonly IConfiguration _configuration;
        public SectionService(IUnitOfWork unitOWork, IConfiguration configuration) : base(unitOWork)
        {
            _configuration = configuration;
        }

        public IResponse GetMany(SearchModelVM searchModel)
        {
            throw new System.NotImplementedException();
        }

        public IResponse Create(SectionPostedVM postedVM)
        {
            var checkResult = _unitOfWork.GetRepository<Section>()
                .Where(x => x.Name.Trim().ToLower().Equals(postedVM.Name.Trim().ToLower())).FirstOrDefault();

            if (checkResult == null)
            {
                postedVM.IsActive = true;
                var result = _unitOfWork.GetRepository<Section>().Add(_mapper.Map<Section>(postedVM));
                int ans = _unitOfWork.Complete();
                return ServiceResponse(ans > 0, ans > 0 ? "section Created Successfully" : "Can't Create This Successfully");
            }

            return ServiceResponse(false, "section added Before!");
        }

        public IResponse Delete(int? id)
        {
            var result = _unitOfWork.GetRepository<Section>().Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                _unitOfWork.GetRepository<Section>().Remove(result);
                int ans = _unitOfWork.Complete();
                return ServiceResponse(ans > 0, ans > 0 ? "Model Removed Successfully" : "Can Delete Vacation");
            }
            return ServiceResponse(false, "Model Removed Successfully");
        }

        public IResponse Update(SectionPostedVM postedVM)
        {
            var oldSection = _unitOfWork.GetRepository<Section>().FirstOrDefault(c => c.Id == postedVM.Id);

            postedVM.IsActive = oldSection.IsActive;
            _unitOfWork.GetRepository<Section>().Update(oldSection, _mapper.Map<Section>(postedVM));

            int ret = _unitOfWork.Complete();

            return ServiceResponse(ret > 0, postedVM);
        }

        public IResponse GetById(int? id)
        {
            var result = _mapper.Map<SectionPostedVM>(_unitOfWork.GetRepository<Section>().Where(x => x.Id == id).FirstOrDefault());
            return ServiceResponse(result != null, result);
        }

        public IResponse Activate(List<int> ids)
        {
            throw new System.NotImplementedException();
        }
    }
}
