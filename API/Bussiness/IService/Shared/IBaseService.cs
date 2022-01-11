using Common.Shared.Interfaces;
using System.Collections.Generic;
using ViewModels.Shared.Searching;

namespace Bussiness.IService.Shared
{
    public interface IBaseService<TEntity, TCreateVM, TUpdate> where TEntity : class
    {
        IResponse GetMany(SearchModelVM searchModel);
        IResponse Create(TCreateVM postedVM);
        IResponse GetById(int? id);
        IResponse Update(TUpdate postedVM);
        IResponse Delete(int? id);
        IResponse Activate(List<int> ids);
    }
}
