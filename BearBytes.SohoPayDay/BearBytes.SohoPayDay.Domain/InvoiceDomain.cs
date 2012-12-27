using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BearBytes.SohoPayDay.Common;

namespace BearBytes.SohoPayDay.Domain
{
    public class InvoiceDomain : BaseDomain
    {
        //Will this be what we use to tell the difference between a quote and an invoice?
        public string InvoiceType { get; set; }

        /// <summary>
        /// Client the Invoice is for
        /// </summary>
        public ClientDomain Client { get; set; }

        /// <summary>
        /// Date the Invoice is issued for
        /// </summary>
        public DateTime IssueDate { get; set; }

        /// <summary>
        /// Date the Invoice is issued for
        /// </summary>
        public string InvoiceNumber { get; set; }

    }
}
