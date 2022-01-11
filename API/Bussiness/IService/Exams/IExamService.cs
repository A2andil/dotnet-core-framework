using Bussiness.IService.Shared;
using Data.Models.Exams;
using ViewModels.Exams;

namespace Bussiness.IService.Exams
{
    public interface IExamService: IBaseService<Exam, ExamPostedVM, ExamPostedVM>
    {

    }
}
