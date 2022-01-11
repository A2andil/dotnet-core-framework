namespace ViewModels.CourseContent.Lectures
{
    public class LecturePostedVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VideoUrl { get; set; }
        public int Duration { get; set; }
        public int SectionId { get; set; }
        public int CourseId { get; set; }
        public bool IsActive { get; set; }
    }
}
