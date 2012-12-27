using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BearBytes.SohoPayDay.Domain
{
    public class ClientDomain : BaseDomain
    {
        /// <summary>
        /// The Type of Client
        /// </summary>
        public string ClientType { get; set; }

        /// <summary>
        /// Business Name of the Client
        /// </summary>
        public string BusinessName { get; set; }

        /// <summary>
        /// First Name of the Client
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Surname of the Client
        /// </summary>
        public string Surname { get; set; }
    }
}
