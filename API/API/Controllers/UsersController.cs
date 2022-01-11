using Bussiness.IService.Locations;
using Common.Classes;
using Common.Shared.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using UnitOfWork.UnitOfWork;
using ViewModels.Exams.Answers;
using ViewModels.Shared.Searching;
using ViewModels.Users;

namespace API.Controllers
{
    [Route("api/master-data/[controller]")]
    [Authorize(Roles = UserRoles.User)]
    public class UsersController : SharedController<AnswerPostedVM, AnswerPostedVM>
    {
        private readonly IConfiguration _configuration;
        private readonly ICityService _cityService;
        public UsersController(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            //_cityService = new CityService(unitOfWork, configuration);
            var xvx = unitOfWork;
        }

        //[HttpPost]
        //[Route(UserActions.Login)]
        //[AllowAnonymous]
        //public IActionResult Login([FromBody] LoginModel model)
        //{
        //    return Ok(new { Message = "Logged Successfully" });
        //}

        [HttpGet]
        [AllowAnonymous]
        [Route(UserActions.Register)]
        public IActionResult Register([FromQuery] RegisterModel model)
        {
            return Ok(new { Message = "Register Successfully" });
        }

        [HttpGet]
        [Route(UserActions.ForgetPassword)]
        public IActionResult ForgetPassword(string email)
        {
            return Ok(new Response()
            {
                IsSuccess = true,
                Message = "Send Message Successfully",
                Data = "",
                AdditionalInfo = ""
            });
        }

        [AllowAnonymous]
        public override IActionResult GetById(int id)
        {
            return Ok(_cityService.GetById(id));
        }

        public override IActionResult GetMany([FromBody] SearchModelVM searchModel)
        {
            throw new System.NotImplementedException();
        }

        public override IActionResult Create([FromBody] AnswerPostedVM addVM)
        {
            throw new System.NotImplementedException();
        }

        public override IActionResult Edit([FromBody] AnswerPostedVM updateVM)
        {
            throw new System.NotImplementedException();
        }

        public override IActionResult Activate([FromBody] List<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public override IActionResult Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        //[HttpPost]
        //[Route(UserActions.ChangePassword)]
        //public IActionResult ChangePassword(ChangePasswordModel model)
        //{
        //    return Ok(new Response()
        //    {
        //        IsSuccess = true,
        //        Message = "Send Message Successfully",
        //        Data = "",
        //        AdditionalInfo = ""
        //    });
        //}
    }
}
