using System.Collections.Generic;
using BearBytes.SohoPayDay.Domain;

namespace BearBytes.SohoPayDay.DataAccess.Interfaces
{
    public interface IInvoiceDao : IBaseDao
    {
        /// <summary>
        /// Get a single Invoice record
        /// </summary>
        /// <returns>InvoiceDomain with requested User</returns>
        InvoiceDomain GetSingle(int recordId);

        /// <summary>
        /// Fetch Invoice Records
        /// </summary>
        /// <param name="invoiceTypeId">ID of the Invoice Type to filter by</param>
        /// <returns></returns>
        IEnumerable<InvoiceDomain> FetchMany(int invoiceTypeId = -1);
    
        /// <summary>
        /// Fetch a list of Invoice Types
        /// </summary>
        /// <returns></returns>
        IEnumerable<LookupDomain> FetchInvoiceTypes();

        /// <summary>
        /// Inserts a Invoice record into the database
        /// </summary>
        /// <param name="newItem">InvoiceDomain of new Invoice item</param>
        /// <returns>The new InvoiceDomain containing the ID</returns>
        int Insert(InvoiceDomain newItem);

        /// <summary>
        /// Updates a Invoice record into the database
        /// </summary>
        /// <param name="editedItem">InvoiceDomain of updated Invoice</param>
        void Update(InvoiceDomain editedItem);

        /// <summary>
        /// Deletes a Record from the database
        /// </summary>
        /// <param name="recordId">ID of Record to delete</param>
        void Delete(int recordId);

    }
}