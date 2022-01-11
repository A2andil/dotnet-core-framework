using Data.Models.CourseContent;
using Data.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.Comments
{
    [Table("Comment", Schema = "Comments")]
    public class Comment : Audit
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int LectureId { get; set; }
        public int? ParentId { get; set; }
        public virtual Lecture Lecture { get; set; }
    }
}
