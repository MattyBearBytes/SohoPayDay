using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BearBytes.SohoPayDay.Business.Service;
using BearBytes.SohoPayDay.Business.Service.Interface;
using BearBytes.SohoPayDay.Dto;
using StructureMap;

namespace BearBytes.SohoPayDay.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController()
        {
            _productService = ObjectFactory.GetInstance<ProductService>(); ;
        }

        /// <summary>
        /// List of Products
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var records = _productService.FetchMany();
            return View(records);
        }


        /// <summary>
        /// Add a new Product
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            var newRecord = _productService.GetNew();

            ViewBag.FormMode = "Add";

            return View("Edit", newRecord);
        }

        /// <summary>
        /// Add a new Product
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(ProductDto newProduct)
        {
            try
            {
                _productService.Insert(newProduct);

                return RedirectToAction("List");
            }
            catch
            {
                ViewBag.FormMode = "Add";
                return View("Edit");
            }
        }

        /// <summary>
        /// Edit a Product
        /// </summary>
        /// <param name="id">ID of the record to edit</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var record = _productService.GetSingle(id);

            ViewBag.FormMode = "Edit";

            return View(record);
        }

        /// <summary>
        /// Edit a Product
        /// </summary>
        /// <param name="editedProduct"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, ProductDto editedProduct)
        {
            try
            {
                _productService.Update(editedProduct);

                return RedirectToAction("List");
            }
            catch
            {
                ViewBag.FormMode = "Edit";
                return View();
            }
        }


        /// <summary>
        /// Handles Delete of Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _productService.Delete(id);

                return RedirectToAction("List");
            }
            catch
            {
                return Json("Error deleting.");
            }
        }
    }
}
