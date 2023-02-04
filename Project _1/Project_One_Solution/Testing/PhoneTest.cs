using Business_Logic;

namespace Testing
{
    public class PhoneTest
    {
        public void Setup()
        {

        }

        [Test]
        [TestCase("9480314998", "9480314998")]
        [TestCase("123456789", null)]

        public void PhoneCheck(string phone, string expected)
        {
            //Arrange
            var result = Validation.Phone(phone);
            //Assert
            Assert.AreEqual(result, expected);
        }
    }
}
