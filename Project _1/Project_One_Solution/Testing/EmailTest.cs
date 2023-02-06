using Business_Logic;

namespace Testing
{
    public class EmailTest
    {
        public void Setup()
        {

        }

        [Test]
        [TestCase("Bhargav@gmail.com", true)]
        [TestCase("Bhargav", false)]

        public void EmailCheck(string email, bool s)
        {
            //Arrange
            var result = Validation.Email(email);
            //Assert
            Assert.AreEqual(result, s);
        }
    }
}
