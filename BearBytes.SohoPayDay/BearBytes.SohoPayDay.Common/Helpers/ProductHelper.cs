using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BearBytes.SohoPayDay.Common;

namespace BearBytes.SohoPayDay.Common.Helpers
{
    public class ProductHelper
    {
        /// <summary>
        /// Converts Product Type string to Enum int
        /// </summary>
        /// <param name="productType">Product Type to convert</param>
        /// <returns></returns>
        public static int ProductTypeToInt(string productType)
        {
            return (int)(Enum.Parse(typeof(Enums.ProductType), productType));
        }

        /// <summary>
        /// Converts Product Type int to Enum
        /// </summary>
        /// <param name="productType">Product Type to convert</param>
        /// <returns></returns>
        public static Enums.ProductType ProductTypeToEnum(int productType)
        {
            return (Enums.ProductType)Enum.Parse(typeof(Enums.ProductType), productType.ToString());
        }

        /// <summary>
        /// Converts Product Type string to Enum
        /// </summary>
        /// <param name="productType">Product Type to convert</param>
        /// <returns></returns>
        public static Enums.ProductType ProductTypeToEnum(string productType)
        {
            return (Enums.ProductType)Enum.Parse(typeof(Enums.ProductType), productType);
        }
    }
}