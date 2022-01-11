using Bussiness.IService.Shared;
using Data.Models.Comments;
using ViewModels.Comments;

namespace Bussiness.IService.Comments
{
    public interface ICommentService : IBaseService<Comment, CommentPostedVM, CommentPostedVM>
    {

    }
}
