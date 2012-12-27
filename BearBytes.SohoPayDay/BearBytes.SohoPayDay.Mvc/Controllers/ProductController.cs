using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BearBytes.SohoPayDay.Business.Service;
using BearBytes.SohoPayDay.Business.Service.Interface;
using BearBytes.SohoPayDay.Common;
using BearBytes.SohoPayDay.Common.Helpers;
using BearBytes.SohoPayDay.Dto;
using StructureMap;

namespace BearBytes.SohoPayDay.Mvc.Controllers
{
    [Authorize]
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
        /// <param name="Id">The Product Type to filter list by</param>
        /// <returns></returns>
        public ActionResult List(int Id)
        {
            var records = _productService.FetchMany(Id);

            ViewBag.ProductTypeFilter = EnumHelper.ProductTypeToEnum(Id);
            
            return View(records);
        }


        /// <summary>
        /// Add a new Product
        /// </summary>
        /// <returns></returns>
        public ActionResult Add(int Id)
        {
            var newRecord = _productService.GetNew(Id);

            ViewBag.FormMode = "Add";
            ViewBag.ProductCategoryList = new SelectList(_productService.FetchProductCategories(Id), "Id", "Name");
            ViewBag.ProductTypeFilter = EnumHelper.ProductTypeToEnum(Id);

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

                return RedirectToAction("List", new { Id = EnumHelper.EnumTextToInt(newProduct.ProductCategory.ProductType, typeof(Enums.ProductType)) });
            }
            catch
            {
                ViewBag.FormMode = "Add";
                ViewBag.ProductCategoryList = new SelectList(_productService.FetchProductCategories(EnumHelper.EnumTextToInt(newProduct.ProductCategory.ProductType, typeof(Enums.ProductType))), "Id", "Name");
                ViewBag.ProductTypeFilter = EnumHelper.ProductTypeToEnum(newProduct.ProductCategory.ProductType);
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
            ViewBag.ProductCategoryList = new SelectList(_productService.FetchProductCategories(EnumHelper.EnumTextToInt(record.ProductCategory.ProductType, typeof(Enums.ProductType))), "Id", "Name");
            ViewBag.ProductTypeFilter = EnumHelper.ProductTypeToEnum(record.ProductCategory.ProductType);
            

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

                return RedirectToAction("List", new { Id = EnumHelper.EnumTextToInt(editedProduct.ProductCategory.ProductType, typeof(Enums.ProductType)) });
            }
            catch
            {
                ViewBag.FormMode = "Edit";
                ViewBag.ProductCategoryList = new SelectList(_productService.FetchProductCategories(EnumHelper.EnumTextToInt(editedProduct.ProductCategory.ProductType, typeof(Enums.ProductType))), "Id", "Name");
                ViewBag.ProductTypeFilter = EnumHelper.ProductTypeToEnum(editedProduct.ProductCategory.ProductType);
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
