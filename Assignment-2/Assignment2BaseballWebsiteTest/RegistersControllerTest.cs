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
    public class RegistersControllerTest
    {
        [Fact]
        public async void Test_Create_Register()
        {
            //Arrange           
            var db = DbSource.CreateDbSource();
            var c = new RegistersController(db);

            var register = new Register
            {
                FirstName = "Meisam1",
                LastName = "Koohaki1",
                Gender = "male",
                BirthMonth = 19,
                BirthDay = 2,
                BirthYear = 1970,
                StreetNumber = 10,
                StreetName = "King",
                City = "Toronto",
                PostalCode = "M2J3K5",
                PhoneNumber = "4165551234",
                EmailAddress = "meisam@gmail.com",
                EmergencyFirstName = "Mike",
                EmergencyLastName = "Rid",
                EmergencyPhoneNumber = "4165557896",
                TeamInfoId = 1
            };
            //Act
            var r = await c.Create(register);
            //Assert
            var result = Assert.IsType<RedirectToActionResult>(r);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal(1, db.Register.Where(x => x.FirstName == register.FirstName && x.LastName == register.LastName && x.Gender == register.Gender &&
                                                   x.BirthDay == register.BirthDay && x.BirthMonth == register.BirthMonth && x.BirthYear == register.BirthYear &&
                                                   x.StreetNumber == register.StreetNumber && x.StreetName == register.StreetName && x.City == register.City &&
                                                   x.PostalCode == register.PostalCode && x.PhoneNumber == register.PhoneNumber && x.EmailAddress == register.EmailAddress &&
                                                   x.EmergencyFirstName == register.EmergencyFirstName && x.EmergencyLastName == register.EmergencyLastName &&
                                                   x.EmergencyRelationship == register.EmergencyRelationship && x.EmergencyPhoneNumber == register.EmergencyPhoneNumber &&
                                                   x.TeamInfoId == register.TeamInfoId).Count());
        }

        [Fact]
        public async void Test_Create_Invalid_Register_FirstName()
        {
            //Arrange
            var db = DbSource.CreateDbSource();
            var c = new RegistersController(db);

            var register = new Register
            {
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
            };
            c.ModelState.AddModelError("FirstName", "Required");

            //Act
            var r = await c.Create(register);

            //Assert
            var result = Assert.IsType<ViewResult>(r);
            var model = Assert.IsAssignableFrom<Register>(result.ViewData.Model);
            Assert.Equal(register, model);
        }

        [Fact]
        public async void Test_Create_Invalid_Register_LastName()
        {
            //Arrange
            var db = DbSource.CreateDbSource();
            var c = new RegistersController(db);

            var register = new Register
            {
                FirstName = "Meisam",
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
            };
            c.ModelState.AddModelError("LastName", "Required");

            //Act
            var r = await c.Create(register);

            //Assert
            var result = Assert.IsType<ViewResult>(r);
            var model = Assert.IsAssignableFrom<Register>(result.ViewData.Model);
            Assert.Equal(register, model);
        }

        [Fact]
        public async void Test_Create_Invalid_Register_Gender()
        {
            //Arrange
            var db = DbSource.CreateDbSource();
            var c = new RegistersController(db);

            var register = new Register
            {
                LastName = "Koohaki",
                Gender = "male",
            };
            c.ModelState.AddModelError("Gender", "Required");

            //Act
            var r = await c.Create(register);

            //Assert
            var result = Assert.IsType<ViewResult>(r);
            var model = Assert.IsAssignableFrom<Register>(result.ViewData.Model);
            Assert.Equal(register, model);
        }

        [Fact]
        public async void Test_Delete_Register()
        {
            //Arrange           
            var db = DbSource.CreateDbSource();
            var c = new RegistersController(db);
            var register = new Register
            {
                FirstName = "Meisam1",
                LastName = "Koohaki1",
                Gender = "male",
                BirthMonth = 19,
                BirthDay = 2,
                BirthYear = 1970,
                StreetNumber = 10,
                StreetName = "King",
                City = "Toronto",
                PostalCode = "M2J3K5",
                PhoneNumber = "4165551234",
                EmailAddress = "meisam@gmail.com",
                EmergencyFirstName = "Mike",
                EmergencyLastName = "Rid",
                EmergencyPhoneNumber = "4165557896",
                TeamInfoId = 1
            };

            //Act
            var r = await c.Delete(1);

            //Assert
            var result = Assert.IsType<ViewResult>(r);
            var model = Assert.IsAssignableFrom<Register>(result.ViewData.Model);

            Assert.Equal(db.Register.Find(1), model);
        }
    }
}
