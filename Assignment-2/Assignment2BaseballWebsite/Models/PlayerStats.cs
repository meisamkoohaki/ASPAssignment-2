using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2BaseballWebsite.Models
{
    public class PlayerStats
    {
        [Key]
        public virtual int StatId { get; set;}

        public virtual int Hits { get; set; }

        public virtual int Doubles { get; set; }

        public virtual int Triples { get; set; }

        public virtual int HomeRuns { get; set; }

        public virtual int RunsBattedIn { get; set; }

        public virtual Register playerInfo { get; set; }

        public virtual int RegisterId { get; set; }




    }
}
