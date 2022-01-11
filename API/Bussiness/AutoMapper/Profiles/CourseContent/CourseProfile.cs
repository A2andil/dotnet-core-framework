using AutoMapper;
using Data.Models.CourseContent;
using ViewModels.CourseContent.Courses;

namespace Bussiness.AutoMapper.Profiles.CourseContent
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseGridItemVM>().ReverseMap();

            CreateMap<Course, CoursePostedVM>().ReverseMap();

            CreateMap<Course, CourseShortGridItemVM>();
        }
    }
}
