using Assignment2BaseballWebsite;
using Assignment2BaseballWebsite.Controllers;
using Assignment2BaseballWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System;
using Xunit;
using Assignment2BaseballWebsiteTest;

namespace UnitTest1
{
    public class PlayerStatsControllerTest
    {

        [Fact]
        public async void Test_Create_PlayerStats()
        {
            //Arrange           
            var db = DbSource.CreateDbSource();
            var c = new PlayerStatsController(db);

            var playerStats = new PlayerStats
            {
                StatId = 2,
                Hits = 3,
                Doubles = 3,
                Triples = 2,
                HomeRuns = 4,
                RunsBattedIn = 6,
                RegisterId = 1
            };
            //Act
            var r = await c.Create(playerStats);
            //Assert
            var result = Assert.IsType<RedirectToActionResult>(r);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal(1, db.PlayerStats.Where(x => x.RegisterId == playerStats.RegisterId && x.Hits == playerStats.Hits &&
                                                      x.Doubles == playerStats.Doubles && x.Triples == playerStats.Triples &&
                                                      x.HomeRuns == playerStats.HomeRuns && x.RunsBattedIn == playerStats.RunsBattedIn &&
                                                      x.RegisterId == playerStats.RegisterId).Count());
        }

        [Fact]
        public async void Test_Index_PlayerStats()
        {
            //Arrange
            var db = DbSource.CreateDbSource();
            var c = new PlayerStatsController(db);

            //Act
            var r = await c.Index();

            //Assert
            var result = Assert.IsType<ViewResult>(r);
            var model = Assert.IsAssignableFrom<List<PlayerStats>>(result.ViewData.Model);
            Assert.Equal(1, model.Count());
        }

        [Fact]
        public async void Test_Delete_PlayerStats()
        {
            //Arrange           
            var db = DbSource.CreateDbSource();
            var c = new PlayerStatsController(db);
            var playerStats = new PlayerStats
            {
                StatId = 2,
                Hits = 1,
                Doubles = 5,
                Triples = 1,
                HomeRuns = 4,
                RunsBattedIn = 6,
                RegisterId = 1
            };

            //Act
            await c.Create(playerStats);

            var r = await c.Delete(2);

            //Assert
            var result = Assert.IsType<ViewResult>(r);
            var model = Assert.IsAssignableFrom<PlayerStats>(result.ViewData.Model);

            Assert.Equal(db.PlayerStats.Find(2), model);
        }

    }
}
