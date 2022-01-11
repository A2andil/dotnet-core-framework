using Bussiness.IService.Exams;
using Bussiness.Services.Shared;
using Common.Shared.Interfaces;
using Data.Models.Exams;
using System.Collections.Generic;
using System.Linq;
using ViewModels.Exams.Answers;
using ViewModels.Shared.Searching;

namespace Bussiness.Services.Exams
{
    public class AnswerService : BaseService<Answer>, IAnswerService
    {
        public IResponse GetMany(SearchModelVM searchModel)
        {
            throw new System.NotImplementedException();
        }

        public IResponse Create(AnswerPostedVM postedVM)
        {
            var checkResult = _unitOfWork.GetRepository<Answer>().FirstOrDefault();

            if (checkResult == null)
            {
                postedVM.IsActive = true;
                var result = _unitOfWork.GetRepository<Answer>().Add(_mapper.Map<Answer>(postedVM));
                int ans = _unitOfWork.Complete();
                return ServiceResponse(ans > 0, ans > 0 ? "answer Created Successfully" : "Can't Create This Successfully");
            }

            return ServiceResponse(false, "Answer added Before!");
        }

        public IResponse Delete(int? id)
        {
            var result = _unitOfWork.GetRepository<Answer>().Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                _unitOfWork.GetRepository<Answer>().Remove(result);
                int ans = _unitOfWork.Complete();
                return ServiceResponse(ans > 0, ans > 0 ? "Model Removed Successfully" : "Can not Delete answer");
            }
            return ServiceResponse(false, "Model Removed Successfully");
        }

        public IResponse Update(AnswerPostedVM postedVM)
        {
            var oldAnswer = _unitOfWork.GetRepository<Answer>().FirstOrDefault(c => c.Id == postedVM.Id);

            postedVM.IsActive = oldAnswer.IsActive;
            _unitOfWork.GetRepository<Answer>().Update(oldAnswer, _mapper.Map<Answer>(postedVM));

            int ret = _unitOfWork.Complete();

            return ServiceResponse(ret > 0, postedVM);
        }

        public IResponse GetById(int? id)
        {
            throw new System.NotImplementedException();
        }

        public IResponse Activate(List<int> ids)
        {
            throw new System.NotImplementedException();
        }
    }
}
