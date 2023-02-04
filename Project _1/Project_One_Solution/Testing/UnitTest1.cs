using Models;
using Business_Logic;

namespace Testing
{
    public class Tests
    {
        public void Setup()
        {
           
        }

        [Test]
        [TestCase("Bhargav@420","Bhargav@420")]
        [TestCase("Bhargav", null)]

        public void Test1(string password,string expected)
        {
            //Arrange
            var result =Validation.Password(password);
            //Act
            //Assert
            Assert.AreEqual(result, expected);
        }
    }
}