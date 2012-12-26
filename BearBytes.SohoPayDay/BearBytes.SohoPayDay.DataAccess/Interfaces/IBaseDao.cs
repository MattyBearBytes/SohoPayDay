namespace BearBytes.SohoPayDay.DataAccess.Interfaces
{
    public interface IBaseDao
    {
        /// <summary>
        /// Begin a Database Transaction
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Abort a Database Transaction
        /// </summary>
        void AbortTransaction();

        /// <summary>
        /// Complete a Database Transaction
        /// </summary>
        void CompleteTransaction();

        /// <summary>
        /// Deletes a Record from the database
        /// </summary>
        /// <param name="recordId">ID of Record to delete</param>
        void Delete(int recordId);
    }
}