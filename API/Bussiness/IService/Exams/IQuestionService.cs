using Bussiness.IService.Shared;
using Data.Models.Exams;
using ViewModels.Exams.Questions;

namespace Bussiness.IService.Exams
{
    public interface IQuestionService : IBaseService<Question, QuestionPostedVM, QuestionPostedVM>
    {

    }
}
