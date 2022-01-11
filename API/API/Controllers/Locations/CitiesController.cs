using AutoMapper.Configuration;
using Bussiness.IService.Locations;
using Bussiness.Services.Locations;
using Common.Helpers.Files;
using Common.Helpers.NCalc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UnitOfWork.UnitOfWork;
using ViewModels.Locations.Cities;
using ViewModels.Shared.Searching;

namespace API.Controllers
{
    public class CitiesController : SharedController<CityCreateVM, CityUpdateVM>
    {
        #region Services
        private readonly ICityService _service;
        #endregion

        #region Constructor
        public CitiesController(IUnitOfWork unitOfWork)
        {
            _service = new CityService(unitOfWork);
            // new ManageFiles().UploadFile()
        }
        #endregion

        #region Methods
        [AllowAnonymous]
        public override IActionResult GetById(int id)
        {
            //string xvx = NCalcHelper.CalulateEquation("5*2+1");
            // var xvx = NCalcHelper.CalculateEquation("Sin(30)");
            //xvx = NCalcHelper.CalculateFunction("Sum(1, 2, 4 , 5)");
            //const string exp = @"(Person.Age > 3 AND Person.Weight > 50) OR Person.Age < {0}";
            //var p = Expression.Parameter(typeof(CitiesController), "Person");
            //var e = System.Linq.Dynamic.Core.DynamicExpressionParser.ParseLambda(new[] { p }, null, exp, 3);
            return Ok(_service.GetById(id));
        }

        [AllowAnonymous]
        public override IActionResult GetMany(SearchModelVM searchModel)
        {
            return Ok(_service.GetMany(searchModel));
        }
        [AllowAnonymous]
        public override IActionResult Create([FromBody] CityCreateVM addVM)
        {
            return Ok(_service.Create(addVM));
        }

        public override IActionResult Edit([FromBody] CityUpdateVM updateVM)
        {
            return Ok(_service.Update(updateVM));
        }

        public override IActionResult Delete(int id)
        {
            return Ok(_service.Delete(id));
        }

        public override IActionResult Activate([FromBody] List<int> ids)
        {
            return Ok(_service.Activate(ids));
        }
        #endregion
    }
}
