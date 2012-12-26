using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BearBytes.SohoPayDay.DataAccess.Interfaces;
using BearBytes.SohoPayDay.Domain;
using PetaPoco;

namespace BearBytes.SohoPayDay.DataAccess
{
    /// <summary>
    /// Data Access methods for Products
    /// </summary>
    public class ProductDao : BaseDao, IProductDao
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ProductDao()
        {
            TableName = "Product";
            PrimaryKeyName = "ID";
        }


        #region Select Single...

        /// <summary>
        /// Get a single Product record
        /// </summary>
        /// <returns>ProductDomain with requested User</returns>
        public ProductDomain GetSingle(int recordId)
        {
            var sql = Sql.Builder
                .Select(" [Product].* ")
                .From("[Product]")
                .Where(" [Product].ID = @0 ", recordId)
                .Where(" [Product].DeletedDate IS NULL ");

            return DataContext.Query<ProductDomain>(sql).SingleOrDefault();

        }

        #endregion

        #region Select Many...

        /// <summary>
        /// Fetch Product Records
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductDomain> FetchMany()
        {
            var sql = Sql.Builder
                .Select(" [Product].* ")
                .From("[Product]")
                .Where(" [Product].DeletedDate IS NULL ");

            return DataContext.Query<ProductDomain>(sql);
        }


        #endregion

        #region Insert...

        /// <summary>
        /// Inserts a Product record into the database
        /// </summary>
        /// <param name="newItem">ProductDomain of new Product item</param>
        /// <returns>The new ProductDomain containing the ID</returns>
        public void Insert(ProductDomain newItem)
        {
            var sql = Sql.Builder.Append(" INSERT INTO Product (Name) ")
                .Append(" VALUES (@0) ", newItem.Name);

            DataContext.Execute(sql);
        }

        #endregion

        #region Update...

        /// <summary>
        /// Updates a Product record into the database
        /// </summary>
        /// <param name="editedItem">ProductDomain of updated Product</param>
        public void Update(ProductDomain editedItem)
        {
            var sql = Sql.Builder.Append("UPDATE Product ")
                     .Append(" SET Name = @0 ", editedItem.Name)
                     .Append(" WHERE ID = @0 ", editedItem.Id);

            DataContext.Execute(sql);
        }

        #endregion

        #region Delete...

        /// <summary>
        /// Deletes a Product record into the database
        /// </summary>
        /// <param name="productId">ID of the Product to delete</param>
        public void Delete(int productId)
        {
            var sql = Sql.Builder.Append("UPDATE Product ")
                     .Append(" SET DeletedDate = GetDate() ")
                     .Append(" WHERE ID = @0 ", productId);

            DataContext.Execute(sql);
        }

        #endregion
    }
}