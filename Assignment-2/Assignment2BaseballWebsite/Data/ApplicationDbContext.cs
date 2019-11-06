using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Assignment2BaseballWebsite.Models;

namespace Assignment2BaseballWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Assignment2BaseballWebsite.Models.Schedule> Schedule { get; set; }
        public DbSet<Assignment2BaseballWebsite.Models.TeamInfo> TeamInfo { get; set; }
        public DbSet<Assignment2BaseballWebsite.Models.Register> Register { get; set; }
    }
}
