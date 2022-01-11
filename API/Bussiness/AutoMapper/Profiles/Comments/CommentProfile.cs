using AutoMapper;
using Data.Models.Comments;
using ViewModels.Comments;

namespace Bussiness.AutoMapper.Profiles.Comments
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentPostedVM>().ReverseMap();
        }
    }
}
