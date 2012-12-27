using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BearBytes.SohoPayDay.Business.Service.Interface;
using BearBytes.SohoPayDay.Common;
using BearBytes.SohoPayDay.Common.Helpers;
using BearBytes.SohoPayDay.DataAccess;
using BearBytes.SohoPayDay.DataAccess.Interfaces;
using BearBytes.SohoPayDay.Domain;
using BearBytes.SohoPayDay.Dto;
using NLog;
using StructureMap;

namespace BearBytes.SohoPayDay.Business.Service
{
    public class ClientService : BaseService, IClientService
    {
        private readonly IClientDao _clientDb;

        #region Construct...

        /// <summary>
        /// Constructor
        /// </summary>
        public ClientService()
        {
            _clientDb = ObjectFactory.GetInstance<ClientDao>();

            Mapper.CreateMap<ClientDomain, ClientDto>();
            Mapper.CreateMap<ClientDto, ClientDomain>();
            Mapper.CreateMap<LookupDomain, LookupDto>();
            Mapper.CreateMap<LookupDto, LookupDomain>();

        }

        #endregion


        #region Get Single...


        public ClientDto GetSingle(int clientId)
        {
            try
            {
                return Mapper.Map<ClientDomain, ClientDto>(_clientDb.GetSingle(clientId));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }


        public ClientDto GetNew(int clientTypeId)
        {
            return new ClientDto
            {
                ClientType = EnumHelper.ClientTypeToEnum(clientTypeId).ToString()
            };
        }

        #endregion

        #region Get Many...


        public IEnumerable<ClientDto> FetchMany(int clientTypeId = -1)
        {
            try
            {
                return Mapper.Map<IEnumerable<ClientDomain>, IEnumerable<ClientDto>>(_clientDb.FetchMany(clientTypeId));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }


        public IEnumerable<LookupDto> FetchClientTypes()
        {
            try
            {
                return Mapper.Map<IEnumerable<LookupDomain>, IEnumerable<LookupDto>>(_clientDb.FetchClientTypes());
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }


        public IEnumerable<ClientDto> FetchSellableLookup()
        {
            try
            {
                return Mapper.Map<IEnumerable<ClientDomain>, IEnumerable<ClientDto>>(
                    _clientDb.FetchMany().Where(x => x.ClientType == "Business" || x.ClientType == "Private"));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

      

        #endregion

        #region Insert...

        public void Insert(ClientDto newRecord)
        {
            //Begin DB transaction
            _clientDb.BeginTransaction();

            try
            {
                //Insert record
                _clientDb.Insert(Mapper.Map<ClientDto, ClientDomain>(newRecord));
                _clientDb.CompleteTransaction();

                Logger.Info(String.Format("{0} Client '{1}' Inserted Successfully", newRecord.ClientType, newRecord.FullName));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                _clientDb.AbortTransaction();
                throw;
            }
        }
        
        #endregion

        #region Update...

        public void Update(ClientDto editedItem)
        {
            //Begin DB transaction
            _clientDb.BeginTransaction();

            try
            {
                //Get record
                _clientDb.Update(Mapper.Map<ClientDto, ClientDomain>(editedItem));
                _clientDb.CompleteTransaction();
                Logger.Info(String.Format("Client #{0} Updated Successfully", editedItem.Id));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                _clientDb.AbortTransaction();
                throw;
            }
        }

        #endregion

        #region Delete...

        public void Delete(int recordId)
        {
            //Begin DB transaction
            _clientDb.BeginTransaction();

            try
            {
                //Get record
                _clientDb.Delete(recordId);
                _clientDb.CompleteTransaction();
                Logger.Info(String.Format("Client #{0} Deleted Successfully", recordId));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                _clientDb.AbortTransaction();
                throw;
            }
        }
        
        #endregion

    }
}

