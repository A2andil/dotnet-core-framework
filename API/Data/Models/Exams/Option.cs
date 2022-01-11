using Data.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.Exams
{
    [Table("Option", Schema = "Exams")]
    public class Option : Audit
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
