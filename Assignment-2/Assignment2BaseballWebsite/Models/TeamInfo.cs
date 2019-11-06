using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2BaseballWebsite.Models
{
    public class TeamInfo
    {
        [Key]
        public virtual int TeamInfoId { get; set; }

        [Required]
        public virtual String TeamName { get; set; }

        public virtual String TeamLogoURL { get; set; }

        [Required]
        public virtual String TeamDivision { get; set; }

        [Required]
        public virtual String HomeField { get; set; }

        [Required]
        public virtual String TeamManager { get; set; }


    }
}



