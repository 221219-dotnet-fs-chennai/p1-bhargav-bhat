using Models;
using Business_Logic;

namespace Testing
{
    public class PasswordTest
    {
        public void Setup()
        {   
        }

        [Test]
        [TestCase("Bhargav@420","Bhargav@420")]
        [TestCase("Bhargav", null)]

        public void PasswordCheck(string password,string expected)
        {
            //Arrange
            var result =Validation.Password(password);
            //Assert
            Assert.AreEqual(result, expected);
        }
    }
}