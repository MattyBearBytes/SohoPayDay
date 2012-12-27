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
        /// <param name="productTypeId">ID of the Product Type to filter by</param>
        /// <param name="productCategoryId">ID of the Product Category to filter by</param>
        /// <returns></returns>
        IEnumerable<ProductDomain> FetchMany(int productTypeId = -1, int productCategoryId = -1);
    
        /// <summary>
        /// Fetch a list of Product Types
        /// </summary>
        /// <param name="productTypeId">ID of the Product Type to filter by</param>
        /// <returns></returns>
        IEnumerable<ProductCategoryDomain> FetchProductCategories(int productTypeId);

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


        /// <summary>
        /// Get a single Product Category record
        /// </summary>
        /// <returns>ProductCategoryDomain with requested User</returns>
        ProductCategoryDomain GetSingleCategory(int recordId);

        /// <summary>
        /// Inserts a Product Category record into the database
        /// </summary>
        /// <param name="newItem">ProductCategoryDomain of new Product Category item</param>
        /// <returns>The new ProductCategoryDomain containing the ID</returns>
        void InsertCategory(ProductCategoryDomain newItem);

        /// <summary>
        /// Updates a Product Category record into the database
        /// </summary>
        /// <param name="editedItem">ProductCategoryDomain of updated Product Category</param>
        void UpdateCategory(ProductCategoryDomain editedItem);

        /// <summary>
        /// Deletes a Record from the database
        /// </summary>
        /// <param name="recordId">ID of Record to delete</param>
        void DeleteCategory(int recordId);

    }
}