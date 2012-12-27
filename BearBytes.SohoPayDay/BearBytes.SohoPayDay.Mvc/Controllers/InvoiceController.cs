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
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IClientService _clientService;

        public InvoiceController()
        {
            _invoiceService = ObjectFactory.GetInstance<InvoiceService>();
            _clientService = ObjectFactory.GetInstance<ClientService>();
        }

        /// <summary>
        /// List of Invoices
        /// </summary>
        /// <param name="Id">The Invoice Type to filter list by</param>
        /// <returns></returns>
        public ActionResult List(int Id)
        {
            var records = _invoiceService.FetchMany(Id);

            ViewBag.InvoiceTypeFilter = EnumHelper.InvoiceTypeToEnum(Id);
            
            return View(records);
        }

        /// <summary>
        /// View a Invoices
        /// </summary>
        /// <param name="Id">The Invoice to fView</param>
        /// <returns></returns>
        public ActionResult View(int Id)
        {
            var record = _invoiceService.GetSingle(Id);

            ViewBag.InvoiceTypeFilter = EnumHelper.InvoiceTypeToEnum(record.InvoiceType);

            return View(record);
        }



        /// <summary>
        /// Add a new Invoice
        /// </summary>
        /// <returns></returns>
        public ActionResult Add(int Id)
        {
            var newRecord = _invoiceService.GetNew(Id);

            ViewBag.FormMode = "Add";
            ViewBag.ClientList = new SelectList(_clientService.FetchSellableLookup(), "Id", "FullName");
            ViewBag.InvoiceTypeFilter = EnumHelper.InvoiceTypeToEnum(Id);

            return View("Edit", newRecord);
        }

        /// <summary>
        /// Add a new Invoice
        /// </summary>
        /// <param name="newInvoice"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(InvoiceDto newInvoice)
        {
            try
            {
                newInvoice.Id = _invoiceService.Insert(newInvoice);

                return RedirectToAction("View", new { Id = newInvoice.Id });
            }
            catch
            {
                ViewBag.FormMode = "Add";
                ViewBag.ClientList = new SelectList(_clientService.FetchSellableLookup(), "Id", "FullName");
                ViewBag.InvoiceTypeFilter = EnumHelper.InvoiceTypeToEnum(newInvoice.InvoiceType);
                return View("Edit");
            }
        }

        /// <summary>
        /// Edit a Invoice
        /// </summary>
        /// <param name="id">ID of the record to edit</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var record = _invoiceService.GetSingle(id);

            ViewBag.FormMode = "Edit";
            ViewBag.ClientList = new SelectList(_clientService.FetchSellableLookup(), "Id", "FullName");
            ViewBag.InvoiceTypeFilter = EnumHelper.InvoiceTypeToEnum(record.InvoiceType);

            return View(record);
        }

        /// <summary>
        /// Edit a Invoice
        /// </summary>
        /// <param name="editedInvoice"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, InvoiceDto editedInvoice)
        {
            try
            {
                _invoiceService.Update(editedInvoice);

                return RedirectToAction("View", new { Id = editedInvoice.Id });
            }
            catch
            {
                ViewBag.FormMode = "Edit";
                ViewBag.ClientList = new SelectList(_clientService.FetchSellableLookup(), "Id", "FullName");
                ViewBag.InvoiceTypeFilter = EnumHelper.InvoiceTypeToEnum(editedInvoice.InvoiceType);
                return View();
            }
        }


        /// <summary>
        /// Handles Delete of Invoice
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _invoiceService.Delete(id);

                return RedirectToAction("List");
            }
            catch
            {
                return Json("Error deleting.");
            }
        }


    }
}
