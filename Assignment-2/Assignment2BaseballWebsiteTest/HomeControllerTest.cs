using Assignment2BaseballWebsite.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Xunit;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;

namespace Assignment2BaseballWebsiteTest
{
    public class HomeControllerTest
    {
        [Fact]
        public void Test_Index_Home()
        {
            // var homeController = new HomeController();
            // var result = homeController.Index() as ViewResult;
            // Assert.Equal("Index", result.ViewName);

            // Arrange
            HomeController homeController = new HomeController();
            // Act
            ViewResult result = homeController.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_About_Home()
        {
            // Arrange
            HomeController homeController = new HomeController();
            // Act
            ViewResult result = homeController.About() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_About_Home_Message()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.About() as ViewResult;
            // Assert
            Assert.Equal("Your application description page.", result.ViewData["Message"]);
        }

        [Fact]
        public void Test_Contact_Home()
        {
            // Arrange
            HomeController homeController = new HomeController();
            // Act
            ViewResult result = homeController.About() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_Contact_Home_Message()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Contact() as ViewResult;
            // Assert
            Assert.Equal("Your contact page.", result.ViewData["Message"]);
        }

        [Fact]
        public void Test_Privacy_Home()
        {
            // Arrange
            HomeController homeController = new HomeController();
            // Act
            ViewResult result = homeController.Privacy() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }
    }
}
