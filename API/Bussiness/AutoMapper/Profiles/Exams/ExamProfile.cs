using AutoMapper;
using Data.Models.Exams;
using ViewModels.Exams;

namespace Bussiness.AutoMapper.Profiles.Exams
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<Exam, ExamPostedVM>();
        }
    }
}
