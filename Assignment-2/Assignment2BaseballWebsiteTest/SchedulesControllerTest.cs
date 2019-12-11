using Assignment2BaseballWebsite;
using Assignment2BaseballWebsite.Controllers;
using Assignment2BaseballWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Assignment2BaseballWebsiteTest
{
    public class SchedulesControllerTest
    {
        [Fact]
        public async void Test_Create_Schedule()
        {
            //Arrange           
            var db = DbSource.CreateDbSource();
            var c = new SchedulesController(db);

            var schedule = new Schedule
            {
                ScheduleId = 2,
                HomeTeamScore = 3,
                AwayTeamScore = 1,
                GameDate = new DateTime(2019, 05, 05, 13, 50, 22),
                Time = "05:30",
                TeamInfoId = 1
            };
            //Act
            var r = await c.Create(schedule);
            //Assert
            var result = Assert.IsType<RedirectToActionResult>(r);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal(1, db.Schedule.Where(x => x.ScheduleId == schedule.ScheduleId && x.HomeTeamScore == schedule.HomeTeamScore &&
                                                    x.AwayTeamScore == schedule.AwayTeamScore && x.GameDate == schedule.GameDate &&
                                                    x.Time == schedule.Time && x.TeamInfoId == schedule.TeamInfoId).Count());
        }

        [Fact]
        public async void Test_Create_Invalid_Schedule_GameDate()
        {
            //Arrange
            var db = DbSource.CreateDbSource();
            var c = new SchedulesController(db);

            var schedule = new Schedule
            {
                ScheduleId = 2,
                HomeTeamScore = 3,
                AwayTeamScore = 1,
                Time = "05:30",
                TeamInfoId = 1
            };
            c.ModelState.AddModelError("GameDate", "Required");

            //Act
            var r = await c.Create(schedule);

            //Assert
            var result = Assert.IsType<ViewResult>(r);
            var model = Assert.IsAssignableFrom<Schedule>(result.ViewData.Model);
            Assert.Equal(schedule, model);
        }

        [Fact]
        public async void Test_Index_Schedule()
        {
            //Arrange
            var db = DbSource.CreateDbSource();
            var c = new SchedulesController(db);

            //Act
            var r = await c.Index();

            //Assert
            var result = Assert.IsType<ViewResult>(r);
            var model = Assert.IsAssignableFrom<List<Schedule>>(result.ViewData.Model);
            Assert.Equal(1, model.Count());
        }

        [Fact]
        public async void Test_Delete_Schedule()
        {
            //Arrange           
            var db = DbSource.CreateDbSource();
            var c = new SchedulesController(db);
            var schedule = new Schedule
            {
                ScheduleId = 3,
                HomeTeamScore = 31,
                AwayTeamScore = 13,
                GameDate = new DateTime(2019, 05, 05, 13, 50, 22),
                Time = "05:30",
                TeamInfoId = 1
            };

            //Act
            await c.Create(schedule);
            var r = await c.Delete(3);

            //Assert
            var result = Assert.IsType<ViewResult>(r);
            var model = Assert.IsAssignableFrom<Schedule>(result.ViewData.Model);

            Assert.Equal(db.Schedule.Find(3), model);
        }
    }
}
