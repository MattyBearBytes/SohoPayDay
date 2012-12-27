using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BearBytes.SohoPayDay.Business.Service.Interface;
using BearBytes.SohoPayDay.Common;
using BearBytes.SohoPayDay.Common.Helpers;
using BearBytes.SohoPayDay.DataAccess;
using BearBytes.SohoPayDay.DataAccess.Interfaces;
using BearBytes.SohoPayDay.Domain;
using BearBytes.SohoPayDay.Dto;
using NLog;
using StructureMap;

namespace BearBytes.SohoPayDay.Business.Service
{
    public class InvoiceService : BaseService, IInvoiceService
    {
        private readonly IInvoiceDao _invoiceDb;

        #region Construct...

        /// <summary>
        /// Constructor
        /// </summary>
        public InvoiceService()
        {
            _invoiceDb = ObjectFactory.GetInstance<InvoiceDao>();

            Mapper.CreateMap<InvoiceDomain, InvoiceDto>();
            Mapper.CreateMap<InvoiceDto, InvoiceDomain>();
            Mapper.CreateMap<ClientDomain, ClientDto>();
            Mapper.CreateMap<ClientDto, ClientDomain>();
        }

        #endregion


        #region Get Single...


        public InvoiceDto GetSingle(int invoiceId)
        {
            try
            {
                return Mapper.Map<InvoiceDomain, InvoiceDto>(_invoiceDb.GetSingle(invoiceId));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }


        public InvoiceDto GetNew(int invoiceTypeId)
        {
            return new InvoiceDto
            {
                InvoiceType = EnumHelper.InvoiceTypeToEnum(invoiceTypeId).ToString(),
                IssueDate = DateTime.Today
            };
        }

        #endregion

        #region Get Many...


        public IEnumerable<InvoiceDto> FetchMany(int invoiceTypeId = -1)
        {
            try
            {
                return Mapper.Map<IEnumerable<InvoiceDomain>, IEnumerable<InvoiceDto>>(_invoiceDb.FetchMany(invoiceTypeId));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
        
        #endregion

        #region Insert...

        public int Insert(InvoiceDto newRecord)
        {
            //Begin DB transaction
            _invoiceDb.BeginTransaction();

            try
            {
                //Insert record
                var invoiceId = _invoiceDb.Insert(Mapper.Map<InvoiceDto, InvoiceDomain>(newRecord));
                _invoiceDb.CompleteTransaction();

                Logger.Info(String.Format("{0} '{1}' Inserted Successfully", newRecord.InvoiceType, newRecord.InvoiceNumber));

                return invoiceId;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                _invoiceDb.AbortTransaction();
                throw;
            }
        }
        
        #endregion

        #region Update...

        public void Update(InvoiceDto editedItem)
        {
            //Begin DB transaction
            _invoiceDb.BeginTransaction();

            try
            {
                //Get record
                _invoiceDb.Update(Mapper.Map<InvoiceDto, InvoiceDomain>(editedItem));
                _invoiceDb.CompleteTransaction();
                Logger.Info(String.Format("Invoice #{0} Updated Successfully", editedItem.Id));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                _invoiceDb.AbortTransaction();
                throw;
            }
        }

        #endregion

        #region Delete...

        public void Delete(int recordId)
        {
            //Begin DB transaction
            _invoiceDb.BeginTransaction();

            try
            {
                //Get record
                _invoiceDb.Delete(recordId);
                _invoiceDb.CompleteTransaction();
                Logger.Info(String.Format("Invoice #{0} Deleted Successfully", recordId));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                _invoiceDb.AbortTransaction();
                throw;
            }
        }
        
        #endregion

    }
}

