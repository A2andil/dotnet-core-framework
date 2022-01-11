using Bussiness.IService.Exams;
using Bussiness.Services.Shared;
using Common.Shared.Interfaces;
using Data.Models.Exams;
using System.Collections.Generic;
using System.Linq;
using ViewModels.Exams.Questions;
using ViewModels.Shared.Searching;

namespace Bussiness.Services.Exams
{
    public class QuestionService : BaseService<Question>, IQuestionService
    {
        public IResponse GetMany(SearchModelVM searchModel)
        {
            throw new System.NotImplementedException();
        }

        public IResponse Create(QuestionPostedVM postedVM)
        {
            var checkResult = _unitOfWork.GetRepository<Question>().FirstOrDefault();

            if (checkResult == null)
            {
                postedVM.IsActive = true;
                var result = _unitOfWork.GetRepository<Question>().Add(_mapper.Map<Question>(postedVM));
                int ans = _unitOfWork.Complete();
                return ServiceResponse(ans > 0, ans > 0 ? "question Created Successfully" : "Can't Create This Successfully");
            }

            return ServiceResponse(false, "Question added Before!");
        }

        public IResponse Delete(int? id)
        {
            var result = _unitOfWork.GetRepository<Question>().Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                //delete parent
                _unitOfWork.GetRepository<Question>().Remove(result);
                int ans = _unitOfWork.Complete();
                return ServiceResponse(ans > 0, ans > 0 ? "Model Removed Successfully" : "Can not Delete Question");
            }
            return ServiceResponse(false, "Model Removed Successfully");
        }

        public IResponse Update(QuestionPostedVM postedVM)
        {
            var oldQuestion = _unitOfWork.GetRepository<Question>().FirstOrDefault(c => c.Id == postedVM.Id);

            postedVM.IsActive = oldQuestion.IsActive;
            _unitOfWork.GetRepository<Question>().Update(oldQuestion, _mapper.Map<Question>(postedVM));

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
