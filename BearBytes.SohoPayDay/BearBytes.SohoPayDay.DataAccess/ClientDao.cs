using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BearBytes.SohoPayDay.Common.Helpers;
using BearBytes.SohoPayDay.DataAccess.Interfaces;
using BearBytes.SohoPayDay.Domain;
using PetaPoco;

namespace BearBytes.SohoPayDay.DataAccess
{
    /// <summary>
    /// Data Access methods for Clients
    /// </summary>
    public class ClientDao : BaseDao, IClientDao
    {
        public ClientDao()
        {
            TableName = "Client";
            PrimaryKeyName = "ID";
        }


        #region Select Single...

        public ClientDomain GetSingle(int recordId)
        {
            var sql = Sql.Builder
                .Select(" [Client].*, " +
                        " ClientType.Name as ClientType ")
                .From("[Client]")
                .LeftJoin("ClientType").On("Client.TypeId = ClientType.Id")
                .Where(" [Client].Id = @0", recordId);

            return DataContext.Query<ClientDomain>(sql).SingleOrDefault();

        }
        
        #endregion

        #region Select Many...

        public IEnumerable<ClientDomain> FetchMany(int clientTypeId = -1)
        {
            var sql = Sql.Builder
                .Select(" [Client].*, " +
                        " ClientType.Name as ClientType ")
                .From("[Client]")
                .LeftJoin("ClientType").On("Client.TypeId = ClientType.Id")
                .Where(" [Client].DeletedDate IS NULL ")
                .Where(" [Client].TypeId = @0 OR @0 = -1", clientTypeId);

            return DataContext.Query<ClientDomain>(sql);
        }

        public IEnumerable<LookupDomain> FetchClientTypes()
        {
            var sql = Sql.Builder
                .Select(" [ClientType].* ")
                .From("[ClientType]")
                .Where(" [ClientType].DeletedDate IS NULL ");

            return DataContext.Query<LookupDomain>(sql);            
        }

        #endregion

        #region Insert...

        public void Insert(ClientDomain newItem)
        {
            var sql = Sql.Builder.Append(" INSERT INTO Client (TypeId, FirstName, Surname, BusinessName) ")
                .Append(" VALUES (@0, @1, @2, @3) ", ClientHelper.ClientTypeToInt(newItem.ClientType), newItem.FirstName, 
                        newItem.Surname, newItem.BusinessName);

            DataContext.Execute(sql);
        }
        
        #endregion

        #region Update...

        public void Update(ClientDomain editedItem)
        {
            var sql = Sql.Builder.Append("UPDATE Client ")
                     .Append(" SET TypeId = @0, FirstName = @1, Surname = @2, BusinessName = @3 ", 
                        ClientHelper.ClientTypeToInt(editedItem.ClientType), editedItem.FirstName, 
                        editedItem.Surname, editedItem.BusinessName)
                     .Append(" WHERE ID = @0 ", editedItem.Id);

            DataContext.Execute(sql);
        }

        #endregion

        #region Delete...

        public void Delete(int clientId)
        {
            var sql = Sql.Builder.Append("UPDATE Client ")
                     .Append(" SET DeletedDate = GetDate() ")
                     .Append(" WHERE ID = @0 ", clientId);

            DataContext.Execute(sql);
        }

        #endregion
    }
}