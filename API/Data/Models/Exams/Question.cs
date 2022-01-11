using Data.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.Exams
{
    [Table("Question", Schema = "Exams")]
    public class Question : Audit
    {
        public int Id { get; set; }
        public string QuestionBody { get; set; }
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public int QuestionTypeId { get; set; }
        public virtual QuestionType QuestionType { get; set; }
        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
