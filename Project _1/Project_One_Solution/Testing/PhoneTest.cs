using Business_Logic;

namespace Testing
{
    public class PhoneTest
    {
        public void Setup()
        {

        }

        [Test]
        [TestCase("9480314998", true)]
        [TestCase("123456789", false)]

        public void PhoneCheck(string phone, bool s)
        {
            //Arrange
            var result = Validation.Phone(phone);
            //Assert
            Assert.AreEqual(result, s);
        }
    }
}
