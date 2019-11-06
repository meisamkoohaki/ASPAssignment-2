using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2BaseballWebsite.Models
{
    public class Schedule
    {

        [Key]
        public virtual int ScheduleId { get; set; }

        [Required]
        public virtual String HomeTeam { get; set; }

        [Required]
        public virtual String AwayTeam { get; set; }

        [Display(Name = "Game Date")]
        [Required]
        public virtual DateTime GameDate { get; set; }

        [Display(Name = "Time")]
        [Required]
        public virtual String Time { get; set; }


    }
}

