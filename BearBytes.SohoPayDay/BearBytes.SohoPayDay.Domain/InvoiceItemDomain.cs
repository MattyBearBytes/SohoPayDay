using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BearBytes.SohoPayDay.Common;

namespace BearBytes.SohoPayDay.Domain
{
    public class InvoiceItemDomain : BaseDomain
    {
        /// <summary>
        /// Invoice the Item belongs to
        /// </summary>
        public InvoiceDomain Invoice { get; set; }

        /// <summary>
        /// The Product that is the Order Item
        /// </summary>
        public ProductDomain Product { get; set; }

        /// <summary>
        /// Quantity of the Order Item
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Unit Price of the Order Item
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Calculated Total Price of the Order Item
        /// </summary>
        public decimal TotalPrice
        {
            get { return Quantity * UnitPrice; }
        }
    }
}
