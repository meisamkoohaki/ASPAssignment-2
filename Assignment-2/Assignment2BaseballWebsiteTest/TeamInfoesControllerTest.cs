using Assignment2BaseballWebsite;
using Assignment2BaseballWebsite.Controllers;
using Assignment2BaseballWebsite.Models;
using Assignment2BaseballWebsiteTest;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTest1
{
    public class TeamInfoesControllerTest
    {

        [Fact]
        public async void Test_Create_TeamInfo()
        {
            //Arrange           
            var db = DbSource.CreateDbSource();
            var c = new TeamInfoesController(db);

            var teamInfo = new TeamInfo
            {
                TeamInfoId = 2,
                TeamName = "Aurora",
                TeamLogoURL = "",
                TeamDivision = "Under 18",
                HomeField = "Stadium",
                TeamManager = "Bob"
            };
            //Act
            var r = await c.Create(teamInfo);
            //Assert
            var result = Assert.IsType<RedirectToActionResult>(r);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal(1, db.TeamInfo.Where(x => x.TeamName == teamInfo.TeamName && x.TeamDivision == teamInfo.TeamDivision && x.HomeField == teamInfo.HomeField &&
                             x.TeamManager == teamInfo.TeamManager).Count());
        }

        [Fact]
        public async void Test_Create_Invalid_TeamInfo_TeamName()
        {
            //Arrange
            var db = DbSource.CreateDbSource();
            var c = new TeamInfoesController(db);

            var teamInfo = new TeamInfo
            {
                TeamLogoURL = "",
                TeamDivision = "Adult",
                HomeField = "Stadium",
                TeamManager = "Andrew"
            };
            c.ModelState.AddModelError("TeamName", "Required");

            //Act
            var r = await c.Create(teamInfo);

            //Assert
            var result = Assert.IsType<ViewResult>(r);
            var model = Assert.IsAssignableFrom<TeamInfo>(result.ViewData.Model);
            Assert.Equal(teamInfo, model);
        }

        [Fact]
        public async void Test_Create_Invalid_TeamInfo_TeamDivision()
        {
            //Arrange
            var db = DbSource.CreateDbSource();
            var c = new TeamInfoesController(db);

            var teamInfo = new TeamInfo
            {
                TeamName = "Newmarket",
                TeamLogoURL = "",
                HomeField = "Stadium",
                TeamManager = "Andrew"
            };
            c.ModelState.AddModelError("TeamDivision", "Required");

            //Act
            var r = await c.Create(teamInfo);

            //Assert
            var result = Assert.IsType<ViewResult>(r);
            var model = Assert.IsAssignableFrom<TeamInfo>(result.ViewData.Model);
            Assert.Equal(teamInfo, model);
        }

        [Fact]
        public async void Test_Create_Invalid_TeamInfo_HomeField()
        {
            //Arrange
            var db = DbSource.CreateDbSource();
            var c = new TeamInfoesController(db);

            var teamInfo = new TeamInfo
            {
                TeamName = "Newmarket",
                TeamLogoURL = "",
                TeamDivision = "Adult",
                TeamManager = "Andrew"
            };
            c.ModelState.AddModelError("HomeField", "Required");

            //Act
            var r = await c.Create(teamInfo);

            //Assert
            var result = Assert.IsType<ViewResult>(r);
            var model = Assert.IsAssignableFrom<TeamInfo>(result.ViewData.Model);
            Assert.Equal(teamInfo, model);
        }

        [Fact]
        public async void Test_Create_Invalid_TeamInfo_TeamManager()
        {
            //Arrange
            var db = DbSource.CreateDbSource();
            var c = new TeamInfoesController(db);

            var teamInfo = new TeamInfo
            {
                TeamName = "Newmarket",
                TeamLogoURL = "",
                TeamDivision = "Adult",
                HomeField = "Stadium"
            };
            c.ModelState.AddModelError("TeamManager", "Required");

            //Act
            var r = await c.Create(teamInfo);

            //Assert
            var result = Assert.IsType<ViewResult>(r);
            var model = Assert.IsAssignableFrom<TeamInfo>(result.ViewData.Model);
            Assert.Equal(teamInfo, model);
        }

        [Fact]
        public async void Test_Index_TeamInfo()
        {
            //Arrange
            var db = DbSource.CreateDbSource();
            var c = new TeamInfoesController(db);

            //Act
            var r = await c.Index();

            //Assert
            var result = Assert.IsType<ViewResult>(r);
            var model = Assert.IsAssignableFrom<List<TeamInfo>>(result.ViewData.Model);
            Assert.Equal(1, model.Count());
        }

        [Fact]
        public async void Test_Delete_TeamInfo()
        {
            //Arrange           
            var db = DbSource.CreateDbSource();
            var c = new TeamInfoesController(db);
            var teamInfoe = new TeamInfo
            {
                TeamInfoId = 2,
                TeamName = "Newmarket",
                TeamLogoURL = "",
                TeamDivision = "Adult",
                HomeField = "Stadium",
                TeamManager = "Andrew"
            };

            //Act
            await c.Create(teamInfoe);

            var r = await c.Delete(2);

            //Assert
            var result = Assert.IsType<ViewResult>(r);
            var model = Assert.IsAssignableFrom<TeamInfo>(result.ViewData.Model);

            Assert.Equal(db.TeamInfo.Find(2), model);
        }
    }
}
