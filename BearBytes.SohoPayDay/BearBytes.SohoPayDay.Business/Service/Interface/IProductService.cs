using System.Collections.Generic;
using BearBytes.SohoPayDay.Dto;

namespace BearBytes.SohoPayDay.Business.Service.Interface
{
    public interface IProductService
    {
        /// <summary>
        /// Gets a single Product record
        /// </summary>
        /// <param name="productId">ID of the Product</param>
        /// <returns>Product Model requested</returns>
        ProductDto GetSingle(int productId);

        /// <summary>
        /// Gets a new Product record populated with defaults
        /// </summary>
        /// <returns>ProductDto requested</returns>
        ProductDto GetNew();

        /// <summary>
        /// Fetch many Products
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductDto> FetchMany();

        /// <summary>
        /// Inserts an Product record into the database
        /// </summary>
        /// <param name="newRecord">Model of Product item</param>
        /// <returns>The new Product ID.  Otherwise, Exception if one occurs</returns>
        void Insert(ProductDto newRecord);

        /// <summary>
        /// Updates an Product record in the database
        /// </summary>
        /// <param name="editedItem">Model of updated Product record</param>
        /// <returns></returns>
        bool Update(ProductDto editedItem);

        /// <summary>
        /// Deletes a Product record in the database
        /// </summary>
        /// <param name="recordId">ID of Product to delete</param>
        void Delete(int recordId);
    }
}