using Assignment2BaseballWebsite.Data;
using Assignment2BaseballWebsite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2BaseballWebsiteTest
{
    public static class EntityExtensions
    {

        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
    public class DbSource
    {
        public static ApplicationDbContext CreateDbSource()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().
                UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.TeamInfo.Add(new TeamInfo {  TeamInfoId = 1, TeamName = "Newmarket", TeamLogoURL = "", TeamDivision ="Adult",HomeField = "Stadium",TeamManager = "Andrew" }); 
                context.Register.Add(new Register
                {
                    RegisterId = 1,
                    FirstName = "Meisam",
                    LastName = "Koohaki",
                    Gender = "male",
                    BirthMonth = 9,
                    BirthDay = 20,
                    BirthYear = 1990,
                    StreetNumber = 20,
                    StreetName = "King",
                    City = "Toronto",
                    PostalCode = "M2J3K5",
                    PhoneNumber = "4165551234",
                    EmailAddress = "meisam@gmail.com",
                    EmergencyFirstName = "Mike",
                    EmergencyLastName = "Rid",
                    EmergencyPhoneNumber = "4165557896",
                    TeamInfoId = 1
                });
                context.Schedule.Add(new Schedule
                {
                    ScheduleId = 1,
                    HomeTeamScore = 1,
                    AwayTeamScore = 2,
                    GameDate = new DateTime(2019, 05, 05, 13, 50, 22),
                    Time = "03:30",
                    TeamInfoId = 1
                });
                context.PlayerStats.Add(new PlayerStats
                {
                    StatId = 1,
                    Hits = 1,
                    Doubles = 5,
                    Triples = 1,
                    HomeRuns = 4,
                    RunsBattedIn = 6,
                    RegisterId = 1
                });
                context.SaveChanges();
            }
            return new ApplicationDbContext(options);
        }
    }

}
