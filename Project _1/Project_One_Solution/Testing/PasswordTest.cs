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
        [TestCase("Bhargav@420",true)]
        [TestCase("Bhargav", false)]

        public void PasswordCheck(string password,bool s)
        {
            //Arrange
            var result =Validation.Password(password);
            //Assert
            Assert.AreEqual(result, s);
        }
    }
}