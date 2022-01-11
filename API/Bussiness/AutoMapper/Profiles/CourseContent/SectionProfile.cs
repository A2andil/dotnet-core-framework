using AutoMapper;
using Data.Models.CourseContent;
using ViewModels.CourseContent.Courses;
using ViewModels.CourseContent.Sections;

namespace Bussiness.AutoMapper.Profiles.CourseContent
{
    class SectionProfile : Profile
    {
        public SectionProfile()
        {
            CreateMap<Section, SectionPostedVM>().ReverseMap();

            CreateMap<Course, CourseShortGridItemVM>();
        }
    }
}
