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
    public class PriceController : Controller
    {
        private IRetailRepository repository;

        public PriceController(IRetailRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("products/{productId}/prices")]
        public ActionResult Get(int productId)
        {
            try {
                var prices = repository.GetProductPrices(productId);
                if (prices == null)
                {
                    return Json(new List<PriceViewModel>());
                }
                var vm = Mapper.Map<IEnumerable<PriceViewModel>>(prices);
                return Json(vm);
            }
            catch (EntityNotFoundException)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return new EmptyResult();
            }
            catch
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new EmptyResult();
            }
        }

        [HttpPost("products/{productId}/prices")]
        public ActionResult Post([FromBody]PriceViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newPrice = Mapper.Map<Price>(vm);
                    repository.AddProductPrice(newPrice);
                    repository.SaveAll();
                    Response.StatusCode = (int)HttpStatusCode.Created;
                    return Json(Mapper.Map<PriceViewModel>(newPrice));
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

        [HttpDelete("products/{productId}/prices/{priceId}")]
        public ActionResult Delete(int priceId)
        {
            try {
                repository.DeleteProductPrice(priceId);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return new EmptyResult();
            }
            catch
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new EmptyResult();
            }
        }
    }
}
