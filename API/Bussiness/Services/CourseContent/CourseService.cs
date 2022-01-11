using Bussiness.IService.CourseContent;
using Bussiness.Services.Shared;
using Common.Shared.Interfaces;
using Data.Models.CourseContent;
using ViewModels.CourseContent.Courses;
using Microsoft.Extensions.Configuration;
using System.Linq;
using ViewModels.Shared.Searching;
using System.Collections.Generic;
using UnitOfWork.UnitOfWork;

namespace Bussiness.Services.CourseContent
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        private readonly IConfiguration _configuration;
        public CourseService(IUnitOfWork unitOWork, IConfiguration configuration) : base(unitOWork)
        {
            _configuration = configuration;
        }

        public IResponse GetMany(SearchModelVM searchModel)
        {
            throw new System.NotImplementedException();
        }

        public IResponse Create(CoursePostedVM postedVM)
        {
            var checkResult = _unitOfWork.GetRepository<Course>()
                .Where(x => x.Name.Trim().ToLower().Equals(postedVM.Name.Trim().ToLower())).FirstOrDefault();

            if (checkResult == null)
            {
                postedVM.IsActive = true;
                var result = _unitOfWork.GetRepository<Course>().Add(_mapper.Map<Course>(postedVM));
                int ans = _unitOfWork.Complete();
                return ServiceResponse(ans > 0, ans > 0 ? "Course Created Successfully" : "Can't Create This Successfully");
            }

            return ServiceResponse(false, "Course added Before!");
        }

        public IResponse Delete(int? id)
        {
            var result = _unitOfWork.GetRepository<Course>().Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                _unitOfWork.GetRepository<Course>().Remove(result);
                int ans = _unitOfWork.Complete();
                return ServiceResponse(ans > 0, ans > 0 ? "Model Removed Successfully" : "Can Delete Vacation");
            }
            return ServiceResponse(false, "Model Removed Successfully");
        }

        public IResponse Update(CoursePostedVM postedVM)
        {
            var oldCourse = _unitOfWork.GetRepository<Course>().FirstOrDefault(c => c.Id == postedVM.Id);

            postedVM.IsActive = oldCourse.IsActive;
            _unitOfWork.GetRepository<Course>().Update(oldCourse, _mapper.Map<Course>(postedVM));

            int ret = _unitOfWork.Complete();

            return ServiceResponse(ret > 0, postedVM);
        }

        public IResponse GetById(int? id)
        {
            var result = _unitOfWork.GetRepository<Course>().Where(x => x.Id == id).SingleOrDefault();
            return ServiceResponse(result != null, result);
        }

        public IResponse Activate(List<int> ids)
        {
            throw new System.NotImplementedException();
        }
    }
}
