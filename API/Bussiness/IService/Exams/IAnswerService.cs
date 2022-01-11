using Bussiness.IService.Shared;
using Data.Models.Exams;
using ViewModels.Exams.Answers;

namespace Bussiness.IService.Exams
{
    public interface IAnswerService: IBaseService<Answer, AnswerPostedVM, AnswerPostedVM>
    {

    }
}
