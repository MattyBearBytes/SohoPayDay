using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BearBytes.SohoPayDay.Common;

namespace BearBytes.SohoPayDay.Common.Helpers
{
    public class ClientHelper
    {
        /// <summary>
        /// Converts Client Type string to Enum int
        /// </summary>
        /// <param name="clientType">Client Type to convert</param>
        /// <returns></returns>
        public static int ClientTypeToInt(string clientType)
        {
            return (int)(Enum.Parse(typeof(Enums.ClientType), clientType));
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
    }
}