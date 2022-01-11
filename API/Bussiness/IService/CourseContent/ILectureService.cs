using Bussiness.IService.Shared;
using Common.Shared.Interfaces;
using Data.Models.CourseContent;
using ViewModels.CourseContent.Lectures;

namespace Bussiness.IService.CourseContent
{
    public interface ILectureService : IBaseService<Lecture, LecturePostedVM, LecturePostedVM>
    {
        IResponse GetSectionsByCourse(int courseId);
    }
}
