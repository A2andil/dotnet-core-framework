using Data.Models.CourseContent;
using Data.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.Exams
{
    [Table("Exam", Schema = "Exams")]
    public class Exam : Audit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfQuestions { get; set; }
        public int TotalMarks { get; set; }
        public int TimeLimitedInMinutes { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
