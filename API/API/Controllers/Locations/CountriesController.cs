using Bussiness.IService.Locations;
using Bussiness.Services.Locations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using UnitOfWork.UnitOfWork;
using ViewModels.Locations.Countries;
using ViewModels.Shared.Searching;

namespace API.Controllers
{
    class country
    {
        public string Name { get; set; }
        public int Code { get; set; }
    }
    public class CountriesController : SharedController<CountryCreateVM, CountryUpdateVM>
    {
        #region Services
        private readonly IConfiguration _configuration;
        private readonly ICountryService _service;
        #endregion

        #region Constructor
        public CountriesController(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _service = new CountryService(unitOfWork, configuration);
        }
        #endregion

        #region Methods
        [AllowAnonymous]
        public override IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [AllowAnonymous]
        public override IActionResult GetMany([FromBody] SearchModelVM searchModel)
        {
            return Ok(_service.GetMany(searchModel));
        }

        [AllowAnonymous]
        public override IActionResult Create([FromBody] CountryCreateVM createVM)
        {
            return Ok(_service.Create(createVM));
        }

        public override IActionResult Edit([FromBody] CountryUpdateVM updateVM)
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

        [HttpGet("GetCountries")]
        [AllowAnonymous]
        public IActionResult GetCountries(string query)
        {
            return Ok(new List<country>()
            {
                new country()
                {
                    Name = "Egypt",
                    Code = 1
                },
                new country()
                {
                    Name = "Qatr",
                    Code = 2
                },
                new country()
                {
                    Name = "Sengal",
                    Code = 3
                }
            }.FindAll(x => query == null || x.Name.ToLower().Contains(query.ToLower().Trim())));
        }
        #endregion

    }
}
