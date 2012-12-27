using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BearBytes.SohoPayDay.Common;
using BearBytes.SohoPayDay.Common.Helpers;
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
        public ProductDao()
        {
            TableName = "Product";
            PrimaryKeyName = "ID";
        }


        #region Select Single...

        public ProductDomain GetSingle(int recordId)
        {
            var sql = Sql.Builder
                .Select(" Product.*, " +
                        " ProductCategory.*, ProductType.Name as ProductType ")
                .From("Product")
                .LeftJoin("ProductCategory").On("Product.CategoryId = ProductCategory.Id")
                .LeftJoin("ProductType").On("ProductCategory.TypeId = ProductType.Id")
                .Where(" Product.ID = @0 ", recordId)
                .Where(" Product.DeletedDate IS NULL ");

            return DataContext.Query<ProductDomain, ProductCategoryDomain>(sql).SingleOrDefault();

        }

        public ProductCategoryDomain GetSingleCategory(int recordId)
        {
            var sql = Sql.Builder
                .Select("ProductCategory.*, ProductType.Name as ProductType ")
                .From("ProductCategory")
                .LeftJoin("ProductType").On("ProductCategory.TypeId = ProductType.Id")
                .Where(" ProductCategory.ID = @0 ", recordId)
                .Where(" ProductCategory.DeletedDate IS NULL ");

            return DataContext.Query<ProductCategoryDomain>(sql).SingleOrDefault();

        }

        #endregion

        #region Select Many...

        public IEnumerable<ProductDomain> FetchMany(int productTypeId = -1, int productCategoryId = -1)
        {
            var sql = Sql.Builder
                .Select(" [Product].*, " +
                        " ProductCategory.*, ProductType.Name as ProductType ")
                .From("[Product]")
                .LeftJoin("ProductCategory").On("[Product].CategoryId = ProductCategory.Id")
                .LeftJoin("ProductType").On("ProductCategory.TypeId = ProductType.Id")
                .Where(" [Product].DeletedDate IS NULL ")
                .Where(" [ProductCategory].TypeId = @0 OR @0 = -1", productTypeId)
                .Where(" [Product].CategoryId = @0 OR @0 = -1", productCategoryId);

            return DataContext.Query<ProductDomain, ProductCategoryDomain>(sql);
        }


        public IEnumerable<ProductCategoryDomain> FetchProductCategories(int productTypeId)
        {
            var sql = Sql.Builder
                .Select(" [ProductCategory].* ")
                .From("[ProductCategory]")
                .Where(" [ProductCategory].DeletedDate IS NULL ")
                .Where(" [ProductCategory].TypeId = @0", productTypeId);

            return DataContext.Query<ProductCategoryDomain>(sql);            
        }


        #endregion

        #region Insert...

        public void Insert(ProductDomain newItem)
        {
            var sql = Sql.Builder.Append(" INSERT INTO Product (Name, CategoryId) ")
                .Append(" VALUES (@0, @1) ", newItem.Name, newItem.ProductCategory.Id);

            DataContext.Execute(sql);
        }

        public void InsertCategory(ProductCategoryDomain newItem)
        {
            var sql = Sql.Builder.Append(" INSERT INTO ProductCategory (Name, TypeId) ")
                .Append(" VALUES (@0, @1) ", newItem.Name, EnumHelper.EnumTextToInt(newItem.ProductType, typeof(Enums.ProductType)));

            DataContext.Execute(sql);
        }

        #endregion

        #region Update...

        public void Update(ProductDomain editedItem)
        {
            var sql = Sql.Builder.Append("UPDATE Product ")
                     .Append(" SET Name = @0, CategoryId = @1 ", editedItem.Name, editedItem.ProductCategory.Id)
                     .Append(" WHERE ID = @0 ", editedItem.Id);

            DataContext.Execute(sql);
        }

        public void UpdateCategory(ProductCategoryDomain editedItem)
        {
            var sql = Sql.Builder.Append("UPDATE ProductCategory ")
                     .Append(" SET Name = @0, TypeId = @1 ", editedItem.Name, EnumHelper.EnumTextToInt(editedItem.ProductType, typeof(Enums.ProductType)))
                     .Append(" WHERE ID = @0 ", editedItem.Id);

            DataContext.Execute(sql);
        }

        #endregion

        #region Delete...

        public void Delete(int productId)
        {
            var sql = Sql.Builder.Append("UPDATE Product ")
                     .Append(" SET DeletedDate = GetDate() ")
                     .Append(" WHERE ID = @0 ", productId);

            DataContext.Execute(sql);
        }

        public void DeleteCategory(int productId)
        {
            var sql = Sql.Builder.Append("UPDATE ProductCategory ")
                     .Append(" SET DeletedDate = GetDate() ")
                     .Append(" WHERE ID = @0 ", productId);

            DataContext.Execute(sql);
        }

        #endregion
    }
}