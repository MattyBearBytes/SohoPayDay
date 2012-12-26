using System.Collections.Generic;
using BearBytes.SohoPayDay.Domain;

namespace BearBytes.SohoPayDay.DataAccess.Interfaces
{
    public interface IProductDao : IBaseDao
    {
        /// <summary>
        /// Get a single Product record
        /// </summary>
        /// <returns>ProductDomain with requested User</returns>
        ProductDomain GetSingle(int recordId);

        /// <summary>
        /// Fetch Product Records
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductDomain> FetchMany();

        /// <summary>
        /// Inserts a Product record into the database
        /// </summary>
        /// <param name="newItem">ProductDomain of new Product item</param>
        /// <returns>The new ProductDomain containing the ID</returns>
        void Insert(ProductDomain newItem);

        /// <summary>
        /// Updates a Product record into the database
        /// </summary>
        /// <param name="editedItem">ProductDomain of updated Product</param>
        void Update(ProductDomain editedItem);

        /// <summary>
        /// Deletes a Record from the database
        /// </summary>
        /// <param name="recordId">ID of Record to delete</param>
        void Delete(int recordId);
    }
}