namespace ViewModels.Exams
{
    public class ExamPostedVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfQuestions { get; set; }
        public int TotalMarks { get; set; }
        public int TimeLimitedInMinutes { get; set; }
        public int CourseId { get; set; }
        public bool IsActive { get; set; }
    }
}
