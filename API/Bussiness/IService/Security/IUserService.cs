using Bussiness.IService.Shared;
using Common.Shared.Interfaces;
using Data.Models.Security;
using System.Threading.Tasks;
using ViewModels.Users;

namespace Bussiness.IService.Security
{
    public interface IUserService : IBaseService<User, UserPostedVM, UserPostedVM>
    {
        Task<IResponse> LoginAsync(UserLoginVM postedVM);
    }
}
