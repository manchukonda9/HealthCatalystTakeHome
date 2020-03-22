using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PeopleSearch.Controllers;
using PeopleSearch.Models;
using System.Collections.Generic;
using System.Linq;

namespace PeopleSearchUnitTest
{
    [TestClass]
    public class ControllerTests
    {
        private PersonContext _context;

        public PersonContext Context => _context;

        private Person _person;

        [TestMethod]
        public void HomeController_Index_Test()
        {
            // Arrange
            var controller = new HomeController(Context);

            // Act    
            IActionResult actionResult = controller.Index();

            // Assert
            Assert.IsNotNull(actionResult);
        }

        [TestMethod]
        public void HomeController_SearchResult_Test()
        {
            // Arrange
            InitializeContext();
            string searchValue = "liz";
            var mockPersonDbSet = GetQueryableMockPersonDbSet();
            var mockContext = new Mock<PersonContext>();
            mockContext.Setup(m => m.Person).Returns(mockPersonDbSet.Object);
            var controller = new HomeController(mockContext.Object);

            // Act    
            IActionResult actionResult = controller.SearchResult(searchValue);

            // Assert
            Assert.IsNotNull(actionResult);
        }

        private static Mock<DbSet<Person>> GetQueryableMockPersonDbSet()
        {
            var data = new List<Person> { GetTestPerson() }.AsQueryable();
            var mockPersonDbSet = new Mock<DbSet<Person>>();
            mockPersonDbSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(data.Provider);
            mockPersonDbSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(data.Expression);
            mockPersonDbSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockPersonDbSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            return mockPersonDbSet;
        }

        private static Person GetTestPerson()
        {
            return new Person
            {
                Address = "123 S St",
                Age = 10,
                FullName = "Liz Parker",
                Interests = "Soccer",
                PersonId = 1
            };
        }

        private void InitializeContext()
        {
            _person = GetTestPerson();

            var options = new DbContextOptionsBuilder<PersonContext>()
                .UseInMemoryDatabase(databaseName: "ControllerTests")
                .Options;

            _context = new PersonContext(options);
            _context.Person.Add(_person);
            _context.SaveChanges();
        }

    }
}
