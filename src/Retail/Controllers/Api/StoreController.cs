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
    [Route("stores")]
    public class StoreController : Controller
    {
        private IRetailRepository repository;

        public StoreController(IRetailRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try {
                var stores = repository.GetAllStores();
                var vm = Mapper.Map<IEnumerable<StoreViewModel>>(stores);
                return Json(vm);
            }
            catch
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new EmptyResult();
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]StoreViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newStore = Mapper.Map<Store>(vm);
                    repository.AddStore(newStore);
                    repository.SaveAll();
                    Response.StatusCode = (int)HttpStatusCode.Created;
                    return Json(Mapper.Map<StoreViewModel>(newStore));
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(new { Errors = ModelState });
                }
            }
            catch
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new EmptyResult();
            }
        }
    }
}
