using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BearBytes.SohoPayDay.Common;


namespace BearBytes.SohoPayDay.Domain
{
    public class ProductCategoryDomain : BaseDomain
    {
        /// <summary>
        /// Name of the Product
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The Product Type
        /// </summary>
        public string ProductType { get; set; }
    }
}
