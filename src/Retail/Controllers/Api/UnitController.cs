using AutoMapper;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Retail.Models;
using Retail.ViewModels;
using System.Collections.Generic;
using System.Net;

namespace Retail.Controllers.Api
{
    [Authorize]
    [Route("units")]
    public class UnitController : Controller
    {
        private IRetailRepository repository;

        public UnitController(IRetailRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var units = repository.GetAllUnits();
                var vm = Mapper.Map<IEnumerable<UnitViewModel>>(units);
                return Json(vm);
            }
            catch
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new EmptyResult();
            }
        }
    }
}
