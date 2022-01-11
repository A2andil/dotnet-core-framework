using Bussiness.IService.Security;
using Bussiness.Services.Shared;
using Common.Helpers.Token;
using Common.Shared.Interfaces;
using Data.Models.Security;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using ViewModels.Users;
using Microsoft.Extensions.Configuration;
using Common.Classes;
using ViewModels.Shared.Searching;
using UnitOfWork.UnitOfWork;

namespace Bussiness.Services.Security
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IUnitOfWork unitOWork, IConfiguration configuration) : base(unitOWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public IResponse GetMany(SearchModelVM searchModel)
        {
            throw new NotImplementedException();
        }

        public IResponse Create(UserPostedVM postedVM)
        {
            throw new System.NotImplementedException();
        }

        public IResponse Delete(int? id)
        {
            throw new System.NotImplementedException();
        }

        public IResponse Update(UserPostedVM postedVM)
        {
            throw new System.NotImplementedException();
        }

        public IResponse GetById(int? id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IResponse> LoginAsync(UserLoginVM postedVM)
        {
            var user = await _userManager.FindByEmailAsync(postedVM.Email);
            //user roles contains rols
            if (user != null && await _userManager.CheckPasswordAsync(user, postedVM.Password) 
                && (await _userManager.GetRolesAsync(user)).Contains(UserRoles.User))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var claims = new List<Claim>
                {
                    new Claim("FullName", user.FullName),
                    new Claim("Id", user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                for (int i = 0; i < userRoles.Count; i++)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRoles[i]));
                }

                string token = JWTHelper.GenerateJwtToken(claims, _configuration["JWT:Secret"],
                    _configuration["JWT:ValidIssuer"], _configuration["JWT:ValidAudience"], 24);

                return ServiceResponse(true, token);
            }
            return ServiceResponse(false, "username or password is not valid!");
        }

        public IResponse Activate(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
