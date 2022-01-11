using Bussiness.IService.Exams;
using Bussiness.Services.Shared;
using Common.Shared.Interfaces;
using Data.Models.Exams;
using System.Collections.Generic;
using System.Linq;
using ViewModels.Exams;
using ViewModels.Shared.Searching;

namespace Bussiness.AutoMapper.Profiles.Exams
{
    public class ExamService : BaseService<Exam>, IExamService
    {
        public IResponse GetMany(SearchModelVM searchModel)
        {
            throw new System.NotImplementedException();
        }

        public IResponse Activate(int id)
        {
            var exam = _unitOfWork.GetRepository<Exam>().Where(x => x.Id == id).SingleOrDefault();
            if (exam != null)
            {
                exam.IsActive = !exam.IsActive;
                int ans = _unitOfWork.Complete();
                return ServiceResponse(ans > 0, ans > 0 ? "Changed Successfully" : "Can't Change This status");
            }
            return ServiceResponse(false, "this exam is not found");
        }

        public IResponse Activate(List<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public IResponse Create(ExamPostedVM postedVM)
        {
            var checkResult = _unitOfWork.GetRepository<Exam>().FirstOrDefault();

            if (checkResult == null)
            {
                postedVM.IsActive = true;
                var result = _unitOfWork.GetRepository<Exam>().Add(_mapper.Map<Exam>(postedVM));
                int ans = _unitOfWork.Complete();
                return ServiceResponse(ans > 0, ans > 0 ? "Exam Created Successfully" : "Can't Create This Successfully");
            }

            return ServiceResponse(false, "Exam added Before!");
        }

        public IResponse Delete(int? id)
        {
            var result = _unitOfWork.GetRepository<Exam>().Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                //delete parent
                _unitOfWork.GetRepository<Exam>().Remove(result);
                int ans = _unitOfWork.Complete();
                return ServiceResponse(ans > 0, ans > 0 ? "Model Removed Successfully" : "Can Delete Exam");
            }
            return ServiceResponse(false, "Model Removed Successfully");
        }

        public IResponse Update(ExamPostedVM postedVM)
        {
            var oldExam = _unitOfWork.GetRepository<Exam>().FirstOrDefault(c => c.Id == postedVM.Id);

            postedVM.IsActive = oldExam.IsActive;
            _unitOfWork.GetRepository<Exam>().Update(oldExam, _mapper.Map<Exam>(postedVM));

            int ret = _unitOfWork.Complete();

            return ServiceResponse(ret > 0, postedVM);
        }

        public IResponse GetById(int? id)
        {
            var result = _unitOfWork.GetRepository<Exam>().Where(x => x.Id == id).SingleOrDefault();
            return ServiceResponse(result != null, result);
        }
    }
}
