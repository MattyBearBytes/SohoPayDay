using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using BearBytes.SohoPayDay.Common;


namespace BearBytes.SohoPayDay.Dto
{
    public class ClientDto : BaseDto
    {
        /// <summary>
        /// The Type of Client
        /// </summary>
        public string ClientType { get; set; }

        /// <summary>
        /// Business Name of the Client
        /// </summary>
        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }

        /// <summary>
        /// First Name of the Client
        /// </summary>
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Surname of the Client
        /// </summary>
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        /// <summary>
        /// Full Name of the Client.  Business Name if Business.  Name if Private.
        /// </summary>
        public string FullName
        {
            get { return ClientType == "Private" ? FirstName + " " + Surname : BusinessName; }
        }
    }
}
