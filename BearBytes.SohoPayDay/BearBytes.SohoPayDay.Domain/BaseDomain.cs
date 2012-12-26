using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BearBytes.SohoPayDay.Domain
{
    public class BaseDomain
    {
        /// <summary>
        /// Unique identifier for record
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The ID of the User that owns this record
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Timestamp of when record was added
        /// </summary>
        public DateTime AddedDate { get; set; }

        /// <summary>
        /// Timestamp of when record was deleted
        /// </summary>
        public DateTime DeletedDate { get; set; }
    }
}
