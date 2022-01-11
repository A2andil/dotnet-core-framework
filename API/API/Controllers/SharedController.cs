using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViewModels.Shared.Searching;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class SharedController<TCreateVM, TUpdateVM> : ControllerBase
    {
        #region Methods
        [HttpGet("GetMany")]
        public abstract IActionResult GetMany([FromQuery] SearchModelVM searchModel);

        [HttpGet("Get/{id}")]
        public abstract IActionResult GetById(int id);

        [HttpDelete("Delete/{id}")]
        public abstract IActionResult Delete(int id);

        [HttpPost("Create")]
        public abstract IActionResult Create([FromBody] TCreateVM addVM);

        [HttpPut("Update")]
        public abstract IActionResult Edit([FromBody] TUpdateVM updateVM);

        [HttpPut("Activate")]
        public abstract IActionResult Activate([FromBody] List<int> ids);
        #endregion
    }
}
