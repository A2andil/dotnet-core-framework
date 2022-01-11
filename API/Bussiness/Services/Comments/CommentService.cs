using Bussiness.IService.Comments;
using Bussiness.Services.Shared;
using Common.Shared.Interfaces;
using Data.Models.Comments;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Comments;
using ViewModels.Shared.Searching;

namespace Bussiness.Services.Comments
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        public IResponse GetMany(SearchModelVM searchModel)
        {
            throw new System.NotImplementedException();
        }

        public IResponse Create(CommentPostedVM postedVM)
        {
            var checkResult = _unitOfWork.GetRepository<Comment>().FirstOrDefault();

            if (checkResult == null)
            {
                postedVM.IsActive = true;
                var result = _unitOfWork.GetRepository<Comment>().Add(_mapper.Map<Comment>(postedVM));
                int ans = _unitOfWork.Complete();
                return ServiceResponse(ans > 0, ans > 0 ? "Comment Created Successfully" : "Can't Create This Successfully");
            }

            return ServiceResponse(false, "Comment added Before!");
        }

        public IResponse Delete(int? id)
        {
            var result = _unitOfWork.GetRepository<Comment>().Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                //delete all childs
                var chidList = _unitOfWork.GetRepository<Comment>().Where(x => x.ParentId == id).ToList();
                for (int i = 0; i < chidList.Count; i++)
                    _unitOfWork.GetRepository<Comment>().Remove(chidList[i]);

                //delete parent
                _unitOfWork.GetRepository<Comment>().Remove(result);
                int ans = _unitOfWork.Complete();
                return ServiceResponse(ans > 0, ans > 0 ? "Model Removed Successfully" : "Can Delete Vacation");
            }
            return ServiceResponse(false, "Model Removed Successfully");
        }

        public IResponse Update(CommentPostedVM postedVM)
        {
            var oldComment = _unitOfWork.GetRepository<Comment>().FirstOrDefault(c => c.Id == postedVM.Id);

            postedVM.IsActive = oldComment.IsActive;
            _unitOfWork.GetRepository<Comment>().Update(oldComment, _mapper.Map<Comment>(postedVM));

            int ret = _unitOfWork.Complete();

            return ServiceResponse(ret > 0, postedVM);
        }

        public IResponse GetById(int? id)
        {
            var result = _unitOfWork.GetRepository<Comment>().Where(x => x.Id == id).SingleOrDefault();
            return ServiceResponse(result != null, result);
        }

        public IResponse Activate(List<int> ids)
        {
            throw new System.NotImplementedException();
        }
    }
}
