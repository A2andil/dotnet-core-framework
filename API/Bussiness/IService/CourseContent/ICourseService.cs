using Bussiness.IService.Shared;
using Data.Models.CourseContent;
using ViewModels.CourseContent.Courses;

namespace Bussiness.IService.CourseContent
{
    public interface ICourseService : IBaseService<Course, CoursePostedVM, CoursePostedVM>
    {

    }
}
