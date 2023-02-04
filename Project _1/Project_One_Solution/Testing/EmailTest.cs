using Business_Logic;

namespace Testing
{
    public class EmailTest
    {
        public void Setup()
        {

        }

        [Test]
        [TestCase("Bhargav@gmail.com", "Bhargav@gmail.com")]
        [TestCase("Bhargav", null)]

        public void EmailCheck(string email, string expected)
        {
            //Arrange
            var result = Validation.Email(email);
            //Assert
            Assert.AreEqual(result, expected);
        }
    }
}
