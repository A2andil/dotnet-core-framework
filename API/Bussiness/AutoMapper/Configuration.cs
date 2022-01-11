using AutoMapper;
using Bussiness.AutoMapper.Profiles.Comments;
using Bussiness.AutoMapper.Profiles.CourseContent;
using Bussiness.AutoMapper.Profiles.Exams;
using Bussiness.AutoMapper.Profiles.Locations;

namespace Bussiness.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Mapper;

        public static void Configure()
        {
            MapperConfiguration configuration = new MapperConfiguration(cfg =>
            {
                #region Location
                cfg.AddProfile<CountryProfile>();
                cfg.AddProfile<CityProfile>();
                #endregion

                #region Course Content
                cfg.AddProfile<CourseProfile>();
                cfg.AddProfile<SectionProfile>();
                cfg.AddProfile<LectureProfile>();
                #endregion

                #region Comments
                cfg.AddProfile<CommentProfile>();
                #endregion

                #region Exams
                cfg.AddProfile<ExamProfile>();
                #endregion

            });

            Mapper = configuration.CreateMapper();
        }
    }
}
