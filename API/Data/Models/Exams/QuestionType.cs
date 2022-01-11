using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.Exams
{
    [Table("QuestionType", Schema = "Exams")]
    public class QuestionType
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
    }
}
