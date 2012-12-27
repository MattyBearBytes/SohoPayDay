using System.Collections.Generic;
using BearBytes.SohoPayDay.Dto;

namespace BearBytes.SohoPayDay.Business.Service.Interface
{
    public interface IClientService
    {
        /// <summary>
        /// Gets a single Client record
        /// </summary>
        /// <param name="clientId">ID of the Client</param>
        /// <returns>Client Model requested</returns>
        ClientDto GetSingle(int clientId);

        /// <summary>
        /// Gets a new Client record populated with defaults
        /// </summary>
        /// <param name="clientTypeId">ID of the Client Type</param>
        /// <returns>ClientDto requested</returns>
        ClientDto GetNew(int clientTypeId);

        /// <summary>
        /// Fetch many Clients
        /// </summary>
        /// <param name="clientTypeId">ID of the Client Type to filter by</param>
        /// <returns></returns>
        IEnumerable<ClientDto> FetchMany(int clientTypeId = -1);

        /// <summary>
        /// Fetch a list of Client Types
        /// </summary>
        /// <returns></returns>
        IEnumerable<LookupDto> FetchClientTypes();

        /// <summary>
        /// Inserts an Client record into the database
        /// </summary>
        /// <param name="newRecord">Model of Client item</param>
        /// <returns>The new Client ID.  Otherwise, Exception if one occurs</returns>
        void Insert(ClientDto newRecord);

        /// <summary>
        /// Updates an Client record in the database
        /// </summary>
        /// <param name="editedItem">Model of updated Client record</param>
        void Update(ClientDto editedItem);

        /// <summary>
        /// Deletes a Client record in the database
        /// </summary>
        /// <param name="recordId">ID of Client to delete</param>
        void Delete(int recordId);
     
    }
}