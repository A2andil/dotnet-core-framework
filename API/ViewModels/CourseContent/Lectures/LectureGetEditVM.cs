using System.Collections.Generic;
using ViewModels.CourseContent.Courses;
using ViewModels.CourseContent.Sections;

namespace ViewModels.CourseContent.Lectures
{
    public class LectureGetEditVM
    {
        public LecturePostedVM PostedVM { get; set; }
        public List<CourseShortGridItemVM> Courses { get; set; }
        public List<SectionShortGridItemVM> Sections { get; set; }
    }
}
