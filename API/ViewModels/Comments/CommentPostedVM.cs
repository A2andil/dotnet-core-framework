namespace ViewModels.Comments
{
    public class CommentPostedVM
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int LectureId { get; set; }
        public bool IsActive { get; set; }
    }
}
