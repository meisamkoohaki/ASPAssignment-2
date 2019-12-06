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

        [Display(Name = "Home Team")]
        public virtual int HomeTeamScore { get; set; }

        [Display(Name = "Away Team")]
        public virtual int AwayTeamScore { get; set; }

        [Display(Name = "Game Date")]
        [Required]
        public virtual DateTime GameDate { get; set; }

        [Display(Name = "Time")]
 
        public virtual String Time { get; set; }

        public virtual TeamInfo teamInfo { get; set; }

        public virtual int TeamInfoId { get; set; }
    }
}

