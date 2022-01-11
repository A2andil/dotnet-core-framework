using AutoMapper;
using Data.Models.CourseContent;
using ViewModels.CourseContent.Lectures;

namespace Bussiness.AutoMapper.Profiles.CourseContent
{
    public class LectureProfile : Profile
    {
        public LectureProfile()
        {
            CreateMap<Lecture, LecturePostedVM>().ReverseMap();
        }
    }
}
