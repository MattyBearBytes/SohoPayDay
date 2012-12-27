using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BearBytes.SohoPayDay.Common;

namespace BearBytes.SohoPayDay.Common.Helpers
{
    public class EnumHelper
    {
        /// <summary>
        /// Converts Client Type string to Enum int
        /// </summary>
        /// <param name="clientType">Client Type to convert</param>
        /// <param name="enumType">Type of Enum to tranform to</param>
        /// <returns></returns>
        public static int EnumTextToInt(string clientType, Type enumType)
        {
            return (int)(Enum.Parse(enumType, clientType));
        }

        /// <summary>
        /// Converts Client Type int to Enum
        /// </summary>
        /// <param name="clientType">Client Type to convert</param>
        /// <returns></returns>
        public static Enums.ClientType ClientTypeToEnum(int clientType)
        {
            return (Enums.ClientType)Enum.Parse(typeof(Enums.ClientType), clientType.ToString());
        }

        /// <summary>
        /// Converts Client Type string to Enum
        /// </summary>
        /// <param name="clientType">Client Type to convert</param>
        /// <returns></returns>
        public static Enums.ClientType ClientTypeToEnum(string clientType)
        {
            return (Enums.ClientType)Enum.Parse(typeof(Enums.ClientType), clientType);
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

        /// <summary>
        /// Converts Invoice Type int to Enum
        /// </summary>
        /// <param name="productType">Invoice Type to convert</param>
        /// <returns></returns>
        public static Enums.InvoiceType InvoiceTypeToEnum(int invoiceType)
        {
            return (Enums.InvoiceType)Enum.Parse(typeof(Enums.InvoiceType), invoiceType.ToString());
        }

        /// <summary>
        /// Converts Invoice Type string to Enum
        /// </summary>
        /// <param name="invoiceType">Invoice Type to convert</param>
        /// <returns></returns>
        public static Enums.InvoiceType InvoiceTypeToEnum(string invoiceType)
        {
            return (Enums.InvoiceType)Enum.Parse(typeof(Enums.InvoiceType), invoiceType);
        }
    
    }
}