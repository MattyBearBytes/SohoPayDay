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
    /// Data Access methods for Invoices
    /// </summary>
    public class InvoiceDao : BaseDao, IInvoiceDao
    {
        public InvoiceDao()
        {
            TableName = "Invoice";
            PrimaryKeyName = "ID";
        }


        #region Select Single...

        public InvoiceDomain GetSingle(int recordId)
        {
            var sql = Sql.Builder
                .Select(" [Invoice].*, " +
                        " InvoiceType.Name as InvoiceType, " +
                        " Client.*, ClientType.Name as ClientType ")
                .From("[Invoice]")
                .LeftJoin("InvoiceType").On("Invoice.TypeId = InvoiceType.Id")
                .LeftJoin("Client").On("Invoice.ClientId = Client.Id")
                .LeftJoin("ClientType").On("ClientType.Id = Client.TypeId")
                .Where(" [Invoice].Id = @0", recordId);

            return DataContext.Query<InvoiceDomain, ClientDomain>(sql).SingleOrDefault();
        }
        
        #endregion

        #region Select Many...

        public IEnumerable<InvoiceDomain> FetchMany(int invoiceTypeId = -1)
        {
            var sql = Sql.Builder
                .Select(" [Invoice].*, " +
                        " InvoiceType.Name as InvoiceType, " +
                        " Client.*, ClientType.Name as ClientType ")
                .From("[Invoice]")
                .LeftJoin("InvoiceType").On("Invoice.TypeId = InvoiceType.Id")
                .LeftJoin("Client").On("Invoice.ClientId = Client.Id")
                .LeftJoin("ClientType").On("ClientType.Id = Client.TypeId")
                .Where(" [Invoice].DeletedDate IS NULL ")
                .Where(" [Invoice].TypeId = @0 OR @0 = -1", invoiceTypeId);

            return DataContext.Query<InvoiceDomain, ClientDomain>(sql);
        }

        public IEnumerable<LookupDomain> FetchInvoiceTypes()
        {
            var sql = Sql.Builder
                .Select(" [InvoiceType].* ")
                .From("[InvoiceType]")
                .Where(" [InvoiceType].DeletedDate IS NULL ");

            return DataContext.Query<LookupDomain>(sql);            
        }

        #endregion

        #region Insert...

        public int Insert(InvoiceDomain newItem)
        {
            var sql = Sql.Builder.Append(" INSERT INTO Invoice (TypeId, ClientId, InvoiceNumber, IssueDate) ")
                .Append(" VALUES (@0, @1, @2, @3) ", EnumHelper.EnumTextToInt(newItem.InvoiceType, typeof(Enums.InvoiceType)), newItem.Client.Id, 
                        newItem.InvoiceNumber, newItem.IssueDate);

            sql.Append(" SELECT SCOPE_IDENTITY() ");

            return DataContext.ExecuteScalar<int>(sql);
        }
        
        #endregion

        #region Update...

        public void Update(InvoiceDomain editedItem)
        {
            var sql = Sql.Builder.Append("UPDATE Invoice ")
                     .Append(" SET TypeId = @0, ClientId = @1, InvoiceNumber = @2, IssueDate = @3 ",
                        EnumHelper.EnumTextToInt(editedItem.InvoiceType, typeof(Enums.InvoiceType)), editedItem.Client.Id,
                        editedItem.InvoiceNumber, editedItem.IssueDate)
                     .Append(" WHERE ID = @0 ", editedItem.Id);

            DataContext.Execute(sql);
        }

        #endregion

        #region Delete...

        public void Delete(int invoiceId)
        {
            var sql = Sql.Builder.Append("UPDATE Invoice ")
                     .Append(" SET DeletedDate = GetDate() ")
                     .Append(" WHERE ID = @0 ", invoiceId);

            DataContext.Execute(sql);
        }

        #endregion
    }
}