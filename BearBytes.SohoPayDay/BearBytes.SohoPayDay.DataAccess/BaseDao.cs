using System;
using System.Collections.Generic;
using System.Configuration;
using BearBytes.SohoPayDay.DataAccess.Interfaces;
using PetaPoco;

namespace BearBytes.SohoPayDay.DataAccess
{
    /// <summary>
    /// BaseDAO for all other DAOs to inherit from
    /// </summary>
    public class BaseDao : IBaseDao
    {

        /// <summary>
        /// Data Context to use for accessing database
        /// </summary>
        public Database DataContext;
        protected string TableName;
        protected string PrimaryKeyName;


        /// <summary>
        /// Construct BaseDAO
        /// </summary>
        public BaseDao()
        {
            //Setup Connection String
            DataContext = new Database(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, ConfigurationManager.ConnectionStrings["DefaultConnection"].ProviderName);
        }

        #region Database Tranactions...

        public void BeginTransaction()
        {
            DataContext.BeginTransaction();
        }

        public void AbortTransaction()
        {
            DataContext.AbortTransaction();
        }

        public void CompleteTransaction()
        {
            DataContext.CompleteTransaction();
        }

        #endregion



        #region Delete...

        /// <summary>
        /// Deletes a Record from the database
        /// </summary>
        /// <param name="recordId">ID of Record to delete</param>
        public virtual void Delete(int recordId)
        {
            DataContext.Execute("UPDATE [" + TableName + "] SET DeletedDate = @0 WHERE ID = @1", DateTime.Now, recordId);
        }

        #endregion


        

    }
}

