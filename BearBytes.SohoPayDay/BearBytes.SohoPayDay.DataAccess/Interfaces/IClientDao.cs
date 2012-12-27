using System.Collections.Generic;
using BearBytes.SohoPayDay.Domain;

namespace BearBytes.SohoPayDay.DataAccess.Interfaces
{
    public interface IClientDao : IBaseDao
    {
        /// <summary>
        /// Get a single Client record
        /// </summary>
        /// <returns>ClientDomain with requested User</returns>
        ClientDomain GetSingle(int recordId);

        /// <summary>
        /// Fetch Client Records
        /// </summary>
        /// <param name="clientTypeId">ID of the Client Type to filter by</param>
        /// <returns></returns>
        IEnumerable<ClientDomain> FetchMany(int clientTypeId = -1);
    
        /// <summary>
        /// Fetch a list of Client Types
        /// </summary>
        /// <returns></returns>
        IEnumerable<LookupDomain> FetchClientTypes();

        /// <summary>
        /// Inserts a Client record into the database
        /// </summary>
        /// <param name="newItem">ClientDomain of new Client item</param>
        /// <returns>The new ClientDomain containing the ID</returns>
        void Insert(ClientDomain newItem);

        /// <summary>
        /// Updates a Client record into the database
        /// </summary>
        /// <param name="editedItem">ClientDomain of updated Client</param>
        void Update(ClientDomain editedItem);

        /// <summary>
        /// Deletes a Record from the database
        /// </summary>
        /// <param name="recordId">ID of Record to delete</param>
        void Delete(int recordId);

    }
}