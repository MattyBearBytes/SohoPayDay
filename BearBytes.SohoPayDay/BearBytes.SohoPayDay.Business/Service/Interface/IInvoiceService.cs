using System.Collections.Generic;
using BearBytes.SohoPayDay.Dto;

namespace BearBytes.SohoPayDay.Business.Service.Interface
{
    public interface IInvoiceService
    {
        /// <summary>
        /// Gets a single Invoice record
        /// </summary>
        /// <param name="invoiceId">ID of the Invoice</param>
        /// <returns>Invoice Model requested</returns>
        InvoiceDto GetSingle(int invoiceId);

        /// <summary>
        /// Gets a new Invoice record populated with defaults
        /// </summary>
        /// <param name="invoiceTypeId">ID of the Invoice Type</param>
        /// <returns>InvoiceDto requested</returns>
        InvoiceDto GetNew(int invoiceTypeId);

        /// <summary>
        /// Fetch many Invoices
        /// </summary>
        /// <param name="invoiceTypeId">ID of the Invoice Type to filter by</param>
        /// <returns></returns>
        IEnumerable<InvoiceDto> FetchMany(int invoiceTypeId = -1);

        /// <summary>
        /// Inserts an Invoice record into the database
        /// </summary>
        /// <param name="newRecord">Model of Invoice item</param>
        /// <returns>The new Invoice ID.  Otherwise, Exception if one occurs</returns>
        int Insert(InvoiceDto newRecord);

        /// <summary>
        /// Updates an Invoice record in the database
        /// </summary>
        /// <param name="editedItem">Model of updated Invoice record</param>
        void Update(InvoiceDto editedItem);

        /// <summary>
        /// Deletes a Invoice record in the database
        /// </summary>
        /// <param name="recordId">ID of Invoice to delete</param>
        void Delete(int recordId);
     
    }
}