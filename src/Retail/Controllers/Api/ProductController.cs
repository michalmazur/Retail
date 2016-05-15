using AutoMapper;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Retail.Models;
using Retail.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;

namespace Retail.Controllers.Api
{
    [Route("products")]
    [Authorize]
    public class ProductController : Controller
    {
        private IRetailRepository repository;

        public ProductController(IRetailRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var products = repository.GetAllProducts();
                var vm = Mapper.Map<IEnumerable<ProductViewModel>>(products);
                return Json(vm);
            }
            catch
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new EmptyResult();
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try {
                var product = repository.GetProduct(id);
                var vm = Mapper.Map<ProductViewModel>(product);
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

        [HttpPost]
        public ActionResult Post([FromBody]ProductViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newProduct = Mapper.Map<Product>(vm);
                    repository.AddProduct(newProduct);
                    repository.SaveAll();
                    Response.StatusCode = (int)HttpStatusCode.Created;
                    return Json(Mapper.Map<ProductViewModel>(newProduct));
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

        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]ProductViewModelBase vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingProduct = repository.GetProduct(id);
                    Mapper.Map(vm, existingProduct);
                    existingProduct.UpdatedDate = DateTime.Now;
                    repository.SaveAll();
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(Mapper.Map<ProductViewModel>(existingProduct));
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
                return Json(new { Errors = ModelState });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try {
                repository.DeleteProduct(id);
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
