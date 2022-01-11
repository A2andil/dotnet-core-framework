using AutoMapper.QueryableExtensions;
using Bussiness.IService.CourseContent;
using Bussiness.Services.Shared;
using Common.Shared.Interfaces;
using Data.Models.CourseContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.CourseContent.Courses;
using ViewModels.CourseContent.Lectures;
using ViewModels.CourseContent.Sections;
using ViewModels.Shared.Searching;

namespace Bussiness.Services.CourseContent
{
    public class LectureService : BaseService<Lecture>, ILectureService
    {
        public IResponse GetMany(SearchModelVM searchModel)
        {
            throw new NotImplementedException();
        }

        public IResponse Activate(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public IResponse Create(LecturePostedVM postedVM)
        {
            var checkResult = _unitOfWork.GetRepository<Lecture>()
                .Where(x => x.Name.Trim().ToLower().Equals(postedVM.Name.Trim().ToLower())).FirstOrDefault();

            if (checkResult == null)
            {
                postedVM.IsActive = true;
                var result = _unitOfWork.GetRepository<Lecture>().Add(_mapper.Map<Lecture>(postedVM));
                int ans = _unitOfWork.Complete();
                return ServiceResponse(ans > 0, ans > 0 ? "lecture Created Successfully" : "Can't Create This Successfully");
            }

            return ServiceResponse(false, "lecture added Before!");
        }

        public IResponse Delete(int? id)
        {
            var result = _unitOfWork.GetRepository<Lecture>().Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                _unitOfWork.GetRepository<Lecture>().Remove(result);
                int ans = _unitOfWork.Complete();
                return ServiceResponse(ans > 0, ans > 0 ? "Model Removed Successfully" : "Can Delete Vacation");
            }
            return ServiceResponse(false, "Model Removed Successfully");
        }

        public IResponse Update(LecturePostedVM postedVM)
        {
            var oldCity = _unitOfWork.GetRepository<Lecture>().FirstOrDefault(c => c.Id == postedVM.Id);

            postedVM.IsActive = oldCity.IsActive;
            _unitOfWork.GetRepository<Lecture>().Update(oldCity, _mapper.Map<Lecture>(postedVM));

            int ret = _unitOfWork.Complete();

            return ServiceResponse(ret > 0, postedVM);
        }

        public IResponse GetById(int? id)
        {
            LectureGetEditVM result = new LectureGetEditVM()
            {
                PostedVM = _mapper.Map<LecturePostedVM>(_unitOfWork.GetRepository<Lecture>().Where(x => x.Id == id).SingleOrDefault()),
                Courses = _unitOfWork.GetRepository<Course>()
                    .Where(x => x.UserId == _unitOfWork.CurrentUser.Id && x.IsActive)
                    .ProjectTo<CourseShortGridItemVM>(_mapConfig)
                    .ToList()
            };

            result.Sections = _unitOfWork.GetRepository<Section>()
                    .Where(x => x.IsActive && x.CourseId == result.PostedVM.Id)
                    .ProjectTo<SectionShortGridItemVM>(_mapConfig).ToList();

            return ServiceResponse(true, result);
        }

        public IResponse GetSectionsByCourse(int courseId)
        {
            var sectionsList = _unitOfWork.GetRepository<Section>()
                    .Where(x => x.IsActive && x.CourseId == courseId)
                    .ProjectTo<SectionShortGridItemVM>(_mapConfig).ToList();
            return ServiceResponse(true, sectionsList);
        }
    }
}
