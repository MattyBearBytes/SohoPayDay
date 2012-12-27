using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BearBytes.SohoPayDay.Business.Service.Interface;
using BearBytes.SohoPayDay.Common;
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

            Mapper.CreateMap<ProductCategoryDomain, ProductCategoryDto>();
            Mapper.CreateMap<ProductCategoryDto, ProductCategoryDomain>();
        }

        #endregion


        #region Get Single...


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

        public ProductCategoryDto GetSingleCategory(int productId)
        {
            try
            {
                return Mapper.Map<ProductCategoryDomain, ProductCategoryDto>(_productDb.GetSingleCategory(productId));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }


        public ProductDto GetNew(int productTypeId)
        {
            return new ProductDto
            {
                ProductCategory = new ProductCategoryDto
                                      {
                                          ProductType = ((Enums.ProductType)productTypeId).ToString()
                                      }
            };
        }

        #endregion

        #region Get Many...


        public IEnumerable<ProductDto> FetchMany(int productTypeId = -1)
        {
            try
            {
                return Mapper.Map<IEnumerable<ProductDomain>, IEnumerable<ProductDto>>(_productDb.FetchMany(productTypeId));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }


        public IEnumerable<ProductCategoryDto> FetchProductCategories(int productTypeId)
        {
            try
            {
                return Mapper.Map<IEnumerable<ProductCategoryDomain>, IEnumerable<ProductCategoryDto>>(_productDb.FetchProductCategories(productTypeId));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

      

        #endregion

        #region Insert...

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

        public void InsertCategory(ProductCategoryDto newRecord)
        {
            //Begin DB transaction
            _productDb.BeginTransaction();

            try
            {
                //Insert record
                _productDb.InsertCategory(Mapper.Map<ProductCategoryDto, ProductCategoryDomain>(newRecord));
                _productDb.CompleteTransaction();

                Logger.Info(String.Format("Product Category '{0}' Inserted Successfully", newRecord.Name));
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

        public void Update(ProductDto editedItem)
        {
            //Begin DB transaction
            _productDb.BeginTransaction();

            try
            {
                //Get record
                _productDb.Update(Mapper.Map<ProductDto, ProductDomain>(editedItem));
                _productDb.CompleteTransaction();
                Logger.Info(String.Format("Product #{0} Updated Successfully", editedItem.Id));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                _productDb.AbortTransaction();
                throw;
            }
        }

        public void UpdateCategory(ProductCategoryDto editedItem)
        {
            //Begin DB transaction
            _productDb.BeginTransaction();

            try
            {
                //Get record
                _productDb.UpdateCategory(Mapper.Map<ProductCategoryDto, ProductCategoryDomain>(editedItem));
                _productDb.CompleteTransaction();
                Logger.Info(String.Format("Product Category #{0} Updated Successfully", editedItem.Id));
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

        public void DeleteCategory(int recordId)
        {
            //Begin DB transaction
            _productDb.BeginTransaction();

            try
            {
                //Get record
                _productDb.DeleteCategory(recordId);
                _productDb.CompleteTransaction();
                Logger.Info(String.Format("Product Category #{0} Deleted Successfully", recordId));
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

