using Data.Models.Security;
using Data.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.CourseContent
{
    [Table("Course", Schema = "Courses")]
    public class Course : Audit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string PictureUrl { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
