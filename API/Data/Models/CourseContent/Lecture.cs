using Data.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.CourseContent
{
    [Table("Lecture", Schema = "Courses")]
    public class Lecture : Audit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VideoUrl { get; set; }
        public int Duration { get; set; }
        public int SectionId { get; set; }
        public int CourseId { get; set; }
    }
}
