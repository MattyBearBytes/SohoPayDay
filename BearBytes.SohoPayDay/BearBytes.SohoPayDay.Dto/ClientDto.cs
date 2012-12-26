using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace BearBytes.SohoPayDay.Dto
{
    public class ClientDto : BaseDto
    {
        /// <summary>
        /// Name of the Client
        /// </summary>
        [Required]
        [Display(Name = "Client Name")]
        public string Name { get; set; }
    }
}
