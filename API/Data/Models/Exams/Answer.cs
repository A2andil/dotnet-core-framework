using Data.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.Exams
{
    [Table("Answer", Schema = "Exams")]
    public class Answer : Audit
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool? TrueOrFalse { get; set; }
        public int OptionId { get; set; }
        public virtual Option Option { get; set; }
    }
}
