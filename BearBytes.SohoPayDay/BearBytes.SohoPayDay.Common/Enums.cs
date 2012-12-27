using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BearBytes.SohoPayDay.Common
{
    public class Enums
    {
        /// <summary>
        /// The Type of Product
        /// </summary>
        public enum ProductType
        {
            All = -1,
            Product = 1,
            Service = 2,
            Labour = 3
        }

        /// <summary>
        /// The Type of Client
        /// </summary>
        public enum ClientType
        {
            All = -1,
            Private = 1,
            Business = 2,
            Supplier = 3
        }

        /// <summary>
        /// The Type of Invoice
        /// </summary>
        public enum InvoiceType
        {
            Quote = 1,
            Invoice = 2
        }
    }
}
