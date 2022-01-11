using Data.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.CourseContent
{
    [Table("Section", Schema = "Courses")]
    public class Section : Audit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
