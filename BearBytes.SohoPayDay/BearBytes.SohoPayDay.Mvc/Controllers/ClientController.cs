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
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController()
        {
            _clientService = ObjectFactory.GetInstance<ClientService>(); ;
        }

        /// <summary>
        /// List of Clients
        /// </summary>
        /// <param name="Id">The Client Type to filter list by</param>
        /// <returns></returns>
        public ActionResult List(int Id)
        {
            var records = _clientService.FetchMany(Id);

            ViewBag.ClientTypeFilter = ClientHelper.ClientTypeToEnum(Id);
            
            return View(records);
        }


        /// <summary>
        /// Add a new Client
        /// </summary>
        /// <returns></returns>
        public ActionResult Add(int Id)
        {
            var newRecord = _clientService.GetNew(Id);

            ViewBag.FormMode = "Add";
            ViewBag.ClientTypeList = new SelectList(_clientService.FetchClientTypes(), "Id", "Value");
            ViewBag.ClientTypeFilter = ClientHelper.ClientTypeToEnum(Id);

            return View("Edit", newRecord);
        }

        /// <summary>
        /// Add a new Client
        /// </summary>
        /// <param name="newClient"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(ClientDto newClient)
        {
            try
            {
                _clientService.Insert(newClient);

                return RedirectToAction("List", new { Id = ClientHelper.ClientTypeToInt(newClient.ClientType) });
            }
            catch
            {
                ViewBag.FormMode = "Add";
                ViewBag.ClientTypeList = new SelectList(_clientService.FetchClientTypes(), "Id", "Name");
                ViewBag.ClientTypeFilter = ClientHelper.ClientTypeToEnum(newClient.ClientType);
                return View("Edit");
            }
        }

        /// <summary>
        /// Edit a Client
        /// </summary>
        /// <param name="id">ID of the record to edit</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var record = _clientService.GetSingle(id);

            ViewBag.FormMode = "Edit";
            ViewBag.ClientTypeFilter = ClientHelper.ClientTypeToEnum(record.ClientType);

            return View(record);
        }

        /// <summary>
        /// Edit a Client
        /// </summary>
        /// <param name="editedClient"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, ClientDto editedClient)
        {
            try
            {
                _clientService.Update(editedClient);

                return RedirectToAction("List", new { Id = ClientHelper.ClientTypeToInt(editedClient.ClientType) });
            }
            catch
            {
                ViewBag.FormMode = "Edit";
                ViewBag.ClientTypeFilter = ClientHelper.ClientTypeToEnum(editedClient.ClientType);
                return View();
            }
        }


        /// <summary>
        /// Handles Delete of Client
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _clientService.Delete(id);

                return RedirectToAction("List");
            }
            catch
            {
                return Json("Error deleting.");
            }
        }


    }
}
