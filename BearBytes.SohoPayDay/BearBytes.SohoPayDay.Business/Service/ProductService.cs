using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BearBytes.SohoPayDay.Business.Service.Interface;
using BearBytes.SohoPayDay.DataAccess;
using BearBytes.SohoPayDay.DataAccess.Interfaces;
using BearBytes.SohoPayDay.Domain;
using BearBytes.SohoPayDay.Dto;
using NLog;
using StructureMap;

namespace BearBytes.SohoPayDay.Business.Service
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductDao _productDb;

        #region Construct...

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductService()
        {
            _productDb = ObjectFactory.GetInstance<ProductDao>();

            Mapper.CreateMap<ProductDomain, ProductDto>();
            Mapper.CreateMap<ProductDto, ProductDomain>();
        }

        #endregion


        #region Get Single...

        /// <summary>
        /// Gets a single Product record
        /// </summary>
        /// <param name="productId">ID of the Product</param>
        /// <returns>Product Model requested</returns>
        public ProductDto GetSingle(int productId)
        {
            try
            {
                return Mapper.Map<ProductDomain, ProductDto>(_productDb.GetSingle(productId));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a new Product record populated with defaults
        /// </summary>
        /// <returns>ProductDto requested</returns>
        public ProductDto GetNew()
        {
            return new ProductDto
            {
            };
        }

        #endregion

        #region Get Many...

        /// <summary>
        /// Fetch many Products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductDto> FetchMany()
        {
            try
            {
                return Mapper.Map<IEnumerable<ProductDomain>, IEnumerable<ProductDto>>(_productDb.FetchMany());
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }

        }

      

        #endregion

        #region Insert...

        /// <summary>
        /// Inserts an Product record into the database
        /// </summary>
        /// <param name="newRecord">Model of Product item</param>
        /// <returns>The new Product ID.  Otherwise, Exception if one occurs</returns>
        public void Insert(ProductDto newRecord)
        {
            //Begin DB transaction
            _productDb.BeginTransaction();

            try
            {
                //Insert record
                _productDb.Insert(Mapper.Map<ProductDto, ProductDomain>(newRecord));
                _productDb.CompleteTransaction();

                Logger.Info(String.Format("Product '{0}' Inserted Successfully", newRecord.Name));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                _productDb.AbortTransaction();
                throw;
            }
        }

        #endregion

        #region Update...

        /// <summary>
        /// Updates an Product record in the database
        /// </summary>
        /// <param name="editedItem">Model of updated Product record</param>
        /// <returns></returns>
        public bool Update(ProductDto editedItem)
        {
            //Begin DB transaction
            _productDb.BeginTransaction();

            try
            {
                //Get record
                _productDb.Update(Mapper.Map<ProductDto, ProductDomain>(editedItem));
                _productDb.CompleteTransaction();
                Logger.Info(String.Format("Product #{0} Updated Successfully", editedItem.Id));
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                _productDb.AbortTransaction();
                throw;
            }
        }

        #endregion

        #region Delete...

        /// <summary>
        /// Deletes a Product record in the database
        /// </summary>
        /// <param name="recordId">ID of Product to delete</param>
        public void Delete(int recordId)
        {
            //Begin DB transaction
            _productDb.BeginTransaction();

            try
            {
                //Get record
                _productDb.Delete(recordId);
                _productDb.CompleteTransaction();
                Logger.Info(String.Format("Product #{0} Deleted Successfully", recordId));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                _productDb.AbortTransaction();
                throw;
            }
        }

        #endregion

    }
}

