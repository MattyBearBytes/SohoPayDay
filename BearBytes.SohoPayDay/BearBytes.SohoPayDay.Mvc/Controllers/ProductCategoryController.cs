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
    public class ProductCategoryController : Controller
    {
        private readonly IProductService _productService;

        public ProductCategoryController()
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
            var records = _productService.FetchProductCategories(Id); 
            
            ViewBag.ProductTypeFilter = ProductHelper.ProductTypeToEnum(Id);
            
            return View(records);
        }


        /// <summary>
        /// Add a new Product Caregory
        /// </summary>
        /// <returns></returns>
        public ActionResult Add(int Id)
        {
            ViewBag.ProductTypeFilter = ProductHelper.ProductTypeToEnum(Id);

            var newRecord = new ProductCategoryDto
                                {
                                    ProductType = ViewBag.ProductTypeFilter.ToString()
                                };

            ViewBag.FormMode = "Add";
            return View("Edit", newRecord);
        }

        /// <summary>
        /// Add a new Product Category
        /// </summary>
        /// <param name="newProductCategory"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(ProductCategoryDto newProductCategory)
        {
            try
            {
                _productService.InsertCategory(newProductCategory);

                return RedirectToAction("List", new { Id = ProductHelper.ProductTypeToInt(newProductCategory.ProductType) });
            }
            catch
            {
                ViewBag.ProductTypeFilter = ProductHelper.ProductTypeToEnum(newProductCategory.ProductType);
                ViewBag.FormMode = "Add";
                return View("Edit");
            }
        }

        /// <summary>
        /// Edit a Product Category
        /// </summary>
        /// <param name="id">ID of the record to edit</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var record = _productService.GetSingleCategory(id);

            ViewBag.FormMode = "Edit";
            ViewBag.ProductTypeFilter = ProductHelper.ProductTypeToEnum(record.ProductType);
            
            return View(record);
        }

        /// <summary>
        /// Edit a Product Category
        /// </summary>
        /// <param name="editedProductCategory"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, ProductCategoryDto editedProductCategory)
        {
            try
            {
                _productService.UpdateCategory(editedProductCategory);

                return RedirectToAction("List", new { Id = ProductHelper.ProductTypeToInt(editedProductCategory.ProductType) });
            }
            catch
            {
                ViewBag.ProductTypeFilter = ProductHelper.ProductTypeToEnum(editedProductCategory.ProductType);
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
                _productService.DeleteCategory(id);

                return RedirectToAction("List");
            }
            catch
            {
                return Json("Error deleting.");
            }
        }

    }
}
