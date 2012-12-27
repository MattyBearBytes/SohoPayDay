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
        /// <param name="productTypeId">ID of the Product Type</param>
        /// <returns>ProductDto requested</returns>
        ProductDto GetNew(int productTypeId);

        /// <summary>
        /// Fetch many Products
        /// </summary>
        /// <param name="productTypeId">ID of the Product Type to filter by</param>
        /// <returns></returns>
        IEnumerable<ProductDto> FetchMany(int productTypeId = -1);

        /// <summary>
        /// Fetch a list of Product Types
        /// </summary>
        /// <param name="productTypeId">ID of the Product Type to filter by</param>
        /// <returns></returns>
        IEnumerable<ProductCategoryDto> FetchProductCategories(int productTypeId);

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
        void Update(ProductDto editedItem);

        /// <summary>
        /// Deletes a Product record in the database
        /// </summary>
        /// <param name="recordId">ID of Product to delete</param>
        void Delete(int recordId);
        
        /// <summary>
        /// Gets a single Product Category record
        /// </summary>
        /// <param name="productCategoryId">ID of the Product Category</param>
        /// <returns>Product Category Model requested</returns>
        ProductCategoryDto GetSingleCategory(int productCategoryId);

        /// <summary>
        /// Inserts an Product Category record into the database
        /// </summary>
        /// <param name="newRecord">Model of Product Category item</param>
        /// <returns>The new Product Category ID.  Otherwise, Exception if one occurs</returns>
        void InsertCategory(ProductCategoryDto newRecord);

        /// <summary>
        /// Updates an Product Category record in the database
        /// </summary>
        /// <param name="editedItem">Model of updated Product Category record</param>
        void UpdateCategory(ProductCategoryDto editedItem);

        /// <summary>
        /// Deletes a Product Category record in the database
        /// </summary>
        /// <param name="recordId">ID of Product Category to delete</param>
        void DeleteCategory(int recordId);
    
    }
}