namespace ViewModels.CourseContent.Sections
{
    public class SectionPostedVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
        public bool IsActive { get; set; }
    }
}
