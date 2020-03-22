using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearch.Models;

namespace PeopleSearchUnitTest
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void PersonTest()
        {
            Person testPerson = new Person
            {
                PersonId = 123,
                Address = "123 S St",
                Age = 10,
                FullName = "Michael Garen",
                Interests = "Soccer and pizza"
            };
            Assert.IsNotNull(testPerson);
        }
    }
}
